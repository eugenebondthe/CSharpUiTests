using OpenQA.Selenium;

namespace Selenium.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _loggedInUsername = By.XPath("//small[text()='EUGENEBONDTHE@TUTANOTA.COM']");
        private readonly By _newEmailButton = By.XPath("//button[@title='New email']//div");
        private readonly By _adresseeTextBox = By.XPath("//input[@aria-label='To']");
        private readonly By _subjectTextBox = By.XPath("//input[@aria-label='Subject']");
        private readonly By _mailBodyTextBox = By.XPath("//div[@role='textbox']");
        private readonly By _closeButton = By.XPath("//div[@class='button-content flex items-center secondary plr-button justify-center']//div[@class='text-ellipsis'][normalize-space()='Close']");
        private readonly By _draftsMenuButton = By.XPath("//span[normalize-space()='Drafts']");
        private readonly By _mailList = By.XPath("(//*[contains(@class,'list-bg')]//*[contains(@class,'list-row')][not(contains(@style,'none'))]//div[@class='text-ellipsis flex-grow'])");
        private readonly By _editDraftMailButton = By.XPath("//button[@title='Edit']//span[@class='icon flex-center items-center button-icon']");
        private readonly By _sendEditedMailButton = By.XPath("//div[contains(text(),'Send')]");
        private readonly By _sendPasswordTextBox1 = By.XPath("(//input[@class='input'])[2]");
        private readonly By _sendPasswordTextBox2 = By.XPath("(//input[@class='input'])[3]");
        private readonly By _sendPasswordTextBox3 = By.XPath("(//input[@class='input'])[4]");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInUsername()
        {
            return GetElement(_loggedInUsername).Text.ToLower().Trim();
        }

        public void CreateNewEmailAsDraft(string adressee, string autoGeneratedString)
        {
            GetElement(_newEmailButton).Click();
            SendKeys(_adresseeTextBox, adressee);
            SendKeys(_subjectTextBox, autoGeneratedString);
            SendKeys(_mailBodyTextBox, autoGeneratedString);

            GetElement(_closeButton).Click();
        }

        public void OpenDraftsPage()
        {
            GetElement(_draftsMenuButton).Click();
        }

        public IList<IWebElement> GetDraftsList()
        {
            return GetElements(_mailList);
        }

        public bool ValidateDraftMailSave(string autoGeneratedString)
        {
            foreach (IWebElement element in GetDraftsList())
            {
                if (element.Text == autoGeneratedString)
                    return true;
            }
            return false;
        }

        public void OpenAndSendCreatedDraftMail(string autoGeneratedString, string mailSendingPassword)
        {
            foreach (IWebElement element in GetDraftsList())
            {
                if (element.Text.Equals(autoGeneratedString))
                {
                    element.Click();
                    Click(_editDraftMailButton);

                    SendKeys(_sendPasswordTextBox1, mailSendingPassword);
                    SendKeys(_sendPasswordTextBox2, mailSendingPassword);
                    SendKeys(_sendPasswordTextBox3, mailSendingPassword);
                    
                    Click(_sendEditedMailButton);
                }
            }
        }

        public bool ValidateMailSend(string autoGeneratedString)
        {
            foreach (IWebElement element in GetDraftsList())
            {
                if (element.Text != autoGeneratedString)
                    return true;
            }
            return false;
        }
    }
}