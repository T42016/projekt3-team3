using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;

namespace MemoryUnitTest
{
    [TestClass]
    public class ClickCoordinateTests
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(3, 3);
        }

        [TestMethod]
        public void ClickCoordinateShouldCallGetCoordinate()
        {
            // Arrange via Setup
            
            // Act
            
            // Assert

        }

        [TestMethod]
        public void ClickCoordinateShouldOpenCoordinate()
        {
            // Arrange via Setup

            // Act
            _underTest.ClickCoordinate(1,1);

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(1,1).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldNotCloseOpenedCoordinate()
        {
            // Arrange
            _underTest.ClickCoordinate(1,1);

            // Act
            _underTest.ClickCoordinate(1,1);

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(1,1).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldAddOntoDraws()
        {
            // Arrange
            var draws = _underTest.Draws;

            // Act
            _underTest.ClickCoordinate(2,2);

            // Assert
            Assert.AreEqual(draws + 1, _underTest.Draws + 1);
        }

        [TestMethod]
        public void ClickCoordinateShouldSetCoordinatesToIsFoundIfMatched()
        {
            // Arrange
            var game = new MemoryGame(2,1);

            // Act
            game.ClickCoordinate(0,0);
            game.ClickCoordinate(1,0);

            // Assert
            Assert.AreEqual(true, game.GetCoordinate(0, 0).IsFound);
            Assert.AreEqual(true, game.GetCoordinate(1, 0).IsFound);
        }

        [TestMethod]
        public void ClickCoordinateShouldNotSetCoordinatesToIsFoundIfMissmatched()
        {
            // Arrange
            
            // Act
            
            // Assert
            Assert.AreEqual(true, false);
        }
    }
}
