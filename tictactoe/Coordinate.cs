using System;
using System.Collections.Generic;
using System.Linq;
using Tictactoe.enums;
using Tictactoe.structs;

namespace Tictactoe
{
    internal class Coordinate
    {
        internal Symbol value { get; set; }

        int _xPoint;
        int _yPoint;

        internal Coordinate()
        {
            this._xPoint = 0;
            this._yPoint = 0;

            cleanCoordinate();
        }

        internal Coordinate(int xPoint, int yPoint)
        {
            this._xPoint = xPoint;
            this._yPoint = yPoint;

            cleanCoordinate();
        }

        internal static List<CoordinateInfo> relatedCoordinate(List<Coordinate> coordinateList)
        {
            var coordinates = coordinateList.ToArray();
            var tokenRelatedInfo = new List<RelatedInfo>();

            coordinateList
                .Select((ss, index) => new
                {
                    coordinate = ss,
                    index = index
                })
                .ToList()
                .ForEach(ss =>
                {
                    for (int i = ss.index; i > 0; i--)
                    {
                        tokenRelatedInfo.Add(coordinates[ss.index].getRelation(coordinates[i - 1]));
                    }
                });

            return tokenRelatedInfo
                    .Where(tr => tr.hasRelation)
                    .Select(tr => tr.coordinateInfo)
                    .ToList();
        }

        internal static bool hasSameLine(IEnumerable<CoordinateInfo> coordinate)
        {
            var validate = coordinate
                        .Select(tr => new { tr.coordinate._xPoint })
                        .Distinct()
                        .Count() == 1 ? true : false;

            return validate;
        }

        internal static bool hasSameColumn(IEnumerable<CoordinateInfo> coordinate)
        {
            var validate = coordinate
                        .Select(tr => new { tr.coordinate._yPoint })
                        .Distinct()
                        .Count() == 1 ? true : false;

            return validate;
        }

        RelatedInfo getRelation(Coordinate coordinateToCompare)
        {
            RelatedInfo relationInfo = new RelatedInfo();
            relationInfo.hasRelation = false;
            relationInfo.coordinateInfo = new CoordinateInfo();

            if (coordinateToCompare._xPoint == this._xPoint &&
                (coordinateToCompare._yPoint + 1 == this._yPoint ||
                coordinateToCompare._yPoint - 1 == this._yPoint))
            {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inLine,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (coordinateToCompare._yPoint == this._yPoint &&
                (coordinateToCompare._xPoint + 1 == this._xPoint ||
                coordinateToCompare._xPoint - 1 == this._xPoint))
            {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inColumn,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (this._xPoint - 1 == coordinateToCompare._xPoint &&
                this._yPoint - 1 == coordinateToCompare._yPoint)
            {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inDiagonal,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (this._xPoint - 1 == coordinateToCompare._xPoint &&
                this._yPoint + 1 == coordinateToCompare._yPoint)
            {
                relationInfo.hasRelation = true;

                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inInverseDiagonal,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            return relationInfo;
        }

        internal static bool areInverseDiagonal(IEnumerable<CoordinateInfo> coordinateList)
        {
            var relInverse = coordinateList
                            .ToArray();

            if (relInverse[0].coordinate._xPoint + 1 == relInverse[1].coordinate._xPoint &&
                relInverse[0].coordinate._yPoint - 1 == relInverse[1].coordinate._yPoint)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static bool areInDiagonal(IEnumerable<CoordinateInfo> coordinate)
        {
            var relDiagonal = coordinate
                        .ToArray();

            if (relDiagonal[0].coordinate._xPoint + 1 == relDiagonal[1].coordinate._xPoint &&
                relDiagonal[0].coordinate._yPoint + 1 == relDiagonal[1].coordinate._yPoint)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void cleanCoordinate()
        {
            this.value = Symbol._;
        }
    }
}