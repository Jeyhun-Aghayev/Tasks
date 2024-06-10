using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Models
{
    public class Book
    {
     
        private static int _bookId = 0;
        private int Id { get; set; }
        public string AuthorName { get; set; }
        public string Name { get; set; }
        public int PageCount { get; set; }
        public double Price { get; set; }
        public string Code { get; set; }
        public Book()
        {
            _bookId++;
            Id =_bookId;
        }
    }
}
