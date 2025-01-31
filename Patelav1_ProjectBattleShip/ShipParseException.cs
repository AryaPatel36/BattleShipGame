using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patelav1_ProjectBattleShip
{
    public class ShipParseException : Exception
    {
        public ShipParseException(string message) : base(message)
        {

        }
    }
}
