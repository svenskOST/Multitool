using System.Runtime.InteropServices;

namespace Multitool
{
    class Program
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        readonly private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        static string[]? title;

        readonly static string[] mainTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\MainTitle.txt");
        readonly static string[] currencyTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\CurrencyTitle.txt");
        readonly static string[] triangleTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\TriangleTitle.txt");
        readonly static string[] sortTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\SortTitle.txt");
        readonly static string[] linBinTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\LinBinTitle.txt");
        readonly static string[] searchTitle = File.ReadAllLines(@"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Multitool (11)\Multitool\Titles\SearchTitle.txt");

        static void Main()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);

            title = mainTitle;
            TitleWriter();
            Console.WriteLine("Welcome to my multitool program!");

            MainLoop();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Thank you for using the program, bye!");
        }

        static void MainLoop()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please choose a tool by pressing the corresponding number:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Currency converter");
            Console.WriteLine("2 - Triangle area calculator");
            Console.WriteLine("3 - Sort odd and even numbers");
            Console.WriteLine("4 - Lineary and binary search");
            Console.WriteLine("5 - Search algorithm");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();

        ToolChoice:
            ConsoleKeyInfo tool = Console.ReadKey(true);
            switch (tool.Key)
            {
                case ConsoleKey.D1:
                    Currency();
                    break;
                case ConsoleKey.D2:
                    Triangle();
                    break;
                case ConsoleKey.D3:
                    Sort();
                    break;
                case ConsoleKey.D4:
                    LinBinSearch();
                    break;
                case ConsoleKey.D5:
                    Search();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto ToolChoice;
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Do you want to continue or exit the program?");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Continue");
            Console.WriteLine("2 - Exit");
            Console.ForegroundColor = ConsoleColor.White;

        AdvanceChoice:
            ConsoleKeyInfo advance = Console.ReadKey(true);
            switch (advance.Key)
            {
                case ConsoleKey.D1:
                    MainLoop();
                    break;
                case ConsoleKey.D2:
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto AdvanceChoice;
            }
        }

        static void Currency()
        {
            title = currencyTitle;
            TitleWriter();
            //input och output
            //göra om alla valutor till USD som globalt värde så man slipper programmera varje möjlig kombination
            //kanske göra alla valutor som klasser så kan de ha sin omvandling till USD som en property i konstruktorn
        }

        static void Triangle()
        {
            title = triangleTitle;
            TitleWriter();
        }

        static void Sort()
        {
            title = sortTitle;
            TitleWriter();
        }

        static void LinBinSearch()
        {
            title = linBinTitle;
            TitleWriter();
        }

        static void Search()
        {
            title = searchTitle;
            TitleWriter();
        }

        static void TitleWriter()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string ln in title!)
            Console.WriteLine(ln);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}