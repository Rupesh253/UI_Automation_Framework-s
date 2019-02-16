using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Selenium.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SomeTestingInAutomation
{
    [TestFixture]
    public class JavaScripts
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdgf&Password=dfgdfg&Login=Login";
        }

        [Test]
        public void SomeTestMethod1InJavaScripts()
        {
            //string userName = "Rupesh";
            //string password = "Kumar";
            //string login = "Login";
            //driver.FindElement(By.Name("UserName")).SendKeys(userName);
            //driver.FindElement(By.Name("Password")).SendKeys(password);
            //driver.FindElement(By.Name("Login")).Click();

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            Thread.Sleep(2000);
            jse.ExecuteScript("history.go(0);");
            Thread.Sleep(2000);
            jse.ExecuteScript("window.location='http://executeautomation.com/demosite/index.html?UserName=fdgf&Password=dfgdfg&Login=Login';");

            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Red';");
            Thread.Sleep(10);
            jse.ExecuteScript("document.getElementById('TitleId').selectedIndex=1;");
            Thread.Sleep(10);
            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Green';");
            Thread.Sleep(10);
            //better for dropdowns
            jse.ExecuteScript("document.getElementById('Initial').style.borderColor='Red';" +
                              "document.getElementById('Initial').value='Somala';"+
                              "document.getElementById('Initial').style.borderColor='Green';");                  
            jse.ExecuteScript("");
            Thread.Sleep(10);
            //better for text box
            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Red';");
            Thread.Sleep(10);
            //driver.FindElement(By.Name("FirstName")).SendKeys("Rupesh");
            jse.ExecuteScript("document.getElementById('FirstName').value='Rupesh';");
            Thread.Sleep(10);
            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Green';");
            Thread.Sleep(10);

            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Red';");
            Thread.Sleep(10);
            //driver.FindElement(By.Name("MiddleName")).SendKeys("Kumar");
            jse.ExecuteScript("document.getElementById('MiddleName').value='Kumar';");
            Thread.Sleep(10);
            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Green';");
            Thread.Sleep(10);

            //string framesCount=jse.ExecuteScript("document.frames.length").ToString();
            //Console.WriteLine($"Frames count is {framesCount}");

            

            //jse.ExecuteScript("document.querySelectorAll('Hindi').checked=true;");

            #region  JS Browser BOM
            Int64 justBrowserWindowHeight = (Int64)(jse.ExecuteScript("return window.innerHeight ;"));
            Int64 justBrowserWindowWidth = (Int64)(jse.ExecuteScript("return window.innerWidth ;"));
            Int64 justBrowserWindowScreenHeight = (Int64)(jse.ExecuteScript("return screen.height ;"));
            Int64 justBrowserWindowScreenWidth = (Int64)(jse.ExecuteScript("return screen.width ;"));
            Int64 justBrowserWindowScreenAvailWidth = (Int64)(jse.ExecuteScript("return screen.availWidth ;"));
            Int64 justBrowserWindowScreenAvailHeight = (Int64)(jse.ExecuteScript("return screen.availHeight ;"));
            Int64 justBrowserWindowScreenColorDepth = (Int64)(jse.ExecuteScript("return screen.colorDepth ;"));
            Int64 justBrowserWindowScreenPixelDepth = (Int64)(jse.ExecuteScript("return screen.pixelDepth ;"));

            Console.WriteLine($"justBrowserWindowHeight is : {justBrowserWindowHeight}");
            Console.WriteLine($"justBrowserWindowWidth is : {justBrowserWindowWidth}");
            Console.WriteLine($"justBrowserWindowScreenHeight is : {justBrowserWindowScreenHeight}");
            Console.WriteLine($"justBrowserWindowScreenWidth is : {justBrowserWindowScreenWidth}");
            Console.WriteLine($"justBrowserWindowScreenAvailWidth is : {justBrowserWindowScreenAvailWidth}");
            Console.WriteLine($"justBrowserWindowScreenAvailHeight is : {justBrowserWindowScreenAvailHeight}");
            Console.WriteLine($"justBrowserWindowScreenColorDepth is : {justBrowserWindowScreenColorDepth}");
            Console.WriteLine($"justBrowserWindowScreenPixelDepth is : {justBrowserWindowScreenPixelDepth}");

            string windowLocationHref = (string)(jse.ExecuteScript("window.location.href;"));
            string windowLocationHostname = (string)(jse.ExecuteScript("window.location.hostname;"));
            string windowLocationPathname = (string)(jse.ExecuteScript("window.location.pathname ;"));
            string windowLocationProtocol = (string)(jse.ExecuteScript("window.location.protocol ;"));
            string windowLocationPort = (string)(jse.ExecuteScript("window.location.port ;"));

            Console.WriteLine($"windowLocationHref is : {windowLocationHref}");
            Console.WriteLine($"windowLocationHostname is : {windowLocationHostname}");
            Console.WriteLine($"windowLocationPathname is : {windowLocationPathname}");
            Console.WriteLine($"windowLocationProtocol is : {windowLocationProtocol}");
            Console.WriteLine($"windowLocationPort is : {windowLocationPort}");


            string windowNavigatorCookieEnabled = (string)(jse.ExecuteScript("window.navigator.cookieEnabled;"));
            string windowNavigatorAppName = (string)(jse.ExecuteScript("window.navigator.appName;"));
            string windowNavigatorAppCodeName = (string)(jse.ExecuteScript("window.navigator.appCodeName;"));
            string windowNavigatorProduct = (string)(jse.ExecuteScript("window.navigator.product;"));
            string windowNavigatorAppVersion = (string)(jse.ExecuteScript("window.navigator.appVersion;"));
            string windowNavigatorUserAgent = (string)(jse.ExecuteScript("window.navigator.userAgent;"));
            string windowNavigatorPlatform = (string)(jse.ExecuteScript("window.navigator.platform;"));
            string windowNavigatorLanguage = (string)(jse.ExecuteScript("window.navigator.language;"));
            string windowNavigatorOnLine = (string)(jse.ExecuteScript("window.navigator.onLine;"));
            string windowNavigatorJavaEnabled = (string)(jse.ExecuteScript("window.navigator.javaEnabled();"));

            Console.WriteLine($"windowNavigatorCookieEnabled is : {windowNavigatorCookieEnabled}");
            Console.WriteLine($"windowNavigatorAppName is : {windowNavigatorAppName}");
            Console.WriteLine($"windowNavigatorAppCodeName is : {windowNavigatorAppCodeName}");
            Console.WriteLine($"windowNavigatorProduct is : {windowNavigatorProduct}");
            Console.WriteLine($"windowNavigatorAppVersion is : {windowNavigatorAppVersion}");
            Console.WriteLine($"windowNavigatorUserAgent is : {windowNavigatorUserAgent}");
            Console.WriteLine($"windowNavigatorPlatform is : {windowNavigatorPlatform}");
            Console.WriteLine($"windowNavigatorLanguage is : {windowNavigatorLanguage}");
            Console.WriteLine($"windowNavigatorOnLine is : {windowNavigatorOnLine}");
            Console.WriteLine($"windowNavigatorJavaEnabled is : {windowNavigatorJavaEnabled}");
            #endregion


            jse.ExecuteScript("window.scrollBy(0,530);");
            jse.ExecuteScript("window.scrollBy(0,document.body.scrollHeight);");
            Thread.Sleep(1000);
            // jse.ExecuteScript($"alert('Domain is: document.domain' \n Title is : document.title \n URL is: document.url);");
            string domain = jse.ExecuteScript("return document.domain;").ToString();
            string title = jse.ExecuteScript("return document.title;").ToString();
            string url = (string)(jse.ExecuteScript("return document.URL;"));

            Console.WriteLine($"Domain is : {domain}");
            Console.WriteLine($"Title is : {title}" );
            Console.WriteLine($"URL is : {url}" );
        
            Thread.Sleep(1000);

            //jse.ExecuteScript("alert('Done');");

            string text = jse.ExecuteScript("return document.documentElement.innerText;").ToString();
            Console.WriteLine($"inner text is {text}");

            Thread.Sleep(1000);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();

        }






    }
}
