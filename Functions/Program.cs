namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int Carpma;
            float Bolme;
            float Mod;
            float Cikarma;
            //Console.WriteLine(Square(ArrayInput()));
            Console.WriteLine("Topmala: " + Calculator(45,23,out Carpma,out Bolme,out Mod,out Cikarma) + $"\nCarpma:{Carpma} \nBolme:{Bolme}\nMod:{Mod}\nCikama{Cikarma}");
        }
        public static double Square(int[] dizi)
        {
            double sum = 0;
            sum = dizi.Sum();
            return Math.Sqrt(sum);
        }
        /// <summary>
        /// Arrayi consoldan qebul eden method
        /// </summary>
        /// <returns>{1,2,3,4,5,6}</returns>
        public static int[] ArrayInput()
        {
            Console.WriteLine("Array olcusu daxil edin:");
            int size = 0;
            bool sizeB = int.TryParse(Console.ReadLine(), out size);
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nIndex [{i}]:");
                Arr[i] = int.Parse(Console.ReadLine());
            }
            return Arr;
        }
        public static int Calculator(int a, int b, out int carpma, out float bolme, out float mod, out float cikartma)
        {
            carpma = a * b;
            bolme = a/b;
            cikartma = a-b;
            mod = a % b;
            return a + b;
        }

    }
}
