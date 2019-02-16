using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Data;
using NUnit.Framework;
using System.Net.Http;
using System.Net;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using static SomeTestingInAutomation.TestAuxiliaries.FireFoxSettings;


namespace SomeTestingInAutomation.TestAuxiliaries
{
    public class KickStarter : BrowserFactory
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IWebDriver driver=null;
        public IWebDriver BrowserIntializer(string browserName)
        {
            log.Info("From KickStarter");
            switch (browserName)
            {
                case "Chrome":
                    driver = KickStartChrome();
                    log.Info("Chrome browser selected");
                    break;
                case "IE":
                    driver = KickStartIE();
                    log.Info("IE browser selected");
                    break;
                case "FireFox":
                    driver = KickStartFireFox();
                    log.Info("FireFox browser selected");
                    break;                
            }
            return driver;
        }
        
    }
    public class Helpers
    {
        private IWebDriver driver;
        public Helpers(IWebDriver driver)
        {
            this.driver = driver;
        }
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public class BasicMethods
        {
            private IWebDriver driver;
            public BasicMethods(IWebDriver driver)
            {
                this.driver = driver;
            }
            private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            public void TextBox(IWebDriver driver, IWebElement element, string keys)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript($"arguments[0].value='{keys}';", element);
            }
            public void TextBox(IWebDriver driver, IWebElement element, string keys, string id)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Red';");
                jse.ExecuteScript($"document.getElementById('{id}').value='{keys}';");
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Green';");
            }
            public void Button(IWebDriver driver, IWebElement element)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click();", element);
            }
            public void Button(IWebDriver driver, IWebElement element, string id)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Red';");
                jse.ExecuteScript($"document.getElementById('{id}').click();");
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Green';");
            }
            public enum SelectBy
            {
                Text,
                Value,
                Index
            }
            public void ComboBox(IWebDriver driver, IWebElement element, string by, string byValue)
            {
                SelectElement se = new SelectElement(element);
                switch (by)
                {
                    case "Text":
                        se.SelectByText(byValue);
                        break;
                    case "Value":
                        se.SelectByValue(byValue);
                        break;
                    case "Index":
                        se.SelectByIndex(Convert.ToInt16(byValue));
                        break;
                    default:
                        break;
                }
            }
            public void CheckBox(IWebDriver driver, IWebElement element, string by, string byValue)
            {
                SelectElement se = new SelectElement(element);
                switch (by)
                {
                    case "Text":
                        se.SelectByText(byValue);
                        break;
                    case "Value":
                        se.SelectByValue(byValue);
                        break;
                    case "Index":
                        se.SelectByIndex(Convert.ToInt16(byValue));
                        break;
                    default:
                        break;
                }
            }
            public void HyperLink(IWebDriver driver, IWebElement element)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript("arguments[0].click();", element);
            }
            public void HyperLink(IWebDriver driver, IWebElement element, string id)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Red';");
                jse.ExecuteScript($"document.getElementById('{id}').click();");
                jse.ExecuteScript($"document.getElementById('{id}').style.borderColor='Green';");
            }
            public void DoMouseHover(IWebDriver driver, IWebElement element)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Build().Perform();
            }
            public string ReadyStateOfPage(IWebDriver driver)
            {
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                string readyState = Convert.ToString(jse.ExecuteScript("return document.readystate"));
                return readyState;
            }
            public void CheckForBrokenLinks(IWebDriver driver)
            {
                IReadOnlyCollection<IWebElement> anchorElements = driver.FindElements(By.TagName("a"));
                Dictionary<string, string> hrefAndUITextOfAnchorElements = new Dictionary<string, string>();
                List<string> hrefOfAnchorElements = new List<string>();
                List<string> hrefOfPerfectLinks = new List<string>();
                List<string> hrefOfBrokenLinks = new List<string>();
                List<IWebElement> brokenLinkWebElements = new List<IWebElement>();

                foreach (IWebElement e in anchorElements)
                {
                    hrefAndUITextOfAnchorElements.Add(e.Text, e.GetAttribute("href"));
                    hrefOfAnchorElements.Add(e.GetAttribute("href"));
                }

                foreach (string s in hrefOfAnchorElements)
                {
                    HttpWebRequest httpWebRequest = null;
                    HttpWebResponse httpWebResponse = null;
                    int responseCode = 0;
                    string responseCodeDescription = null;
                    try
                    {
                        httpWebRequest = (HttpWebRequest)WebRequest.Create(s);
                        httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        responseCode = Convert.ToInt32(httpWebResponse.StatusCode);
                        responseCodeDescription = httpWebResponse.StatusCode.ToString();
                        if (responseCode != 200)
                        {
                            hrefOfBrokenLinks.Add(s);
                        }
                        if (responseCode == 200)
                        {
                            hrefOfPerfectLinks.Add(s);
                        }
                    }

                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
            public void SwitchToFrame(IWebDriver driver, int index)
            {
                try
                {
                    driver.SwitchTo().Frame(index);
                }
                catch (NoSuchFrameException ex)
                {
                    Console.WriteLine($"Unable to find out the frame with index{index} in the url {driver.Url},title {driver.Title}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.StackTrace}");
                }

            }
            public void SwitchToFrame(IWebDriver driver, string nameOrId)
            {
                try
                {
                    driver.SwitchTo().Frame(nameOrId);
                }
                catch (NoSuchFrameException ex)
                {
                    Console.WriteLine($"Unable to find out the frame with nameOrId{nameOrId} in the url {driver.Url},title {driver.Title}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.StackTrace}");
                }
            }
            public void SwitchToParentFrame(IWebDriver driver)
            {
                try
                {
                    driver.SwitchTo().ParentFrame();
                }
                catch (Exception ex)
                {

                }
            }
            public void SwitchToDefaultContent(IWebDriver driver)
            {
                try
                {
                    driver.SwitchTo().DefaultContent();
                }
                catch (Exception ex)
                {

                }
            }
            public void AlertAccept(IWebDriver driver)
            {
                driver.SwitchTo().Alert().Accept();
            }
            public void AlertDismiss(IWebDriver driver)
            {
                driver.SwitchTo().Alert().Dismiss();
            }
            public string AlertRead(IWebDriver driver)
            {
                string text = driver.SwitchTo().Alert().Text.ToString();
                return text;
            }
            public void AlertSendKeys(IWebDriver driver, string keys)
            {
                driver.SwitchTo().Alert().SendKeys(keys);
            }
            public void SwitchToWindow(IWebDriver driver, string window)
            {
                driver.SwitchTo().Window(window);
            }


        }

        public class Validations
        {
            public enum Type
            {
                Username,
                pincode
            }
            private IWebDriver driver;
            public Validations(IWebDriver driver)
            {
                this.driver = driver;
            }
            private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            public void ValidateUrl(IWebDriver driver, string expectedUrl)
            {
                string actualUrl = driver.Url;
                Assert.AreEqual(expectedUrl, actualUrl, $"Please check the url {actualUrl} navigation and redirection");
            }
            public void ValidateTitle(IWebDriver driver, string expectedTitle)
            {
                string actualTitle = driver.Title;
                string actualUrl = driver.Url;
                Assert.AreEqual(expectedTitle, actualTitle, $"Please check the title {actualTitle} in the Url {actualUrl}");
            }
            public void ValidateElementText(IWebDriver driver, IWebElement element, string expectedText)
            {
                string actualText = element.Text;
                Assert.AreEqual(expectedText, actualText, $"Element text mismatch for the {element.Text} element in the url {driver.Url} , title {driver.Title}");
            }
            public void ValidateElementIsDisplayed(IWebDriver driver, IWebElement element)
            {
                Assert.IsTrue(element.Displayed, $"Element{element.Text} not displayed in the url {driver.Url} , title {driver.Title}");
            }
            public void ValidateElementIsEnabled(IWebDriver driver, IWebElement element)
            {
                //Assert.IsTrue(element.Enabled, $"Element {element.Text} not enabled in the url {driver.Url} , title {driver.Title});
            }
            public void ValidateElementIsSelected(IWebDriver driver, IWebElement element)
            {
                //Assert.IsTrue(element.Selected, $"Element {element.Text} not selected in the url {driver.Url} , title {driver.Title});              
            }
            public void ValidateImagesInEntirePage(IWebDriver driver)
            {
                IReadOnlyCollection<IWebElement> imgElements = driver.FindElements(By.TagName("img"));
                List<string> srcOfImages = null;
                foreach (IWebElement e in imgElements)
                {
                    srcOfImages.Add(e.GetAttribute("src"));
                }

                foreach (string s in srcOfImages)
                {
                    try
                    {
                        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(s);
                        string response = string.Empty;
                        using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                        {
                            if (HttpStatusCode.OK == httpWebResponse.StatusCode)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                }


            }
            public void ValidateImagePresenceOrDisplay(IWebDriver driver, IWebElement imageElement)
            {
                string srcOfImage = imageElement.GetAttribute("src");
                IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
                bool isPresent = (bool)(jse.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth!=\"undefined\" && arguments[0].naturalWidth>0", imageElement));
                Assert.IsTrue(isPresent, $"Image :with text {imageElement.Text}, with src {srcOfImage} is not loaded/displayed/present in the url {driver.Title} with title {driver.Title}");
            }
            public void ValidateToolTipText(IWebDriver driver, IWebElement element, string expectedToolTipText)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Build().Perform();
                string actualToolTipText = element.GetAttribute("title");
                Assert.AreEqual(expectedToolTipText, actualToolTipText, $"Please check the tool tip text");
            }
            public void ValidateRegex(IWebDriver driver, IWebElement element, string type)
            {
                string usernamePattern = "Test_Test_*([a-z][A-Z][0-9])";
                string pincodePattern = "10001[0-9]";
                string mobilenumberPattern = "8019548124";
                if (type.Contains("Username"))
                {
                    Regex re = new Regex(usernamePattern);
                    Assert.IsTrue(re.IsMatch(element.Text), $"Username pattern mismatch {usernamePattern} != {element.Text}");
                }
                else if (type.Contains("pincode"))
                {
                    Regex re = new Regex(pincodePattern);
                    Assert.IsTrue(re.IsMatch(element.Text), $"Pincode pattern mismatch {pincodePattern}!= {element.Text}");
                }
                else
                {
                    Regex re = new Regex(mobilenumberPattern);
                    Assert.IsTrue(re.IsMatch(element.Text), $"Pincode pattern mismatch {mobilenumberPattern}!= {element.Text}");
                }
            }
            public void ValidateAlertRead(IWebDriver driver, string expectedText)
            {
                string actualText = new Helpers.BasicMethods(driver).AlertRead(driver);
                Assert.AreEqual(expectedText, actualText, $"alert read {expectedText} != {actualText}");
            }
        }

        public bool WaitForElementToBeExist(IWebDriver driver, IWebElement element, double timeout)
        {
            string id = element.GetAttribute("id");
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<IWebElement>(ExpectedConditions.ElementExists(By.Id(id)));
                return true;
            }

            catch (WebDriverException)
            {
                return false;
            }
        }
        public bool WaitForElementToBeVisible(IWebDriver driver, IWebElement element, double timeout)
        {
            string id = element.GetAttribute("id");
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id(id)));
                return true;
            }

            catch (WebDriverException)
            {
                return false;
            }
        }
        public bool WaitForElementToBeClickable(IWebDriver driver, IWebElement element, double timeout)
        {
            string id = element.GetAttribute("id");
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<IWebElement>(ExpectedConditions.ElementToBeClickable(By.Id(id)));
                return true;
            }

            catch (WebDriverException)
            {
                return false;
            }
        }
        public bool WaitForElementToBeSelected(IWebDriver driver, IWebElement element, double timeout)
        {
            string id = element.GetAttribute("id");
            try
            {
                //new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<IWebElement>(ExpectedConditions.ElementToBeSelected(element));
                return true;
            }

            catch (WebDriverException)
            {
                return false;
            }
        }
        public bool WaitForFrameAvailableAndSwitch(IWebDriver driver, IWebElement element, double timeout)
        {
            string id = element.GetAttribute("id");
            try
            {
                //new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until<IWebElement>(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(element));
                return true;
            }

            catch (WebDriverException)
            {
                return false;
            }
        }
        public void WaitForLoading(IWebDriver driver, double timeInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(timeInSeconds));
        }
        public void WaitForPageLoadToBeComplete(IWebDriver driver)
        {
            string readyState = new Helpers.BasicMethods(driver).ReadyStateOfPage(driver);
            for (int i = 1; i < 500; i++)
            {
                if (readyState == "complete")
                {
                    return;
                }
                else
                {
                    continue;
                }
            }

        }
        public bool IsAlertPresent(IWebDriver driver, double timeout = 10)
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    WaitForLoading(driver, 20);
                    continue;
                }
            }
            return false;
        }
        public void WaitForAlert(IWebDriver driver)
        {
            int i = 0;
            while (i++ < 5000)
            {
                try
                {
                    driver.SwitchTo().Alert().Accept();
                    break;
                }
                catch (NoAlertPresentException e)
                {
                    Thread.Sleep(1000);
                    continue;
                }
            }




        }
        public string GetCellFromTable(IWebElement table, int rowIndex, int columnIndex)
        {
            return table.FindElements(By.XPath("./tbody/tr"))[rowIndex].FindElements(By.XPath("./td"))[columnIndex].Text;
        }
        public string GetRowsFromTable(IWebElement table, int rowIndex)
        {
            return table.FindElements(By.XPath("./tbody/tr"))[rowIndex].Text;
        }
        public DataTable ConvertListToDataTable(List<string[]> TitleList)

        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in TitleList)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in TitleList)
            {
                table.Rows.Add(array);
            }

            return table;

        }
    }
}
