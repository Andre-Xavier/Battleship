using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Core.Models;

namespace Battleship.API.Controllers.Tests
{
    [TestClass()]
    public class MethodCreateGameBoardTest
    {
        #region Null Player Name

        [TestMethod()]
        public void Null_Player_Name()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);

            var failed = false;
            try
            {
                controller.CreateGameBoard(null, boardSize);
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

            var failed = false;
            try
            {
                controller.CreateGameBoard(string.Empty, boardSize);
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

            var failed = false;
            try
            {
                controller.CreateGameBoard("  ", boardSize);
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

            var failed = false;
            try
            {
                controller.CreateGameBoard(player3, boardSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Other Player Than Players 1 And Player 2

        #region Null Board Size

        [TestMethod()]
        public void Null_Board_Size()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = (SizeModel)null;

            var controller = new GameMatchController(player1, player2);

            var failed = false;
            try
            {
                controller.CreateGameBoard(player1, boardSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Board Size

        #region Zero Board Size

        [TestMethod()]
        public void Zero_Board_Size()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(0);

            var controller = new GameMatchController(player1, player2);

            var failed = false;
            try
            {
                controller.CreateGameBoard(player1, boardSize);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Zero Board Size

        #region Valid Players Names And Size

        [TestMethod()]
        public void Valid_Players_Names_And_Sizes()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var controller = new GameMatchController(player1, player2);

            var failed = false;
            try
            {
                controller.CreateGameBoard(player1, boardSize);
                controller.CreateGameBoard(player2, boardSize);
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