using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a destroyer, which is used for the BattleShip game.
    /// </summary>
    internal class Destroyer : Ship
    {
        /// <summary>
        /// Initializes a new instance of the Destroyer class with a specified position and direction.
        /// </summary>
        /// <param name="position">The starting position of the destroyer.</param>
        /// <param name="direction">The direction the destroyer is facing.</param>
        public Destroyer(Coord2D position, DirectionType direction) : base(position, direction, 3) { }

        /// <summary>
        /// Retrieves the name of the destroyer.
        /// </summary>
        /// <returns>The name "Destroyer".</returns>
        public override string GetName()
        {
            return "Destroyer";
        }
    }
}
