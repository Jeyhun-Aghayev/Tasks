using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Inheritance.Data;
using Inheritance.Models;

namespace Inheritance
{
    internal class Library
    {
        public static void AddBook(Book book)
        {
            AppDbContext.books.Add(book);
        }
        public static void RemoveBook(Book book)
        {
            AppDbContext.books.Remove(book);
        }
        public static Book GetBook(string name)
        {
           Book book =  AppDbContext.books.Where(x=>x.Name == name).FirstOrDefault();
            return book;
        }
        public static List<Book> FindAll(string name)
        {
            List<Book> books = AppDbContext.books.Where(x=>x.Name == name).ToList();
            return books;
        }






        //public List<Book> Books { get; set; } = new List<Book>();
        ////public void AddBook(Book book)
        ////{
        ////    book.Code += book.Id;
        ////    Books.Add(book);
        ////}
        //public Book GetBook(Predicate<Book> ex)
        //{
        //    IEnumerable<Book> getbooks = Books.FindAll(ex);
        //    return getbooks.FirstOrDefault();
        //}
        //public Book FindAllBook(Func<Book, bool> ex)
        //{
        //    IEnumerable<Book> getbooks = Books.Where(ex);
        //    return getbooks.FirstOrDefault();
        //}
        //public int RemoveAllBook(Predicate<Book> ex)
        //{
        //    return Books.RemoveAll(ex);
        //}
    }

    //public class Order
    //{
    //    public static int OrderId = 0;
    //    public int Id { get; set; }
    //    public double TotalPrice { get; set; }
    //    public DateTime SifarisTarixi { get; set; }

    //    public Order(int id, double totalPrice, DateTime sifarisTarixi)
    //    {
    //        Id = OrderId;
    //        OrderId++;
    //        TotalPrice = totalPrice;
    //        SifarisTarixi = sifarisTarixi;
    //    }
    //    public Order()
    //    {

    //    }

    //    public double CalculatePrice(List<Book> Books)
    //    {
    //        double price = 0;
    //        foreach (Book book in Books)
    //        {
    //            price += book.Price;
    //        }
    //        return price;
    //    }
    //}
}
