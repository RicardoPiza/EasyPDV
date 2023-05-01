using EasyPDV.Entities;
using EasyPDV.Model;
using EasyPDV.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyPDV.UI
{
    public partial class FrmLoginScreen : Form
    {
        UserDAO userDAO = new UserDAO();
        public FrmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (GetUser())
            {
                FrmSplashScreen frmSplashScreen = new FrmSplashScreen();
                FrmHelper.OpenIfIsNot("FrmSplashScreen", frmSplashScreen);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inexistentes");
            }
        }
        public bool GetUser()
        {
            User user = new User();
            user = userDAO.GetByLogin(txtUserLogin.Text.Trim().ToLower());
            if (user != null && user.Password == txtUserPassword.Text)
            {
                LoginInfo.SetUser(user);
                return true;
            }
            else
            {
                return false;                
            }
        }

        private void FrmLoginScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
