using GenericExtation.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace GenericExtation
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Expression<Func<Source,Destination>> Map<Source,Destination>()
              {
                  var sourceParametr = Expression.Parameter(typeof(Source), "source");
                  var bindings = new List<MemberBinding>();

                  foreach (PropertyInfo property in )
                  {
                  }
                  return expression;
              }
            /*Expression<Func<DadClass, DadDto>> expression = e => new DadDto()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
            };
            Func<DadClass,DadDto> func = expression.Compile();
            Employee employee = new Employee()
            {
                FirstName = "asdads",
                LastName = "asfqer",
                Email = "sSfc@asfa",
                Age = 23
            };
            Director director = new Director()
            {
                FirstName = "Salam",
                LastName = "Sagol",
                Email = employee.Email,
                Salary = 2134.12
            };
            Console.WriteLine(func(employee).FirstName); 
            Console.WriteLine(func(director).FirstName);*/
        }
    }
}
