using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryUnitTest
{
    [TestClass]
    public class DrawBoardTests
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(2,2);
        }

        [TestMethod]
        public void DrawBoardShouldDrawUnOpenedPositions()
        {
            // Arrange
            
            // Act

            // Assert
            Assert.AreEqual(true, false);
        }
    }
}