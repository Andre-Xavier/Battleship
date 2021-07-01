using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Enumerators
{
  public  enum BoardCellStatusEnum: byte
    {
        [Description("Empty")]
        Empty = 0,
        [Description("Occupied")]
        Occupied = 1
    }
}
