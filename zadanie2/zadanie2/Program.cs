using System;

namespace zadanie2
{
    class Program
    {
        static int Collatz (int startingPoint)
        {
            int licznik = 1;
            Int64 n = startingPoint;
            while (n != 1)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                }
                else 
                {
                    n = 3*n + 1;
                }
                licznik++;
            }
            return licznik;
        }


        static void Main(string[] args)
        {
            int longestChain = 1;
            int longestStartingNumber = 1;
            for (int i = 1; i < 1000000; i++)
            {
                int result = Collatz(i);
                if (result > longestChain)
                {
                    longestChain = result;
                    longestStartingNumber = i;
                }

            }
            Console.WriteLine("Najdłuższy łańcuch: " + longestChain + " dla liczby " + longestStartingNumber);


        }
    }
}
