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
            try
            {
                decimal nextID = db.GetNextPKValue("sales-ID", "Sales");
                // Get the values from the text boxes on the form.
                //string customerID = txtCustomerID.Text.Trim();
                //string customerName = txtSales.Text.Trim(); 
                string invoiceDiscount = txtInvoiceDiscount.Text.Trim();
                DateTime invoiceDate = dtp.Value;


                //string salesDetailID = txtSalesDetailID.Text.Trim();
                string productID = txtProductID.Text.Trim();
                int quantity = int.Parse(txtQuantity.Text.Trim());
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
                txtTotalPrice.Text =txtUnitPrice.Text;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string productID = cmbProduct.Text;
            string quantity = txtQuantity.Text;
            string unitPrice = txtUnitPrice.Text;

            // Add the data to the DataGridView
            dgv.Rows.Add(productID, quantity, unitPrice);

            // Clear the TextBox controls after adding data
            txtProductID.Clear();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
            txtTotalPrice.Clear();
        }
    }
}
//private void InitializeComponent()
//{
//    this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
//    this.label2 = new System.Windows.Forms.Label();
//    this.txtDesignationName = new System.Windows.Forms.TextBox();
//    this.dtm = new System.Windows.Forms.DateTimePicker();
//    this.label1 = new System.Windows.Forms.Label();
//    this.panel1 = new System.Windows.Forms.Panel();
//    this.label3 = new System.Windows.Forms.Label();
//    this.comboBox1 = new System.Windows.Forms.ComboBox();
//    this.label4 = new System.Windows.Forms.Label();
//    this.textBox1 = new System.Windows.Forms.TextBox();
//    this.textBox2 = new System.Windows.Forms.TextBox();
//    this.panel1.SuspendLayout();
//    this.SuspendLayout();
// 
// flowLayoutPanel1
// 
//this.flowLayoutPanel1.Location = new System.Drawing.Point(554, 123);
//this.flowLayoutPanel1.Name = "flowLayoutPanel1";
//this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
//this.flowLayoutPanel1.TabIndex = 0;
// 
// label2
// 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.ForeColor = System.Drawing.Color.Black;
//            this.label2.Location = new System.Drawing.Point(13, 26);
//            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(169, 23);
//            this.label2.TabIndex = 54;
//            this.label2.Text = "Designation Name";
//            // 
//            // txtDesignationName
//            // 
//            this.txtDesignationName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.txtDesignationName.Location = new System.Drawing.Point(189, 23);
//            this.txtDesignationName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.txtDesignationName.Multiline = true;
//            this.txtDesignationName.Name = "txtDesignationName";
//            this.txtDesignationName.Size = new System.Drawing.Size(221, 36);
//            this.txtDesignationName.TabIndex = 55;
//            // 
//            // dtm
//            // 
//            this.dtm.Location = new System.Drawing.Point(489, 37);
//            this.dtm.Margin = new System.Windows.Forms.Padding(4);
//            this.dtm.Name = "dtm";
//            this.dtm.Size = new System.Drawing.Size(265, 22);
//            this.dtm.TabIndex = 56;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.ForeColor = System.Drawing.Color.Black;
//            this.label1.Location = new System.Drawing.Point(427, 36);
//            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(52, 23);
//            this.label1.TabIndex = 57;
//            this.label1.Text = "Date";
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.textBox2);
//            this.panel1.Controls.Add(this.textBox1);
//            this.panel1.Controls.Add(this.label4);
//            this.panel1.Controls.Add(this.comboBox1);
//            this.panel1.Controls.Add(this.label3);
//            this.panel1.Location = new System.Drawing.Point(17, 75);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(1342, 388);
//            this.panel1.TabIndex = 58;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.ForeColor = System.Drawing.Color.Black;
//            this.label3.Location = new System.Drawing.Point(4, 25);
//            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(78, 23);
//            this.label3.TabIndex = 59;
//            this.label3.Text = "Product";
//            // 
//            // comboBox1
//            // 
//            this.comboBox1.FormattingEnabled = true;
//            this.comboBox1.Location = new System.Drawing.Point(89, 24);
//            this.comboBox1.Name = "comboBox1";
//            this.comboBox1.Size = new System.Drawing.Size(200, 24);
//            this.comboBox1.TabIndex = 60;
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.ForeColor = System.Drawing.Color.Black;
//            this.label4.Location = new System.Drawing.Point(4, 87);
//            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(73, 23);
//            this.label4.TabIndex = 61;
//            this.label4.Text = "Quatity";
//            // 
//            // textBox1
//            // 
//            this.textBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBox1.Location = new System.Drawing.Point(84, 74);
//            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.textBox1.Multiline = true;
//            this.textBox1.Name = "textBox1";
//            this.textBox1.Size = new System.Drawing.Size(221, 36);
//            this.textBox1.TabIndex = 59;
//            // 
//            // textBox2
//            // 
//            this.textBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.textBox2.Location = new System.Drawing.Point(426, 12);
//            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
//            this.textBox2.Multiline = true;
//            this.textBox2.Name = "textBox2";
//            this.textBox2.Size = new System.Drawing.Size(221, 36);
//            this.textBox2.TabIndex = 62;
//            // 
//            // frmSales
//            // 
//            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
//            this.ClientSize = new System.Drawing.Size(1371, 676);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.label1);
//            this.Controls.Add(this.dtm);
//            this.Controls.Add(this.txtDesignationName);
//            this.Controls.Add(this.label2);
//            this.Controls.Add(this.flowLayoutPanel1);
//            this.Name = "frmSales";
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }
//    }
//}

