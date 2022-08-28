using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Pages;
using System.Threading;

namespace Selenium.Tests
{
    internal class DraftFunctionalityTests : BaseTest
    {
        private const string _logIn = "eugenebondthe@tutanota.com";
        private const string _password = "KbKjBcNbXkJkJ891?";

        private MainPage _mainPage;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private IList<IWebElement> mailslist;

        [SetUp]
        public void Before()
        {
            _mainPage = new MainPage(driver);
            _loginPage = new LoginPage(driver);
            _homePage = new HomePage(driver);
        }

        [Test(Description = "Verify that user can create and save new mail to Draft folder")]
        public void NewDraftMailCreation()
        {
            _mainPage.OpenLoginPage();
            _loginPage.Login(_logIn, _password);
            _homePage.CreateNewEmailAsDraft();
            _homePage.OpenDraftsPage();
            mailslist = _homePage.GetDraftsList();
            Assert.IsTrue(_homePage.ValidateDraftMailSave(mailslist));
        }

        [Test(Description = "Verify that user can create, save new mail to Draft folder and send it")]
        public void NewDraftMailCreationAndSending()
        {
            _mainPage.OpenLoginPage();
            _loginPage.Login(_logIn, _password);
            _homePage.CreateNewEmailAsDraft();
            _homePage.OpenDraftsPage();
            mailslist = _homePage.GetDraftsList();
            _homePage.OpenAndSendCreatedDraftMail(mailslist);
            Assert.IsTrue(_homePage.ValidateMailSend(mailslist));
        }
    }
}
