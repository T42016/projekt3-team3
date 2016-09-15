using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryUnitTest
{
    [TestClass]
    public class GetCoordinateTests
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(3, 3);
        }

        [TestMethod]
        public void GetCoordinateShouldReturnPositionInfoForCoordinate()
        {
            // Arrange via Setup

            // Act
            var coord = _underTest.GetCoordinate(1, 1);

            // Assert
            Assert.IsInstanceOfType(coord, typeof(PositionInfo));
        }

        [TestMethod]
        public void GetCoordinateShouldReturnPositionInfoWithCorrectX()
        {
            // Arrange via Setup

            // Act
            var coord = _underTest.GetCoordinate(2, 1);

            // Assert
            Assert.AreEqual(coord.X,2);
        }

        [TestMethod]
        public void GetCoordinateShouldReturnPositionInfoWithCorrectY()
        {
            // Arrange via Setup

            // Act
            var coord = _underTest.GetCoordinate(1, 2);

            // Assert
            Assert.AreEqual(coord.Y, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCoordinateShouldThrowExeptionForNegativeX()
        {
            // Arrange via Setup

            // Act
            _underTest.GetCoordinate(-1, 0);

            //Assert via Exception & method attribute
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCoordinateShouldThrowExeptionForNegativeY()
        {
            // Arrange via Setup

            // Act
            _underTest.GetCoordinate(0, -1);

            //Assert via Exception & method attribute
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCoordinateShouldThrowExeptionForTooBigX()
        {
            // Arrange via Setup

            // Act
            _underTest.GetCoordinate(_underTest.SizeX, 0);

            //Assert via Exception & method attribute
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetCoordinateShouldThrowExeptionForTooBigY()
        {
            // Arrange via Setup

            // Act
            _underTest.GetCoordinate(0, _underTest.SizeY);

            //Assert via Exception & method attribute
        }
    }
}
