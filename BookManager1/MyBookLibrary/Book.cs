using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Publisher{ get; set; }
        public double  Price { get; set; }

        public Book()
        {

        }

        public Book(int iD, string name, string publisher, double price)
        {
            ID = iD;
            Name = name;
            Publisher = publisher;
            Price = price;
        }
    }
}
