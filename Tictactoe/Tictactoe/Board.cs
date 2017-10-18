using System;
using System.Collections.Generic;
using System.Text;

namespace Tictactoe
{
    internal abstract class Board
    {
        int _row;
        int _column;
        Coordinate[,] coordinates;

        internal Board(int row, int column) {
            this._row = row;
            this._column = column;

            coordinates = new Coordinate[this._row, this._column];
            newBoard();
        }

        internal void newBoard() {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    coordinates[i, j] = new Coordinate();
                }
            }
        }

        internal void clearBoard()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    coordinates[i, j].cleanCoordinate();
                }
            }
        }

        internal void print() {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    Console.Write(" {0}", coordinates[i, j].value.ToString());
                }
                Console.WriteLine("");
            }
        }
    }
}