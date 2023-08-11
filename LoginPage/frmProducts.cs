using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPage
{
    public partial class frmProducts : Form
    {
        DatabaseManager db = new DatabaseManager();

        //private static frmProducts _DefaultInstance;
        //public static frmProducts DefaultInstance
        //{
        //    get
        //    {
        //        if (_DefaultInstance == null)
        //            _DefaultInstance = new frmProducts();
        //        return _DefaultInstance;
        //    }
        //    private set
        //    {
        //        _DefaultInstance = value;
          //}
    

        public frmProducts()
        {
            InitializeComponent();
         
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            string sql = "select * from Product_Categories";
            cmbCategory.DisplayMember = "Product_Category_Name";
            cmbCategory.ValueMember = "Product_Category_ID";
            cmbCategory.DataSource = db.ExecuteDataTable(sql);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtProductName.Text == "")
            {
                MessageBox.Show("Please enter Product name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductName.Focus();
                return;
            }

            try
            {
                //decimal productID = decimal.Parse(txtProductID.Text.Trim());
                string productName = txtProductName.Text.Trim();
                string price = txtprice.Text.Trim();
                decimal salesPrice = decimal.Parse(txtSalesPrice.Text.Trim());
                decimal openStock = decimal.Parse(txtOpenStock.Text.Trim());
                decimal currentStock = decimal.Parse(txtCurrentStock.Text.Trim());
                DateTime selectedDate = dateTimePicker.Value;

                string sql = "INSERT INTO Products (Product_ID, Product_Name, Price, Sales_Price, Open_Stock, Current_Stock, Date_Added)"
                           + " VALUES ('" + productName + "', '" + price + "', " + salesPrice + ", '"
                           + openStock + "', '" + currentStock + "', '" + selectedDate.ToString("yyyy-MM-dd") + "')";

                //               + " VALUES (" + venderid + ", '" + txtVendorName.Text.Trim() + "', '" + txtContactPerson.Text.Trim() + "', '" + txtPostalAddress.Text.Trim() + "', '" + txtMobileNo.Text.Trim() + "', '" + txtCity.Text.Trim() + "')";
                //    x = db.ExecuteNonQuery(sql);
                //    if (x == 1)
                db.ExecuteNonQuery(sql);
                //decimal venderid;
                //int x;
                //if (this.EditVender == null)
                //{
                //    venderid = db.GetNextPKValue("Vendor_ID", "Vendors");

                //    // Use the retrieved ID in your INSERT query.
                //    string sq
                //    {
                    MessageBox.Show("successfully inserted");
                      this.DialogResult = DialogResult.OK;
                      this.Close();

                //    }
                //}
                //else
                //{
                //    venderid = decimal.Parse(this.EditVender["Vendor_ID"].ToString());
                //    string sql = "UPDATE Vendors SET " +
                //    "Vendor_Name = '" + txtVendorName.Text.Trim() + "', " +
                //     "Contact_Person = '" + txtContactPerson.Text.Trim() + "', " +
                //     "Postal_Address = '" + txtPostalAddress.Text.Trim() + "', " +
                //     "Mobile_No = '" + txtMobileNo.Text.Trim() + "', " +
                //     "City = '" + txtCity.Text.Trim() + "'" +
                //     " WHERE Vendor_ID = " + venderid;
                //    db.ExecuteNonQuery(sql);

                //}


                //this.Close();
                //textBox1.Text = cmd.CommandText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtOpenStock_TextChanged(object sender, EventArgs e)
        {
            this.txtCurrentStock.Text = this.txtOpenStock.Text;
        }

        private void txtOpenStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 48 && e.KeyChar < 57||e.KeyChar==8)
            {
                //accet numaric key 
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSalesPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 48 && e.KeyChar < 57 || e.KeyChar == 8)
            {
                //accet numaric key 
            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
  

        }
    


