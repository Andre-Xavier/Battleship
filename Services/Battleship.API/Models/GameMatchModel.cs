using Battleship.Core.Enumerators;
using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.API.Models
{
    public class GameMatchModel
    {
        #region Properties
        public string Player { get; }

        private readonly IList<IEvent> _events = new List<IEvent>();
        private readonly CurrentStateModel _currentState = new CurrentStateModel();

        #endregion Properties

        #region Constructors
        public GameMatchModel(string player)
        {
            this.Player = player;
        }
        #endregion Constructors

        #region Methods
        public void CreateBoard(SizeModel size)
        {
            if (size == null || size.Columns == 0 || size.Rows == 0)
            {
                throw new Exception("Board size is not valid!");
            }
            AddEvent(new BoardCreated(this.Player, size, DateTime.UtcNow));
        }

        public void PlaceBattleship(ShipModel ship)
        {
            if (ship == null)
            {
                throw new Exception("Battleship is not valid!");
            }
            else if (string.IsNullOrWhiteSpace(ship.Name))
            {
                throw new Exception("Battleship name is not valid!");
            }
            else if (ship.Size == 0)
            {
                throw new Exception("Battleship size is not valid!");
            }
            else if (ship.Coordinates == null || ship.Coordinates.Any(p => p == null) || ship.Coordinates.Length != ship.Size)
            {
                throw new Exception("Battleship coordinates is not valid!");
            }
            else if (ship.Coordinates.Any(p => p.X > _currentState.GameBoard.Columns || p.Y > _currentState.GameBoard.Rows))
            {
                throw new Exception("Battleship must fit entirely on the board!");
            }
            else
            {
                var countDistinctX = ship.Coordinates.GroupBy(p => p.X).Count();
                var countDistinctY = ship.Coordinates.GroupBy(p => p.Y).Count();
                if (!((countDistinctX == 1 && countDistinctY == ship.Size) || (countDistinctX == ship.Size && countDistinctY == 1)))
                {
                    throw new Exception("Battleship must be aligned either vertically or horizontally!");
                }
                else
                {
                    for (int i = 0; i < ship.Coordinates.Length; i++)
                    {
                        var cell = _currentState.GameBoard.CellStatus[ship.Coordinates[i].X, ship.Coordinates[i].Y];
                        if (cell == Core.Enumerators.BoardCellStatusEnum.Occupied)
                        {
                            throw new Exception("Battleship cannot overlap!");
                        }
                    }
                }
            }
            AddEvent(new BattleshipPlaced(this.Player, ship, DateTime.UtcNow));
        }

        public Core.Enumerators.AttackStatusEnum TakeAttack(PositionModel position)
        {
            if (position == null)
            {
                throw new Exception("Position is not valid!");
            }
            else if (position.X > _currentState.GameBoard.Columns || position.Y > _currentState.GameBoard.Rows)
            {
                throw new Exception("Position is out of range!");
            }
            else if (_currentState.GameBoard.AttackTakenStatus[position.X, position.Y] != AttackStatusEnum.None)
            {
                throw new Exception("Position has already been attacked!");
            }
            var result = (_currentState.GameBoard.CellStatus[position.X, position.Y] == BoardCellStatusEnum.Occupied) ? AttackStatusEnum.Hit : AttackStatusEnum.Miss;

            AddEvent(new AttackTaken(this.Player, position, result,  DateTime.UtcNow));
            return _currentState.GameBoard.AttackTakenStatus[position.X, position.Y];
        }

        public void FinishMatch(MatchResultEnum result)
        {
            if (result == MatchResultEnum.None)
            {
                throw new Exception("Result is not valid!");
            }
            AddEvent(new MatchFinished(this.Player, result, DateTime.UtcNow));
        }

        public MatchResultEnum MatchResult()
        {
            return (_currentState.BattleshipsTotalOnHand == 0 ? MatchResultEnum.Lost : _currentState.Result);
        }

        private void Apply(BoardCreated evnt)
        {
            _currentState.GameBoard = new GameBoardModel(evnt.size);
        }

        private void Apply(BattleshipPlaced evnt)
        {
            var placedShip = new PlacedShipModel(evnt.ship);
            for (int i = 0; i < evnt.ship.Coordinates.Length; i++)
            {
                _currentState.GameBoard.CellStatus[evnt.ship.Coordinates[i].X, evnt.ship.Coordinates[i].Y] = Core.Enumerators.BoardCellStatusEnum.Occupied;
                placedShip.SectionStatus[i] = _currentState.GameBoard.AttackTakenStatus[evnt.ship.Coordinates[i].X, evnt.ship.Coordinates[i].Y];
            }
            _currentState.PlacedShips.Add(placedShip);
        }

        private void Apply(AttackTaken evnt)
        {
            if (_currentState.GameBoard.CellStatus[evnt.position.X, evnt.position.Y] == Core.Enumerators.BoardCellStatusEnum.Occupied)
            {                
                var shipHit = _currentState.PlacedShips.FirstOrDefault(p => p.Coordinates.Any(c => c.X == evnt.position.X&& c.Y == evnt.position.Y));
                shipHit.SectionStatus[shipHit.HitsTaken] = AttackStatusEnum.Hit;
                _currentState.GameBoard.AttackTakenStatus[evnt.position.X, evnt.position.Y] = Core.Enumerators.AttackStatusEnum.Hit;
            }
            else
            {
                _currentState.GameBoard.AttackTakenStatus[evnt.position.X, evnt.position.Y] = Core.Enumerators.AttackStatusEnum.Miss;
            }
        }

        private void Apply(MatchFinished evnt)
        {
            _currentState.Result = evnt.result;
        }

        public void AddEvent(IEvent evnt)
        {
            switch (evnt)
            {
                case BoardCreated createBoard:
                    Apply(createBoard);
                    break;
                case BattleshipPlaced placeBattleship:
                    Apply(placeBattleship);
                    break;
                case AttackTaken takeAttack:
                    Apply(takeAttack);
                    break;
                case MatchFinished finishMatch:
                    Apply(finishMatch);
                    break;
                default:
                    throw new Exception("Unsupported Event");
            }
            _events.Add(evnt);
        }

        public IList<IEvent> GetEvents() {
            return _events;
        }
        #endregion Methods
    }
}
