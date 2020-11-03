using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using FootBot.Models.Models;
using System.Configuration;
using FootBot.Selenium;
using System.Linq;

namespace FootBot.FormApp.Controls
{
    public partial class UCTraining : UserControl
    {
        private List<Training> _trainings;
        private User _user;

        private static UCTraining _instance;

        public static UCTraining GetInstance()
        {
            if (_instance == null)
                _instance = new UCTraining();
            return _instance;
        }

        private UCTraining()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadFoodInForm();

            nudCost.Controls[0].Visible = nudEnergy.Controls[0].Visible = nudSeconds.Controls[0].Visible =
                nudMinutes.Controls[0].Visible = nudHours.Controls[0].Visible = nudCount.Controls[0].Visible = false;

            _user = new User
            {
                Username = ConfigurationManager.AppSettings["user"],
                Password = ConfigurationManager.AppSettings["password"]
            };
        }

        #region Aux

        private void LoadFoodInForm()
        {
            Training product = (Training)lstTrainings.SelectedItem;

            nudHours.Value = product.Hours;
            nudMinutes.Value = product.Minutes;
            nudSeconds.Value = product.Seconds;
            nudEnergy.Value = product.Energy;
            nudCost.Value = product.Cost;
        }

        private void InitializeConfiguration()
        {
            string[] paths = { Application.StartupPath, "Configurations", "Trainings.json" };
            string path = Path.Combine(paths);

            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                _trainings = JsonConvert.DeserializeObject<List<Training>>(json);
            }

            lstTrainings.DataSource = _trainings;
            lstTrainings.DisplayMember = "Name";
            lstTrainings.ValueMember = "Id";
        }

        #endregion

        #region Events

        private void lstTrainings_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadFoodInForm();
        }

        private void btnInitTrain_Click(object sender, System.EventArgs e)
        {
            _user.Count = int.Parse(nudCount.Value.ToString());
            _user.Training = (Training) lstTrainings.SelectedItem;

            if (!backgroundWorkerTrain.IsBusy)
                backgroundWorkerTrain.RunWorkerAsync();
            else
                MessageBox.Show("Por favor, deja de explotarme, ya estoy entrenando...");
        }

        #endregion

        private void backgroundWorkerTrain_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/");

                seleniumServices.LogIn(_user);

                seleniumServices.Train(_user, _user.Training);

                seleniumServices.LogOut(false);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
        {
            Training training = (Training)lstTrainings.SelectedItem;

            _trainings.Where(item => item.Id == training.Id).ToList().ForEach(s => {
                s.Energy = int.Parse(nudEnergy.Value.ToString());
                s.Cost = int.Parse(nudCost.Value.ToString());
                s.Hours = int.Parse(nudHours.Value.ToString());
                s.Minutes = int.Parse(nudMinutes.Value.ToString());
                s.Seconds = int.Parse(nudSeconds.Value.ToString());
            });

            string json = JsonConvert.SerializeObject(_trainings);

            string[] paths = { Application.StartupPath, "Configurations", "Trainings.json" };
            string path = Path.Combine(paths);
            File.WriteAllText(path, json);
        }
    }
}
