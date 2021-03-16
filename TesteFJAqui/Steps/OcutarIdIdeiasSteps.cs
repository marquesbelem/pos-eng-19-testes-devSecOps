using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TesteFJAqui
{
    [Binding]
    public sealed class OcutarIdIdeiasSteps
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
            /*browser.Close();
            browser.Dispose();*/
        }

        [Given(@"o usuário deseja visualizar alguma ideia")]
        public void DadoOUsuarioDesejaVisualizarAlgumaIdeia()
        {
            browser.Navigate().GoToUrl(uri + "/ideas");
        }

        [Given(@"o usuário conseguiu ativar o modo inspecto")]
        public void DadoOUsuarioConseguiuAtivarOModoInspecto()
        {

        }

        [When(@"o usuário clicar em inspecionar")]
        public void QuandoOUsuarioClicarEmInspecionar()
        {

        }

        [Then(@"o usuário não deverá vê nenhum Id das ideias")]
        public void EntaoOUsuarioNaoDeveraVeNenhumIdDasIdeias()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var elements = browser.FindElements(By.Id("btn-saber-mais"));
            var totalElementsId = 0;

            foreach (var item in elements)
            {
                var alt = item.GetAttribute("href");
                if (alt != null && alt.Contains("-M"))
                {
                    totalElementsId++;
                }
            }

            Console.Write("totalElementsId:" + totalElementsId);
            Console.Write("elements:" + elements.Count);
            Assert.AreEqual(0, totalElementsId);
        }

        [When(@"o usuário clicar no botão de voltar da página")]
        public void QuandoOUsuarioClicarNoBotaoDeVoltarDaPagina()
        {
            browser.Navigate().GoToUrl(uri + "/ideas/-MT1z5sUapPBVvR4vmkp");

            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            browser.Navigate().Back();
        }

        [Then(@"o usuário não deverá vê nenhum Id da ideia na url")]
        public void EntaoOUsuarioNaoDeveraVeNenhumIdDaIdeiaNaUrl()
        {
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var url = browser.Url;

            if (url.Contains("-M"))
            {
                Assert.Fail();
            }
        }
    }
}
