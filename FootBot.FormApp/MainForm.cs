using FootBot.FormApp.Controls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FootBot.FormApp
{
    public partial class MainForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRec, int nRightReact, int nBottomRect, int nWidthEllipse, int nHeighEllipse
        );

        private UCWork ucWork = UCWork.GetInstance();
        private UCFood ucFood = UCFood.GetInstance();
        private UCTraining uCTraining = UCTraining.GetInstance();
        private Button _tempButton;        

        private static MainForm _mainForm;

        public static MainForm MainFormInstance
        {
            get
            {
                if (_mainForm != null)
                    _mainForm = new MainForm();
                return _mainForm;
            }
        }

        public MainForm()
        {
            InitializeComponent();           
        }

        #region Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            _tempButton = btnHome;
            UpdateNavWithButton(btnHome);
            _mainForm = this;
            button1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 23, 23));
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ntfIconApp.Dispose();
            Application.Exit();            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UpdateNavWithButton(btnHome);
            pnlControlsContainer.Controls.Clear();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            UpdateNavWithButton(btnCity);
            pnlControlsContainer.Controls.Clear();

            UpdatePanelContainerForControl(ucFood);            
        }

        private void btnTraining_Click(object sender, EventArgs e)
        {
            UpdateNavWithButton(btnTraining);
            pnlControlsContainer.Controls.Clear();

            UpdatePanelContainerForControl(uCTraining);
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            UpdateNavWithButton(btnWork);
            pnlControlsContainer.Controls.Clear();

            UpdatePanelContainerForControl(ucWork);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            UpdateNavWithButton(btnConfig);
            pnlControlsContainer.Controls.Clear();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.ntfIconApp.Visible = true;
                this.ShowInTaskbar = false;
                this.ntfIconApp.ShowBalloonTip(200);
            }
            else
            {
                this.ntfIconApp.Visible = false;
                this.ShowInTaskbar = true;
            }

        }

        private void ntfIconApp_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        #endregion

        private void UpdateNavWithButton(Button button)
        {
            lblNav.Height = button.Height;
            lblNav.Top = button.Top;
            if (button1.ImageAlign == ContentAlignment.MiddleRight)
            {
                button.BackColor = Color.FromArgb(255, 196, 214);
                if (_tempButton != button)
                    _tempButton.BackColor = Color.FromArgb(255, 166, 193);
            }
            else
            {
                button.BackColor = Color.FromArgb(46, 51, 73);
                if (_tempButton != button)
                    _tempButton.BackColor = Color.FromArgb(24, 30, 54);
            }
            _tempButton = button;
        }

        private void UpdatePanelContainerForControl(UserControl control)
        {
            pnlControlsContainer.Controls.Clear();

            control.Dock = DockStyle.Fill;
            pnlControlsContainer.Controls.Add(control);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Color color1, color2, color3;

            if (button1.ImageAlign == ContentAlignment.MiddleLeft)
            {
                button1.ImageAlign = ContentAlignment.MiddleRight;
                color1 = Color.FromArgb(255, 255, 255);
                color2 = Color.FromArgb(255, 166, 193);
                color3 = Color.FromArgb(255, 255, 255);                
            }
            else
            {
                button1.ImageAlign = ContentAlignment.MiddleLeft;
                color1 = Color.FromArgb(46, 51, 73);
                color2 = Color.FromArgb(24, 30, 54);                
                color3 = Color.FromArgb(0, 126, 249);             
            }            

            this.BackColor = color1;

            btnHome.BackColor = btnCity.BackColor = btnTraining.BackColor = btnWork.BackColor = btnConfig.BackColor =
                button1.BackColor = panel1.BackColor = panel2.BackColor = color2;

            lblNav.BackColor =
                lblUserName.ForeColor = btnHome.ForeColor = btnCity.ForeColor =
                btnTraining.ForeColor = btnWork.ForeColor = btnConfig.ForeColor = color3;

            ucWork.CheckColors(color1, color2, color3);
            ucFood.CheckColors(color1, color2, color3);
            uCTraining.CheckColors(color1, color2, color3);
        }
    }
}
