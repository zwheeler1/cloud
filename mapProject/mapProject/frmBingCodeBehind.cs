using DevExpress.XtraMap;
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
    public partial class frmBingCodeBehind : Form
    {
        public frmBingCodeBehind()
        {
            InitializeComponent();
        }

        private void frmBingCodeBehind_Load(object sender, EventArgs e)
        {
            mapControl1.Layers.Add(new ImageLayer()
            {
                DataProvider = new BingMapDataProvider()
                {
                    BingKey = "AgcKYXpwRWCC-BxCoD-Ws31GePSgJYL96-smmvBugF-_0yZKbD6KBvEz9H7JzoKo",
                    Kind = BingMapKind.Road
                }
            });
        }
    }
}
