using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
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
using System.IO;
using SomeTestingInAutomation.TestAuxiliaries;
using static SomeTestingInAutomation.TestAuxiliaries.FireFoxSettings;

namespace SomeTestingInAutomation
{


    [TestFixture]
    public class DummyTC1 : BrowserFactory
    {
        public IWebDriver driver1;
        BrowserFactory bf = new BrowserFactory();
        [TestCase]
        public void SomeTestMethod1InDummyTC1()
        {           
            bf.BrowserName = BrowserFactory.SelectBrowser.Chrome.ToString();
            Console.WriteLine($"{bf.BrowserName}");

            switch (bf.BrowserName)
            {
                case "Chrome":
                    string b = "Chrome";
                    Console.WriteLine($"{b}");
                    //new ChromeSettings().KickStartChrome(driver);
                    //DummyTC1 t1 = new DummyTC1();
                    //t1.HasToRun(driver1);
                    Console.WriteLine("Breaked");
               
                    break;
                case "IE":
                    string c = "IE";
                    Console.WriteLine($"{c}");
                    //new IESettings().KickStartIE(driver);
                    //DummyTC1 t2 = new DummyTC1();
                    //t2.HasToRun(driver);
                    Console.WriteLine("Breaked");
                    break;
                case "FireFox":
                    string d = "FireFox";
                    Console.WriteLine($"{d}");
                    //new FireFoxSettings().KickStartFireFox(driver);
                    DummyTC1 t3 = new DummyTC1();
                    //t3.HasToRun(driver);
                    break;
                default:
                    string e = "Select a browser"; Console.WriteLine($"{e}");
                    break;
            }

        }

        public void HasToRun(IWebDriver driver)
        {
            //IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            Console.WriteLine("Entered");
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=fdghhf&Password=dfgdfg&Login=Login");
            Console.WriteLine("Entered1");
            //driver1.Url = "http://executeautomation.com/demosite/index.html?UserName=fdghhf&Password=dfgdfg&Login=Login";
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Blue';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('TitleId').selectedIndex=1;");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Green';");
            Thread.Sleep(20);

            jse.ExecuteScript("document.getElementById('Initial').style.borderColor='Blue';" +
                              "document.getElementById('Initial').value='Somala';" +
                              "document.getElementById('Initial').style.borderColor='Green';");
            Thread.Sleep(20);

            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Blue';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('FirstName').value='Rupesh';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Green';");
            Thread.Sleep(20);

            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Blue';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('MiddleName').value='Kumar';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Green';");
            Thread.Sleep(20);
            Assert.AreEqual("Execute Automation", driver.Title);
            driver.Close();
            driver.Quit();
            Console.WriteLine("Final");
        }

        [TearDown]
        public void Teardown()
        {

        }
    }

}

