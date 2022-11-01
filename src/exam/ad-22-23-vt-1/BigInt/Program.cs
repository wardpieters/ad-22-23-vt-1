using System;

namespace AD
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInt b;
            BigInt b1, b2, b3, b4, b5;
            string[] lst;

            // Constructor
            b1 = new BigInt(null);
            b2 = new BigInt("0");
            b3 = new BigInt("1234");
            b4 = new BigInt("1230");
            try
            {
                b5 = new BigInt("2d13");
                System.Console.WriteLine("*ERROR* : This line should not be reached");
            }
            catch (System.Exception e)
            {
                // When we reach this line, it is successful
            }

            System.Console.WriteLine("=== ToString() ===");
            b = new BigInt(null);
            Console.WriteLine($"NULL : \"{b.ToString()}\"");
            lst = new string[] { "", "0", "-123", "1357", "404" };
            foreach (string str in lst)
            {
                b = new BigInt(str);
                Console.WriteLine($"\"{str}\" : \"{b.ToString()}\"");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=== Sum() ===");
            lst = new string[] { "0", "-123", "1357", "404" };
            foreach (string str in lst)
            {
                b = new BigInt(str);
                Console.WriteLine($"Sum({str}) = {b.Sum()}");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=== Increment() ===");
            lst = new string[] { "0", "73", "129", "999" };
            foreach (string str in lst)
            {
                b = new BigInt(str);
                b.Increment();
                Console.WriteLine($"Increment({str}) : {b.ToString()}");
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=== IncrementBetter() ===");
            lst = new string[] { "-1000", "-11", "-10", "-1", "0", "73", "129", "999" };
            foreach (string str in lst)
            {
                b = new BigInt(str);
                b.IncrementBetter();
                Console.WriteLine($"Increment({str}) : {b.ToString()}");
            }
        }
    }
}
