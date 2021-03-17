using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestClass]
    public class TrocaDeSenha
    {
        private static IWebDriver driver;
        private StringBuilder verificationErrors;
        private static string baseURL;
        private bool acceptNextAlert = true;

        [ClassInitialize]
        public static void InitializeClass(TestContext testContext)
        {
            var options = new ChromeOptions()
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
        public void EmailComProvedorDesconhecido()
        {
            var emailParaEnviar = "camila@teste.com";
            var provedorDeEmailExiste = false;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-access")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(emailParaEnviar);

            driver.Navigate().GoToUrl("https://tools.verifyemailaddress.io/");
            driver.FindElement(By.XPath("//p")).Click();
            driver.FindElement(By.Id("input-email-address")).Click();
            driver.FindElement(By.Id("input-email-address")).Clear();
            driver.FindElement(By.Id("input-email-address")).SendKeys(emailParaEnviar);
            driver.FindElement(By.XPath("//div[2]/button")).Click();

            //Validação 
            var resultadoVerificacao = driver.FindElement(By.XPath("//table[@id='dt-grid1']/tbody/tr/td[2]")).Text;

            if (resultadoVerificacao.Contains("Bad"))
            {
                provedorDeEmailExiste = false;
            }
            else
            {
                provedorDeEmailExiste = true;
            }

            driver.Navigate().Back();
            driver.Navigate().GoToUrl("http://localhost:3000/login/access");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys(emailParaEnviar);
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).Clear();
            driver.FindElement(By.Id("pass")).SendKeys("asdsdfs");
            driver.FindElement(By.Id("btn-entrar")).Click();
            driver.FindElement(By.XPath("(//p[@name='msg-error'])[2]")).Click();
            driver.FindElement(By.LinkText("Esqueceu a senha?")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(emailParaEnviar);
            driver.FindElement(By.Id("btn-enviar-esqueceu-senha")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Validação 
            Assert.AreEqual(true, provedorDeEmailExiste);
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
