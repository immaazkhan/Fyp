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
    public partial class frmProductCategoryMgt : Form
    {
        private static frmProductCategoryMgt _DefaultInstance;
        DatabaseManager db = new DatabaseManager();
        DataTable _dtproductcatagry;
        public static frmProductCategoryMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmProductCategoryMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        private frmProductCategoryMgt()
        {
            InitializeComponent();
        }

        private void frmProductCategoryMgt_Load(object sender, EventArgs e)
        {
           
            string sql = "Select * from Product_Categories";
            _dtproductcatagry=db.ExecuteDataTable(sql);
            this.dgv.DataSource = _dtproductcatagry;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmProductCategories frm = new frmProductCategories();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
           
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[0].Value);
            DataRow product = this._dtproductcatagry.Select("Product_Category_ID=" + id)[0];

            frmProductCategories frm = new frmProductCategories()
            {
                StartPosition = FormStartPosition.CenterParent

            };
            frm.EditProductCatagry = product;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }

    }

}
