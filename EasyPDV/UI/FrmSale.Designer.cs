namespace EasyPDV.UI {
    partial class FrmSale {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSale));
            this.salesGridView1 = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteVenda = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // vendasGridView1
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
            this.salesGridView1.Location = new System.Drawing.Point(12, 43);
            this.salesGridView1.MinimumSize = new System.Drawing.Size(474, 302);
            this.salesGridView1.MultiSelect = false;
            this.salesGridView1.Name = "vendasGridView1";
            this.salesGridView1.ReadOnly = true;
            this.salesGridView1.RowHeadersVisible = false;
            this.salesGridView1.RowHeadersWidth = 60;
            this.salesGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.salesGridView1.Size = new System.Drawing.Size(1165, 453);
            this.salesGridView1.TabIndex = 19;
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
            this.salesGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendasGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(461, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Lista de Vendas Realizadas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnDeleteVenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteVenda.BorderRadius = 25;
            this.btnDeleteVenda.BorderThickness = 1;
            this.btnDeleteVenda.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteVenda.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteVenda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteVenda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteVenda.FillColor = System.Drawing.Color.Transparent;
            this.btnDeleteVenda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVenda.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteVenda.Location = new System.Drawing.Point(931, 502);
            this.btnDeleteVenda.Name = "btnCancelarVenda";
            this.btnDeleteVenda.PressedColor = System.Drawing.Color.White;
            this.btnDeleteVenda.Size = new System.Drawing.Size(246, 45);
            this.btnDeleteVenda.TabIndex = 21;
            this.btnDeleteVenda.Text = "Cancelar selecionado";
            this.btnDeleteVenda.Click += new System.EventHandler(this.btnDeleteSale_Click);
            this.btnDeleteVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelarVenda_MouseMove);
            // 
            // btnRelatorio
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Image = global::EasyPDV.Properties.Resources.excel;
            this.btnReport.Location = new System.Drawing.Point(12, 502);
            this.btnReport.Name = "btnRelatorio";
            this.btnReport.Size = new System.Drawing.Size(35, 45);
            this.btnReport.TabIndex = 22;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            this.btnReport.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelarVenda_MouseMove);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = global::EasyPDV.Properties.Resources.refresh1;
            this.btnRefresh.Location = new System.Drawing.Point(53, 502);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(35, 45);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRefresh_MouseMove);
            // 
            // TelaVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(255)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(1189, 559);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnDeleteVenda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.salesGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1205, 598);
            this.Name = "TelaVendas";
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.FrmSale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.salesGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView salesGridView1;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnDeleteVenda;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnRefresh;
    }
}