using System.Runtime.InteropServices;

#pragma warning disable SYSLIB1054
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

        //För ett mer strukturerat och optimerat program har jag titlarna i txt filer.
        readonly static string[] mainTitle = File.ReadAllLines("assets/MainTitle.txt");
        readonly static string[] currencyTitle = File.ReadAllLines("assets/CurrencyTitle.txt");
        readonly static string[] triangleTitle = File.ReadAllLines("assets/TriangleTitle.txt");
        readonly static string[] sortTitle = File.ReadAllLines("assets/SortTitle.txt");
        readonly static string[] linBinTitle = File.ReadAllLines("assets/LinBinTitle.txt");
        readonly static string[] searchTitle = File.ReadAllLines("assets/SearchTitle.txt");

        //Programmets ingångsläge gör först konsolen fullscreen och sedan körs en loop tills användaren går ut ur den.
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

        //Här väljer man ett av de fem miniprogrammen.
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

        //Beroende på vilken tangent som trycks körs ett program, om tangenten inte stämmer kommer ett error meddelande.
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

        /*Detta program låter användaren välja två valutor samt en summa, för att konvertera från ena till den andra.
          Jag har skapat flera objekt, valutor, av klassen Currency där jag tilldelar attribut som namn, förkortning, tecken och
          framförallt ett värde i US Dollar. På så sätt kan jag använda dollar som ett globalt värde för att omvandla valutorna.*/
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
            if (!double.TryParse(input, out double amount1))
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

        //Detta program beräknar arean på en triangel givet en längd och bred i valfri enhet, och bestämmer sedan automatiskt lämplig enhet för resultatet.
        static void Triangle()
        {
            title = triangleTitle;
            TitleWriter();

            //Likt förra programet har jag klasser för måtten med ett globalt värde i meter
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
            if (!double.TryParse(input1, out double width))
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
            if (!double.TryParse(input2, out double length))
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

        //Här sorteras en array av givna heltal in i två nya arrays, en för jämna och en för udda nummer.
        static void Sort()
        {
            title = sortTitle;
            TitleWriter();

            Console.WriteLine("Enter any amount of numbers, separated by a comma and space.");
        Numbers:
            Console.ForegroundColor = ConsoleColor.Blue;
            string input = Console.ReadLine()!;
            Console.ForegroundColor = ConsoleColor.White;
            string[] inputs = input.Split(",");
            int[] numbers = new int[inputs.Length];
            int[] odd = [];
            int[] even = [];
            int l = -1;
            int j = -1;

            for (int i = 0; i < inputs.Length; i++)
            {
                inputs[i] = inputs[i].Trim();
                if (!int.TryParse(inputs[i], out numbers[i]))
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid, whole numbers");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto Numbers;
                }
                numbers[i] = Convert.ToInt32(inputs[i]);
            }

            //För att avgöra om talet är udda eller jämnt använder jag modero, %, operatören.
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 1)
                {
                    l++;
                    Array.Resize(ref odd, l + 1);
                    odd[l] = numbers[i];
                }
                else
                {
                    j++;
                    Array.Resize(ref even, j + 1);
                    even[j] = numbers[i];
                }
            }

            Array.Sort(odd);
            Array.Sort(even);

            Console.WriteLine();
            Console.Write("Out of the numbers you entered, ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(odd.Length);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" are odd:");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < odd.Length; i++)
            {
                Console.WriteLine(odd[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
            Console.Write("And ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(even.Length);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" are even:");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < even.Length; i++)
            {
                Console.WriteLine(even[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Här är ett program som demonstrerar linjär och binär sökning samt mäter tiden för de två algoritmerna.
        static void LinBinSearch()
        {
            title = linBinTitle;
            TitleWriter();

            Console.WriteLine("Which one would you like to try?");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1 - Linear search");
            Console.WriteLine("2 - Binary search");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            string mode;

        SearchChoice:
            ConsoleKeyInfo search = Console.ReadKey(true);
            switch (search.Key)
            {
                case ConsoleKey.D1:
                    mode = "linear";
                    break;
                case ConsoleKey.D2:
                    mode = "binary";
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto SearchChoice;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            if (mode == "linear")
            {
                Console.WriteLine("Linear search");
            }
            else
            {
                Console.WriteLine("Binary search");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            //Först skapas en array av ett slumpässigt antal nummer, och varje nummer slumpas.
            Random random = new();
            int rnd = random.Next(500, 2000);
            int[] numbers = new int[rnd];
            Number[] nums = new Number[rnd];
            for (int i = 0; i < rnd; i++)
            {
                int rand = random.Next(5000);
                numbers[i] = rand;
                nums[i] = new(rand, i);
            }

            //Sedan kan användaren välja ett nummer att söka efter.
            Console.WriteLine("Choose a number to search for:");
            for (int i = 0; i < rnd; i++)
            {
                if (i < rnd - 1)
                {
                    Console.Write(numbers[i] + ", ");
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }

        NumChoice:
            Console.ForegroundColor = ConsoleColor.Blue;
            string choosen = Console.ReadLine()!;
            if (!int.TryParse(choosen, out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please choose a valid number");
                Console.ForegroundColor = ConsoleColor.White;
                goto NumChoice;
            }
            int index = -1;
            DateTime startTime;
            TimeSpan endTime;

            //Den linjära sökningen är ganska simpel, programmet går igenom arrayen från början till slut tills nummret har hittats.
            if (mode == "linear")
            {
                startTime = DateTime.Now;
                for (int i = 0; i < rnd; i++)
                {
                    if (numbers[i] == choice)
                    {
                        index = i;
                        break;
                    }
                }
                endTime = DateTime.Now - startTime;
            }
            else
            {
                /*Binär sökning är lite mer avancerad. Den går ut på att varje gång halvera mängden data genom att kolla om mitten är mindre eller större
                  än det som sökes och fokusera på en av halvorna. Problemet med binär sökning är att den måste vara i storleksordning, vilket jag först inte
                  hade tänkt på när jag gjorde linjär sökning. Jag ville fortfarande kunna jämföra båda på samma array så jag kom på en lösning. Jag har en klass 
                  som heter Number, där objekten har attributen nummer och index. På så sätt kan jag sortera arrayen och utföra binär sökning och veta alla nummers
                  ursprungliga index. Detta tar troligen mycket längre tid dock och är inte optimalt.*/
                startTime = DateTime.Now;
                Array.Sort(nums, new NumSorter()!);
                int start = 0;
                int end = rnd - 1;
                while (start <= end)
                {
                    int centre = (start + end) / 2;
                    if (nums[centre].number == choice)
                    {
                        index = nums[centre].index;
                        break;
                    }
                    else if (nums[centre].number < choice)
                    {
                        start = centre + 1;
                    }
                    else
                    {
                        end = centre - 1;
                    }
                }
                endTime = DateTime.Now - startTime;
            }

            if (index == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(choice + " was not found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(choice);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" was found at index ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(index);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" in ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Math.Round(endTime.TotalMilliseconds) + " ms");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(".");
                for (int i = 0; i < rnd; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (i < rnd - 1)
                    {
                        Console.Write(numbers[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
        }

        //Här är en annan typ av sökalgoritm där jag söker igenom från början OCH slut samtidigt, in mot mitten.
        static void Search()
        {
            title = searchTitle;
            TitleWriter();

            Random random = new();
            int rnd = random.Next(500, 2000);
            int[] numbers = new int[rnd];
            for (int i = 0; i < rnd; i++)
            {
                int rand = random.Next(5000);
                numbers[i] = rand;
            }

            Console.WriteLine("Choose a number to search for:");
            for (int i = 0; i < rnd; i++)
            {
                if (i < rnd - 1)
                {
                    Console.Write(numbers[i] + ", ");
                }
                else
                {
                    Console.WriteLine(numbers[i]);
                }
            }

        NumChoice:
            Console.ForegroundColor = ConsoleColor.Blue;
            string choosen = Console.ReadLine()!;
            if (!int.TryParse(choosen, out int choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please choose a valid number");
                Console.ForegroundColor = ConsoleColor.White;
                goto NumChoice;
            }
            int index = -1;
            DateTime startTime;
            TimeSpan endTime;

            startTime = DateTime.Now;
            for (int i = 0; i < rnd; i++)
            {
                if (numbers[i] == choice)
                {
                    index = i;
                    break;
                }
                else if (numbers[rnd - 1 - i] == choice)
                {
                    index = rnd - 1 - i;
                    break;
                }
            }
            endTime = DateTime.Now - startTime;

            if (index == -1)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(choice + " was not found!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(choice);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" was found at index ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(index);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" in ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Math.Round(endTime.TotalMilliseconds) + " ms");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(".");
                for (int i = 0; i < rnd; i++)
                {
                    if (i == index)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    if (i < rnd - 1)
                    {
                        Console.Write(numbers[i]);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(", ");
                    }
                    else
                    {
                        Console.WriteLine(numbers[i]);
                    }
                }
            }
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

        class Currency(string name, string code, string symbol, double value)
        {
            public string name = name;
            public string code = code;
            public string symbol = symbol;
            public double value = value;
        }

        class Unit(string name, string sName, double value)
        {
            public string name = name;
            public string sName = sName;
            public double value = value;
        }

        public class Number(int number, int index)
        {
            public int number = number;
            public int index = index;
        }

        public class NumSorter : IComparer<Number>
        {
            public int Compare(Number? x, Number? y)
            {
                return x!.number.CompareTo(y!.number);
            }
        }
    }
}