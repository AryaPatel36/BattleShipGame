using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Patelav1_ProjectBattleShip
{
    public class ShipFactory
    {
        /// <summary>
        /// Verifies the format of a ship description string against a specified pattern.
        /// </summary>
        /// <param name="description">The ship description to verify.</param>
        /// <returns>True if the description matches the pattern, otherwise false.</returns>
        /// <exception cref="ShipParseException">Thrown when the description does not match the pattern.</exception>
        /// <remarks>
        /// The ship description should be in the format: "Name: [name], Length: [length], Direction: [Horizontal/Vertical], Position: ([x],[y])".
        /// </remarks>
        public static bool VerifyShipString(string description)
        {
            // Regular expression pattern to extract ship details. 
            // Assumes the string is formatted like this example: "Name: Battleship, Length: 4, Direction: Horizontal, Position: (3,5)"
            string pattern = @"(.+?)\s*,\s*(\d+)\s*,\s*(h|v)\s*,\s*(\d+)\s*,\s*(\d+)";
            var match = Regex.Match(description, pattern);

            // If the pattern is not matched, the string is invalid.
            if (!match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        /// <summary>
        /// Parses a ship description string and verifies it against a predefined format. Additionally, extracts ship details such as name, length, direction, and position.
        /// </summary>
        /// <param name="description">The ship description string to parse.</param>
        /// <returns>A new instance of the ship type based on the parsed details.</returns>
        /// <exception cref="ShipParseException">
        /// Thrown when the input string does not match the expected format or when an invalid ship type is encountered.
        /// Thrown if the parsed position has negative coordinates.
        /// Thrown if the length of the ship is not within the bounds (1-5).
        /// Thrown if the ship's position and length are out of the 10x10 grid bounds.
        /// </exception>
        public static Ship ParseShipString(string description)
        {
            // Verify the format of the ship string against the defined pattern.
            // If the string does not match, throw an exception.
            if (!VerifyShipString(description))
            {
                throw new ShipParseException("Invalid ship string format.");
            }


            // Match the ship string against the regular expression pattern to extract ship details.
            // I ChatGPT'd this regex
            var match = Regex.Match(description, @"(.+?)\s*,\s*(\d+)\s*,\s*(h|v)\s*,\s*(\d+)\s*,\s*(\d+)");

            string name = match.Groups[1].Value;
            int length = int.Parse(match.Groups[2].Value);
            char direction = char.Parse(match.Groups[3].Value);
            int posX = int.Parse(match.Groups[4].Value);
            int posY = int.Parse(match.Groups[5].Value);

            DirectionType shipDirection;
            if (direction == 'h')
            {
                shipDirection = DirectionType.Horizontal;
            }
            else
            {
                shipDirection = DirectionType.Vertical;
            }


            if (posX < 0 || posY < 0)
            {
                throw new ShipParseException($"Error: {name} has negative positions.");
            }

            // Check if the ship's length is less than 1 or greater than 5 inclusive
            if (length < 1 || length > 5)
            {
                throw new ShipParseException($"Error: {name}'s length is not within the bound (1-5).");
            }

            // Check if the ship's position and length are within bounds.
            // The ship must not extend beyond the grid size of 10x10.
            if (shipDirection == DirectionType.Horizontal)
            {
                if (posX < 0 || posX + length > 10 || posY < 0 || posY >= 10)
                {
                    throw new ShipParseException($"Error: {name} is out of bounds horizontally.");
                }
            }
            else if (shipDirection == DirectionType.Vertical)
            {
                if (posY < 0 || posY + length > 10 || posX < 0 || posX >= 10)
                {
                    throw new ShipParseException($"Error: {name} is out of bounds vertically.");
                }
            }


            // Creates a new Coord2D object for the ship's position using the parsed X and Y coordinates.
            Coord2D position = new Coord2D(posX, posY);

            /* Determine the type of ship to create based on the name extracted from the string,
             and return a new instance of that ship type. */
            return CreateShip(name, shipDirection, position);
            
        }

        /// <summary>
        /// Creates a new ship object of the specified type.
        /// </summary>
        /// <param name="name">The name of the ship type. Spaces in the name are ignored.</param>
        /// <param name="shipDirection">The direction of the ship, either horizontal or vertical.</param>
        /// <param name="position">The starting coordinate (top-left corner) of the ship.</param>
        /// <returns>A new instance of a ship derived from the Ship base class.</returns>
        /// <exception cref="ShipParseException">Thrown when the ship type name does not match any known types.</exception>
        private static Ship CreateShip(string name, DirectionType shipDirection, Coord2D position)
        {
            switch (name.Replace(" ", ""))
            {
                case "Battleship":
                    return new Battleship(position, shipDirection);
                case "Destroyer":
                    return new Destroyer(position, shipDirection);
                case "Carrier":
                    return new Carrier(position, shipDirection);
                case "Submarine":
                    return new Submarine(position, shipDirection);
                case "PatrolBoat":
                    return new PatrolBoat(position, shipDirection);
                default:
                    throw new ShipParseException($"Error: Unknown ship type: {name}.");
            }
        }

        /// <summary>
        /// Parses a file to create a collection of ship objects.
        /// </summary>
        /// <param name="filePath">The path to the file containing ship data.</param>
        /// <returns>An array of <see cref="Ship"/> objects constructed from the file data.</returns>
        /// <exception cref="ShipParseException">Thrown when a duplicate ship name is encountered,
        /// when an overlapping position is detected, when more than the expected number of ships is found,
        /// or when fewer ships than expected are found.</exception>
        public static Ship[] ParseShipFile(string filePath)
        {
            var ships = new List<Ship>();


            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (VerifyShipString(line))
                    {
                        Ship ship = ParseShipString(line);
                        ships.Add(ship);
                    }
                }
            }
            return ships.ToArray();
        }
    }
}
