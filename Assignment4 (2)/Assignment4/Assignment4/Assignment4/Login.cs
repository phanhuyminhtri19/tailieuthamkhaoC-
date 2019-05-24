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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Login : Form
    {
        SqlConnection SqlCon =
           new SqlConnection(@"Data Source=TRIPHMSE62951\SQLEXPRESS;initial Catalog=BookDB;Integrated Security = True;");
        public Login()
        {
            InitializeComponent();
        }
        public User CheckLogin(String username , String password)
        {
            User user = new User();
            try
            {
                // List<User> list = new List<User>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", username);
                param.Add("@Password", password);
                user = SqlCon.Query<User>("Login", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
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
            return user;
        }


        public Boolean CheckRole(String username, String password)
        {
            User user = new User();
            Boolean isAdmin = false;
            try
            {
                // List<User> list = new List<User>();
                if (SqlCon.State == System.Data.ConnectionState.Closed)
                {
                    SqlCon.Open();

                }
                DynamicParameters param = new DynamicParameters();
                param.Add("@Username", username);
                param.Add("@Password", password);
                user = SqlCon.Query<User>("Login", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                isAdmin = user.IsAdmin;


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                SqlCon.Close();
            }
            return isAdmin;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
            User User = CheckLogin(username, password);
            if(User!=null)
            {
                if(CheckRole(User.Username,User.Password))
                {
                    IBook book = new IBook();
                    book.Visible = true;
                   // this.Close();
             
                }
                else
                {
                    IUser user = new IUser();
                    user.Visible = true;
                   // this.Close();                
                    user.txtUsername.Text = User.Username;
                    user.txtPassword.Text = User.Password;
                    user.txtUsername.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("USERNAME OR PASSWORD IS WRONG", "ERROR");
            }
       
           
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
