using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mapProject
{
    public partial class frmSelection : Form
    {
        public frmSelection()
        {
            InitializeComponent();
        }

        private void btnBingDesignMap_Click(object sender, EventArgs e)
        {
            frmBingMapProviderDesign frm = new frmBingMapProviderDesign();
            frm.ShowDialog();
        }

        private void btnBingCodeMap_Click(object sender, EventArgs e)
        {
            frmBingCodeBehind frm = new frmBingCodeBehind();
            frm.ShowDialog();
        }
    }
}
