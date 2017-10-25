using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.enums;
using Tictactoe.structs;

namespace Tictactoe
{
    internal class Board3x3 : Board
    {
        const int row = 3;
        const int column = 3;

        internal Board3x3():base(row,column) {

        }

        protected override bool isEnogthToWin(List<RelatedInfo> tokenRelatedInfo)
        {
            return true;
        }
    }
}