namespace elseif
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the sheason:");
            string season = Console.ReadLine();
            string sea = season switch
            {
                "Winter" => "Qis",
                "Sprint" => "Yaz",
                "Summer" => "Yay",
                "Autumn" => "Payiz"
            };
            Console.WriteLine(sea);
            string sea1 = "";
            switch (season)
            {
                case "Winter":
                    sea1 = "Qis";
                    break;
                case "Sprint":
                    sea1 = "Yaz";
                    break;
                case "Summer":
                    sea1 = "Yay";
                    break;
                case "Autumn":
                    sea1 = "Payiz";
                    break;
            }
            Console.WriteLine(sea1);
        }
    }
}
