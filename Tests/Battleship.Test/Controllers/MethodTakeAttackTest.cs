using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Core.Models;
using Battleship.Core.Interfaces;
using Battleship.Core.Models.Battleships;
using Battleship.Core.Enumerators;

namespace Battleship.API.Controllers.Tests
{
    [TestClass()]
    public class MethodTakeAttackTest
    {
        #region Null Player Name

        [TestMethod()]
        public void Null_Player_Name()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 0);
                controller.TakeAttack(null, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Player names

        #region Empty Player Name

        [TestMethod()]
        public void Empty_Player_Name()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 0);
                controller.TakeAttack(string.Empty, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Player Name

        #region White Space Player Name

        [TestMethod()]
        public void WhiteSpace_Player_Name()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 0);
                controller.TakeAttack("  ", attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion White Space Player Name

        #region Other Player Than Players 1 And Player 2

        [TestMethod()]
        public void Other_Player_Than_Player1_And_Player2()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var player3 = "Player 3";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 0);
                controller.TakeAttack(player3, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Other Player Than Players 1 And Player 2

        #region Null Position

        [TestMethod()]
        public void Null_Position()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                controller.TakeAttack(player2, null);

                /*Player 2 attacks Player 1*/
                controller.TakeAttack(player1, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null position

        #region Same Position

        [TestMethod()]
        public void Same_Position()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 0);
                controller.TakeAttack(player2, attackPosition);

                /*Player 2 attacks Player 1*/
                controller.TakeAttack(player1, attackPosition);

                /*Player 1 attacks Player 2 Same Position*/
                controller.TakeAttack(player2, attackPosition);

                /*Player 2 attacks Player 1 Same Position*/
                controller.TakeAttack(player1, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Same Position

        #region Position Out Of The Board

        [TestMethod()]
        public void Position_Out_Of_The_Board()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;
            try
            {
                /*Player 1 attacks Player 2*/
                var attackPosition = new PositionModel(0, 11);
                controller.TakeAttack(player2, attackPosition);

                /*Player 2 attacks Player 1*/
                attackPosition = new PositionModel(11, 0);
                controller.TakeAttack(player1, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Position Out Of The Board

        #region Valid Players Names And Positions

        [TestMethod()]
        public void Valid_Players_Names_And_Positions()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship1 = new BattleshipShipModel();
            ship1.Coordinates[0] = new PositionModel(0, 6);
            ship1.Coordinates[1] = new PositionModel(0, 7);
            ship1.Coordinates[2] = new PositionModel(0, 8);
            ship1.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship1);

            var ship2 = new PatrolBoatShipModel();
            ship2.Coordinates[0] = new PositionModel(1, 7);
            ship2.Coordinates[1] = new PositionModel(2, 7);
            playerShips.Add(ship2);

            controller.PlaceBattleships(player1, playerShips);
            controller.PlaceBattleships(player2, playerShips);

            var failed = false;

            var resultAttackTakenHit = AttackStatusEnum.None;
            var resultAttackTakenMiss = AttackStatusEnum.None;
            try
            {
                /*Player 1 attacks Player 2*/
               var attackPosition = new PositionModel(0,6);
                resultAttackTakenHit = controller.TakeAttack(player2, attackPosition);

                /*Player 2 attacks Player 1*/
                attackPosition = new PositionModel(0, 0);
                resultAttackTakenMiss = controller.TakeAttack(player1, attackPosition);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(!failed && resultAttackTakenHit == AttackStatusEnum.Hit && resultAttackTakenMiss == AttackStatusEnum.Miss);
        }
        #endregion Valid Players Names And Positions
    }
}