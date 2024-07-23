using System.ComponentModel.Design;
using System.Linq.Expressions;

namespace AgainC_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }
        static void Task1()
        {
            int between = Int32.Parse(Console.ReadLine());
            if (between >= 0 && between <= 100)
            {
                if (between <= 50) { Console.WriteLine('F'); }
                else if (between <= 60) Console.WriteLine('E');
                else if (between <= 70) Console.WriteLine('D');
                else if (between <= 80) Console.WriteLine('C');
                else if (between <= 90) Console.WriteLine('B');
                else Console.WriteLine('A');
            }
            if (between >= 0 && between <= 100)
            {
                switch (between)
                {
                    case int n when (n <= 50):
                        Console.WriteLine('F');
                        break;
                    case int n when (n <= 60):
                        Console.WriteLine('E');
                        break;
                    case int n when (n <= 70):
                        Console.WriteLine('D');
                        break;
                    case int n when (n <= 80):
                        Console.WriteLine('C');
                        break;
                    case int n when (n <= 90):
                        Console.WriteLine('B');
                        break;
                    default:
                        Console.WriteLine('A');
                        break;
                }
            }
            char grade = between switch
            {
                var n when (n <= 50) => 'F',
                var n when (n <= 60) => 'E',
                var n when (n <= 70) => 'D',
                var n when (n <= 80) => 'C',
                var n when (n <= 90) => 'B',
                _ => 'A'
            };

            Console.WriteLine(grade);
        }
    }
}
