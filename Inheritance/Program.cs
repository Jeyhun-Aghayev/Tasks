using Inheritance.Models;

namespace Inheritance
{
    internal class Program
    {
        
        //Kitabxana sistemi ilə işləmək üçün əvvəlcə Library obyekti yaradın,
        //sonra lazım olan Book obyektlərini əlavə edin.
        //Sifariş yaratmaq üçün Order obyekti yaradaraq lazımi kitabları əlavə edin
        //ümumi qiyməti hesablayın.
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook(new Book("Keramet Boyukcol", "Kitabadi1",192,23.12));
            library.AddBook(new Book("Cingiz Xanlarov", "Kitabadi2",134,12.34));
            library.AddBook(new Book("Dostayecvski Boyukcol", "Kitabadi3",142,7.32));
            Order order = new Order();
            Console.WriteLine( order.CalculatePrice(library.Books));

        }
    }
}
