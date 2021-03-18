using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;

namespace SeleniumTests
{
    [TestClass]
    public class EnvioDeComentarioTest
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
        public void UsuarioAutenticadoEnviaComentarioTeste()
        {
            string comentarioParaEnviar = "essa ideia parece promissora";
            string comentarioEsperado = comentarioParaEnviar;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-access")).Click();
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("camila@teste.com");
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[3]/div/div/form")).Click();
            driver.FindElement(By.Id("pass")).Click();
            driver.FindElement(By.Id("pass")).Clear();
            driver.FindElement(By.Id("pass")).SendKeys("camila123");
            driver.FindElement(By.Id("btn-entrar")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-saber-mais")).Click();
            driver.FindElement(By.Id("comentario")).Click();
            driver.FindElement(By.Id("comentario")).Clear();
            driver.FindElement(By.Id("comentario")).SendKeys(comentarioParaEnviar);
            driver.FindElement(By.Id("btn-enviar-comentario")).Click();
            driver.FindElement(By.Id("msg-sucess")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Validacao 
            IWebElement comentarioAdicionado = null;

            string idComentario = "comment-" + comentarioParaEnviar;

            try
            {
                comentarioAdicionado = driver.FindElement(By.Id(idComentario));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(comentarioEsperado, comentarioAdicionado.Text);
        }

        [TestMethod]
        public void UsuarioNaoAutenticadoEnviaComentarioTeste()
        {
            string comentarioParaEnviar = "essa ideia parece promissora";
            string comentarioEsperado = string.Empty;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[2]/nav/div")).Click();
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[4]/button")).Click();
            driver.FindElement(By.Id("modal-rules")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-saber-mais")).Click();
            driver.FindElement(By.Id("comentario")).Click();
            driver.FindElement(By.Id("comentario")).Clear();
            driver.FindElement(By.Id("comentario")).SendKeys(comentarioParaEnviar);
            driver.FindElement(By.Id("btn-enviar-comentario")).Click();
            driver.FindElement(By.Id("msg-sucess")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);


            //Validacao 
            IWebElement comentarioAdicionado = null;

            string idComentario = "comment-" + comentarioParaEnviar;

            try
            {
                comentarioAdicionado = driver.FindElement(By.Id(idComentario));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }

            Assert.AreEqual(comentarioEsperado, comentarioAdicionado.Text);
        }

        [TestMethod]
        public void EmailRegistradoQuandoEnviaComentario()
        {
            string comentarioParaEnviar = "essa ideia parece promissora";
            int contemEmailNaPublicacao = 0;

            driver.Navigate().GoToUrl("http://localhost:3000/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[2]/nav/div")).Click();
            driver.FindElement(By.XPath("//div[@id='__next']/div/div[4]/button")).Click();
            driver.FindElement(By.Id("modal-rules")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.FindElement(By.Id("btn-saber-mais")).Click();
            driver.FindElement(By.Id("comentario")).Click();
            driver.FindElement(By.Id("comentario")).Clear();
            driver.FindElement(By.Id("comentario")).SendKeys(comentarioParaEnviar);
            driver.FindElement(By.Id("btn-enviar-comentario")).Click();
            driver.FindElement(By.Id("msg-sucess")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //Validacao 
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> campoPublicadoPor = driver.FindElements(By.Id("display-name"));

            for (int i = 0; i < campoPublicadoPor.Count; i++)
            {
                if (campoPublicadoPor[i].Text.Contains("@"))
                {
                    contemEmailNaPublicacao++;
                }
            }

            Assert.AreEqual(true, contemEmailNaPublicacao > 0);
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
