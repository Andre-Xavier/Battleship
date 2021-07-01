using Battleship.Core.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models
{
    public class GameBoardModel : SizeModel
    {
        #region properties
        public BoardCellStatusEnum[,] CellStatus { get; set; }
        public AttackStatusEnum[,] AttackTakenStatus { get; set; }
        #endregion properties

        #region Constructors
        public GameBoardModel(SizeModel size)
        {         
            this.Columns = size.Columns;
            this.Rows = size.Rows;
            this.CellStatus = new BoardCellStatusEnum[this.Columns, this.Rows];
            this.AttackTakenStatus = new AttackStatusEnum[this.Columns, this.Rows];

            for (int c = 0; c < this.Columns; c++)
            {
                for (int r = 0; r < this.Rows; r++)
                {
                    this.CellStatus[c, r] = BoardCellStatusEnum.Empty;
                    this.AttackTakenStatus[c, r] = AttackStatusEnum.None;
                }
            }
        }
        #endregion Constructors
    }
}
