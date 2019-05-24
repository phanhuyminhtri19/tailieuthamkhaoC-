using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDbClassLibrary;
using System.Threading;

namespace BookManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            DbHelper db = new DbHelper();
            int role = db.checkLogin(username, password);
            switch (role)
            {
                case -1:
                    MessageBox.Show("Username or password is invalid!");
                    break;
                case 0:
                    this.Hide();
                    Thread thread = new Thread(() => ShowForm(username, password));
                    thread.Start();
                    this.Close();
                    break;
                case 1:
                    this.Hide();
                    Thread threadAdmin = new Thread(() => ShowFormAdmin());
                    threadAdmin.Start();
                    this.Close();
                    break;
            }
        }

        public void ShowForm(string username, string password)
        {
            ChangeAccount frm = new ChangeAccount(username, password);
            Application.Run(frm);
        }

        public void ShowFormAdmin()
        {
            BookManagement frm = new BookManagement();
            Application.Run(frm);
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
