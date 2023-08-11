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
            //System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            //con.ConnectionString = @"Data Source = .\SQLEXPRESS; Database = DSMC_Hospital_Management_System; integrated security = true;";
            //con.Open();
            //System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            //cmd.Connection = con;
            string sql = "Select * from Sales";
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
