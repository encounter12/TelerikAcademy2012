using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class FighterAttack
    {
        static void Main()
        {
            int pX1 = int.Parse(Console.ReadLine());
            int pY1 = int.Parse(Console.ReadLine());
            int pX2 = int.Parse(Console.ReadLine());
            int pY2 = int.Parse(Console.ReadLine());
            int fX = int.Parse(Console.ReadLine());
            int fY = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            int hitPointX = fX + d;
            int hitPointY = fY;

            int totalDamage = 0;

            if (hitPointX >= Math.Min(pX1, pX2) && hitPointX <= Math.Max(pX1, pX2) && hitPointY >= Math.Min(pY1, pY2) && hitPointY <= Math.Max(pY1, pY2))
            {
                totalDamage += 100;
            }
            if (hitPointX + 1 >= Math.Min(pX1, pX2) && hitPointX + 1 <= Math.Max(pX1, pX2) && hitPointY >= Math.Min(pY1, pY2) && hitPointY <= Math.Max(pY1, pY2))
            {
                totalDamage += 75;
            }
            if (hitPointX >= Math.Min(pX1, pX2) && hitPointX <= Math.Max(pX1, pX2) && hitPointY + 1 >= Math.Min(pY1, pY2) && hitPointY + 1 <= Math.Max(pY1, pY2))
            {
                totalDamage += 50;
            }
            if (hitPointX >= Math.Min(pX1, pX2) && hitPointX <= Math.Max(pX1, pX2) && hitPointY - 1 >= Math.Min(pY1, pY2) && hitPointY - 1 <= Math.Max(pY1, pY2))
            {
                totalDamage += 50;
            }
            Console.WriteLine(totalDamage + "%");


        }
    }
}
