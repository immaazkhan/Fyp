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
        public DataRow EditManufactures
        {
            get;
            set;
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



                decimal manufactureId;
                int x;
                if (this.EditManufactures == null)
                {
                     manufactureId = db.GetNextPKValue("Manufacturer_ID", "Manufacturers");

                    string manufacturerName = txtManufacturesName.Text.Trim();

                    string sql = "INSERT INTO Manufacturers (Manufacturer_ID, Manufacturer_Name) " +
                                 "VALUES (" + manufactureId + ", '" + manufacturerName + "')";
                    x = db.ExecuteNonQuery(sql);
                    if (x == 1)
                    {
                        MessageBox.Show("successfully inserted");
                        this.DialogResult = DialogResult.OK;
                        this.Close();

                    }
                }
                else
                {
                    manufactureId = decimal.Parse(this.EditManufactures["Manufacturer_ID"].ToString());
                    string sql = "UPDATE  Manufacturers SET " +
                                 "Manufacturer_Name = '" + txtManufacturesName.Text.Trim() + "' " +
                                 "WHERE Manufacturer_ID = " + manufactureId;
                    db.ExecuteNonQuery(sql);

                }

              


                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RetriveData()
        {
            if (this.EditManufactures != null)
            {
                this.txtManufacturesName.Text = this.EditManufactures["Manufacturer_Name"]?.ToString();
             
            }
        }
        private void frmManufacturers_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
    }
}
