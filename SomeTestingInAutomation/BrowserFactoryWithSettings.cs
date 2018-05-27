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

namespace SomeTestingInAutomation
{
    [TestFixture]
    public class BrowserFactoryWithSettings
    {
        IWebDriver driver;
        
        [TestCase]
        
        public void SomeTestMethod1InBrowserFactoryWithSettings()
        { 
                     
        string inputBrowser = "Chrome";
            switch (inputBrowser)
            {
                case "Chrome":
                    //Deprecated. How will you merge cap and options and send to driver constructor.
                    //DesiredCapabilities cap = new DesiredCapabilities();
                    //cap.SetCapability(CapabilityType.AcceptInsecureCertificates,true);
                    //cap.SetCapability(CapabilityType.AcceptSslCertificates,true);
                    //cap.SetCapability(CapabilityType.HandlesAlerts,true);
                    //cap.SetCapability(CapabilityType.IsJavaScriptEnabled,true);
                    //cap.SetCapability(CapabilityType.UnexpectedAlertBehavior,true);
                    //cap.SetCapability(CapabilityType.UnhandledPromptBehavior,true);
                    
                    ChromeOptions options = new ChromeOptions();
                    options.AcceptInsecureCertificates = true;
                    options.AddArguments("disable-infobars");
                    options.AddArgument("ignore-certificate-errors");
                    options.AddArgument("start-maximized");
                    options.AddArgument("test-type");
                    options.EnableMobileEmulation("Nexus 5");

                    //var proxy = new Proxy();
                    //proxy.Kind = ProxyKind.Manual;
                    //proxy.IsAutoDetect = true;
                    //proxy.HttpProxy = "";                    
                    //proxy.SslProxy = "";
                    //options.Proxy = proxy;

                    //options.AddExtension(@"load - extension = c:\PathToFirstExtensionHere, c:\PathToSecondExtensionHere");

                    bool? AcceptInsecureCertificates=options.AcceptInsecureCertificates;               
                    ReadOnlyCollection<string> ArgumentsList=options.Arguments;
                    string BinaryLocation=options.BinaryLocation;
                    string BrowserName = options.BrowserName;
                    string BrowserVersion = options.BrowserVersion;
                    string DebuggerAddress = options.DebuggerAddress;
                    ReadOnlyCollection<string> ExtensionsList = options.Extensions;
                    bool LeaveBrowserRunning = options.LeaveBrowserRunning;
                    string MinidumpPath = options.MinidumpPath;
                    PageLoadStrategy PageLoadStrategy = options.PageLoadStrategy;
                    ChromePerformanceLoggingPreferences PerformanceLoggingPreferences = options.PerformanceLoggingPreferences;
                    string PlatformName = options.PlatformName;
                    Proxy Proxy = options.Proxy;
                    UnhandledPromptBehavior UnhandledPromptBehavior = options.UnhandledPromptBehavior;
                    bool UseSpecCompliantProtocol = options.UseSpecCompliantProtocol;

                    Console.WriteLine($"  AcceptInsecureCertificates   : {AcceptInsecureCertificates}");
                    foreach(string s in ArgumentsList)
                    {
                        Console.WriteLine($"  ArgumentsList   : {s}");
                    }
                   
                    Console.WriteLine($" BinaryLocation    : {BinaryLocation}");
                    Console.WriteLine($" BrowserName    : {BrowserName}");
                    Console.WriteLine($" BrowserVersion    : {BrowserVersion}");
                    Console.WriteLine($" DebuggerAddress    : {DebuggerAddress}");
                    foreach (string s in ExtensionsList)
                    {
                        Console.WriteLine($"  ExtensionsList   : {s}");
                    }

                    Console.WriteLine($" LeaveBrowserRunning    : {LeaveBrowserRunning}");
                    Console.WriteLine($" MinidumpPath    : {MinidumpPath}");
                    Console.WriteLine($" PageLoadStrategy    : {PageLoadStrategy}");
                    Console.WriteLine($" PerformanceLoggingPreferences    : {PerformanceLoggingPreferences}");
                    Console.WriteLine($" PlatformName   : {PlatformName}");
                    Console.WriteLine($" Proxy   : {Proxy}");
                    Console.WriteLine($" UnhandledPromptBehavior    : {UnhandledPromptBehavior}");
                    Console.WriteLine($" UseSpecCompliantProtocol   : {UseSpecCompliantProtocol}");

                    //options.AddAdditionalCapability(CapabilityType.AcceptInsecureCertificates,true);
                    //options.AddAdditionalCapability(CapabilityType.AcceptSslCertificates,true);
                    //options.AddAdditionalCapability(CapabilityType.HandlesAlerts, true);
                    //options.AddAdditionalCapability(CapabilityType.IsJavaScriptEnabled, true);
                    //options.AddAdditionalCapability(CapabilityType.UnexpectedAlertBehavior,true);
                    //options.AddAdditionalCapability(CapabilityType.UnhandledPromptBehavior, UnhandledPromptBehavior.Accept);
                    //options.AddAdditionalCapability(CapabilityType.Platform,PlatformType.Windows); 

                    driver = new ChromeDriver(options);
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\chromedriver.exe");
                    break;

                case "IE":
                     
                    //DesiredCapabilities caps = DesiredCapabilities.InternetExplorer();
                    //caps.SetCapability("ignoreZoomSetting",true);

                    InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                    //ieoptions.ForceCreateProcessApi = true;
                    ieoptions.IgnoreZoomLevel = true;
                    ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //ieoptions.AcceptInsecureCertificates = true;
                    ieoptions.BrowserCommandLineArguments = "-private";

                    //var ieproxy = new Proxy();
                    //ieproxy.Kind = ProxyKind.Manual;
                    //ieproxy.IsAutoDetect = false;
                    //ieproxy.HttpProxy = "127.0.0.1";
                    //ieproxy.SslProxy = "127.0.0.1";
                    //ieoptions.Proxy = ieproxy;
                    
                    driver = new InternetExplorerDriver(ieoptions);

                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\IEDriverServer.exe");
                    break;

                default:
                    Console.WriteLine("Plese enter correct browser here");
                    break;
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();            
            driver.Url = "http://executeautomation.com/demosite/index.html?UserName=fdghhf&Password=dfgdfg&Login=Login";

            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;        
            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Red';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('TitleId').selectedIndex=1;");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('TitleId').style.borderColor='Green';");
            Thread.Sleep(20);
       
            jse.ExecuteScript("document.getElementById('Initial').style.borderColor='Red';" +
                              "document.getElementById('Initial').value='Somala';" +
                              "document.getElementById('Initial').style.borderColor='Green';");        
            Thread.Sleep(20);
         
            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Red';");
            Thread.Sleep(20);        
            jse.ExecuteScript("document.getElementById('FirstName').value='Rupesh';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('FirstName').style.borderColor='Green';");
            Thread.Sleep(20);

            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Red';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('MiddleName').value='Kumar';");
            Thread.Sleep(20);
            jse.ExecuteScript("document.getElementById('MiddleName').style.borderColor='Green';");
            Thread.Sleep(20);
        

            Assert.AreEqual("Execute Automation",driver.Title);


            driver.Close();
            driver.Quit();

        }

    }
}
