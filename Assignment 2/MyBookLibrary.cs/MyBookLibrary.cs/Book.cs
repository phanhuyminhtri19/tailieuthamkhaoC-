using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary.cs
{
    class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Publisher { get; set; }
        public double Price { get; set; }

        public Book ()
        {

        }
        public Book(int id, string name, string publisher, double price)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            Price = price;
        }
    }
}
