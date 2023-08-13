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
        public DataRow EditProductCatagry
        {
            get;
            set;
        }
        public frmProductCategories()
        {
            InitializeComponent();
        }

        private void frmProduct_Categories_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
        private void RetriveData()
        {
            if (this.EditProductCatagry != null)
            {
                this.txtProductCategoryName.Text = this.EditProductCatagry["Product_Category_Name"]?.ToString();
                //this.txtCity.Text = this.EditVender["City"]?.ToString();
                //this.txtMobileNo.Text = this.EditVender["Mobile_No"]?.ToString();
                //this.txtContactPerson.Text = this.EditVender["Contact_Person"]?.ToString();
                //this.txtPostalAddress.Text = this.EditVender["Postal_Address"]?.ToString();
            }
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



                decimal productCatagryid;
                int x;
                // Get the values from the text boxes on the form.
                if (this.EditProductCatagry == null)
                {
                    productCatagryid = db.GetNextPKValue("Product_Category_ID", "Product_Categories");
                    string productCatagryname = txtProductCategoryName.Text.Trim();

                    // Use string concatenation for the SQL query (not recommended due to security risks).
                    string sql = "INSERT INTO Product_Categories (Product_Category_ID, Product_Category_Name) "
                               + "VALUES (" + productCatagryid + ", '" + productCatagryname + "')";


                  x=  db.ExecuteNonQuery(sql);
                    if (x == 1)
                    {
                        MessageBox.Show("successfully inserted");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                else
                {
                    productCatagryid =decimal.Parse(this.EditProductCatagry["Product_Category_ID"].ToString());
                    string sql = "UPDATE Product_Categories "
                   + "SET Product_Category_Name = '" + txtProductCategoryName.Text.Trim() + "' "
                  + "WHERE Product_Category_ID = " + productCatagryid;
                    db.ExecuteNonQuery(sql);
                    MessageBox.Show("data updated sucessfully");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
