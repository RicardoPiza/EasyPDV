namespace EasyPDV.UI {
    partial class TelaCadastroProduto {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProdNome = new System.Windows.Forms.Label();
            this.lblProdPreco = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCadastrar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.dataGridView1 = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcluir = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnAlterar = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.textBox2 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.textBox1 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.siticoneTextBox1 = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCaminho = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.txtEstoque = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProdNome
            // 
            this.lblProdNome.AutoSize = true;
            this.lblProdNome.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdNome.Location = new System.Drawing.Point(8, 704);
            this.lblProdNome.Name = "lblProdNome";
            this.lblProdNome.Size = new System.Drawing.Size(69, 22);
            this.lblProdNome.TabIndex = 0;
            this.lblProdNome.Text = "Nome:";
            // 
            // lblProdPreco
            // 
            this.lblProdPreco.AutoSize = true;
            this.lblProdPreco.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdPreco.Location = new System.Drawing.Point(7, 753);
            this.lblProdPreco.Name = "lblProdPreco";
            this.lblProdPreco.Size = new System.Drawing.Size(70, 22);
            this.lblProdPreco.TabIndex = 1;
            this.lblProdPreco.Text = "Preço:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 648);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Insira os dados do produto";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadastrar.BorderRadius = 25;
            this.btnCadastrar.BorderThickness = 1;
            this.btnCadastrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCadastrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCadastrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCadastrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCadastrar.FillColor = System.Drawing.Color.Transparent;
            this.btnCadastrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.ForeColor = System.Drawing.Color.Black;
            this.btnCadastrar.Location = new System.Drawing.Point(651, 681);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(221, 45);
            this.btnCadastrar.TabIndex = 17;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            this.btnCadastrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.Location = new System.Drawing.Point(12, 65);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(474, 302);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 60;
            this.dataGridView1.Size = new System.Drawing.Size(860, 562);
            this.dataGridView1.TabIndex = 18;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ThemeStyle.HeaderStyle.Height = 25;
            this.dataGridView1.ThemeStyle.ReadOnly = false;
            this.dataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(257, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Lista de produtos";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExcluir.BorderRadius = 25;
            this.btnExcluir.BorderThickness = 1;
            this.btnExcluir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExcluir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExcluir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExcluir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExcluir.FillColor = System.Drawing.Color.Transparent;
            this.btnExcluir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.Black;
            this.btnExcluir.Location = new System.Drawing.Point(389, 903);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(221, 45);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir selecionado";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            this.btnExcluir.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAlterar.BorderRadius = 25;
            this.btnAlterar.BorderThickness = 1;
            this.btnAlterar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAlterar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAlterar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAlterar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAlterar.FillColor = System.Drawing.Color.Transparent;
            this.btnAlterar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.ForeColor = System.Drawing.Color.Black;
            this.btnAlterar.Location = new System.Drawing.Point(651, 903);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(221, 45);
            this.btnAlterar.TabIndex = 21;
            this.btnAlterar.Text = "Alterar selecionado";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            this.btnAlterar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCadastrar_MouseMove);
            // 
            // textBox2
            // 
            this.textBox2.BorderRadius = 18;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.DefaultText = "";
            this.textBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox2.Location = new System.Drawing.Point(108, 737);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.PlaceholderText = "R$";
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(123, 38);
            this.textBox2.TabIndex = 22;
            // 
            // textBox1
            // 
            this.textBox1.BorderRadius = 18;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.DefaultText = "";
            this.textBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textBox1.Location = new System.Drawing.Point(108, 688);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.PlaceholderText = "Ex: Pastel";
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(305, 38);
            this.textBox1.TabIndex = 23;
            // 
            // siticoneTextBox1
            // 
            this.siticoneTextBox1.BorderRadius = 18;
            this.siticoneTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.siticoneTextBox1.DefaultText = "";
            this.siticoneTextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.siticoneTextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.siticoneTextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.siticoneTextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.siticoneTextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneTextBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneTextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.siticoneTextBox1.Location = new System.Drawing.Point(108, 786);
            this.siticoneTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.siticoneTextBox1.Name = "siticoneTextBox1";
            this.siticoneTextBox1.PasswordChar = '\0';
            this.siticoneTextBox1.PlaceholderText = "Caminho da imagem";
            this.siticoneTextBox1.SelectedText = "";
            this.siticoneTextBox1.Size = new System.Drawing.Size(305, 38);
            this.siticoneTextBox1.TabIndex = 25;
            this.siticoneTextBox1.TextChanged += new System.EventHandler(this.siticoneTextBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 802);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Imagem:";
            // 
            // btnCaminho
            // 
            this.btnCaminho.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCaminho.BorderRadius = 18;
            this.btnCaminho.BorderThickness = 1;
            this.btnCaminho.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCaminho.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCaminho.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCaminho.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCaminho.FillColor = System.Drawing.Color.Transparent;
            this.btnCaminho.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaminho.ForeColor = System.Drawing.Color.Black;
            this.btnCaminho.Location = new System.Drawing.Point(650, 786);
            this.btnCaminho.Name = "btnCaminho";
            this.btnCaminho.Size = new System.Drawing.Size(51, 38);
            this.btnCaminho.TabIndex = 26;
            this.btnCaminho.Text = "...";
            this.btnCaminho.Click += new System.EventHandler(this.btnCaminho_Click);
            // 
            // txtEstoque
            // 
            this.txtEstoque.BorderRadius = 18;
            this.txtEstoque.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEstoque.DefaultText = "";
            this.txtEstoque.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEstoque.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEstoque.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEstoque.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEstoque.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEstoque.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoque.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEstoque.Location = new System.Drawing.Point(108, 834);
            this.txtEstoque.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.PasswordChar = '\0';
            this.txtEstoque.PlaceholderText = "Quantidade";
            this.txtEstoque.SelectedText = "";
            this.txtEstoque.Size = new System.Drawing.Size(123, 38);
            this.txtEstoque.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 850);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "Estoque:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::EasyPDV.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(11, 915);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(38, 34);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TelaCadastroProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(884, 961);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtEstoque);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCaminho);
            this.Controls.Add(this.siticoneTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProdPreco);
            this.Controls.Add(this.lblProdNome);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 1000);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 1000);
            this.Name = "TelaCadastroProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Cadastro Produto";
            this.Load += new System.EventHandler(this.TelaCadastroProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProdNome;
        private System.Windows.Forms.Label lblProdPreco;
        private System.Windows.Forms.Label label1;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnCadastrar;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnExcluir;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnAlterar;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox textBox2;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox textBox1;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox siticoneTextBox1;
        private System.Windows.Forms.Label label3;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnCaminho;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtEstoque;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
    }
}