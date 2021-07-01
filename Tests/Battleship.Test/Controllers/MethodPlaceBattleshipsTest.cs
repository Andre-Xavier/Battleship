using Battleship.API.Controllers;
using Battleship.Core.Interfaces;
using Battleship.Core.Models;
using Battleship.Core.Models.Battleships;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.API.Controllers.Tests
{
    [TestClass()]
    public class MethodPlaceBattleshipsTest
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

            var player1Ships = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(0, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 3);
            player1Ships.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(null, player1Ships);
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

            var player1Ships = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(0, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 3);
            player1Ships.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(string.Empty, player1Ships);
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

            var player1Ships = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(0, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 3);
            player1Ships.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships("  ", player1Ships);
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

            var player1Ships = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(0, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 3);
            player1Ships.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player3, player1Ships);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Other Player Than Players 1 And Player 2

        #region Null Battleship List

        [TestMethod()]
        public void Null_Battleship_List()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, null);
                controller.PlaceBattleships(player2, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Battleship List

        #region Empty Battleship List

        [TestMethod()]
        public void Empty_Battleship_List()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var player1Ships = new List<ShipModel>();

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, player1Ships);
                controller.PlaceBattleships(player2, player1Ships);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Empty Battleship List

        #region Not Aligned Battleship Coordinates

        [TestMethod()]
        public void Not_Aligned_Battleship_Coordinates()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(1, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 3);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Not Aligned Battleship Coordinates

        #region Battleship Coordinates Out Of Board

        [TestMethod()]
        public void Battleship_Coordinates_Out_Of_Board()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 8);
            ship.Coordinates[1] = new PositionModel(0, 9);
            ship.Coordinates[2] = new PositionModel(0, 10);
            ship.Coordinates[3] = new PositionModel(0, 11);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Coordinates Out Of Board

        #region Battleship Coordinates Overlap

        [TestMethod()]
        public void Battleship_Coordinates_Overlap()
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
            ship2.Coordinates[0] = new PositionModel(0, 7);
            ship2.Coordinates[1] = new PositionModel(1, 7);
            playerShips.Add(ship2);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Coordinates Overlap

        #region Battleship Size Zero

        [TestMethod()]
        public void Battleship_Size_Zero()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new CustomShipModel(0, "Custom Ship");
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Size Zero

        #region Battleship Name Null

        [TestMethod()]
        public void Battleship_Name_Null()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new CustomShipModel(4, null);
            ship.Coordinates[0] = new PositionModel(0, 6);
            ship.Coordinates[1] = new PositionModel(0, 7);
            ship.Coordinates[2] = new PositionModel(0, 8);
            ship.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Name Null

        #region Battleship Name Empty

        [TestMethod()]
        public void Battleship_Name_Empty()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new CustomShipModel(4, string.Empty);
            ship.Coordinates[0] = new PositionModel(0, 6);
            ship.Coordinates[1] = new PositionModel(0, 7);
            ship.Coordinates[2] = new PositionModel(0, 8);
            ship.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Name Empty

        #region Battleship Name White Space

        [TestMethod()]
        public void Battleship_Name_White_Space()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new CustomShipModel(4, string.Empty);
            ship.Coordinates[0] = new PositionModel(0, 6);
            ship.Coordinates[1] = new PositionModel(0, 7);
            ship.Coordinates[2] = new PositionModel(0, 8);
            ship.Coordinates[3] = new PositionModel(0, 9);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Name White Space

        #region Battleship Coordinates Position Null

        [TestMethod()]
        public void Battleship_Coordinates_Position_Null()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 8);
            //ship.Coordinates[1] = new PositionModel(0, 9);
            ship.Coordinates[2] = new PositionModel(0, 10);
            ship.Coordinates[3] = new PositionModel(0, 11);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Coordinates Position Null

        #region Battleship Coordinates Same Position

        [TestMethod()]
        public void Battleship_Coordinates_Same_Position()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);
            controller.CreateGameBoard(player1, boardSize);
            controller.CreateGameBoard(player2, boardSize);

            var playerShips = new List<ShipModel>();

            var ship = new BattleshipShipModel();
            ship.Coordinates[0] = new PositionModel(0, 0);
            ship.Coordinates[1] = new PositionModel(0, 1);
            ship.Coordinates[2] = new PositionModel(0, 2);
            ship.Coordinates[3] = new PositionModel(0, 2);
            playerShips.Add(ship);

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Battleship Coordinates Same Position

        #region Valid Players Names And Battleships

        [TestMethod()]
        public void Valid_Players_Names_And_Battleships()
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

            var failed = false;
            try
            {
                controller.PlaceBattleships(player1, playerShips);
                controller.PlaceBattleships(player2, playerShips);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsFalse(failed);
        }
        #endregion Valid Players Names And Sizes
    }
}
