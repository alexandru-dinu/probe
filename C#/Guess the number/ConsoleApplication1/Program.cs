using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many games do you want to play? ");
            int nrOfGames = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < nrOfGames; i++)
            {
                Random rnd = new Random();
                int nrToGuess = rnd.Next(1000);
                int count = 1;

                Console.Write("Your guess: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                while (guess != nrToGuess)
                {
                    count++;

                    if (guess == nrToGuess)
                    {
                        break;
                    }
                    else if (guess > nrToGuess)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your guess is higher than the number.");
                        Console.ResetColor();
                        Console.Write("Your guess: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (guess < nrToGuess)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Your guess is lower than the number.");
                        Console.ResetColor();
                        Console.Write("Your guess: ");
                        guess = Convert.ToInt32(Console.ReadLine());
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You did it! You've made " + Convert.ToString(count) + " guesses.");
                Console.ResetColor();
                Console.WriteLine("----------");
            }
            Console.Read();
        }
    }
}
