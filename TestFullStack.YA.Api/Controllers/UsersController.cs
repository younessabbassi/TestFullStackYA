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
        public IHttpActionResult GetUserById(int id)
        {
            return Json(UsersMiddle.get(id));
        }
         /// <summary>
         /// Action permettant de verifier la validité des credentieles 
         /// </summary>
         /// <param name="login"></param>
         /// <param name="password"></param>
         /// <returns></returns>
        public Utilisateur GetUserByLoginPass(string login,string password) {
            if (login != null && password != null)
            {
                if (UsersMiddle.get(login, password)!=null)
                {
                    return UsersMiddle.get(login, password); 
                }
               
            }
             return null ;
        }

        /// <summary>
        /// Action permettant d'ajouter un nouveau Utilisateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult AddUser(string name, string mail, string login, string pass)
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
                        login=login,
                        password = pass
                    }); 
                    return Json(true);
                } 
            }
            return Json(false); 
        }

        // POST: api/Users 
        public void Post(Utilisateur user)
        {
            UsersMiddle.Add(user);
        }
         
    }
}
