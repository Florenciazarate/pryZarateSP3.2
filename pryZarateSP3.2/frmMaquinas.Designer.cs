using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using pryZarateSP3._2.UI;

namespace pryZarateSP3._2
{
    partial class frmMaquinas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private static readonly Color CLR_BG          = Color.FromArgb(248, 250, 252);
        private static readonly Color CLR_TEXT        = Color.FromArgb(15, 23, 42);
        private static readonly Color CLR_TEXT_SOFT   = Color.FromArgb(100, 116, 139);
        private static readonly Color CLR_BORDER      = Color.FromArgb(226, 232, 240);
        private static readonly Color CLR_INDIGO      = Color.FromArgb(79, 70, 229);
        private static readonly Color CLR_DANGER      = Color.FromArgb(239, 68, 68);
        private static readonly Color CLR_INPUT_BG    = Color.FromArgb(248, 250, 252);

        private Label lblHeaderTitle;
        private Label lblHeaderSub;
        private Guna2Panel pnlForm;
        private Label lblFormTitle;
        private Label lblNombre;
        private Guna2TextBox txtNombre;
        private Label lblCapacidad;
        private Guna2NumericUpDown numCapacidad;
        private Label lblHint;
        private Guna2Button btnAgregar;

        private Guna2Panel pnlGrid;
        private Label lblGridTitle;
        private Label lblTotal;
        private Guna2DataGridView grid;
        private Guna2Button btnEliminar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(960, 620);
            this.Text = "Máquinas inyectoras";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = CLR_BG;
            this.Font = new Font("Segoe UI", 9F);

            // Header
            lblHeaderTitle = new Label
            {
                Text = "Máquinas inyectoras",
                Location = new Point(32, 24),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 18F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblHeaderTitle);

            lblHeaderSub = new Label
            {
                Text = "Registrá nuevas máquinas, listalas y eliminá las que ya no estén en uso.",
                Location = new Point(34, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblHeaderSub);

            // ---- FORM CARD ----
            pnlForm = new Guna2Panel
            {
                Location = new Point(32, 100),
                Size = new Size(310, 484),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlForm);

            lblFormTitle = new Label
            {
                Text = "Nueva máquina",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblFormTitle);

            lblNombre = new Label
            {
                Text = "Nombre",
                Location = new Point(20, 64),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblNombre);

            txtNombre = new Guna2TextBox
            {
                Location = new Point(20, 86),
                Size = new Size(270, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_INDIGO },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                MaxLength = 30,
                PlaceholderText = "Ej. Inyectora Línea A"
            };
            pnlForm.Controls.Add(txtNombre);

            lblCapacidad = new Label
            {
                Text = "Capacidad de inyección (m³/h)",
                Location = new Point(20, 142),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblCapacidad);

            numCapacidad = new Guna2NumericUpDown
            {
                Location = new Point(20, 164),
                Size = new Size(270, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_INDIGO },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                Minimum = 1,
                Maximum = 1000000,
                Value = 10
            };
            pnlForm.Controls.Add(numCapacidad);

            lblHint = new Label
            {
                Text = "El identificador se asigna automáticamente.",
                Location = new Point(20, 216),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblHint);

            btnAgregar = new Guna2Button
            {
                Text = "Agregar máquina",
                Location = new Point(20, 420),
                Size = new Size(270, 46),
                BorderRadius = 10,
                FillColor = CLR_INDIGO,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F),
                Cursor = Cursors.Hand
            };
            btnAgregar.HoverState.FillColor = ControlPaint.Dark(CLR_INDIGO, 0.05f);
            btnAgregar.Click += btnAgregar_Click;
            pnlForm.Controls.Add(btnAgregar);

            // ---- GRID CARD ----
            pnlGrid = new Guna2Panel
            {
                Location = new Point(360, 100),
                Size = new Size(568, 484),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlGrid);

            lblGridTitle = new Label
            {
                Text = "Listado",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlGrid.Controls.Add(lblGridTitle);

            lblTotal = new Label
            {
                Text = "0 máquinas registradas",
                Location = new Point(20, 44),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlGrid.Controls.Add(lblTotal);

            grid = new Guna2DataGridView
            {
                Location = new Point(20, 76),
                Size = new Size(528, 326)
            };
            GridStyle.Apply(grid);
            pnlGrid.Controls.Add(grid);

            btnEliminar = new Guna2Button
            {
                Text = "Eliminar seleccionada",
                Location = new Point(20, 420),
                Size = new Size(528, 46),
                BorderRadius = 10,
                FillColor = Color.White,
                ForeColor = CLR_DANGER,
                BorderColor = CLR_DANGER,
                BorderThickness = 1,
                Font = new Font("Segoe UI Semibold", 10F),
                Cursor = Cursors.Hand
            };
            btnEliminar.HoverState.FillColor = Color.FromArgb(254, 242, 242);
            btnEliminar.HoverState.BorderColor = CLR_DANGER;
            btnEliminar.HoverState.ForeColor = CLR_DANGER;
            btnEliminar.Click += btnEliminar_Click;
            pnlGrid.Controls.Add(btnEliminar);
        }
    }
}
