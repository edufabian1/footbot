using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using FootBot.Models.Models;
using System.Configuration;
using FootBot.Selenium;
using System.Linq;
using System;
using System.Drawing;

namespace FootBot.FormApp.Controls
{
    public partial class UCTraining : UserControl
    {
        private List<Training> _trainings;
        private User _user;

        #region SingletonPattern
        private static UCTraining _instance;

        public static UCTraining GetInstance()
        {
            if (_instance == null)
                _instance = new UCTraining();
            return _instance;
        }
        #endregion

        private UCTraining()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadFoodInForm();

            pgbTrainings.Visible = 
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

        public void CheckColors(Color color1, Color color2, Color color3)
        {
            MessageBox.Show("Chequeando training");
        }

        #endregion

        #region Events

        private void lstTrainings_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoodInForm();
        }

        private void btnInitTrain_Click(object sender, EventArgs e)
        {
            _user.Count = int.Parse(nudCount.Value.ToString());
            _user.Training = (Training) lstTrainings.SelectedItem;
            
            if (!backgroundWorkerTrain.IsBusy)
            {
                pgbTrainings.Visible = true;
                backgroundWorkerTrain.RunWorkerAsync();
            }
                
            else
                MessageBox.Show("Por favor, deja de explotarme, ya estoy entrenando...");

            btnInitTrain.Enabled = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
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

        #endregion

        #region BackgroundWorker

        private void backgroundWorkerTrain_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int countProgress = 0;
            SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/", int.Parse(ConfigurationManager.AppSettings["navigatorId"]));
            try
            {
                seleniumServices.LogIn(_user);

                var resultIndex = seleniumServices.NavigateToUrl(_user.Training, "training");

                while (countProgress < _user.Count)
                {
                    backgroundWorkerTrain.ReportProgress(++countProgress * 100 / _user.Count);
                    seleniumServices.doOneActivity(_user.Training, resultIndex, "btn btn-primary tile-box__btn pulse-in-tutorial");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                seleniumServices.LogOut(true);
            }
        }

        private void backgroundWorkerTrain_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                MessageBox.Show("Entrenamiento finalizado, sex appeal +1.");
            btnInitTrain.Enabled = true;            
            pgbTrainings.Value = 0;
            pgbTrainings.Visible = false;
        }

        private void backgroundWorkerTrain_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pgbTrainings.Value = e.ProgressPercentage;
            pgbTrainings.Update();
        }

        #endregion
    }
}
