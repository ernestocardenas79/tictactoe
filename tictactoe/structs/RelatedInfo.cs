using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.enums;

namespace Tictactoe.structs
{
    internal struct RelatedInfo
    {
        internal bool hasRelation { get; set; }
        internal CoordinateInfo coordinateInfo { get; set; }
    }

    internal struct CoordinateInfo
    {
        internal RelationType? relation { get; set; }
        internal Coordinate coordinate { get; set; }
    }
}