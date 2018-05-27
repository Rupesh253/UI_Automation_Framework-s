using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace SomeTestingInAutomation.TestAuxiliaries
{
    public class ChromeSettings
    {
        public IWebDriver KickStartChrome()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDirectory, "chromedriver.exe");
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = false;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;
            options.AddArguments("disable-infobars");
            options.AddArguments("start-maximized");
            options.AddArguments("test-type");
            IWebDriver driver = new ChromeDriver(options);
            System.Environment.SetEnvironmentVariable("web.chrome.driver", Path.Combine(baseDirectory, exePath));
            return driver;
        }
    }
    public class IESettings : ChromeSettings
    {
        public IWebDriver KickStartIE()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDirectory, "IEDriverServer.exe");
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.AcceptInsecureCertificates = false; //but it has to be true.
            options.EnsureCleanSession = true;
            options.IgnoreZoomLevel = true;
            options.InitialBrowserUrl = ""; //go for msn or google homepage
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.RequireWindowFocus = true;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;
            IWebDriver driver1 = new InternetExplorerDriver(options);
            System.Environment.SetEnvironmentVariable("web.ie.driver", Path.Combine(baseDirectory, exePath));
            return driver1;

        }
    }
    public class FireFoxSettings : IESettings
    {
        public IWebDriver KickStartFireFox()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = Path.Combine(baseDirectory, "geckodriver.exe");
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = false;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.AcceptAndNotify;
            options.UseLegacyImplementation = true; //In C# binding, FirefoxDriver in legacy mode demands geckodriver to be in the PATH. It does not use it to drive the browser, but it fails if geckodriver is not available.               
            IWebDriver driver2 = new FirefoxDriver(options);
            System.Environment.SetEnvironmentVariable("web.gecko.driver", Path.Combine(baseDirectory, exePath));
            return driver2;           
        }

        public class BrowserFactory: FireFoxSettings
        {
            public enum SelectBrowser
            {
                IE,
                Chrome,
                FireFox
            }
            public string BrowserName { get; set; }

        }

    }
}


