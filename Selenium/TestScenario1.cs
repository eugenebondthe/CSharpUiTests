using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium
{
    internal class TestScenario1
    {
        private IWebDriver driver;
        private readonly By _logInButton = By.XPath("//*[@id='loginWrapper']//*[@class='pl pr white border hover-white hover-white-bg hover-reda button flex center-vertically pointer button-min-height']");
        private readonly By _loginInputField = By.XPath("//*[@class='flex-grow rel']//input[@type='email']");
        private readonly By _passwordInputField = By.XPath("//input[@type='password']");
        private readonly By _finishLogInButton = By.XPath("//button[@title='Log in']");
        private readonly By _settingsButton = By.XPath("//button[@title='Settings']");
        private readonly By _usersLogin = By.XPath("//div[@class='text-break selectable']");
        private readonly By _userLogout = By.XPath("//button[@title='Logout']//span[@class='icon flex-center items-center button-icon icon-large']//*[name()='svg']");
        private readonly By _finalTitle = By.XPath("//title");

        private const string _logIn = "eugenebondthe@tutanota.com";
        private const string _password = "KbKjBcNbXkJkJ891?";

        [OneTimeSetUp]
        public void PreConditions()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://tutanota.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LogIn()
        {
            var logIn = driver.FindElement(_logInButton);
            logIn.Click();

            Thread.Sleep(1000);
            var actualWindow = driver.WindowHandles[1];

            Assert.IsTrue(!string.IsNullOrEmpty(actualWindow));
            driver.SwitchTo().Window(actualWindow);

            Thread.Sleep(1000);
            var loginInput = driver.FindElement(_loginInputField);
            loginInput.SendKeys(_logIn);

            var passwordInput = driver.FindElement(_passwordInputField);
            passwordInput.SendKeys(_password);

            var finishLogIn = driver.FindElement(_finishLogInButton);
            finishLogIn.Click();

            Thread.Sleep(2000);
            var alertWindow = driver.FindElement(By.XPath("//div[text()='Ok']"));
            alertWindow.Click();

            Thread.Sleep(2000);
            var settingsButton = driver.FindElement(_settingsButton);
            settingsButton.Click();

            Thread.Sleep(2000);
            var userLogin = driver.FindElement(_usersLogin).Text;
            Assert.AreEqual(_logIn, userLogin);
        }

        [Test]
        public void LogOut()
        {
            var logOut = driver.FindElement(_userLogout);
            logOut.Click();
            Assert.IsTrue(driver.Url == "https://mail.tutanota.com/login?noAutoLogin=true");
        }

        [OneTimeTearDown]
        public void PostConditions()
        {
            driver.Quit();
        }
    }
}
