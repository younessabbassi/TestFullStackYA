﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        public Utilisateur GetUserById(int id)
        {
            return UsersAccess.get(id);
        }

        public Utilisateur GetUserByLoginPass(string login,string password) {
            return UsersMiddle.get(login, password);
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
