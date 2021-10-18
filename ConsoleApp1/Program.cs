using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static bool isRunning;
        static int maxNumber;
        static int attempts;
        static decimal maxAttempts;

        static void Title()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" _____ _____ _____ _____ _____    _____ _____ _____    _____ _____ _____ _____ _____ _____ ");
            Console.WriteLine("|   __|  |  |   __|   __|   __|  |_   _|  |  |   __|  |   | |  |  |     | __  |   __| __  |");
            Console.WriteLine("|  |  |  |  |   __|__   |__   |    | | |     |   __|  | | | |  |  | | | | __ -|   __|    -|");
            Console.WriteLine("|_____|_____|_____|_____|_____|    |_| |__|__|_____|  |_|___|_____|_|_|_|_____|_____|__|__|");
            Console.WriteLine();
            Console.WriteLine();
        }
        static void StartTitle()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("                               _____ _____ _____ _____ _____ ");
            Console.WriteLine("                              |   __|_   _|  _  | __  |_   _|");
            Console.WriteLine("                              |__   | | | |     |    -| | |  ");
            Console.WriteLine("                              |_____| |_| |__|__|__|__| |_|  ");
            Console.WriteLine();
        }

        static void NopeTitle()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine();
            Console.WriteLine("                                  _____ _____ _____ _____ ");
            Console.WriteLine("                                 |   | |     |  _  |   __|");
            Console.WriteLine("                                 | | | |  |  |   __|   __|");
            Console.WriteLine("                                 |_|___|_____|__|  |_____|");
            Console.WriteLine();
        }

        static void ErrorTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("                               _____ _____ _____ _____ _____ ");
            Console.WriteLine("                              |   __| __  | __  |     | __  |");
            Console.WriteLine("                              |   __|    -|    -|  |  |    -|");
            Console.WriteLine("                              |_____|__|__|__|__|_____|__|__|");
            Console.WriteLine();
        }

        static void WinTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("                           __ __ _____ _____    _ _ _ _____ _____ ");
            Console.WriteLine("                          |  |  |     |  |  |  | | | |     |   | |");
            Console.WriteLine("                          |_   _|  |  |  |  |  | | | |  |  | | | |");
            Console.WriteLine("                            |_| |_____|_____|  |_____|_____|_|___|");
            Console.WriteLine();
        }

        static void LoseTitle()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("                        __ __ _____ _____    __    _____ _____ _____ ");
            Console.WriteLine("                       |  |  |     |  |  |  |  |  |     |   __|   __|");
            Console.WriteLine("                       |_   _|  |  |  |  |  |  |__|  |  |__   |   __|");
            Console.WriteLine("                         |_| |_____|_____|  |_____|_____|_____|_____|");
            Console.WriteLine();
        }

        static void Start()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Title();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═════════════════════════════ Chceš si zahrať hru?  [y / n] ═════════════════════════════╗");
            Console.ForegroundColor = ConsoleColor.White;
            string response = Console.ReadLine();

            if (response == "y")
            {
                isRunning = true;
            }
            else
            {
                isRunning = false;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Tak nie no :(");
                Console.WriteLine();
                End();
            }
        }

        static void Choose()
        {
            StartTitle();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═════════════════════════ Napíš najvyššie číslo ktoré chceš hádať ═════════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();

            while (!int.TryParse(input, out maxNumber))
            {
                ErrorTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("═══════════════════════════════ Zadaná hodnota nieje číslo! ═══════════════════════════════");
                Console.WriteLine("                                      Skús to znovu");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }
            while (true)
            {
                if(int.Parse(input) > 50)
                {
                    maxNumber = int.Parse(input);
                    maxAttempts = Math.Round((decimal)int.Parse(input) / 100 * 8);
                    break;
                }
                ErrorTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("══════════════════════════════ Číslo musí byť väčšie ako 50! ══════════════════════════════");
                Console.WriteLine("                                      Skús to znovu");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }
        }

        static void End()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine();
            Console.WriteLine("...stlač niečo pre ukončenie");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        static bool guessed(int num)
        {
            if(attempts > maxAttempts)
            {
                LoseTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("╚════════════════════════════ Vyčerpal si všetky svoje pokusy ════════════════════════════╝");
                End();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════ Skús napísať číslo na ktoré myslím  ═══════════════════════════");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            int guess;

            while (!int.TryParse(input, out guess))
            {
                ErrorTitle();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("═══════════════════════════════ Zadaná hodnota nieje číslo! ═══════════════════════════════");
                Console.WriteLine("                                      Skús to znovu");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }
            if (guess > maxNumber)
            {
                NopeTitle();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("«======================» Číslo je väčšie ako najväčie možné číslo! «======================»");
                Console.WriteLine();
            }
            else if (guess < 0)
            {
                NopeTitle();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("«============================» Zadané číslo musí byť kladné! «============================»");
                Console.WriteLine();
            }
            else if (num > guess)
            {
                NopeTitle();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("«===============================» Myslím na väčšie číslo! «===============================»");
                Console.WriteLine();
                attempts++;
            }
            else if (num < guess)
            {
                NopeTitle();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("«===============================» Myslím na menšie číslo! «===============================»");
                Console.WriteLine();
                attempts++;
            }
            else if (num == guess)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Start();
            Choose();
    
            if (isRunning)
            {
                System.Random random = new System.Random();
                Console.ForegroundColor = ConsoleColor.Cyan;
                int num = random.Next(maxNumber);

                while (isRunning)
                {
                    if (guessed(num))
                    {
                        WinTitle();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("╚════════════════════════════════════ Číslo si uhádol ════════════════════════════════════╝");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        isRunning = false;
                    }
                }
            }
            End();
        }
    }
}