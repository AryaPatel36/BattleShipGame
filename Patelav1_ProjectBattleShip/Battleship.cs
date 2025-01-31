using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a battleship, which is used for the BattleShip game.
    /// </summary>
    public class Battleship : Ship
    {
        /// <summary>
        /// Initializes a new instance of the Battleship class with a specified position and direction.
        /// </summary>
        /// <param name="position">The starting position of the battleship on the grid.</param>
        /// <param name="direction">The orientation of the battleship, determining how it is placed on the grid.</param>
        public Battleship(Coord2D position, DirectionType direction) : base(position, direction, 4) { }

        /// <summary>
        /// Retrieves the name of the battleship.
        /// </summary>
        /// <returns>The name "Battleship".</returns>
        public override string GetName()
        {
            return "Battleship";
        }

    }
}
