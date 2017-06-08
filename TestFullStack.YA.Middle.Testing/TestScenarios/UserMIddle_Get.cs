using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestFullStack.YA.Middle;
namespace TestFullStack.YA.Middle.Testing
{
    [TestClass]
    public class UserMIddle_Get
    {
        /// <summary>
        /// tester the function get by Id (case found)
        /// </summary>
        [TestMethod]
        public void GetUserByIdToFound()
        {
            var utilisater = UsersMiddle.get(1);
            Assert.IsNotNull(utilisater); 
        }

        /// <summary>
        /// tester the function get by login (case fail)
        /// </summary>
        [TestMethod]
        public void GetUserByIdToFail()
        {
            var utilisater = UsersMiddle.get(76);
            Assert.IsNull(utilisater);
        }

        /// <summary>
        /// tester the function get by Id (case found)
        /// </summary>
        [TestMethod]
        public void GetUserByLoginToFound()
        {
            var utilisater = UsersMiddle.get("koko");
            Assert.IsNotNull(utilisater);
        }

        /// <summary>
        /// tester the function get by login (case fail)
        /// </summary>
        [TestMethod]
        public void GetUserByLoginToFail()
        {
            var utilisater = UsersMiddle.get("toto");
            Assert.IsNull(utilisater);
        }


    }
}
