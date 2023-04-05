using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Xunit;
public class SuiteTests : IDisposable
{
    public IWebDriver driver { get; private set; }
    public IDictionary<String, Object> vars { get; private set; }
    public IJavaScriptExecutor js { get; private set; }
    public SuiteTests()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<String, Object>();
    }
    public void Dispose()
    {
        driver.Quit();
    }
    [Fact]
    public void ShowWelcomeText()
    {
        driver.Navigate().GoToUrl("https://localhost:7236/");
        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//h1[contains(.,\'Welcome To CW\')]"));
            Assert.True(elements.Count > 0);
        }
    }
}

