using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Defines a health management system for an ship.
/// </summary>
namespace Patelav1_ProjectBattleShip
{
    internal interface IHealth
    {
        /// <summary>
        /// Gets the maximum health of the ship.
        /// </summary>
        /// <returns>The maximum health value.</returns>
        public int GetMaxHealth();

        /// <summary>
        /// Gets the current health of the ship.
        /// </summary>
        /// <returns>The current health value.</returns>
        public int GetCurrentHealth();

        /// <summary>
        /// Determines if the ship is dead.
        /// </summary>
        /// <returns>True if the ship is dead, otherwise false.</returns>
        public bool IsDead();

    }
}
