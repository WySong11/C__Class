using System;

public class Input
{
    public static int GetHeight()
    {
        Console.Write("Enter the height of the diamond (odd number): ");
        int height;
        while (!int.TryParse(Console.ReadLine(), out height) || height <= 0 || height % 2 == 0)
        {
            Console.Write("Invalid input. Please enter a positive odd number: ");
        }
        return height;
    }

    public static bool RestartProgram()
    {
        Console.Write("Do you want to draw another diamond? (y/n): ");
        string? response = Console.ReadLine()?.Trim().ToLower();
        return response == "y" || response == "yes";
    }
}
