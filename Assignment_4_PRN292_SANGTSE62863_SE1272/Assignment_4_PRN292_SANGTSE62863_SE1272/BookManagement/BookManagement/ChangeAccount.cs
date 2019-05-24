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
    public partial class ChangeAccount : Form
    {
        public ChangeAccount(string username, string password)
        {
            InitializeComponent();
            lbUsername.Text = username;
            txtPassword.Text = password;
        }

        private void ChangeAccount_Load(object sender, EventArgs e)
        {
            
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string username = lbUsername.Text;
            string password = txtPassword.Text;
            DbHelper db = new DbHelper();
            db.updatePassword(username, password);
            MessageBox.Show("Done");
        }

        public void ShowForm()
        {
            Login frm = new Login();
            Application.Run(frm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread thread = new Thread(() => ShowForm());
            thread.Start();
            this.Close();
        }
    }
}
