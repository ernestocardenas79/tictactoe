﻿using System;
using System.Collections.Generic;
using System.Linq;
using Tictactoe;
using Tictactoe.enums;
using Tictactoe.structs;
using Xunit;

namespace TictactoeTests
{
    public class BoardTest
    {
        [Fact]
        internal void chooseRightCoordinate()
        {
            Board board = new Board3x3();

            int fila = 0;
            int columna = 1;

            Assert.True(board.isValidToken(fila, columna));

            fila = 4;
            columna = 3;
            Assert.False(board.isValidToken(fila, columna));
        }

        [Fact]
        internal void ConvertKeyToNumber()
        {
            int value = 0;
            Board board = new Board3x3();
            ConsoleKeyInfo cki = new ConsoleKeyInfo('2', ConsoleKey.D2, false, false, false); ;

            Assert.True(board.convertKeyToNumber(cki, out value));
            Assert.Equal(2, value);
        }

        [Fact]
        internal void areYouFullTest() {
            Board board = new Board3x3();

            Assert.False(board.areYouFull());

            Player player = new Player(Symbol.O);

            board.makeMove(player,0,0);
            board.makeMove(player, 0, 1);
            board.makeMove(player, 0, 2);
            board.makeMove(player, 1, 0);
            board.makeMove(player, 1, 1);
            board.makeMove(player, 1, 2);
            board.makeMove(player, 2, 0);
            board.makeMove(player, 2, 1);
            board.makeMove(player, 2, 2);

            Assert.True(board.areYouFull());

        }

        [Fact]
        internal void thereIsTTTTest() {

            Player playerO = new Player(Symbol.O);
            Player playerX = new Player(Symbol.X);

            Board board = new Board3x3();

            board.makeMove(playerO, 0, 0);
            board.makeMove(playerX, 1, 1);
            board.makeMove(playerO, 0, 2);
            board.makeMove(playerX, 1, 0);
            board.makeMove(playerO, 1, 2);

            Assert.True(!board.thereIsTTT(playerO.symbol)&& !board.areYouFull());

            board.clearBoard();

            board.makeMove(playerO, 0, 0);
            board.makeMove(playerO, 0, 1);
            board.makeMove(playerO, 1, 2);

            Assert.False(board.thereIsTTT(playerO.symbol));

            board.clearBoard();

            board.makeMove(playerO, 0, 0);
            board.makeMove(playerO, 0, 1);
            board.makeMove(playerO, 1, 2);

            Assert.False(board.thereIsTTT(playerO.symbol));
        }

        [Fact]
        internal void isEnogthToWinTest() {
            Board board = new Board3x3();

            List<RelatedInfo> tokenRelatedInfo = new List<RelatedInfo>() {
                new RelatedInfo()
                {
                    hasRelation = true,
                    relation = RelationType.inColumn
                }, new RelatedInfo()
                {
                    hasRelation = false
                }, new RelatedInfo()
                {
                    hasRelation = true,
                    relation = RelationType.inDiagonal
                }, new RelatedInfo()
                {
                    hasRelation = false,
                }, new RelatedInfo()
                {
                    hasRelation = true,
                    relation = RelationType.inColumn
                }
            };

            Assert.True( board.isEnogthToWin(tokenRelatedInfo));


            tokenRelatedInfo = new List<RelatedInfo>() {
                new RelatedInfo()
                {
                    hasRelation = true,
                    relation = RelationType.inColumn
                }, new RelatedInfo()
                {
                    hasRelation = false
                }, new RelatedInfo()
                {
                    hasRelation = true,
                    relation = RelationType.inInverseDiagonal
                }, new RelatedInfo()
                {
                    hasRelation = false,
                }, new RelatedInfo()
                {
                    hasRelation = false,
                }
            };

            Assert.False( board.isEnogthToWin(tokenRelatedInfo));
        }
    }
}