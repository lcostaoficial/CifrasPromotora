using System;
using System.Web;
using System.Web.Security;
using System.Linq;
using CIFRAS.Domain.Interfaces.Security;
using CIFRAS.Domain.Entities;
using CIFRAS.Infra.Data.Context;

namespace CIFRAS.Infra.CrossCutting.Security
{
    public class Safety : ISecurity
    {
        public int UserId()
        {
            return Int32.Parse(HttpContext.Current.User.Identity.Name);
        }

        public void LogIn(int userId, bool keepLogged)
        {
            FormsAuthentication.SetAuthCookie(userId.ToString(), keepLogged);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }        

        public static Funcionario GetUserLogged(int userId)
        {
            using (var context = new CifrasContext())
            {
                return context.Funcionarios.FirstOrDefault(x => x.FuncionarioId == userId);
            }
        }
    }
}
