﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Board15.Tests
{
    [TestClass()]
    public class GameTests
    {
        [TestMethod()]
        public void StartTest()
        {
            var game = new Game(4);
            game.Start();
            Assert.AreEqual(1, game.GetDigitAt(0, 0));
            Assert.AreEqual(2, game.GetDigitAt(1, 0));
            Assert.AreEqual(5, game.GetDigitAt(0, 1));
            Assert.AreEqual(15, game.GetDigitAt(2, 3));
            Assert.AreEqual(0, game.GetDigitAt(03, 3));
        }

        [TestMethod()]
        public void PressAtTest()
        {
            var game = new Game(4);
            game.Start();
            game.PressAt(2, 3);
            Assert.AreEqual(0, game.GetDigitAt(2, 3));
            Assert.AreEqual(15, game.GetDigitAt(3, 3));
            game.PressAt(2, 2);
            Assert.AreEqual(0, game.GetDigitAt(2, 2));
            Assert.AreEqual(11, game.GetDigitAt(2, 3));
        }

        [TestMethod()]
        public void GetDigitAtTest()
        {
            var game = new Game(4);
            game.Start();
            Assert.AreEqual(0, game.GetDigitAt(-5, -3));
            Assert.AreEqual(0, game.GetDigitAt(5, 6));
        }

        [TestMethod()]
        public void SolvedTest()
        {
            var game = new Game(4);
            game.Start();
            Assert.IsTrue(game.Solved());
            game.PressAt(2, 3);
            Assert.IsFalse(game.Solved());
            game.PressAt(3, 3);
            Assert.IsTrue(game.Solved());
        }
    }
}