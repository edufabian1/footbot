using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlOption, seleccion, password, username;

            Console.WriteLine("Usuario:");
            username = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            password = Console.ReadLine();
            Console.WriteLine("Cantidad:");
            int count = int.Parse(Console.ReadLine());
            Console.WriteLine("Seleccionar:");            
            Console.WriteLine("1 - Food:");
            Console.WriteLine("2 - Training: resistencia");
            seleccion = Console.ReadLine();

            switch (seleccion)
            {
                case "1":
                    urlOption = "https://la.footballteamgame.com/food";
                    break;
                case "2":
                    urlOption = "https://la.footballteamgame.com/training";
                    break;
                default:
                    return;
            }


            IWebDriver driver = new ChromeDriver(@"C:\chromedriver");

            driver.Navigate().GoToUrl("https://la.footballteamgame.com");

            IWebElement lnkLogin = driver.FindElement(By.CssSelector("button[class='btn btn-lg openLoginModal']"));
            lnkLogin.Click();

            IWebElement signIn = driver.FindElement(By.Id("modal-login-tab"));
            signIn.Click();

            var txtUsername = driver.FindElement(By.CssSelector("input[type='email']")); 
            var txtPassword = driver.FindElement(By.CssSelector("input[type='password']"));

            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);

            IWebElement btnLogin = driver.FindElement(By.Id("btn-login"));
            btnLogin.Click();

            Thread.Sleep(5000);
            driver.Navigate().GoToUrl(urlOption);

            switch (seleccion)
            {
                case "1":
                    do
                    {
                        Thread.Sleep(5000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-lg btn-primary')[0].click()");

                        Thread.Sleep(1000 * 60 * 7);
                        driver.Navigate().Refresh();
                        count -= 1;
                    } while (count != 0);
                    break;
                case "2":
                    do
                    {
                        Thread.Sleep(5000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-primary tile-box__btn pulse-in-tutorial')[3].click()");
                        Thread.Sleep(1000 * 10);
                        driver.Navigate().Refresh();
                        count -= 1;
                    } while (count != 0);
                    break;
                default:
                    break;
            }       
        }
    }
}
