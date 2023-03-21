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

        Amount:
            Console.Write(c1.name + " to convert: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            double amount1;
            if (!double.TryParse(input, out amount1))
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid amount");
                Console.ForegroundColor = ConsoleColor.White;
                goto Amount;
            }

            double amount2 = (c1.value * amount1) / c2.value;

            string a1;
            string a2;
            if (c1 == USD || c1 == GBP)
            {
                a1 = c1.symbol + amount1;
            }
            else
            {
                a1 = amount1 + " " + c1.symbol;
            }
            if (c2 == USD || c2 == GBP)
            {
                a2 = c2.symbol + amount2;
            }
            else
            {
                a2 = amount2 + " " + c2.symbol;
            }

            Console.WriteLine();
            Console.WriteLine(a1 + " = " + a2);
        }

        static void Triangle()
        {
            title = triangleTitle;
            TitleWriter();

            Unit km = new("kilometre", "km", 1000);
            Unit m = new("metre", "m", 1);
            Unit dm = new("decimetre", "dm", 0.1);
            Unit cm = new("centimetre", "cm", 0.01);
            Unit mm = new("millimetre", "mm", 0.001);

            Unit u1;
            Unit u2;

            Console.WriteLine("Enter the measurements of your triangle to calculate the area.");

        Width:
            Console.Write("Width: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input1 = Console.ReadLine()!;
            double width;
            if (!double.TryParse(input1, out width))
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number");
                Console.ForegroundColor = ConsoleColor.White;
                goto Width;
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Width: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(input1 + " ");

        Unit1:
            Console.ForegroundColor = ConsoleColor.Blue;
            string wUnit = Console.ReadLine()!;
            switch (wUnit)
            {
                case "cm":
                    u1 = cm;
                    break;
                case "dm":
                    u1 = dm;
                    break;
                case "m":
                    u1 = m;
                    break;
                case "mm":
                    u1 = mm;
                    break;
                case "km":
                    u1 = km;
                    break;
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid unit of measurement");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Width: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(input1 + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Unit1;
            }
            Console.ForegroundColor = ConsoleColor.White;

        Length:
            Console.Write("Length: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string input2 = Console.ReadLine()!;
            double length;
            if (!double.TryParse(input2, out length))
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a valid number");
                Console.ForegroundColor = ConsoleColor.White;
                goto Length;
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Length: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(input2 + " ");

        Unit2:
            Console.ForegroundColor = ConsoleColor.Blue;
            string lUnit = Console.ReadLine()!;
            switch (lUnit)
            {
                case "cm":
                    u2 = cm;
                    break;
                case "dm":
                    u2 = dm;
                    break;
                case "m":
                    u2 = m;
                    break;
                case "mm":
                    u2 = mm;
                    break;
                case "km":
                    u2 = km;
                    break;
                default:
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid unit of measurement");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Length: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(input2 + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Unit2;
            }

            double widthValue = width * u1.value;
            double lengthValue = length * u2.value;
            double result = widthValue * lengthValue / 2;
            string resultUnit = "m";

            if (result < 0.1)
            {
                result *= 100;
                resultUnit = "dm";

                if (result < 0.1)
                {
                    result *= 100;
                    resultUnit = "cm";

                    if (result < 0.1)
                    {
                        result *= 100;
                        resultUnit = "mm";
                    }
                }
            }
            else if (result > 10000)
            {
                result /= 1000000;
                resultUnit = "km";
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Your triangle width a width of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(input1 + " " + wUnit);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" and length of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(input2 + " " + lUnit);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("has an area of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(result + " " + resultUnit + "²");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(".");
        }

        static void Sort()
        {
            title = sortTitle;
            TitleWriter();

            //skapa en array och låt användaren ange hur många heltal man vill
            //for loop för att gå igenom alla inputs i arrayen
            //använd % (modero) och kolla om det blir en rest eller inte efter inputen delats med 2
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

        class Unit
        {
            public string name;
            public string sName;
            public double value;

            public Unit(string name, string sName, double value)
            {
                this.name = name;
                this.sName = sName;
                this.value = value;
            }
        }
    }
}