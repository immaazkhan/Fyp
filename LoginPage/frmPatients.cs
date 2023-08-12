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
    public partial class frmPatients : Form
    {
        DatabaseManager db = new DatabaseManager();
        DataTable _dtPatient;
        public frmPatients()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text == "")
            {
                MessageBox.Show("Please enter vendor name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtPatientName.Focus();
                return;
            }

            try {
                string patientName = txtPatientName.Text; // Gets text from txtPatientName TextBox
                string mobileNo = txtMobileNo.Text; // Gets text from txtMobileNo TextBox
                int age = Convert.ToInt32(txtAge.Text); // Gets text from txtAge TextBox and converts to int
                string gender = radioButton1.Checked ? "Male" : "Female"; // Checks the selected radio button
                string address = txtAddress.Text; // Gets text from txtAddress TextBox
                string problem = txtProblem.Text; // Gets text from txtProblem TextBox
                string doctor = txtDoctor.Text; // Gets text from txtDoctor TextBox
                double fees = Convert.ToDouble(txtFees.Text);
                decimal Patientid = db.GetNextPKValue("Patient_ID", "Patients");
                string sql = "INSERT INTO DSMC_Hospital_Management_System.dbo.Patients " +
                   "(Date, Patient_ID, Patient_Name, Mobile_No, Age, Gender, Address, Problem, Doctor, Fees) " +
                   "VALUES " +
                   "('" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + Patientid + ", '" + patientName + "', '" + mobileNo + "', " +
                   age + ", '" + gender + "', '" + address + "', '" + problem + "', '" + doctor + "', " + fees + ")";
                db.ExecuteNonQuery(sql);
                MessageBox.Show("Data inserted Sucessfully");
                this.Close();
  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
          
        }
       
    }
}
