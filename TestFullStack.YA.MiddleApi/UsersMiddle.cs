using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFullStack.YA.Core;
using TestFullStack.YA.Data;

namespace TestFullStack.YA.Middle
{
    public class UsersMiddle
    {
        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Utilisateur get(int id)
        { 
            IQueryable<Utilisateur> Result = UsersAccess.get(id);
            return  Result.Any() ? Result.First() : null;
        }
        /// <summary>
        /// get user by Login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Utilisateur get(string login)
        {
            if (login != null)
            {
                IQueryable<Utilisateur> Result = UsersAccess.get(login);
                return Result.Any() ? Result.First() : null;
            }
            return null;
        }

        /// <summary>
        /// get user by Login and password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Utilisateur get(string login, string password)
        {
            if (login!=null && password!=null)
            {
                IQueryable<Utilisateur> Result = UsersAccess.get(login, Utils.CreateMD5(password));
                return Result.Any() ? Result.First() : null; 
            }
            return null;
        }

        /// <summary>
        /// add a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Add(Utilisateur user)
        {
            if (user!=null && !UsersAccess.get(user.login).Any())
            {
                user.password = Utils.CreateMD5(user.password);
                UsersAccess.insert(user);
                return true;
            }
            return false;
        }

    }
}
