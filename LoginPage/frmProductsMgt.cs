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
    public partial class frmProductsMgt : Form
    {
        private static frmProductsMgt _DefaultInstance;
        DatabaseManager db = new DatabaseManager();
        DataTable _dtProduct;
        public static frmProductsMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmProductsMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        private frmProductsMgt()
        {
            InitializeComponent();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProductsMgt_Load(object sender, EventArgs e)
        {
            RetrieveData();
        }
        private void RetrieveData()
        {
            string sql = "Select * from Products";
            _dtProduct = db.ExecuteDataTable(sql);
            this.dgv.DataSource = _dtProduct;
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
            {
                RetrieveData();
            }
            frm = null;
         
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[0].Value);
            DataRow vender = this._dtProduct.Select("Product_ID=" + id)[0];

            frmProducts frm = new frmProducts()
            {
                StartPosition = FormStartPosition.CenterParent

            };
            frm.Editproduct = vender;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;

        }
    }
}
