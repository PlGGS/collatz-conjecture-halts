using System;
using System.Collections.Generic;

namespace collatz_conjecture_halts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Run from: ");
            long start = (long)Convert.ToDouble(Console.ReadLine());
            Console.Write("Up to: ");
            long stop = (long)Convert.ToDouble(Console.ReadLine());

            List<string> haltingLoop;
            for (long i = start; i <= stop; i++) {
                haltingLoop = ListTillHalt(RunTillHalt(i));
                
                Console.Write($"{i}: ");
                PrintList(haltingLoop);
            }
        }

        static long A3p1(long prev) {
            if (prev % 2 == 0)
                return prev / 2;
            else
                return prev * 3 + 1;
        }

        static long RunTillHalt(long prev) {
            long curr;

            if (prev > 0) {
                do {
                    curr = A3p1(prev);
                    prev = curr;
                }
                while (curr > 1);
            }
            else {
                do {
                    curr = A3p1(prev);
                    prev = curr;
                }
                while (curr != -17 && curr != -5 && curr < -1);
            }

            return curr;
        }

        static List<string> ListTillHalt(long prev) {
            List<string> loop = new List<string>();
            long curr;

            if (prev > 0) {
                do {
                    curr = A3p1(prev);
                    prev = curr;
                    loop.Add(prev.ToString());
                }
                while (curr > 1);
            }
            else {
                do {
                    curr = A3p1(prev);
                    prev = curr;
                    loop.Add(prev.ToString());
                }
                while (curr != -17 && curr != -5 && curr < -1);
            }

            return loop;
        }

        static void PrintList(List<string> list) {
            Console.Write(list[0]);
            for (int i = 1; i < list.Count; i++)
                Console.Write($",{list[i]}");

            Console.WriteLine();
        }
    }
}
