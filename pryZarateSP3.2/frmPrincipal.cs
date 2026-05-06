using System;
using System.Drawing;
using System.Windows.Forms;

namespace pryZarateSP3._2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnMaquinas_Click(object sender, EventArgs e)
        {
            using (var f = new frmMaquinas()) { f.ShowDialog(this); }
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            using (var f = new frmOrdenes()) { f.ShowDialog(this); }
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            using (var f = new frmConsulta()) { f.ShowDialog(this); }
        }
    }
}
