using System;
using System.Collections.Generic;
using Tictactoe.enums;
using Tictactoe.structs;

namespace Tictactoe
{
    internal class Coordinate
    {
        internal Symbol value { get; set; }
        internal int row { get { return _xPoint; } }
        internal int column { get { return _yPoint; } }

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

        internal RelatedInfo getRelation(Coordinate coordinateToCompare)
        {
            //var tokenRelatedInfo = new List<RelatedInfo>();

            RelatedInfo relationInfo = new RelatedInfo();
            relationInfo.hasRelation = false;
            relationInfo.coordinateInfo = new CoordinateInfo();

            if (coordinateToCompare._xPoint == this._xPoint &&
                (coordinateToCompare._yPoint + 1 == this._yPoint ||
                coordinateToCompare._yPoint - 1 == this._yPoint)) {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inColumn,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (coordinateToCompare._yPoint == this._yPoint &&
                (coordinateToCompare._xPoint + 1 == this._xPoint||
                coordinateToCompare._xPoint - 1 == this._xPoint)) {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inLine,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (this._xPoint - 1  == coordinateToCompare._xPoint &&
                this._yPoint -1  == coordinateToCompare._yPoint) {

                relationInfo.hasRelation = true;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inDiagonal,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (this._xPoint  - 1 == coordinateToCompare._xPoint &&
                this._yPoint +1 == coordinateToCompare._yPoint)
            {
                relationInfo.hasRelation = true;

                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = RelationType.inInverseDiagonal,
                    coordinate = new Coordinate(this._xPoint, this._yPoint)
                };
            }

            if (relationInfo.hasRelation)
            {
                relationInfo.hasRelation = false;
                relationInfo.coordinateInfo = new CoordinateInfo()
                {
                    relation = null,
                    coordinate = new Coordinate()
                };
            }

            return relationInfo;
        }
    }
}