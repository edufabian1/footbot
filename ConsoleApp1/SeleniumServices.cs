using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class SeleniumServices
    {
        public IWebDriver Driver { get; set; }

        public SeleniumServices(string chromeDriverDirectory)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            Driver = new ChromeDriver(chromeDriverDirectory, options);
        }

        public void Login(string username, string password)
        {
            //TODO: Validar error por demora de conexion a pagina
            Driver.Navigate().GoToUrl("https://la.footballteamgame.com/");

            IWebElement lnkLogin = Driver.FindElement(By.CssSelector("button[class='btn btn-lg openLoginModal']"));
            lnkLogin.Click();

            IWebElement signIn = Driver.FindElement(By.Id("modal-login-tab"));
            signIn.Click();

            var txtUsername = Driver.FindElement(By.CssSelector("input[type='email']"));
            var txtPassword = Driver.FindElement(By.CssSelector("input[type='password']"));

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);

            IWebElement btnLogin = Driver.FindElement(By.Id("btn-login"));
            btnLogin.Click();
        }
    }
}
