using FootBot.Models.Models;
using FootBot.Selenium;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FootBot.FormApp.Controls
{
    public partial class UCFood : UserControl
    {
        private List<Food> _product;
        private User _user;
        
        private static UCFood _instance;

        public static UCFood GetInstance()
        {
            if (_instance == null)
                _instance = new UCFood();            
            return _instance;
        }

        private UCFood()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadFoodInForm();

            nudEnergy.Controls[0].Visible = nudSeconds.Controls[0].Visible = 
                nudMinutes.Controls[0].Visible = nudHours.Controls[0].Visible = nudCount.Controls[0].Visible = false;

            _user = new User
            {
                Username = ConfigurationManager.AppSettings["user"],
                Password = ConfigurationManager.AppSettings["password"]
            };
        }

        #region Events

        private void btnInitTrain_Click(object sender, System.EventArgs e)
        {
            _user.Count = int.Parse(nudCount.Value.ToString());
            _user.Food = (Food)lstFoods.SelectedItem;

            if (!backgroundWorkerFood.IsBusy)
                backgroundWorkerFood.RunWorkerAsync();
            else
                MessageBox.Show("Por favor, deja de engordarme, ya estoy comiendo...");
        }

        private void lstTrainings_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            LoadFoodInForm();
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

        private void backgroundWorkerFood_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/");

                seleniumServices.LogIn(_user);

                seleniumServices.Eat(_user, _user.Food);

                seleniumServices.LogOut(false);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, System.EventArgs e)
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
    }
}
