using System;

public class Output
{
    public static void PrintDiamond(int height)
    {
        int spaces = height / 2;
        int stars = 1;
        // Print the upper part of the diamond
        for (int i = 0; i < height / 2 + 1; i++)
        {
            Console.Write(new string(' ', spaces));
            Console.WriteLine(new string('*', stars));
            spaces--;
            stars += 2;
        }
        // Reset spaces and stars for the lower part
        spaces = 1;
        stars = height - 2;
        // Print the lower part of the diamond
        for (int i = 0; i < height / 2; i++)
        {
            Console.Write(new string(' ', spaces));
            Console.WriteLine(new string('*', stars));
            spaces++;
            stars -= 2;
        }
    }

    public static void PrintDiamondOneLoop(int height)
    {
        int spaces = height / 2;
        int stars = 1;
        // Print the diamond using one loop
        for (int i = 0; i < height; i++)
        {
            Console.Write(new string(' ', spaces));
            Console.WriteLine(new string('*', stars));
            if (i < height / 2)
            {
                spaces--;
                stars += 2;
            }
            else
            {
                spaces++;
                stars -= 2;
            }
        }
    }

    public static void testheight(int i)
    {
        return ;
    }
}