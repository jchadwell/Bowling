using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingTest
{
    [TestClass]
    public class BowlingTest
    {
        private Game g;

        private void rollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                g.roll(pins);
            }
        }

        private void rollSpare()
        {
            g.roll(5);
            g.roll(5);
        }

        private void rollStrike()
        {
            g.roll(10);
        }

        [TestInitialize]
        public void setUp()
        {
            g = new Game();
        }

        [TestMethod]
        public void gutterGame()
        {
            rollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void allOnes()
        {
            rollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void oneSpare()
        {
            rollSpare();
            g.roll(3);
            rollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void oneStrike()
        {
            rollStrike();
            g.roll(3);
            g.roll(4);
            rollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void perfectGame()
        {
            rollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }
    }
}
