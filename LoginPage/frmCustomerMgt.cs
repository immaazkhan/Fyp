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
    public partial class frmCustomerMgt : Form
    {
        DatabaseManager db = new DatabaseManager();
        DataTable _dtCustomer;
        private static frmCustomerMgt _DefaultInstance;
        
        public static frmCustomerMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmCustomerMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        public frmCustomerMgt()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }

        private void frmCustomerMgt_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        public void RefreshDataGridView()
        {
            string sql = "Select * from Customers";
            _dtCustomer = db.ExecuteDataTable(sql);
             dgv .DataSource = _dtCustomer;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[0].Value);
            DataRow customer = this._dtCustomer.Select("Customer_ID=" + id)[0];

            frmCustomers frm = new frmCustomers()
            {
                StartPosition = FormStartPosition.CenterParent

            };
            frm.EditCustomer = customer;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }
    }
    }

