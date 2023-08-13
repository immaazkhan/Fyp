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
    public partial class frmEmployeeMgt : Form
    {
        public frmEmployeeMgt()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {

            //frmEmployees  frm = new frmEmployees()
            frmDoctors frm = new frmDoctors();
             {
                StartPosition = FormStartPosition.CenterParent;
              }
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }
    }
    }
