using System;
using System.Linq;
using System.Windows.Forms;
using pryZarateSP3._2.Datos;
using pryZarateSP3._2.Entidades;

namespace pryZarateSP3._2
{
    public partial class frmMaquinas : Form
    {
        public frmMaquinas()
        {
            InitializeComponent();
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            using (var ctx = new TodoPlastContext())
            {
                var datos = ctx.Maquinas
                    .OrderBy(m => m.Id)
                    .Select(m => new
                    {
                        ID = m.Id,
                        Nombre = m.Nombre,
                        Capacidad = m.CapacidadInyeccion
                    })
                    .ToList();

                grid.DataSource = datos;

                if (grid.Columns.Count > 0)
                {
                    grid.Columns["ID"].HeaderText = "ID";
                    grid.Columns["ID"].FillWeight = 20;
                    grid.Columns["Nombre"].HeaderText = "NOMBRE";
                    grid.Columns["Nombre"].FillWeight = 50;
                    grid.Columns["Capacidad"].HeaderText = "CAPACIDAD (m³/h)";
                    grid.Columns["Capacidad"].FillWeight = 30;
                }

                lblTotal.Text = datos.Count + (datos.Count == 1 ? " máquina registrada" : " máquinas registradas");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show(this, "Ingresá el nombre de la máquina.", "Falta información",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (nombre.Length > 30)
            {
                MessageBox.Show(this, "El nombre no puede superar los 30 caracteres.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int capacidad = (int)numCapacidad.Value;
            if (capacidad <= 0)
            {
                MessageBox.Show(this, "La capacidad debe ser mayor a cero.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var ctx = new TodoPlastContext())
            {
                ctx.Maquinas.Add(new Maquina
                {
                    Nombre = nombre,
                    CapacidadInyeccion = capacidad
                });
                ctx.SaveChanges();
            }

            txtNombre.Clear();
            numCapacidad.Value = 1;
            txtNombre.Focus();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null)
            {
                MessageBox.Show(this, "Seleccioná una máquina de la lista.", "Sin selección",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = (int)grid.CurrentRow.Cells["ID"].Value;
            string nombre = grid.CurrentRow.Cells["Nombre"].Value.ToString();

            var r = MessageBox.Show(this,
                "¿Eliminar la máquina \"" + nombre + "\"?\nSe eliminarán también sus órdenes asociadas.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r != DialogResult.Yes) return;

            using (var ctx = new TodoPlastContext())
            {
                var maq = ctx.Maquinas.Find(id);
                if (maq != null)
                {
                    var ords = ctx.Ordenes.Where(o => o.MaquinaId == id).ToList();
                    if (ords.Count > 0) ctx.Ordenes.RemoveRange(ords);
                    ctx.Maquinas.Remove(maq);
                    ctx.SaveChanges();
                }
            }

            CargarGrilla();
        }
    }
}
