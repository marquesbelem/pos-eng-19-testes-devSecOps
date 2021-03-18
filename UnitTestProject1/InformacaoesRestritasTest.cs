using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestClass]
    public class InformacaoesRestritasTest
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
        public void UsuarioAutenticadoDetalhesDisponiveisTest()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.FindElement(By.Id("btn-access")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("camila@teste.com");
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).Clear();
            driver.FindElement(By.Id("pass")).SendKeys("camila123");
            driver.FindElement(By.Id("btn-entrar")).Click();
            driver.FindElement(By.LinkText("Olá criador(a), camila, acesse seu perfil")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Validação 
            try
            {
                driver.FindElement(By.Name("btn-mudar-senha"));
                driver.FindElement(By.Name("msg-bem-vindo"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void UsuarioAutenticadoDetalhesNaoDisponiveisTest()
        {
            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Navigate().GoToUrl("http://localhost:3000/profile");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Validação 
            IWebElement msgRestrita = null;
            IWebElement msgBemVindo = null;
            IWebElement btnMudarSenha = null;

            try
            {
                msgRestrita = driver.FindElement(By.Name("msg-restrita"));
                msgBemVindo = driver.FindElement(By.Name("msg-bem-vindo"));
                btnMudarSenha = driver.FindElement(By.Name("btn-mudar-senha"));
            }
            catch (NoSuchElementException)
            {
                Assert.IsTrue(msgRestrita != null && msgBemVindo == null && btnMudarSenha == null);
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
