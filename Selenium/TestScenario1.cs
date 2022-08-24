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
        private readonly By _menuButton = By.XPath("//*[@d='M64 384h384v-42.666H64V384zm0-106.666h384v-42.667H64v42.667zM64 128v42.665h384V128H64z']");
        private readonly By _usersLogin = By.XPath("//*[@class='folder-row flex-space-between plr-l pt-s button-height']//*[@class='b align-self-center text-ellipsis']");
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
            var menuButton = driver.FindElement(_menuButton);
            menuButton.Click();

            //забрать строку логина в переменную
            Assert.AreEqual(_usersLogin, _logIn, "Login is verified.");
        }

        [Test]
        public void LogOut()
        {
            var menuButton = driver.FindElement(_menuButton);
            menuButton.Click();

            var logOut = driver.FindElement(_userLogout);
            logOut.Click();

            var titleCheck = "Mail. Done. Right. Tutanota Login &amp; Sign up for an Ad-free Mailbox";
            Assert.AreEqual(_finalTitle, titleCheck);
        }

        [OneTimeTearDown]
        public void PostConditions()
        {
            driver.Quit();
        }
    }
}
