using System.Runtime.InteropServices;

namespace RefOut
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sahe;
            AreaCalculator(6, 8,out sahe);
            Console.WriteLine($"Ucbucagin sahesi: {sahe}");
            AreaCalculator(6, out sahe);
            Console.WriteLine($"Dairenin sahesi: {sahe}");
            Console.ReadKey();
        }
        public static void AreaCalculator(int katet1, int katet2, out double sahe)
        {
             sahe = katet1 * katet2/2;
        }
        public static void AreaCalculator(int radius,out double sahe)
        {
            sahe = radius * radius * 3;
        }
    }
}
