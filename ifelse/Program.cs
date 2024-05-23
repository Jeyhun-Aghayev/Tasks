namespace ifelse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static void Example()
        {
        EDED:
            Console.WriteLine("1-100 araliginda eded daxil edin:");
            int a;
            bool f = int.TryParse(Console.ReadLine(), out a);
            if (!f) { Console.WriteLine("1-100 araliginda eded daxil edin!!!"); goto EDED; }
            if (a < 0 || a > 100) { goto EDED; }

            if (a < 30) Console.WriteLine("FF");
            else if (a < 50) Console.WriteLine("DD");
            else if (a < 70) Console.WriteLine("CC");
            else if (a < 84) Console.WriteLine("BB");
            else Console.WriteLine("AA");
        }
        static void Eample2()
        {
            string number = "1";
            byte b = Convert.ToByte(number);
            sbyte sb = Convert.ToSByte(number);
            short s = Convert.ToInt16(number);
            ushort us = Convert.ToUInt16(number);
            int i = Convert.ToInt32(number);
            uint ui = Convert.ToUInt32(number);
            long l = Convert.ToInt64(number);
            ulong ul = Convert.ToUInt64(number);

            float f = Convert.ToSingle(number);
            decimal d = Convert.ToDecimal(number);
            double db = Convert.ToDouble(number);
        }

        static void Eample3()
        {
            bool result = true;
            Console.WriteLine($"Veri kaydetme islemi basari{(true ? "li" : "siz")}dir");
        }
        static void Example4()
        {

        }
    }
}
