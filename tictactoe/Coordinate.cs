using System;
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

        internal RelatedInfo getRelation(Coordinate coordinateToCompare)
        {
            RelatedInfo relationInfo = new RelatedInfo();
            relationInfo.hasRelation = false;

            if (coordinateToCompare._xPoint == this._xPoint &&
                (coordinateToCompare._yPoint + 1 == this._yPoint ||
                coordinateToCompare._yPoint - 1 == this._yPoint)) {
                relationInfo.relation = RelationType.inColumn;
                relationInfo.hasRelation = true;

                return relationInfo;
            }


            if (coordinateToCompare._yPoint == this._yPoint &&
                (coordinateToCompare._xPoint + 1 == this._xPoint||
                coordinateToCompare._xPoint - 1 == this._xPoint)) {
                relationInfo.relation = RelationType.inLine;
                relationInfo.hasRelation = true;

                return relationInfo;
            }


            if ((coordinateToCompare._xPoint + 1 == this._xPoint && coordinateToCompare._yPoint + 1 == this._yPoint)) {
                relationInfo.relation = RelationType.inDiagonal;
                relationInfo.hasRelation = true;

                return relationInfo;
            } 

            if(coordinateToCompare._xPoint - 1 == this._xPoint && coordinateToCompare._yPoint - 1 == this._yPoint) {

                relationInfo.relation = RelationType.inInverseDiagonal;
                relationInfo.hasRelation=true;

                return relationInfo;
            }

            return relationInfo;
        }
    }
}