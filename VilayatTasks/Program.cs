using System.Globalization;

namespace VilayatTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DigitsOfNumber();
            Task2();
        }
        public static void DigitsOfNumber()
        {
            int enter = 0;
            Console.WriteLine("Ededi daxil edin:");
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out enter))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Dogru eded daxil edin!:");
                }
            } while (true);
            int sum = 0;
            int say = 0;
            int qaliq = 0;
            do
            {
                sum += enter % 10;
                say++;
                qaliq = enter % 10;
                enter = enter - qaliq;
                enter /= 10;
            }
            while (enter > 0);
            Console.WriteLine("Ededlerin cemi:" + sum);
            Console.WriteLine("Ededlerin sayi:" + say);
        }
        public static void Task2()
        {
            Console.WriteLine("Array olcusu daxil edin:");
            int size = int.Parse(Console.ReadLine());
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nIndex [{i}]:");
                Arr[i] = int.Parse(Console.ReadLine());
            }
            int TekSay = 0;
            int CutSay = 0;
            for (int i = 0;i < size; i++)
            {
                if(Arr[i] % 2 == 0)
                {
                    CutSay++;
                }
                else {  TekSay++; }
            }
            Console.WriteLine("Teksay : " + TekSay);
            Console.WriteLine("Cutsay : " + CutSay);
        }
        public static void Task3() 
        {

        }
    }
}
