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

        private void frmCustomers_Load(object sender, EventArgs e)
        {

        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtCustomerID.Text== "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtCustomerID.Focus();
                return;
            }
            try
            {


            

                // Get the values from the text boxes on the form.
                string customerID = txtCustomerID.Text.Trim();
                string customerName = txtCustomerName.Text.Trim();

                // Use string concatenation for the SQL query (not recommended due to security risks).
                string sql = "INSERT INTO Customers (Customer_ID, Customer_Name) "
                           + "VALUES ('" + customerID + "', '" + customerName + "')";


                db.ExecuteNonQuery(sql);
        
                MessageBox.Show("successfully inserted");
           
                this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

