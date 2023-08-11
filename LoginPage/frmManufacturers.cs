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
    public partial class frmManufacturers : Form
    {
        public frmManufacturers()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtManufacturesName.Text == "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtManufacturesName.Focus();
                return;
            }
            try
            {




           
                decimal manufactureId = db.GetNextPKValue("Manufacturer_ID", "Manufacturers");
string manufacturerName = txtManufacturesName.Text.Trim();

string sql = "INSERT INTO Manufacturers (Manufacturer_ID, Manufacturer_Name) " +
             "VALUES (" + manufactureId + ", '" + manufacturerName + "')";

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
