using Battleship.Core.Enumerators;
using Battleship.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models
{
   public class PlacedShipModel : ShipModel
    {
        #region properties
        public  AttackStatusEnum[] SectionStatus { get; private set; }
        public byte HitsTaken => (byte)SectionStatus.Count(p => p == AttackStatusEnum.Hit);
        public bool IsSunk => HitsTaken >= base.Size;
        #endregion properties

        #region Constructors
        public PlacedShipModel(ShipModel ship)
        {
            base.Size = ship.Size;
            base.Name = ship.Name;
            base.Coordinates = ship.Coordinates;
            this.SectionStatus = new AttackStatusEnum[base.Size];
        }
        #endregion Constructors
    }
}
