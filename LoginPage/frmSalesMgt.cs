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
    public partial class frmSalesMgt : Form
    {
        private static frmSalesMgt _DefaultInstance;
        DatabaseManager db = new DatabaseManager();
        public static frmSalesMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmSalesMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        private frmSalesMgt()
        {
            InitializeComponent();
        }

        private void frmSalesMgt_Load(object sender, EventArgs e)
        {

            string sql = "Select * from Sales";
            this.dgv.DataSource = db.ExecuteDataTable(sql);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
            
            frm.Show();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
