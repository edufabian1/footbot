using ConsoleApp1.models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class SeleniumServices
    {
        public IWebDriver Driver { get; set; }
        public string Url { get; set; }

        public SeleniumServices(string chromeDriverDirectory, string url)
        {
            Url = url;

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            Driver = new ChromeDriver(chromeDriverDirectory, options);
        }

        public void LogIn(User user)
        {
            //TODO: Validar error por demora de conexion a pagina
            Driver.Navigate().GoToUrl(Url);

            IWebElement lnkLogin = Driver.FindElement(By.CssSelector("button[class='btn btn-lg openLoginModal']"));
            lnkLogin.Click();

            IWebElement signIn = Driver.FindElement(By.Id("modal-login-tab"));
            signIn.Click();

            var txtUsername = Driver.FindElement(By.CssSelector("input[type='email']"));
            var txtPassword = Driver.FindElement(By.CssSelector("input[type='password']"));

            txtUsername.SendKeys(user.Username);
            txtPassword.SendKeys(user.Password);

            IWebElement btnLogin = Driver.FindElement(By.Id("btn-login"));
            btnLogin.Click();
        }

        public void LogOut()
        {
            Driver.Close();
            Driver.Dispose();
        }

        public void ProcessEatAndTrain(User user)
        {
            switch (user.PlayerAction)
            {
                case PlayerActionEnum.food:
                    do
                    {
                        Driver.Navigate().GoToUrl(Url + user.PlayerAction.ToString());
                        Thread.Sleep(5000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-lg btn-primary')[0].click()");

                        Thread.Sleep(1000 * 60 * 7);
                        Driver.Navigate().Refresh();
                        user.Count -= 1;
                    } while (user.Count != 0);
                    break;
                case PlayerActionEnum.training:
                    do
                    {
                        //Los entrenamientos tienen un refresh menor de 15 por lo que no es necesario actualizar pagina y se puede reducir tiempo de sleep ya que se encadenan en loop
                        Driver.Navigate().GoToUrl(Url + user.PlayerAction.ToString());
                        Thread.Sleep(3000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-primary tile-box__btn pulse-in-tutorial')[3].click()");
                        Thread.Sleep(1000 * 10);
                        user.Count -= 1;
                    } while (user.Count != 0);
                    break;
                default:
                    break;
            }
        }

        //TODO: Accion de comer por bot https://la.footballteamgame.com/training
        public void Train(User user, string training)
        {
            List<Training> trainings = new List<Training>();
            
            Driver.Navigate().GoToUrl(Url + user.PlayerAction.ToString());
            Thread.Sleep(5000);

            ReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.ClassName("tile-box--header"));
            foreach (var element in elements)
            {
                if (!element.Text.Equals(""))
                    trainings.Add(new Training { Name = element.Text });
            }
                

            int index = trainings.FindIndex(element => element.Name.ToUpper().Equals(training.ToUpper()));

            do
            {
                Thread.Sleep(3000);

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript($"document.getElementsByClassName('btn btn-primary tile-box__btn pulse-in-tutorial')[{index}].click()");

                Thread.Sleep(1000 * user.Training.Cost);
                Driver.Navigate().Refresh();

                user.Count -= 1;
            } while (user.Count != 0);
        }

        //TODO: Accion de comer por bot https://la.footballteamgame.com/food
        public void Eat(User user, string food)
        {
            List<Food> foods = new List<Food>();

            Driver.Navigate().GoToUrl(Url + user.PlayerAction.ToString());
            Thread.Sleep(5000);

            ReadOnlyCollection<IWebElement> elements = Driver.FindElements(By.ClassName("tile-box--header"));
            
            foreach (var element in elements)
                foods.Add(new Food { Name = element.Text });

            int index = foods.FindIndex(element => element.Name.ToUpper().Equals(food.ToUpper()));

            do
            {
                Thread.Sleep(5000);

                IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                js.ExecuteScript($"document.getElementsByClassName('btn btn-lg btn-primary')[{index}].click()");

                Thread.Sleep(1000 * 60 * user.Food.Cost);
                Driver.Navigate().Refresh();

                user.Count -= 1;
            } while (user.Count != 0);            
        }
    }
}
