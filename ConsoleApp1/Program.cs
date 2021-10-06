using System;

namespace ConsoleApp1
{
    class Program
    {
        static bool isRunning;
        static int maxNumber;

        static void Start()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔══ Chceš si zahrať hru? [y / n] ══╗");
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
            }
        }

        static void Choose()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("═══ Napíš najvyššie číslo ktoré chceš hádať ═══");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();

            while (!int.TryParse(input, out maxNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("══ Toto nieje číslo! ══");
                Console.WriteLine("    Skús to znovu ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }

            while (true)
            {
                if(int.Parse(input) > 2)
                {
                    maxNumber = int.Parse(input);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("══ Číslo musí byť väčšie ako 2! ══");
                Console.WriteLine("    Skús to znovu ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }
            
                
            


        }

        static bool guessed(int num)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("══ Skús napísať číslo na ktoré myslím ══");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();
            int guess;
            while (!int.TryParse(input, out guess))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("══ Toto nieje číslo! ══");
                Console.WriteLine("    Skús to znovu ");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
            }

            if (guess > maxNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine();
                Console.WriteLine("» Číslo je väčšie ako najväčie možné číslo «");
            }
            else if (guess < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine();
                Console.WriteLine("» Číslo musí byť kladné «");
            }
            else if (num > guess)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine();
                Console.WriteLine("» Myslím na väčšie číslo :D «");
            }
            else if (num < guess)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("» Myslím na menšie číslo :D «");
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine();
                        Console.WriteLine("╚══ Číslo si uhádol :) ══╝");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        isRunning = false;

                    }
                }
            }
        }
    }
}

