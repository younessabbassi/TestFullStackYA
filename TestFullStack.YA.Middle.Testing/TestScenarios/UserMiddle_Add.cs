using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFullStack.YA.Data;
namespace TestFullStack.YA.Middle.Testing
{
    class UserMiddle_Add
    {
        /// <summary>
        /// test case Success
        /// </summary>
        [TestMethod]
        public void AddUserToSuccess()
        {
            Utilisateur toAdd = new Utilisateur()
            {
                email = "email@mail.com",
                Name = "totoo",
                login = "totoo",
                password = "Password1234"                
            };
            bool Added = UsersMiddle.Add(toAdd); 
            Assert.AreEqual(Added,true);
        }

        /// <summary>
        /// test case Fail when Null Parameter
        /// </summary>
        [TestMethod]
        public void AddUserToNullUtilisateurFail()
        {
            Utilisateur toAdd=null;
            bool Added = UsersMiddle.Add(toAdd);
            Assert.AreEqual(Added, false);
        }

        /// <summary>
        /// test case when adding a user with existant Login
        /// </summary>
        [TestMethod]
        public void AddUserWithExistantLoginFail()
        {
            Utilisateur toAdd = new Utilisateur()
            {
                email = "email@mail.com",
                Name = "totoo",
                login = "koko", // existant login
                password = "Password1234"
            };
            bool Added = UsersMiddle.Add(toAdd);
            Assert.AreEqual(Added, false);
        }
    }
}
