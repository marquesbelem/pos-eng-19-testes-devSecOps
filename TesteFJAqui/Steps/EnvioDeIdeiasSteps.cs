using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TesteFJAqui
{
    [Binding]
    public sealed class EnvioDeIdeiasSteps
    {
        IWebDriver browser;

        private string uri = "http://localhost:3000";

        [BeforeScenario]
        public void Init()
        {
            browser = new ChromeDriver();
        }

        [AfterScenario]
        public void Close()
        {
            browser.Close();
            browser.Dispose();
        }

        [Given(@"deseja compartilhar uma ideia na plataforma")]
        public void DadoDesejaCompartilharUmaIdeiaNaPlataforma()
        {

        }

        [Then(@"o usuário acessar a página de ideias")]
        public void EntaoOUsuarioAcessarAPaginaDeIdeias()
        {
            browser.Navigate().GoToUrl(uri + "/ideas");
        }

        [Then(@"clicar no botão de escrever ideia")]
        public void EntaoClicarNoBotaoDeEscreverIdeia()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var btnEnviar = browser.FindElement(By.Id("btn-escrever-ideia"));
            btnEnviar.Click();
        }

        [Given(@"clicar no botão de escrever ideias")]
        public void DadoClicarNoBotaoDeEscreverIdeias()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var btnEnviar = browser.FindElement(By.Id("btn-escrever-ideia"));
            btnEnviar.Click();
        }


        [Then(@"o usuário informar ""(.*)"" com o valor igual a ""(.*)""")]
        public void EntaoOUsuarioInformarComOValorIgualA(string inputName, string value)
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var input = browser.FindElement(By.Id(inputName));
            input.SendKeys(value);
        }

        [Then(@"o usuário selecionar ""(.*)"" com o valor igual a ""(.*)""")]
        public void EntaoOUsuarioSelecionarComOValorIgualA(string inputName, int value)
        {
            //var Xpath = ".//label[contains(.,'" + value + "')]/input";
            var inputRadio = browser.FindElement(By.Id(value.ToString()));
            inputRadio.Click();
        }

        [When(@"o usuário clicar no botão de enviar")]
        public void QuandoOUsuarioClicarNoBotaoDeEnviar()
        {
            var btnEnviar = browser.FindElement(By.Id("btn-enviar-ideia"));
            btnEnviar.Click();
        }

        [Given(@"o usuário acessar a página de ideias")]
        public void DadoOUsuarioAcessarAPaginaDeIdeias()
        {
            browser.Navigate().GoToUrl(uri + "/ideas");
        }

        [Given(@"clicar no botão de escrever ideia")]
        public void DadoClicarNoBotaoDeEscreverIdeia()
        {

            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var btnEnviar = browser.FindElement(By.Id("btn-escrever-ideia"));
            btnEnviar.Click();
        }

        [Given(@"o usuário selecionar ""(.*)"" com o valor igual a ""(.*)""")]
        public void DadoOUsuarioSelecionarComOValorIgualA(string inputName, int value)
        {
            var inputRadio = browser.FindElement(By.Id(value.ToString()));
            inputRadio.Click();
        }

        [Then(@"o usuário deverá vê uma mensagem de erro")]
        public void EntaoOUsuarioDeveraVeUmaMensagemDeErro()
        {
            System.Threading.Thread.Sleep(2000);

            try
            {
                var msgSucesso = browser.FindElement(By.Id("msg-error"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Given(@"o usuário informar ""(.*)"" com o valor ""(.*)""")]
        public void DadoOUsuarioInformarComOValor(string inputName, string value)
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            var input = browser.FindElement(By.Id(inputName));
            input.SendKeys(value);
        }

    }
}
