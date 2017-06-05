using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestFullStack.YA.Data;

namespace TestFullStack.YA.Api.Controllers
{
    public class UsersController : ApiController
    {
        // GET: api/Users
        public IEnumerable<string> Get()
        { 
            return new string[] { "value1", "value2" };
        }

       
        /// <summary>
        /// get User By ID
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public Utilisateur Get(int id)
        {
            return UsersAccess.get(id);
        }

        public Utilisateur get(string login,string password) {
            
        }
        // POST: api/Users
        public void Post([FromBody]string value)
        {
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
