using System;
using System.Collections.Generic;
using System.Text;

namespace Tictactoe
{
    internal class Game
    {
        private Player[] players;
        private Board board;

        internal Game() {
            players = new Player[2];
            players[0] = new Player(enums.Symbol.X);
            players[1] = new Player(enums.Symbol.O);

            board = new Board3x3();

            board.print();
        }
    }
}