using FootBot.Models.Models;
using FootBot.Selenium;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace FootBot.FormApp.Controls
{
    public partial class UCFood : UserControl
    {
        private List<Food> _product;
        private User _user;

        #region SingletonPattern
        private static UCFood _instance;

        public static UCFood GetInstance()
        {
            if (_instance == null)
                _instance = new UCFood();
            return _instance;
        }
        #endregion

        private UCFood()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadFoodInForm();

            pgbFoods.Visible =
            nudEnergy.Controls[0].Visible = nudSeconds.Controls[0].Visible = 
                nudMinutes.Controls[0].Visible = nudHours.Controls[0].Visible = nudCount.Controls[0].Visible = false;

            _user = new User
            {
                Username = ConfigurationManager.AppSettings["user"],
                Password = ConfigurationManager.AppSettings["password"]
            };
        }

        #region Events

        private void btnInitEat_Click(object sender, EventArgs e)
        {
            _user.Count = int.Parse(nudCount.Value.ToString());
            _user.Food = (Food) lstFoods.SelectedItem;

            if (!backgroundWorkerFood.IsBusy)
            {
                pgbFoods.Visible = true;
                backgroundWorkerFood.RunWorkerAsync();
            }

            else
                MessageBox.Show("Por favor, deja de engordarme, ya estoy comiendo...");

            btnInitEat.Enabled = false;
        }

        private void lstTrainings_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFoodInForm();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Food product = (Food)lstFoods.SelectedItem;

            _product.Where(item => item.Id == product.Id).ToList().ForEach(s => {
                s.Energy = int.Parse(nudEnergy.Value.ToString());
                s.Hours = int.Parse(nudHours.Value.ToString());
                s.Minutes = int.Parse(nudMinutes.Value.ToString());
                s.Seconds = int.Parse(nudSeconds.Value.ToString());
            });

            string json = JsonConvert.SerializeObject(_product);

            string[] paths = { Application.StartupPath, "Configurations", "Foods.json" };
            string path = Path.Combine(paths);
            File.WriteAllText(path, json);
        }

        public void CheckColors(Color color1, Color color2, Color color3)
        {
            MessageBox.Show("Chequeando food");
        }

        #endregion

        #region Aux

        private void LoadFoodInForm()
        {
            Food product = (Food)lstFoods.SelectedItem;

            nudHours.Value = product.Hours;
            nudMinutes.Value = product.Minutes;
            nudSeconds.Value = product.Seconds;
            nudEnergy.Value = product.Energy;
        }

        private void InitializeConfiguration()
        {   
            string[] paths = { Application.StartupPath, "Configurations", "Foods.json" };
            string path = Path.Combine(paths);
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                _product = JsonConvert.DeserializeObject<List<Food>>(json);
            }

            lstFoods.DataSource = _product;
            lstFoods.DisplayMember = "Name";
            lstFoods.ValueMember = "Id";
        }

        #endregion

        #region BackgroundWorker

        private void backgroundWorkerFood_DoWork(object sender, DoWorkEventArgs e)
        {
            int countProgress = 0;
            SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/", int.Parse(ConfigurationManager.AppSettings["navigatorId"]));
            try
            {
                seleniumServices.LogIn(_user);

                var resultIndex = seleniumServices.NavigateToUrl(_user.Food, "food");

                while (countProgress < _user.Count)
                {
                    backgroundWorkerFood.ReportProgress(++countProgress * 100 / _user.Count);
                    seleniumServices.doOneActivity(_user.Food, resultIndex, "btn btn-lg btn-primary");
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

        private void backgroundWorkerFood_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                MessageBox.Show("Terminé de comer, ya estoy gordo.");
            btnInitEat.Enabled = true;            
            pgbFoods.Value = 0;
            pgbFoods.Visible = false;
        }

        private void backgroundWorkerFood_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbFoods.Value = e.ProgressPercentage;
            pgbFoods.Update();
        }

        #endregion
    }
}
