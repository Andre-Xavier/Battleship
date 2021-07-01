using Battleship.API.Controllers;
using Battleship.API.Repositories;
using Battleship.Core.Enumerators;
using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using Battleship.Core.Models.Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Battleship.Testes
{
    [TestClass]
    public class SimulateGameMatchTest
    {
        [TestMethod]
        public void MatchTest()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);

            #region Player 1 - Create Game Board
            controller.CreateGameBoard(player1, boardSize);
            #endregion Player 1 - Create Game Board

            #region Player 2 - Create Game Board
            controller.CreateGameBoard(player2, boardSize);
            #endregion Player 2 - Create Game Board

            #region Player 1 - Place Ships
            var player1Ships = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 0);
            ship1.Coordinates[1] = new PositionModel(0, 1);
            ship1.Coordinates[2] = new PositionModel(0, 2);
            ship1.Coordinates[3] = new PositionModel(0, 3);
            player1Ships.Add(ship1);

            var ship2 = new CarrierShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 0);
            ship2.Coordinates[1] = new PositionModel(1, 1);
            ship2.Coordinates[2] = new PositionModel(1, 2);
            ship2.Coordinates[3] = new PositionModel(1, 3);
            ship2.Coordinates[4] = new PositionModel(1, 4);
            player1Ships.Add(ship2);

            var ship3 = new DestroyerShipModel();
            ship3.Coordinates[0] = new PositionModel(2, 0);
            ship3.Coordinates[1] = new PositionModel(2, 1);
            ship3.Coordinates[2] = new PositionModel(2, 2);
            player1Ships.Add(ship3);

            var ship4 = new SubmarineShipModel();
            ship4.Coordinates[0] = new PositionModel(3, 0);
            ship4.Coordinates[1] = new PositionModel(3, 1);
            ship4.Coordinates[2] = new PositionModel(3, 2);
            player1Ships.Add(ship4);

            controller.PlaceBattleships(player1, player1Ships);
            #endregion Player 1 - Place Ships

            #region Player 2 - Place Ships
            var player2Ships = new List<ShipModel>();

            ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 0);
            ship1.Coordinates[1] = new PositionModel(0, 1);
            ship1.Coordinates[2] = new PositionModel(0, 2);
            ship1.Coordinates[3] = new PositionModel(0, 3);
            player2Ships.Add(ship1);

            ship2 = new CarrierShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 0);
            ship2.Coordinates[1] = new PositionModel(1, 1);
            ship2.Coordinates[2] = new PositionModel(1, 2);
            ship2.Coordinates[3] = new PositionModel(1, 3);
            ship2.Coordinates[4] = new PositionModel(1, 4);
            player2Ships.Add(ship2);

            ship3 = new DestroyerShipModel();
            ship3.Coordinates[0] = new PositionModel(2, 0);
            ship3.Coordinates[1] = new PositionModel(2, 1);
            ship3.Coordinates[2] = new PositionModel(2, 2);
            player2Ships.Add(ship3);

            ship4 = new SubmarineShipModel();
            ship4.Coordinates[0] = new PositionModel(3, 0);
            ship4.Coordinates[1] = new PositionModel(3, 1);
            ship4.Coordinates[2] = new PositionModel(3, 2);
            player2Ships.Add(ship4);

            controller.PlaceBattleships(player2, player2Ships);
            #endregion Player 1 - Place Ships

            #region Player 1/2 - Take Attacks
            var player1HasLost = controller.HasLostMatch(player1);
            var player2HasLost = controller.HasLostMatch(player2);

            var player1AttackTakenPositions = new Dictionary<string, PositionModel>();
            var player2AttackTakenPositions = new Dictionary<string, PositionModel>();

            var rnd = new Random();
            var attackPosition = (PositionModel)null;


            while (!player1HasLost && !player2HasLost)
            {
                /*Player 1 attacks Player 2*/
                attackPosition = new PositionModel((byte)rnd.Next(0, 10), (byte)rnd.Next(0, 10));
                while (player2AttackTakenPositions.ContainsKey(attackPosition.ToString()))
                {
                    attackPosition = new PositionModel((byte)rnd.Next(0, 10), (byte)rnd.Next(0, 10));
                }
                player2AttackTakenPositions.Add(attackPosition.ToString(), attackPosition);
                controller.TakeAttack(player2, attackPosition);
                player2HasLost = controller.HasLostMatch(player2);

                if (!player2HasLost)
                {
                    /*Player 2 attacks Player 1*/
                    attackPosition = new PositionModel((byte)rnd.Next(0, 10), (byte)rnd.Next(0, 10));
                    while (player1AttackTakenPositions.ContainsKey(attackPosition.ToString()))
                    {
                        attackPosition = new PositionModel((byte)rnd.Next(0, 10), (byte)rnd.Next(0, 10));
                    }
                    player1AttackTakenPositions.Add(attackPosition.ToString(), attackPosition);
                    controller.TakeAttack(player1, attackPosition);
                    player1HasLost = controller.HasLostMatch(player1);
                }
            }
            #endregion Player 1/2 - Take Attacks

            #region Match Finished
            var logs =  controller.GetEventLogs();
            for (int i = 0; i < logs.Count; i++)
            {
                Console.WriteLine(logs[i]);
            }
            #endregion Match Finished
        }
    }
}
