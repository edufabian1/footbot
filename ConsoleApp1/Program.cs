using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;

namespace ConsoleApp1
{

    class Program
    {
        static string _urlOption = "https://la.footballteamgame.com/";
        
        static void Main(string[] args)
        {
            User user = new User();
            Menu(user);
            
            SeleniumServices seleniumServices = new SeleniumServices(@"C:\chromedriver");

            seleniumServices.Login(user.Username, user.Password);
            Thread.Sleep(5000);

            switch (user.PlayerAction)
            {
                case PlayerAction.food:
                    do
                    {
                        seleniumServices.Driver.Navigate().GoToUrl(_urlOption + user.PlayerAction.ToString());
                        Thread.Sleep(5000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor)seleniumServices.Driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-lg btn-primary')[0].click()");

                        Thread.Sleep(1000 * 60 * 7);
                        seleniumServices.Driver.Navigate().Refresh();
                        user.Count -= 1;
                    } while (user.Count != 0);
                    break;
                case PlayerAction.training:
                    do
                    {
                        //Los entrenamientos tienen un refresh menor de 15 por lo que no es necesario actualizar pagina y se puede reducir tiempo de sleep ya que se encadenan en loop
                        seleniumServices.Driver.Navigate().GoToUrl(_urlOption + user.PlayerAction.ToString());
                        Thread.Sleep(3000);
                        IJavaScriptExecutor js = (IJavaScriptExecutor)seleniumServices.Driver;
                        js.ExecuteScript("document.getElementsByClassName('btn btn-primary tile-box__btn pulse-in-tutorial')[3].click()");
                        Thread.Sleep(1000 * 10);
                        user.Count -= 1;
                    } while (user.Count != 0);
                    break;
                default:
                    break;
            }       
        }

        static void Menu(User user)
        {
            user.Username = RequireData("Usuario");
            user.Password = RequireData("Contraseña");
            user.Count = int.Parse(RequireData("Cantidad"));

            string data = string.Empty;
            string[] playerActions = { "food", "training" };
            do
            {
                Console.WriteLine("Seleccionar:");
                foreach (string item in playerActions)
                    Console.WriteLine(item);

                data = RequireData("Escribi bien y textual no seas choto");
                if (playerActions.Contains(data))
                    user.PlayerAction = (PlayerAction)Enum.Parse(typeof(PlayerAction), data);

            } while (!playerActions.Contains(data));
        }
        static string RequireData(string label)
        {
            string result;
            bool isOk;
            do
            {
                Console.WriteLine($"Ingresar {label}:");
                result = Console.ReadLine();
                isOk = !string.IsNullOrEmpty(result.Trim()) ? true : false;
            } while (!isOk);
            return result;
        }
    }
}
