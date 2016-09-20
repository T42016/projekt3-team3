using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic;

namespace MemoryUnitTest
{
    [TestClass]
    public class ResetBoardTests
    {
        [TestMethod]
        public void ResetBoardShouldSetGameStateToRunning()
        {
            //Arrange
            var game = new MemoryGame(2,1, new SB());

            game.ClickCoordinate();
            game.Update(ConsoleKey.RightArrow);

            game.ClickCoordinate();

            var state = game.state;

            //Act
            game.ResetBoard();

            //Assert
            Assert.AreNotEqual(state, game.state);
        }
    }
}
