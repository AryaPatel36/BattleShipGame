using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    public abstract class Ship : IHealth, IInformatic
    {
        /// <summary>
        /// The position of the object in a 2D space.
        /// </summary>
        public Coord2D Position {  get; private set; }

        /// <summary>
        /// The direction the object is facing.
        /// </summary>
        public DirectionType Direction { get; private set; }

        /// <summary>
        /// The length of the object, represented as a byte.
        /// </summary>
        public byte Length { get; private set; }

        /// <summary>
        /// An array of 2D points representing specific locations.
        /// </summary>
        public Coord2D[] Points { get; private set; }

        /// <summary>
        /// A list of 2D points representing areas that have been damaged.
        /// </summary>
        public List<Coord2D> DamagedPoints { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Ship class with specified position, direction, and length.
        /// </summary>
        /// <param name="position">The starting position of the ship represented as a Coord2D.</param>
        /// <param name="direction">The direction of the ship, either horizontal or vertical.</param>
        /// <param name="length">The length of the ship, indicating how many points it occupies on the grid.</param>
        public Ship(Coord2D position, DirectionType direction, byte length)
        {
            Position = position;
            Direction = direction;
            Length = length;
            DamagedPoints = new List<Coord2D>();
            Points = GeneratePoints(position, direction, length);
        }

        /// <summary>
        /// Generates an array of points representing the ship's position on a grid.
        /// </summary>
        /// <param name="position">The starting position of the ship, representing the top-left corner.</param>
        /// <param name="direction">The direction of the ship (horizontal or vertical).</param>
        /// <param name="length">The length of the ship.</param>
        /// <returns>An array of <see cref="Coord2D"/> representing each point the ship occupies based on its length and direction.</returns>
        private Coord2D[] GeneratePoints(Coord2D position, DirectionType direction, int length)
        {
            Coord2D[] points = new Coord2D[length];

            for (int i = 0; i < length; i++)
            {
                if (direction == DirectionType.Horizontal)
                {
                    points[i] = new Coord2D(position.X + i, position.Y);
                }
                else if (direction == DirectionType.Vertical)
                {
                    points[i] = new Coord2D(position.X, position.Y + i);
                }
            }
            return points;
        }

        /// <summary>
        /// Determines whether the specified point has been hit by checking each point in the array.
        /// </summary>
        /// <param name="point">The point to check against the ship's points.</param>
        /// <returns>true if the point is in the array of points; otherwise, false.</returns>
        public bool CheckIfHit(Coord2D point)
        {
            foreach (Coord2D p in Points)
            {
                if(p.X == point.X &&  p.Y == point.Y)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Records damage to the ship at the specified point if not already damaged.
        /// </summary>
        /// <param name="point">The point of impact to check and record.</param>
        public void TakeDamage(Coord2D point) 
        {
            if (!DamagedPoints.Contains(point))
            {
                DamagedPoints.Add(point);
            }
        }

        /// <summary>
        /// Retrieves the name of the ship.
        /// </summary>
        /// <returns>The name of the ship.</returns>
        public abstract string GetName();

        /// <summary>
        /// Calculates and retrieves the current health of the ship based on its maximum health and the number of damaged points.
        /// </summary>
        /// <returns>The current health of the ship, which is the difference between the maximum health and the number of damaged points.</returns>
        public int GetCurrentHealth()
        {
            return GetMaxHealth() - DamagedPoints.Count;
        }

        /// <summary>
        /// Gets a string containing detailed information about the ship.
        /// </summary>
        /// <remarks>
        /// The information includes the ship's name, maximum health, current health, whether it's dead,
        /// and its direction. It also lists all positions the ship occupies on the grid.
        /// </remarks>
        /// <returns>A string detailing the ship's information and occupied positions.</returns>
        public string GetInfo()
        {
            bool isDead = IsDead();
            var allPositions = GetAllPositions();
            string allPositionsString = string.Join(", ", allPositions.Select(p => $"({p.X}, {p.Y})"));

            return
                $"\nName: {GetName()}\n" +
                $"Max Health: {GetMaxHealth()}\n" +
                $"Current Health: {GetCurrentHealth()}\n" +
                $"IsDead: {isDead}\n" +
                $"Position: {allPositionsString}\n" +
                $"Length: {Length}\n" +
                $"Direction: {Direction}\n";
        }

        /// <summary>
        /// Retrieves a list of all the coordinates that the ship occupies on a grid.
        /// </summary>
        /// <remarks>
        /// The method calculates the ship's occupied positions based on its starting position,
        /// length, and direction. It assumes a grid with horizontal and vertical coordinates.
        /// </remarks>
        /// <returns>
        /// A list of <see cref="Coord2D"/> objects, each representing a coordinate on the grid
        /// occupied by the ship.
        /// </returns>
        private List<Coord2D> GetAllPositions()
        {
            var allPositions = new List<Coord2D>();

            for (int i = 0; i < Length; i++)
            {
                if (Direction == DirectionType.Horizontal)
                {
                    allPositions.Add(new Coord2D(Position.X + i, Position.Y));
                }
                else if (Direction == DirectionType.Vertical)
                {
                    allPositions.Add(new Coord2D(Position.X, Position.Y + i));
                }
            }
            return allPositions;
        }

        /// <summary>
        /// Retrieves the maximum health capacity of the ship.
        /// </summary>
        /// <returns>The maximum health value.</returns>
        public int GetMaxHealth()
        {
            return Length;
        }

        /// <summary>
        /// Checks if the ship is dead, which is determined by whether the current health is less than or equal to zero.
        /// </summary>
        /// <returns>true if the ship is dead; otherwise, false.</returns>
        public bool IsDead()
        {
            if(GetCurrentHealth() <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
