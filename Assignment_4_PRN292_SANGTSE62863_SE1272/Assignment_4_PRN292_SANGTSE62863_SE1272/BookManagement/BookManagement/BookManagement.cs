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
    public partial class BookManagement : Form
    {
        private bool addNew;
        public BookManagement()
        {
            InitializeComponent();
        }

        private void BookManagement_Load(object sender, EventArgs e)
        {
            setData();

            addNew = false;
        }

        private void setData()
        {
            DbHelper db = new DbHelper();
            DataTable dt = db.GetBookList();

            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPrice.DataBindings.Clear();

            txtId.DataBindings.Add("Text", dt, "BookId");
            txtName.DataBindings.Add("Text", dt, "BookName");
            txtPrice.DataBindings.Add("Text", dt, "BookPrice");

            dgvBook.DataSource = dt;
            dgvBook.Rows[0].Selected = true;
        }

        private void BindingData()
        {
            int index = dgvBook.SelectedCells[0].OwningRow.Index;
            txtId.Text = dgvBook.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dgvBook.Rows[index].Cells[1].Value.ToString();
            txtPrice.Text = dgvBook.Rows[index].Cells[2].Value.ToString();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                dgvBook.ClearSelection();
                dgvBook.Rows[0].Selected = true;
                BindingData();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (dgvBook.SelectedRows.Count > 0)
            {
                dgvBook.ClearSelection();
                dgvBook.Rows[dgvBook.Rows.Count - 1].Selected = true;
                BindingData();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int rowCount = dgvBook.Rows.Count;
            int index = dgvBook.SelectedCells[0].OwningRow.Index;
            if (index > 0)
            {
                dgvBook.ClearSelection();
                dgvBook.Rows[index - 1].Selected = true;
                BindingData();
            }  
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int rowCount = dgvBook.Rows.Count;
            int index = dgvBook.SelectedCells[0].OwningRow.Index;
            if (index < (dgvBook.Rows.Count - 1))
            {
                dgvBook.ClearSelection();
                dgvBook.Rows[index + 1].Selected = true;
                BindingData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";

            addNew = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (addNew)
            {
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                DbHelper db = new DbHelper();
                db.AddNewBook(new Book(0, name, price));
                MessageBox.Show("Done");
                setData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            string name = txtName.Text;
            float price = float.Parse(txtPrice.Text);
            DbHelper db = new DbHelper();
            db.UpdateBook(new Book(id, name, price));
            MessageBox.Show("Done");
            setData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(txtId.Text);
            DbHelper db = new DbHelper();
            db.RemoveBook(new Book(id, "", 0));
            MessageBox.Show("Done");
            setData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread thread = new Thread(() => ShowForm());
            thread.Start();
            this.Close();
        }

        public void ShowForm()
        {
            Login frm = new Login();
            Application.Run(frm);
        }

        private void btnShowSort_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => ShowBookOrderPriceForm());
            thread.Start();
        }

        public void ShowBookOrderPriceForm()
        {
            ShowBookInDescPrice frm = new ShowBookInDescPrice();
            Application.Run(frm);
        }

        private void txtFilt_TextChanged(object sender, EventArgs e)
        {
                DbHelper db = new DbHelper();
                if (txtFilt.Text.Equals(""))
                {
                    DataTable dt = db.GetBookList();
                    dgvBook.DataSource = dt;
                    lbTotal.Text = "";
                }
                else
                {
                    DataTable dt = db.GetBookInFilt(txtFilt.Text);
                    lbTotal.Text = "Total: " + dt.Compute("SUM(BookPrice)", dt.DefaultView.RowFilter);
                    dgvBook.DataSource = dt;
                }
        }


    }
}
