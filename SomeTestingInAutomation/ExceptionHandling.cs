using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SomeTestingInAutomation
{
    [TestFixture]
    public class ExceptionHandling
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdgf&Password=dfgdfg&Login=Login";
        }
        [Test]
        public void SomeMethodToTestExceptionHandling()
        {
            //driver.FindElement(By.Name("tytyt")).SendKeys("Kumar");

            try
            {
                driver.FindElement(By.Name("MiddleName")).SendKeys("kumar");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);
                throw new NoSuchElementException();


                

            }
           
        }



        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
