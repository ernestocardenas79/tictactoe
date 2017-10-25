using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe;
using Xunit;

namespace TictactoeTests
{
    public class CoordinateTest
    {
        [Fact]
        internal void hasRelation() {

            Assert.True(new Coordinate(0,0).hasRelation(new Coordinate(0,1)).hasRelation);
            Assert.True(new Coordinate(2, 2).hasRelation(new Coordinate(2, 1)).hasRelation);
            Assert.True(new Coordinate(1,1).hasRelation(new Coordinate(2, 2)).hasRelation);
            Assert.True(new Coordinate(2, 2).hasRelation(new Coordinate(1, 1)).hasRelation);
            Assert.True(new Coordinate(1, 1).hasRelation(new Coordinate(0, 1)).hasRelation);
            Assert.True(new Coordinate(2, 1).hasRelation(new Coordinate(2, 2)).hasRelation);

            Assert.False(new Coordinate(0, 0).hasRelation(new Coordinate(2, 2)).hasRelation);
            Assert.False(new Coordinate(0, 0).hasRelation(new Coordinate(0, 2)).hasRelation);
            Assert.False(new Coordinate(2, 0).hasRelation(new Coordinate(0, 0)).hasRelation);
        }
    }
}
