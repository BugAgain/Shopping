using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace RequestTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThrottleTest()
        {
            var options = new ChromeOptions();
            options.AddArguments("--test-type", "--start-maximized");
            options.AddArguments("--test-type", "--ignore-certificate-errors");
            options.AddArgument("--disable-cache");

            IWebDriver driver = new ChromeDriver(@"C:\Users\sabit\Downloads\chromedriver_win32\", options);
            for (int i = 0; i <= 10; i++)
            {
                driver.Url = "https://localhost:5001/PostOrder";
            }

            driver.Close();
        }
    }
}