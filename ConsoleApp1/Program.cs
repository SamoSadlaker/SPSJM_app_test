using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Random random = new System.Random();
            Console.WriteLine("LOL Hádaj číslo");
            int num = random.Next(100);
            
           repeat:
            Console.WriteLine("Napíš číslo:");
            int guess = Convert.ToInt32(Console.ReadLine());

            if (num > guess) 
            {
                Console.WriteLine("Je to viac XD");
                goto repeat;
            }
            else if (num < guess)
            {
                Console.WriteLine("Je to menej LOL");
                goto repeat;
            }
            else if (num == guess)
            {
                goto done;               
            }

            done:
            Console.WriteLine("Nice");
        }
            
    }
}

