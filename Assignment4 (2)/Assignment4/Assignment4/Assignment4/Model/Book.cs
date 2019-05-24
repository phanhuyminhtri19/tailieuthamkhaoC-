using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public String BookName { get; set; }
        public double BookPrice { get; set; }
        public Book()
        {

        }

        public Book(int bookId, string bookName, double bookPrice)
        {
            BookId = bookId;
            BookName = bookName;
            BookPrice = bookPrice;
        }
    }
}
