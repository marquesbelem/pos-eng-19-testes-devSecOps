using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestClass]
    public class OcutarIdIdeiasTest
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            ChromeOptions options = new ChromeOptions()
            {
                BinaryLocation = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            };

            driver = new ChromeDriver(options);
            baseURL = "https://www.katalon.com/";
        }

        [ClassCleanup]
        public static void CleanupClass()
        {
            try
            {
                //driver.Quit();// quit does not close the window
                driver.Close();
                driver.Dispose();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [TestInitialize]
        public void InitializeTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            Assert.AreEqual("", verificationErrors.ToString());
        }

        #region Testes
        [TestMethod]
        public void UsuarioAcessaListaDeIdeiasNaoPodeTerAcessoIdNaPagina()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/ideas");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.Id("btn-saber-mais"));
            int totalElementsId = 0;

            //Validação
            foreach (IWebElement item in elements)
            {
                string alt = item.GetAttribute("href");
                if (alt != null && alt.Contains("-M"))
                {
                    totalElementsId++;
                }
            }

            Assert.AreEqual(0, totalElementsId);
        }

        [TestMethod]
        public void UsuarioAcessaListaDeIdeiasNaoPodeTerAcessoIdNaUrl()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/ideas");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            driver.Navigate().GoToUrl("http://localhost:3000/ideas/-MT1z5sUapPBVvR4vmkp");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Validação
            string url = driver.Url;

            if (url.Contains("-M"))
            {
                Assert.Fail();
            }
        }
        #endregion

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
