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
    public partial class frmDoctors : Form
    {
        public frmDoctors()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
          decimal doctoreid=  db.GetNextPKValue("Doctor_ID", "Doctors");
            string sql = "INSERT INTO Doctors " +
             "(Doctor_ID, Doctor_Name, CNIC, Mobile_No, Email_Address, License_No, Designation_ID, Gender, Salary) " +
             "VALUES ('" + doctoreid + "', '" + txtDoctorName.Text + "', '" + txtCNIC.Text + "', " +
             "'" + txtMobileNo.Text + "', '" + txtEmailAddress.Text + "', '" + txtLicNo.Text + "', " +
             "'" + txtDesignationID.Text + "', '" + (radioButton1.Checked ? "Male" : "Female") + "', " +
             txtSalary.Text + ")";
            db.ExecuteNonQuery(sql);
        }
    }
}
