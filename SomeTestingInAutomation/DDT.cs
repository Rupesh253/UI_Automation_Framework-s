//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;
//using System.Xml.Linq;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;


//namespace SomeTestingInAutomation
//{


//    [TestFixture]
//    public class DDT
//    {
//        private IWebDriver driver;
//        Uri uri = new Uri("http://executeautomation.com/demosite/index.html");
//        [SetUp]
//        public void Setup()
//        {
//            driver.Manage().Cookies.DeleteAllCookies();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl(uri);
//        }

//        [TestCase]
//        public void SomeTestMethod1InDDTWithXML()
//        {

//        }

//        [TearDown]
//        public void Teardown()
//        {
//            driver.Close();
//            driver.Quit();
//        }

//    }
//}
//    public static class DDTHelper
//    {

//        public static IEnumerable<TestCaseData> ReadDataDrivenFile(string folder, string testData, string[] diffParam, [Optional] string testName)
//        {
//            var doc = XDocument.Load(folder);

//            if (!doc.Descendants(testData).Any())
//            {
//                throw new ArgumentNullException(string.Format($"Exception while reading Data Driven file\n row {testData} not found \n in file {folder}"));
//            }

//            foreach (XElement element in doc.Descendants(testData))
//            {

//                var testParams = element.Attributes().ToDictionary(k => k.Name.ToString(), v => v.Value);

//                var testCaseName = string.IsNullOrEmpty(testName) ? testData : testName;
//                try
//                {
//                    testCaseName = TestCaseName(diffParam, testParams, testCaseName);
//                }
//                catch (DataDrivenReadException e)
//                {
//                    throw new DataDrivenReadException(
//                        string.Format(
//                            " Exception while reading Data Driven file\n test data '{0}' \n test name '{1}' \n searched key '{2}' not found in row \n '{3}'  \n in file '{4}'",
//                            testData,
//                            testName,
//                            e.Message,
//                            element,
//                            folder));
//                }

//                var data = new TestCaseData(testParams);
//                data.SetName(testCaseName);
//                yield return data;
//            }
//        }

//        private static string TestCaseName(string[] diffParam, Dictionary<string, string> testParams, string testCaseName)
//        {
//            throw new NotImplementedException();
//        }
//    }

//    //public static class TestData
//    //{
//    //    public static IEnumerable Credentials;
//    //    {
//    //     get 
            
//    //        { return DDTHelper.ReadDataDriveFile(DataDrivenFile, "credential", new[] { "user", "password" }, "credential"); }
//    //      }
//}









    










