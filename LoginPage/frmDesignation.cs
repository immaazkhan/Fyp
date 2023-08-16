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
    public partial class frmDesignation : Form
    {
        public DataRow EditDesignation
        {
            get;
            set;
        }
        public frmDesignation()
        {
            InitializeComponent();
        }

        private void frmDesignation_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
        private void RetriveData()
        {
            if (this.EditDesignation != null)
            {
                this.txtDesignationName.Text = this.EditDesignation["Manufacturer_Name"]?.ToString();

            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            if (txtDesignationName.Text == "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtDesignationName.Focus();
                return;
            }
            try
            {



                decimal designationis;
                int x;
                if (this.EditDesignation == null)
                {
              
                    designationis = db.GetNextPKValue("Designation_ID", "Designation");

                    string manufacturerName = txtDesignationName.Text.Trim();

                    string sql = "INSERT INTO Designation (Designation_ID, Designation_Name) " +
                                 "VALUES (" + designationis + ", '" + manufacturerName + "')";
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
                    designationis = decimal.Parse(this.EditDesignation["Designation_ID"].ToString());
                    string sql = "UPDATE  Designation SET " +
                                 "Designation_Name = '" + txtDesignationName.Text.Trim() + "' " +
                                 "WHERE Designation_ID = " + designationis;
                    db.ExecuteNonQuery(sql);

                }




                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
