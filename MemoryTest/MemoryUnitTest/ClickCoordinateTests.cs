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
            _underTest.ClickCoordinate();

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(_underTest.posX, _underTest.posY).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldNotCloseOpenedCoordinate()
        {
            // Arrange
            _underTest.ClickCoordinate();

            // Act
            _underTest.ClickCoordinate();

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(_underTest.posX, _underTest.posY).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldAddOntoDraws()
        {
            // Arrange
            var moves = _underTest.Moves;

            // Act
            _underTest.ClickCoordinate();

            // Assert
            Assert.AreEqual(moves + 1, _underTest.Moves + 1);
        }

        [TestMethod]
        public void ClickCoordinateShouldSetCoordinatesToIsFoundIfMatched()
        {
            // Arrange
            var game = new MemoryGame(2, 1);
            
            // Act
            game.ClickCoordinate();
            game.Update(ConsoleKey.RightArrow);
            
            game.ClickCoordinate();

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

        [TestMethod]
        public void ClickCoordinateShouldBeAbleToWin()
        {
            // Arrange
            var game = new MemoryGame(2,1);

            // Act
            game.ClickCoordinate();
            game.Update(ConsoleKey.RightArrow);

            game.ClickCoordinate();

            // Assert
            Assert.AreEqual(MemoryGame.Gamestate.Won, game.state);
        }
    }
}
