using OpenQA.Selenium;
using Xunit;


namespace UITesting;

public class RegistrationUITest : UITest
{

    [Fact]
    public void UserRegistration()
    {
        Driver.Navigate().GoToUrl("http://localhost:5210/Account/SignUp");

        IWebElement usernameField = Driver.FindElement(By.Id("username"));
        IWebElement emailField = Driver.FindElement(By.Id("email"));
        IWebElement passwordField = Driver.FindElement(By.Id("psw"));
        IWebElement confirmPasswordField = Driver.FindElement(By.Id("psw-repeat"));
        IWebElement registerButton = Driver.FindElement(By.ClassName("registerbtn"));

        // Fill in registration form
        usernameField.SendKeys("testuser");
        emailField.SendKeys("testuser@example.com");
        passwordField.SendKeys("TestPassword1!");
        confirmPasswordField.SendKeys("TestPassword1!");
        

        string initialUrl = Driver.Url; //initial current url

        registerButton.Click();

        // get the URL after clicking the button
        string finalUrl = Driver.Url;

        // assert that the URL changed to the home page
        Assert.NotEqual(initialUrl, finalUrl);
        Assert.Contains("http://localhost:5210/Home", finalUrl);

    }
}

