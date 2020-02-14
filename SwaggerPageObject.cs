using OpenQA.Selenium;
using System;
using System.Threading;

namespace CRUD_Project
{
    class SwaggerPageObject
    {
        private IWebDriver _driver;

        public SwaggerPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PostPet => _driver.FindElement(By.XPath("//*[contains(text(), 'Add a new pet to the store')]"));
        public IWebElement TryItOut => _driver.FindElement(By.CssSelector(".btn.try-out__btn"));
        public IWebElement TextArea => _driver.FindElement(By.CssSelector(".body-param__text"));
        public IWebElement Execute => _driver.FindElement(By.CssSelector(".btn.execute.opblock-control__btn"));
        public IWebElement GetPet => _driver.FindElement(By.XPath("//*[contains(text(), 'Find pet by ID')]"));
        public IWebElement Input => _driver.FindElement(By.XPath("//input[@placeholder='petId - ID of pet to return']"));
        public IWebElement NameCheck => _driver.FindElement(By.XPath("//span[contains(text(), 'Fafik')]"));
        public IWebElement Update => _driver.FindElement(By.XPath("//*[contains(text(), 'Update an existing pet')]"));
        public IWebElement TryItOutUpdate => _driver.FindElement(By.XPath("//button[contains(@class,'btn try-out__btn')][not(contains(text(),'Cancel'))]"));
        public IWebElement TextAreaUpdate => _driver.FindElement(By.XPath("//textarea[contains(@class,'body-param__text')][not(contains(text(),'Fafik'))]"));
        public IWebElement ExecuteUpdate => _driver.FindElement(By.XPath("//div[contains(@class,'execute-wrapper')]/button[contains(@class,'btn execute opblock-control__btn')]"));
        public IWebElement NameCheckUpdate => _driver.FindElement(By.XPath("//span[contains(text(), 'Fafor')]"));
        public IWebElement Delete => _driver.FindElement(By.XPath("//*[contains(text(), 'Deletes a pet')]"));
        public IWebElement DeleteInput => _driver.FindElement(By.XPath("//input[@placeholder='petId - Pet id to delete']"));
        public IWebElement CheckIfDeleted => _driver.FindElement(By.XPath("//span[contains(text(), 'Pet not found')]"));

        public void AddPet()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            PostPet.Click();
            TryItOut.Click();

            TextArea.Clear();
            TextArea.SendKeys("{\"id\": 100,\"category\": {\"id\": 0,\"name\": \"string\"},\"name\": \"Fafik\",\"photoUrls\": [\"string\"],\"tags\": [{\"id\": 0,\"name\": \"string\"}],\"status\": \"available\"}");
            Execute.Click();
        }

        public void FindPet()
        {
            GetPet.Click();
            Thread.Sleep(500);
            TryItOut.Click();
            Input.SendKeys("100");
            Execute.Click();           
        }

        public void UpdatePet()
        {
            Update.Click();
            TryItOutUpdate.Click();
            TextAreaUpdate.Clear();
            TextAreaUpdate.SendKeys("{\"id\": 100,\"category\": {\"id\": 0,\"name\": \"string\"},\"name\": \"Fafor\",\"photoUrls\": [\"string\"],\"tags\": [{\"id\": 0,\"name\": \"string\"}],\"status\": \"available\"}");
            ExecuteUpdate.Click();
        }

        public void DeletePet()
        {
            Delete.Click();
            TryItOutUpdate.Click();
            DeleteInput.SendKeys("100");
            ExecuteUpdate.Click();
            Execute.Click();
        }
    }
}
