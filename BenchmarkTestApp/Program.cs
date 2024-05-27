using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;
using System.Text;

namespace BenchmarkTestApp
{
    public class Program
    {
        /*public static void TestKase1() 
        {
            string result = "";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++) { result += i.ToString(); }
            sw.Stop();
            Console.WriteLine("Base For : " + sw.ElapsedMilliseconds + "ms");
            sw.Restart();
            StringBuilderTest();
            sw.Stop();
            Console.WriteLine("Stringbuilder : " + sw.ElapsedMilliseconds + "ms");

        }
        public static void StringBuilderTest()
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < 100000 ; i++)
            {
                str.Append(i.ToString());
            }

        }*/

        static void Main(string[] args)
        {
            /*TestKase1();*/
            var summary = BenchmarkRunner.Run<StringVsStringBuilder>();
        }
        
        public class StringVsStringBuilder
        {
            private const int num = 100000;
            [Benchmark]
            public  void TestKase1()
            {
                string result = "";
                for (int i = 0; i < num; i++) { result += i.ToString(); }

            }
            [Benchmark]
            public void StringBuilderTest()
            {
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < num; i++)
                    {
                        str.Append(i);
                    }

            }
        }
    }

}
