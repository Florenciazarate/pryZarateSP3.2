using System;
using System.Linq;
using System.Windows.Forms;
using pryZarateSP3._2.Datos;

namespace pryZarateSP3._2
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.Load += (s, e) => RefreshStats();
        }

        private void RefreshStats()
        {
            try
            {
                using (var ctx = new TodoPlastContext())
                {
                    int totalMaquinas = ctx.Maquinas.Count();
                    int totalOrdenes  = ctx.Ordenes.Count();
                    int totalHoras    = ctx.Ordenes.Any() ? ctx.Ordenes.Sum(o => o.HorasTrabajo) : 0;

                    LblStatMaquinasValue.Text = totalMaquinas.ToString();
                    LblStatOrdenesValue.Text  = totalOrdenes.ToString();
                    LblStatHorasValue.Text    = totalHoras.ToString();
                }
            }
            catch
            {
                LblStatMaquinasValue.Text = "0";
                LblStatOrdenesValue.Text  = "0";
                LblStatHorasValue.Text    = "0";
            }
        }

        private void btnMaquinas_Click(object sender, EventArgs e)
        {
            using (var f = new frmMaquinas()) { f.ShowDialog(this); }
            RefreshStats();
        }

        private void btnOrdenes_Click(object sender, EventArgs e)
        {
            using (var f = new frmOrdenes()) { f.ShowDialog(this); }
            RefreshStats();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            using (var f = new frmConsulta()) { f.ShowDialog(this); }
            RefreshStats();
        }
    }
}
