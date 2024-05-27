using System.Runtime.CompilerServices;

namespace Loops
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr ={ 2, 4, 32, 1, 2, 4, 2, 5, 7, };
            IF:
            int i = 0;
            if (Array.LastIndexOf(arr, arr[i]) == Array.IndexOf(arr, arr[i]))
            {
                Console.WriteLine("Arrayda eyni element var");
            }
            else 
            {
                if (i < arr.Length - 1) { i++; goto IF; }
                else Console.WriteLine("Arrayda ayni element yoxdur");
            }
            
            
        }
        
    }
}
