namespace Aplikacja
{
    public static class Menu
    {
        public static string[] employeeData = new string[4];
        public static string fileName = "";
        public static List<string> employeeList = new List<string>();
        public static void MemoryEmployee(int left, int top)
        {
            Console.Clear();
            MenuFrame.MainFrame(1, "DANE NOWEGO PRACOWNIKA", "");
            MenuFrame.NavigationFrame(25, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "       Tab - zatwierdź dane pracownika. ", "");
            for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
            Utils.EmployeeData(left, top, 'm');
            var counter = 0;
            foreach (var item in Menu.employeeData)
            {
                Console.SetCursorPosition(left + 11, top + (counter * 2));
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(item);
                counter++;
            }
            MenuFrame.CleanWindow(35, 24, 75, 6, 0, 0);
            MenuFrame.NavigationFrame(26, " Można dodać ocenę z przedziału [0..50] ", "    lub [A..F].  Znak Q / q wyjście. ", "");
            Utils.EmployeeAddGrade(73, top, 'm');
            MainMenu(9, 1);
        }
        public static void FileEmployee(int position)
        {
            var x = 45;
            var y = 9;
            Console.Clear();
            switch (position)
            {
                case 1:
                    {
                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
                    }
                    break;
                case 2:
                    {
                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                    }
                    break;
                case 3:
                    {
                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                    }
                    break;

            }
            MenuFrame.NavigationFrame(23, "[1..4] lub ↑/↓ - wybór Enter - potwierdzenie ESC - wyjście", "", "");
            Console.CursorVisible = false;
            string[] menu = [" 1 - NOWY PRACOWNIK     ", " 2 - WCZYTAJ PRACOWNIKA ", " 3 - KASUJ PRACOWNIKA   ", " 4 - WYJŚCIE            "];
            MenuFrame.Frame(x, y, 28, 11, 6, 0);
            for (int i = 0; i < 4; i++) MenuFrame.UnmarkRow(x, y + (i + 1) * 2, menu[i], 10, 0);
            MenuFrame.MarkRow(x, y + position * 2, menu[position - 1], 15, 1);
            var requirement = true;
            while (requirement)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (position == 1)
                            {
                                MenuFrame.UnmarkRow(x, y + position * 2, menu[position - 1], 10, 0);
                                position = 4;
                                MenuFrame.MarkRow(x, y + position * 2, menu[position - 1], 15, 1);
                            }
                            else
                            {
                                MenuFrame.UnmarkRow(x, y + position * 2, menu[position - 1], 10, 0);
                                position--;
                                MenuFrame.MarkRow(x, y + position * 2, menu[position - 1], 15, 1);
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (position == 4)
                            {
                                MenuFrame.UnmarkRow(x, y + position * 2, menu[position - 1], 10, 0);
                                position = 1;
                                MenuFrame.MarkRow(x, y + position * 2, menu[position - 1], 15, 1);
                            }
                            else
                            {
                                MenuFrame.UnmarkRow(x, y + position * 2, menu[position - 1], 10, 0);
                                position++;
                                MenuFrame.MarkRow(x, y + position * 2, menu[position - 1], 15, 1);
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            switch (position)
                            {
                                case 1:
                                    {
                                        Console.Clear();
                                        MenuFrame.MainFrame(1, "DANE NOWEGO PRACOWNIKA", "");
                                        MenuFrame.NavigationFrame(25, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "          Tab - zapisz dane do pliku. ", "");
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        Utils.EmployeeData(45, 10, 'f');
                                        break;
                                    }
                                case 2:
                                    {
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        LoadEmployee('l');
                                        break;
                                    }
                                case 3:
                                    {
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        LoadEmployee('k');
                                        break;
                                    }
                                default:
                                    {
                                        MainMenu(9, 2);
                                        break;
                                    }
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            MainMenu(9, 2);
                            break;
                        }
                    default:
                        {
                            switch (key.KeyChar)
                            {
                                case '1':
                                    {
                                        Console.Clear();
                                        MenuFrame.MainFrame(3, "DANE NOWEGO PRACOWNIKA", "");
                                        MenuFrame.NavigationFrame(23, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "          Tab - zapisz dane do pliku. ", "");
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        Utils.EmployeeData(45, 10, 'f');
                                        break;
                                    }
                                case '2':
                                    {
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        LoadEmployee('l');
                                        break;
                                    }
                                case '3':
                                    {
                                        for (int i = 0; i < Menu.employeeData.Length; i++) Menu.employeeData[i] = null;
                                        LoadEmployee('k');
                                        break;
                                    }
                                default:
                                    {
                                        MainMenu(9, 2);
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }
        public static void LoadEmployee(char c)
        {
            if (!Directory.Exists("DANE PRACOWNIKÓW"))
            {
                MenuFrame.CleanWindow(45, 8, 30, 15, 0, 0);
                MenuFrame.Frame(50, 12, 19, 5, 13, 0);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(54, 12);
                Console.Write(" U W A G A ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(53, 14);
                Console.Write("BRAK DANYCH !");
                Thread.Sleep(3000);
                Menu.FileEmployee(2);
            }
            else
            {
                string[] txtFiles = Directory.GetFiles("DANE PRACOWNIKÓW/", "*.txt");
                if (txtFiles.Length == 0)
                {
                    MenuFrame.CleanWindow(45, 8, 30, 15, 0, 0);
                    MenuFrame.Frame(50, 12, 19, 5, 13, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(54, 12);
                    Console.Write(" U W A G A ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(53, 14);
                    Console.Write("BRAK DANYCH !");
                    Thread.Sleep(3000);
                    Menu.FileEmployee(2);
                }
                else
                {
                    Console.Clear();
                    if (c == 'l')
                    {
                        MenuFrame.MainFrame(2, "Odczyt pliku z danymi pracownika", "");
                        MenuFrame.NavigationFrame(24, "↑/↓ - wybór pracownika. Enter - wczytaj. ESC - wyjście", "", "");
                    }
                    else
                    {
                        MenuFrame.MainFrame(1, "Kasowanie pliku z danymi pracownika", "");
                        MenuFrame.NavigationFrame(24, "↑/↓ - wybór pracownika. Del - kasowanie. ESC - wyjście", "", "");
                    }
                    employeeList.Clear();
                    for (int i = 0; i < txtFiles.Length; i++)
                    {
                        string file = txtFiles[i];
                        file = file.Remove(0, file.IndexOf('/') + 1);
                        file = file.Replace(".TXT", "");
                        file = file.Replace(".txt", "");
                        employeeList.Add(file);
                    }
                    var x = 0;
                    var y = 0;
                    if (c == 'l')
                    {
                        x = 3;
                        y = 6;
                    }
                    else
                    {
                        x = 45;
                        y = 6;
                    }
                    Console.SetCursorPosition(x + 4, y - 1);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(" LISTA PRACOWNIKÓW ");
                    MenuFrame.Frame(x, y, 27, 17, 15, 0);
                    for (int j = 0; j < employeeList.Count; j++)
                    {
                        var buffor = employeeList[j];
                        while (buffor.Length < 25 - 1)
                        {
                            buffor += " ";
                        }
                        employeeList[j] = buffor;
                    }
                    for (int i = 0; i < employeeList.Count && i < 15; i++) MenuFrame.UnmarkRow(x - 1, y + 1 + i, " " + employeeList[i], 10, 0);
                    MenuFrame.MarkRow(x - 1, y + 1, " " + employeeList[0], 15, 1);
                    var positionInFrame = 1;
                    var positionInList = 0;
                    while (true)
                    {
                        if (employeeList.Count > 0)
                        {
                            Console.CursorVisible = false;
                            ConsoleKeyInfo key = Console.ReadKey();
                            switch (key.Key)
                            {
                                case ConsoleKey.Escape:
                                    {
                                        if (c == 'k') Menu.FileEmployee(3);
                                        else Menu.FileEmployee(2);
                                        break;
                                    }
                                case ConsoleKey.DownArrow:
                                    {
                                        MenuFrame.UnmarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 10, 0);
                                        if (positionInFrame < 15)
                                        {
                                            if (positionInList < employeeList.Count)
                                            {
                                                if (positionInList + 1 < employeeList.Count) positionInList++;
                                                if (positionInFrame < employeeList.Count) positionInFrame++;
                                            }
                                            MenuFrame.MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                        }
                                        else
                                        {
                                            if (positionInList < employeeList.Count - 1)
                                            {
                                                MenuFrame.CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                                positionInList++;
                                                for (int i = 1; i <= employeeList.Count && i <= 15; i++)
                                                    MenuFrame.UnmarkRow(x - 1, y + i, " " + employeeList[i + positionInList - positionInFrame], 10, 0);
                                            }
                                            MenuFrame.MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                        }
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        MenuFrame.UnmarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 10, 0);
                                        if (positionInFrame > 1)
                                        {
                                            positionInList--;
                                            positionInFrame--;
                                        }
                                        else
                                        {
                                            if (positionInList > positionInFrame || positionInList > 0)
                                            {
                                                MenuFrame.CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                                positionInList--;
                                                for (int i = 1; (i + positionInList - positionInFrame) <= employeeList.Count - 1 && i <= 15; i++)
                                                    MenuFrame.UnmarkRow(x - 1, y + i, " " + employeeList[i + positionInList - positionInFrame], 10, 0);
                                            }
                                        }
                                        MenuFrame.MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);

                                        break;
                                    }
                                case ConsoleKey.Delete:
                                    {
                                        if (c == 'k')
                                        {
                                            File.Delete(txtFiles[positionInList]);
                                            string[] newBoard = new string[txtFiles.Length - 1]; // Tworzę nową tablicę o rozmiarze mniejszym o jeden
                                            Array.Copy(txtFiles, 0, newBoard, 0, positionInList); // Kopiuję elementy przed elementem który chcę usunąć
                                            Array.Copy(txtFiles, positionInList + 1, newBoard, positionInList, txtFiles.Length - positionInList - 1); // Kopiuję elementy po elemencie który chcę usunąć
                                            txtFiles = newBoard; // Aktualizujemy referencję tablicy

                                            employeeList.Remove(employeeList[positionInList]);
                                            MenuFrame.CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                            if (positionInList <= 14)
                                            {
                                                if (employeeList.Count > 15)
                                                {
                                                    int j = 0;
                                                    for (int i = positionInList - positionInFrame + 1; i < employeeList.Count && i < employeeList.Count && j < 15; i++)
                                                    {
                                                        MenuFrame.UnmarkRow(x - 1, y + 1 + j, " " + employeeList[i], 10, 0);
                                                        j++;
                                                    }
                                                    if (positionInList == employeeList.Count)
                                                    {
                                                        positionInList--;
                                                        if (positionInList == employeeList.Count - 1) positionInFrame = positionInList + 1;
                                                        else positionInFrame--;
                                                    }
                                                    MenuFrame.MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < employeeList.Count; i++) MenuFrame.UnmarkRow(x - 1, y + 1 + i, " " + employeeList[i], 10, 0);
                                                    if (positionInList == employeeList.Count) positionInList--;
                                                    positionInFrame = positionInList + 1;
                                                    if (positionInFrame > 0) MenuFrame.MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                                }
                                            }
                                            else
                                            {
                                                int j = 0;
                                                int k = 0;
                                                string buffer = "";
                                                for (int i = positionInList - positionInFrame + 1; i < employeeList.Count && j < 16; i++)
                                                {
                                                    j++;
                                                    buffer = employeeList[i].ToString();
                                                    MenuFrame.UnmarkRow(x - 1, y + j, " " + buffer, 10, 0);
                                                    k = i;
                                                }
                                                MenuFrame.MarkRow(x - 1, y + j, " " + buffer, 15, 1);
                                                if (positionInList + 1 > employeeList.Count) positionInFrame--;
                                                positionInList = k;

                                            }
                                        }
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        if (c == 'l')
                                        {
                                            Menu.fileName = txtFiles[positionInList];
                                            using (StreamReader reader = new StreamReader(Menu.fileName))
                                            {
                                                int lineNumber = 0;
                                                while (lineNumber < 4)
                                                {
                                                    Menu.employeeData[lineNumber] = reader.ReadLine();
                                                    lineNumber++;
                                                }
                                            }
                                            x = 32;
                                            y = 9;
                                            Console.CursorVisible = true;
                                            Console.SetCursorPosition(x + 9, y - 1);
                                            Console.WriteLine(" DANE PRACOWNIKA ");
                                            MenuFrame.Frame(x, y, 35, 6, 3, 0);
                                            Console.SetCursorPosition(x + 12, y + 1);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("IMIĘ : ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(Menu.employeeData[0]);
                                            Console.SetCursorPosition(x + 8, y + 2);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("NAZWISKO : ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(Menu.employeeData[1]);
                                            Console.SetCursorPosition(x + 2, y + 3);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("DATA URODZENIA : ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(Menu.employeeData[2]);
                                            Console.SetCursorPosition(x + 12, y + 4);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.Write("PŁEĆ : ");
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write(Menu.employeeData[3]);
                                            MenuFrame.CleanWindow(30, 23, 130, 6, 0, 0);
                                            MenuFrame.NavigationFrame(23, " Można dodać ocenę z przedziału [0..50] ", "    lub [A..F].  Znak Q / q wyjście. ", "");
                                            Utils.EmployeeAddGrade(138, 1, 'f');
                                        }
                                        break;
                                    }
                            }
                        }
                        else break;

                    }
                }
            }

        }
        public static void MainMenu(int y, int poz)
        {
            Console.Clear();
            switch (poz)
            {
                case 1:
                    {
                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
                    }
                    break;
                case 2:
                    {
                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                    }
                    break;
            }
            MenuFrame.NavigationFrame(21, "[1..3] lub ↑/↓ - wybór i Enter - potwierdzenie. ESC - wyjście.", "", "");
            Console.CursorVisible = false;
            var x = 46;
            MenuFrame.Frame(x, y, 28, 9, 13, 0);
            string[] menu = [" 1 - OPERCJE NA PAMIĘCI ", " 2 - OPERCJE NA PLIKU   ", " 3 - WYJŚCIE            "];
            for (int i = 0; i < 3; i++) MenuFrame.UnmarkRow(x, y + (i + 1) * 2, menu[i], 10, 0);
            MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
            var requirement = true;
            while (requirement)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            switch (poz)
                            {
                                case 1:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz = 3;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "WYJŚCIE");
                                    }
                                    break;
                                case 2:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz--;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
                                    }
                                    break;
                                case 3:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz--;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                                    }
                                    break;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            switch (poz)
                            {
                                case 1:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz++;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                                    }
                                    break;
                                case 2:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz++;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "WYJŚCIE");
                                    }
                                    break;
                                case 3:
                                    {
                                        MenuFrame.UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                                        poz = 1;
                                        MenuFrame.MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
                                    }
                                    break;
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            switch (poz)
                            {
                                case 1:
                                    {
                                        Menu.MemoryEmployee(45, 5);
                                        break;
                                    }
                                case 2:
                                    {
                                        Menu.FileEmployee(1);
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Environment.Exit(0);
                                        break;
                                    }
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            switch (key.KeyChar)
                            {
                                case '1':
                                    {
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
                                        Menu.MemoryEmployee(45, 5);
                                        break;
                                    }
                                case '2':
                                    {
                                        MenuFrame.MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKU");
                                        Menu.FileEmployee(2);
                                        break;
                                    }
                                case '3':
                                    {
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Environment.Exit(0);
                                        break;
                                    }
                                default:
                                    {
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        Console.Write(" ");
                                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                        break;
                                    }
                            }
                            break;
                        }
                }

            }
        }

    }
}
