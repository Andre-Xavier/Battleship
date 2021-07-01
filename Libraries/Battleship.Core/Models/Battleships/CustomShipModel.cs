using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models.Battleships
{
    public class CustomShipModel : ShipModel
    {
        #region Constructors
        public CustomShipModel(byte size, string name)
        {
            base.Size = size;
            base.Name = name;
            base.Coordinates = new PositionModel[base.Size];
        }
        #endregion Constructors
    }
}
