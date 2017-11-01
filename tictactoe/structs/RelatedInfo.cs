using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe.enums;

namespace Tictactoe.structs
{
    internal struct RelatedInfo
    {
        internal bool hasRelation { get; set; }
        internal List<CoordinateInfo> coordinateInfo { get; set; }
    }

    internal struct CoordinateInfo
    {
        internal RelationType? relation { get; set; }
        internal int? row { get; set; }
        internal int? column { get; set; }
    }
}