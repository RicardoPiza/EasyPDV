﻿using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/RicardoPiza/EasyPDV");
        }

        private void FrmAbout_Load(object sender, System.EventArgs e)
        {

        }
    }
}
