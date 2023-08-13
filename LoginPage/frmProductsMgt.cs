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
            //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            //con.ConnectionString = @"Data Source = .\SQLEXPRESS; Database = DSMC_Hospital_Management_System; integrated security = true;";
            //con.Open();
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.Connection = con;
            string sql = "Select * from Products";

            //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            //da.SelectCommand = cmd;
            //System.Data.DataTable dt = new DataTable();
            //da.Fill(dt);
            //da.Dispose();
            //con.Close();
            _dtProduct = db.ExecuteDataTable(sql);
            this.dgv.DataSource = _dtProduct;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
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
