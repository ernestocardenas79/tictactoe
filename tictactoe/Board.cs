using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.enums;
using Tictactoe.structs;

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

        internal bool isValidToken(int fila,int columna)
        {
            try
            {
                return coordinates[fila, columna].value == enums.Symbol._ ? true : false;
            }
            catch (IndexOutOfRangeException e) {
                return false;
            }
        }

        internal void newBoard() {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    coordinates[i, j] = new Coordinate(i,j);
                }
            }
        }

        internal void makeMove(Player player, int row, int column)
        {
            coordinates[row, column].value = player.symbol;
        }

        internal bool areYouFull()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    if (coordinates[i, j].value == Symbol._)
                    {
                        return false;
                    };
                };
            };

            return true;
        }

        internal bool thereIsTTT(Symbol symbol)
        {
            var hasCoordinateToCompare = false;
            Coordinate coordinateToCompare = new Coordinate();
            //RelatedInfo relatedInfo = new RelatedInfo() { hasRelation = false };
            List<RelatedInfo> tokenRelatedInfo = new List<RelatedInfo>();

            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _column; j++)
                {
                    if (coordinates[i, j].value == symbol)
                    {
                        if (!hasCoordinateToCompare)
                        {
                            coordinateToCompare = coordinates[i, j];
                            hasCoordinateToCompare = true;
                        }
                        else
                        {
                            var coordinateList= coordinates[i, j].getRelations(coordinateToCompare);

                            coordinateList.ForEach(cl =>
                            {
                                tokenRelatedInfo.Add(cl);
                            });

                            coordinateToCompare = coordinates[i, j];
                        }
                    }
                }
            }

            return isEnogthToWin(tokenRelatedInfo) ? true : false;
        }

        internal abstract bool isEnogthToWin(List<RelatedInfo> tokenRelatedInfo);

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
            Console.Clear();
            Console.WriteLine("");

            for (int i = 0; i < _row; i++)
            {
                if (i == 0)
                {
                    Console.Write("   {0}", i);
                }
                else {
                    Console.Write(" {0}", i);
                }
            }

            Console.WriteLine(" ");

            for (int i = 0; i < _row; i++)
            {
                Console.Write(" {0}", i);

                for (int j = 0; j < _column; j++)
                {
                    Console.Write(" {0}", coordinates[i, j].value.ToString());
                }
                Console.WriteLine("");
            }
        }

        internal int askForNumber(string target)
        {
            int value;
            var validNumber = true;
            ConsoleKeyInfo key;
            do
            {
                if (validNumber)
                {
                    Console.Write("\n{0}: ", target);
                }
                else
                {
                    Console.Write("\n{0} (Valida): ", target);
                }
                key = Console.ReadKey();
                validNumber = convertKeyToNumber(key, out value);
            } while (!validNumber);

            return value;
        }

        internal bool convertKeyToNumber(ConsoleKeyInfo key, out int value)
        {
            return int.TryParse(key.KeyChar.ToString(), out value);
        }
    }
}