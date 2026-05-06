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
        private static readonly Color CLR_SIDEBAR_HOV = Color.FromArgb(30, 41, 59);
        private static readonly Color CLR_SIDEBAR_TXT = Color.FromArgb(203, 213, 225);
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
        private Label lblNavSection;
        private Guna2Button btnNavMaquinas;
        private Guna2Button btnNavOrdenes;
        private Guna2Button btnNavConsulta;
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
                ForeColor = Color.FromArgb(148, 163, 184),
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblBrandSub);

            lblNavSection = new Label
            {
                Text = "MENÚ",
                Location = new Point(29, 124),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 7.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                BackColor = Color.Transparent
            };
            pnlSidebar.Controls.Add(lblNavSection);

            btnNavMaquinas = BuildNavButton("Máquinas inyectoras", 152);
            btnNavOrdenes  = BuildNavButton("Órdenes de producción", 204);
            btnNavConsulta = BuildNavButton("Consulta por máquina", 256);

            btnNavMaquinas.Click += btnMaquinas_Click;
            btnNavOrdenes.Click  += btnOrdenes_Click;
            btnNavConsulta.Click += btnConsulta_Click;

            pnlSidebar.Controls.Add(btnNavMaquinas);
            pnlSidebar.Controls.Add(btnNavOrdenes);
            pnlSidebar.Controls.Add(btnNavConsulta);

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

        private Guna2Button BuildNavButton(string text, int top)
        {
            var b = new Guna2Button
            {
                Text = text,
                TextAlign = HorizontalAlignment.Left,
                Location = new Point(16, top),
                Size = new Size(208, 44),
                BorderRadius = 8,
                BorderThickness = 0,
                FillColor = CLR_SIDEBAR,
                ForeColor = CLR_SIDEBAR_TXT,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            b.HoverState.FillColor = CLR_SIDEBAR_HOV;
            b.HoverState.ForeColor = CLR_WHITE;
            b.HoverState.BorderColor = CLR_SIDEBAR_HOV;
            b.PressedColor = Color.FromArgb(51, 65, 85);
            b.PressedDepth = 0;
            b.Padding = new Padding(16, 0, 0, 0);
            return b;
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

            // Barra superior de acento (4px alto en color de la sección)
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
    }
}
