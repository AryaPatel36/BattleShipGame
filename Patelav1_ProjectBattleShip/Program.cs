// See https://aka.ms/new-console-template for more information
using Patelav1_ProjectBattleShip;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
class Program
{
    static string filePath;
    static Ship[] ships;

    static void Main(string[] args)
    {
        RequestFilePath();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("The file does not exist or cannot be opened. Exiting the program.");
            return;
        }

        LoadShipsFromFile();
        GameLoop();
    }

    static void RequestFilePath()
    {
        Console.Write("Please enter the file path: ");
        filePath = Console.ReadLine();
        filePath = filePath.Replace("\"", string.Empty);
    }

    static void LoadShipsFromFile()
    {
        try
        {
            ships = ShipFactory.ParseShipFile(filePath);
            Console.WriteLine("File has been successfully imported!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while parsing the file: {ex.Message}");
            ships = null;
        }
    }

    static void GameLoop()
    {
        bool allShipsDestroyed = false;
        while (!allShipsDestroyed)
        {
            Console.Write("Enter command: ");
            string input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "EXIT":
                    Console.WriteLine("Exiting the game...");
                    return;
                case "INFO":
                    DisplayShipInfo();
                    break;
                default:
                    if (TryParseCoordinates(input, out int x, out int y))
                    {
                        ProcessAttack(x, y, out allShipsDestroyed);
                    }
                    else
                    {
                        Console.WriteLine("Command not recognized.");
                    }
                    break;
            }
        }
        Console.WriteLine("All ships have been destroyed! Game Over!");
    }

    static void DisplayShipInfo()
    {
        foreach (var ship in ships)
        {
            Console.WriteLine(ship.GetInfo());
        }
    }

    static bool TryParseCoordinates(string input, out int x, out int y)
    {
        x = y = 0;
        var match = Regex.Match(input, @"^(\d+),\s*(\d+)$");
        if (!match.Success) return false;

        x = int.Parse(match.Groups[1].Value);
        y = int.Parse(match.Groups[2].Value);
        return true;
    }

    static void ProcessAttack(int x, int y, out bool allShipsDestroyed)
    {
        allShipsDestroyed = true;
        bool hit = false;

        foreach (var ship in ships)
        {
            if (ship.CheckIfHit(new Coord2D(x, y)))
            {
                ship.TakeDamage(new Coord2D(x, y));
                Console.WriteLine($"Hit confirmed on {ship.GetName()}. Current health: {ship.GetCurrentHealth()}");
                hit = true;
                break;
            }
        }

        if (!hit)
        {
            Console.WriteLine("Missed.");
        }

        foreach (var ship in ships)
        {
            if (!ship.IsDead())
            {
                allShipsDestroyed = false;
                break;
            }
        }
    }
}