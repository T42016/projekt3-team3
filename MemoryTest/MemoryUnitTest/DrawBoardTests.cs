using System;
using MemoryLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakeItEasy;

namespace MemoryUnitTest
{
    [TestClass]
    public class DrawBoardTests
    {
        private MemoryGame _underTest;

        [TestInitialize]
        public void Setup()
        {
            _underTest = new MemoryGame(2,2,new SB());
        }

        [TestMethod]
        public void DrawBoardShouldDrawUnOpenedPositions()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            int x = 2;
            int y = 2;
            _underTest = new MemoryGame(x, y, draw);

            // Act

            // Assert
            A.CallTo(() => draw.Write(". ")).MustHaveHappened();
        }
        [TestMethod]
        public void DrawBoardShouldDrawOpenedPositions()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            int x = 2;
            int y = 1;
            _underTest = new MemoryGame(x, y, draw);

            // Act
            _underTest.Update(ConsoleKey.Spacebar);
            
            // Assert
            A.CallTo(() => draw.Write("* ")).MustHaveHappened();
        }
        [TestMethod]
        public void DrawBoardShouldDrawRightNumberOfUnOpenedPositions()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            int x = 2;
            int y = 2;
            _underTest = new MemoryGame(x, y, draw);

            // Act

            // Assert
            A.CallTo(() => draw.Write(". ")).MustHaveHappened(Repeated.Exactly.Times(x * y));
        }
        [TestMethod]
        public void DrawBoardShouldDrawNnrOpenedPositions()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            int x = 2;
            int y = 1;
            _underTest = new MemoryGame(x, y, draw);

            // Act
            _underTest.Update(ConsoleKey.Spacebar);

            // Assert

            A.CallTo(() => draw.Write("* ")).MustHaveHappened(Repeated.Exactly.Once);
        }
        [TestMethod]
        public void DrawBoardShouldDrawCorrectSize()
        {
            // Arrange
            var draw = A.Fake<ISB>();
            int x = 4;
            int y = 4;
            _underTest = new MemoryGame(x,y,draw);

            // Act

            // Assert
            A.CallTo(() => draw.Write(A<string>.Ignored)).MustHaveHappened(Repeated.Exactly.Times(x*y));
        }
    }
}