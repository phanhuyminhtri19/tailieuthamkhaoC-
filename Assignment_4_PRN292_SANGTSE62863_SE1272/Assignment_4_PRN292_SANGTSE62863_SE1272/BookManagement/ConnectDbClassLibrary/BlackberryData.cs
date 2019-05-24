using ConnectDbClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class BlackberryData
    {
        public string strConnect { get; set; }

        public BlackberryData()
        {
            strConnect = getConnectionString();
        }

        public string getConnectionString()
        {
            return "server=TRIPHMSE62951\\SQLEXPRESS;database=SUMMER11_Practical_Exam_2;uid=sa;pwd=123456";
        }
        public DataTable GetProductsList()
        {
            string sql = "Select * From LambID";
            SqlConnection cnn = new SqlConnection(strConnect);
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dt);
            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        public DataTable GetProductsInFilt(string filtChar)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Select * From Lamb Where LambName Like '%" + filtChar + "%'";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dt);
            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }

        public bool AddNewProduct(Blackberry b)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Insert Lamb Values(@name,@manu,@model,@price,@year)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@name", b.LambName);
            cmd.Parameters.AddWithValue("@manu", b.Manufacturer);
            cmd.Parameters.AddWithValue("@model", b.Model);
            cmd.Parameters.AddWithValue("@price", b.Price);
            cmd.Parameters.AddWithValue("@year", b.ReleasedYear);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool UpdateProducts(Blackberry b)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Update Lamb Set LambName = @name, Manufacturer=@manu, Model = @model," +
                " Price = @price, ReleasedYear= @year  Where LambID = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", b.LambID);
            cmd.Parameters.AddWithValue("@name", b.LambName);
            cmd.Parameters.AddWithValue("@manu", b.Manufacturer);
            cmd.Parameters.AddWithValue("@model", b.Model);
            cmd.Parameters.AddWithValue("@price", b.Price);
            cmd.Parameters.AddWithValue("@year", b.ReleasedYear);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
