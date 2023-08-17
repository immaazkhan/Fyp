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
        DatabaseManager db = new DatabaseManager();
        public frmDoctors()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            string employmentType = radioButton1.Checked ? "Regular" : "Visiting";

            int selectedDesignationId = cmb.SelectedIndex + 1;

            decimal doctorId = db.GetNextPKValue("Doctor_ID", "Doctors");
            string sql = "INSERT INTO Doctors " +
                         "(Doctor_ID, Doctor_Name, CNIC, [Mobile No], Email_Address, Lic_No, Desgination_ID, Employement_Type, Salary, Date_Added, Active) " +
                         "VALUES ('" + doctorId + "', '" + txtDoctorName.Text + "', '" + txtCNIC.Text + "', " +
                         "'" + txtMobileNo.Text + "', '" + txtEmailAddress.Text + "', '" + txtLicNo.Text + "', " +
                         selectedDesignationId + ", '" + employmentType + "', " +
                         txtSalary.Text + ", '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                         (radioButton1.Checked ? "1" : "0") + ")";
         int  x=  db.ExecuteNonQuery(sql);
            if (x==1) { MessageBox.Show("value inserted "); }
        }

        private void frmDoctors_Load(object sender, EventArgs e)
        {
     
            string customers = "select * from Designation";
            cmb.DisplayMember = "Designation_Name";
            cmb.ValueMember = "Designation_ID";
            cmb.DataSource = db.ExecuteDataTable(customers);
        }
    }
}
