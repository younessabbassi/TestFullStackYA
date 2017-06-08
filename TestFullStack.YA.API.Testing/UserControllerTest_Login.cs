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
            var driver = new ChromeDriver(); 
            driver.Navigate().GoToUrl(urlApp); 
            var txtLogin = driver.FindElement(By.Id("loginCnx"));
            txtLogin.SendKeys("koko"); 
            var pwBox = driver.FindElement(By.Id("passwordCnx"));
            pwBox.SendKeys("koko"); 
            var btnlogin = driver.FindElement(By.Id("btnLogin"));
            btnlogin.Click();
            driver.Quit(); 
        }

        /// <summary>
        /// test case for Login/password not correct
        /// </summary>
        [TestMethod]
        public void GetTestToLogiFail()
        {
            string urlApp = "http://localhost:51468/Front/UserForms.html";
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(urlApp);
            var txtLogin = driver.FindElement(By.Id("loginCnx"));
            txtLogin.SendKeys("koko");
            var pwBox = driver.FindElement(By.Id("passwordCnx"));
            pwBox.SendKeys("badpassword");
            var btnlogin = driver.FindElement(By.Id("btnLogin"));
            btnlogin.Click();
            driver.Quit();
        }
    }
}
