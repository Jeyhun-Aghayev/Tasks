namespace SingletonTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.Instance;
            Singleton s2 = Singleton.Instance;

            if (s1 == s2)
            {
                Console.WriteLine("Both instances are the same.");
            }

            s1.DoSomething();
        }
        public sealed class Singleton
        {
            // Statik bir örnek değişkeni
            private static Singleton instance = null;

            // Thread-safety için bir kilit nesnesi
            private static readonly object padlock = new object();

            // Özel kurucu metot, bu sınıfın dışından doğrudan örneklenmesini engeller
            private Singleton()
            {
            }

            // Tek örneği döndüren statik metot
            public static Singleton Instance
            {
                get
                {
                    lock (padlock) // Thread-safety sağlamak için kilit kullanımı
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                        return instance;
                    }
                }
            }

            public void DoSomething()
            {
                Console.WriteLine("Singleton instance is working.");
            }
        }
    }
}
