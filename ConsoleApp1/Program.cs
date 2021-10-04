using System;

namespace ConsoleApp1
{
    class Program
    {
        static bool isRunning;
        static bool guessed(int num)
        {
            Console.WriteLine("Napíš číslo:");
            int guess = Convert.ToInt32(Console.ReadLine());
            if (num > guess)
            {
                Console.WriteLine("Je to viac XD");
            }
            else if (num < guess)
            {
                Console.WriteLine("Je to menej LOL");
            }
            else if (num == guess)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Chceš si zahrať hru? [y / n]");
            string response = Console.ReadLine();

            if (response == "y")
            {
                isRunning = true;
            }
            else if (response == "n")
            {
                isRunning = false;
            }

            if (isRunning)
            {
                System.Random random = new System.Random();
                Console.WriteLine("LOL Hádaj číslo");
                int num = random.Next(100);


                if (guessed(num))
                {
                    Console.WriteLine("Nice");
                }

                while (isRunning)
                {
                    if (guessed(num))
                    {
                        Console.WriteLine("Nice");
                        isRunning = false;

                    }
                }
            }

        }
            
    }
}

