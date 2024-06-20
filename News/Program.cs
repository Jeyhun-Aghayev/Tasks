using News.Models;

namespace News
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee employee = new Employee("asd","asd","asd","asd","dsa");
            var emp = employee with { Firstname = "Abuzer" };
            Console.WriteLine(employee);
            Console.WriteLine(emp);
        }
    }
}
