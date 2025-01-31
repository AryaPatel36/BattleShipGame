using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a patrol boat, which is used for the BattleShip game.
    /// </summary>
    internal class PatrolBoat : Ship
    {
        /// <summary>
        /// Initializes a new instance of the PatrolBoat class with a specified position and direction.
        /// </summary>
        /// <param name="position">The starting position of the patrol boat.</param>
        /// <param name="direction">The direction the patrol boat is facing.</param>
        public PatrolBoat(Coord2D position, DirectionType direction) : base(position, direction, 2) { }

        /// <summary>
        /// Retrieves the name of the patrol boat.
        /// </summary>
        /// <returns>The name "Patrol Boat".</returns>
        public override string GetName()
        {
            return "Patrol Boat";
        }
    }
}
