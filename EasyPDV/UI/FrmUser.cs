using EasyPDV.Entities;
using EasyPDV.Model;
using Npgsql;
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
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserDAO userDao = new UserDAO();
            user.CreationDate = DateTime.Now;
            user.Admin = comboUserType.Text == "Administrador" ? true : false;
            user.Active = true;
            user.Password = txtUserPassword.Text;
            user.Login = txtUserLogin.Text.Trim().ToLower();
            user.Name = txtUserName.Text;

            if (!userDao.CheckLogin(user.Login))
            {
                userDao.CreateUser(user);
                MessageBox.Show("Usuário criado com sucesso.");
            }
            else
            {
                MessageBox.Show("Nome de usuário ja existente.");
            }
        }
    }
}
