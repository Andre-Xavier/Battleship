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
    public class ConstructorGameMatchControllerTests
    {
        #region Null Players Names

        [TestMethod()]
        public void Null_Players_Names()
        {
            var player1 = (string)null;
            var player2 = (string)null;
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void Null_Player1_Name()
        {
            var player1 = (string)null;
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void Null_Player2_Name()
        {
            var player1 = "Player 1";
            var player2 = (string)null;
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Players names

        #region Empty Players Names

        [TestMethod()]
        public void Empty_Players_Names()
        {
            var player1 = string.Empty;
            var player2 = string.Empty;
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void Empty_Player1_Name()
        {
            var player1 = string.Empty;
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void Empty_Player2_Name()
        {
            var player1 = "Player 1";
            var player2 = string.Empty;
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Null Players Names

        #region White Space Players Names

        [TestMethod()]
        public void WhiteSpace_Players_Names()
        {
            var player1 = " ";
            var player2 = "  ";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void WhiteSpace_Player1_Name()
        {
            var player1 = "  ";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }

        [TestMethod()]
        public void WhiteSpace_Player2_Name()
        {
            var player1 = "Player 1";
            var player2 = " ";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion White Space Players Names

        #region Same Players Names

        [TestMethod()]
        public void Same_Players_Names()
        {
            var player1 = "Player 1";
            var player2 = "player 1";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsTrue(failed);
        }
        #endregion Same Players Names

        #region Valid Players Names

        [TestMethod()]
        public void Valid_Players_Names()
        {
            var player1 = "Player 1";
            var player2 = "Player 2";
            var boardSize = new SizeModel(10);

            var failed = false;
            try
            {
                var controller = new GameMatchController(player1, player2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                failed = true;
            }
            Assert.IsFalse(failed);
        }
        #endregion Valid Players Names
    }
}