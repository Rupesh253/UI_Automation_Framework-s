using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using Protractor;
using System.Threading;

namespace ExploreProtractor
{
    [TestFixture]
    public class Class1
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // Using PhantomJS
            //driver = new PhantomJSDriver();

            // Using Chrome
            System.Environment.SetEnvironmentVariable("web.chrome.driver", @"E:\Automation Frameworks\SomeThingInAutomation\ExploreProtractor\bin\Debug\chromedriver.exe");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);

        }

        [Test]
        public void ShouldGreetUsingBinding()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("http://www.angularjs.org");
            ngDriver.FindElement(NgBy.Model("yourName")).SendKeys("Rupesh");
            Assert.AreEqual("Hello Rupesh!", ngDriver.FindElement(NgBy.Binding("yourName")).Text);

            //driver.Url = "http://www.angularjs.org";
            //driver.FindElement(By.CssSelector("input.ng-valid.ng-touched.ng-dirty.ng-valid-parse.ng-empty")).SendKeys("Rupesh");
            //NoSuchElementException
        }

        [Test]
        public void ShouldListTodos()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("http://www.angularjs.org");
            var elements = ngDriver.FindElements(NgBy.Repeater("todo in todoList.todos"));
            Assert.AreEqual("build an AngularJS app", elements[1].Text.Trim());
            Assert.AreEqual(false, elements[1].Evaluate("todo.done"));
            Thread.Sleep(5000);
        }

        [Test]
        public void Angular2Test()
        {
            var ngDriver = new NgWebDriver(driver);
            ngDriver.Navigate().GoToUrl("https://material.angular.io/");
            ngDriver.FindElement(By.XPath("//a[@routerlink='/guide/getting-started']")).Click();
            Assert.AreEqual("https://material.angular.io/guide/getting-started", ngDriver.Url);
            Thread.Sleep(5000);
        }
        [Test]
        public void NonAngularPageShouldBeSupported()
        {
            Assert.DoesNotThrow(() =>
            {
                var ngDriver = new NgWebDriver(driver);
                ngDriver.IgnoreSynchronization = true;
                ngDriver.Navigate().GoToUrl("http://www.google.com");
                ngDriver.IgnoreSynchronization = false;
            });
        }
        [Test]
        public void ShouldFilter()
        {
            // Fake backend with 2 phones
            NgMockE2EModule mockModule = new NgMockE2EModule(@"
// Requests for templates are handled by the real server
$httpBackend.whenGET('phone-list/phone-list.template.html').passThrough();
$httpBackend.whenGET('phones/phones.json').respond(
[
    {
        age: 12, 
        carrier: 'AT&amp;T', 
        id: 'motorola-bravo-with-motoblur', 
        imageUrl: 'img/phones/motorola-bravo-with-motoblur.0.jpg', 
        name: 'MOTOROLA BRAVO\u2122 with MOTOBLUR\u2122', 
        snippet: 'An experience to cheer about.'
    }, 
    {
        age: 13, 
        carrier: 'T-Mobile', 
        id: 'motorola-defy-with-motoblur', 
        imageUrl: 'img/phones/motorola-defy-with-motoblur.0.jpg', 
        name: 'Motorola DEFY\u2122 with MOTOBLUR\u2122', 
        snippet: 'Are you ready for everything life throws your way?'
    }, 
]
);
");
            var ngDriver = new NgWebDriver(driver, mockModule);
            ngDriver.Navigate().GoToUrl("http://angular.github.io/angular-phonecat/step-7/app/");
            Assert.AreEqual(2, ngDriver.FindElements(NgBy.Repeater("phone in $ctrl.phones")).Count);
            ngDriver.FindElement(NgBy.Model("$ctrl.query")).SendKeys("bravo");
            Assert.AreEqual(1, ngDriver.FindElements(NgBy.Repeater("phone in $ctrl.phones")).Count);
            ngDriver.FindElement(NgBy.Model("$ctrl.query")).SendKeys("!");
            Assert.AreEqual(0, ngDriver.FindElements(NgBy.Repeater("phone in $ctrl.phones")).Count);
        }
        [TearDown]
        public void TearDown()
        {

            driver.Quit();
        }

    }

}



