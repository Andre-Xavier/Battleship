using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models.Battleships
{
    public class DestroyerShipModel : ShipModel
    {
        #region Constructors
        public DestroyerShipModel()
        {
            base.Size = 3;
            base.Name = "Destroyer";
            base.Coordinates = new PositionModel[base.Size];
        }
        #endregion Constructors
    }
}
