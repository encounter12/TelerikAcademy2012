using System;

class IsPointWithinCircleAndOutsideRectangle
{
    static void Main()
    {
        Console.WindowWidth = 100;
        //A(x0,y0) - circle center; circle radius r
        float x0 = 1;
        float y0 = 1;
        float r = 3;

        //R(top = 1, left = -1, width = 6, height = 2)
        float topY = 1f;
        float leftX = -1f;
        float width = 6f;
        float height = 2f;
        float rightX = leftX + width;
        float bottomY = topY - height;

        Console.Write("This program checks if a given point C(x, y) is:\nwithin a circle K (A({0},{1}), r = {2}) ", x0, y0, r);
        Console.WriteLine("and outside rectangle R(top = {0}, left = {1}, width = {2}, height = {3})", topY, leftX, width, height);
        
        Console.WriteLine("Please enter the point coordinate x:");
        float x = Single.Parse(Console.ReadLine());
        Console.WriteLine("Please enter the point coordinate y:");
        float y = Single.Parse(Console.ReadLine());


        /*In order to solve this task 
         1. We compare the hypothenuse AC of the right triangle ABC with the circle radius r
         A(x0,y0) - circle center
         B(x,y0);
         C(x,y)
         
         AB = x - x0;
         BC = y - y0;
         AC = sqrt[(x - x0)^2 + (y - y0)^2]
         If AC <= r then the point C(x,y) is within the circle K
         
         2. We check if either of the point coordinates x or y is outside of the ranges respectively (leftX, rightX) and (topY, bottomY)
        
         */

        double hypothenuseAC = Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));
        

        if ((hypothenuseAC <= r) && ((x < leftX) || (x > rightX) || (y < bottomY) || (y > topY)))
        {
            Console.WriteLine("The point is WITHIN the circle and OUTSIDE the rectangle: TRUE");
        }
        else
        {
            Console.WriteLine("The point is WITHIN the circle and OUTSIDE the rectangle: FALSE");
        }

        Console.WriteLine();
    }
}

