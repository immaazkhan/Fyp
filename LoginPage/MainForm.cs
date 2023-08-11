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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //frmLogin frm = new frmLogin();
            //frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog(this);
            //if(frm.LoginSucceeded != true)
            //{
            //    this.Close();
            //    return;
            //}
            //frm = null;
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmVendorsMgt vendorsMgt =  frmVendorsMgt.DefaultInstance;
            vendorsMgt.MdiParent = this;
            vendorsMgt.Show();
            //this.Close();
               
        }

       // private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
       // {
          //  frmPRegistration registration = frmPRegistration.DefaultInstance;
           // registration.MdiParent = this;
           // registration.Show();
            //this.Close();
        //}

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //this.Close();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerMgt frm = frmCustomerMgt.DefaultInstance;
            frm.MdiParent = this;
            frm.Show();
            //this.Close();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductsMgt productsMgt = frmProductsMgt.DefaultInstance;
            productsMgt.MdiParent = this;
            productsMgt.Show();
            //this.Close();
        }

        private void productCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductCategoryMgt productCategoryMgt = frmProductCategoryMgt.DefaultInstance;
            productCategoryMgt.MdiParent = this;
            productCategoryMgt.Show();
            //this.Close();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalesMgt salesMgt = frmSalesMgt.DefaultInstance;
            salesMgt.MdiParent = this;
            salesMgt.Show();
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpatientregistrationMgt frm = new frmpatientregistrationMgt();
            frm.MdiParent = this;
            frm.Show();
        }

        private void manufacturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManufacturerMgt frm = new frmManufacturerMgt();
            {
                StartPosition = FormStartPosition.CenterParent;
            };
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }
    }
}
