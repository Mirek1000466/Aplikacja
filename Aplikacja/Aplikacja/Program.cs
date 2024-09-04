using Aplikacja;
MenuFrame.SplashScreen(10, 70, 1300);
Menu.MainMenu(9, 1);
public static class Utils
{
    public static void EmployeeData(int left, int top, char c)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(left, top);
        Console.Write("    IMIĘ : ");
        Console.SetCursorPosition(left, top + 2);
        Console.Write("NAZWISKO : ");
        Console.SetCursorPosition(left - 6, top + 4);
        Console.Write("DATA URODZENIA : ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("DD-MM-RRRR");
        Console.SetCursorPosition(left, top + 6);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("    PŁEĆ : ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("K/M");
        Console.SetCursorPosition(left + 11, top);
        Console.CursorVisible = true;
        var indicator = 0;
        var requirement = true;
        Console.ForegroundColor = ConsoleColor.White;
        while (requirement)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                        Console.Write(Menu.employeeData[indicator]);
                        if (indicator == 0)
                        {
                            indicator = 3;
                        }
                        else
                        {
                            indicator--;
                        }
                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(Menu.employeeData[indicator]);
                        break;
                    }
                case ConsoleKey.Enter:
                case ConsoleKey.DownArrow:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                        Console.Write(Menu.employeeData[indicator]);
                        if (indicator == 3)
                        {
                            indicator = 0;
                        }
                        else
                        {
                            indicator++;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                        Console.Write(Menu.employeeData[indicator]);
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        if (c == 'm') Menu.MainMenu(9, 1);
                        else Menu.FileEmployee(1);
                        break;
                    }
                case ConsoleKey.Backspace:
                    {
                        if (Menu.employeeData[indicator] != null)
                        {
                            if (indicator == 2)
                            {
                                if (Menu.employeeData[indicator].Length == 3 || Menu.employeeData[indicator].Length == 6) Menu.employeeData[indicator] =
                                        Menu.employeeData[indicator][..(Menu.employeeData[indicator].Length - 2)];
                                else Menu.employeeData[indicator] = Menu.employeeData[indicator][..(Menu.employeeData[indicator].Length - 1)];
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.Write("DD-MM-RRRR");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.Write(Menu.employeeData[indicator]);
                            }
                            else
                            {
                                if (indicator == 3)
                                {
                                    if (!string.IsNullOrEmpty(Menu.employeeData[indicator]))
                                    {
                                        if (Menu.employeeData[indicator] == "MĘŻCZYZNA") { Menu.employeeData[indicator] = "KOBIETA"; }
                                        else { Menu.employeeData[indicator] = "MĘŻCZYZNA"; }
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(Menu.employeeData[indicator]))
                                    {
                                        Menu.employeeData[indicator] = Menu.employeeData[indicator][..(Menu.employeeData[indicator].Length - 1)];
                                    }
                                }
                                MenuFrame.CleanWindow(left + 11, top + (indicator * 2), Menu.employeeData[indicator].Length + 2, 1, 0, 0);
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.Write(Menu.employeeData[indicator]);
                            }
                        }
                        else Console.SetCursorPosition(left + 11, top + (indicator * 2));
                        break;
                    }
                case ConsoleKey.Tab:
                    {
                        var condition = true;
                        while (condition)
                        {
                            indicator = 0;
                            while (indicator < 4)
                            {
                                var buffer = "";
                                if (!string.IsNullOrEmpty(Menu.employeeData[indicator])) buffer = Menu.employeeData[indicator].Replace(" ", "");
                                if (buffer.Length == 0)
                                {
                                    Menu.employeeData[indicator] = "";
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                    Console.CursorVisible = false;
                                    switch (indicator)
                                    {
                                        case 0:
                                            {
                                                Console.Write("NALEŻY PODAĆ IMIĘ PRACOWNIKA !");
                                                break;
                                            }
                                        case 1:
                                            {
                                                Console.Write("NALEŻY PODAĆ NAZWISKO PRACOWNIKA !");
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.Write("NALEŻY DATĘ URODZENIA PRACOWNIKA !");
                                                break;
                                            }
                                        default:
                                            {
                                                Console.Write("NALEŻY PODAĆ PŁEĆ PRACOWNIKA !");
                                                break;
                                            }
                                    }
                                    Thread.Sleep(2000);
                                    MenuFrame.CleanWindow(left + 11, top + (indicator * 2), 35, 1, 0, 0);
                                    switch (indicator)
                                    {
                                        case 2:
                                            {
                                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                Console.Write("DD-MM-RRRR");
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                Console.Write("K/M");
                                                break;
                                            }
                                    }
                                    Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(Menu.employeeData[indicator]);
                                    Console.CursorVisible = true;
                                    condition = false;
                                    break;
                                }
                                else
                                {
                                    if (indicator == 2)
                                    {
                                        if (Menu.employeeData[indicator].Length == 10) indicator++;
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                            Console.CursorVisible = false;
                                            Console.Write("NALEŻY DATĘ URODZENIA PRACOWNIKA !");
                                            Thread.Sleep(2000);
                                            MenuFrame.CleanWindow(left + 11, top + (indicator * 2), 35, 1, 0, 0);
                                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.Write("DD-MM-RRRR");
                                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(Menu.employeeData[indicator]);
                                            Console.CursorVisible = true;
                                            condition = false;
                                            break;
                                        }
                                    }
                                    else indicator++;
                                }
                            }
                            if (indicator == 4) condition = false;
                        }
                        if (indicator == 4) requirement = false;
                        break;
                    }
                default:
                    {
                        if (indicator == 2)
                        {

                            if (Menu.employeeData[indicator] != null && Menu.employeeData[indicator].Length == 10)
                            {
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.Write(' ');
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            }
                            else
                            {
                                if ((char)key.KeyChar >= '0' && (char)key.KeyChar <= '9')
                                {
                                    Menu.employeeData[indicator] += key.KeyChar;
                                    if (Menu.employeeData[indicator].Length == 2 || Menu.employeeData[indicator].Length == 5) Menu.employeeData[indicator] += '-';
                                }
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write("DD-MM-RRRR");
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(Menu.employeeData[indicator]);
                            }
                        }
                        else
                        {
                            if (indicator == 3)
                            {
                                if ((char)key.KeyChar == 'M' || (char)key.KeyChar == 'm') { Menu.employeeData[indicator] = "MĘŻCZYZNA"; }
                                else
                                {
                                    if ((char)key.KeyChar == 'K' || (char)key.KeyChar == 'k') { Menu.employeeData[indicator] = "KOBIETA"; }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(Menu.employeeData[indicator]))
                                        {
                                            if (indicator == 3)
                                            {
                                                if ((char)key.KeyChar == 'M' || (char)key.KeyChar == 'm') { Menu.employeeData[indicator] = "MĘŻCZYZNA"; }
                                                else
                                                {
                                                    if ((char)key.KeyChar == 'K' || (char)key.KeyChar == 'k') { Menu.employeeData[indicator] = "KOBIETA"; }
                                                    else
                                                    {
                                                        if (string.IsNullOrEmpty(Menu.employeeData[indicator]))
                                                        {
                                                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                                            Console.Write("k / m");
                                                        }
                                                    }
                                                }
                                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write(Menu.employeeData[indicator]);
                                            }
                                            else
                                            {
                                                Menu.employeeData[indicator] += key.KeyChar;
                                            }
                                        }
                                    }
                                }
                                Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(Menu.employeeData[indicator]);
                            }
                            else
                            {
                                Menu.employeeData[indicator] += (char)key.KeyChar;
                            }
                        }
                        break;
                    }
            }
        }
        if (c == 'f')
        {
            if (!Directory.Exists("DANE PRACOWNIKÓW")) Directory.CreateDirectory("DANE PRACOWNIKÓW");
            //Directory.SetCurrentDirectory("DANE PRACOWNIKÓW");
            string fileName = Menu.employeeData[1] + " " + Menu.employeeData[0] + ".TXT";
            if (!File.Exists("DANE PRACOWNIKÓW/" + fileName))
            {
                using (StreamWriter sw = new StreamWriter("DANE PRACOWNIKÓW/" + fileName))
                {
                    sw.WriteLine(Menu.employeeData[0]);
                    sw.WriteLine(Menu.employeeData[1]);
                    sw.WriteLine(Menu.employeeData[2]);
                    sw.WriteLine(Menu.employeeData[3]);
                }
            }
            else
            {
                var buffer = "Pracownik " + Menu.employeeData[0] + " " + Menu.employeeData[1] + " już istnieje w bazie danych !";
                Console.SetCursorPosition((Console.BufferWidth - buffer.Length) / 2, top + 10);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(buffer);
                Thread.Sleep(5000);
            }
            Menu.FileEmployee(1);
        }
    }
    public static void EmployeeAddGrade(int left, int top, char c)
    {
        MenuFrame.RatingsPanel(left, top, c);
        var employeeMemory = new EmployeeMemory(Menu.employeeData[0], Menu.employeeData[1], Menu.employeeData[2], Menu.employeeData[3]);
        employeeMemory.GradeAdded += EmployeeGradeAdded;
        var employeeFile = new EmployeeFile(Menu.employeeData[0], Menu.employeeData[1], Menu.employeeData[2], Menu.employeeData[3], Menu.fileName);
        employeeFile.GradeAdded += EmployeeGradeAdded;
        void EmployeeGradeAdded(object sender, EventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition((left / 2) + 27, top + 17);
            Console.CursorVisible = false;
            Console.WriteLine("Dodano nową ocenę!");
            Thread.Sleep(2000);
            MenuFrame.CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition((left / 2) + 27, top + 17);
            Console.CursorVisible = true;

        }
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            var statisticsMemory = employeeMemory.GetStatistics();
            var statisticsFile = employeeFile.GetStatistics();
            if (statisticsMemory.Count == 0 && statisticsFile.Count == 0)
            {
                Console.SetCursorPosition((left / 2) + 27, top + 9);
                Console.Write(0);
                Console.SetCursorPosition((left / 2) + 27, top + 11);
                Console.Write(0);
                Console.SetCursorPosition((left / 2) + 27, top + 13);
                Console.Write(0);
                Console.SetCursorPosition((left / 2) + 27, top + 15);
                Console.Write("F");
            }
            else
            {
                switch (c)
                {
                    case 'm':
                        {
                            MenuFrame.CleanWindow((left / 2) + 27, top + 9, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 9);
                            Console.Write(statisticsMemory.Max);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 11, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 11);
                            Console.Write("{0:0.00}", statisticsMemory.Average);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 13, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 13);
                            Console.Write(statisticsMemory.Min);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 15, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 15);
                            Console.Write(statisticsMemory.AverageLetter);
                            break;
                        }
                    default:
                        {
                            MenuFrame.CleanWindow((left / 2) + 27, top + 9, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 9);
                            Console.Write(statisticsFile.Max);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 11, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 11);
                            Console.Write("{0:0.00}", statisticsFile.Average);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 13, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 13);
                            Console.Write(statisticsFile.Min);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 15, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 15);
                            Console.Write(statisticsFile.AverageLetter);
                            MenuFrame.CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
                            Console.SetCursorPosition((left / 2) + 27, top + 17);
                            break;
                        }
                }

            }
            if (c == 'm') Console.SetCursorPosition(left - 10, top + 17);
            else Console.SetCursorPosition(left - 42, top + 17);
            Console.ForegroundColor = ConsoleColor.Green;
            var line = Console.ReadLine();
            if (line != null) 
            {
                switch (line[0])
                {
                    case 'Q':
                    case 'q':
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            if (c == 'm') Menu.MainMenu(9, 1);
                            else Menu.LoadEmployee('l');
                            break;
                        }
                    default:
                        {
                            try
                            {
                                switch (c)
                                {
                                    case 'm':
                                        {
                                            employeeMemory.AddGrade(line);
                                            break;
                                        }
                                    default:
                                        {
                                            employeeFile.AddGrade(line);
                                            break;
                                        }
                                }
                            }
                            catch (Exception exception)
                            {
                                Console.SetCursorPosition((left / 2) + 27, top + 17);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(exception.Message);
                                Console.CursorVisible = false;
                                Thread.Sleep(2000);
                                Console.SetCursorPosition((left / 2) + 27, top + 17);
                                MenuFrame.CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
                                Console.CursorVisible = true;
                                Console.SetCursorPosition((left / 2) + 27, top + 17);
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            }
                        }
                    break;
                }
            }
            
        }
    }    
}