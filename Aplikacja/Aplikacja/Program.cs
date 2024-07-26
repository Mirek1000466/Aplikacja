using Aplikacja;
using System;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

string[] employeeData = new string[4];
var fileName = "";
List<string> employeeList = new List<string>();
void SplashScreen(int pozycjaY, int zwloka, int czekaj)
{
    string[] lineSplashScreen = { "Program do oceny pracowników. Skala ocen [50..0] lub A=50, B=40, C=30, D=20, E=10 i F=0.",
                                  "Oceny można dodawać w pamięci (nie będą przechowywane) lub",
                                  "w pliku (możliwy dostęp do ocen w dowolnej chwili)."};
    var maxLengthLine = Math.Max(lineSplashScreen[0].Length, lineSplashScreen[1].Length);
    maxLengthLine = Math.Max(maxLengthLine, lineSplashScreen[2].Length);
    Console.CursorVisible = false;
    var pozycjaX = ((Console.BufferWidth - maxLengthLine + 4) / 2) - 4;
    Console.SetCursorPosition(pozycjaX, pozycjaY);
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write("╔");
    for (int i = 0; i < maxLengthLine + 2; i++) Console.Write("═");
    Console.Write("╗");
    for (int i = 0; i < 3; i++)
    {
        Console.SetCursorPosition(pozycjaX, pozycjaY + i + 1);
        Console.Write("║");
        Console.SetCursorPosition(pozycjaX + maxLengthLine + 3, pozycjaY + i + 1);
        Console.Write("║");
    }
    Console.SetCursorPosition(pozycjaX, pozycjaY + 4);
    Console.Write("╚");
    for (int i = 0; i < maxLengthLine + 2; i++) Console.Write("═");
    Console.Write("╝");
    for (int j = 0; j < lineSplashScreen.Length; j++)
    {
        Console.SetCursorPosition(pozycjaX + 2, pozycjaY + 1 + j);
        if (lineSplashScreen[j].Length == maxLengthLine)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < lineSplashScreen[j].Length; i++)
            {
                Console.Write(lineSplashScreen[j][i]);
                Thread.Sleep(zwloka);
            }
        }
        else
        {
            Console.SetCursorPosition(Console.CursorLeft + ((maxLengthLine - lineSplashScreen[j].Length) / 2), pozycjaY + 1 + j);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < lineSplashScreen[j].Length; i++)
            {
                Console.Write(lineSplashScreen[j][i]);
                Thread.Sleep(zwloka);
            }
        }
    }
    Thread.Sleep(czekaj);
}
void MainFrame(int y, string line1, string line2)
{
    var x = ((Console.BufferWidth - Math.Max(line1.Length, line2.Length)) / 2) - 3;
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.Write("╔");
    Console.SetCursorPosition(x, y);
    Console.Write("╔");
    for (var i = 0; i <= Math.Max(line1.Length, line2.Length) + 1; i++)
    {
        Console.Write("═");
    }
    Console.Write("╗");
    var j = 1;
    Console.SetCursorPosition(x, y + j);
    Console.Write("║");
    Console.ForegroundColor = ConsoleColor.Cyan;
    if (line2.Length == 0)
    {
        Console.Write(" " + line1 + " ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("║");
    }
    else
    {
        if (line1.Length >= line2.Length)
        {
            Console.Write(" " + line1 + " ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            int pozycjaX = Console.CursorLeft;
            Console.Write("║");
            j++;
            Console.SetCursorPosition(x, y + j);
            Console.Write("║");
            for (var i = 0; i <= (line1.Length - line2.Length) / 2 + 1; i++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(line2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(pozycjaX, y + j);
            Console.Write("║");
        }
    }
    j++;
    Console.SetCursorPosition(x, y + j);
    Console.Write("╚");
    for (var i = 0; i <= Math.Max(line1.Length, line2.Length) + 1; i++)
    {
        Console.Write("═");
    }
    Console.Write("╝");
}
void CleanWindow(int x, int y, int width, int height, int foreGroundColor, int backGroundColor)
{
    // 0-Black 1-DarkBlue 2-DarkGreen 3-DarkCyan 4-DarkRed 5-DarkMagenta 6-DarkYellow
    // 7-Gray 8-DarkGray 9-Blue 10-Green 11-Cyan 12-Red 13-Magenta 14-Yellow 15-White
    ConsoleColor currentForegroundColor = Console.ForegroundColor;
    ConsoleColor currentBackgroundColor = Console.BackgroundColor;
    Console.ForegroundColor = (ConsoleColor)foreGroundColor;
    Console.BackgroundColor = (ConsoleColor)backGroundColor;
    string line = "";
    for (int i = 1; i <= width; i++)
    {
        line += " ";
    }
    for (int i = y; i < y + height; i++)
    {
        Console.SetCursorPosition(x, i);
        Console.Write(line);
    }
    Console.ForegroundColor = (ConsoleColor)currentForegroundColor;
    Console.BackgroundColor = (ConsoleColor)currentBackgroundColor;
}
void NavigationFrame(int y, string line1, string line2, string line3)
{
    var length = 0;
    length = Math.Max(length, line1.Length);
    length = Math.Max(length, line2.Length);
    length = Math.Max(length, line3.Length);
    if (length != 0)
    {
        var counter = 0;
        if (line1.Length > 0) counter++;
        if (line2.Length > 0) counter++;
        if (line3.Length > 0) counter++;
        var x = (116 - length) / 2;
        var itemy = y;
        CleanWindow(0, y, 110, 5, 0, 0);
        Console.SetCursorPosition(x, itemy);
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("╔");
        for (int i = 1; i <= length + 2; i++) Console.Write("═");
        Console.WriteLine("╗");
        Console.SetCursorPosition(x, itemy += 1);
        Console.Write("║");
        Console.SetCursorPosition(x + length + 3, itemy);
        Console.WriteLine("║");
        for (int i = 1; i <= counter * 2 - 1; i++)
        {
            Console.SetCursorPosition(x, itemy += 1);
            Console.Write("║");
            Console.SetCursorPosition(x + length + 3, itemy);
            Console.WriteLine("║");
        }
        if(counter == 1) 
        {
            Console.SetCursorPosition(x, itemy += 1);
            Console.Write("║");
            Console.SetCursorPosition(x + length + 3, itemy);
            Console.WriteLine("║");
        }
        Console.SetCursorPosition(x, itemy += 1);
        Console.Write("╚");
        for (int i = 1; i <= length + 2; i++) Console.Write("═");
        Console.Write("╝");
        Console.SetCursorPosition(x + 2, y);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAWIGACJA ");
        Console.SetCursorPosition(x + 2, y + 2);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(line1);
        if (line2 != "")
        {
            Console.SetCursorPosition(x + 2, y + 3);
            Console.Write(line2);
        }
    }

}
void UnmarkRow(int x, int y, string line, int foreGroundColor, int backGroundColor)
{
    ConsoleColor currentForegroundColor = Console.ForegroundColor;
    ConsoleColor currentBackgroundColor = Console.BackgroundColor;
    Console.ForegroundColor = (ConsoleColor)foreGroundColor;
    Console.BackgroundColor = (ConsoleColor)backGroundColor;
    for (int i = 0; i < line.Length; i++)
    {
        Console.SetCursorPosition(x + i + 2, y);
        Console.Write(" ");
    }
    Console.SetCursorPosition(x + 2, y);
    Console.Write(line);
    Console.SetCursorPosition(x + 2, y);
    Console.ForegroundColor = (ConsoleColor)currentForegroundColor;
    Console.BackgroundColor = (ConsoleColor)currentBackgroundColor;
}
void MarkRow(int x, int y, string line, int foreGroundColor, int backGroundColor)
{
    ConsoleColor currentForegroundColor = Console.ForegroundColor;
    ConsoleColor currentBackgroundColor = Console.BackgroundColor;
    Console.ForegroundColor = (ConsoleColor)foreGroundColor;
    Console.BackgroundColor = (ConsoleColor)backGroundColor;
    for (int i = 0; i < line.Length; i++)
    {
        Console.SetCursorPosition(x + i + 2, y);
        Console.Write(" ");
    }
    Console.SetCursorPosition(x + 2, y);
    Console.Write(line);
    Console.ForegroundColor = (ConsoleColor)currentForegroundColor;
    Console.BackgroundColor = (ConsoleColor)currentBackgroundColor;
}
void EmployeeAddGrade(int left, int top, char c) 
{
    if(c == 'f') 
    {
        Console.SetCursorPosition((left / 2) + 19, top + 7);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("PANEL OCEN");
    }
    Console.SetCursorPosition(left / 2, top + 8);
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("╔══════════════════════════════════════════════╗");
    Console.SetCursorPosition(left / 2, top + 9);
    Console.WriteLine("║       Ocena Maksymalna :                     ║");
    Console.SetCursorPosition(left / 2, top + 10);
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.SetCursorPosition(left / 2, top + 11);
    Console.WriteLine("║       Ocena Średnia    :                     ║");
    Console.SetCursorPosition(left / 2, top + 12);
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.SetCursorPosition(left / 2, top + 13);
    Console.WriteLine("║       Ocena Minimalna  :                     ║");
    Console.SetCursorPosition(left / 2, top + 14);
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.SetCursorPosition(left / 2, top + 15);
    Console.WriteLine("║       Ocena Końcowa    :                     ║");
    Console.SetCursorPosition(left / 2, top + 16);
    Console.WriteLine("╠══════════════════════════════════════════════╣");
    Console.SetCursorPosition(left / 2, top + 17);
    Console.WriteLine("║ Podaj ocenę pracownika :                     ║");
    Console.SetCursorPosition(left / 2, top + 18);
    Console.WriteLine("╚══════════════════════════════════════════════╝");
    var employeeMemory = new EmployeeMemory(employeeData[0], employeeData[1], employeeData[2], employeeData[3]);
    employeeMemory.GradeAdded += EmployeeGradeAdded;
    var employeeFile = new EmployeeFile(employeeData[0], employeeData[1], employeeData[2], employeeData[3], fileName);
    employeeFile.GradeAdded += EmployeeGradeAdded;
    void EmployeeGradeAdded(object sender, EventArgs args)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition((left / 2) + 27, top + 17);
        Console.CursorVisible = false;
        Console.WriteLine("Dodano nową ocenę!");
        Thread.Sleep(2000);
        CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition((left / 2) + 27, top + 17);
        Console.CursorVisible = true;

    }
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        var statisticsMemory = employeeMemory.GetStatistics();
        var statisticsFile = employeeFile.GetStatistics();
        if (statisticsMemory.Count == 0 && statisticsFile.Count ==0)
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
                        CleanWindow((left / 2) + 27, top + 9, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 9);
                        Console.Write(statisticsMemory.Max);
                        CleanWindow((left / 2) + 27, top + 11, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 11);
                        Console.Write("{0:0.00}", statisticsMemory.Average);
                        CleanWindow((left / 2) + 27, top + 13, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 13);
                        Console.Write(statisticsMemory.Min);
                        CleanWindow((left / 2) + 27, top + 15, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 15);
                        Console.Write(statisticsMemory.AverageLetter);
                        break; 
                    }
                default:
                    {
                        CleanWindow((left / 2) + 27, top + 9, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 9);
                        Console.Write(statisticsFile.Max);
                        CleanWindow((left / 2) + 27, top + 11, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 11);
                        Console.Write("{0:0.00}", statisticsFile.Average);
                        CleanWindow((left / 2) + 27, top + 13, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 13);
                        Console.Write(statisticsFile.Min);
                        CleanWindow((left / 2) + 27, top + 15, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 15);
                        Console.Write(statisticsFile.AverageLetter);
                        CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
                        Console.SetCursorPosition((left / 2) + 27, top + 17);
                        break; 
                    }
            }
            
        }
        if (c == 'm') Console.SetCursorPosition(left - 10, top + 17);
        else Console.SetCursorPosition(left - 42, top + 17);
        Console.ForegroundColor = ConsoleColor.Green;
        var line = Console.ReadLine();
        switch (line[0])
        {
            case 'Q':
            case 'q':
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    if(c =='m') MainMenu(9, 1);
                    else LoadEmployee('l');
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
                        CleanWindow((left / 2) + 27, top + 17, 20, 1, 0, 0);
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
void LoadEmployee(char c)
{
    if (!Directory.Exists("DANE PRACOWNIKÓW"))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition((Console.BufferWidth - "BRAK DANYCH!".Length) / 2, 13);
        Console.Write("BRAK DANYCH!");
        Thread.Sleep(3000);
        FileEmployee(2);
    }
    else
    {
        string[] txtFiles = Directory.GetFiles("DANE PRACOWNIKÓW/", "*.txt");
        if (txtFiles.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition((Console.BufferWidth - "BRAK DANYCH!".Length) / 2, 13);
            Console.Write("BRAK DANYCH!");
            Thread.Sleep(3000);
            FileEmployee(2);
        }
        else
        {
            Console.Clear();
            if(c == 'l')
            {
                MainFrame(2, "Odczyt pliku z danymi pracownika", "");
                NavigationFrame(24, "↑/↓ - wybór pracownika. Enter - wczytaj. ESC - wyjście", "", "");
            }
            else
            {
                MainFrame(1, "Kasowanie pliku z danymi pracownika", "");
                NavigationFrame(24, "↑/↓ - wybór pracownika. Del - kasowanie. ESC - wyjście", "", "");
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
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("╔");
            for (int i = 0; i < 25; i++) Console.Write("═");
            Console.Write("╗");
            for (int j = 1; j < 16; j++)
            {
                Console.SetCursorPosition(x, y + j);
                Console.Write("║");
                for (int i = 0; i < 25; i++) Console.Write(" ");
                Console.Write("║");
            }
            Console.SetCursorPosition(x, y + 16);
            Console.Write("╚");
            for (int i = 0; i < 25; i++) Console.Write("═");
            Console.Write("╝");
            for (int j = 0; j < employeeList.Count; j++)
            {
                var buffor = employeeList[j];
                while (buffor.Length < 25 - 1)
                {
                    buffor += " ";
                }
                employeeList[j] = buffor;
            }
            for (int i = 0; i < employeeList.Count && i < 15; i++) UnmarkRow(x - 1, y + 1 + i, " " + employeeList[i], 10, 0);
            MarkRow(x - 1, y + 1, " " + employeeList[0], 15, 1);
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
                                if (c == 'k') FileEmployee(3);
                                else FileEmployee(2);
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                UnmarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 10, 0);
                                if (positionInFrame < 15)
                                {
                                    if (positionInList < employeeList.Count)
                                    {
                                        if (positionInList +1 < employeeList.Count) positionInList++;
                                        if (positionInFrame < employeeList.Count) positionInFrame++;
                                    }
                                    MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                }
                                else
                                {
                                    if (positionInList < employeeList.Count - 1)
                                    {
                                        CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                        positionInList++;
                                        for (int i = 1; i <= employeeList.Count && i <= 15; i++)
                                            UnmarkRow(x - 1, y + i, " " + employeeList[i + positionInList - positionInFrame], 10, 0);
                                    }
                                    MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                }
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                UnmarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 10, 0);
                                if (positionInFrame > 1)
                                {
                                    positionInList--;
                                    positionInFrame--;
                                }
                                else
                                {
                                    if (positionInList > positionInFrame || positionInList > 0)
                                    {
                                        CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                        positionInList--;
                                        for (int i = 1; (i + positionInList - positionInFrame) <= employeeList.Count - 1 && i <= 15; i++) UnmarkRow(x - 1, y + i, " " + employeeList[i + positionInList - positionInFrame], 10, 0);

                                    }
                                }
                                MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);

                                break;
                            }
                        case ConsoleKey.Delete:
                            {
                                if (c == 'k')
                                {
                                    string asa = Directory.GetCurrentDirectory();
                                    File.Delete(txtFiles[positionInList]);
                                    string[] nowaTablica = new string[txtFiles.Length - 1]; // Tworzę nową tablicę o rozmiarze mniejszym o jeden
                                    Array.Copy(txtFiles, 0, nowaTablica, 0, positionInList); // Kopiujemy elementy przed elementem który chcemy usunąć
                                    Array.Copy(txtFiles, positionInList + 1, nowaTablica, positionInList, txtFiles.Length - positionInList - 1); // Kopiujemy elementy po elemencie który chcemy usunąć
                                    txtFiles = nowaTablica; // Aktualizujemy referencję tablicy

                                    employeeList.Remove(employeeList[positionInList]);
                                    CleanWindow(x + 1, y + 1, 25, 15, 0, 0);
                                    if (positionInList <= 14) 
                                    {
                                        if (employeeList.Count > 15) 
                                        {
                                            int j = 0;
                                            for (int i = positionInList - positionInFrame + 1; i < employeeList.Count && i < employeeList.Count && j < 15; i++)
                                            {
                                                UnmarkRow(x - 1, y + 1 + j, " " + employeeList[i], 10, 0);
                                                j++;
                                            }
                                            if (positionInList == employeeList.Count)
                                            {
                                                positionInList--;
                                                if (positionInList == employeeList.Count - 1) positionInFrame = positionInList + 1;
                                                else positionInFrame--;
                                            }
                                            MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                        }
                                        else 
                                        {
                                            for (int i = 0; i < employeeList.Count; i++) UnmarkRow(x - 1, y + 1 + i, " " + employeeList[i], 10, 0);
                                            if(positionInList == employeeList.Count) positionInList--;
                                            positionInFrame = positionInList + 1;
                                            if(positionInFrame>0) MarkRow(x - 1, y + positionInFrame, " " + employeeList[positionInList], 15, 1);
                                        }
                                    }
                                    else 
                                    {
                                        int j = 0;
                                        int k = 0;
                                        string buf = "";
                                        for (int i = positionInList - positionInFrame + 1; i < employeeList.Count && j < 16; i++)
                                        {
                                            j++;
                                            buf = employeeList[i].ToString();
                                            UnmarkRow(x - 1, y + j, " " + buf, 10, 0);
                                            k = i;
                                        }
                                        MarkRow(x - 1, y + j, " " + buf, 15, 1);
                                        if(positionInList + 1 > employeeList.Count) positionInFrame--;
                                        positionInList = k;
                                        
                                    }
                                }
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                if (c == 'l')
                                {
                                    fileName = txtFiles[positionInList];
                                    using (StreamReader reader = new StreamReader(fileName))
                                    {
                                        int lineNumber = 0;
                                        while (lineNumber < 4)
                                        {
                                            employeeData[lineNumber] = reader.ReadLine();
                                            lineNumber++;
                                        }
                                    }
                                    x = 32;
                                    y = 9;
                                    Console.CursorVisible = true;
                                    Console.SetCursorPosition(x + 9, y - 1);
                                    Console.WriteLine(" DANE PRACOWNIKA ");
                                    Console.SetCursorPosition(x, y);
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.WriteLine("╔═════════════════════════════════╗");
                                    Console.SetCursorPosition(x, y + 1);
                                    Console.WriteLine("║           IMIĘ :                ║");
                                    Console.SetCursorPosition(x + 19, y + 1);
                                    Console.WriteLine(employeeData[0]);
                                    Console.SetCursorPosition(x, y + 2);
                                    Console.WriteLine("║       NAZWISKO :                ║");
                                    Console.SetCursorPosition(x + 19, y + 2);
                                    Console.WriteLine(employeeData[1]);
                                    Console.SetCursorPosition(x, y + 3);
                                    Console.WriteLine("║ DATA URODZENIA :                ║");
                                    Console.SetCursorPosition(x + 19, y + 3);
                                    Console.WriteLine(employeeData[2]);
                                    Console.SetCursorPosition(x, y + 4);
                                    Console.WriteLine("║           PŁEĆ :                ║");
                                    Console.SetCursorPosition(x + 19, y + 4);
                                    Console.WriteLine(employeeData[3]);
                                    Console.SetCursorPosition(x, y + 5);
                                    Console.WriteLine("╚═════════════════════════════════╝");
                                    CleanWindow(30, 23, 130, 6, 0, 0);
                                    NavigationFrame(23, " Można dodać ocenę z przedziału [0..50] ", "    lub [A..F].  Znak Q / q wyjście. ", "");
                                    EmployeeAddGrade(138, 1, 'f');
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
void FileEmployee(int poz)
{
    var x = 45;
    var y = 9;
    Console.Clear();
    MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PLIKACH");
    NavigationFrame(23, "[1..4] lub ↑/↓ - wybór Enter - potwierdzenie ESC - wyjście", "", "");
    Console.CursorVisible = false;
    string[] menu = [" 1 - NOWY PRACOWNIK     ", " 2 - WCZYTAJ PRACOWNIKA ", " 3 - KASUJ PRACOWNIKA   ", " 4 - WYJŚCIE            "];
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.SetCursorPosition(x, y);
    Console.WriteLine("╔══════════════════════════╗");
    var itemy = y;
    for (int i = 0; i < 9; i++)
    {
        Console.SetCursorPosition(x, itemy += 1);
        Console.WriteLine("║                          ║");
    }
    Console.SetCursorPosition(x, itemy += 1);
    Console.WriteLine("╚══════════════════════════╝");
    for (int i = 0; i < 4; i++) UnmarkRow(x, y + (i + 1) * 2, menu[i], 10, 0);
    MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
    var requirement = true;
    while (requirement)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                {
                    if (poz == 1)
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz = 4;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz--;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.DownArrow:
                {
                    if (poz == 4)
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz = 1;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz++;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.Enter: 
                {
                    switch (poz)
                    {
                        case 1:
                            {
                                Console.Clear();
                                MainFrame(1, "DANE NOWEGO PRACOWNIKA", "");
                                NavigationFrame(25, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "          Tab - zapisz dane do pliku. ", "");
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
                                EmployeeData(45, 10, 'f');
                                break;
                            }
                        case 2:
                            {
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
                                LoadEmployee('l');
                                break;
                            }
                        case 3:
                            {
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
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
                                MainFrame(3, "DANE NOWEGO PRACOWNIKA", "");
                                NavigationFrame(23, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "          Tab - zapisz dane do pliku. ", "");
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
                                EmployeeData(45, 10, 'f');
                                break;
                            }
                        case '2':
                            {
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
                                LoadEmployee('l');
                                break;
                            }
                        case '3':
                            {
                                for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
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
void EmployeeData(int left, int top, char c) 
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
    while(requirement) 
    {
        ConsoleKeyInfo key = Console.ReadKey();
        switch(key.Key) 
        {
            case ConsoleKey.UpArrow:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(left + 11, top + (indicator * 2));
                    Console.Write(employeeData[indicator]);
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
                    Console.Write(employeeData[indicator]);
                    break;
                }
            case ConsoleKey.Enter:
            case ConsoleKey.DownArrow:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(left + 11, top + (indicator * 2));
                    Console.Write(employeeData[indicator]);
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
                    Console.Write(employeeData[indicator]);
                    break;
                }
            case ConsoleKey.Escape:
                {
                    if (c == 'm') MainMenu(9, 1);
                    else FileEmployee(1);
                    break;
                }
            case ConsoleKey.Backspace:
                {
                    if (employeeData[indicator] != null)
                    {
                        if (indicator == 2)
                        {
                            if (employeeData[indicator].Length == 3 || employeeData[indicator].Length == 6) employeeData[indicator] = employeeData[indicator][..(employeeData[indicator].Length - 2)];
                            else employeeData[indicator] = employeeData[indicator][..(employeeData[indicator].Length - 1)];
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.Write("DD-MM-RRRR");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.Write(employeeData[indicator]);
                        }
                        else
                        {
                            if (indicator == 3)
                            {
                                if (!string.IsNullOrEmpty(employeeData[indicator]))
                                {
                                    if (employeeData[indicator] == "MĘŻCZYZNA") { employeeData[indicator] = "KOBIETA"; }
                                    else { employeeData[indicator] = "MĘŻCZYZNA"; }
                                }
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(employeeData[indicator]))
                                {
                                    employeeData[indicator] = employeeData[indicator][..(employeeData[indicator].Length - 1)];
                                }
                            }
                            CleanWindow(left + 11, top + (indicator * 2), employeeData[indicator].Length + 2, 1, 0, 0);
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.Write(employeeData[indicator]);
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
                        while(indicator < 4) 
                        {
                            var buffer = "";
                            if (!string.IsNullOrEmpty(employeeData[indicator])) buffer = employeeData[indicator].Replace(" ", "");
                            if (buffer.Length == 0)
                            {
                                employeeData[indicator] = "";
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
                                CleanWindow(left + 11, top + (indicator * 2), 35, 1, 0, 0);
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
                                Console.Write(employeeData[indicator]);
                                Console.CursorVisible = true;
                                condition = false;
                                break;
                            }
                            else
                            {
                                if (indicator == 2)
                                {
                                    if(employeeData[indicator].Length == 10) indicator++;
                                    else 
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                        Console.CursorVisible = false;
                                        Console.Write("NALEŻY DATĘ URODZENIA PRACOWNIKA !");
                                        Thread.Sleep(2000);
                                        CleanWindow(left + 11, top + (indicator * 2), 35, 1, 0, 0);
                                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.Write("DD-MM-RRRR");
                                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write(employeeData[indicator]);
                                        Console.CursorVisible = true;
                                        condition = false;
                                        break;
                                    }
                                }
                                else indicator++;
                            }
                        }
                        if(indicator == 4) condition = false;
                    }
                    if (indicator == 4) requirement = false;
                    break; 
                }
            default:
                {
                    if (indicator == 2)
                    {

                        if (employeeData[indicator] != null && employeeData[indicator].Length == 10)
                        {
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            Console.Write(' ');
                            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        }
                        else
                        {
                            if ((char)key.KeyChar >= '0' && (char)key.KeyChar <= '9')
                            {
                                employeeData[indicator] += key.KeyChar;
                                if (employeeData[indicator].Length == 2 || employeeData[indicator].Length == 5) employeeData[indicator] += '-';
                            }
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("DD-MM-RRRR");
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(employeeData[indicator]);
                        }
                    }
                    else
                    {
                        if (indicator == 3)
                        {
                            if ((char)key.KeyChar == 'M' || (char)key.KeyChar == 'm') { employeeData[indicator] = "MĘŻCZYZNA"; }
                            else
                            {
                                if ((char)key.KeyChar == 'K' || (char)key.KeyChar == 'k') { employeeData[indicator] = "KOBIETA"; }
                                else
                                {
                                        if (string.IsNullOrEmpty(employeeData[indicator]))
                                    {
                                        if (indicator == 3)
                                        {
                                            if ((char)key.KeyChar == 'M' || (char)key.KeyChar == 'm') { employeeData[indicator] = "MĘŻCZYZNA"; }
                                            else
                                            {
                                                if ((char)key.KeyChar == 'K' || (char)key.KeyChar == 'k') { employeeData[indicator] = "KOBIETA"; }
                                                else
                                                {
                                                    if (string.IsNullOrEmpty(employeeData[indicator]))
                                                    {
                                                        Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                                        Console.ForegroundColor = ConsoleColor.DarkGray;
                                                        Console.Write("k / m");
                                                    }
                                                }
                                            }
                                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write(employeeData[indicator]);
                                        }
                                        else
                                        {
                                            employeeData[indicator] += key.KeyChar;
                                        }
                                    }
                                }
                            }
                            Console.SetCursorPosition(left + 11, top + (indicator * 2));
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(employeeData[indicator]);
                        }
                        else
                        {
                            employeeData[indicator] += (char)key.KeyChar;
                        }
                    }
                    break;
                }
        }
    }
    if (c == 'f') 
    {
        if (! Directory.Exists("DANE PRACOWNIKÓW")) Directory.CreateDirectory("DANE PRACOWNIKÓW");
        //Directory.SetCurrentDirectory("DANE PRACOWNIKÓW");
        string nazwaPliku = employeeData[1] + " " + employeeData[0] + ".TXT";
        if (! File.Exists("DANE PRACOWNIKÓW/" + nazwaPliku)) 
        {
            using (StreamWriter sw = new StreamWriter("DANE PRACOWNIKÓW/" + nazwaPliku)) 
            {
                sw.WriteLine(employeeData[0]);
                sw.WriteLine(employeeData[1]);
                sw.WriteLine(employeeData[2]);
                sw.WriteLine(employeeData[3]);
            }
        }
        else 
        {
            var buffer = "Pracownik " + employeeData[0] + " " + employeeData[1] + " już istnieje w bazie danych !";
            Console.SetCursorPosition( (Console.BufferWidth - buffer.Length) / 2, top + 10);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(buffer);
            Thread.Sleep(5000);
        }
        FileEmployee(1);
    }
}
void MemoryEmployee(int left, int top)
{
    Console.Clear();
    MainFrame(1, "DANE NOWEGO PRACOWNIKA", "");
    NavigationFrame(25, " ↑/↓ lub Enter - kolejne dane. ESC - wyjście. ", "       Tab - zatwierdź dane pracownika. ", "");
    for (int i = 0; i < employeeData.Length; i++) employeeData[i] = null;
    EmployeeData(left, top, 'm');
    var counter = 0;
    foreach (var item in employeeData)
    {
        Console.SetCursorPosition(left + 11, top + (counter * 2));
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write(item);
        counter++;
    }
    CleanWindow(35, 25, 75, 6, 0, 0);
    NavigationFrame(25, " Można dodać ocenę z przedziału [0..50] ", "    lub [A..F].  Znak Q / q wyjście. ", "");
    EmployeeAddGrade(73, top, 'm');
    MainMenu(9, 1);
}
void MainMenu(int y, int poz)
{
    Console.Clear();
    MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "OPERACJE NA PAMIĘCI");
    NavigationFrame(21, "[1..3] lub ↑/↓ - wybór i Enter - potwierdzenie. ESC - wyjście.", "", "");
    Console.CursorVisible = false;
    var x = (Console.BufferWidth - "╔══════════════════════════╗".Length) / 2;
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = ConsoleColor.Magenta;
    string[] menu = [" 1 - OPERCJE NA PAMIĘCI ", " 2 - OPERCJE NA PLIKU   ", " 3 - WYJŚCIE            "];
    Console.WriteLine("╔══════════════════════════╗");
    var itemy = y;
    for (int i = 0; i < 7; i++)
    {
        Console.SetCursorPosition(x, itemy += 1);
        Console.WriteLine("║                          ║");
    }
    Console.SetCursorPosition(x, itemy += 1);
    Console.WriteLine("╚══════════════════════════╝");
    for (int i = 0; i < 3; i++) UnmarkRow(x, y + (i + 1) * 2, menu[i], 10, 0);
    MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
    var requirement = true;
    while (requirement)
    {
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                {
                    if (poz == 1)
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz = 3;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz--;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.DownArrow:
                {
                    if (poz == 3)
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz = 1;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz++;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.Enter:
                {
                    switch (poz)
                    {
                        case 1:
                            {
                                MemoryEmployee(45, 5);
                                break;
                            }
                        case 2:
                            {
                                FileEmployee(1);
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
                                MemoryEmployee(45, 5);
                                break;
                            }
                        case '2':
                            {
                                FileEmployee(1);
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
void MenuFrame(int y, int poz)
{
    Console.Clear();
    MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "WERSJA Z ZAPISEM DO PAMIĘCI");
    MainFrame(2, "PROGRAM DO WYSTAWIANIA OCEN PRACOWNIKOM", "WERSJA Z ZAPISEM DO PAMIĘCI");
    NavigationFrame(20, "[1..4] lub ↑/↓ - wybór. Enter - potwierdzenie. ESC - wyjście.", "", "");
    Console.CursorVisible = false;
    var x = (Console.BufferWidth - 28) / 2;
    Console.SetCursorPosition(x, y);
    Console.ForegroundColor = ConsoleColor.Magenta;
    string[] menu = { " 1 - DODAJ PRACOWNKA    ", " 2 - WCZYTAJ PRACOWNIKA ", " 3 - STATYSTYKI       ", " 4 - WYJŚCIE          " };
    Console.WriteLine("╔══════════════════════════╗");
    var itemy = y;
    for (int i = 0; i < 9; i++)
    {
        Console.SetCursorPosition(x, itemy += 1);
        Console.WriteLine("║                          ║");
    }
    Console.SetCursorPosition(x, itemy += 1);
    Console.WriteLine("╚══════════════════════════╝");
    for (int i = 0; i < 4; i++) UnmarkRow(x, y + (i + 1) * 2, menu[i], 10, 0);
    MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
    var tru = true;
    while (tru)
    {
        Console.SetCursorPosition(x + 4, y + poz * 2);
        ConsoleKeyInfo keyPressed = Console.ReadKey();
        switch (keyPressed.Key)
        {
            case ConsoleKey.UpArrow:
                {
                    if (poz == 1)
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz = 4;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + poz * 2, menu[poz - 1], 10, 0);
                        poz--;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.DownArrow:
                {
                    if (poz == 4)
                    {
                        UnmarkRow(x, y + (poz) * 2, menu[poz - 1], 10, 0);
                        poz = 1;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    else
                    {
                        UnmarkRow(x, y + (poz) * 2, menu[poz - 1], 10, 0);
                        poz++;
                        MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                    }
                    break;
                }
            case ConsoleKey.Enter:
                {
                    switch (poz)
                    {
                        case 1:
                            {
                                //                                NoweDane();
                                MenuFrame(7, 1);
                                break;
                            }
                        case 2:
                            {
                                //                                DataReadingFrame(14, 7, 1);
                                MenuFrame(7, 2);
                                break;
                            }
                        case 3:
                            {
                                //                              StatisticsFrame();
                                break;
                            }
                        default:
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
                    Console.CursorVisible = false;
                    switch (keyPressed.KeyChar)
                    {
                        case '1':
                            {
                                UnmarkRow(x, y + (poz) * 2,  menu[poz - 1], 10, 0);
                                poz = 1;
                                MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                Thread.Sleep(300);
                                //                                NoweDane();
                                MenuFrame(7, 1);
                                break;
                            }
                        case '2':
                            {
                                UnmarkRow(x, y + (poz) * 2,  menu[poz - 1], 10, 0);
                                poz = 2;
                                MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                Thread.Sleep(300);
                                //                                DataReadingFrame(14, 7, 1);
                                MenuFrame(7, 2);
                                break;
                            }
                        case '3':
                            {
                                UnmarkRow(x, y + (poz) * 2, menu[poz - 1], 10, 0);
                                poz = 3;
                                MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                Thread.Sleep(300);
                                //                                StatisticsFrame();
                                break;
                            }
                        default:
                            {
                                UnmarkRow(x, y + (poz) * 2, menu[poz - 1], 10, 0);
                                poz = 4;
                                MarkRow(x, y + poz * 2, menu[poz - 1], 15, 1);
                                Thread.Sleep(300);
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Environment.Exit(0);
                                break;
                            }

                    }
                    break;
                }
        }
    }
}
SplashScreen(10,70,1300);
MainMenu(9, 1);
MenuFrame(7, 1);