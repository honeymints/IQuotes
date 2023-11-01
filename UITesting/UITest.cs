using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITesting;



public class UITest
{
    protected IWebDriver Driver;

    public UITest()
    {
        Driver = new ChromeDriver(); // initialize Chrome WebDriver
    }

    public void Cleanup()
    {
        Driver.Quit(); // cleanup after the test
    }
}
