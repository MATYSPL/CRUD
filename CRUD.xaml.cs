using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CRUD_Project 
{
    [TestFixture]
     public class SwaggerPetstore 
    { 
        [Test]
        public void PetStore()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://petstore.swagger.io/");

            SwaggerPageObject swaggerPageObject = new SwaggerPageObject(driver);
            swaggerPageObject.AddPet();

            swaggerPageObject.FindPet();
            Assert.IsTrue(swaggerPageObject.NameCheck.Text.Contains("Fafik"));

            swaggerPageObject.UpdatePet();
            Assert.IsTrue(swaggerPageObject.NameCheckUpdate.Text.Contains("Fafor"));

            swaggerPageObject.DeletePet();
            Assert.IsTrue(swaggerPageObject.CheckIfDeleted.Text.Contains("Pet not found"));
        }
    }
}
