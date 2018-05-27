//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Support.UI;
//using OpenQA.Selenium.Support;
//using RestSharp;
//using Newtonsoft.Json;
//using System.Collections.ObjectModel;
//using NUnit.Framework;
//using OpenQA.Selenium.Remote;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.IO;
//using SomeTestingInAutomation.TestAuxiliaries;

//namespace SomeTestingInAutomation
//{

//    [TestFixture]
//    public class DummyTC
//    {

//        [TestCase]

//        public void SomeTestMethod1InDummyTC()
//        {
//            BrowserFactory.BrowserName = BrowserFactory.SelectBrowser.FireFox.ToString();
//            Console.WriteLine($"{BrowserFactory.BrowserName}");


//            switch (BrowserFactory.BrowserName)
//            {
//                case "Chrome": string b = "Chrome"; Console.WriteLine($"{b}");
//                    break;
//                case "IE":
//                    string c = "IE"; Console.WriteLine($"{c}");
//                    break;
//                case "FireFox":
//                    string d = "FireFox"; Console.WriteLine($"{d}");
//                    break;
//                default:
//                    string e = "Boo"; Console.WriteLine($"{e}");
//                    break;              
//            }




//            IWebDriver driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Manage().Cookies.DeleteAllCookies();
//            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdghhf&Password=dfgdfg&Login=Login";
//            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
//            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Red';");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('TitleId').selectedIndex=1;");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Green';");
//            Thread.Sleep(20);

//            jse.ExecuteScript("document.getElementById('Initial').style.borderColor='Red';" +
//                              "document.getElementById('Initial').value='Somala';" +
//                              "document.getElementById('Initial').style.borderColor='Green';");
//            Thread.Sleep(20);

//            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Red';");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('FirstName').value='Rupesh';");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Green';");
//            Thread.Sleep(20);

//            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Red';");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('MiddleName').value='Kumar';");
//            Thread.Sleep(20);
//            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Green';");
//            Thread.Sleep(20);


//            Assert.AreEqual("Execute Automation", driver.Title);


//            driver.Close();
//            driver.Quit();


//        }

//    }
//}
