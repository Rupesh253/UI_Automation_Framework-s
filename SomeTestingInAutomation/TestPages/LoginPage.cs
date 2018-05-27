using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using SomeTestingInAutomation.TestAuxiliaries;
using SomeTestingInAutomation.TestReporter.TestAuditFiles;

namespace SomeTestingInAutomation.TestPages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoginPage(IWebDriver driver)
        {          
            driver.Manage().Window.Maximize();
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "UserName")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password"), CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "Login"), CacheLookup]
        public IWebElement Login { get; set; }

        public void DoLogin(string userName, string password)
        {
           
            log.Info("Entered into DoLogin with username and password");
            log.Debug($"userName={userName}");
            log.Debug($"password={password}");
            new ScreenShot(driver).Save(driver, "Login", 1, "Initial Page");
            new Helpers.BasicMethods(driver).TextBox(driver, UserName, userName);
            //new Helpers.Validations(driver).ValidateRegex(driver,UserName,Helpers.Validations.Type.Username.ToString());
            new Helpers.BasicMethods(driver).TextBox(driver, Password, password);
            new Helpers.BasicMethods(driver).Button(driver, Login);
            new ScreenShot(driver).Save(driver, "Login", 1, "Final Page");
            new AuditFile().Generate("Login",1,"Audit");
            Thread.Sleep(2000);
        }
    }
}
