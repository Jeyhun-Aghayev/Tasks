using System;
using System.Threading.Channels;
using System.Timers;

namespace Loopss
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            #region For
            //MinMax();
            //TekCutSayisi();
            //DigitsOfNumber();
            //Kare();
            //BosKare();
            //CarpimTablosu();
            //SekkizKarakterlikBirRandomSayi();
            #endregion

            //ForeachTask();
            WhileTask();
            //Login();
            #region Examples

            /*int sum = 0;
            for (int i = 2; i <= 1000; i+=2)
            {
                sum += i;
            }
            Console.WriteLine(sum);

            char[] az = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i).ToArray();

            for (int i = 0; i < az.Length; i++)
            {
                Console.WriteLine(az[i]);
            }
            for (char i = 'A'; i < 'Z'; i++)
            {
                Console.WriteLine(az[i]);
            }

            for(int i = 1945; i <2025 ; i++)
            {
                if(i==1990||i==1992) continue;
                Console.WriteLine(i);
            }*/
            /*string[] takimlar = { "besiktas", "kupasiz", "galatasaray" };
            for (int i = 0; i < takimlar.Length; i++)
            {
                Console.WriteLine(takimlar[i]);
            }
            Console.WriteLine(new String('-',50));
*/
            #endregion
        }
        //----------FOR_START--------------
        public static void MinMax()
        {
            int[] numbers = { 3, 5, 7, 2, 8, -1, 4, 10, 12 };

            int min = numbers[0];
            int max = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }

                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            Console.WriteLine("En kücük reqem: " + min);
            Console.WriteLine("En büyük reqem: " + max);
        }
        public static void SekkizKarakterlikBirRandomSayi()
        {
            Random random = new Random();
            bool success = false;
                int randomNumber = random.Next(10000000, 100000000);
                Console.WriteLine(randomNumber);
                Console.WriteLine("yukaridaki random sayiyi girin:");
            for (int i = 0; i < 3; i++)
            {

                int enter = 0;
                if (!Int32.TryParse(Console.ReadLine(), out enter) && enter != randomNumber)
                {
                    if(i == 2)continue;
                    Console.WriteLine($"Yansil daxil etdiz!  Sizin {2-i} sansiniz qaldi");
                    continue;
                }
                else
                {
                    Console.WriteLine("Dogru daxil etdiz");
                    success = true;
                    break;
                }
            }
            if (!success) 
            {
                Console.WriteLine("Sansiniz bitdi");

                Thread.Sleep(10000);
                Environment.Exit(0);
            }
        }
        public static void TekCutSayisi()
        {
            Console.WriteLine("Array olcusu daxil edin:");
            int size = int.Parse(Console.ReadLine());
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nIndex [{i}]:");
                Arr[i] = int.Parse(Console.ReadLine());
            }
            int TekSay = 0;
            int CutSay = 0;
            for (int i = 0; i < size; i++)
            {
                if (Arr[i] % 2 == 0)
                {
                    CutSay++;
                }
                else { TekSay++; }
            }
            Console.WriteLine("Teksay : " + TekSay);
            Console.WriteLine("Cutsay : " + CutSay);

        }
        public static void DigitsOfNumber()
        {
            int enter = EdedDaxilEdin();
            int sum = 0;
            int qaliq = 0;
            do
            {
                sum += enter % 10;
                qaliq = enter % 10;
                enter = enter - qaliq;
                enter /= 10;
            }
            while (enter > 0);
            Console.WriteLine("Ededlerin cemi:" + sum);
        }
        public static void Kare()
        {
            int enter = EdedDaxilEdin();


            for (int i = 0; i < enter; i++)
            {
                Console.WriteLine(new String('X', enter));
            }
        }
        public static void Dikkenar()
        {
            int enter = EdedDaxilEdin();
            for (int i = enter; i > 0; i--)
            {
                Console.WriteLine(new String('X', i));
            }
        }
        public static void BosKare()
        {
            int enter = EdedDaxilEdin();
            for (int i = 1; i < enter; i++)
            {
                if (i == 1 || i <= enter)
                {
                    Console.WriteLine(new String('X', enter));
                }
                else
                {
                    Console.WriteLine("X" + new String(' ', enter - 2) + "X");
                }
            }
        }
        public static void CarpimTablosu()
        {
            for (int j = 1; j < 10; j++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{j}x{i}={j * i}");
                }
                Console.WriteLine(new String('-', 50));
            }
        }
        public static int EdedDaxilEdin()
        {
            int enter = 0;
            Console.WriteLine("Ededi daxil edin:");
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out enter))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Dogru eded daxil edin!:");
                }
            } while (true);
            return enter;
        }  //hazir eded input
        public static int[] ArrayInput()
        {
            Console.WriteLine("Array olcusu daxil edin:");
            int size = int.Parse(Console.ReadLine());
            int[] Arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"\nIndex [{i}]:");
                Arr[i] = int.Parse(Console.ReadLine());
            }
            return Arr;
        }   //hazir array input
        //----------FOR_End------------


        //----------FOREACH------------
        public static void ForeachTask()
        {
            int[] arr = ArrayInput();
            string ikiyeBolunenler = String.Empty;
            string uceBolunenler = String.Empty;
            int ikiSay = 0;
            int ucSay = 0;
            int tekSum = 0;
            int Ciftsum = 0;
            foreach (int i in arr)
            {
                if (i % 2 == 0)
                {
                    ikiyeBolunenler += $" {i}";
                    ikiSay++;
                    Ciftsum += i;
                }
                else tekSum += i;

                if (i % 3 == 0)
                {
                    uceBolunenler += $" {i}";
                    ucSay++;
                }
            }
            Console.WriteLine($"\n\nIkiye bolunenler:\n{ikiyeBolunenler}\n");
            Console.WriteLine($"Ikiye bolunenlerin sayi: {ikiSay}\n\n");
            Console.WriteLine($"Uce bolunenler:\n{uceBolunenler}\n");
            Console.WriteLine($"Uce Bolunenlerin sayi:{ucSay}\n");
            Console.WriteLine($"Tek Toplam:{tekSum} \nCut Toplam:{Ciftsum}");
        }

        //-----------While-------------
        public static void WhileTask()
        {
                Console.WriteLine("1-6 araliginda Array olcusu daxil edin:");
            int size = 0;
            while (true)
            {

                if (Int32.TryParse(Console.ReadLine(), out size) && size >= 1 && size <= 6)
                {
                    break;
                }
                else { Console.WriteLine("1-6 araliginda eded daxil edin!!!!"); }
            }
            Random random = new Random();
            int i = 0;
            int t = 0;
            while (i<size)
            {
                i++;
                int[]  ints = new int[size];
                while (t < size)
                {
                    t++;
                    int randomNumber = random.Next(1, 50);
                    for (int j = 0; j < t; j++)
                    {
                        if (ints[j] == randomNumber) return;
                    }
                    ints[t-1] = randomNumber;
                }
                t = 0;
                Console.Write(i + ". ");
                for (int j = 0;j < ints.Length; j++)
                {
                    Console.Write(ints[j] + " ");
                }
                Console.WriteLine("\n\n");

            }
        }

        public static void Login()
        {
            string Username = "Ceyhun";
            string Password = "Ceyhun123";
            bool login = true;
            Console.WriteLine($"Username:{Username}\nPassword:{Password}\n\n");
            Console.WriteLine("Enter the username:");
            do
            {
                string EnterUser = Console.ReadLine();
                Console.WriteLine("\nEnter the password:");
                string EnterPass = Console.ReadLine();
                if(EnterPass==Password && EnterUser == Username)
                {
                    Console.WriteLine("\nLogin is successed");
                    login = false;
                }
                else
                {
                    Console.WriteLine("\n\nDogru deyil yeniden qeyd edin:");
                }

            } while (login);
        }
    }

}
