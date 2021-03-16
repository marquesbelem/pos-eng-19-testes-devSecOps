using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TesteFJAqui
{
    [Binding]
    public sealed class EnvioDeComentarioStepss
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

        [Given(@"deseja compartilhar um comentario na plataforma")]
        public void DadoDesejaCompartilharUmComentarioNaPlataforma()
        {

        }

        [Then(@"o usuário selecionar uma ideia clicando no botão de saber mais")]
        public void EntaoOUsuarioSelecionarUmaIdeiaClicandoNoBotaoDeSaberMais()
        {
            browser.Navigate().GoToUrl(uri + "/ideas/-MT1z5sUapPBVvR4vmkp");
        }

        [Then(@"o usuário informar ""(.*)"" com o valor igual ""(.*)""")]
        public void EntaoOUsuarioInformarComOValorIgual(string inputName, string value)
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var input = browser.FindElement(By.Id(inputName));
            input.SendKeys(value);
        }

        [Then(@"clicar no botão de comentar")]
        public void EntaoClicarNoBotaoDeComentar()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var btnSaberMais = browser.FindElement(By.Id("btn-enviar-comentario"));
            btnSaberMais.Click();
        }


        [Given(@"o usuário selecionar uma ideia clicando no botão de saber mais")]
        public void DadoOUsuarioSelecionarUmaIdeiaClicandoNoBotaoDeSaberMais()
        {
            browser.Navigate().GoToUrl(uri + "/ideas/-MT1z5sUapPBVvR4vmkp");
        }

        [Given(@"o usuário informar ""(.*)"" com o valor igual ""(.*)""")]
        public void DadoOUsuarioInformarComOValorIgual(string inputName, string value)
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var input = browser.FindElement(By.Id(inputName));
            input.SendKeys(value);
        }

        [Given(@"clicar no botão de comentar")]
        public void DadoClicarNoBotaoDeComentar()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            var btnSaberMais = browser.FindElement(By.Id("btn-enviar-comentario"));
            btnSaberMais.Click();
        }


    }
}
