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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.actionCombo = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.btnChange = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.lblChange = new System.Windows.Forms.Label();
            this.comboProductChange = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.comboProduct = new Siticone.Desktop.UI.WinForms.SiticoneComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.15461F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.84539F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.actionCombo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnChange, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblChange, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboProductChange, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboProduct, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(44, 74);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(401, 189);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 14);
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
            this.actionCombo.Location = new System.Drawing.Point(156, 5);
            this.actionCombo.MaxLength = 2;
            this.actionCombo.Name = "actionCombo";
            this.actionCombo.Size = new System.Drawing.Size(170, 36);
            this.actionCombo.StartIndex = 0;
            this.actionCombo.TabIndex = 34;
            this.actionCombo.SelectedIndexChanged += new System.EventHandler(this.actionCombo_SelectedIndexChanged);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnChange.Location = new System.Drawing.Point(156, 141);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(242, 45);
            this.btnChange.TabIndex = 17;
            this.btnChange.Text = "Realizar ação";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // lblChange
            // 
            this.lblChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(52, 106);
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
            this.comboProductChange.Location = new System.Drawing.Point(156, 97);
            this.comboProductChange.MaxLength = 2;
            this.comboProductChange.Name = "comboProductChange";
            this.comboProductChange.Size = new System.Drawing.Size(242, 36);
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
            this.comboProduct.Location = new System.Drawing.Point(156, 51);
            this.comboProduct.MaxLength = 2;
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(242, 36);
            this.comboProduct.TabIndex = 32;
            this.comboProduct.SelectedIndexChanged += new System.EventHandler(this.comboProduct_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Produto vendido:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(108, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Estornar ou trocar produto";
            // 
            // FrmReversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EasyPDV.Properties.Resources._012_Tempting_Azure;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 332);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 371);
            this.MinimumSize = new System.Drawing.Size(500, 371);
            this.Name = "FrmReversal";
            this.Text = "Estorno ou Troca";
            this.Load += new System.EventHandler(this.FrmReversal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
    }
}