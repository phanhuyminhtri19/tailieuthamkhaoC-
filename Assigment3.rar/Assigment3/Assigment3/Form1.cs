using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductLibrary;

namespace Assigment3
{
    public partial class Form1 : Form
    {
        // ProductLibrary.DBModel model = new DBModel();
        Product product = new Product();
        //DBModel model = new DBModel();
        ProductManagement manage = new ProductManagement();
        int pos = 0;
        // IProduct product = new IProduct();
        // IProduct iproduct;  
        List<Product> ListProduct = null;
        public Form1()
        {
            InitializeComponent();
            ViewOrSearch();
            Clear();
            // iproduct = _iproduct;
            ListProduct = manage.GetAllProducts();
        }

        void Clear()
        {
            //txtId.Text = "";
            txtName.Text = "";
            txtUnit.Text = "";
            txtQuantity.Text = "";
            btnSave.Text = "Save";
            btnSave.Enabled = true;
            btnRemove.Enabled = false;
            product.ProductId = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // int  ProductId = int.Parse(txtId.Text.Trim());
            string error = "";
            if (txtName.Text.Trim().Length == 0)
            {
                error += "Name cannot be null \n";
            }
            if (txtQuantity.Text.Trim().Length == 0)
            {
                error += "Quantity cannot be null \n";
            }
            if (txtUnit.Text.Trim().Length == 0)
            {
                error += "Unit cannot be null \n";
            }
            if (error != null && !error.Equals(""))
            {
                MessageBox.Show(error, "ERROR");
                // MessageBox.Show()
            }
            else
            {
                string ProductName = txtName.Text.Trim();
                double UnitPrice = double.Parse(txtUnit.Text.Trim());
                int Quantity = int.Parse(txtQuantity.Text.Trim());
                product.ProductName = ProductName;
                product.UnitPrice = UnitPrice;
                product.Quantity = Quantity;
                if (product.ProductId == 0)
                {
                    if (manage.AddNew(product))
                    {
                        MessageBox.Show("Added Successfully!!!");
                        ViewOrSearch();
                    }
                }
                else
                {
                    if (manage.AddNew(product))
                    {
                        MessageBox.Show("Updated Successfully!!!");
                        ViewOrSearch();
                    }
                }

                Clear();
            }
        }
        void ViewOrSearch()
        {
            dataView.DataSource = manage.GetAllProducts();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String Name = txtSearch.Text.Trim();
            if (Name.Length == 0)
            {
                MessageBox.Show("Please input an ID to search!!!");
            }
            else
            {
                if (manage.FindProduct(int.Parse(Name)).Count == 0)
                {
                    MessageBox.Show("Your Id cannot be found");
                }
                else
                {
                    // dataView.DataSource = manage.FindProduct(int.Parse(Name));
                    List<Product> list = manage.FindProduct(int.Parse(Name));
                    SearchDetail detail = new SearchDetail();
                    detail.Show();
                    detail.txtName.Text = list[0].ProductName.ToString();
                    detail.txtUnit.Text = list[0].Quantity.ToString();
                    detail.txtPrice.Text = list[0].UnitPrice.ToString();
                    detail.txtTotal.Text = list[0].SubTotal.ToString();
                }
            }
        }

        private void dataView_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            product.ProductId = Int32.Parse(dataView.CurrentRow.Cells[0].Value.ToString());
            product.ProductName = dataView.CurrentRow.Cells[1].Value.ToString();
            product.UnitPrice = Double.Parse(dataView.CurrentRow.Cells[2].Value.ToString());
            product.Quantity = Int32.Parse(dataView.CurrentRow.Cells[3].Value.ToString());
            txtName.Text = product.ProductName;
            txtUnit.Text = product.UnitPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            btnSave.Text = "Update";
            btnRemove.Enabled = true;
        }
        void showData(int pos)
        {
            product.ProductId = Int32.Parse(dataView.Rows[pos].Cells[0].Value.ToString());
            product.ProductName = dataView.Rows[pos].Cells[1].Value.ToString();
            product.UnitPrice = Double.Parse(dataView.Rows[pos].Cells[2].Value.ToString());
            product.Quantity = Int32.Parse(dataView.Rows[pos].Cells[3].Value.ToString());
            txtName.Text = product.ProductName;
            txtUnit.Text = product.UnitPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            btnSave.Text = "Update";
            btnRemove.Enabled = true;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {

            // manage.RemoveProduct(product.ProductId)
            if (manage.RemoveProduct(product.ProductId))
            {
                ViewOrSearch();
                btnSave.Enabled = false;
                MessageBox.Show("You removed successfully!!!");
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < dataView.Rows.Count)
            {
                showData(pos);
            }
            else
            {
                pos = 0;
                showData(pos);
            }
        }

    }
}
