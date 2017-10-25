using System;

namespace Tictactoe
{
    internal class Shift
    {
        int _currrenPlayer;
        Player[] players;

        internal Player currentPlayer {
            get {
                return this.players[_currrenPlayer];
            }
        }

        internal Shift(Player[] players)
        {
            this.players = players;
            this._currrenPlayer = 0;
        }

        internal Player nextPlayer()
        {
            this._currrenPlayer=(this._currrenPlayer+1) % 2;

            return players[this._currrenPlayer];
        }
    }
}