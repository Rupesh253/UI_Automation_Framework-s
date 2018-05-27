using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Net;
using System.Net.Http;
using System.Threading;
using AutoIt;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace SomeInAutomation
{
    [TestFixture]
    public class AutoITTesting
    {
        IWebDriver driver;
        string uri = "https://www.google.co.in/imghp?hl=en&tab=wi&authuser=0";
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            //string chromeDriverDirectory = @"C:\Users\Rupesh Chaitu\source\repos\SomeInAutomation\SomeInAutomation\bin\Debug\chromedriver.exe";
            //driver = new ChromeDriver( options,TimeSpan.FromMinutes(2));

            //driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Cookies.DeleteAllCookies();
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\chromedriver.exe");
            //System.Environment.SetEnvironmentVariable("webdriver.ie.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\IEDriverServer.exe");
            System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\geckodriver.exe");

        }


        [Test]
        public void WindowPopUp()
        {

            driver.Navigate().GoToUrl(uri);
            Thread.Sleep(10000);
            //IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //jse.ExecuteScript("document.getElementById('qbi').click();");

            driver.FindElement(By.Id("qbi")).Click();
            Thread.Sleep(1000);


            driver.FindElement(By.PartialLinkText("Upload an image")).Click();

            Actions actions = new Actions(driver);
            actions.DoubleClick(driver.FindElement(By.Id("qbfile"))).Build().Perform();

           

            //jse.ExecuteScript("document.getElementById('qbfile').click().click();");
            Thread.Sleep(1000);
            SendKeys.SendWait(@"C:\Users\Rupesh Chaitu\Downloads\IMG_20180106_192642_392.jpg");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");

            Thread.Sleep(10000);
   
            //string driverType = driver.GetType().ToString();

            //switch(driverType)
            //{
            //    case "chrome":

            //C:\Users\Rupesh Chaitu\Downloads\IMG_20180106_192642_392.jpg        break;
            //    case "firefox":
            //        break;
            //    case "IE":
            //        break;
            //}


            //AutoItX.Send(@"C: \Users\Rupesh Chaitu\Downloads\IMG_20180106_192642_392.jpg");
            //AutoItX.Send("{ENTER}");
            //Thread.Sleep(2000);




        }



        [TearDown]
        public void Teardown()
        {
            //driver.Close();
            //driver.Quit();
        }
    }


}
