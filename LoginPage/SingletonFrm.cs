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
    public partial class SingletonFrm : Form
    {
        private static SingletonFrm _defaultInstance;
        public static SingletonFrm DefaultInstance
        {
            get
            {
                if (_defaultInstance == null)
                    _defaultInstance = new SingletonFrm();
                return _defaultInstance;
            }
            private set
            {
                _defaultInstance = value;
            }
        }
        private SingletonFrm()
        {
            InitializeComponent();
        }

        private void SingletonFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
