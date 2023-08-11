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
    public partial class frmpatientregistrationMgt : Form
    {
        public frmpatientregistrationMgt()
        {
            InitializeComponent();
        }

        private void frmpatientregistrationMgt_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = @"Data Source = .\SQLEXPRESS; Database = DSMC_Hospital_Management_System; integrated security = true;";
            con.Open();
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from Patients";
            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
            da.SelectCommand = cmd;
            System.Data.DataTable dt = new DataTable();
            da.Fill(dt);
            da.Dispose();
            con.Close();
            this.dgv.DataSource = dt;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmPatients frm = new frmPatients();
            {
                StartPosition = FormStartPosition.CenterParent;
            };
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }
    }
}
