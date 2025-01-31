using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a submarine, which is used for the BattleShip game.
    /// </summary>
    internal class Submarine : Ship
    {
        /// <summary>
        /// Initializes a new instance of the Submarine class with a specified position and direction.
        /// </summary>
        /// <param name="position">The starting position of the submarine.</param>
        /// <param name="direction">The direction the submarine is facing.</param>
        public Submarine(Coord2D position, DirectionType direction) : base(position, direction, 3) { }

        /// <summary>
        /// Retrieves the name of the submarine.
        /// </summary>
        /// <returns>The name "Submarine".</returns>
        public override string GetName()
        {
            return "Submarine";
        }
    }
}
