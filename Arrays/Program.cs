namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Array olcusu daxil edin:");
            int size = int.Parse(Console.ReadLine());
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nIndex{i}:");
                Arr[i] = int.Parse(Console.ReadLine());
            }
                static bool IsPrime(int number)
                {
                    if (number == 2) return true; 

                    for (int i = 2; i <= Math.Sqrt(number); i++)
                    {
                        if (number % i == 0) return false;
                    }
                    return true;
                }

            string simples = "";
            string iscomposite = "";
            
            for (int i = 0; i < size; i++) 
            {
                if (Arr[i] <= 1) continue;
                if(IsPrime(Arr[i]) == true) simples += $" {Arr[i]}";
                else { iscomposite += $" {Arr[i]}"; }
                string[] simplesStr = simples.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int[] Simpless = Array.ConvertAll(simplesStr, Convert.ToInt32);

                string[] IscompesitStr = iscomposite.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int[] IsCompesite = Array.ConvertAll(IscompesitStr, Convert.ToInt32);
                if (i == size - 1)
                {

                Console.WriteLine("Mwrekkeb ededler: \n");
                for (int h = 0; h < IsCompesite.Length; h++)
                {
                    Console.Write($"{IsCompesite[h]}  ");
                }

                Console.WriteLine("\nSade ededler: \n");
                for (int h = 0; h < Simpless.Length; h++)
                {
                    Console.Write($"{Simpless[h]}  ");
                }
                }
            }

            /*int[] arr = { 0, 50, -11, 23 };
            Tuple<int, int> Task4_3(int[] arr)
            {
                int min = arr[0];
                int minIndex = 0;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < min) { min = arr[i]; minIndex = i; };
                }
                return Tuple.Create(min, minIndex);
            }
            Console.WriteLine("(Min;MinIndex)");
            Console.WriteLine(Task4_3(arr));*/

/*
            int Ortalam(int[] arr)
            {
                int cem = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    cem += arr[i];
                }
                int edediorta = cem/arr.Length;
                return edediorta;
            }*/
            
            /*  int[] Sorted(int[] arr)
              {
                  int num = arr[0];
                  for (int i = 0; i < arr.Length; i++)
                  {
                      int index = i ;
                      for (int j = 1; j < num; j++)
                      {
                          if (arr[j] < arr[index]){ index = j; }

                      }

                  }

              }*/
        }
    }
}
