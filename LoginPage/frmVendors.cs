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
    public partial class frmVendors : Form
    {

        public frmVendorsMgt frmVendorsMgt;
        public frmVendors(frmVendorsMgt frmVendorsMgt)
        {
            InitializeComponent();
            this.frmVendorsMgt = frmVendorsMgt;
        }
        /// <summary>
        /// 
        /// </summary>
        public DataRow EditVender
        {
            get;
            set;
        }

     
        private void frmVendors_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
        private void RetriveData()
        {
            if (this.EditVender != null)
            {
                this.txtVendorName.Text = this.EditVender["Vendor_Name"]?.ToString();
                this.txtCity.Text = this.EditVender["City"]?.ToString();
                this.txtMobileNo.Text = this.EditVender["Mobile_No"]?.ToString();
                this.txtContactPerson.Text = this.EditVender["Contact_Person"]?.ToString();
                this.txtPostalAddress.Text = this.EditVender["Postal_Address"]?.ToString();
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtVendorName.Text == "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtVendorName.Focus();
                return;
            }

            try
            {
                decimal venderid;
                int x;
                if (this.EditVender == null)
                {
                    venderid = db.GetNextPKValue("Vendor_ID", "Vendors");
                    string sql = "INSERT INTO Vendors (Vendor_ID, Vendor_Name, Contact_Person, Postal_Address, Mobile_No, City)"
                               + " VALUES (" + venderid + ", '" + txtVendorName.Text.Trim() + "', '" + txtContactPerson.Text.Trim() + "', '" + txtPostalAddress.Text.Trim() + "', '" + txtMobileNo.Text.Trim() + "', '" + txtCity.Text.Trim() + "')";
                    x=db.ExecuteNonQuery(sql);
                    if (x == 1)
                    {
                        MessageBox.Show("successfully inserted");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                else
                {
                    venderid = decimal.Parse(this.EditVender["Vendor_ID"].ToString());
                    string sql = "UPDATE Vendors SET " +
                    "Vendor_Name = '" + txtVendorName.Text.Trim() + "', " +
                     "Contact_Person = '" + txtContactPerson.Text.Trim() + "', " +
                     "Postal_Address = '" + txtPostalAddress.Text.Trim() + "', " +
                     "Mobile_No = '" + txtMobileNo.Text.Trim() + "', " +
                     "City = '" + txtCity.Text.Trim() + "'" +
                     " WHERE Vendor_ID = " + venderid;
                    db.ExecuteNonQuery(sql);
                   
                }
             
                this.Close();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
