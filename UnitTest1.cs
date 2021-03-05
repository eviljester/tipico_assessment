using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Tipico_Tech_Assessment
{
    public class Tests
    {
        // Set the URL string and create the webDriver
        readonly string URL_String = "https://trends.google.com/";
        IWebDriver webDriver;

        [SetUp]
        public void Setup()
        {
            // Set the webDriver to a new Chrome instance and maximize the window
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            // Go to the URL
            webDriver.Url = URL_String;
            System.Threading.Thread.Sleep(3000);
        }

        [Test]
        public void Test_search()
        {
            // Grab the div and enter the search term and press Enter
            IWebElement search_box = webDriver.FindElement(By.CssSelector("Enter a search term or topic"));
            search_box.SendKeys("Selenium WebDriver");
            search_box.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Test Search Completed");
            Assert.Pass();
        }

        [Test]
        public void Test_compare()
        {
            // Grab the div and enter the term to compare and press Enter
            IWebElement search_compare = webDriver.FindElement(By.Name("Add a search term for comparison"));
            search_compare.SendKeys("Javascript WebDriverIO");
            search_compare.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Test Compare Completed");
            Assert.Pass();
        }

        [Test]
        public void Test_filter()
        {
            // Grab the div, search for NY, click on US -> NY, then click "Past 90 Days"
            IWebElement country_filter = webDriver.FindElement(By.Name("United States"));
            country_filter.Click();
            country_filter.SendKeys("new york");
            country_filter.SendKeys(Keys.ArrowDown);
            country_filter.SendKeys(Keys.Enter);

            int N = 6;
            IWebElement time_filter = webDriver.FindElement(By.Name("Past 12 Months"));
            time_filter.Click();
            for(int i = 0; i < N; i++)
                time_filter.SendKeys(Keys.ArrowDown); // To get to 90 Days
            time_filter.SendKeys(Keys.Enter);

            Console.WriteLine("Test Filters Completed");
            Assert.Pass();
        }

        [Test]
        public void Test_ratio()
        {
            // Get the percentual ratio from the “Compared breakdown by metro” section
            IWebElement ratio_filter = webDriver.FindElement(By.Name("Subregion"));
            ratio_filter.Click();
            ratio_filter = webDriver.FindElement(By.Name("Metro"));
            ratio_filter.Click();

            // Grab the value of the comparison, 100% selenium, and output it to the console
            Console.WriteLine("Temp");
        }

        [Test]
        public void Test_shutdown()
        {
            webDriver.Quit();
        }
    }
}