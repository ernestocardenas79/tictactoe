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

            //en Columna
            Assert.True(new Coordinate(1, 0).getRelation(new Coordinate(0, 0)).hasRelation);
            Assert.True(new Coordinate(2, 1).getRelation(new Coordinate(1, 1)).hasRelation);
            Assert.False(new Coordinate(2, 0).getRelation(new Coordinate(0, 0)).hasRelation);
            Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(1, 2)).hasRelation);

            //enFila
            Assert.True(new Coordinate(0, 0).getRelation(new Coordinate(0, 1)).hasRelation);
            Assert.True(new Coordinate(2, 2).getRelation(new Coordinate(2, 1)).hasRelation);
            Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(0, 2)).hasRelation);
            Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(2, 1)).hasRelation);

            //En diagonal
            Assert.True(new Coordinate(1, 1).getRelation(new Coordinate(2, 2)).hasRelation);
            Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(2, 2)).hasRelation);


            //En Diagonal Inversa
            Assert.True(new Coordinate(2, 2).getRelation(new Coordinate(1, 1)).hasRelation);
            Assert.True(new Coordinate(2, 0).getRelation(new Coordinate(1, 1)).hasRelation);
            Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(2, 0)).hasRelation);

        }
    }
}
