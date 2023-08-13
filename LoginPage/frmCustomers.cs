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
    public partial class frmCustomers : Form
    {
        private static frmCustomers _DefaultInstance;
        public static frmCustomers DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmCustomers();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }

        public frmCustomers()
        {
            InitializeComponent();
        }
        public DataRow EditCustomer
        {
            get;
            set;
        }
        private void frmCustomers_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
        private void RetriveData()
        {
            if (this.EditCustomer != null)
            {
                this.txtCustomerName.Text = this.EditCustomer["Customer_Name"]?.ToString();

            }
        }
            private void Btnsave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtCustomerName.Text== "")
            {
                MessageBox.Show("Please enter customer name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCustomerName.Focus();
                return;
            }
            try
            {

                decimal customerID;
                int x;
             
                //string customerName = txtCustomerName.Text.Trim();
                if (this.EditCustomer == null)
                {


                    // Get the values from the text boxes on the form.
                    customerID = db.GetNextPKValue("Customer_ID", "Customers");

                    // Use string concatenation for the SQL query (not recommended due to security risks).
                    string sql = "INSERT INTO Customers (Customer_ID, Customer_Name) "
                               + "VALUES ('" + customerID + "', '" + txtCustomerName.Text.Trim() + "')";


                 x=   db.ExecuteNonQuery(sql);
                    if (x == 1)
                    {
                        MessageBox.Show("successfully inserted");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                
                }
                else
                {
                   decimal customerid = decimal.Parse(this.EditCustomer["Customer_ID"].ToString());
                    string sql = "UPDATE Customers SET Customer_Name = '" + txtCustomerName.Text.Trim() + "' WHERE Customer_ID = '" + customerid+ "'";
                    db.ExecuteDataTable(sql);
                    MessageBox.Show("successfully Updated");
                }
        
                
           
                this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

