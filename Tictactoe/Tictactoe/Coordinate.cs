using Tictactoe.enums;

namespace Tictactoe
{
    internal class Coordinate
    {
        internal Symbol value { get; set; }

        internal Coordinate() {
            cleanCoordinate();
        }

        internal void  cleanCoordinate()
        {
            this.value = Symbol._;
        }
    }
}