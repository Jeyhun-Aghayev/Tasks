using System;
using System.Drawing;

namespace List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WhileTask();
        }
        public static void WhileTask()
        {
            int[] ints;
            int randomNumber;
            Console.WriteLine("1-6 araliginda Array olcusu daxil edin:");
            int size = 0;
            while (true)
            {

                if (Int32.TryParse(Console.ReadLine(), out size) && size >= 1 && size <= 6)
                {
                    break;
                }
                else { Console.WriteLine("1-6 araliginda eded daxil edin!!!!"); }
            }
            Random random = new Random();
            int i = 0;
            int t = 0;
            int index = 0;
            List < int[]> arrays = new List <int[]>();
            while (i < size)
            {
                i++;
                ints = new int[size];
                while ( index < size)
                {
                    index++;
                    if (!CheckUniqe(ints, random.Next(1, 50), size, index)) return;
                }
                index = 0;
                arrays.Add(ints);
            }
            i = 0;
            arrays.ForEach(a =>
            {
                i++;
                Console.WriteLine(i + ". ");
                WriteLine(a);
            });
        }
        public static bool CheckUniqe( int[] ints,int randomNumber,int size,int index)
        {
                for (int j = 0; j < index; j++)
                {
                    if (ints[j] == randomNumber) return false;
                }
                ints[index - 1] = randomNumber;
                return true;
        }
        public static void WriteLine(int[] a)
        {
            for (int j = 0; j < a.Length; j++)
            {
                Console.Write(a[j] + " ");
            }
            Console.WriteLine("\n\n");
        }
    }
}
