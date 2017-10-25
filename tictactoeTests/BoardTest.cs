using System;
using Tictactoe;
using Tictactoe.enums;
using Xunit;

namespace TictactoeTests
{
    public class BoardTest
    {
        [Fact]
        internal void chooseRightCoordinate()
        {
            Board board = new Board3x3();

            int fila = 0;
            int columna = 1;

            Assert.True(board.isValidToken(fila, columna));

            fila = 4;
            columna = 3;
            Assert.False(board.isValidToken(fila, columna));
        }

        [Fact]
        internal void ConvertKeyToNumber()
        {
            int value = 0;
            Board board = new Board3x3();
            ConsoleKeyInfo cki = new ConsoleKeyInfo('2', ConsoleKey.D2, false, false, false); ;

            Assert.True(board.convertKeyToNumber(cki, out value));
            Assert.Equal(2, value);
        }

        [Fact]
        internal void areYouFullTest() {
            Board board = new Board3x3();

            Assert.False(board.areYouFull());

            Player player = new Player(Symbol.O);

            board.makeMove(player,0,0);
            board.makeMove(player, 0, 1);
            board.makeMove(player, 0, 2);
            board.makeMove(player, 1, 0);
            board.makeMove(player, 1, 1);
            board.makeMove(player, 1, 2);
            board.makeMove(player, 2, 0);
            board.makeMove(player, 2, 1);
            board.makeMove(player, 2, 2);

            Assert.True(board.areYouFull());

        }

        [Fact]
        internal void thereIsTTTTest() {

            Player player = new Player(Symbol.O);

            //Board board = new Board3x3();

            //board.makeMove(player, 0, 0);
            //board.makeMove(player, 0, 1);
            //board.makeMove(player, 0, 2);

            //Assert.True(board.thereIsTTT(player.symbol));

            Board board2 = new Board3x3();

            board2.makeMove(player, 0, 0);
            board2.makeMove(player, 0, 1);
            board2.makeMove(player, 1, 2);

            Assert.False(board2.thereIsTTT(player.symbol));
        }

        [Fact]
        internal void isEnogthToWinTest() {
            Board board = new Board3x3();

            board.isEnogthToWin();
        }
    }
}