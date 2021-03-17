using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestClass]
    public class EnvioDeIdeiasTest
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

        [TestMethod]
        public void UsuarioAutenticadoEnviaIdeiaTest()
        {
            var tituloParaEnviar = "Sonic vs Mario";
            var tituloEsperado = tituloParaEnviar;

            var descricaoParaEnviar = "um jogo de plataforma onde você é o sonic e seu amigo o mario";
            var descricaoEsperado = descricaoParaEnviar;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-access")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("camila@teste.com");
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).Clear();
            driver.FindElement(By.Id("pass")).SendKeys("camila123");
            driver.FindElement(By.Id("btn-entrar")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-escrever-ideia")).Click();
            driver.FindElement(By.Id("title")).Clear();
            driver.FindElement(By.Id("title")).SendKeys(tituloParaEnviar);
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Id("content")).Clear();
            driver.FindElement(By.Id("content")).SendKeys(descricaoParaEnviar);
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[3]/div/nav/div/div/div/form/div/label[2]")).Click();
            driver.FindElement(By.Id("btn-enviar-ideia")).Click();

            //Validacao 
            IWebElement tituloAdicionado = null;
            IWebElement descricaoAdicionado = null;

            try
            {
                tituloAdicionado = driver.FindElement(By.XPath("//div[@id='main']/div/div/div/h3"));
                descricaoAdicionado = driver.FindElement(By.XPath("//div[@id='main']/div/div/div/p"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

            var sucesso = tituloEsperado == tituloAdicionado.Text && descricaoEsperado == descricaoAdicionado.Text;
            Assert.AreEqual(true, sucesso);
        }

        [TestMethod]
        public void UsuarioNaoAutenticadoEnviaIdeiaTest()
        {
            var tituloParaEnviar = "Sonic vs Mario 2";
            var tituloEsperado = string.Empty;

            var descricaoParaEnviar = "um jogo de plataforma onde você é o sonic e seu amigo o mario";
            var descricaoEsperado = string.Empty;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[2]/nav/div")).Click();
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[4]/button")).Click();
            driver.FindElement(By.Id("modal-rules")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-escrever-ideia")).Click();
            driver.FindElement(By.Id("title")).Clear();
            driver.FindElement(By.Id("title")).SendKeys(tituloParaEnviar);
            driver.FindElement(By.Id("content")).Click();
            driver.FindElement(By.Id("content")).Clear();
            driver.FindElement(By.Id("content")).SendKeys(descricaoParaEnviar);
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[3]/div/nav/div/div/div/form/div/label[2]")).Click();
            driver.FindElement(By.Id("btn-enviar-ideia")).Click();

            //Validacao 
            IWebElement tituloAdicionado = null;
            IWebElement descricaoAdicionado = null;

            try
            {
                tituloAdicionado = driver.FindElement(By.XPath("//div[@id='main']/div/div/div/h3"));
                descricaoAdicionado = driver.FindElement(By.XPath("//div[@id='main']/div/div/div/p"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

            var sucesso = tituloEsperado == tituloAdicionado.Text && descricaoEsperado == descricaoAdicionado.Text;
            Assert.AreEqual(true, sucesso);
        }

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
