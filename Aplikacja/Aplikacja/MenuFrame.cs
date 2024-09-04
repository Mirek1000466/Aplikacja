namespace Aplikacja
{
    public static class MenuFrame
    {
        public static void CleanWindow(int x, int y, int width, int height, int foreGroundColor, int backGroundColor) 
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
                if (x < 0) x = 0;
                else if (x > Console.WindowWidth) x = Console.WindowWidth;
                if (i < 0) i = 0;
                else if (i > Console.WindowHeight) i = Console.WindowHeight;
                try
                {
                    Console.SetCursorPosition(x, i);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(50, 24);
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (x < 0 || x > Console.WindowWidth) 
                    {
                        Console.Write("x = " + x + " poza zakresem");
                        if (x < 0) x = 0;
                        else x = Console.WindowWidth;
                    }
                    else if (i < 0 || i > Console.WindowHeight)
                    {
                        Console.Write("i = " + i + " poza zakresem");
                        if (i < 0) i = 0;
                        else i = Console.WindowHeight;
                    }
                    Thread.Sleep(500);
                }
                Console.Write(line);
            }
            Console.ForegroundColor = (ConsoleColor)currentForegroundColor;
            Console.BackgroundColor = (ConsoleColor)currentBackgroundColor;

        }
        public static void UnmarkRow(int x, int y, string line, int foreGroundColor, int backGroundColor)
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
        public static void MarkRow(int x, int y, string line, int foreGroundColor, int backGroundColor)
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
        public static void SplashScreen(int positionY, int waitingTime, int wait) 
        {
            string[] lineSplashScreen = { "Program do oceny pracowników. Skala ocen [50..0] lub A=50, B=40, C=30, D=20, E=10 i F=0.",
                                  "Oceny można dodawać w pamięci (nie będą przechowywane) lub",
                                  "w pliku (możliwy dostęp do ocen w dowolnej chwili)."};
            var maxLengthLine = Math.Max(lineSplashScreen[0].Length, lineSplashScreen[1].Length);
            maxLengthLine = Math.Max(maxLengthLine, lineSplashScreen[2].Length);
            Console.CursorVisible = false;
            var positionX = ((Console.BufferWidth - maxLengthLine + 4) / 2) - 4;
            Frame(positionX, positionY, maxLengthLine + 4, 5, 1, 0);
            for (int j = 0; j < lineSplashScreen.Length; j++)
            {
                Console.SetCursorPosition(positionX + 2, positionY + 1 + j);
                if (lineSplashScreen[j].Length == maxLengthLine)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    for (int i = 0; i < lineSplashScreen[j].Length; i++)
                    {
                        Console.Write(lineSplashScreen[j][i]);
                        Thread.Sleep(waitingTime);
                    }
                }
                else
                {
                    Console.SetCursorPosition(Console.CursorLeft + ((maxLengthLine - lineSplashScreen[j].Length) / 2), positionY + 1 + j);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    for (int i = 0; i < lineSplashScreen[j].Length; i++)
                    {
                        Console.Write(lineSplashScreen[j][i]);
                        Thread.Sleep(waitingTime);
                    }
                }
            }
            Thread.Sleep(wait);
        }
        public static void Frame(int left, int top, int with, int hight, int foreGroundColor, int backGroundColor) 
        {
            // 0-Black 1-DarkBlue 2-DarkGreen 3-DarkCyan 4-DarkRed 5-DarkMagenta 6-DarkYellow
            // 7-Gray 8-DarkGray 9-Blue 10-Green 11-Cyan 12-Red 13-Magenta 14-Yellow 15-White
            ConsoleColor currentForegroundColor = Console.ForegroundColor;
            ConsoleColor currentBackgroundColor = Console.BackgroundColor;
            Console.ForegroundColor = (ConsoleColor)foreGroundColor;
            Console.BackgroundColor = (ConsoleColor)backGroundColor;
            Console.SetCursorPosition(left, top);
            Console.Write('╔');
            Console.SetCursorPosition(left, top);
            Console.Write('╔');
            for (int i = 0; i < with - 2; i++) Console.Write('═');
            Console.Write('╗');
            int j = 1;
            for (j = 1; j < hight - 1; j++)
            {
                Console.SetCursorPosition(left, top + j);
                Console.Write('║');
                for (int k = 0; k < with - 2; k++)
                {
                    Console.Write(" ");
                }
                Console.Write('║');
            }
            Console.SetCursorPosition(left, top + j);
            Console.Write('╚');
            for (int i = 0; i < with - 2; i++) Console.Write('═');
            Console.Write('╝');
        }
        public static void MainFrame(int y, string line1, string line2)
        {
            var x = ((Console.BufferWidth - Math.Max(line1.Length, line2.Length)) / 2) - 3;
            var h = 3;
            if (line2.Length > 0) h = 4;
            Frame(x, y, Math.Max(line1.Length, line2.Length) + 4, h, 1, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(x + 2, y + 1);
            if (line2.Length == 0) Console.Write(line1);
            else
            {
                var j = (line1.Length - line2.Length) / 2;
                if (j >= 0)
                {
                    while (j > 0)
                    {
                        line2 = ' ' + line2;
                        j--;
                    }
                }
                else
                {
                    while (j > 0)
                    {
                        line1 = ' ' + line1;
                        j--;
                    }
                }
                Console.Write(line1);
                Console.SetCursorPosition(x + 2, y + 2);
                Console.Write(line2);
            }
        }
        public static void NavigationFrame(int y, string line1, string line2, string line3)
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
                CleanWindow(0, y, 110, 5, 0, 0);
                var dy = -1 + counter;
                Frame(x, y - dy, length + 4, counter + 4, 4, 0);
                if (counter == 2)
                {
                    Console.SetCursorPosition(x + 2, y - 1);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" NAWIGACJA ");
                    Console.SetCursorPosition(x + 2, y + 1);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(line1);
                    Console.SetCursorPosition(x + 2, y + 2);
                    Console.Write(line2);
                }
                else
                {
                    Console.SetCursorPosition(x + 2, y);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" NAWIGACJA ");
                    Console.SetCursorPosition(x + 2, y + 2);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(line1);
                }
            }

        }
        public static void RatingsPanel(int left, int top, char c)
        {
            if (c == 'f')
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
        }
    }
}
