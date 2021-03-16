
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TesteFJAqui
{
    [Binding]
    public class InformacoesRestritasSteps
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


        [Given(@"que o usuário acessou a pagina inicial")]
        public void DadoQueOUsuarioAcessouAPaginaInicial()
        {
            browser.Navigate().GoToUrl(uri);
        }

        [Given(@"deseja ver informações sobre o seu perfil")]
        public void DadoDesejaVerInformacoesSobreOSeuPerfil()
        {

        }

        [Given(@"o usuário está na página de login")]
        public void DadoOUsuarioEstaNaPaginaDeLogin()
        {
            browser.Navigate().GoToUrl(uri + "/login/access");
        }

        [Given(@"o usuário informar ""(.*)"" com o valor igual a ""(.*)""")]
        public void DadoOUsuarioInformarComOValorIgualA(string inputName, string value)
        {
            var input = browser.FindElement(By.Id(inputName));
            input.SendKeys(value);
        }

        [Given(@"o usuário não está autenticado")]
        public void DadoOUsuarioNaoEstaAutenticado()
        {

        }

        [Given(@"o usuário acessar a página do perfil")]
        public void DadoOUsuarioAcessarAPaginaDoPerfil()
        {
            browser.Navigate().GoToUrl(uri + "/profile");
        }


        [When(@"o usuário clicar no botão de entrar")]
        public void QuandoOUsuarioClicarNoBotaoDeEntrar()
        {
            var btnEntrar = browser.FindElement(By.Id("btn-entrar"));
            btnEntrar.Click();
        }

        [Then(@"o usuário acessar a página do perfil")]
        public void EntaoOUsuarioAcessarAPaginaDoPerfil()
        {
            browser.Navigate().GoToUrl(uri + "/profile");
        }

        [Then(@"o usuário deverá ver os detalhes do perfil e opção de trocar de senha")]
        public void EntaoOUsuarioDeveraVerOsDetalhesDoPerfilEOpcaoDeTrocarDeSenha()
        {
            try
            {
                var msgBemVindo = browser.FindElement(By.Name("msg-bem-vindo"));
                var btnMudarSenha = browser.FindElement(By.Name("btn-mudar-senha"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Then(@"o usuário deverá vê uma mensagem de sucesso")]
        public void EntaoOUsuarioDeveraVerUmaMensagemDeSucesso()
        {
            // System.Threading.Thread.Sleep(2000);

            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            try
            {
                var msgSucesso = browser.FindElement(By.Id("msg-sucess"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail();
            }
        }

        [Then(@"o usuário deverá ver um aviso de página restrita")]
        public void EntaoOUsuarioDeveraVerUmAvisoDePaginaRestrita()
        {
            var msgRestrita = browser.FindElement(By.Name("msg-restrita"));
            var msgBemVindo = browser.FindElement(By.Name("msg-bem-vindo"));
            var btnMudarSenha = browser.FindElement(By.Name("btn-mudar-senha"));

            Assert.IsTrue(msgRestrita != null && msgBemVindo == null && btnMudarSenha == null);
        }
    }
}

