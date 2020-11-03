namespace FootBot.FormApp
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWork = new System.Windows.Forms.Button();
            this.lblNav = new System.Windows.Forms.Panel();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnTraining = new System.Windows.Forms.Button();
            this.btnCity = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUserDescription = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pctUser = new System.Windows.Forms.PictureBox();
            this.pnlControlsContainer = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.ntfIconApp = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnWork);
            this.panel1.Controls.Add(this.lblNav);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Controls.Add(this.btnTraining);
            this.panel1.Controls.Add(this.btnCity);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // btnWork
            // 
            this.btnWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWork.FlatAppearance.BorderSize = 0;
            this.btnWork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWork.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWork.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnWork.Image = ((System.Drawing.Image)(resources.GetObject("btnWork.Image")));
            this.btnWork.Location = new System.Drawing.Point(0, 286);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(186, 42);
            this.btnWork.TabIndex = 6;
            this.btnWork.Text = "Trabajo            ";
            this.btnWork.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // lblNav
            // 
            this.lblNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblNav.Location = new System.Drawing.Point(0, 160);
            this.lblNav.Name = "lblNav";
            this.lblNav.Size = new System.Drawing.Size(3, 42);
            this.lblNav.TabIndex = 3;
            // 
            // btnConfig
            // 
            this.btnConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfig.FlatAppearance.BorderSize = 0;
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfig.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfig.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.Location = new System.Drawing.Point(0, 535);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(186, 42);
            this.btnConfig.TabIndex = 5;
            this.btnConfig.Text = "Configuracion";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnTraining
            // 
            this.btnTraining.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTraining.FlatAppearance.BorderSize = 0;
            this.btnTraining.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTraining.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraining.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnTraining.Image = ((System.Drawing.Image)(resources.GetObject("btnTraining.Image")));
            this.btnTraining.Location = new System.Drawing.Point(0, 244);
            this.btnTraining.Name = "btnTraining";
            this.btnTraining.Size = new System.Drawing.Size(186, 42);
            this.btnTraining.TabIndex = 3;
            this.btnTraining.Text = "Entrenamiento";
            this.btnTraining.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnTraining.UseVisualStyleBackColor = true;
            this.btnTraining.Click += new System.EventHandler(this.btnTraining_Click);
            // 
            // btnCity
            // 
            this.btnCity.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCity.FlatAppearance.BorderSize = 0;
            this.btnCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCity.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnCity.Image = ((System.Drawing.Image)(resources.GetObject("btnCity.Image")));
            this.btnCity.Location = new System.Drawing.Point(0, 202);
            this.btnCity.Name = "btnCity";
            this.btnCity.Size = new System.Drawing.Size(186, 42);
            this.btnCity.TabIndex = 2;
            this.btnCity.Text = "Ciudad            ";
            this.btnCity.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCity.UseVisualStyleBackColor = true;
            this.btnCity.Click += new System.EventHandler(this.btnCity_Click);
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 160);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(186, 42);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Inicio             ";
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUserDescription);
            this.panel2.Controls.Add(this.lblUserName);
            this.panel2.Controls.Add(this.pctUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 160);
            this.panel2.TabIndex = 0;
            // 
            // lblUserDescription
            // 
            this.lblUserDescription.AutoSize = true;
            this.lblUserDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(178)))));
            this.lblUserDescription.Location = new System.Drawing.Point(37, 121);
            this.lblUserDescription.Name = "lblUserDescription";
            this.lblUserDescription.Size = new System.Drawing.Size(112, 12);
            this.lblUserDescription.TabIndex = 2;
            this.lblUserDescription.Text = "Some User Text Here";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblUserName.Location = new System.Drawing.Point(47, 88);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 16);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "User Name";
            // 
            // pctUser
            // 
            this.pctUser.Image = ((System.Drawing.Image)(resources.GetObject("pctUser.Image")));
            this.pctUser.Location = new System.Drawing.Point(60, 22);
            this.pctUser.Name = "pctUser";
            this.pctUser.Size = new System.Drawing.Size(63, 63);
            this.pctUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctUser.TabIndex = 0;
            this.pctUser.TabStop = false;
            // 
            // pnlControlsContainer
            // 
            this.pnlControlsContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControlsContainer.Location = new System.Drawing.Point(186, 112);
            this.pnlControlsContainer.Name = "pnlControlsContainer";
            this.pnlControlsContainer.Size = new System.Drawing.Size(765, 465);
            this.pnlControlsContainer.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(906, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.Location = new System.Drawing.Point(871, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 26);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // ntfIconApp
            // 
            this.ntfIconApp.BalloonTipText = "Se encuentra ejecutando en segundo plano";
            this.ntfIconApp.BalloonTipTitle = "FootBot";
            this.ntfIconApp.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfIconApp.Icon")));
            this.ntfIconApp.Text = "FootBot";
            this.ntfIconApp.Visible = true;
            this.ntfIconApp.DoubleClick += new System.EventHandler(this.ntfIconApp_DoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlControlsContainer);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel lblNav;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.Button btnTraining;
        private System.Windows.Forms.Button btnCity;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblUserDescription;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox pctUser;
        private System.Windows.Forms.Panel pnlControlsContainer;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.NotifyIcon ntfIconApp;
    }
}

