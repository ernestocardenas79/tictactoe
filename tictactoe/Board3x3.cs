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

        internal override bool isEnogthToWin(List<Coordinate> sameSymbolcoordinateList)
        {
            var relatedCoordinateList= Coordinate.relatedCoordinate(sameSymbolcoordinateList);

            var relations = relatedCoordinateList
                            .GroupBy(tr => tr.relation)
                            .Select(tr => new { relation = tr.Key, count = tr.Count() })
                            .Where(tr => tr.count == relationToWin);

            var winner = false;

            foreach (var relation in relations)
            {
                if(relation.relation.Value == RelationType.inColumn)
                {
                    winner = Coordinate.hasSameColumn(relatedCoordinateList
                                            .Where(tr => tr.relation == RelationType.inColumn));
                }

                if (relation.relation.Value == RelationType.inLine)
                {
                    winner = Coordinate.hasSameLine(relatedCoordinateList
                                    .Where(tr => tr.relation == RelationType.inLine));
                }

                if (relation.relation.Value == RelationType.inDiagonal)
                {
                    winner = Coordinate.areInDiagonal(relatedCoordinateList
                                            .Where(tr => tr.relation == RelationType.inDiagonal));
                }

                if (relation.relation.Value == RelationType.inInverseDiagonal)
                {
                    winner= Coordinate.areInverseDiagonal(relatedCoordinateList
                                        .Where(tr => tr.relation == RelationType.inInverseDiagonal));
                }

                if (winner)
                {
                    return true;
                }
            }

            return false;
        }
    }
}