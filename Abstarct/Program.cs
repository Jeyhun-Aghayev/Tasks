using Abstarct.Models;

namespace Abstarct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bateri bateri = new Bateri()
            {
                Marka = "Yamaha",
                Model = "x123",
                Aciqlama = "guzel caliyor",
                Fiyat = 1231,
                UretimYeri = "USA",
                Hammadde = Hammade.Metal
            };
            Keman keman = new Keman()
            {
                Marka = "Qaraci",
                Model = "4/4",
                Aciqlama = "Taksiye islenmiyib",
                Fiyat =1230,
                UretimYeri = "Austry",
                Hammadde=Hammade.Agac,
                TelTipi = "Steel",
                Arse = "at tuku",                
            };
            Muzisyen muzisyen = new Muzisyen()
            {
                Name = "San",
                Surname = "Marino",
                Enstruman = keman,
            };
            Console.WriteLine(muzisyen);
        }
    }
}
