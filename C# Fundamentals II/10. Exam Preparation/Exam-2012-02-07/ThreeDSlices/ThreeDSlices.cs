using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //1. Read input from console and initialize the cuboid 3-dimensional array 

        string[] cuboidSize = Console.ReadLine().Trim().Split(' '); //input 1st line: creating string array with the cuboid dimensions
        
        //declaring and initializing the cuboid dimensions variables
        int width = int.Parse(cuboidSize[0]);
        int height = int.Parse(cuboidSize[1]);
        int depth = int.Parse(cuboidSize[2]);

        int[,,] cuboid = new int[width, depth, height];

        long totalSum = 0;

        for (int h = 0; h < height; h++) //iterate through floors (heightSlices)
        {            
            string[] heightSlice = Console.ReadLine().Split(new string[] {" | "}, StringSplitOptions.None); //splits each floor into blocks

            /* heightSlice (or floor) are all the numbers on a single input line. 
             * heightSlince (or floor) contains depth number of blocks (string arrays) separated by " | ", each one having width number of elements.
             * In the input data height increases downwards, on 2nd line are the elements of 0 height slice (0 floor), 
             * on 3rd line are the elements of 1st height slice (1st floor),.., and so on.
             */
            for (int d = 0; d < depth; d++) //iterate through blocks of height slice h
            {
                string[] block = heightSlice[d].Split(' '); //from each block create string array having width number of elements
                for (int w = 0; w < width; w++) //iterate through the elements of block d
                {
                    cuboid[w, d, h] = int.Parse(block[w]); //assigning values to each element of the cuboid array
                    totalSum += cuboid[w, d, h];
                }
            }
        }
       
        int equalSumsCount = 0;
        long currentSum = 0;

        //2. Slices the cuboid in each dimension (width, depth, height) and checks if the two sub-cuboids have equal sums

        for (int h = 0; h < height - 1; h++) // slicing the cuboid at height dimension and iterating through the height slices
        {
            //adds the sum of elements for height slice h to currentSum
            for (int d = 0; d < depth; d++) 
            {
                for (int w = 0; w < width; w++)
                {
                    currentSum += cuboid[w, d, h];                    
                }
            }
            //if current sum is half the total sum the counter increments by 1
            if (currentSum * 2 == totalSum) 
            {
                equalSumsCount++;
            }
        }

        currentSum = 0; //resetting the currentSum to 0 so that we could re-use it below

        for (int d = 0; d < depth - 1; d++) //slicing the cuboid at depth dimension and iterating through the depth slices
        {
            //adds the sum of elements for depth slice d to currentSum
            for (int w = 0; w < width; w++) 
            {
                for (int h = 0; h < height; h++)
                {
                    currentSum += cuboid[w, d, h];
                }

            }
            //if current sum is half the total sum the counter increments by 1
            if (currentSum * 2 == totalSum) 
            {
                equalSumsCount++;
            }
        }

        currentSum = 0; //resetting the currentSum to 0 so that we could re-use it below

        for (int w = 0; w < width - 1; w++) //slicing the cuboid at width dimension and iterating through the width slices
        {
            //adds the sum of elements for width slice w to currentSum
            for (int h = 0; h < height; h++)
            {
                for (int d = 0; d < depth; d++)
                {
                    currentSum += cuboid[w, d, h];
                }
                
            }
            //if current sum is half the total sum the counter increments by 1
            if (currentSum * 2 == totalSum) 
            {
                equalSumsCount++;
            }
        }

        Console.WriteLine(equalSumsCount); 
    }
}

