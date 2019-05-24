using ProductLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagement
{
    public partial class Form1 : Form
    {
        private ProductDB db = new ProductDB();
        private DataTable dt;
       // private string strConnection;
        private bool isAddNew = false;

        public Form1()
        {
            InitializeComponent();
            //strConnection = ConfigurationManager.ConnectionStrings["SaleDB"].ConnectionString;
            //db.strConnection = strConnection;
            init();
        }

        private void ClearErrorProvider()
        {
            errQuantity.Clear();
            errPrice.Clear();
        }

        private void init()
        {
            
            List<Product> products = db.GetProductList();
            dt = products.ConvertListToDataTable();

            txtProductID.ReadOnly = true;

            txtProductID.DataBindings.Clear();
            txtProductName.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtUnitPrice.DataBindings.Clear();

            txtProductID.DataBindings.Add(new Binding("Text", dt, "ID"));
            txtProductName.DataBindings.Add("Text", dt, "Name");
            txtQuantity.DataBindings.Add("Text", dt, "Quantity");
            txtUnitPrice.DataBindings.Add("Text", dt, "UnitPrice");

            dgvProducts.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ClearErrorProvider();
            int ID = 0;
            int.TryParse(txtProductID.Text, out ID);
            string Name = txtProductName.Text;
            int Quantity = 0;
            decimal Price = 0;
            try
            {
                Quantity = int.Parse(txtQuantity.Text);
            }
            catch (Exception)
            {
                errQuantity.SetError(txtQuantity, "Quantity must be an integer");
                return;
            }
            try
            {
                Price = decimal.Parse(txtUnitPrice.Text);
            }
            catch (Exception)
            {
                errPrice.SetError(txtUnitPrice, "Price must be an float");
                return;
            }
            var p = new Product(ID, Name, Quantity, Price);
            if (isAddNew)
            {
                if (db.AddNewProduct(p))
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            else
            {
                if (db.UpdateProduct(p))
                {
                    MessageBox.Show("Successfully");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            btnRefresh_Click(null, null);

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //ClearErrorProvider();
            //isAddNew = true;
            //txtProductID.Text = string.Empty;
            //txtProductName.Text = string.Empty;
            //txtQuantity.Text = string.Empty;
            //txtUnitPrice.Text = string.Empty;
            try
            {
                int ProID = int.Parse(txtProductID.Text);
                string ProName = txtProductName.Text;
                float Price = float.Parse(txtUnitPrice.Text);
                int Quantity = int.Parse(txtQuantity.Text);
                Product p = new Product { ID=ProID, Name =ProName,UnitPrice=Price,Quantity=Quantity};
                db.Products
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClearErrorProvider();
            int Id = int.Parse(txtProductID.Text);
            var p = new Product()
            {
                ID = Id
            };
            if (db.RemoveProduct(p))
            {
                MessageBox.Show("Successfully");
            }
            else
            {
                MessageBox.Show("Fail");
            }
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearErrorProvider();
            init();
        }

        private void dgvProducts_Click(object sender, EventArgs e)
        {
            ClearErrorProvider();
            isAddNew = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string SearchID = txtSearchValue.Text.Trim();
                DataTable SearchDataTable = new DataTable();
                var RowTable = dt.Select("ID = " + SearchID).ElementAt(0);
                if (RowTable != null)
                {
                    int ID = RowTable.Field<int>("ID");
                    string Name = RowTable.Field<string>("Name");
                    int Quantity = RowTable.Field<int>("Quantity");
                    float Price = RowTable.Field<float>("UnitPrice");
                    float total = RowTable.Field<float>("SubTotal");

                    string msg = string.Format($"ID: {ID}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Total: {total}");
                    MessageBox.Show(msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ID in search box must be an integer: " + ex.Message);
                return;
            }
        }
    }

    public static class Convert
    {
        public static DataTable ConvertListToDataTable(this List<Product> products)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Quantity", typeof(int));
            dataTable.Columns.Add("UnitPrice", typeof(float));
            dataTable.Columns.Add("SubTotal", typeof(float));

            foreach (var product in products)
            {
                dataTable.Rows.Add(product.ID,
                                    product.Name,
                                    product.Quantity,
                                    product.UnitPrice,
                                    product.Quantity * product.UnitPrice);
            }
            return dataTable;
        }
    }
}
