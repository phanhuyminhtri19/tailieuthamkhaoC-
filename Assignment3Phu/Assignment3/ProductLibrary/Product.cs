using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public class Product
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public float SubTotal {
            get
            {
                return (float) (Quantity * UnitPrice);
            }
        }
        public Product(int iD, string name, int quantity, decimal unitPrice)
        {
            ID = iD;
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public Product()
        {
        }
    }
}
