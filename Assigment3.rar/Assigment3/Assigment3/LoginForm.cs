using ProductLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assigment3
{
    public partial class LoginForm : Form
    {
        Product product = new Product();
        //DBModel model = new DBModel();
        ProductManagement manage = new ProductManagement();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();          
            if (manage.checkLogin(username, password))
            {
                if(manage.checkRole(username,password))
                {
                    Form1 _form1 = new Form1();
                    _form1.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("User interface is not found!!!");
                }
             
            }
            else
            {
                MessageBox.Show("Username or password maybe wrong!!!","ERROR");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
