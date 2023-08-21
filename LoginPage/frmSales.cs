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

        decimal UpdateGrandTotal = 0;
        decimal netTotal = 0;
        decimal invoiceDiscount = 0;
        #region DatasetforSales
        DataSet _dSSales;
        DataTable _dtSales;
        DataTable _dtSalesDetails;
        DataTable _dtCustomers;
        DataTable _dtProduct;

        /// <summary>
        /// gets or sets the edit sales data row for modification/update
        /// </summary>
        public DataRow EditSale
        {
            get;
            set;
        }

        #endregion
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
            //dgv.Columns.Add("ProductIDColumn", "Product ID");
            //dgv.Columns.Add("QuantityColumn", "Quantity");
            //dgv.Columns.Add("UnitPriceColumn", "Unit Price");

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
            RetrieveCustomer();
            RetrieveProduct();
            dtp.Value = DateTime.Today;

        }
        private void RetrieveProduct()
        {
            //string product = "SELECT product.*, CONCAT(product.Product_Name, ' (', productCatagry.Product_Category_Name, ')') AS Product_Full_Name FROM  [DSMC_Hospital_Management_System].[dbo].Products as product INNER JOIN [DSMC_Hospital_Management_System].[dbo].[Product_Categories] as productCatagry ON productCatagry.Product_Category_ID = product.Product_Category_ID ORDER BY   Product_Full_Name ASC";
            string sql = @"
    SELECT 
        product.*, 
        CONCAT(product.Product_Name, ' (', productCatagry.Product_Category_Name, ')') AS Product_Full_Name 
    FROM  
        [DSMC_Hospital_Management_System].[dbo].Products as product 
    INNER JOIN 
        [DSMC_Hospital_Management_System].[dbo].[Product_Categories] as productCatagry 
    ON 
        productCatagry.Product_Category_ID = product.Product_Category_ID 
    ORDER BY   
        CASE WHEN product.Product_ID = 0 THEN 0 ELSE 1 END, Product_Full_Name ASC;
";
            cmbProduct.DisplayMember = "Product_Full_Name";
            cmbProduct.ValueMember = "Product_ID";
            cmbProduct.DataSource = db.ExecuteDataTable(sql);
        }
        private void RetrieveCustomer()
        {
            string sql = "select * from Customers ORDER BY Customer_Name ASC";
            cmbCutsomer.DisplayMember = "Customer_Name";
            cmbCutsomer.ValueMember = "Customer_ID";
            cmbCutsomer.DataSource = db.ExecuteDataTable(sql);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
           
            if (cmbProduct.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cmbProduct.Focus();
                return;
            }
           else  if (txtpayment.Text == "")
            {
                MessageBox.Show("Please enter paymnet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtpayment.Focus();
                return;
            }

            try
            {
                
                decimal salesdetailsid = db.GetNextPKValue("Sale_Details_ID", "SalesDetails");
                decimal salesID = db.GetNextPKValue("sales_ID", "Sales");
                string customerName = cmbCutsomer.SelectedValue.ToString();
                string invoiceDiscount = txtInvoiceDiscount.Text.Trim();
                DateTime invoiceDate = dtp.Value;
                string productName = cmbProduct.SelectedValue.ToString();

                string payment = txtpayment.Text.Trim();
              
            
                decimal quantity = decimal.Parse(txtQuantity.Text);

                decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
                decimal grandTotal = decimal.Parse(txtGrandTotal.Text);

                string sql = "INSERT INTO Sales (sales_ID, Customer_ID, Invoice_Date, Invoice_Discount, Quantity, Unit_Price, invice_total, payment)"
                  + " VALUES (" + salesID + ", '" + customerName + "', '" + invoiceDate.ToString("yyyy-MM-dd") + "', '" + invoiceDiscount + "', " + quantity + ", " + unitPrice + ", " + grandTotal + ", " + payment + ")";
                db.ExecuteNonQuery(sql);
     
                string sqlSD = "INSERT INTO SalesDetails (Sale_Details_ID, product_ID, Quantity, Unit_Price)"
                               + " VALUES (" + salesdetailsid + ", " + productName + ", " + quantity + ", " + unitPrice + ")";
                db.ExecuteNonQuery(sqlSD);

                string sqlUpdateS = "UPDATE Sales " +
                                   "SET Sales_Details_ID = " + salesdetailsid + " " +
                                   "WHERE Sales_ID = " + salesID;
                db.ExecuteNonQuery(sqlUpdateS);
                string sqlUpdateSD = "UPDATE SalesDetails " +
                               "SET Sales_ID= " + salesID + " " +
                               "WHERE Sale_Details_ID  = " + salesdetailsid;
                MessageBox.Show("successfully inserted");
                this.DialogResult = DialogResult.OK;
                this.Close();

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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCutsomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {
            txtNetTotal.Text = txtGrandTotal.Text;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal id = decimal.Parse(cmbProduct.SelectedValue.ToString());
            string sql = "select Sale_Price from Products where Product_ID=" + id;

            DatabaseManager databaseManager = new DatabaseManager();
            object result = databaseManager.ExecuteScalar(sql);

            if (result != null && result != DBNull.Value)
            {
                decimal salePrice = Convert.ToDecimal(result);
                txtUnitPrice.Text = salePrice.ToString();


            }
            else
            {
                // Handle the case where no result or null result is returned
                MessageBox.Show("Sale Price not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            decimal qty;
            if (decimal.TryParse(txtQuantity.Text, out qty))
            {
                decimal unitPrice;
                if (decimal.TryParse(txtUnitPrice.Text, out unitPrice))
                {
                    decimal totalprice = qty * unitPrice;
                    txtTotalPrice.Text = totalprice.ToString();
                }
                else
                {
                    txtTotalPrice.Text = "Invalid Unit Price";
                }
            }
            else
            {
                txtTotalPrice.Text = txtUnitPrice.Text;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please select Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.cmbProduct.Focus();
                return;
            }
            string productID = cmbProduct.Text;
            string quantity = string.IsNullOrEmpty(txtQuantity.Text) ? "1" : txtQuantity.Text;
            string unitPrice = txtUnitPrice.Text;

            decimal totalDecimalPrice;
            if (decimal.TryParse(unitPrice, out totalDecimalPrice))
            {
                string totalPrice = (string.IsNullOrEmpty(txtQuantity.Text)) ? txtUnitPrice.Text : (decimal.Parse(unitPrice) * decimal.Parse(quantity)).ToString();

                // Add the data to the DataGridView
                dgv.Rows.Add(productID, quantity, unitPrice, totalPrice);

                UpdateGrandTotal += decimal.Parse(totalPrice);
                txtGrandTotal.Text = UpdateGrandTotal.ToString();

            }
            else
            {
                MessageBox.Show("Invalid unit price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clear the TextBox controls after adding data
            //txtQuantity.Clear();
            //txtUnitPrice.Clear();
            //txtTotalPrice.Clear();
        }

        private void txtInvoiceDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal netTotal = decimal.Parse(txtNetTotal.Text);
            decimal invoiceDiscount;

            if (decimal.TryParse(txtInvoiceDiscount.Text, out invoiceDiscount))
            {
                // Calculate the new net total after subtracting the invoice discount
                decimal newNetTotal = netTotal - invoiceDiscount;

                // Update the txtNetTotal field with the new net total
                txtNetTotal.Text = newNetTotal.ToString();
            }
            else
            {
                // If invoice discount is empty, assume it's 0 and calculate net total accordingly
                //txtInvoiceDiscount.Text = ;
                txtNetTotal.Text = txtGrandTotal.Text;
            }

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtpayment.Text, out decimal payment) && decimal.TryParse(txtNetTotal.Text, out decimal nettotal))
            {
                decimal balance = nettotal - payment;

                // Set txtbalance.Text to an empty string if the balance is empty
                txtbalance.Text = (balance != decimal.MinValue) ? balance.ToString() : "";
            }
            else
            {
                // Handle the case where parsing fails
                txtbalance.Text = ""; // Set txtbalance to an empty string
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            DataGridViewRow selectedRow = this.dgv.CurrentRow;
            string id = selectedRow.Cells[0].Value.ToString();
           

            DialogResult result = MessageBox.Show("Are you sure you want to remove the product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dgv.Rows.Remove(selectedRow);
            }
        }
    }
    }
