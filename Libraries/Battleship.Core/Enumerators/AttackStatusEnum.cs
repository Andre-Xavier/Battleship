using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Core.Enumerators
{
  public  enum AttackStatusEnum : byte
    {
        [Description("None")]
        None = 0,
        [Description("Miss")]
        Miss = 1,
        [Description("Hit")]
        Hit = 2
    }
}
