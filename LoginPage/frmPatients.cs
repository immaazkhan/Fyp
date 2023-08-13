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
        public DataRow EditProduct
        {
            get;
            set;
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

            try
            {
                string patientName = txtPatientName.Text; // Gets text from txtPatientName TextBox
                string mobileNo = txtMobileNo.Text; // Gets text from txtMobileNo TextBox
                int age = Convert.ToInt32(txtAge.Text); // Gets text from txtAge TextBox and converts to int
                string gender = radioButton1.Checked ? "Male" : "Female"; // Checks the selected radio button
                string address = txtAddress.Text; // Gets text from txtAddress TextBox
                string problem = txtProblem.Text; // Gets text from txtProblem TextBox
                string doctor = txtDoctor.Text; // Gets text from txtDoctor TextBox
                double fees = Convert.ToDouble(txtFees.Text);
                decimal Patientid;
                int x;
                if (this.EditProduct == null)
                {
                    
                    Patientid = db.GetNextPKValue("Patient_ID", "Patients");
                    string sql = "INSERT INTO DSMC_Hospital_Management_System.dbo.Patients " +
                       "(Date, Patient_ID, Patient_Name, Mobile_No, Age, Gender, Address, Problem, Doctor, Fees) " +
                       "VALUES " +
                       "('" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + Patientid + ", '" + patientName + "', '" + mobileNo + "', " +
                       age + ", '" + gender + "', '" + address + "', '" + problem + "', '" + doctor + "', " + fees + ")";
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
                    Patientid = decimal.Parse(this.EditProduct["Patient_ID"].ToString());
                    string sql = "UPDATE DSMC_Hospital_Management_System.dbo.Patients " +
             "SET Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " +
             "Patient_Name = '" + patientName + "', " +
             "Mobile_No = '" + mobileNo + "', " +
             "Age = " + age + ", " +
             "Gender = '" + gender + "', " +
             "Address = '" + address + "', " +
             "Problem = '" + problem + "', " +
             "Doctor = '" + doctor + "', " +
             "Fees = " + fees + " " +
             "WHERE Patient_ID = " + Patientid;
                    db.ExecuteNonQuery(sql);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }

        private void frmPatients_Load(object sender, EventArgs e)
        {
            RetriveData();
        }
        private void RetriveData()
        {
        
            if (this.EditProduct != null)
            {
                this.txtPatientName.Text = this.EditProduct["Patient_Name"]?.ToString();
                this.txtAddress.Text = this.EditProduct["Address"]?.ToString();
                this.txtMobileNo.Text = this.EditProduct["Mobile_No"]?.ToString();
                this.txtAge.Text = this.EditProduct["Age"]?.ToString();
                this.txtFees.Text = this.EditProduct["Fees"]?.ToString();
                this.txtProblem.Text = this.EditProduct["Problem"]?.ToString();
                this.txtDoctor.Text = this.EditProduct["Doctor"]?.ToString();
                //string gender = this.EditProduct["Gender"]?.ToString();
                //if (gender == "Male")
                //{
                //    this.gb.Checked = true;
                //}
                //else if (gender == "Female")
                //{
                //    this.rbFemale.Checked = true;
                //}
                // Add additional conditions if you have more gender options

                // Populate DateTimePicker control for Date
                DateTime dateValue;
                if (DateTime.TryParse(this.EditProduct["Date"]?.ToString(), out dateValue))
                {
                    this.dtm.Value = dateValue;
                }
            }
        }

    }
}
