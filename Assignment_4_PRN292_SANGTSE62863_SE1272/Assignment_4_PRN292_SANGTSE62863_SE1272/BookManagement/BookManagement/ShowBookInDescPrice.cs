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

namespace BookManagement
{
    public partial class ShowBookInDescPrice : Form
    {
        public ShowBookInDescPrice()
        {
            InitializeComponent();
        }

        private void ShowBookInDescPrice_Load(object sender, EventArgs e)
        {
            DbHelper db = new DbHelper();
            dgvShow.DataSource = db.GetBookOrderByPrice();
        }


    }
}
