using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestFullStack.YA.MiddleApi;
using TestFullStack.YA.Data;
namespace TestFullStack.YA.Api.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// get User By ID
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        
        public JsonResult<Utilisateur> GetUserById(int id)
        {
            return Json(UsersAccess.get(id));
        }
         
        public  JsonResult<Utilisateur> GetUserByLoginPass(string login,string password) {
            if (login != null && password != null)
            {

            }
            return Json(UsersMiddle.get(login, password));
        }

        public JsonResult<bool> AddUser(string name, string mail, string login, string pass)
        {
            if (name !=null && mail !=null && login != null && pass!=null)
            {
                if (UsersMiddle.get(login)!=null)
                {
                    return Json(false);
                }
                else
                {
                    UsersMiddle.Add(
                    new Utilisateur
                    {
                        Name = name,
                        email = mail,
                        password = pass
                    });
                } 
            }
            return Json(true);

        }

        // POST: api/Users 
        public void Post(Utilisateur user)
        {
            UsersMiddle.Add(user);
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
