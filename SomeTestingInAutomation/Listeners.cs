using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Support.Events;

namespace SomeTestingInAutomation
{
    [TestFixture]
    public class Listeners
    {
        IWebDriver webDriver;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void SomeTestMethod1InListeners()
        {
            webDriver = new ChromeDriver();
            EventFiringWebDriver driver = new EventFiringWebDriver(webDriver);
            //driver.ElementClicked += new EventHandler<WebElementEventArgs>(firingDriver_ElementClicked);

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdgf&Password=dfgdfg&Login=Login";
            driver.FindElement(By.Name("UserName")).SendKeys("Rupesh");
            driver.Close();
            driver.Quit();
        }

        [TearDown]
        public void Teardown()
        {
        
        }

        private void firingDriver_ElementClicked(object sender, WebDriverExceptionEventArgs e)
        {
            // do action required to handle what happens after clicking button you have mentioned.
        }

    }
}
