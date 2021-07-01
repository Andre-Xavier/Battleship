using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Models
{
  public  class PositionModel
    {
        #region Properties
        public byte X { get; protected set; }
        public byte Y { get; protected set; }
        #endregion Properties

        #region Constructors
        public PositionModel()
        {
            this.X = 0;
            this.Y = 0;
        }
        public PositionModel(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion Constructors

        #region Methods
        public override string ToString()
        {
            return $"({this.X},{this.Y})";
        }
        #endregion Methods
    }
}
