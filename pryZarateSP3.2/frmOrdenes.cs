using System;
using System.Linq;
using System.Windows.Forms;
using pryZarateSP3._2.Datos;
using pryZarateSP3._2.Entidades;

namespace pryZarateSP3._2
{
    public partial class frmOrdenes : Form
    {
        public frmOrdenes()
        {
            InitializeComponent();
            CargarMaquinas();
            CargarGrilla();
        }

        private void CargarMaquinas()
        {
            using (var ctx = new TodoPlastContext())
            {
                var maquinas = ctx.Maquinas.OrderBy(m => m.Nombre).ToList();
                cboMaquina.DataSource = maquinas;
                cboMaquina.DisplayMember = "Nombre";
                cboMaquina.ValueMember = "Id";
                cboMaquina.SelectedIndex = maquinas.Count > 0 ? 0 : -1;
            }
        }

        private void CargarGrilla()
        {
            using (var ctx = new TodoPlastContext())
            {
                var datos = (from o in ctx.Ordenes
                             join m in ctx.Maquinas on o.MaquinaId equals m.Id
                             orderby o.Id
                             select new
                             {
                                 ID = o.Id,
                                 Descripcion = o.Descripcion,
                                 Maquina = m.Nombre,
                                 Horas = o.HorasTrabajo
                             }).ToList();

                grid.DataSource = datos;

                if (grid.Columns.Count > 0)
                {
                    grid.Columns["ID"].HeaderText = "ID";
                    grid.Columns["ID"].FillWeight = 15;
                    grid.Columns["Descripcion"].HeaderText = "DESCRIPCIÓN";
                    grid.Columns["Descripcion"].FillWeight = 45;
                    grid.Columns["Maquina"].HeaderText = "MÁQUINA";
                    grid.Columns["Maquina"].FillWeight = 25;
                    grid.Columns["Horas"].HeaderText = "HORAS";
                    grid.Columns["Horas"].FillWeight = 15;
                }

                lblTotal.Text = datos.Count + (datos.Count == 1 ? " orden registrada" : " órdenes registradas");
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string desc = txtDescripcion.Text.Trim();
            if (string.IsNullOrEmpty(desc))
            {
                MessageBox.Show(this, "Ingresá una descripción.", "Falta información",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }
            if (desc.Length > 50)
            {
                MessageBox.Show(this, "La descripción no puede superar los 50 caracteres.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboMaquina.SelectedValue == null)
            {
                MessageBox.Show(this, "Primero registrá una máquina desde el menú principal.", "Sin máquinas",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int horas = (int)numHoras.Value;
            if (horas <= 0)
            {
                MessageBox.Show(this, "Las horas de trabajo deben ser mayores a cero.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var ctx = new TodoPlastContext())
            {
                ctx.Ordenes.Add(new OrdenProduccion
                {
                    Descripcion = desc,
                    MaquinaId = (int)cboMaquina.SelectedValue,
                    HorasTrabajo = horas
                });
                ctx.SaveChanges();
            }

            txtDescripcion.Clear();
            numHoras.Value = 1;
            txtDescripcion.Focus();
            CargarGrilla();
        }
    }
}
