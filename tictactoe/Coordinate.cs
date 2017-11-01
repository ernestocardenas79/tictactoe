using System;
using System.Collections.Generic;
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

        internal Coordinate(int xPoint, int yPoint) {
            this._xPoint = xPoint;
            this._yPoint = yPoint;

            cleanCoordinate();
        }

        internal void cleanCoordinate()
        {
            this.value = Symbol._;
        }

        internal List<RelatedInfo> getRelations(Coordinate coordinateToCompare)
        {
            var tokenRelatedInfo = new List<RelatedInfo>();

            RelatedInfo relationInfo = new RelatedInfo();
            relationInfo.hasRelation = false;
            relationInfo.coordinateInfo = new List<CoordinateInfo>();

            if (coordinateToCompare._xPoint == this._xPoint &&
                (coordinateToCompare._yPoint + 1 == this._yPoint ||
                coordinateToCompare._yPoint - 1 == this._yPoint)) {
                relationInfo.hasRelation = true;

                relationInfo.coordinateInfo.Add(new CoordinateInfo()
                {
                    relation = RelationType.inColumn,
                    row = this._xPoint
                });
            }

            if (coordinateToCompare._yPoint == this._yPoint &&
                (coordinateToCompare._xPoint + 1 == this._xPoint||
                coordinateToCompare._xPoint - 1 == this._xPoint)) {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo.Add(new CoordinateInfo()
                {
                    relation = RelationType.inLine,
                    row = this._xPoint,
                    column = this._yPoint
                });
            }

            if (this._xPoint - 1  == coordinateToCompare._xPoint &&
                this._yPoint -1  == coordinateToCompare._yPoint) {

                relationInfo.hasRelation = true;

                relationInfo.coordinateInfo.Add(new CoordinateInfo()
                {
                    relation = RelationType.inDiagonal,
                    row = this._xPoint,
                    column = this._yPoint
                });
            }

            if (this._xPoint  - 1 == coordinateToCompare._xPoint &&
                this._yPoint +1 == coordinateToCompare._yPoint)
            {
                relationInfo.hasRelation = true;

                relationInfo.coordinateInfo.Add(new CoordinateInfo()
                {
                    relation = RelationType.inInverseDiagonal,
                    row = this._xPoint,
                    column = this._yPoint
                });
            }

            if (relationInfo.hasRelation)
            {
                tokenRelatedInfo.Add(relationInfo);
                relationInfo.hasRelation = false;
                relationInfo.coordinateInfo.Add(new CoordinateInfo()
                {
                    relation = null,
                    row = null,
                    column = null
                });
            }

            return tokenRelatedInfo;
        }
    }
}