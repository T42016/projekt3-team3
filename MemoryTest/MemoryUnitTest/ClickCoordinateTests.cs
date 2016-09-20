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
            _underTest = new MemoryGame(4, 4, new SB());
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
            _underTest.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(_underTest.posX, _underTest.posY).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldNotCloseOpenedCoordinate()
        {
            // Arrange
            _underTest.Update(ConsoleKey.Spacebar);

            // Act
            _underTest.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(true, _underTest.GetCoordinate(_underTest.posX, _underTest.posY).IsOpen);
        }

        [TestMethod]
        public void ClickCoordinateShouldAddOntoDraws()
        {
            // Arrange
            var moves = _underTest.Moves;

            // Act
            _underTest.Update(ConsoleKey.Spacebar);
            _underTest.Update(ConsoleKey.RightArrow);
            _underTest.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(moves + 1, _underTest.Moves);
        }

        [TestMethod]
        public void ClickCoordinateShouldSetCoordinatesToIsFoundIfMatched()
        {
            // Arrange
            var game = new MemoryGame(2, 1, new SB());

            // Act
            game.Update(ConsoleKey.Spacebar);
            game.Update(ConsoleKey.RightArrow);
            game.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(true, game.GetCoordinate(0, 0).IsFound);
            Assert.AreEqual(true, game.GetCoordinate(1, 0).IsFound);
        }

        [TestMethod]
        public void ClickCoordinateShouldNotSetCoordinatesToIsFoundIfMissmatched()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            A.CallTo(() => draw.Next(A<int>.Ignored)).ReturnsNextFromSequence(0,0,0,0);
            _underTest = new MemoryGame(2,2,draw);
            // Act

            _underTest.Update(ConsoleKey.Spacebar);
            _underTest.Update(ConsoleKey.RightArrow);
            _underTest.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(false, _underTest.GetCoordinate(0, 0).IsFound);
            Assert.AreEqual(false, _underTest.GetCoordinate(0, 1).IsFound);
        }

        [TestMethod]
        public void ClickCoordinateShouldBeAbleToWin()
        {
            // Arrange
            var game = new MemoryGame(2,1, new SB());

            // Act
            game.Update(ConsoleKey.Spacebar);
            game.Update(ConsoleKey.RightArrow);
            game.Update(ConsoleKey.Spacebar);

            // Assert
            Assert.AreEqual(MemoryGame.Gamestate.Won, game.state);
        }
    }
}
