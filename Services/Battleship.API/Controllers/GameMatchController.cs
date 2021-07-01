using Battleship.API.Models;
using Battleship.API.Repositories;
using Battleship.Core.Enumerators;
using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.API.Controllers
{
    public class GameMatchController
    {
        private GameMatchModel Player1GameMatch { get; set; }
        private GameMatchModel Player2GameMatch { get; set; }
        private readonly GameMatchRepository _repository;

        public GameMatchController(string player1, string player2)
        {
            if (string.IsNullOrWhiteSpace(player1))
            {
                throw new Exception($"The player 1 name is invalid!");
            }
            else if (string.IsNullOrWhiteSpace(player2))
            {
                throw new Exception($"The player 2 name is invalid!");
            }
            else if (player1.ToLowerInvariant() == player2.ToLowerInvariant())
            {
                throw new Exception($"The players name cannot be the same!");
            }
            _repository = new GameMatchRepository();

            this.Player1GameMatch = _repository.Get(player1);
            this.Player2GameMatch = _repository.Get(player2);
        }

        public void CreateGameBoard(string player, SizeModel size)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new Exception($"The player name is invalid!");
            }
            else 
            if (Player1GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant() && Player2GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant())
            {
                throw new Exception($"The player {player} does not take part in the match!");
            }

            if (Player1GameMatch.Player == player)
            {
                Player1GameMatch.CreateBoard(size);
            }
            else if (Player2GameMatch.Player == player)
            {
                Player2GameMatch.CreateBoard(size);
            }

        }

        public void PlaceBattleships(string player, IList<ShipModel> ships)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new Exception($"The player name is invalid!");
            }
            else
            if (Player1GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant() && Player2GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant())
            {
                throw new Exception($"The player {player} does not take part in the match!");
            }
            if (ships == null || ships.Count == 0)
            {
                throw new Exception($"The battleship list is null or empty!");
            }

            if (Player1GameMatch.Player == player)
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    Player1GameMatch.PlaceBattleship(ships[i]);
                }
            }
            else if (Player2GameMatch.Player == player)
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    Player2GameMatch.PlaceBattleship(ships[i]);
                }
            }
        }

        public AttackStatusEnum TakeAttack(string player, PositionModel position)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new Exception($"The player name is invalid!");
            }
            else
            if (Player1GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant() && Player2GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant())
            {
                throw new Exception($"The player {player} does not take part in the match!");
            }

            var result = AttackStatusEnum.None;
            if (Player1GameMatch.Player == player)
            {
                result = Player1GameMatch.TakeAttack(position);
            }
            else if (Player2GameMatch.Player == player)
            {
                result = Player2GameMatch.TakeAttack(position);
            }
            return result;
        }

        public bool HasLostMatch(string player)
        {
            if (string.IsNullOrWhiteSpace(player))
            {
                throw new Exception($"The player name is invalid!");
            }
            else
            if (Player1GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant() && Player2GameMatch.Player.ToLowerInvariant() != player.ToLowerInvariant())
            {
                throw new Exception($"The player {player} does not take part in the match!");
            }

            var result = false;
            if (Player1GameMatch.Player == player)
            {
                if (Player1GameMatch.MatchResult() == MatchResultEnum.Lost)
                {
                    Player1GameMatch.FinishMatch(MatchResultEnum.Lost);
                    Player2GameMatch.FinishMatch(MatchResultEnum.Won);
                    result = true;
                }
            }
            else if (Player2GameMatch.Player == player)
            {
                if (Player2GameMatch.MatchResult() == MatchResultEnum.Lost)
                {
                    Player2GameMatch.FinishMatch(MatchResultEnum.Lost);
                    Player1GameMatch.FinishMatch(MatchResultEnum.Won);
                    result = true;
                }
            }
            return result;
        }

        public IList<IEvent> GetEvents(string player = null)
        {
            if (player != null && Player1GameMatch.Player != player && Player2GameMatch.Player == player)
            {
                throw new Exception($"The player {player} does not take part in the match!");
            }

            var result = new List<IEvent>();
            if (player == null ||Player1GameMatch.Player == player)
            {
                result.AddRange(Player1GameMatch.GetEvents());
            }
            if (player == null || Player2GameMatch.Player == player)
            {
                result.AddRange(Player2GameMatch.GetEvents());
            }

            result = result.OrderBy(p => (
                 (p is BoardCreated) ? ((BoardCreated)p).dateTime : (
                 (p is BattleshipPlaced) ? ((BattleshipPlaced)p).dateTime : (
                 (p is AttackTaken) ? ((AttackTaken)p).dateTime : (
                 (p is MatchFinished) ? ((MatchFinished)p).dateTime : DateTime.MaxValue))))).ToList();

            return result;
        }

        public IList<string> GetEventLogs(string player = null)
        {
            var result = new List<string>();
            var events = GetEvents(player);

            for (int i = 0; i < events.Count; i++)
            {
                switch (events[i])
                {
                    case BoardCreated evnt:
                        result.Add($"{evnt.dateTime:u} - Player:{evnt.player} - Board Created: Size:{evnt.size}");
                        break;
                    case BattleshipPlaced evnt:
                        result.Add($"{evnt.dateTime:u} - Player:{evnt.player} - Ship Placed: {evnt.ship.ToString()}");
                        break;
                    case AttackTaken evnt:
                        result.Add($"{evnt.dateTime:u} - Player:{evnt.player} - Attack Taken: Position:{evnt.position.ToString()} Result:{evnt.AttackResult.GetDescription()}");
                        break;
                    case MatchFinished evnt:
                        result.Add($"{evnt.dateTime:u} - Player:{evnt.player} - Match Finished: Result:{evnt.result.GetDescription()}");
                        break;
                    default:
                        break;
                }
            }
            return result;
        }
    }
}
