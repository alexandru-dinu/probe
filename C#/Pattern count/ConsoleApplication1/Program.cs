using System;

namespace ConsoleApplication1
{
    static class Program
    {
        static void Main()
        {
            var mat = new long[100,100];

            Console.Write("Enter the size of the square: ");
            var size = Convert.ToInt32(Console.ReadLine());

            if(size <= 0)
                Console.WriteLine("No possible way this path can be completed.");
            else if(size == 1)
                Console.WriteLine("You didn't move at all.");
            else
            {
                mat[0, 0] = 0; //starting point

                for (var i = 1; i < size; i++)
                {
                    for (var j = 1; j < size; j++)
                    {
                        mat[0, j] = 1;
                        mat[i, 0] = 1;
                        mat[i, j] = mat[i - 1, j] + mat[i, j - 1];
                    }
                }

                for (var i = 0; i < size; i++)
                {
                    for (var j = 0; j < size; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Convert.ToString(mat[i, j]) + " ");
                            Console.ResetColor();
                        }
                        else if (i == size - 1 && j == size - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Convert.ToString(mat[i, j]) + " ");
                        }
                        else
                            Console.Write(Convert.ToString(mat[i, j]) + " ");
                    }
                    Console.WriteLine();
                }
            }
            
            Console.Read();
        }
    }
}
