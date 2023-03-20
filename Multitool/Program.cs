using System.Runtime.InteropServices;
using System.Runtime.Versioning;

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
                    CurrencyConverter();
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

        static void CurrencyConverter()
        {
            title = currencyTitle;
            TitleWriter();
            //input och output
            //göra om alla valutor till USD som globalt värde så man slipper programmera varje möjlig kombination
            //kanske göra alla valutor som klasser så kan de ha sin omvandling till USD som en property i konstruktorn

            Currency USD = new("US Dollar", "USD", "$", 1);
            Currency EUR = new("Euro", "EUR", "€", 1.07);
            Currency SEK = new("Swedish Krona", "SEK", "kr", 0.096);
            Currency ZAR = new("South African Rand", "ZAR", "R", 0.054);
            Currency GBP = new("British Pound", "GBP", "£", 1.22);
            Currency JPY = new("Japanese Yen", "JPY", "¥", 0.0076);

            Currency c1;
            Currency c2;

            Console.WriteLine("Enter currencies and amount to convert. Available currencies are:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("US Dollar (USD)");
            Console.WriteLine("Euro (EUR)");
            Console.WriteLine("Swedish Krona (SEK)");
            Console.WriteLine("South African Rand (ZAR)");
            Console.WriteLine("British Pound (GBP)");
            Console.WriteLine("Japanese Yen (JPY)");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        Currency1:
            Console.Write("Convert ");
            Console.ForegroundColor = ConsoleColor.Blue;
            ConsoleKeyInfo c11 = Console.ReadKey();
            ConsoleKeyInfo c12 = Console.ReadKey();
            ConsoleKeyInfo c13 = Console.ReadKey();
            string currency1 = c11.Key.ToString() + c12.Key.ToString() + c13.Key.ToString();
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            Console.Write(currency1);
            Console.ForegroundColor = ConsoleColor.White;
            switch (currency1)
            {
                case "USD":
                    c1 = USD;
                    break;
                case "EUR":
                    c1 = EUR;
                    break;
                case "SEK":
                    c1 = SEK;
                    break;
                case "ZAR":
                    c1 = ZAR;
                    break;
                case "GBP":
                    c1 = GBP;
                    break;
                case "JPY":
                    c1 = JPY;
                    break;
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid currency");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Currency1;
            }
            Console.Write(" to ");
        Currency2:
            Console.ForegroundColor = ConsoleColor.Blue;
            ConsoleKeyInfo c21 = Console.ReadKey();
            ConsoleKeyInfo c22 = Console.ReadKey();
            ConsoleKeyInfo c23 = Console.ReadKey();
            string currency2 = c21.Key.ToString() + c22.Key.ToString() + c23.Key.ToString();
            Console.SetCursorPosition(Console.CursorLeft - 3, Console.CursorTop);
            Console.WriteLine(currency2);
            Console.ForegroundColor = ConsoleColor.White;
            switch (currency2)
            {
                case "USD":
                    c2 = USD;
                    break;
                case "EUR":
                    c2 = EUR;
                    break;
                case "SEK":
                    c2 = SEK;
                    break;
                case "ZAR":
                    c2 = ZAR;
                    break;
                case "GBP":
                    c2 = GBP;
                    break;
                case "JPY":
                    c2 = JPY;
                    break;
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid currency");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Convert ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(currency1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" to ");
                    goto Currency2;
            }

            Console.Write(c1.name + " to convert: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string ln in title!)
                Console.WriteLine(ln);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine();
        }

        class Currency
        {
            public string name;
            public string code;
            public string symbol;
            public double value;

            public Currency(string name, string code, string symbol, double value)
            {
                this.name = name;
                this.code = code;
                this.symbol = symbol;
                this.value = value;
            }
        }
    }
}