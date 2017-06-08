using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.PhantomJS;
using TestFullStack.YA.API.Controllers;
namespace TestFullStack.YA.API.Testing
{
    /// <summary>
    /// [Selenium test]: Class for testing Login Action scenarios
    /// </summary>
    [TestClass]
    public class UserControllerTest_Login
    { 
       /// <summary>
       /// test case for normal login action
       /// </summary>
        [TestMethod]
        public void GetTestToLoginSuccess()
        {
            string urlApp= "http://localhost:51468/Front/UserForms.html";
            var chromedriver = new ChromeDriver();
            chromedriver.Navigate().GoToUrl(urlApp); 
            var txtLogin = chromedriver.FindElement(By.Id("loginCnx"));
            txtLogin.SendKeys("koko"); 
            var pwBox = chromedriver.FindElement(By.Id("passwordCnx"));
            pwBox.SendKeys("koko"); 
            var btnlogin = chromedriver.FindElement(By.Id("btnLogin"));
            btnlogin.Click();
            var spMessage = chromedriver.FindElement(By.Id("spNameLogged"));
            Assert.AreNotEqual(spMessage.Text,"");
            chromedriver.Quit(); 
        }

        /// <summary>
        /// test case for Login/password not correct
        /// </summary>
        [TestMethod]
        public void GetTestToLogiFail()
        {
            string urlApp = "http://localhost:51468/Front/UserForms.html";
            var chromedriver = new ChromeDriver();
            chromedriver.Navigate().GoToUrl(urlApp);
            var txtLogin = chromedriver.FindElement(By.Id("loginCnx"));
            txtLogin.SendKeys("koko");
            var pwBox = chromedriver.FindElement(By.Id("passwordCnx"));
            pwBox.SendKeys("badpassword");
            var btnlogin = chromedriver.FindElement(By.Id("btnLogin"));
            btnlogin.Click();
            var spMessage = chromedriver.FindElement(By.Id("spNameLogged"));
            Assert.AreEqual(spMessage.Text, "");
            chromedriver.Quit();
        }
    }
}
