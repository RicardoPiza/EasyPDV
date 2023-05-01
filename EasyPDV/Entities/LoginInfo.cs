using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPDV.Entities
{
    internal class LoginInfo
    {
        public static User LoggedUser { get; set; }

        public static void SetUser(User user)
        {
            LoggedUser = new User();
            LoggedUser.Id = user.Id;
            LoggedUser.Login = user.Login;
            LoggedUser.Password = user.Password;
            LoggedUser.Active = user.Active;
            LoggedUser.Admin = user.Admin;
        }
        public static User GetUser()
        {
            User user = new User();
            user.Id = LoggedUser.Id;
            user.Login = LoggedUser.Login;
            user.Password = LoggedUser.Password;
            user.Active = LoggedUser.Active;
            user.Admin = LoggedUser.Admin;
            return user;
        }
    }
}
