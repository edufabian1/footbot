using FootBot.Models;
using FootBot.Models.Enums;
using FootBot.Models.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;

namespace FootBot.Selenium
{
    public class SeleniumServices
    {
        private IWebDriver _driver;
        private string _url;

        public SeleniumServices(string pathDriverDirectory, string url, int navigatorDriver)
        {
            _url = url;

            if (navigatorDriver == NavigatorDriverEnum.Chrome.GetHashCode())
            {
                var driverService = ChromeDriverService.CreateDefaultService(pathDriverDirectory);
                driverService.HideCommandPromptWindow = true;

                ChromeOptions options = new ChromeOptions();
                //options.AddArguments(new List<string>() {
                //                            "--silent-launch",
                //                            "--no-startup-window",
                //                            "no-sandbox",
                //                            "headless",});
                options.AddArguments(new[] { "--no-sandbox",
                                        "--disable-dev-shm-usage",
                                        "--disable-images",
                                        "--disable-notifications",
                                        "use-fake-device-for-media-stream",
                                        "use-fake-ui-for-media-stream" });
                options.AddArgument(@"--user-agent=""Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.157 Safari/537.36""");

                _driver = new ChromeDriver(driverService, options);                
            }
            else if (navigatorDriver == NavigatorDriverEnum.Firefox.GetHashCode())
            {
                var driverService = FirefoxDriverService.CreateDefaultService(pathDriverDirectory);
                driverService.HideCommandPromptWindow = true;

                FirefoxOptions options = new FirefoxOptions();

                options.AddArguments(new List<string>() {
                                            "--silent-launch",
                                            "--no-startup-window",
                                            "no-sandbox",
                                            "--headless",});
                _driver = new FirefoxDriver(driverService, options);
            }

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
        }

        public void LogIn(User user)
        {
            try
            {
                _driver.Navigate().GoToUrl(_url);

                IWebElement lnkLogin = _driver.FindElement(By.CssSelector("button[class='btn btn-lg']"));
                lnkLogin.Click();

                IWebElement signIn = _driver.FindElement(By.ClassName("modal-header-tab"));
                signIn.Click();

                var txtUsername = _driver.FindElement(By.CssSelector("input[type='email']"));
                var txtPassword = _driver.FindElement(By.CssSelector("input[type='password']"));

                txtUsername.SendKeys(user.Username);
                txtPassword.SendKeys(user.Password);

                IWebElement btnLogin = _driver.FindElement(By.Id("btn-login"));
                btnLogin.Click();

                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                throw new Exception("LogIn Error: " + ex.Message);
            }
        }

        public void LogOut(bool complete)
        {
            if (complete)
            {
                _driver.Close();
                _driver.Dispose();
            }
            else
                _driver.Close();

        }

        //TODO: Accion de comer por bot https://la.footballteamgame.com/training
        public void Train(User user, Training training)
        {
            try
            {
                List<Training> trainings = new List<Training>();

                _driver.Navigate().GoToUrl(_url + "training");
                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tile-box--header"));
                foreach (var element in elements)
                {
                    if (!element.Text.Equals(string.Empty))
                        trainings.Add(new Training { Name = element.Text });
                }

                int index = trainings.FindIndex(element => string.Compare(element.Name.ToUpper(), training.Name, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0);

                while (user.Count != 0)
                {
                    Thread.Sleep(5000);

                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript($"document.getElementsByClassName('btn btn-primary tile-box__btn pulse-in-tutorial')[{index}].click()");

                    Thread.Sleep(1000 * training.getCostISeconds());
                    _driver.Navigate().Refresh();

                    user.Count -= 1;
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Train Error: " + ex.Message + " in loop: " + user.Count);
            }
        }

        //TODO: Accion de comer por bot https://la.footballteamgame.com/food
        // user.PlayerAction.ToString() => /food
        // food                         => namefood
        // user.Food.Cost               => costfood
        public void Eat(User user, Food food)
        {
            try
            {
                List<Food> foods = new List<Food>();

                _driver.Navigate().GoToUrl(_url + "food");
                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tile-box--header"));

                foreach (var element in elements)
                    foods.Add(new Food { Name = element.Text });

                int index = foods.FindIndex(element => string.Compare(element.Name.ToUpper(), food.Name, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0);

                while (user.Count != 0)
                {
                    Thread.Sleep(5000);

                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript($"document.getElementsByClassName('btn btn-lg btn-primary')[{index}].click()");

                    Thread.Sleep(1000 * food.getCostISeconds());
                    _driver.Navigate().Refresh();

                    user.Count -= 1;
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Eat Error: " + ex.Message + " in loop: " + user.Count);
            }
        }

        //TODO: Accion de comer por bot https://la.footballteamgame.com/work
        public void Job(User user, Work work)
        {
            try
            {
                List<Work> works = new List<Work>();

                _driver.Navigate().GoToUrl(_url + "work");
                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tile-box--header"));

                foreach (var element in elements)
                    works.Add(new Work { Name = element.Text });

                int index = works.FindIndex(element => string.Compare(element.Name.ToUpper(), work.Name, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0);

                while (user.Count != 0)
                {
                    Thread.Sleep(5000);

                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript($"document.getElementsByClassName('btn btn-lg btn-primary')[{index}].click()");

                    Thread.Sleep(1000 * work.getCostISeconds());
                    _driver.Navigate().Refresh();

                    user.Count -= 1;
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Work Error: " + ex.Message + " in loop: " + user.Count);
            }
        }

        public int NavigateToUrl(IActivity activity, string urlActivity)
        {
            int index = -1;
            try
            {
                List<string> activities = new List<string>();

                _driver.Navigate().GoToUrl(_url + urlActivity);
                Thread.Sleep(5000);

                ReadOnlyCollection<IWebElement> elements = _driver.FindElements(By.ClassName("tile-box--header"));

                foreach (var element in elements)
                {
                    if (!element.Text.Equals(string.Empty))
                        activities.Add(element.Text);
                }
                index = activities.FindIndex(element => string.Compare(element.ToUpper(), activity.Name, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace) == 0);
            }
            catch (Exception ex)
            {
                throw new Exception(activity.Name + "error redirecting to url: " + ex.Message);
            }
            return index;
        }

        public void doOneActivity(IActivity activity, int indexActivity, string classNameButton)
        {
            try
            {
                Thread.Sleep(5000);

                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript($"document.getElementsByClassName('{classNameButton}')[{indexActivity}].click()");

                Thread.Sleep(1000 * activity.getCostISeconds());
                _driver.Navigate().Refresh();
            }
            catch (Exception ex)
            {
                throw new Exception(activity.Name + "error executing click: " + ex.Message);
            }
        }
    }
}
