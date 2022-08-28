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

        private const string _mailSendingPassword = "Qwerty123!?@";
        string finalString;

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetLoggedInUsername()
        {
            return GetElement(_loggedInUsername).Text.ToLower();
        }

        public void CreateNewEmailAsDraft()
        {
            GetElement(_newEmailButton).Click();

            var random = new Random();
            var adressee = $"user{random.Next(0, 100)}@gmail.com";
            SendKeys(_adresseeTextBox, adressee);
            
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[15];

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            finalString = new String(stringChars);
            SendKeys(_subjectTextBox, finalString);
            SendKeys(_mailBodyTextBox, finalString);

            GetElement(_closeButton).Click();
        }

        public void OpenDraftsPage()
        {
            GetElement(_draftsMenuButton).Click();
        }

        public IList<IWebElement> GetDraftsList()
        {
            IList<IWebElement> all = GetElements(_mailList);
            return all;
        }

        public bool ValidateDraftMailSave(IList<IWebElement> all)
        {
            foreach (IWebElement element in all)
            {
                if (element.Text == finalString)
                    return true;
            }
            return false;
        }

        public void OpenAndSendCreatedDraftMail(IList<IWebElement> all)
        {
            foreach (IWebElement element in all)
            {
                if (element.Text.Equals(finalString))
                {
                    element.Click();
                    Click(_editDraftMailButton);
                    Click(_sendPasswordTextBox1);
                    SendKeys(_sendPasswordTextBox1, _mailSendingPassword);
                    Click(_sendPasswordTextBox2);
                    SendKeys(_sendPasswordTextBox2, _mailSendingPassword);
                    Click(_sendPasswordTextBox3);
                    SendKeys(_sendPasswordTextBox3, _mailSendingPassword);
                    Click(_sendEditedMailButton);
                }
            }
        }

        public bool ValidateMailSend(IList<IWebElement> all)
        {
            foreach (IWebElement element in all)
            {
                if (element.Text != finalString)
                    return true;
            }
            return false;
        }
    }
}