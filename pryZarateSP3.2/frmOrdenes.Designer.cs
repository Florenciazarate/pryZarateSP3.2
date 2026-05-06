using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using pryZarateSP3._2.UI;

namespace pryZarateSP3._2
{
    partial class frmOrdenes
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
        private static readonly Color CLR_EMERALD     = Color.FromArgb(16, 185, 129);
        private static readonly Color CLR_INPUT_BG    = Color.FromArgb(248, 250, 252);

        private Label lblHeaderTitle;
        private Label lblHeaderSub;
        private Guna2Panel pnlForm;
        private Label lblFormTitle;
        private Label lblDescripcion;
        private Guna2TextBox txtDescripcion;
        private Label lblMaquina;
        private Guna2ComboBox cboMaquina;
        private Label lblHoras;
        private Guna2NumericUpDown numHoras;
        private Label lblHint;
        private Guna2Button btnRegistrar;

        private Guna2Panel pnlGrid;
        private Label lblGridTitle;
        private Label lblTotal;
        private Guna2DataGridView grid;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1000, 620);
            this.Text = "Órdenes de producción";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = CLR_BG;
            this.Font = new Font("Segoe UI", 9F);

            lblHeaderTitle = new Label
            {
                Text = "Órdenes de producción",
                Location = new Point(32, 24),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 18F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblHeaderTitle);

            lblHeaderSub = new Label
            {
                Text = "Asigná órdenes a las máquinas inyectoras y listá las cargadas hasta el momento.",
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
                Size = new Size(330, 484),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlForm);

            lblFormTitle = new Label
            {
                Text = "Nueva orden",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblFormTitle);

            lblDescripcion = new Label
            {
                Text = "Descripción",
                Location = new Point(20, 64),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblDescripcion);

            txtDescripcion = new Guna2TextBox
            {
                Location = new Point(20, 86),
                Size = new Size(290, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_EMERALD },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                MaxLength = 50,
                PlaceholderText = "Ej. Producción tapas de 500ml"
            };
            pnlForm.Controls.Add(txtDescripcion);

            lblMaquina = new Label
            {
                Text = "Máquina asignada",
                Location = new Point(20, 142),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblMaquina);

            cboMaquina = new Guna2ComboBox
            {
                Location = new Point(20, 164),
                Size = new Size(290, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_EMERALD },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            pnlForm.Controls.Add(cboMaquina);

            lblHoras = new Label
            {
                Text = "Horas de trabajo",
                Location = new Point(20, 220),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblHoras);

            numHoras = new Guna2NumericUpDown
            {
                Location = new Point(20, 242),
                Size = new Size(290, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_EMERALD },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                Minimum = 1,
                Maximum = 100000,
                Value = 1
            };
            pnlForm.Controls.Add(numHoras);

            lblHint = new Label
            {
                Text = "Recordá registrar primero las máquinas\nantes de cargar las órdenes.",
                Location = new Point(20, 294),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlForm.Controls.Add(lblHint);

            btnRegistrar = new Guna2Button
            {
                Text = "Registrar orden",
                Location = new Point(20, 420),
                Size = new Size(290, 46),
                BorderRadius = 10,
                FillColor = CLR_EMERALD,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 10F),
                Cursor = Cursors.Hand
            };
            btnRegistrar.HoverState.FillColor = ControlPaint.Dark(CLR_EMERALD, 0.05f);
            btnRegistrar.Click += btnRegistrar_Click;
            pnlForm.Controls.Add(btnRegistrar);

            // ---- GRID CARD ----
            pnlGrid = new Guna2Panel
            {
                Location = new Point(380, 100),
                Size = new Size(588, 484),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlGrid);

            lblGridTitle = new Label
            {
                Text = "Órdenes registradas",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlGrid.Controls.Add(lblGridTitle);

            lblTotal = new Label
            {
                Text = "0 órdenes registradas",
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
                Size = new Size(548, 390)
            };
            GridStyle.Apply(grid);
            pnlGrid.Controls.Add(grid);
        }
    }
}
