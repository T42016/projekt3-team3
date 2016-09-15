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
        public void GetCoordinateShouldReturnPositionInfoForCorrectCoordinate()
        {
            // Arrange via Setup

            // Act
            var coord = _underTest.GetCoordinate(1, 1);

            // Assert
            Assert.IsInstanceOfType(coord, typeof(PositionInfo));
        }
    }
}
