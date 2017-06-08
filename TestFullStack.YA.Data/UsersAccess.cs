using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFullStack.YA.Data
{
    /// <summary>
    /// Data layer class for traiting the User Table 
    /// </summary>
    public class UsersAccess
    {
        /// <summary>
        /// Add a user to the Table User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool insert(Utilisateur user)
        {
            DataBaseEntities DB = new DataBaseEntities();
            DB.Utilisateur.Add(user);
            DB.SaveChanges();
            return true;
        }

        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IQueryable<Utilisateur> get(int id)
        {
            DataBaseEntities DB = new DataBaseEntities();
            return DB.Utilisateur.Where(a => a.id == id);
        }

        /// <summary>
        /// get user by login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static IQueryable<Utilisateur> get(string login)
        {
            DataBaseEntities DB = new DataBaseEntities();
            return DB.Utilisateur.Where(a => a.login == login);
        }

        /// <summary>
        /// get user by Login and password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static IQueryable<Utilisateur> get(string login, string password)
        {
            DataBaseEntities DB = new DataBaseEntities();
            bool ok = false;
            return DB.Utilisateur.Where(a => a.login == login && a.password == password);
        }

        
    }
}
