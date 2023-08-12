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
    public partial class frmSales : Form
{
        DatabaseManager db = new DatabaseManager();
    private static frmSales _DefaultInstance;
    public static frmSales DefaultInstance
    {
        get
        {
            if (_DefaultInstance == null)
                _DefaultInstance = new frmSales();
            return _DefaultInstance;
        }
        private set
        {
            _DefaultInstance = value;
        }

    }


    public frmSales()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {

    }

    private void frmSales_Load(object sender, EventArgs e)
    {
            string customers = "select * from Customers";
            cmbCutsomer.DisplayMember = "Customer_Name";
            cmbCutsomer.ValueMember = "Customer_ID";
            cmbCutsomer.DataSource = db.ExecuteDataTable(customers);
            string product = "select * from Products";
           
            cmbProduct.DisplayMember = "Product_Name";
            cmbProduct.ValueMember = "Product_ID";
            cmbProduct.DataSource = db.ExecuteDataTable(product);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal nextID=db.GetNextPKValue("sales-ID","Sales");
                // Get the values from the text boxes on the form.
                //string customerID = txtCustomerID.Text.Trim();
                //string customerName = txtSales.Text.Trim(); 
                string invoiceDiscount = txtInvoiceDiscount.Text.Trim();
                DateTime invoiceDate = dtp.Value;

            
                //string salesDetailID = txtSalesDetailID.Text.Trim();
                string productID = txtProductID.Text.Trim();
                int quantity = int.Parse(Quantity.Text.Trim());
                decimal unitPrice = decimal.Parse(txtUnitPrice.Text.Trim());
           
     
                //string sql = "INSERT INTO Vendors (sales_ID, Customer_ID, Invoice_Date, Invoice_Discount, Sales_Details_ID, Purchase_ID)"
                //       + " VALUES (" + nextID + ", '" + customerName + "', '" + invoiceDiscount + "', '" + txtPostalAddress.Text.Trim() + "', '" + txtMobileNo.Text.Trim() + "', '" + txtCity.Text.Trim() + "')";
                //db.ExecuteNonQuery(sql);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the processing.
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

