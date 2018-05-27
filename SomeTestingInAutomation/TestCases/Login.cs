using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;
using SomeTestingInAutomation.TestPages;
using System.Xml;
using System.Threading;
using SomeTestingInAutomation.TestAuxiliaries;
using SomeTestingInAutomation.TestReporter.TestAuditFiles;

namespace SomeTestingInAutomation.TestCases
{
    [TestFixture]
    public class Login
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
             string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDirectory, "chromedriver.exe");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            System.Environment.SetEnvironmentVariable("web.chrome.driver", Path.Combine(baseDirectory, exePath));
            driver.Url = "http://executeautomation.com/demosite/Login.html";
            
        }

        [Test][Author("Rupesh")][Category("Sanity Suite")][Order(1)]
        public void LoginMethod()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string xmlPathWithBackSlash = baseDirectory.Replace("bin", "TestData").
                           Replace("Debug", "TestXML_2.xml");
            string xmlPath = xmlPathWithBackSlash.Remove(xmlPathWithBackSlash.Length-1,1);
            Console.WriteLine(xmlPath);
            int i = 1;
            new ScreenShot(driver).Save(driver, "Login", 1, "Initial Page");
            if (File.Exists(xmlPath))
            {               
                XmlDocument docCreated = new XmlDocument();
                docCreated.Load(xmlPath);
                XmlNode nodeUsername = null;
                XmlNode nodePassword = null;
                if (i <= 2)
                {
                    StringBuilder sbSetUsername = new StringBuilder("Set");
                    sbSetUsername.Append(Convert.ToString(i));
                    sbSetUsername.Append("/Username");
                    string xpathUsername =  sbSetUsername.ToString();
                    nodeUsername = docCreated.DocumentElement.SelectSingleNode(xpathUsername);
                    string userName = nodeUsername.InnerText;

                    StringBuilder sbSetPassword = new StringBuilder("Set");
                    sbSetPassword.Append(Convert.ToString(i));
                    sbSetPassword.Append("/Password");
                    string xpathPassword = sbSetPassword.ToString();
                    nodePassword = docCreated.DocumentElement.SelectSingleNode(xpathPassword);
                    string passWord = nodePassword.InnerText;

                    LoginPage loginPage = new LoginPage(driver);
                    loginPage.DoLogin(userName, passWord);
                    Thread.Sleep(2000);
                }
                i++;
             
            }
            new ScreenShot(driver).Save(driver, "Login", 1, "Final Page");

            

        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
            new AuditFile().Generate("Login",1,"RKS");
        }       

    }
}
