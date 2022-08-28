using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _loginTextBox = By.XPath("//*[@class='flex-grow rel']//input[@type='email']");
        private readonly By _passwordTextBox = By.XPath("//input[@type='password']");
        private readonly By _signInButton = By.XPath("//button[@title='Log in']");
        private readonly By _userLogout = By.XPath("//button[@title='Logout']//span[@class='icon flex-center items-center button-icon icon-large']//*[name()='svg']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void SetEmail(string email)
        {
            SendKeys(_loginTextBox, email);
        }

        public void SetPassword(string password)
        {
            SendKeys(_passwordTextBox, password);
        }

        public void ClickSignInButton()
        {
            Click(_signInButton);
        }

        public void Login(string email, string password)
        {
            SetEmail(email);
            SetPassword(password);
            ClickSignInButton();
        }

        public void LogOut()
        {
            GetElement(_userLogout).Click();
        }
    }
}