namespace EasyPDV {
    partial class FrmApp {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmApp));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelarVendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarVendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conferirFaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirCaixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button16 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button15 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button14 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button13 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button12 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button11 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button10 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button9 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button8 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button7 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button6 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button5 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button4 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button3 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button2 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.button1 = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.siticoneContextMenuStrip1 = new Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip();
            this.siticoneContextMenuStrip2 = new Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip();
            this.richTextBox3 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._listViewProducts = new System.Windows.Forms.ListView();
            this.btnRealizar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.label3 = new System.Windows.Forms.Label();
            this.meioPagamentoBox = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem,
            this.vendasToolStripMenuItem,
            this.faturaToolStripMenuItem,
            this.caixaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1075, 32);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem});
            this.produtosToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.produtosToolStripMenuItem.Text = "Produtos";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(256, 26);
            this.cadastrarToolStripMenuItem.Text = "Visualizar produtos";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // vendasToolStripMenuItem
            // 
            this.vendasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarVendaToolStripMenuItem,
            this.visualizarVendasToolStripMenuItem});
            this.vendasToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendasToolStripMenuItem.Name = "vendasToolStripMenuItem";
            this.vendasToolStripMenuItem.Size = new System.Drawing.Size(90, 26);
            this.vendasToolStripMenuItem.Text = "Vendas";
            // 
            // cancelarVendaToolStripMenuItem
            // 
            this.cancelarVendaToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelarVendaToolStripMenuItem.Name = "cancelarVendaToolStripMenuItem";
            this.cancelarVendaToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.cancelarVendaToolStripMenuItem.Text = "Visualizar canceladas";
            this.cancelarVendaToolStripMenuItem.Click += new System.EventHandler(this.cancelarVendaToolStripMenuItem_Click_1);
            // 
            // visualizarVendasToolStripMenuItem
            // 
            this.visualizarVendasToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visualizarVendasToolStripMenuItem.Name = "visualizarVendasToolStripMenuItem";
            this.visualizarVendasToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.visualizarVendasToolStripMenuItem.Text = "Visualizar vendas";
            this.visualizarVendasToolStripMenuItem.Click += new System.EventHandler(this.visualizarVendasToolStripMenuItem_Click_1);
            // 
            // faturaToolStripMenuItem
            // 
            this.faturaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conferirFaturaToolStripMenuItem});
            this.faturaToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.faturaToolStripMenuItem.Name = "faturaToolStripMenuItem";
            this.faturaToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.faturaToolStripMenuItem.Text = "Fatura";
            // 
            // conferirFaturaToolStripMenuItem
            // 
            this.conferirFaturaToolStripMenuItem.Name = "conferirFaturaToolStripMenuItem";
            this.conferirFaturaToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.conferirFaturaToolStripMenuItem.Text = "Conferir fatura";
            this.conferirFaturaToolStripMenuItem.Click += new System.EventHandler(this.conferirFaturaToolStripMenuItem_Click);
            // 
            // caixaToolStripMenuItem
            // 
            this.caixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fecharCaixaToolStripMenuItem,
            this.abrirCaixaToolStripMenuItem});
            this.caixaToolStripMenuItem.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
            this.caixaToolStripMenuItem.Size = new System.Drawing.Size(73, 26);
            this.caixaToolStripMenuItem.Text = "Caixa";
            // 
            // fecharCaixaToolStripMenuItem
            // 
            this.fecharCaixaToolStripMenuItem.Name = "fecharCaixaToolStripMenuItem";
            this.fecharCaixaToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.fecharCaixaToolStripMenuItem.Text = "Fechar caixa";
            // 
            // abrirCaixaToolStripMenuItem
            // 
            this.abrirCaixaToolStripMenuItem.Name = "abrirCaixaToolStripMenuItem";
            this.abrirCaixaToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.abrirCaixaToolStripMenuItem.Text = "Abrir Caixa";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Produtos";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(190, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button16, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.button15, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button14, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button13, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button12, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.button11, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button10, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(449, 69);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(536, 472);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // button16
            // 
            this.button16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button16.BorderRadius = 15;
            this.button16.BorderThickness = 1;
            this.button16.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button16.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button16.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button16.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button16.FillColor = System.Drawing.Color.Transparent;
            this.button16.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button16.ForeColor = System.Drawing.Color.White;
            this.button16.HoverState.BorderColor = System.Drawing.Color.White;
            this.button16.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button16.ImageSize = new System.Drawing.Size(64, 64);
            this.button16.Location = new System.Drawing.Point(405, 357);
            this.button16.Name = "button16";
            this.button16.PressedDepth = 50;
            this.button16.Size = new System.Drawing.Size(128, 112);
            this.button16.TabIndex = 31;
            this.button16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button15
            // 
            this.button15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button15.BorderRadius = 15;
            this.button15.BorderThickness = 1;
            this.button15.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button15.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button15.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button15.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button15.FillColor = System.Drawing.Color.Transparent;
            this.button15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button15.ForeColor = System.Drawing.Color.White;
            this.button15.HoverState.BorderColor = System.Drawing.Color.White;
            this.button15.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button15.ImageSize = new System.Drawing.Size(64, 64);
            this.button15.Location = new System.Drawing.Point(271, 357);
            this.button15.Name = "button15";
            this.button15.PressedDepth = 50;
            this.button15.Size = new System.Drawing.Size(128, 112);
            this.button15.TabIndex = 30;
            this.button15.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button14
            // 
            this.button14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button14.BorderRadius = 15;
            this.button14.BorderThickness = 1;
            this.button14.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button14.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button14.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button14.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button14.FillColor = System.Drawing.Color.Transparent;
            this.button14.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button14.ForeColor = System.Drawing.Color.White;
            this.button14.HoverState.BorderColor = System.Drawing.Color.White;
            this.button14.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button14.ImageSize = new System.Drawing.Size(64, 64);
            this.button14.Location = new System.Drawing.Point(137, 357);
            this.button14.Name = "button14";
            this.button14.PressedDepth = 50;
            this.button14.Size = new System.Drawing.Size(128, 112);
            this.button14.TabIndex = 29;
            this.button14.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button13
            // 
            this.button13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button13.BorderRadius = 15;
            this.button13.BorderThickness = 1;
            this.button13.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button13.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button13.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button13.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button13.FillColor = System.Drawing.Color.Transparent;
            this.button13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.HoverState.BorderColor = System.Drawing.Color.White;
            this.button13.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button13.ImageSize = new System.Drawing.Size(64, 64);
            this.button13.Location = new System.Drawing.Point(3, 357);
            this.button13.Name = "button13";
            this.button13.PressedDepth = 50;
            this.button13.Size = new System.Drawing.Size(128, 112);
            this.button13.TabIndex = 28;
            this.button13.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button12
            // 
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.BorderRadius = 15;
            this.button12.BorderThickness = 1;
            this.button12.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button12.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button12.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button12.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button12.FillColor = System.Drawing.Color.Transparent;
            this.button12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.HoverState.BorderColor = System.Drawing.Color.White;
            this.button12.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button12.ImageSize = new System.Drawing.Size(64, 64);
            this.button12.Location = new System.Drawing.Point(405, 239);
            this.button12.Name = "button12";
            this.button12.PressedDepth = 50;
            this.button12.Size = new System.Drawing.Size(128, 112);
            this.button12.TabIndex = 27;
            this.button12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button11
            // 
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.BorderRadius = 15;
            this.button11.BorderThickness = 1;
            this.button11.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button11.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button11.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button11.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button11.FillColor = System.Drawing.Color.Transparent;
            this.button11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.HoverState.BorderColor = System.Drawing.Color.White;
            this.button11.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button11.ImageSize = new System.Drawing.Size(64, 64);
            this.button11.Location = new System.Drawing.Point(271, 239);
            this.button11.Name = "button11";
            this.button11.PressedDepth = 50;
            this.button11.Size = new System.Drawing.Size(128, 112);
            this.button11.TabIndex = 26;
            this.button11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button10
            // 
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.BorderRadius = 15;
            this.button10.BorderThickness = 1;
            this.button10.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button10.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button10.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button10.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button10.FillColor = System.Drawing.Color.Transparent;
            this.button10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.HoverState.BorderColor = System.Drawing.Color.White;
            this.button10.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button10.ImageSize = new System.Drawing.Size(64, 64);
            this.button10.Location = new System.Drawing.Point(137, 239);
            this.button10.Name = "button10";
            this.button10.PressedDepth = 50;
            this.button10.Size = new System.Drawing.Size(128, 112);
            this.button10.TabIndex = 25;
            this.button10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button9
            // 
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.BorderRadius = 15;
            this.button9.BorderThickness = 1;
            this.button9.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button9.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button9.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button9.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button9.FillColor = System.Drawing.Color.Transparent;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.HoverState.BorderColor = System.Drawing.Color.White;
            this.button9.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button9.ImageSize = new System.Drawing.Size(64, 64);
            this.button9.Location = new System.Drawing.Point(3, 239);
            this.button9.Name = "button9";
            this.button9.PressedDepth = 50;
            this.button9.Size = new System.Drawing.Size(128, 112);
            this.button9.TabIndex = 24;
            this.button9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button8
            // 
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.BorderRadius = 15;
            this.button8.BorderThickness = 1;
            this.button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button8.FillColor = System.Drawing.Color.Transparent;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.HoverState.BorderColor = System.Drawing.Color.White;
            this.button8.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button8.ImageSize = new System.Drawing.Size(64, 64);
            this.button8.Location = new System.Drawing.Point(405, 121);
            this.button8.Name = "button8";
            this.button8.PressedDepth = 50;
            this.button8.Size = new System.Drawing.Size(128, 112);
            this.button8.TabIndex = 23;
            this.button8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button7
            // 
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button7.BorderRadius = 15;
            this.button7.BorderThickness = 1;
            this.button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button7.FillColor = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.HoverState.BorderColor = System.Drawing.Color.White;
            this.button7.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button7.ImageSize = new System.Drawing.Size(64, 64);
            this.button7.Location = new System.Drawing.Point(271, 121);
            this.button7.Name = "button7";
            this.button7.PressedDepth = 50;
            this.button7.Size = new System.Drawing.Size(128, 112);
            this.button7.TabIndex = 22;
            this.button7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button6
            // 
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.BorderRadius = 15;
            this.button6.BorderThickness = 1;
            this.button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button6.FillColor = System.Drawing.Color.Transparent;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.HoverState.BorderColor = System.Drawing.Color.White;
            this.button6.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button6.ImageSize = new System.Drawing.Size(64, 64);
            this.button6.Location = new System.Drawing.Point(137, 121);
            this.button6.Name = "button6";
            this.button6.PressedDepth = 50;
            this.button6.Size = new System.Drawing.Size(128, 112);
            this.button6.TabIndex = 21;
            this.button6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.BorderRadius = 15;
            this.button5.BorderThickness = 1;
            this.button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button5.FillColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.HoverState.BorderColor = System.Drawing.Color.White;
            this.button5.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button5.ImageSize = new System.Drawing.Size(64, 64);
            this.button5.Location = new System.Drawing.Point(3, 121);
            this.button5.Name = "button5";
            this.button5.PressedDepth = 50;
            this.button5.Size = new System.Drawing.Size(128, 112);
            this.button5.TabIndex = 20;
            this.button5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.BorderRadius = 15;
            this.button4.BorderThickness = 1;
            this.button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button4.FillColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.HoverState.BorderColor = System.Drawing.Color.White;
            this.button4.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button4.ImageSize = new System.Drawing.Size(64, 64);
            this.button4.Location = new System.Drawing.Point(405, 3);
            this.button4.Name = "button4";
            this.button4.PressedDepth = 50;
            this.button4.Size = new System.Drawing.Size(128, 112);
            this.button4.TabIndex = 19;
            this.button4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button3
            // 
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.BorderRadius = 15;
            this.button3.BorderThickness = 1;
            this.button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button3.FillColor = System.Drawing.Color.Transparent;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.HoverState.BorderColor = System.Drawing.Color.White;
            this.button3.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button3.ImageSize = new System.Drawing.Size(64, 64);
            this.button3.Location = new System.Drawing.Point(271, 3);
            this.button3.Name = "button3";
            this.button3.PressedDepth = 50;
            this.button3.Size = new System.Drawing.Size(128, 112);
            this.button3.TabIndex = 18;
            this.button3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.BorderRadius = 15;
            this.button2.BorderThickness = 1;
            this.button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button2.FillColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.HoverState.BorderColor = System.Drawing.Color.White;
            this.button2.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button2.ImageSize = new System.Drawing.Size(64, 64);
            this.button2.Location = new System.Drawing.Point(137, 3);
            this.button2.Name = "button2";
            this.button2.PressedDepth = 50;
            this.button2.Size = new System.Drawing.Size(128, 112);
            this.button2.TabIndex = 17;
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.BorderRadius = 15;
            this.button1.BorderThickness = 1;
            this.button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.button1.FillColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverState.BorderColor = System.Drawing.Color.White;
            this.button1.HoverState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.button1.ImageSize = new System.Drawing.Size(64, 64);
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.PressedDepth = 50;
            this.button1.Size = new System.Drawing.Size(128, 112);
            this.button1.TabIndex = 16;
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button12_MouseMove);
            // 
            // siticoneContextMenuStrip1
            // 
            this.siticoneContextMenuStrip1.Name = "siticoneContextMenuStrip1";
            this.siticoneContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.ColorTable = null;
            this.siticoneContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.siticoneContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.siticoneContextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.siticoneContextMenuStrip1_Opening);
            // 
            // siticoneContextMenuStrip2
            // 
            this.siticoneContextMenuStrip2.Name = "siticoneContextMenuStrip2";
            this.siticoneContextMenuStrip2.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip2.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip2.RenderStyle.ColorTable = null;
            this.siticoneContextMenuStrip2.RenderStyle.RoundedEdges = true;
            this.siticoneContextMenuStrip2.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip2.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.siticoneContextMenuStrip2.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.siticoneContextMenuStrip2.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.siticoneContextMenuStrip2.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.siticoneContextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox3.BackColor = System.Drawing.Color.Transparent;
            this.richTextBox3.BorderColor = System.Drawing.Color.Transparent;
            this.richTextBox3.BorderRadius = 20;
            this.richTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox3.DefaultText = "";
            this.richTextBox3.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.richTextBox3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.richTextBox3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.richTextBox3.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.richTextBox3.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.richTextBox3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.richTextBox3.Location = new System.Drawing.Point(47, 585);
            this.richTextBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.richTextBox3.Multiline = true;
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.PasswordChar = '\0';
            this.richTextBox3.PlaceholderText = "";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.SelectedText = "";
            this.richTextBox3.Size = new System.Drawing.Size(345, 40);
            this.richTextBox3.TabIndex = 14;
            this.richTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Font = new System.Drawing.Font("Arial Black", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 654);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(483, 23);
            this.label4.TabIndex = 20;
            this.label4.Text = "Desenvolvido por Ricardo Piza - pizricardo@gmail.com";
            // 
            // _listViewProducts
            // 
            this._listViewProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._listViewProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._listViewProducts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._listViewProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this._listViewProducts.GridLines = true;
            this._listViewProducts.HideSelection = false;
            this._listViewProducts.Location = new System.Drawing.Point(47, 72);
            this._listViewProducts.Name = "_listViewProducts";
            this._listViewProducts.Size = new System.Drawing.Size(345, 392);
            this._listViewProducts.TabIndex = 21;
            this._listViewProducts.UseCompatibleStateImageBehavior = false;
            this._listViewProducts.View = System.Windows.Forms.View.Tile;
            // 
            // btnRealizar
            // 
            this.btnRealizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRealizar.BackColor = System.Drawing.Color.Transparent;
            this.btnRealizar.BorderRadius = 25;
            this.btnRealizar.BorderThickness = 1;
            this.btnRealizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRealizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRealizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRealizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRealizar.FillColor = System.Drawing.Color.Transparent;
            this.btnRealizar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRealizar.ForeColor = System.Drawing.Color.Black;
            this.btnRealizar.Location = new System.Drawing.Point(348, 33);
            this.btnRealizar.Name = "btnRealizar";
            this.btnRealizar.Size = new System.Drawing.Size(182, 45);
            this.btnRealizar.TabIndex = 16;
            this.btnRealizar.Text = "Realizar Venda";
            this.btnRealizar.Click += new System.EventHandler(this.btnMakeSale_Click_1);
            this.btnRealizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRealizar_MouseMove);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "Meio de pagamento";
            // 
            // meioPagamentoBox
            // 
            this.meioPagamentoBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.meioPagamentoBox.BackColor = System.Drawing.Color.Transparent;
            this.meioPagamentoBox.BorderColor = System.Drawing.Color.Transparent;
            this.meioPagamentoBox.BorderRadius = 15;
            this.meioPagamentoBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.meioPagamentoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.meioPagamentoBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.meioPagamentoBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.meioPagamentoBox.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meioPagamentoBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.meioPagamentoBox.ItemHeight = 30;
            this.meioPagamentoBox.Items.AddRange(new object[] {
            "",
            "Cartão",
            "Dinheiro"});
            this.meioPagamentoBox.Location = new System.Drawing.Point(67, 42);
            this.meioPagamentoBox.MaxLength = 2;
            this.meioPagamentoBox.Name = "meioPagamentoBox";
            this.meioPagamentoBox.Size = new System.Drawing.Size(159, 36);
            this.meioPagamentoBox.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.07246F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.92754F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnRealizar, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.meioPagamentoBox, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(452, 547);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.66234F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.33766F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(533, 81);
            this.tableLayoutPanel3.TabIndex = 23;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::EasyPDV.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(988, 501);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(43, 40);
            this.btnRefresh.TabIndex = 19;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRefresh_MouseMove);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = global::EasyPDV.Properties.Resources.dust1;
            this.btnCancel.ImageSize = new System.Drawing.Size(40, 40);
            this.btnCancel.Location = new System.Drawing.Point(332, 470);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 68);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseMove);
            // 
            // FrmApp
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(211)))), ((int)(((byte)(251)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1075, 677);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this._listViewProducts);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1000, 716);
            this.Name = "FrmApp";
            this.Text = "EasyPDV Sistema de ponto de venta para festas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conferirFaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharCaixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirCaixaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip siticoneContextMenuStrip1;
        private Siticone.Desktop.UI.WinForms.SiticoneContextMenuStrip siticoneContextMenuStrip2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox richTextBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView _listViewProducts;
        private System.Windows.Forms.ToolStripMenuItem vendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelarVendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarVendasToolStripMenuItem;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnRealizar;
        private System.Windows.Forms.Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox meioPagamentoBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnRefresh;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnCancel;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button16;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button15;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button14;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button13;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button12;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button11;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button10;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button9;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button8;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button7;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button6;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button5;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button4;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton button1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
    }
}

