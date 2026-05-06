using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using pryZarateSP3._2.UI;

namespace pryZarateSP3._2
{
    partial class frmConsulta
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
        private static readonly Color CLR_AMBER       = Color.FromArgb(245, 158, 11);
        private static readonly Color CLR_INDIGO      = Color.FromArgb(79, 70, 229);
        private static readonly Color CLR_AMBER_SOFT  = Color.FromArgb(254, 243, 199);
        private static readonly Color CLR_INDIGO_SOFT = Color.FromArgb(238, 242, 255);
        private static readonly Color CLR_INPUT_BG    = Color.FromArgb(248, 250, 252);

        private Label lblHeaderTitle;
        private Label lblHeaderSub;
        private Guna2Panel pnlFiltro;
        private Label lblFiltro;
        private Guna2ComboBox cboMaquina;

        private Guna2Panel cardOrdenes;
        private Label lblOrdenesCaption;
        private Label lblTotalOrdenes;

        private Guna2Panel cardHoras;
        private Label lblHorasCaption;
        private Label lblTotalHoras;
        private Label lblHorasUnidad;

        private Guna2Panel pnlGrid;
        private Label lblGridTitle;
        private Guna2DataGridView grid;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(960, 620);
            this.Text = "Consulta por máquina";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = CLR_BG;
            this.Font = new Font("Segoe UI", 9F);

            lblHeaderTitle = new Label
            {
                Text = "Consulta por máquina",
                Location = new Point(32, 24),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 18F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblHeaderTitle);

            lblHeaderSub = new Label
            {
                Text = "Seleccioná una máquina para ver el detalle de sus órdenes y el total de horas trabajadas.",
                Location = new Point(34, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            this.Controls.Add(lblHeaderSub);

            // ---- FILTRO ----
            pnlFiltro = new Guna2Panel
            {
                Location = new Point(32, 100),
                Size = new Size(896, 90),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlFiltro);

            lblFiltro = new Label
            {
                Text = "Máquina",
                Location = new Point(24, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlFiltro.Controls.Add(lblFiltro);

            cboMaquina = new Guna2ComboBox
            {
                Location = new Point(24, 40),
                Size = new Size(420, 40),
                BorderRadius = 8,
                BorderColor = CLR_BORDER,
                FocusedState = { BorderColor = CLR_AMBER },
                FillColor = CLR_INPUT_BG,
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboMaquina.SelectedIndexChanged += cboMaquina_SelectedIndexChanged;
            pnlFiltro.Controls.Add(cboMaquina);

            // métricas dentro del panel filtro
            cardOrdenes = new Guna2Panel
            {
                Location = new Point(490, 14),
                Size = new Size(180, 62),
                FillColor = CLR_INDIGO_SOFT,
                BorderRadius = 12
            };
            pnlFiltro.Controls.Add(cardOrdenes);

            lblOrdenesCaption = new Label
            {
                Text = "ÓRDENES",
                Location = new Point(14, 8),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 8F),
                ForeColor = CLR_INDIGO,
                BackColor = Color.Transparent
            };
            cardOrdenes.Controls.Add(lblOrdenesCaption);

            lblTotalOrdenes = new Label
            {
                Text = "0",
                Location = new Point(14, 22),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22F),
                ForeColor = CLR_INDIGO,
                BackColor = Color.Transparent
            };
            cardOrdenes.Controls.Add(lblTotalOrdenes);

            cardHoras = new Guna2Panel
            {
                Location = new Point(686, 14),
                Size = new Size(190, 62),
                FillColor = CLR_AMBER_SOFT,
                BorderRadius = 12
            };
            pnlFiltro.Controls.Add(cardHoras);

            lblHorasCaption = new Label
            {
                Text = "TOTAL HORAS",
                Location = new Point(14, 8),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 8F),
                ForeColor = Color.FromArgb(180, 83, 9),
                BackColor = Color.Transparent
            };
            cardHoras.Controls.Add(lblHorasCaption);

            lblTotalHoras = new Label
            {
                Text = "0",
                Location = new Point(14, 22),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22F),
                ForeColor = Color.FromArgb(180, 83, 9),
                BackColor = Color.Transparent
            };
            cardHoras.Controls.Add(lblTotalHoras);

            lblHorasUnidad = new Label
            {
                Text = "hs",
                Location = new Point(150, 36),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(180, 83, 9),
                BackColor = Color.Transparent
            };
            cardHoras.Controls.Add(lblHorasUnidad);

            // ---- GRID ----
            pnlGrid = new Guna2Panel
            {
                Location = new Point(32, 206),
                Size = new Size(896, 384),
                FillColor = Color.White,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            this.Controls.Add(pnlGrid);

            lblGridTitle = new Label
            {
                Text = "Detalle de órdenes",
                Location = new Point(20, 18),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 12F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlGrid.Controls.Add(lblGridTitle);

            grid = new Guna2DataGridView
            {
                Location = new Point(20, 56),
                Size = new Size(856, 308)
            };
            GridStyle.Apply(grid);
            pnlGrid.Controls.Add(grid);
        }
    }
}
