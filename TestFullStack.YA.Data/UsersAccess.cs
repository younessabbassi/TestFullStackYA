using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFullStack.YA.Data
{
    public class UsersAccess
    {
        /// <summary>
        /// Get user by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Users get(int id)
        {
            TestFullStackDBEntities DB = new TestFullStackDBEntities();
            return DB.Users.Where(a=> a.id==id).First();
        }

        /// <summary>
        /// get user by Login and password
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Users get(string login,string password)
        {
            TestFullStackDBEntities DB = new TestFullStackDBEntities();
            return DB.Users.Where(a => a.login==login && a.password==password).First();
        }
    }
}
