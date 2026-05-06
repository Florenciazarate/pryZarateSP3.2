using System;
using System.Linq;
using System.Windows.Forms;
using pryZarateSP3._2.Datos;

namespace pryZarateSP3._2
{
    public partial class frmConsulta : Form
    {
        public frmConsulta()
        {
            InitializeComponent();
            CargarMaquinas();
        }

        private void CargarMaquinas()
        {
            using (var ctx = new TodoPlastContext())
            {
                var maquinas = ctx.Maquinas.OrderBy(m => m.Nombre).ToList();
                cboMaquina.DataSource = maquinas;
                cboMaquina.DisplayMember = "Nombre";
                cboMaquina.ValueMember = "Id";

                if (maquinas.Count > 0)
                {
                    cboMaquina.SelectedIndex = 0;
                    CargarConsulta();
                }
                else
                {
                    grid.DataSource = null;
                    lblTotalHoras.Text = "0";
                    lblTotalOrdenes.Text = "0";
                }
            }
        }

        private void cboMaquina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConsulta();
        }

        private void CargarConsulta()
        {
            if (cboMaquina.SelectedValue == null) return;
            int idMaquina;
            try { idMaquina = (int)cboMaquina.SelectedValue; }
            catch { return; }

            using (var ctx = new TodoPlastContext())
            {
                var ordenes = ctx.Ordenes
                    .Where(o => o.MaquinaId == idMaquina)
                    .OrderBy(o => o.Id)
                    .Select(o => new
                    {
                        ID = o.Id,
                        Descripcion = o.Descripcion,
                        Horas = o.HorasTrabajo
                    })
                    .ToList();

                grid.DataSource = ordenes;

                if (grid.Columns.Count > 0)
                {
                    grid.Columns["ID"].HeaderText = "ID";
                    grid.Columns["ID"].FillWeight = 15;
                    grid.Columns["Descripcion"].HeaderText = "DESCRIPCIÓN";
                    grid.Columns["Descripcion"].FillWeight = 65;
                    grid.Columns["Horas"].HeaderText = "HORAS";
                    grid.Columns["Horas"].FillWeight = 20;
                }

                int totalHoras = ordenes.Sum(o => o.Horas);
                lblTotalHoras.Text = totalHoras.ToString();
                lblTotalOrdenes.Text = ordenes.Count.ToString();
            }
        }
    }
}
