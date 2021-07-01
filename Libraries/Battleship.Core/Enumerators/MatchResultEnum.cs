using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Enumerators
{
  public  enum MatchResultEnum : byte
    {
        [Description("None")]
        None = 0,
        [Description("Won")]
        Won = 1,
        [Description("Lost")]
        Lost = 2
    }
}
