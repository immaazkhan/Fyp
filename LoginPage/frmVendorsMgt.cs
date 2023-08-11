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
    public partial class frmVendorsMgt : Form
    {
        private static frmVendorsMgt _DefaultInstance;
        DatabaseManager db = new DatabaseManager();
        DataTable _dtVenders;
        public static frmVendorsMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmVendorsMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        
        private frmVendorsMgt()
        {
            InitializeComponent();
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmVendors frm = new frmVendors(this)
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }

        private void frmVendorsMgt_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
          
        }
        public void RefreshDataGridView()
        {
            string sql = "Select * from Vendors";
            _dtVenders = db.ExecuteDataTable(sql);
            dgv.DataSource = _dtVenders;
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[0].Value);
            DataRow vender= this._dtVenders.Select("Vendor_ID=" + id)[0];
            
            frmVendors frm = new frmVendors(this)
            {
                StartPosition = FormStartPosition.CenterParent
                
            };
            frm.EditVender = vender;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;           
        }

    }
}
