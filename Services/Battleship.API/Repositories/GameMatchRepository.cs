using Battleship.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.API.Repositories
{
    public class GameMatchRepository
    {
        #region Properties
        private readonly Dictionary<string, IList<IEvent>> _inMemoryStream = new();
        #endregion Properties

        #region Methods
        public GameMatchModel Get(string player)
        {
            var playerBoard = new GameMatchModel(player);

            if (_inMemoryStream.ContainsKey(player.ToUpperInvariant()))
            {
                for (int i = 0; i < _inMemoryStream[player.ToUpperInvariant()].Count; i++)
                {
                    playerBoard.AddEvent(_inMemoryStream[player.ToUpperInvariant()][i]);
                }
            }

            return playerBoard;
        }

        public void Save(GameMatchModel playerBoard)
        {
            _inMemoryStream[playerBoard.Player.ToUpperInvariant()] = playerBoard.GetEvents();
        }
        #endregion Methods
    }
}
