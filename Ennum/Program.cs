using Ennum.Models;
using System.Threading.Channels;

namespace Ennum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
                FirstName = "Test",
                LastName = "Test",
                Email = "test.email",
                Phone = "134123123",
                Department = Department.IT
            };
            employee.GetType().GetProperties().ToList().ForEach(p => Console.WriteLine($"{p.Name.PadLeft(20)} : {p.GetValue(employee)}"));
            string[] status = Enum.GetNames(typeof(Status));
            foreach (var item in status)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Enum.GetName(typeof(Status),1));
        }
        
    }
}
