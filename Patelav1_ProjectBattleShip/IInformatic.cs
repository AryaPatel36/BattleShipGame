using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    /// <summary>
    /// Provides a mechanism to retrieve information.
    /// </summary>
    internal interface IInformatic
    {
        /// <summary>
        /// Retrieves information as a string.
        /// </summary>
        /// <returns>A string containing the information.</returns>
        public string GetInfo();
    }
}
