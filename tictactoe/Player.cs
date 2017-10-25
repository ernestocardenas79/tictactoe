using System;
using Tictactoe.enums;

namespace Tictactoe
{
    internal class Player
    {
        private Symbol _symbol;
        internal Symbol symbol {
            get {
                return _symbol;
            }
        }

        internal int number { get; }

        public Player(Symbol symbol)
        {
            this._symbol = symbol;
            this.number = symbol == Symbol.X ? 0 : 1;
        }

        
        internal void chooseMove(Board board)
        {
            int row;
            int column;
            do
            {
                row = 0;
                column = 0;

                Console.Write("\nJugador {0} Elije una posicion del tablero", number);

                row = board.askForNumber("Fila");
                column = board.askForNumber("Columna");
                
            } while (!board.isValidToken(row, column));

            board.makeMove(this, row, column);

        }
    }
}