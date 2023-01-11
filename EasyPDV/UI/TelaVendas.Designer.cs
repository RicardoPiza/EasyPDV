namespace EasyPDV.UI {
    partial class TelaVendas {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.vendasGridView1 = new Siticone.Desktop.UI.WinForms.SiticoneDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelarVenda = new Siticone.Desktop.UI.WinForms.SiticoneButton();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.vendasGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // vendasGridView1
            // 
            this.vendasGridView1.AllowUserToAddRows = false;
            this.vendasGridView1.AllowUserToDeleteRows = false;
            this.vendasGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.vendasGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.vendasGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.vendasGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.vendasGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.vendasGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.vendasGridView1.ColumnHeadersHeight = 25;
            this.vendasGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.vendasGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.vendasGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.vendasGridView1.Location = new System.Drawing.Point(12, 43);
            this.vendasGridView1.MinimumSize = new System.Drawing.Size(474, 302);
            this.vendasGridView1.MultiSelect = false;
            this.vendasGridView1.Name = "vendasGridView1";
            this.vendasGridView1.ReadOnly = true;
            this.vendasGridView1.RowHeadersVisible = false;
            this.vendasGridView1.RowHeadersWidth = 60;
            this.vendasGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vendasGridView1.Size = new System.Drawing.Size(1165, 453);
            this.vendasGridView1.TabIndex = 19;
            this.vendasGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.vendasGridView1.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendasGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.vendasGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.vendasGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.vendasGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.vendasGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.vendasGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.vendasGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.vendasGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendasGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.vendasGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.vendasGridView1.ThemeStyle.HeaderStyle.Height = 25;
            this.vendasGridView1.ThemeStyle.ReadOnly = true;
            this.vendasGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.vendasGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.vendasGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vendasGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.vendasGridView1.ThemeStyle.RowsStyle.Height = 22;
            this.vendasGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.vendasGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.vendasGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.vendasGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(447, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Lista de Vendas Realizadas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelarVenda.BorderRadius = 25;
            this.btnCancelarVenda.BorderThickness = 1;
            this.btnCancelarVenda.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarVenda.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancelarVenda.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancelarVenda.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancelarVenda.FillColor = System.Drawing.Color.Transparent;
            this.btnCancelarVenda.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenda.ForeColor = System.Drawing.Color.Black;
            this.btnCancelarVenda.Location = new System.Drawing.Point(931, 502);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.PressedColor = System.Drawing.Color.White;
            this.btnCancelarVenda.Size = new System.Drawing.Size(246, 45);
            this.btnCancelarVenda.TabIndex = 21;
            this.btnCancelarVenda.Text = "Cancelar selecionado";
            this.btnCancelarVenda.Click += new System.EventHandler(this.btnCancelarVenda_Click);
            this.btnCancelarVenda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelarVenda_MouseMove);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Image = global::EasyPDV.Properties.Resources.excel;
            this.btnRelatorio.Location = new System.Drawing.Point(12, 502);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(35, 45);
            this.btnRelatorio.TabIndex = 22;
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            this.btnRelatorio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancelarVenda_MouseMove);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vendasGridView1);
            this.Name = "TelaVendas";
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.TelaVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vendasGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Siticone.Desktop.UI.WinForms.SiticoneDataGridView vendasGridView1;
        private System.Windows.Forms.Label label2;
        private Siticone.Desktop.UI.WinForms.SiticoneButton btnCancelarVenda;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnRefresh;
    }
}