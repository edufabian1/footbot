using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using FootBot.Models.Models;
using System.Configuration;
using FootBot.Selenium;
using System.Linq;

namespace FootBot.FormApp.Controls
{
    public partial class UCWork : UserControl
    {
        private List<Work> _works;
        private User _user;

        private static UCWork _instance;

        public static UCWork GetInstance()
        {
            if (_instance == null)
                _instance = new UCWork();
            return _instance;
        }

        private UCWork()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadWorkInForm();

            nudPrize.Controls[0].Visible = nudEnergy.Controls[0].Visible = nudSeconds.Controls[0].Visible =
                nudMinutes.Controls[0].Visible = nudHours.Controls[0].Visible = nudCount.Controls[0].Visible = false;
            
            _user = new User
            {
                Username = ConfigurationManager.AppSettings["user"],
                Password = ConfigurationManager.AppSettings["password"]
            };
        }

        #region Aux

        private void LoadWorkInForm()
        {
            Work work = (Work)lstWorks.SelectedItem;

            nudHours.Value = work.Hours;
            nudMinutes.Value = work.Minutes;
            nudSeconds.Value = work.Seconds;
            nudEnergy.Value = work.Cost;
            nudPrize.Value = work.Prize;
        }

        private void InitializeConfiguration()
        {
            string[] paths = { Application.StartupPath, "Configurations", "Works.json" };
            string path = Path.Combine(paths);

            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                _works = JsonConvert.DeserializeObject<List<Work>>(json);
            }

            lstWorks.DataSource = _works;
            lstWorks.DisplayMember = "Name";
            lstWorks.ValueMember = "Id";
        }

        #endregion

        #region Events

        private void lstWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWorkInForm();
        }

        private void btnInitWork_Click(object sender, EventArgs e)
        {
            _user.Count = int.Parse(nudCount.Value.ToString());
            _user.Job = (Work)lstWorks.SelectedItem;

            if (!backgroundWorkerWork.IsBusy)
                backgroundWorkerWork.RunWorkerAsync();
            else
                MessageBox.Show("Por favor, deja de explotarme, ya estoy trabajando...");
        }

        #endregion

        private void backgroundWorkerWork_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/");

                seleniumServices.LogIn(_user);

                seleniumServices.Job(_user, _user.Job);

                seleniumServices.LogOut(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Work work = (Work)lstWorks.SelectedItem;

            _works.Where(item => item.Id == work.Id).ToList().ForEach(s => {                
                s.Cost = int.Parse(nudEnergy.Value.ToString());
                s.Hours = int.Parse(nudHours.Value.ToString());
                s.Minutes = int.Parse(nudMinutes.Value.ToString());
                s.Seconds = int.Parse(nudSeconds.Value.ToString());
                s.Prize = int.Parse(nudPrize.Value.ToString());
            });

            string json = JsonConvert.SerializeObject(_works);

            string[] paths = { Application.StartupPath, "Configurations", "Works.json" };
            string path = Path.Combine(paths);
            File.WriteAllText(path, json);
        }
    }
}
