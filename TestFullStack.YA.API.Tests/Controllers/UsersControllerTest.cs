using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFullStack.YA.API;
using TestFullStack.YA.API.Controllers;

namespace TestFullStack.YA.API.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            
            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        /// <summary>
        /// get User By ID
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns> 
        public void GetUserById(int id)
        {
           
        }
        /// <summary>
        /// Action permettant de verifier la validité des credentieles 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public void GetUserByLoginPass(string login, string password)
        {
            
        }
  

        /// <summary>
        /// Permet de tester la creation de l'utilisateur
        /// </summary>
        /// <param name="user">type Utilisateur</param>
        /// <returns></returns>
        public void Post(Utilisateur user)
        {
            
        }



    }
}
