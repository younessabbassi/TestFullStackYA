using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using TestFullStack.YA.Middle;
using TestFullStack.YA.Data;
using TestFullStack.YA.Core;

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
        /// Action permettant de retrouver un utilisateur par son Login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Utilisateur GetUserByLogin(string login)
        {
            if (login != null )
            {
                if (UsersMiddle.get(login) != null)
                {
                    return UsersMiddle.get(login);
                }
            }
            return null;
        }

        /// <summary>
        /// Action permettant d'ajouter un nouveau Utilisateur
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <returns></returns> 
        [AcceptVerbs("GET", "POST")]
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

        /// <summary>
        /// Permet de créer un nouveau utilisateur 
        /// </summary>
        /// <param name="user">type Utilisateur</param>
        /// <returns></returns>
        public IHttpActionResult Post(Utilisateur user)
        {
            if (user.Name != null && user.email != null && user.login != null && user.password != null)
            {
                if (UsersMiddle.get(user.login) == null)
                {
                    return Json(UsersMiddle.Add(user)); 
                }
            }  
            return Json(false);
        }
         
    }
}
