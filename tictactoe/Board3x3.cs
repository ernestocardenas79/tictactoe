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
            var relations = tokenRelatedInfo.Where(tr => tr.hasRelation)
                        .GroupBy(tr => new {  relation = tr.relation} )
                        .Select(tr => new { relation = tr.Key.relation, count = tr.Count()})
                        .Where(tr=> tr.count == relationToWin);

            var validate = 0;

            relations.ToList().ForEach(r=>{
                if (r.relation.Value == RelationType.inColumn) {
                    validate = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inColumn)
                                .Select(tr=> new { tr.column } )
                                .Distinct()
                                .Count();
                }

                if (r.relation.Value == RelationType.inLine)
                {
                    validate = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inLine)
                                .Select(tr => new { tr.row })
                                .Distinct()
                                .Count();
                }

                if (r.relation.Value == RelationType.inDiagonal)
                {
                    validate = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inDiagonal)
                                .Select(tr => new { column= tr.column, row = tr.row })
                                .Count();
                }
            });

            //var total= eval.Where(e => e.count == relationToWin).Count();

            return validate == 0? false:true;
        }
    }
}