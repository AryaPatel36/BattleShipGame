using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Represents a two-dimensional coordinate.
    /// </summary>
    public struct Coord2D
    {
        /// <summary>
        /// Gets or sets the X-coordinate value.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the Y-coordinate value.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the Coord2D structure with specified x and y coordinates.
        /// </summary>
        /// <param name="x">The horizontal position.</param>
        /// <param name="y">The vertical position.</param>
        public Coord2D(int x, int y) 
        { 
            X = x;
            Y = y;
        }
    }
}
