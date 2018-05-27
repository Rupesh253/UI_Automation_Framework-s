using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SomeTestingInAutomation.TestPages;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

namespace SomeTestingInAutomation.TestCases
{
    [TestFixture]
    public class Registration
    {

        public IWebDriver driver;

        [Test][Category("Sanity Suite")][Order(1)]
        public void RegistrationMethod()
        {
            
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDirectory, "chromedriver.exe");
            driver = new ChromeDriver();
            System.Environment.SetEnvironmentVariable("web.chrome.driver", Path.Combine(baseDirectory, exePath));
            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdgf&Password=dfgdfg&Login=Login";
            RegistrationPage registrationPage = new RegistrationPage(driver);
            registrationPage.DoRegistration();
            Thread.Sleep(2000);
            driver.Close();
            driver.Quit();
        }
            



    }
}
