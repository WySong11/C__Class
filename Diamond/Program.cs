using System;
using static System.Console;

namespace Diamond
{
    public class Program
    {
        // 델리게이트 정의
        public delegate void PrintDiamond(int height);

        static void Main(string[] args)
        {
            DrawDiamond();
        }

        public static void DrawDiamond()
        {
            WriteLine();
            int height = Input.GetHeight();
            WriteLine();

            PrintDiamond? printDiamond = null;

            printDiamond += Output.PrintDiamondOneLoop;
            printDiamond += Output.PrintDiamond;

            printDiamond += Output.testheight;

            // 이 밑에 줄을 델리게이트로 호출하세요.
            //Output.PrintDiamondOneLoop(height);

            printDiamond?.Invoke(height);

            WriteLine();

            if (Input.RestartProgram())
            {
                DrawDiamond();
            }
            else
            {
                WriteLine("Thank you for using the diamond drawing program!");
            }

            printDiamond = null;
        }
    }
}
