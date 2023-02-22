using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Drawing;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace EasyPDV.Utils {
    public class MyMessageBox : Form {
        private Label lblText;
        private Button btnOK;
        public MyMessageBox(string text, string caption) {
            InitializeComponent();

            lblText.Text = text;
            Text = caption;
        }

        private void InitializeComponent() {
            lblText = new Label();
            btnOK = new Button();

            SuspendLayout();

            lblText.AutoSize = true;
            lblText.Location = new Point(12, 9);
            lblText.Name = "lblText";
            lblText.TabIndex = 0;
            lblText.Font = new Font("Arial", 12); // Set the font of the label

            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Margin = new Padding(5);
            btnOK.Name = "btnOK";
            btnOK.TabIndex = 1;
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize= true;
            ClientSize = new Size(225, 80);
            Controls.Add(btnOK);
            Controls.Add(lblText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MyMessageBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "My Message Box";
            ResumeLayout(false);
            PerformLayout();

            // Add a SizeChanged event handler to auto-size the form
            SizeChanged += MyMessageBox_SizeChanged;
        }
        private void MyMessageBox_SizeChanged(object sender, EventArgs e) {
            // Resize the form based on the height of the label
            Height = lblText.Height + 180; // Adjust the constant value to fit your needs
        }

    }
}
