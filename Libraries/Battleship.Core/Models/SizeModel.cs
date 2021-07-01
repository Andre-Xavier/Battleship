using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models
{
    public class SizeModel
    {
        #region Properties
        public byte Columns { get; protected set; }
        public byte Rows { get; protected set; }
        #endregion Properties

        #region Constructors
        protected SizeModel()
        {

        }
        public SizeModel(byte size)
        {
            this.Columns = this.Rows = size;
        }
        public SizeModel(byte columns, byte rows)
        {
            this.Columns = columns;
            this.Rows = rows;
        }
        #endregion Constructors

        #region Methods
        public override string ToString()
        {
            return $"[{this.Columns},{this.Rows}]";
        }
        #endregion Methods
    }
}
