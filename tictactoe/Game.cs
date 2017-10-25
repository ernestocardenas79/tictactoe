using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TictactoeTests")]
namespace Tictactoe
{
    internal class Game
    {
        Player[] players;
        Board board;
        Shift shift;
        internal Game() {
            players = new Player[2];
            players[0] = new Player(enums.Symbol.X);
            players[1] = new Player(enums.Symbol.O);

            shift= new Shift(players);

            board = new Board3x3();

        }

        internal void play() {
            board.print();

            do
            {
                //determinar siguiente jugador
                //elejir coordenada
                //validar si es posible escojer esa coordenada
                shift.nextPlayer().chooseMove(board);
                board.print();

                //validar si hay 3 en raya
                //validar que el tablero no este lleno
            } while (board.thereIsTTT(shift.currentPlayer.symbol)|| board.areYouFull());

            if (board.areYouFull())
            {
                Console.WriteLine("Parece que hubo un empate!!!");
            }
            else {
                Console.WriteLine("Felicidades al Jugador {0} por haber ganado la partida", shift.currentPlayer.number);
            }

            //opcion para comenzar de nuevo
            if (restartGame())
            {
                play();
            }
            else {
                Console.Write("\nJuego Terminado \nGracias por haber Jugado al Gato");
            };
        }

        private bool restartGame() {
            Console.WriteLine("Desean Comenzar Otra Partida? Y/N");
            if (Console.ReadKey().Key == ConsoleKey.Y) {
                board.clearBoard();

                return true;
            }
            return false;
        }
    }
}