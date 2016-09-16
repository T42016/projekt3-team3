using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryUnitTest
{
    [TestClass]
    public class MovementTests
    {
        private MemoryGame _underTest;
        private MemoryGame _underTest1x1;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(2, 2);
            _underTest1x1 = new MemoryGame(1, 1);
        }

        [TestMethod]
        public void MoveUpShouldMoveUp()
        {
            // Arrange
            _underTest.Update(ConsoleKey.DownArrow);
            var posY = _underTest.posY;

            // Act
            _underTest.Update(ConsoleKey.UpArrow);

            // Assert
            Assert.AreEqual(posY - 1, _underTest.posY);
        }

        [TestMethod]
        public void MoveDownShouldMoveDown()
        {
            // Arrange
            var posY = _underTest.posY;

            // Act
            _underTest.Update(ConsoleKey.DownArrow);

            // Assert
            Assert.AreEqual(posY + 1, _underTest.posY);
        }

        [TestMethod]
        public void MoveLeftShouldMoveLeft()
        {
            // Arrange
            _underTest.Update(ConsoleKey.RightArrow);
            var posX = _underTest.posX;

            // Act
            _underTest.Update(ConsoleKey.LeftArrow);

            // Assert
            Assert.AreEqual(posX - 1, _underTest.posX);
        }

        [TestMethod]
        public void MoveRightShouldMoveRight()
        {
            // Arrange
            var posX = _underTest.posX;

            // Act
            _underTest.Update(ConsoleKey.RightArrow);

            // Assert
            Assert.AreEqual(posX + 1, _underTest.posX);
        }

        [TestMethod]
        public void MoveUpShouldNotCauseNegativePosY()
        {
            // Arrange via Setup

            // Act
            _underTest1x1.Update(ConsoleKey.UpArrow);

            // Assert
            Assert.AreNotEqual(-1, _underTest1x1.posY);
        }

        [TestMethod]
        public void MoveLeftShouldNotCauseNegativePosX()
        {
            // Arrange via Setup

            // Act
            _underTest1x1.Update(ConsoleKey.LeftArrow);

            // Assert
            Assert.AreNotEqual(-1, _underTest1x1.posX);
        }

        [TestMethod]
        public void MoveDownShouldNotCausePosYEqualToSizeY()
        {
            // Arrange via Setup

            // Act
            _underTest1x1.Update(ConsoleKey.DownArrow);

            // Assert
            Assert.AreNotEqual(_underTest1x1.SizeY, _underTest1x1.posY);
        }

        [TestMethod]
        public void MoveRightShouldNotCausePosXEqualToSizeX()
        {
            // Arrange via Setup

            // Act
            _underTest1x1.Update(ConsoleKey.RightArrow);

            // Assert
            Assert.AreNotEqual(_underTest1x1.SizeX, _underTest1x1.posX);
        }
    }
}
