using System;

class BitBall
{
    static int GetBitOnPosition(byte number, int position)
    {
        byte bitMask = (byte)(1 << position);
        int result = (number & bitMask) >> position;
        return result;
    }
    static void Main()
    {
        int[,] teamTop = new int[8, 8];
        int[,] teamBottom = new int[8, 8];

        byte number;

        //Get the n0 - n7 numbers and fill in the bits in teamTop array

        for (int i = 0; i < 8; i++)
        {
            number = byte.Parse(Console.ReadLine());

            for (int j = 7; j >= 0; j--)
            {
                teamTop[i, j] = GetBitOnPosition(number, 7 - j);
            }
        }

        /*Get the n8 - n15 numbers and fill in the bits in teamBottom array. 
        Here I also check if there are bits on the same position (foul) and if so I make this cells 0s.*/

        for (int i = 0; i < 8; i++)
        {
            number = byte.Parse(Console.ReadLine());

            for (int j = 7; j >= 0; j--)
            {
                teamBottom[i, j] = GetBitOnPosition(number, 7 - j);

                if (teamBottom[i, j] == 1 && teamTop[i, j] == 1) //make the respective ones zeros if there is foul
                {
                    teamBottom[i, j] = 0;
                    teamTop[i, j] = 0;
                }
            }
        }

        int teamTopScore = 0;
        int teamBottomScore = 0;

        for (int i = 7; i >= 0; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (teamTop[i, j] == 1)
                {
                    if (i == 7)
                    {
                        teamTopScore += 1; 
                    }
                    else 
                    {
                        for (int m = i + 1; m < 8; m++)
                        {
                            if (teamTop[m, j] == 1 || teamBottom[m, j] == 1)
                            {
                                break;
                            }
                            else if (m == 7)
                            {
                                teamTopScore += 1;
                            }
                        }
                    }
                }                                
            }
        }

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (teamBottom[i, j] == 1)
                {
                    if (i == 0)
                    {
                        teamBottomScore += 1;
                    }
                    else
                    {
                        for (int m = i - 1; m >= 0; m--)
                        {
                            if (teamBottom[m, j] == 1 || teamTop[m, j] == 1)
                            {
                                break;
                            }
                            else if (m == 0)
                            {
                                teamBottomScore += 1;
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine("{0}:{1}", teamTopScore, teamBottomScore);
    }
}
