using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models.Battleships
{
    public class CarrierShipModel : ShipModel
    {
        #region Constructors
        public CarrierShipModel()
        {
            base.Size = 5;
            base.Name = "Carrier";
            base.Coordinates = new PositionModel[base.Size];
        }
        #endregion Constructors
    }
}
