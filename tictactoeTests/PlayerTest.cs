using System;
using Xunit;

namespace Tictactoe.Tests
{
    public class PlayerTest
    {
        [Fact]
        internal void playerCreation() {
            Player player = new Player(enums.Symbol.O);
            Assert.Equal(1, player.number);
        }
    }
}