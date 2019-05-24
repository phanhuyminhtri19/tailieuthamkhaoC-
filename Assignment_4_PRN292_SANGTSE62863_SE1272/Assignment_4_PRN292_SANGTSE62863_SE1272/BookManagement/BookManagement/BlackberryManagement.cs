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
using ClassLibrary;

namespace BookManagement
{
    public partial class BlackberryManagement : Form
    {
        private bool addNew;
        public BlackberryManagement()
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
            BlackberryData db = new BlackberryData();
            DataTable dt = db.GetProductsList();

            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtManufacturer.DataBindings.Clear();
            txtModel.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtYear.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dt, "LambID");
            txtName.DataBindings.Add("Text", dt, "LambName");
            txtManufacturer.DataBindings.Add("Text", dt, "Manufacturer");
            txtModel.DataBindings.Add("Text", dt, "Model");
            txtPrice.DataBindings.Add("Text", dt, "Price");
            txtYear.DataBindings.Add("Text", dt, "ReleasedYear");

            dgvProducts.DataSource = dt;
            dgvProducts.Rows[0].Selected = true;
        }

        private void BindingData()
        {
            int index = dgvProducts.SelectedCells[0].OwningRow.Index;
            txtID.Text = dgvProducts.Rows[index].Cells[0].Value.ToString();
            txtName.Text = dgvProducts.Rows[index].Cells[1].Value.ToString();
            txtManufacturer.Text = dgvProducts.Rows[index].Cells[2].Value.ToString();
            txtModel.Text = dgvProducts.Rows[index].Cells[3].Value.ToString();
            txtPrice.Text = dgvProducts.Rows[index].Cells[4].Value.ToString();
            txtYear.Text = dgvProducts.Rows[index].Cells[5].Value.ToString();

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtManufacturer.Text = "";
            txtModel.Text = "";
            txtPrice.Text = "";
            txtYear.Text = "";
            addNew = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (addNew)
            {
                string name = txtName.Text;
                float price = float.Parse(txtPrice.Text);
                BlackberryData db = new BlackberryData();
                if (db.AddNewProduct(new Blackberry(lambID, name, manu, model, price, releasedYear)))
                {
                    MessageBox.Show("Save successful");
                }
                else
                {
                    MessageBox.Show("Save fail.");
                }
                setData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string manu = txtManufacturer.Text;
            string model = txtModel.Text;
            float price = float.Parse(txtPrice.Text);
            string year = txtYear.Text;
            BlackberryData db = new BlackberryData();
            if(db.UpdateProducts(new Blackberry(id, name, price)))
            {
                MessageBox.Show("Update successful");
            }
            else
            {
                MessageBox.Show("Update fail.");
            }
            
            setData();
        }

        private void txtFilt_TextChanged(object sender, EventArgs e)
        {
                BlackberryData db = new BlackberryData();
                if (txtFilt.Text.Equals(""))
                {
                    DataTable dt = db.GetProductsList();
                    dgvProducts.DataSource = dt;
                }
                else
                {
                    DataTable dt = db.GetProductsInFilt(txtFilt.Text);
                    dgvProducts.DataSource = dt;
                }
        }


    }
}
