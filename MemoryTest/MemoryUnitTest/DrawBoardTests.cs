using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemoryUnitTest
{
    [TestClass]
    public class DrawBoardTests
    {
        [TestInitialize]
        public void Setup()
        {
            MemoryGame _underTest = new MemoryGame(2,2);
        }

        [TestMethod]
        public void DrawBoardShouldDoSomething()
        {
            // Arrange via Setup

            // Act

            // Assert

        }
    }
}
