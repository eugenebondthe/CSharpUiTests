﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Selenium.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        protected void WaitUntilElementVisible(By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementVisible(by);
            return _driver.FindElement(by);
        }

        protected IList<IWebElement> GetElements(By by)
        {
            WaitUntilElementVisible(by);
            return _driver.FindElements(by);
        }

        protected void Click(By by)
        {
            WaitUntilElementVisible(by);
            _driver.FindElement(by).Click();
        }

        protected void SendKeys(By by, string text)
        {
            WaitUntilElementVisible(by);
            _driver.FindElement(by).SendKeys(text);
        }

        protected void SwitchActualWindow()
        {
            var actualPage = _driver.WindowHandles[1];
            _driver.SwitchTo().Window(actualPage);
        }
    }
}