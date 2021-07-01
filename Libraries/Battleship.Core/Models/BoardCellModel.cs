using Battleship.Core.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models
{
    public class BoardCellModel : PositionModel
    {
        #region Properties
        public BoardCellStatusEnum CellStatus { get; set; }
        public AttackStatusEnum AttackStatus { get; set; }
        #endregion Properties

        #region Constructors
        public BoardCellModel(PositionModel position)
        {
            base.X = position.X;
            base.Y = position.Y;
            this.CellStatus = BoardCellStatusEnum.Empty;
            this.AttackStatus = AttackStatusEnum.None;
        }
        #endregion Constructors

        #region Methods
        public bool TakeAttack()
        {
            switch (CellStatus)
            {
                case BoardCellStatusEnum.Empty:
                    this.AttackStatus = AttackStatusEnum.Miss;
                    break;
                case BoardCellStatusEnum.Occupied:
                    this.AttackStatus = AttackStatusEnum.Hit;
                    break;
                default:
                    break;
            }
            return this.AttackStatus == AttackStatusEnum.Hit;
        }

        public bool PlaceBattleship() {
            switch (this.CellStatus)
            {
                case BoardCellStatusEnum.Empty:
                    this.CellStatus = BoardCellStatusEnum.Occupied;
                    break;
                case BoardCellStatusEnum.Occupied:
                default:
                    break;
            }
            return this.CellStatus == BoardCellStatusEnum.Occupied; 
        }
        #endregion Methods
    }
}
