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
        DatabaseManager db = new DatabaseManager();
        DataTable _dtPatient;
  
        public frmpatientregistrationMgt()
        {
            InitializeComponent();
        }

        private void frmpatientregistrationMgt_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        public void RefreshDataGridView()
        {
            string sql = "Select * from Patients";
            _dtPatient = db.ExecuteDataTable(sql);
            dgv.DataSource = _dtPatient;
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[1].Value);
            DataRow patient = this._dtPatient.Select("Patient_ID=" + id)[0];

            frmPatients frm = new frmPatients()
            {
                StartPosition = FormStartPosition.CenterParent

            };
            frm.EditProduct = patient;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;

        }
    }
}
