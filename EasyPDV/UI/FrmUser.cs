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
            btnChange.Cursor = Cursors.Hand;
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

            if (txtUserLogin.Text != "" && txtUserName.Text != "" && txtUserPassword.Text != "")
            {
                if (!txtUserLogin.Text.Any(x => char.IsWhiteSpace(x)))
                {
                    if (txtUserPassword.Text.Length >= 8)
                    {
                        if (!userDao.CheckLogin(user.Login))
                        {
                            userDao.CreateUser(user);
                            MessageBox.Show("Usuário criado com sucesso.");
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Nome de usuário ja existente.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Senha deve ter no mínimo 8 caractéres.");
                    }
                }
                else
                {
                    MessageBox.Show("Nome de login não deve conter espaços.");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos.");
            }
            
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {

        }
    }
}
