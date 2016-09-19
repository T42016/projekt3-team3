using System;
using FakeItEasy;
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
            var fakeGame = A.Fake<MemoryGame>();
        }

        [TestMethod]
        public void DrawBoardShouldDoThings()
        {
            // Arrange via Setup

            // Act

            // Assert
            Assert.AreEqual(true, false);
        }
    }
}
