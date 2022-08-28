using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class MainPage : BasePage
    {
        private readonly By _logInButton = By.XPath("//*[@id='loginWrapper']//*[@class='pl pr white border hover-white hover-white-bg hover-reda button flex center-vertically pointer button-min-height']");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenLoginPage()
        {
            GetElement(_logInButton).Click();
            SwitchActualWindow();
        }
    }
}