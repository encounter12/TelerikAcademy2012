using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipDamage
{
    class ShipDamage
    {
        static bool IsOnRectangleCorners(int sX1, int sY1, int sX2, int sY2, int cX, int cY)
        {
            bool isAtRectangleCorners = false;
            if ((cX == sX1 && cY == sY1) || (cX == sX2 && cY == sY2) || (cX == sX1 && cY == sY2) || (cX == sX2 && cY == sY1))
            {
                isAtRectangleCorners = true;
            }
            return isAtRectangleCorners;
        }

        static bool IsOnRectangleSides(int sX1, int sY1, int sX2, int sY2, int cX, int cY)
        {
            bool isAtRectangleSides = false;
            bool isAtRectangleVerticalSides = false;
            bool isAtRectangleHorizontalSides = false;

            if ((cX == sX1 || cX == sX2) && cY > Math.Min(sY1, sY2) && cY < Math.Max(sY1, sY2))
            {
                isAtRectangleVerticalSides = true;
            }

            if ((cY == sY1 || cY == sY2) && cX > Math.Min(sX1, sX2) && cX < Math.Max(sX1, sX2))
            {
                isAtRectangleHorizontalSides = true;
            }
                            
            isAtRectangleSides = isAtRectangleVerticalSides || isAtRectangleHorizontalSides;
            return isAtRectangleSides;
        }

        static bool isInsideRectangle(int sX1, int sY1, int sX2, int sY2, int cX, int cY)
        {
            bool isInsideTheRectangle = false;
            if (cX > Math.Min(sX1, sX2) && cX < Math.Max(sX1, sX2) && cY > Math.Min(sY1, sY2) && cY < Math.Max(sY1, sY2))
            {
                isInsideTheRectangle = true;
            }
            return isInsideTheRectangle;
        }

        static int HorizontalAxisMirrorPointYCoord(int h, int cY)
        {
            int cYMirror = 0;
            if (cY >= h)
            {
                cYMirror = h - Math.Abs(h - cY);
            }
            else
            {
                cYMirror = h + Math.Abs(h - cY);
            }

            return cYMirror;
        }

        static void Main()
        {
            int sX1 = int.Parse(Console.ReadLine());
            int sY1 = int.Parse(Console.ReadLine());
            int sX2 = int.Parse(Console.ReadLine());
            int sY2 = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int[,] cCoordinates = new int[3,2];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cCoordinates[i,j] = int.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                cCoordinates[i,1] = HorizontalAxisMirrorPointYCoord(h, cCoordinates[i,1]);
            }
            

            int damage = 0;

            bool isAtRectangleCorners = false;
            bool isAtRectangleSides = false;
            bool isInsideTheRectangle = false;

            for (int i = 0; i < 3; i++)
            {
                isAtRectangleCorners = IsOnRectangleCorners(sX1, sY1, sX2, sY2, cCoordinates[i, 0], cCoordinates[i, 1]);
                isAtRectangleSides = IsOnRectangleSides(sX1, sY1, sX2, sY2, cCoordinates[i, 0], cCoordinates[i, 1]);
                isInsideTheRectangle = isInsideRectangle(sX1, sY1, sX2, sY2, cCoordinates[i, 0], cCoordinates[i, 1]);

                if (isAtRectangleCorners)
                {
                    damage += 25;
                }
                else if (isAtRectangleSides)
                {
                    damage += 50;
                }
                else if (isInsideTheRectangle)
                {
                    damage += 100;
                }
                
            }

            Console.WriteLine(damage + "%");
        }
    }
}
