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
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DatabaseManager db = new DatabaseManager();
            string sql = "INSERT INTO Employees (Employee_ID, Employee_Name, Birth_Date, Gender, Designation_ID, Lic_No, CNIC, Mobile_NO, Email_Address, Postal_Address, City, Qualification, Joining_Date, Salary) " +
              "VALUES (" +
              "1, " + // Employee_ID
              "'" + txtEmployeeName.Text + "', " +
              "'" + dtm.Value.ToString("yyyy-MM-dd") + "', " +
              "'" + (radioButton1.Checked ? "Male" : "Female") + "', " +
              txtDesignation.Text + ", " +
              "'" + txtPMDC.Text + "', " +
              "'" + txtCNIC.Text + "', " +
              txtMobileNo.Text + ", " +
              "'" + txtEmailAddress.Text + "', " +
              "'" + txtPostalAddress.Text + "', " +
              "'" + txtCity.Text + "', " +
              "'" + txtQualification.Text + "', " +
              "'" + dtpJoiningDate.Value.ToString("yyyy-MM-dd") + "', " +
              txtSalary.Text +
              ")";

            db.ExecuteNonQuery(sql);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQualification_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
