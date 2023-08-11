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
    public partial class DSMC_Dashboard : Form
    {
        public DSMC_Dashboard()
        {
            InitializeComponent();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            frmLogin Mloginpage = new frmLogin();
            Mloginpage.ShowDialog();
        }

       

        private void Lab_Click(object sender, EventArgs e)
        {
            frmLogin Mloginpage = new frmLogin();
            Mloginpage.ShowDialog();
        }

        private void Pharmacy_Click(object sender, EventArgs e)
        {
            frmLogin Mloginpage = new frmLogin();
            Mloginpage.ShowDialog();
        }

        private void Receptionist_Click(object sender, EventArgs e)
        {
            frmLogin Mloginpage = new frmLogin();
            Mloginpage.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
