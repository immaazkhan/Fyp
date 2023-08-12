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
            this.dgv.DataSource = db.ExecuteDataTable(sql);
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
    }
}
