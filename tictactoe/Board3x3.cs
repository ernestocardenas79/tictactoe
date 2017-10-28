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

            var validate = false;

            relations.ToList().ForEach(r=>
            {
                if (r.relation.Value == RelationType.inColumn)
                {
                    validate = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inColumn)
                                .Select(tr => new { tr.row })
                                .Distinct()
                                .Count() == 1 ? true : false;
                }

                if (r.relation.Value == RelationType.inLine)
                {
                    validate = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inLine)
                                .Select(tr => new { tr.column })
                                .Distinct()
                                .Count() == 1 ? true : false;
                }

                if (r.relation.Value == RelationType.inDiagonal)
                {
                    var relDiagonal = tokenRelatedInfo
                        .Where(tr => tr.relation == RelationType.inDiagonal)
                        .ToArray();

                    if (relDiagonal[0].row + 1 == relDiagonal[1].row &&
                        relDiagonal[0].column + 1 == relDiagonal[1].column)
                    {
                        validate = true;
                    }
                    else
                    {
                        validate = false;
                    }
                }

                if (r.relation.Value == RelationType.inInverseDiagonal)
                {
                    var relInverse = tokenRelatedInfo
                                .Where(tr => tr.relation == RelationType.inInverseDiagonal)
                                .ToArray();

                    if (relInverse[0].row + 1 == relInverse[1].row &&
                        relInverse[0].column -1 == relInverse[1].column)
                    {
                        validate = true;
                    }
                    else
                    {
                        validate = false;
                    }
                }
            });

            return validate;
        }
    }
}