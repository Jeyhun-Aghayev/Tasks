namespace TryCatchException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the phone number:");
                int tel = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
            Console.WriteLine("We have problem");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
