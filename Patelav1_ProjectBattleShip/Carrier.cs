using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a carrier, which is used for the BattleShip game.
    /// </summary>
    internal class Carrier : Ship
    {
        /// <summary>
        /// Initializes a new instance of the Carrier class with a specified position and direction.
        /// </summary>
        /// <param name="position">The starting position of the carrier on the grid.</param>
        /// <param name="direction">The orientation of the carrier, determining how it is placed on the grid.</param>
        public Carrier(Coord2D position, DirectionType direction) : base(position, direction, 5) { }

        /// <summary>
        /// Retrieves the name of the carrier.
        /// </summary>
        /// <returns>The name "Carrier".</returns>
        public override string GetName()
        {
            return "Carrier";
        }
    }
}
