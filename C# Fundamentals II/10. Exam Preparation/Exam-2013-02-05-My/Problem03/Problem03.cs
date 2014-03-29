using System;
using System.Collections.Generic;

class Program
{
    public struct Coords
    {
        public int x, y, z;

        public Coords(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }
    }

    public struct Direction
    {
        public int x, y, z;

        public Direction(int p1, int p2, int p3)
        {
            x = p1;
            y = p2;
            z = p3;
        }
    }    
    static void Main()
    {
        string[] cuboidSize = Console.ReadLine().Trim().Split(' ');
        string[] startCube = Console.ReadLine().Trim().Split(' ');
        string[] directionVector = Console.ReadLine().Trim().Split(' ');
       
        int width = int.Parse(cuboidSize[0]);
        int height = int.Parse(cuboidSize[1]);
        int depth = int.Parse(cuboidSize[2]);

        int startW = int.Parse(startCube[0]);
        int startH = int.Parse(startCube[1]);
        int startD = int.Parse(startCube[2]);

        int dirW = int.Parse(directionVector[0]);
        int dirH = int.Parse(directionVector[1]);
        int dirD = int.Parse(directionVector[2]);

        Coords currentCube = new Coords(startW, startH, startD);
        Direction initialDirection = new Direction(dirW, dirH, dirD);
        Direction upDirection = new Direction(0, 1, 0);
        Direction currentDirection = initialDirection;

        List<Coords> burnedCubes = new List<Coords>();
        Coords lastBurnedCube;
      
        while (!burnedCubes.Contains(currentCube))
        {
            burnedCubes.Add(currentCube);

            if (currentCube.y < width - 1 && currentDirection.Equals(upDirection))
            {
                currentCube.y++;
            }
            else if (currentCube.y == width - 1 && currentDirection.Equals(upDirection))
            {
                lastBurnedCube = currentCube;
                currentCube.y--;
            }    
                 
        }

        Console.WriteLine("Last visited cube coordinates: {0}, {1}, {2}", lastBurnedCube.x, lastBurnedCube.y, lastBurnedCube.z);
    }
}

