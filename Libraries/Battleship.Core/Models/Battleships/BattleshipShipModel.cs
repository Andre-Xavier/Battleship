using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models.Battleships
{
    public class BattleshipShipModel : ShipModel
    {
        #region Constructors
        public BattleshipShipModel()
        {
            base.Size = 4;
            base.Name = "Battleship";
            base.Coordinates = new PositionModel[base.Size];
        }
        #endregion Constructors
    }
}
