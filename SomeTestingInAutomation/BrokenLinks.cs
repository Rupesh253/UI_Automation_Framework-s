using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Net;
using System.Net.Http;

namespace SomeInAutomation
{
    [TestFixture]
    public class BrokenLinks
    {
        IWebDriver driver;
        string uri = "https://www.microsoft.com/en-in";
        [SetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            //string chromeDriverDirectory = @"C:\Users\Rupesh Chaitu\source\repos\SomeInAutomation\SomeInAutomation\bin\Debug\chromedriver.exe";
            //driver = new ChromeDriver( options,TimeSpan.FromMinutes(2));
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\v-rusom\Documents\visual studio 2015\Projects\SomeThingInAutomation\SomeTestingInAutomation\bin\Debug\chromedriver.exe");
        }

        //RestSharp
        [Test]
        
        public void SomeTestMethod1InBrokenLinks()
        {
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\Users\Rupesh Chaitu\source\repos\SomeInAutomation\SomeInAutomation\bin\Debug\chromedriver.exe");
            //string uri = "https://www.microsoft.com/en-in";

            //int uriLetterCount = uri.Count();
            //driver.Navigate().GoToUrl(uri);
            //ReadOnlyCollection<IWebElement> aLinks = driver.FindElements(By.TagName("a"));
            //int noOfAnchors = aLinks.Count;
            //int brokenLinksCount = 0;
            ////string brokenLinkUIText = null;
            ////string brokenLinkHref = null;
            //for (int i = 0; i < noOfAnchors; i++)
            //{
            //    string hRef = aLinks[i].GetAttribute("href");
            //    if (hRef.Contains(".com"))
            //    {
            //        string[] comPrefixAndSuffix = hRef.Split(new string[] { ".com" }, StringSplitOptions.None);
            //        RestClient restClient = new RestClient();
            //        restClient.BaseUrl = new Uri(comPrefixAndSuffix[0] + ".com");
            //        RestRequest restRequest = new RestRequest();
            //        restRequest.Method = Method.GET;
            //        restRequest.RequestFormat = DataFormat.Json;
            //        restRequest.Resource = comPrefixAndSuffix[comPrefixAndSuffix.Length - 1];
            //        IRestResponse restResponse = restClient.Execute(restRequest);

            //        //for (int j = 0; j < comPrefixAndSuffix.Length; j++)
            //        //{
            //        //    string com = ".com";
            //        //    string temp = com + Convert.ToString(j);
            //        //    temp = comPrefixAndSuffix[j];
            //        //}

            //        if (restResponse.StatusCode.ToString() != "200")
            //        {
            //            brokenLinksCount++;
            //            Console.WriteLine("*****************||******************");
            //            Console.WriteLine(restResponse.ResponseUri.ToString() + "\t" + restResponse.StatusCode.ToString() + "\t" + restResponse.StatusDescription.ToString());
            //            Console.WriteLine("*****************||******************");
            //        }
            //        if (Convert.ToInt32(restResponse.StatusCode.ToString()) >= 400)
            //        {
            //            Console.WriteLine("*****************||******************");
            //            Console.WriteLine(restResponse.ResponseUri.ToString() + "\t" + restResponse.StatusCode.ToString() + "\t" + restResponse.StatusDescription.ToString());
            //            Console.WriteLine("*****************||******************");
            //        }
            //        Console.WriteLine(restResponse.ResponseUri.ToString() + "\t" + restResponse.StatusCode.ToString() + "\t" + restResponse.StatusDescription.ToString());
            //        restResponse = null;
            //        restRequest = null;
            //        restClient = null;
            //    }

            //}

            //Console.WriteLine("Number of Links found: " + noOfAnchors);
            //Console.WriteLine("Number of Broken links found: " + brokenLinksCount);
            //foreach (IWebElement e in aLinks)
            //{
            //    Console.WriteLine(e.GetAttribute("href"));
            //}
        }

        //HtttpWebClient
        [Test]
        
        public void SomeTestMethod2InBrokenLinks()
        {
            driver.Navigate().GoToUrl(uri);

            ReadOnlyCollection<IWebElement> aList = driver.FindElements(By.TagName("a"));
            long nuOfAnchors = aList.Count;
            int nuOfBrokenLinks = 0;
            HttpWebRequest request = null;
            foreach (IWebElement e in aList)
            {
                if (!((e.Text.Contains("Email")) || (e.Text == "")))
                {
                    string hrefAttributeValue = e.GetAttribute("href");
                    request = (HttpWebRequest)WebRequest.Create(hrefAttributeValue);
                    try
                    {
                        var response = (HttpWebResponse)request.GetResponse();
                        Console.WriteLine($"URL: {hrefAttributeValue} status is {((int)response.StatusCode).ToString()}");
                    }

                    catch (WebException ex)
                    {
                        var errorResponse = (HttpWebResponse)ex.Response;
                        Console.WriteLine($"URL : {hrefAttributeValue} status is {errorResponse.StatusCode.ToString()}");
                    }
                }
            }
            //Console.WriteLine($"Number of links found: {nuOfAnchors} \n Number of broken links found: {nuOfBrokenLinks}");

        }

        //HttpClient
        [Test]
        
        public void SomeTestMethod3InBrokenLinks()
        {
            driver.Navigate().GoToUrl(uri);
            ReadOnlyCollection<IWebElement> aList = driver.FindElements(By.TagName("a"));
            long nuOfAnchors = aList.Count;
            int nuOfBrokenLinks = 0;

            foreach(IWebElement e in aList)
            {
                string href = e.GetAttribute("href");
                using (HttpClient httpClient = new HttpClient())
                {
                    //HttpResponse httpResponse = httpClient.GetAsync(new Uri(href));                   
                }
            }                  
        }

        


        [TearDown]
        public void Teardown()
        {
            driver.Close();
            driver.Quit();
        }
    }


}
