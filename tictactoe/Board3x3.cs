using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tictactoe.enums;
using Tictactoe.structs;

namespace Tictactoe
{
    internal class Board3x3 : Board
    {
        const int row = 3;
        const int column = 3;
        const int relationToWin = 2;

        internal Board3x3():base(row,column) {

        }

        internal override bool isEnogthToWin(List<RelatedInfo> tokenRelatedInfo)
        {
            var eval = tokenRelatedInfo.Where(tr => tr.hasRelation)
                        .GroupBy(tr => tr.relation)
                        .Select(tr => new { relation = tr.Key, count = tr.Count()});

            return eval.Where(e => e.count == relationToWin).Count()==0? false:true;
        }
    }
}