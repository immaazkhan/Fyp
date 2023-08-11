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
    public partial class frmLogin : Form
    {
        //public bool LoginSucceeded;
        public frmLogin()
        {
            //this.LoginSucceeded = false;
            InitializeComponent();
        }

        private void Mini_Login_Page_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            txtUsername.Text = "";
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void Close_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            //if (this.txtUsername.Text.Trim()=="")
            //{
            //    MessageBox.Show ("Please Enter Username");
            //};
            //this.txtUsername.Focus();
            //return;
            //if (this.txtUsername.Text == "admin" && this.txtPassword.Text == "123")
            //{
            //    this.LoginSucceeded = true;
            //    this.Close();
            //}
            //else {
            //    MessageBox.Show("Invalid Login/Password");
            //    this.txtUsername.Focus();
            //    return; 
            //}
        }
    }
}
