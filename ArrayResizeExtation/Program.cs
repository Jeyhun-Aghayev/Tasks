using ArrayResizeExtation.System;
namespace ArrayResizeExtation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Array<int> arr = new Array<int>(5);
            Console.WriteLine(arr); 

            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            arr[3] = 4;
            arr[4] = 5;
            Console.WriteLine(arr); 

            arr.Resize(3);
            Console.WriteLine(arr);
            int[] ints = { 2, 3, 14, 4 };
            arr.Resize(7,ints);
            Console.WriteLine(arr);
            
        }
    }
}
