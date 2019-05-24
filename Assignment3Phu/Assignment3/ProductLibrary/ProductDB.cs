using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public class ProductDB
    {
        public string strConnection { get; set; }

        public bool AddNewProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string sql = "insert Products values(@name, @quantity, @price) ";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@quantity", p.Quantity);
                command.Parameters.AddWithValue("@price", p.UnitPrice);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int count = command.ExecuteNonQuery();
                return count > 0;
            }
        }

        public bool RemoveProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string sql = "delete from Products where ProductID = @ID ";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@ID", p.ID);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int count = command.ExecuteNonQuery();
                return count > 0;
            }
        }

        public bool UpdateProduct(Product p)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string sql = "update Products set ProductName = @name, Quantity = @quantity, UnitPrice = @price " +
                    "where ProductID = @ID";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@ID", p.ID);
                command.Parameters.AddWithValue("@name", p.Name);
                command.Parameters.AddWithValue("@quantity", p.Quantity);
                command.Parameters.AddWithValue("@price", p.UnitPrice);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                int count = command.ExecuteNonQuery();
                return count > 0;
            }
        }

        //public Product FindProduct(int ProductID)
        //{
        //    using (SqlConnection conn = new SqlConnection(strConnection))
        //    {
        //        string sql = "select ProductName, Quantity, UnitPrice from Products where ProductID = @ID";
        //        SqlCommand command = new SqlCommand(sql, conn);
        //        command.Parameters.AddWithValue("@ID", ProductID);
        //        if (conn.State == ConnectionState.Closed)
        //        {
        //            conn.Open();
        //        }
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                while (reader.Read())
        //                {
        //                    string Name = reader.GetString(reader.GetOrdinal("ProductName"));
        //                    int Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
        //                    decimal UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
        //                    return new Product()
        //                    {
        //                        ID = ProductID,
        //                        Name = Name,
        //                        Quantity = Quantity,
        //                        UnitPrice = UnitPrice
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}

        public List<Product> GetProductList()
        {
            List<Product> products = null;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string sql = "select ProductID, ProductName, Quantity, UnitPrice from Products";
                SqlCommand command = new SqlCommand(sql, conn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (products == null)
                            {
                                products = new List<Product>();
                            }
                            int Id = reader.GetInt32(reader.GetOrdinal("ProductID"));
                            string Name = reader.GetString(reader.GetOrdinal("ProductName"));
                            int Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            decimal UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                            products.Add(new Product()
                            {
                                ID = Id,
                                Name = Name,
                                Quantity = Quantity,
                                UnitPrice = UnitPrice
                            });
                        }
                    }
                }

            }
            return products;
        }
    }
}
