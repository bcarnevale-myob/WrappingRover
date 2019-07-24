using System;
using System.Collections.Generic;
using WrappingRover;
using Xunit;

namespace WrappingRoverTests
{
    public class MapTests
    {
        [Fact]
        public void CanCreateMap()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {".", ".", "."},
                new List<string> {".", "R", "."},
                new List<string> {".", ".", "."}
            };


            var map = new Map(initialMap);

            var expectedMap = "...\n" +
                              ".R.\n" +
                              "...";

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoverLeft()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " ", " ", " ", " "},
                new List<string> {" ", " ", " ", "R", " ", " "},
                new List<string> {" ", " ", " ", " ", " ", " "},
            };


            var map = new Map(initialMap);

            var expectedMap = "      \n" +
                              "  R   \n" +
                              "      ";

            map.MoveRoverLeft();

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoverRight()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = "   \n" +
                              "  R\n" +
                              "   ";

            map.MoveRoverRight();

            Assert.Equal(expectedMap, map.Display());
        }


        [Fact]
        public void CanMoveRoverUp()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = " R \n" +
                              "   \n" +
                              "   ";

            map.MoveRoverUp();

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoverDown()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = "   \n" +
                              "   \n" +
                              " R ";

            map.MoveRoverDown();

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoverTwoSpacesLeft()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = "   \n" +
                              "  R\n" +
                              "   ";

            map.MoveRoverLeft();
            map.MoveRoverLeft();

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoverThreeSpacesLeft()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = "   \n" +
                              " R \n" +
                              "   ";

            map.MoveRoverLeft();
            map.MoveRoverLeft();
            map.MoveRoverLeft();

            Assert.Equal(expectedMap, map.Display());
        }

        [Fact]
        public void CanMoveRoveOneSpaceLeftThenOneSpacesUp()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = "R  \n" +
                              "   \n" +
                              "   ";

            map.MoveRoverLeft();
            map.MoveRoverUp();

            var actual = map.Display();
            Assert.Equal(expectedMap, actual);
        }

        [Fact]
        public void CanMoveRoverThreeSpacesLeftThenTwoSpacesDown()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " "},
                new List<string> {" ", "R", " "},
                new List<string> {" ", " ", " "}
            };


            var map = new Map(initialMap);

            var expectedMap = " R \n" +
                              "   \n" +
                              "   ";

            map.MoveRoverLeft();
            map.MoveRoverLeft();
            map.MoveRoverLeft();
            map.MoveRoverDown();
            map.MoveRoverDown();

            Assert.Equal(expectedMap, map.Display());
        }
        
        [Fact]
        public void CanSetAnObstacle()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " ", " ", " ", " "},
                new List<string> {" ", "X", " ", "R", " ", " "},
                new List<string> {" ", " ", " ", " ", " ", " "},
            };


            var map = new Map(initialMap);

            var expectedMap = "      \n" +
                              " XR   \n" +
                              "      ";

            map.MoveRoverLeft();

            Assert.Equal(expectedMap, map.Display());
        }
        
        [Fact]
        public void RoverWillKnowIfItHitAnObstacle()
        {
            var initialMap = new List<List<string>>
            {
                new List<string> {" ", " ", " ", " ", " ", " "},
                new List<string> {" ", "X", " ", "R", " ", " "},
                new List<string> {" ", " ", " ", " ", " ", " "},
            };


            var map = new Map(initialMap);

            map.MoveRoverLeft();
            map.MoveRoverLeft();

            Assert.True(map.CheckForObstacleAt());
        }
    }
}