namespace ProductLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }  
        public int Quantity { get; set; }
        public double SubTotal
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }

        public Product()
        {
        }

        public Product(int productId, string productName, double unitPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
