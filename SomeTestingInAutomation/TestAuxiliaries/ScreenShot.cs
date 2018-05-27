using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.IO;
using System.Threading;

namespace SomeTestingInAutomation.TestAuxiliaries
{
    public class ScreenShot
    {
        private IWebDriver driver;
        public ScreenShot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Save(IWebDriver driver, string methodName, int setNumber, string fileName)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string tempDirectoryWithBackSlash = baseDirectory.Replace("bin", "TestReporter").Replace("Debug", "TestPics");
            string tempDirectory = tempDirectoryWithBackSlash.Remove(tempDirectoryWithBackSlash.Length - 1, 1);
            string directoryCreation = tempDirectory + @"\" + methodName + @"\" + "set" + setNumber.ToString() + @"\";
            string finalDirectory = directoryCreation + fileName+ ".Png";
            try
            {
                if (!Directory.Exists(directoryCreation))
                {
                    Directory.CreateDirectory(directoryCreation);
                }
                if (!File.Exists(finalDirectory))
                {
                    Screenshot takesScreenshot = ((ITakesScreenshot)driver).GetScreenshot();
                    takesScreenshot.SaveAsFile(finalDirectory, ScreenshotImageFormat.Png);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.StackTrace);

            }
        }
    }
}
