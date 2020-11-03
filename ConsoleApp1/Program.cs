using Newtonsoft.Json.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace ConsoleApp1
{

    class Program
    {   
        static IDictionary<int, string> Foods = new Dictionary<int, string> ()
        {
            { 1, "SMOOTHIE DE VERDURAS" },
            { 2, "ROLLO DE PLÁTANO" },
            { 3, "CARNE ASADA DE MAMÁ" },
            { 4, "LICUADO DE PROTEÍNAS" },
            { 5, "POLLO Y ARROZ" },
            { 6, "EMPAREDADO DE MERIENDA" }
        };

        static IDictionary<int, string> Trainings = new Dictionary<int, string>()
        {
            { 1, "ENTRENAMIENTO BASICO (no usar) (La pagina esta trabajando en esto)" },
            { 2, "OFENSIVA" },
            { 3, "DEFENSIVA" },
            { 4, "CREACIÓN DE JUEGO" },
            { 5, "RESISTENCIA" },
            { 6, "LECTURA" },
            { 7, "PRESIÓN" },
            { 8, "BALÓN PARADO" },
            { 9, "EFICACIA" }
        };

        static IDictionary<int, string> Jobs = new Dictionary<int, string>()
        {
            { 1, "UTILERO" },
            { 2, "MASCOTA DEL EQUIPO" },
            { 3, "EXPERTOS DEL ESTUDIO" },
            { 4, "AGUADOR" },
            { 5, "ENTRENADOR DE LAS FUERZAS BÁSICAS" },
            { 6, "APARECER EN UN ANUNCIO" },
            { 7, "RECOGEBALONES" },
            { 8, "COMENTARISTA" },
            { 9, "PARTICIPACIÓN EN UN PARTIDO DE CELEBRIDADES" }
        };

        static void Main(string[] args)
        {
            User user = new User();
            Menu(user);

            //TODO: Crear archivo de configuracion https://aspnetcoremaster.com/asp.net/core/2019/04/07/aspnetcore-appsettings.html
            SeleniumServices seleniumServices = new SeleniumServices(@"C:\chromedriver", "https://la.footballteamgame.com/");

            seleniumServices.LogIn(user);
            Thread.Sleep(5000);

            switch (user.PlayerAction)
            {
                case PlayerActionEnum.food:
                    seleniumServices.Eat(user, user.Food.Name);
                    break;
                case PlayerActionEnum.training:
                    seleniumServices.Train(user, user.Training.Name);
                    break;
                case PlayerActionEnum.work:
                    seleniumServices.Job(user, user.Job.Name);
                    break;
                default:
                    break;
            }

            seleniumServices.LogOut();
        }

        static void Menu(User user)
        {
            user.Username = RequireData("Usuario");
            user.Password = RequireData("Contraseña");
            user.Count = int.Parse(RequireData("Cantidad"));

            string data = string.Empty;
            bool state = false;
            string[] playerActions = { "food", "training", "work" };
            do
            {
                Console.WriteLine("Seleccionar:");
                foreach (string item in playerActions)
                    Console.WriteLine(item);

                data = RequireData("actividad a realizar");
                if (playerActions.Contains(data))
                    user.PlayerAction = (PlayerActionEnum)Enum.Parse(typeof(PlayerActionEnum), data);

                if (user.PlayerAction == PlayerActionEnum.food)
                {
                    foreach (KeyValuePair<int, string> food in Foods)
                        Console.WriteLine("{0} - {1}", food.Key, food.Value);

                    data = RequireData("opcion");
                    if (Foods.ContainsKey(int.Parse(data)))
                    {
                        user.Food.Name = Foods[int.Parse(data)];
                        user.Food.Cost = int.Parse(RequireData("Cuantos minutos demora la actividad?"));
                        user.Food.CostMeasure = CostMeasureEnum.min;
                        state = true;
                    }                        
                }
                else if (user.PlayerAction == PlayerActionEnum.training)
                {
                    foreach (KeyValuePair<int, string> training in Trainings)
                        Console.WriteLine("{0} - {1}", training.Key, training.Value);

                    data = RequireData("opcion");
                    if (Trainings.ContainsKey(int.Parse(data)))
                    {
                        user.Training.Name = Trainings[int.Parse(data)];
                        user.Training.Cost = int.Parse(RequireData("Cuantos segundos demora la actividad?"));
                        user.Training.CostMeasure = CostMeasureEnum.seconds;
                        state = true;
                    }
                }
                else if (user.PlayerAction == PlayerActionEnum.work)
                {
                    foreach (KeyValuePair<int, string> job in Jobs)
                        Console.WriteLine("{0} - {1}", job.Key, job.Value);

                    data = RequireData("opcion");
                    if (Jobs.ContainsKey(int.Parse(data)))
                    {
                        user.Job.Name = Jobs[int.Parse(data)];
                        user.Job.CostTime = double.Parse(RequireData("minutos que demora la actividad (30s = 0,5min, 6hs = 360min) (NO USAR PUNTO PARA DECIMAL!!)"));
                        user.Job.CostMeasure = CostMeasureEnum.min;
                        state = true;
                    }
                }
            } while (!state);
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
