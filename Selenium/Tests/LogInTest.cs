using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Pages;
using System.Threading;

namespace Selenium.Tests
{
    internal class LogInTest : BaseTest
    {
        private const string _logIn = "eugenebondthe@tutanota.com";
        private const string _password = "KbKjBcNbXkJkJ891?";
        private MainPage _mainPage;
        private LoginPage _loginPage;

        [SetUp]
        public void Before()
        {
            _mainPage = new MainPage(driver);
            _loginPage = new LoginPage(driver);
        }

        [Test(Description = "Verify that user can login and logout in the application with valid credentials")]
        public void TestValidUserLogIn()
        {
            _mainPage.OpenLoginPage();
            _loginPage.Login(_logIn, _password);
            Assert.AreEqual(_logIn, new HomePage(driver).GetLoggedInUsername());

            _loginPage.LogOut();
            Thread.Sleep(1000);
            Assert.AreEqual("Mail. Done. Right. Tutanota Login & Sign up for an Ad-free Mailbox", driver.Title);
        }
    }
}
