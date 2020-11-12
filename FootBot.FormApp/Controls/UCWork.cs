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
using System.Drawing;

namespace FootBot.FormApp.Controls
{
    public partial class UCWork : UserControl
    {
        private List<Work> _works;
        private User _user;

        #region SingletonPattern
        private static UCWork _instance;

        public static UCWork GetInstance()
        {
            if (_instance == null)
                _instance = new UCWork();
            return _instance;
        }
        #endregion

        private UCWork()
        {
            InitializeComponent();
            InitializeConfiguration();

            LoadWorkInForm();

            pgbWorks.Visible =
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

        public void CheckColors(Color color1, Color color2, Color color3)
        {
            nudCount.BackColor = nudEnergy.BackColor = nudHours.BackColor = nudMinutes.BackColor = nudSeconds.BackColor = nudPrize.BackColor =
            this.BackColor = color1;            
            
            panel3.BackColor = lstWorks.BackColor = color2;

            if (color1 == Color.FromArgb(255, 255, 255))
                nudCount.ForeColor = nudEnergy.ForeColor = nudHours.ForeColor = nudMinutes.ForeColor = nudSeconds.ForeColor = nudPrize.ForeColor =
                    lstWorks.ForeColor =
                    panel6.BackColor = panel5.BackColor = panel2.BackColor = panel1.BackColor =
                    lblEnergy.ForeColor = label7.ForeColor = label3.ForeColor = label2.ForeColor = Color.FromArgb(0, 0, 0);
            else
                nudCount.ForeColor = nudEnergy.ForeColor = nudHours.ForeColor = nudMinutes.ForeColor = nudSeconds.ForeColor = nudPrize.ForeColor =
                lstWorks.ForeColor =
                panel6.BackColor = panel5.BackColor = panel2.BackColor = panel1.BackColor =
                lblEnergy.ForeColor = label7.ForeColor = label3.ForeColor = label2.ForeColor = Color.FromArgb(255, 255, 255);

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
            {
                pgbWorks.Visible = true;
                backgroundWorkerWork.RunWorkerAsync();
            }
                
            else
                MessageBox.Show("Por favor, deja de explotarme, ya estoy trabajando...");

            btnInitWork.Enabled = false;
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

        #endregion

        #region BackgroundWorker

        private void backgroundWorkerWork_DoWork(object sender, DoWorkEventArgs e)
        {
            int countProgress = 0;
            SeleniumServices seleniumServices = new SeleniumServices(Application.StartupPath, "https://la.footballteamgame.com/", int.Parse(ConfigurationManager.AppSettings["navigatorId"]));
            try
            {
                seleniumServices.LogIn(_user);

                var resultIndex = seleniumServices.NavigateToUrl(_user.Job, "work");

                while (countProgress < _user.Count)
                {
                    backgroundWorkerWork.ReportProgress(++countProgress * 100 / _user.Count);
                    seleniumServices.doOneActivity(_user.Job, resultIndex, "btn btn-lg btn-primary");
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

        private void backgroundWorkerWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
                MessageBox.Show("Terminé de trabajar, hora de ver a la familia.");
            btnInitWork.Enabled = true;
            pgbWorks.Value = 0;
            pgbWorks.Visible = false;
        }

        private void backgroundWorkerWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbWorks.Value = e.ProgressPercentage;
            pgbWorks.Update();
        }

        #endregion
    }
}
