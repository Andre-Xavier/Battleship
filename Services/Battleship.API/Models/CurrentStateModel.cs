using Battleship.Core.Enumerators;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.API.Models
{
    public class CurrentStateModel
    {
        #region Properties
        public GameBoardModel GameBoard { get; set; }
        public IList<PlacedShipModel> PlacedShips { get; set; }
        public byte BattleshipsTotalOnHand => (byte)PlacedShips.Count(p => !p.IsSunk);
        public MatchResultEnum Result { get; set; }
        #endregion Properties

        #region Constructors
        public CurrentStateModel()
        {
            this.GameBoard = null;
            this.PlacedShips = new List<PlacedShipModel>();
            this.Result = MatchResultEnum.None;
        }
        #endregion Constructors
    }
}
