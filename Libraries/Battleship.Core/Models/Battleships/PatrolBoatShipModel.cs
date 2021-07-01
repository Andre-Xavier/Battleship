using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models.Battleships
{
    public class PatrolBoatShipModel : ShipModel
    {
        #region Constructors
        public PatrolBoatShipModel()
        {
            base.Size = 2;
            base.Name = "Patrol Boat";
            base.Coordinates = new PositionModel[base.Size];
        }
        #endregion Constructors
    }
}
