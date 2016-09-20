using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MemoryLogic;

namespace MemoryUnitTest
{
    [TestClass]
    public class GameStateTests
    {
        [TestMethod]
        public void AllFoundShouldSetGameStateToWon()
        {
            // Arrange
            var game = new MemoryGame(2, 1, new SB());

            // Act
            game.ClickCoordinate();
            game.Update(ConsoleKey.RightArrow);

            game.ClickCoordinate();

            // Assert
            Assert.AreEqual(MemoryGame.Gamestate.Won, game.state);
        }
    }
}
