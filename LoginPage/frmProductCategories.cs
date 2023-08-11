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
    public partial class frmProductCategories : Form
    {
        private static frmProductCategories _DefaultInstance;
        public static frmProductCategories DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmProductCategories();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        public frmProductCategories()
        {
            InitializeComponent();
        }

        private void frmProduct_Categories_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtProductCategoryName.Text == "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtProductCategoryName.Focus();
                return;
            }
            try
            {




                // Get the values from the text boxes on the form.
                decimal customerID = db.GetNextPKValue("Product_Category_ID", "Product_Categories");
                string customerName =txtProductCategoryName.Text.Trim();
      
                // Use string concatenation for the SQL query (not recommended due to security risks).
                string sql = "INSERT INTO Product_Categories (Product_Category_ID, Product_Category_Name) "
                           + "VALUES (" + customerID + ", '" + customerName + "')";


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
