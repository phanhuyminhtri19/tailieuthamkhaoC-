using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDbClassLibrary
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        public Book()
        {

        }

        public Book(int id, string name, float price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}
