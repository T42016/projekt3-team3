using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic;

namespace MemoryUnitTest
{
    [TestClass]
    public class ConstructorTests
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(4, 4);
        }

        [TestMethod]
        public void ConstructorShouldSetSizeX()
        {
            // Arrange via Setup
            int x = 4;
            
            // Act

            // Assert
            Assert.AreEqual(x, _underTest.SizeX);
        }

        [TestMethod]
        public void ConstructorShouldSetSizeY()
        {
            // Arrange via Setup
            int y = 4;

            // Act

            // Assert
            Assert.AreEqual(y, _underTest.SizeY);
        }

        [TestMethod]
        public void ConstructorShouldSetGameStateToRunning()
        {
            // Arrange via setup

            // Act

            // Assert
            Assert.AreEqual(MemoryGame.Gamestate.Running, _underTest.state);
        }
    }
}
