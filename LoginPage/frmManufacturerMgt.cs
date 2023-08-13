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
    public partial class frmManufacturerMgt : Form
    {
        private static frmManufacturerMgt _DefaultInstance;
        DatabaseManager db = new DatabaseManager();
        DataTable _dtManufactures; 
        public static frmManufacturerMgt DefaultInstance
        {
            get
            {
                if (_DefaultInstance == null)
                    _DefaultInstance = new frmManufacturerMgt();
                return _DefaultInstance;
            }
            private set
            {
                _DefaultInstance = value;
            }
        }
        public frmManufacturerMgt()
        {
            InitializeComponent();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            frmManufacturers frm = new frmManufacturers();
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

        private void frmManufacturerMgt_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        public void RefreshDataGridView()
        {
            string sql = "Select * from Manufacturers";
            _dtManufactures = db.ExecuteDataTable(sql);
            dgv.DataSource = _dtManufactures;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (this.dgv.CurrentRow == null) return;
            decimal id = Convert.ToDecimal(this.dgv.CurrentRow.Cells[0].Value);
            DataRow vender = this._dtManufactures.Select("Manufacturer_ID=" + id)[0];

            frmManufacturers frm = new frmManufacturers()
            {
                StartPosition = FormStartPosition.CenterParent

            };
            frm.EditManufactures = vender;
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
                frm = null;
        }
    }
    }

    
