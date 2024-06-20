using Expressionn.Models;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Expressionn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region example1

            /*Expression<Func<Employee, bool>> isAsultExpre = e => e.Age > 17;

            var employee = new List<Employee>
            {
                new Employee {FirstName = "Davoly" , LastName = "Nancy" , Age = 32},
                new Employee {FirstName = "Asda"  , LastName = " asda" , Age = 34},

                new Employee {FirstName = "dgwseEW" , LastName = "Qsfcda" , Age = 32},
                new Employee {FirstName = "Vasold"  , LastName = "Resasf" , Age = 34},
                new Employee {FirstName = "Edasemu" , LastName = "Uldatre" , Age = 32},
                new Employee {FirstName = "Yermisu"  , LastName = "Dateble" , Age = 34},
            };
            if (isAsultExpre.Body is BinaryExpression binary)
            {
                Console.WriteLine(binary);
                Console.WriteLine(binary.Left);
                Console.WriteLine(binary.Right);
                Console.WriteLine(binary.NodeType);


                List<string> list = new List<string>()
                {
                    "asdasd",
                    "asdq>!qwe",
                    "1wewdv#$!gas"
                };
                string word = String.Empty;
                string specialchar = ":!@#$%^&*()-_=+\\|[]{};:/?.<>";
                Expression<Func<string, string>> Cleaner = x => x.ToLower().Replace(">", "").Replace("!","").Replace("#","").Replace("$","");
                var exp = Cleaner.Compile();
                var filteredTexk = list.Select(exp).ToList();
                foreach (var item in filteredTexk)
                {
                    Console.WriteLine(item);
                }
            }*/
            #endregion

            string pattern = @"[ ğüşıç'-]";

            string replaced(Match match)
            {
                return match.Value switch
                {
                    " " => "",
                    "-" => "",
                    "'" => "",
                    "ç" => "c",
                    "ğ" => "g",
                    "ı" => "i",
                    "ö" => "o",
                    "ş" => "s",
                    "ü" => "u",
                    "ß" => "b",
                    "ä" => "a",
                    "é" => "e",
                    "â" => "a",
                    _ => match.Value.ToLower()
                };
            }
          

            Func<string, string> ReplaceExpression = s => Regex.Replace(s, pattern, new MatchEvaluator(replaced));

            Expression<Func<string, string, string>> createdMail = (m, n) => ReplaceExpression(m.ToLower()) + "."
            + ReplaceExpression(n.ToLower())
            + "@hotmail.com";
            Expression<Func<string, string>> Name = n =>  ReplaceExpression(n.Substring(0, 1)).ToUpper() + ReplaceExpression(n.Substring(1, n.Length - 1)).ToLower();
            Expression<Func<string, string>> LastName = l => ReplaceExpression(l.ToLower()).ToUpper();


            List<Employee> employees = new List<Employee>()
               {
                   new Employee{FirstName = "ceüyhun" , LastName = "agayev"},
                   new Employee{FirstName = "eldar" , LastName = "Eyvazli"},
                   new Employee{FirstName = "samir" , LastName = "samirov"}
               };
            var retVal = employees
            .AsQueryable()
            .Select(x => new
            {
                M = createdMail.Compile()(x.FirstName,x.LastName),
                N = Name.Compile()(x.FirstName),
                L = LastName.Compile()(x.LastName),
            }).ToList();

            retVal.ForEach(x =>
            {
                Console.WriteLine(x.M);
                Console.WriteLine(x.N);
                Console.WriteLine(x.L);
            });
        }
    }
}

