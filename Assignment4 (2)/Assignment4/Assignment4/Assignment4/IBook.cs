using Assignment4.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class IBook : Form
    {
        SqlConnection SqlCon =
          new SqlConnection(@"Data Source=TRIPHMSE62951\SQLEXPRESS;initial Catalog=BookDB;Integrated Security = True;");
        int bookId = 0;
        int pos = 0;
        public IBook()
        {
            InitializeComponent();
            ViewAll();
            button2.Enabled = false;
        }
        public Boolean AddNew(Book book)
        {
            try
            {
                // List<User> list = new List<User>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@BookId", book.BookId);
                param.Add("@BookName", book.BookName);
                param.Add("@BookPrice", book.BookPrice);
                // param.Add("@Password", password);
                int result = SqlCon.Execute("AddOrEdit", param, commandType: System.Data.CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }
                // Console.WriteLine(list[0].Username);


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return false;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            String name = txtBookName.Text.Trim();
            String price = txtPrice.Text.Trim();
            String error = "";
            double _price = 0;
            Regex rg = new Regex("[0-9]+");
            if (name.Length == 0 || name.Equals(""))
            {
                error += "Book's Name cannot be empty \n";
            }
            if (price.Length == 0 || price.Equals(""))
            {
                error += "Book's Price cannot be empty \n";
            }
            else if (!rg.IsMatch(price))
            {
                error += "Please input number for price \n";
            }
            else
            {
                _price = Double.Parse(price);
            }


            if (error != null && !error.Equals(""))
            {
                MessageBox.Show(error);
            }
            else if(error.Equals(""))
            {

                Book book = null;
                if (btnSave.Text.Equals("Save"))
                {
                    book = new Book();
                    book.BookId = 0;
                    book.BookName = name;
                    book.BookPrice = _price;
                    if (AddNew(book))
                    {
                        MessageBox.Show("Added successfully!!!");
                        txtBookName.Text = "";
                        txtPrice.Text = "";
                        ViewAll();
                    }
                    else
                    {
                        MessageBox.Show("Something errors", "Error");
                    }
                }

                else if (btnSave.Text.Equals("Update"))
                {
                    book = LoadAllBook().Where(b => b.BookId == bookId).FirstOrDefault();
                    book.BookName = name;
                    book.BookPrice = _price;
                    if (AddNew(book))
                    {
                        MessageBox.Show("Updated successfully!!!");
                        ViewAll();
                    }
                    else
                    {
                        MessageBox.Show("Something errors", "Error");
                    }
                }

            }
        }
        public void ViewAll()
        {
            try
            {
                List<Book> list = new List<Book>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();
                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@txtSearch", "");
                // param.Add("@Password", password);
                list = SqlCon.Query<Book>("ViewAllOrSearch", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                dataView.DataSource = list;
                double price = list.Sum(b => b.BookPrice);
                lbTotalPrice.Text = price.ToString("0,0") + " VND";
                // Console.WriteLine(list[0].Username);


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
        }

        public List<Book> LoadAllBook()
        {
            List<Book> list = new List<Book>();
            try
            {

                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@txtSearch", "");
                // param.Add("@Password", password);
                list = SqlCon.Query<Book>("ViewAllOrSearch", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                //dataView.DataSource = list;
                // Console.WriteLine(list[0].Username);


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return list;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Book> list = new List<Book>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                // param.Add("@Password", password);
                list = SqlCon.Query<Book>("LoadBookPrice", null, commandType: System.Data.CommandType.StoredProcedure).ToList();
                if (list.Count != 0)
                {
                    IBookList bookList = new IBookList();
                    bookList.dataView.DataSource = list;
                    bookList.Show();
                    this.Close();
                }



                // Console.WriteLine(list[0].Username);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String search = txtSearch.Text.Trim();
            try
            {
                List<Book> list = new List<Book>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@txtSearch", search);
                list = SqlCon.Query<Book>("ViewAllOrSearch", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                if (list.Count != 0)
                {
                    dataView.DataSource = list;
                }



                // Console.WriteLine(list[0].Username);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }


        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos >= 0)
            {
                showData(pos);
            }
            else
            {
                pos = dataView.Rows.Count - 1;
                showData(pos);
            }
        }
        public void showData(int pos)
        {
            //pos = (int)dataView.CurrentRow.Cells[0].Value;
            bookId = (int)dataView.Rows[pos].Cells[0].Value;
            Console.WriteLine(bookId);
            txtBookName.Text = dataView.Rows[pos].Cells[1].Value.ToString();
            txtPrice.Text = dataView.Rows[pos].Cells[2].Value.ToString();
            Console.WriteLine(txtBookName.Text);
            Console.WriteLine(txtPrice.Text);

            btnSave.Text = "Update";
        }
        private void dataView_MouseClick(object sender, MouseEventArgs e)
        {
            bookId = Int32.Parse(dataView.CurrentRow.Cells[0].FormattedValue.ToString());
            txtBookName.Text = dataView.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataView.CurrentRow.Cells[2].Value.ToString();
            btnSave.Text = "Update";
            button2.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < dataView.Rows.Count)
            {
                showData(pos);
                button2.Enabled = true;
            }
            else
            {
                pos = 0;
                showData(pos);
                button2.Enabled = true;
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {

            pos = 0;
            showData(pos);
            button2.Enabled = true;

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            pos = dataView.Rows.Count - 1;
            showData(pos);
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(bookId);
            if (bookId >= 0)
            {
                try
                {
                    // List<Book> list = new List<Book>();
                    if (SqlCon.State == System.Data.ConnectionState.Closed)
                    {
                        SqlCon.Open();

                    }
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@BookId", bookId);
                    int result = SqlCon.Execute("RemoveBook", param, commandType: System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                    {
                        MessageBox.Show("Removed successfully!!!");
                        ViewAll();
                        Clear();
                    }
                    else
                    {
                        MessageBox.Show("Cannot remove this book!!!");
                    }


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    SqlCon.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            bookId = 0;
            pos = 0;
            txtBookName.Text = "";
            txtPrice.Text = "";
            btnSave.Text = "Save";
            button2.Enabled = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            String search = txtSearch.Text.Trim();
            try
            {
                List<Book> list = new List<Book>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@txtSearch", search);
                list = SqlCon.Query<Book>("ViewAllOrSearch", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                if (list.Count != 0)
                {
                    dataView.DataSource = list;
                    double price = list.Sum(b => b.BookPrice);
                    lbTotalPrice.Text = price.ToString("0,0") + " VND";
                }



                // Console.WriteLine(list[0].Username);


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                SqlCon.Close();
            }

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void IBook_Load(object sender, EventArgs e)
        {

        }
    }


}
