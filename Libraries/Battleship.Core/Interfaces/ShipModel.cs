using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Interfaces
{
    public abstract class ShipModel
    {
        #region Properties
        public byte Size { get; protected set; }
        public string Name { get; protected set; }
        public PositionModel[] Coordinates { get; protected set; }
        #endregion Properties

        #region Methods
        public override string ToString()
        {
            return $"{this.Name} Size:{this.Size} Coordinates:({(string.Join(",", this.Coordinates.Select(p => p.ToString()).ToArray()))})";
        }
        #endregion Methods
    }
}
