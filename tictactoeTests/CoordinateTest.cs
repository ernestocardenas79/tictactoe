﻿using System;
using System.Collections.Generic;
using System.Text;
using Tictactoe;
using Tictactoe.enums;
using Xunit;

namespace TictactoeTests
{
    public class CoordinateTest
    {
        internal void hasRelation() {

            ////en Fila
            //Assert.True(new Coordinate(1, 0).getRelation(new Coordinate(0, 0))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inLine));
            //Assert.True(new Coordinate(2, 1).getRelation(new Coordinate(1, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inLine));
            //Assert.False(new Coordinate(2, 0).getRelation(new Coordinate(0, 0))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inLine));
            //Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(1, 2))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inLine));

            ////en Columna
            //Assert.True(new Coordinate(0, 0).getRelation(new Coordinate(0, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inColumn));
            //Assert.True(new Coordinate(2, 2).getRelation(new Coordinate(2, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inColumn));
            //Assert.False(new Coordinate(0, 0).getRelation(new Coordinate(0, 2))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inColumn));
            //Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(2, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inColumn));

            //////En diagonal
            //Assert.True(new Coordinate(2,2).getRelation(new Coordinate(1, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inDiagonal));
            //Assert.False(new Coordinate(2,2).getRelation(new Coordinate(0, 0))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inDiagonal));


            //////En Diagonal Inversa
            //Assert.True(new Coordinate(2,0).getRelation(new Coordinate(1, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inInverseDiagonal));
            //Assert.False(new Coordinate(2,0).getRelation(new Coordinate(0, 2))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inInverseDiagonal));
            //Assert.False(new Coordinate(0, 2).getRelation(new Coordinate(1, 1))[0].coordinateInfo.Exists(ci => ci.relation == RelationType.inInverseDiagonal));

        }
    }
}
