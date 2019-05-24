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
        public ProductDB()
        {
            strConnection = getConnectionString();
        }
        public string getConnectionString()
        {
            string strConnection = "server=.;database=SaleDB;uid=sa;pwd=123456";
            return strConnection;
        }
        public bool AddNewProduct(Product product)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "insert Products values(@name, @quantity, @price) ";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@name", product.ID);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@price", product.UnitPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);

        }

        public bool RemoveProduct(Product product)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "delete from Products where ProductID = @ID ";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", product.ID);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool UpdateProduct(Product product)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            string SQL = "update Products set ProductName = @name, Quantity = @quantity, UnitPrice = @price " +
                    "where ProductID = @ID";
            SqlCommand cmd = new SqlCommand(SQL, cnn);
            cmd.Parameters.AddWithValue("@ID", product.ID);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@price", product.UnitPrice);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public Product FindProduct(int ProductID)
        {
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string sql = "select ProductName, Quantity, UnitPrice from Products where ProductID = @ID";
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddWithValue("@ID", ProductID);
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
                            string Name = reader.GetString(reader.GetOrdinal("ProductName"));
                            int Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            float UnitPrice = reader.GetFloat(reader.GetOrdinal("UnitPrice"));
                            return new Product()
                            {
                                ID = ProductID,
                                Name = Name,
                                Quantity = Quantity,
                                UnitPrice = UnitPrice
                            };
                        }
                    }
                }
            }
            return null;
        }

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
                            float UnitPrice = reader.GetFloat(reader.GetOrdinal("UnitPrice"));
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
