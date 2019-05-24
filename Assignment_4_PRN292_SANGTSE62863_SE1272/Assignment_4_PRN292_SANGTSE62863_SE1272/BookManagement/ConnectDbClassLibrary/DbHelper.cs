using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectDbClassLibrary
{
    public class DbHelper
    {
        public string strConnect { get; set; }

        public DbHelper()
        {
            strConnect = getConnectionString();
        }

        public string getConnectionString()
        {
            return "server=TRIPHMSE62951\\SQLEXPRESS;database=BookDB;uid=sa;pwd=123456";
        }

        public int checkLogin(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Select IsAdmin From tbl_User Where Username=@id And Password=@pass";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", username);
            cmd.Parameters.AddWithValue("@pass", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            int role = -1;
            try
            {
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                }
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    string result = dr[0].ToString();
                    if (result.Equals("True")) role = 1;
                    else role = 0;
                }
            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
            finally
            {
                cnn.Close();
            }
            return role;
        }

        public void updatePassword(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Update tbl_User Set Password=@pass where Username=@id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", username);
            cmd.Parameters.AddWithValue("@pass",password);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.ExecuteNonQuery();
        }

        public DataTable GetBookList()
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Select * From tbl_Book";
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

        public DataTable GetBookOrderByPrice()
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Select * From tbl_Book Order By BookPrice Desc";
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

        public DataTable GetBookInFilt(string filtChar)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Select * From tbl_Book Where BookName Like '%" + filtChar + "%'";
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

        public bool AddNewBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Insert tbl_Book Values(@name,@price)";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@name", book.name);
            cmd.Parameters.AddWithValue("@price", book.price);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool RemoveBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Delete tbl_Book Where BookId = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", book.id);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }

        public bool UpdateBook(Book book)
        {
            SqlConnection cnn = new SqlConnection(strConnect);
            string sql = "Update tbl_Book Set BookName = @name, BookPrice = @price Where BookId = @id";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.Parameters.AddWithValue("@id", book.id);
            cmd.Parameters.AddWithValue("@name", book.name);
            cmd.Parameters.AddWithValue("@price", book.price);
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            int count = cmd.ExecuteNonQuery();
            return (count > 0);
        }
    }
}
