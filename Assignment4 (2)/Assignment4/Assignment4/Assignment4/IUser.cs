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
    public partial class IUser : Form
    {
        SqlConnection SqlCon =
          new SqlConnection(@"Data Source=TRIPHMSE62951\SQLEXPRESS;initial Catalog=BookDB;Integrated Security = True;");
        public IUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // User user = new User();
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
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
                // user = SqlCon.Query<User>("Login", param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                int result = SqlCon.Execute("EditUser", param,commandType: System.Data.CommandType.StoredProcedure);
                if(result>0)
                {
                    MessageBox.Show("Updated successfully");
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

        private void IUser_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
