namespace EasyPDV.UI {
    partial class FrmReversal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReversal));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtValue = new Siticone.Desktop.UI.WinForms.SiticoneTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ToChangeProductsCount = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.actionCombo = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.btnChange = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.lblChange = new System.Windows.Forms.Label();
            this.comboProductChange = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.comboProduct = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SoldProductsCount = new Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown();
            this.paymentMethod = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.salesGridView1 = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.lblFillId = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToChangeProductsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoldProductsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.15461F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.84539F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 186F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 206F));
            this.tableLayoutPanel1.Controls.Add(this.txtValue, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.ToChangeProductsCount, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChange, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblChange, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboProductChange, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboProduct, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.SoldProductsCount, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.paymentMethod, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblFillId, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 206);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtValue.BackColor = System.Drawing.Color.Transparent;
            this.txtValue.BorderRadius = 18;
            this.txtValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtValue.DefaultText = "";
            this.txtValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtValue.Location = new System.Drawing.Point(644, 162);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.PasswordChar = '\0';
            this.txtValue.PlaceholderText = "";
            this.txtValue.SelectedText = "";
            this.txtValue.Size = new System.Drawing.Size(129, 35);
            this.txtValue.TabIndex = 24;
            this.txtValue.TextChanged += new System.EventHandler(this.txtValue_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(649, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 22);
            this.label4.TabIndex = 20;
            this.label4.Text = "Meio de pagamento";
            // 
            // ToChangeProductsCount
            // 
            this.ToChangeProductsCount.BackColor = System.Drawing.Color.Transparent;
            this.ToChangeProductsCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ToChangeProductsCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToChangeProductsCount.Location = new System.Drawing.Point(458, 106);
            this.ToChangeProductsCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ToChangeProductsCount.Name = "ToChangeProductsCount";
            this.ToChangeProductsCount.Size = new System.Drawing.Size(81, 38);
            this.ToChangeProductsCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Ação:";
            // 
            // actionCombo
            // 
            this.actionCombo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.actionCombo.BackColor = System.Drawing.Color.Transparent;
            this.actionCombo.BorderColor = System.Drawing.Color.Transparent;
            this.actionCombo.BorderRadius = 15;
            this.actionCombo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.actionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionCombo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.actionCombo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.actionCombo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionCombo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.actionCombo.ItemHeight = 30;
            this.actionCombo.Items.AddRange(new object[] {
            "Estornar",
            "Trocar"});
            this.actionCombo.Location = new System.Drawing.Point(176, 7);
            this.actionCombo.MaxLength = 2;
            this.actionCombo.Name = "actionCombo";
            this.actionCombo.Size = new System.Drawing.Size(170, 36);
            this.actionCombo.StartIndex = 0;
            this.actionCombo.TabIndex = 34;
            this.actionCombo.SelectedIndexChanged += new System.EventHandler(this.actionCombo_SelectedIndexChanged);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChange.BackColor = System.Drawing.Color.Transparent;
            this.btnChange.BorderRadius = 25;
            this.btnChange.BorderThickness = 1;
            this.btnChange.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChange.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChange.FillColor = System.Drawing.Color.Transparent;
            this.btnChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.ForeColor = System.Drawing.Color.Black;
            this.btnChange.Location = new System.Drawing.Point(176, 157);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(220, 45);
            this.btnChange.TabIndex = 17;
            this.btnChange.Text = "Realizar ação";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblChange
            // 
            this.lblChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(72, 118);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(98, 18);
            this.lblChange.TabIndex = 1;
            this.lblChange.Text = "Trocar por:";
            // 
            // comboProductChange
            // 
            this.comboProductChange.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboProductChange.BackColor = System.Drawing.Color.Transparent;
            this.comboProductChange.BorderColor = System.Drawing.Color.Transparent;
            this.comboProductChange.BorderRadius = 15;
            this.comboProductChange.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboProductChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductChange.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProductChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProductChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProductChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboProductChange.ItemHeight = 30;
            this.comboProductChange.Location = new System.Drawing.Point(176, 109);
            this.comboProductChange.MaxLength = 2;
            this.comboProductChange.Name = "comboProductChange";
            this.comboProductChange.Size = new System.Drawing.Size(216, 36);
            this.comboProductChange.TabIndex = 33;
            this.comboProductChange.SelectedIndexChanged += new System.EventHandler(this.comboProductChange_SelectedIndexChanged);
            // 
            // comboProduct
            // 
            this.comboProduct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboProduct.BackColor = System.Drawing.Color.Transparent;
            this.comboProduct.BorderColor = System.Drawing.Color.Transparent;
            this.comboProduct.BorderRadius = 15;
            this.comboProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboProduct.ItemHeight = 30;
            this.comboProduct.Location = new System.Drawing.Point(176, 58);
            this.comboProduct.MaxLength = 2;
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(216, 36);
            this.comboProduct.TabIndex = 32;
            this.comboProduct.SelectedIndexChanged += new System.EventHandler(this.comboProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto vendido:";
            // 
            // SoldProductsCount
            // 
            this.SoldProductsCount.BackColor = System.Drawing.Color.Transparent;
            this.SoldProductsCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SoldProductsCount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoldProductsCount.Location = new System.Drawing.Point(458, 55);
            this.SoldProductsCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SoldProductsCount.Name = "SoldProductsCount";
            this.SoldProductsCount.Size = new System.Drawing.Size(81, 38);
            this.SoldProductsCount.TabIndex = 36;
            // 
            // paymentMethod
            // 
            this.paymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.paymentMethod.BorderColor = System.Drawing.Color.Transparent;
            this.paymentMethod.BorderRadius = 15;
            this.paymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.paymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.paymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.paymentMethod.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethod.ForeColor = System.Drawing.Color.Black;
            this.paymentMethod.ItemHeight = 30;
            this.paymentMethod.Items.AddRange(new object[] {
            "",
            "Cartão crédito",
            "Cartão débito",
            "Dinheiro",
            "Pix"});
            this.paymentMethod.Location = new System.Drawing.Point(643, 54);
            this.paymentMethod.MaxLength = 2;
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.Size = new System.Drawing.Size(201, 36);
            this.paymentMethod.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 24);
            this.label5.TabIndex = 25;
            this.label5.Text = "ID da venda:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(301, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Estornar ou trocar produto";
            // 
            // salesGridView1
            // 
            this.salesGridView1.AllowUserToAddRows = false;
            this.salesGridView1.AllowUserToDeleteRows = false;
            this.salesGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.salesGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.salesGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.salesGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.salesGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.salesGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.salesGridView1.ColumnHeadersHeight = 25;
            this.salesGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.salesGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.salesGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesGridView1.Location = new System.Drawing.Point(12, 299);
            this.salesGridView1.MinimumSize = new System.Drawing.Size(474, 302);
            this.salesGridView1.MultiSelect = false;
            this.salesGridView1.Name = "salesGridView1";
            this.salesGridView1.ReadOnly = true;
            this.salesGridView1.RowHeadersVisible = false;
            this.salesGridView1.RowHeadersWidth = 60;
            this.salesGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salesGridView1.Size = new System.Drawing.Size(847, 302);
            this.salesGridView1.TabIndex = 21;
            this.salesGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.salesGridView1.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.salesGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.salesGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.salesGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.salesGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.salesGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.salesGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.salesGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.salesGridView1.ThemeStyle.HeaderStyle.Height = 25;
            this.salesGridView1.ThemeStyle.ReadOnly = true;
            this.salesGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.salesGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.salesGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.salesGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.salesGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.salesGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // lblFillId
            // 
            this.lblFillId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFillId.AutoSize = true;
            this.lblFillId.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFillId.ForeColor = System.Drawing.Color.Red;
            this.lblFillId.Location = new System.Drawing.Point(643, 141);
            this.lblFillId.Name = "lblFillId";
            this.lblFillId.Size = new System.Drawing.Size(86, 12);
            this.lblFillId.TabIndex = 37;
            this.lblFillId.Text = "Preencha o ID:";
            // 
            // FrmReversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EasyPDV.Properties.Resources._012_Tempting_Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 613);
            this.Controls.Add(this.salesGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(700, 371);
            this.Name = "FrmReversal";
            this.Text = "Estorno ou Troca";
            this.Load += new System.EventHandler(this.FrmReversal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToChangeProductsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoldProductsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblChange;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox comboProduct;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnChange;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox comboProductChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox actionCombo;
        private Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown ToChangeProductsCount;
        private Siticone.Desktop.UI.WinForms.SiticoneNumericUpDown SoldProductsCount;
        private System.Windows.Forms.Label label4;
        private Siticone.Desktop.UI.WinForms.SiticoneComboBox paymentMethod;
        private Siticone.Desktop.UI.WinForms.SiticoneTextBox txtValue;
        private System.Windows.Forms.Label label5;
        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView salesGridView1;
        private System.Windows.Forms.Label lblFillId;
    }
}