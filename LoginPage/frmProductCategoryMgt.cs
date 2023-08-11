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
            //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            //con.ConnectionString = @"Data Source = .\SQLEXPRESS; Database = DSMC_Hospital_Management_System; integrated security = true;";
            //con.Open();
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.Connection = con;
            string sql = "Select * from Product_Categories";

            //System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            //da.SelectCommand = cmd;
            //System.Data.DataTable dt = new DataTable();
            //da.Fill(dt);
            //da.Dispose();
            //con.Close();
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
