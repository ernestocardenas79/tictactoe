using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe;
using Tictactoe.enums;
using Xunit;

namespace TictactoeTests
{
    public class CoordinateTest
    {
        [Fact]
        internal void hasRelation() {

            //en Fila
            Assert.True(new Coordinate(1, 0).getRelation(new Coordinate(0, 0)).relation == RelationType.inLine);
            Assert.True(new Coordinate(2, 1).getRelation(new Coordinate(1, 1)).relation == RelationType.inLine);
            Assert.False(new Coordinate(2, 0).getRelation(new Coordinate(0, 0)).relation == RelationType.inLine);
            Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(1, 2)).relation == RelationType.inLine);

            //en Columna
            Assert.True(new Coordinate(0, 0).getRelation(new Coordinate(0, 1)).relation == RelationType.inColumn);
            Assert.True(new Coordinate(2, 2).getRelation(new Coordinate(2, 1)).relation == RelationType.inColumn);
            Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(0, 2)).relation == RelationType.inColumn);
            Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(2, 1)).relation == RelationType.inColumn);

            ////En diagonal
            Assert.True(new Coordinate(2,2).getRelation(new Coordinate(1, 1)).relation == RelationType.inDiagonal);
            Assert.False(new Coordinate(2,2).getRelation(new Coordinate(0, 0)).relation == RelationType.inDiagonal);


            ////En Diagonal Inversa
            Assert.True(new Coordinate(2,0).getRelation(new Coordinate(1, 1)).relation == RelationType.inInverseDiagonal);
            Assert.False(new Coordinate(2,0).getRelation(new Coordinate(0, 2)).relation == RelationType.inInverseDiagonal);
            Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(1, 1)).relation == RelationType.inInverseDiagonal);

        }
    }
}
