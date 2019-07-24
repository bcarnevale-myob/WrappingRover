using System;
using System.Collections.Generic;
using System.Linq;

namespace WrappingRover
{
    public class Map
    {
        private IEnumerable<Space> _map;
        private int _width;
        private int _spaces;
        private Space _roverPosition;

        public Map(IEnumerable<IEnumerable<string>> map)
        {
            _width = map.First().Count();
            _spaces = map.Count() * _width;

            _map = BuildMap(map);
        }

        private IEnumerable<Space> BuildMap(IEnumerable<IEnumerable<string>> map)
        {
            var spaceMap = new List<Space>();

            foreach (var row in map)
            {
                foreach (var col in row)
                {
                    
                    spaceMap.Add(new Space(col));
                    if (col == "R") _roverPosition = spaceMap.Last();
                }
            }

            SewSpaceMap(spaceMap);
            return spaceMap;
        }

        private void SewSpaceMap(List<Space> spaceMap)
        {
            var currentRow = 0;
            for (var i = 0; i < spaceMap.Count; i++)
            {
                var space = spaceMap[i];
                space.North = spaceMap[((i - _width) % _spaces + _spaces) % _spaces];
                space.South = spaceMap[(i + _width) % _spaces];

                space.East = spaceMap[(i + 1) % _width + (currentRow * _width) % _spaces];
                space.West = spaceMap[((i - 1) % _width + _width) % _width + (currentRow * _width) % _spaces];

                if ((i + 1) % _width == 0)
                {
                    currentRow += 1;
                }
            }
        }

        public IEnumerable<char> Display()
        {
            var stringMap = string.Empty;

            var current = _map.First();
            var startingEdge = _map.First();
            do
            {
                stringMap += current.Character;
                current = current.East;

                if (current == startingEdge)
                {
                    current = current.South;
                    startingEdge = current;
                    stringMap += "\n";
                }
            } while (current != _map.First());

            return stringMap.TrimEnd('\n');
        }

        public void MoveRoverLeft()
        {
            MoveRover(_roverPosition.West);
        }

   
        public void MoveRoverRight()
        {
            MoveRover(_roverPosition.East);
        }

        public void MoveRoverUp()
        {
            MoveRover(_roverPosition.North);
        }

        public void MoveRoverDown()
        {
            MoveRover(_roverPosition.South);

        }
        
        private void MoveRover(Space newSpace)
        {
            
            if (newSpace.Character != " " ) throw new ArgumentException();
            _roverPosition.Character = " ";
            _roverPosition = newSpace;
            _roverPosition.Character = "R";
        }

        public bool CheckForObstacleAt(Space space)
        {
            if(space.Equals("X"));
        }
    }
}