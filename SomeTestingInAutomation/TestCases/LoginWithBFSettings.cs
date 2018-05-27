using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SomeTestingInAutomation.TestAuxiliaries;
using SomeTestingInAutomation.TestPages;
using System.Threading;

namespace SomeTestingInAutomation.TestCases
{
    [TestFixture]
    public class LoginWithBFSettings : KickStarter
    {
        private IWebDriver driver;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Test]
        public void LoginMethodWithBFSettings()
        {

           
            driver = BrowserIntializer("Chrome");
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/Login.html");
            log.Info($"Navigate to login url");
            log.Debug($"Url={driver.Url}");
            log.Debug($"Title={driver.Title}");
            LoginPage loginPage = new LoginPage(driver);
            loginPage.DoLogin("rupesh", "123456");
            driver.FindElement(By.Name("Login")).Click();      
        }


    }
}
