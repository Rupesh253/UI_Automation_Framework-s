using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using SomeTestingInAutomation.TestAuxiliaries;
using System.Diagnostics;

namespace SomeTestingInAutomation.TestPages
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        public RegistrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "TitleId"), CacheLookup]
        public IWebElement TitleId { get; set; }

        [FindsBy(How = How.Id, Using = "Initial"), CacheLookup]
        public IWebElement Initial { get; set; }

        [FindsBy(How = How.Id, Using = "FirstName"), CacheLookup]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "MiddleName"), CacheLookup]
        public IWebElement MiddleName { get; set; }


        public void DoRegistration1(IWebDriver driver, IWebElement element)
        {
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
                              "document.getElementById('Initial').value='Somala';" +
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
            Console.WriteLine($"Title is : {title}");
            Console.WriteLine($"URL is : {url}");

            Thread.Sleep(1000);

            //jse.ExecuteScript("alert('Done');");

            string text = jse.ExecuteScript("return document.documentElement.innerText;").ToString();
            Console.WriteLine($"inner text is {text}");

            Thread.Sleep(1000);
        }

        public void DoRegistration()
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //new Helpers(driver).WaitForElementToBeExist(driver, Initial, 3);
            //new Helpers.Validations(driver).ValidateElementIsDisplayed(driver,Initial);
            //new Helpers.Validations(driver).ValidateElementIsEnabled(driver, Initial);           
            //new Helpers.BasicMethods(driver).TextBox(driver, Initial, "Somala", Initial.GetAttribute("id"));

            //new Helpers(driver).WaitForElementToBeExist(driver, FirstName, 3);
            //new Helpers.Validations(driver).ValidateElementIsDisplayed(driver, FirstName);
            //new Helpers.Validations(driver).ValidateElementIsEnabled(driver, FirstName);
            //new Helpers.BasicMethods(driver).TextBox(driver, FirstName, "Rupesh", FirstName.GetAttribute("id"));


            //new Helpers(driver).WaitForElementToBeExist(driver, MiddleName, 15);
            //new Helpers.Validations(driver).ValidateElementIsDisplayed(driver, MiddleName);
            //new Helpers.Validations(driver).ValidateElementIsEnabled(driver, MiddleName);        
            //new Helpers.BasicMethods(driver).TextBox(driver, MiddleName, "Kumar", MiddleName.GetAttribute("id"));
            //sw.Stop();
            //var seconds = sw.Elapsed;
            //Console.WriteLine($"Time took for DoRegistration() is {seconds}");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Helpers helpers = new Helpers(driver);
            Helpers.BasicMethods basicMethods = new Helpers.BasicMethods(driver);
            Helpers.Validations validations = new Helpers.Validations(driver);
            ScreenShot screenshot = new ScreenShot(driver);

            screenshot.Save(driver,"Registration",1,"while page loaded completely");
            helpers.WaitForElementToBeExist(driver, Initial, 15);
            validations.ValidateElementIsDisplayed(driver, Initial);
            validations.ValidateElementIsEnabled(driver, Initial);
            basicMethods.TextBox(driver, Initial, "Somala", Initial.GetAttribute("id"));

            helpers.WaitForElementToBeExist(driver, FirstName, 15);
            validations.ValidateElementIsDisplayed(driver, FirstName);
            //validations.ValidateRegex(driver,FirstName, "Username");
            validations.ValidateElementIsEnabled(driver, FirstName);
            basicMethods.TextBox(driver, FirstName, "Rupesh", FirstName.GetAttribute("id"));


            helpers.WaitForElementToBeExist(driver, MiddleName, 15);
            validations.ValidateElementIsDisplayed(driver, MiddleName);
            validations.ValidateElementIsEnabled(driver, MiddleName);
            basicMethods.TextBox(driver, MiddleName, "Kumar", MiddleName.GetAttribute("id"));
            screenshot.Save(driver, "Registration", 1, "after page loaded with details");
            sw.Stop();
            var seconds = sw.Elapsed;
            Console.WriteLine("Time took for DoRegistration() is {0:hh\\:mm\\:ss}",seconds);
        }

    }
}   
