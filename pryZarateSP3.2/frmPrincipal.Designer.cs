using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace pryZarateSP3._2
{
    partial class frmPrincipal
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

        // Paleta UX
        private static readonly Color CLR_BG          = Color.FromArgb(248, 250, 252);
        private static readonly Color CLR_SIDEBAR     = Color.FromArgb(15, 23, 42);
        private static readonly Color CLR_SIDEBAR_CARD = Color.FromArgb(30, 41, 59);
        private static readonly Color CLR_SIDEBAR_MUTED = Color.FromArgb(148, 163, 184);
        private static readonly Color CLR_TEXT        = Color.FromArgb(15, 23, 42);
        private static readonly Color CLR_TEXT_SOFT   = Color.FromArgb(100, 116, 139);
        private static readonly Color CLR_BORDER      = Color.FromArgb(226, 232, 240);
        private static readonly Color CLR_INDIGO      = Color.FromArgb(79, 70, 229);
        private static readonly Color CLR_EMERALD     = Color.FromArgb(16, 185, 129);
        private static readonly Color CLR_AMBER       = Color.FromArgb(245, 158, 11);
        private static readonly Color CLR_WHITE       = Color.White;

        private Panel pnlSidebar;
        private Label lblBrand;
        private Label lblBrandSub;
        private Label lblResumenTitle;

        private Guna2Panel statMaquinas;
        private Label lblStatMaquinasCaption;
        private Label lblStatMaquinasValue;
        private Label lblStatMaquinasUnit;

        private Guna2Panel statOrdenes;
        private Label lblStatOrdenesCaption;
        private Label lblStatOrdenesValue;
        private Label lblStatOrdenesUnit;

        private Guna2Panel statHoras;
        private Label lblStatHorasCaption;
        private Label lblStatHorasValue;
        private Label lblStatHorasUnit;

        private Label lblVersion;

        private Panel pnlMain;
        private Label lblHello;
        private Label lblTitle;
        private Label lblSubtitle;

        private Guna2Panel cardMaquinas;
        private Guna2Panel cardOrdenes;
        private Guna2Panel cardConsulta;
        private Guna2Button btnMaquinas;
        private Guna2Button btnOrdenes;
        private Guna2Button btnConsulta;

        private Label lblFooter;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1120, 680);
            this.Text = "TodoPlast — Sistema de Producción";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = CLR_BG;
            this.Font = new Font("Segoe UI", 9F);

            // ============ SIDEBAR ============
            pnlSidebar = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(240, 680),
                BackColor = CLR_SIDEBAR
            };
            this.Controls.Add(pnlSidebar);

            lblBrand = new Label
            {
                Text = "TodoPlast",
                Location = new Point(28, 36),
                AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = CLR_WHITE,
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblBrand);

            lblBrandSub = new Label
            {
                Text = "Área de Producción",
                Location = new Point(29, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = CLR_SIDEBAR_MUTED,
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblBrandSub);

            lblResumenTitle = new Label
            {
                Text = "RESUMEN",
                Location = new Point(29, 130),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 7.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblResumenTitle);

            BuildStatCard(out statMaquinas, out lblStatMaquinasCaption, out lblStatMaquinasValue,
                out lblStatMaquinasUnit, 158, "MÁQUINAS REGISTRADAS", "máquinas", CLR_INDIGO);
            pnlSidebar.Controls.Add(statMaquinas);

            BuildStatCard(out statOrdenes, out lblStatOrdenesCaption, out lblStatOrdenesValue,
                out lblStatOrdenesUnit, 254, "ÓRDENES CARGADAS", "órdenes", CLR_EMERALD);
            pnlSidebar.Controls.Add(statOrdenes);

            BuildStatCard(out statHoras, out lblStatHorasCaption, out lblStatHorasValue,
                out lblStatHorasUnit, 350, "HORAS TRABAJADAS", "hs totales", CLR_AMBER);
            pnlSidebar.Controls.Add(statHoras);

            lblVersion = new Label
            {
                Text = "v1.0  ·  Cátedra Zárate",
                Location = new Point(28, 638),
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(100, 116, 139),
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblVersion);

            // ============ MAIN ============
            pnlMain = new Panel
            {
                Location = new Point(240, 0),
                Size = new Size(880, 680),
                BackColor = CLR_BG
            };
            this.Controls.Add(pnlMain);

            lblHello = new Label
            {
                Text = "Bienvenido",
                Location = new Point(48, 44),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblHello);

            lblTitle = new Label
            {
                Text = "Sistema de Órdenes de Producción",
                Location = new Point(46, 64),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblTitle);

            lblSubtitle = new Label
            {
                Text = "Gestioná las máquinas inyectoras y registrá las órdenes de trabajo.",
                Location = new Point(48, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblSubtitle);

            // ============ CARDS ============
            int cardY = 170;
            int cardW = 250;
            int cardH = 290;
            int gap   = 24;
            int firstX = 48;

            BuildCard(out cardMaquinas, out btnMaquinas,
                firstX, cardY, cardW, cardH,
                CLR_INDIGO, "Máquinas",
                "Registrá nuevas máquinas inyectoras, listalas y eliminá las que ya no estén operativas.",
                "Administrar máquinas");
            btnMaquinas.Click += btnMaquinas_Click;
            pnlMain.Controls.Add(cardMaquinas);

            BuildCard(out cardOrdenes, out btnOrdenes,
                firstX + (cardW + gap), cardY, cardW, cardH,
                CLR_EMERALD, "Órdenes",
                "Cargá las órdenes de producción asignándolas a una máquina y definiendo las horas de trabajo.",
                "Registrar órdenes");
            btnOrdenes.Click += btnOrdenes_Click;
            pnlMain.Controls.Add(cardOrdenes);

            BuildCard(out cardConsulta, out btnConsulta,
                firstX + 2 * (cardW + gap), cardY, cardW, cardH,
                CLR_AMBER, "Consulta",
                "Consultá las órdenes registradas para cada máquina y revisá el total de horas trabajadas.",
                "Ver consulta");
            btnConsulta.Click += btnConsulta_Click;
            pnlMain.Controls.Add(cardConsulta);

            lblFooter = new Label
            {
                Text = "© TodoPlast S.A. — Pasantía de desarrollo",
                Location = new Point(48, 630),
                AutoSize = true,
                Font = new Font("Segoe UI", 8F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            pnlMain.Controls.Add(lblFooter);
        }

        private void BuildStatCard(out Guna2Panel card, out Label lblCaption, out Label lblValue,
            out Label lblUnit, int top, string caption, string unit, Color accent)
        {
            card = new Guna2Panel
            {
                Location = new Point(20, top),
                Size = new Size(200, 80),
                FillColor = CLR_SIDEBAR_CARD,
                BorderRadius = 12,
                BorderThickness = 0
            };

            // Acento lateral izquierdo (3px)
            var leftAccent = new Panel
            {
                Location = new Point(0, 16),
                Size = new Size(3, 48),
                BackColor = accent
            };
            card.Controls.Add(leftAccent);

            lblCaption = new Label
            {
                Text = caption,
                Location = new Point(16, 12),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 7.5F),
                ForeColor = CLR_SIDEBAR_MUTED,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblCaption);

            lblValue = new Label
            {
                Text = "0",
                Location = new Point(14, 28),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 22F),
                ForeColor = CLR_WHITE,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblValue);

            lblUnit = new Label
            {
                Text = unit,
                Location = new Point(60, 50),
                AutoSize = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = CLR_SIDEBAR_MUTED,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblUnit);
        }

        private void BuildCard(out Guna2Panel card, out Guna2Button btn,
            int x, int y, int w, int h,
            Color accent, string title, string desc, string btnText)
        {
            card = new Guna2Panel
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                FillColor = CLR_WHITE,
                BorderColor = CLR_BORDER,
                BorderThickness = 1,
                BorderRadius = 14
            };
            card.ShadowDecoration.Enabled = false;

            var topAccent = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(40, 4),
                BackColor = accent
            };
            card.Controls.Add(topAccent);

            var lblTitleC = new Label
            {
                Text = title,
                Location = new Point(20, 44),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 16F),
                ForeColor = CLR_TEXT,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblTitleC);

            var lblDesc = new Label
            {
                Text = desc,
                Location = new Point(20, 86),
                Size = new Size(w - 40, 110),
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = CLR_TEXT_SOFT,
                BackColor = Color.Transparent
            };
            card.Controls.Add(lblDesc);

            btn = new Guna2Button
            {
                Text = btnText,
                Location = new Point(20, h - 64),
                Size = new Size(w - 40, 44),
                BorderRadius = 10,
                FillColor = accent,
                ForeColor = CLR_WHITE,
                Font = new Font("Segoe UI Semibold", 9.5F),
                Cursor = Cursors.Hand
            };
            btn.HoverState.FillColor = ControlPaint.Dark(accent, 0.08f);
            card.Controls.Add(btn);
        }

        // expuesto al code-behind para refrescar
        internal Label LblStatMaquinasValue { get { return lblStatMaquinasValue; } }
        internal Label LblStatOrdenesValue { get { return lblStatOrdenesValue; } }
        internal Label LblStatHorasValue { get { return lblStatHorasValue; } }
    }
}
