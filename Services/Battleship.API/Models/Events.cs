using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Battleship.Core.Enumerators;
using Battleship.Core.Interfaces;
using Battleship.Core.Models;

namespace Battleship.API.Models
{
    public interface IEvent { }

    public record BoardCreated(string player, SizeModel size, DateTime dateTime) : IEvent;

    public record BattleshipPlaced(string player, ShipModel ship, DateTime dateTime) : IEvent;

    public record AttackTaken(string player, PositionModel position,AttackStatusEnum AttackResult, DateTime dateTime) : IEvent;

    public record MatchFinished(string player, MatchResultEnum result, DateTime dateTime) : IEvent;
}
