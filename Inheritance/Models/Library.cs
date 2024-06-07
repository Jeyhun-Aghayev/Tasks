using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    internal class Library
    {
        public  List<Book> Books { get; set; } = new List<Book>();
        public void AddBook(Book book)
        {
            book.Code += book.Id;
            Books.Add(book);
        }
        public Book GetBook(Predicate<Book> ex)
        {
            IEnumerable<Book> getbooks = Books.FindAll(ex);
            return getbooks.FirstOrDefault();
        }
        public Book FindAllBook(Func<Book, bool> ex)
        {
            IEnumerable<Book> getbooks = Books.Where(ex);
            return getbooks.FirstOrDefault();
        }
        public int RemoveAllBook(Predicate<Book> ex)
        {
            return Books.RemoveAll(ex);
        }
    }

    public class Book
    {
        public static int BookId = 0;
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public Book(string authorName, string name, int pageCount, double price)
        {
            Id = BookId;
            BookId ++;
            AuthorName = authorName;
            Name = name.Trim();
            PageCount = pageCount;
            Price = price;
            Code = Name.Substring(0, 1);
        }
    }
    public class Order
    {
        public static int OrderId = 0;
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SifarisTarixi { get; set; }

        public Order(int id, double totalPrice, DateTime sifarisTarixi)
        {
            Id = OrderId;
            OrderId ++;
            TotalPrice = totalPrice;
            SifarisTarixi = sifarisTarixi;
        }
        public Order()
        {
            
        }

        public double CalculatePrice(List<Book> Books)
        {
            double price = 0;
            foreach (Book book in Books)
            {
                price += book.Price;
            }
            return price;
        }
    }
}
