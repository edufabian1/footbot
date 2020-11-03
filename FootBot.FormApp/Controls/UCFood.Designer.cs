namespace FootBot.FormApp.Controls
{
    partial class UCFood
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInitTrain = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudSeconds = new System.Windows.Forms.NumericUpDown();
            this.nudMinutes = new System.Windows.Forms.NumericUpDown();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCount = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstFoods = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.nudEnergy = new System.Windows.Forms.NumericUpDown();
            this.backgroundWorkerFood = new System.ComponentModel.BackgroundWorker();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInitTrain
            // 
            this.btnInitTrain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(69)))));
            this.btnInitTrain.FlatAppearance.BorderSize = 0;
            this.btnInitTrain.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(198)))), ((int)(((byte)(132)))));
            this.btnInitTrain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitTrain.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnInitTrain.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnInitTrain.Location = new System.Drawing.Point(147, 288);
            this.btnInitTrain.Name = "btnInitTrain";
            this.btnInitTrain.Size = new System.Drawing.Size(156, 33);
            this.btnInitTrain.TabIndex = 27;
            this.btnInitTrain.Text = "Iniciar";
            this.btnInitTrain.UseVisualStyleBackColor = true;
            this.btnInitTrain.Click += new System.EventHandler(this.btnInitTrain_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(328, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 21);
            this.label6.TabIndex = 26;
            this.label6.Text = "Hs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(251, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(179, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 21);
            this.label4.TabIndex = 24;
            this.label4.Text = ":";
            // 
            // nudSeconds
            // 
            this.nudSeconds.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nudSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.nudSeconds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudSeconds.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.nudSeconds.ForeColor = System.Drawing.Color.White;
            this.nudSeconds.Location = new System.Drawing.Point(264, 230);
            this.nudSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSeconds.Name = "nudSeconds";
            this.nudSeconds.ReadOnly = true;
            this.nudSeconds.Size = new System.Drawing.Size(58, 25);
            this.nudSeconds.TabIndex = 23;
            this.nudSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nudMinutes
            // 
            this.nudMinutes.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nudMinutes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.nudMinutes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudMinutes.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.nudMinutes.ForeColor = System.Drawing.Color.White;
            this.nudMinutes.Location = new System.Drawing.Point(187, 230);
            this.nudMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.ReadOnly = true;
            this.nudMinutes.Size = new System.Drawing.Size(58, 25);
            this.nudMinutes.TabIndex = 22;
            this.nudMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(115, 262);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(207, 1);
            this.panel6.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(162, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 20;
            this.label3.Text = "Costo en tiempo";
            // 
            // nudHours
            // 
            this.nudHours.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nudHours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.nudHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudHours.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.nudHours.ForeColor = System.Drawing.Color.White;
            this.nudHours.Location = new System.Drawing.Point(115, 230);
            this.nudHours.Name = "nudHours";
            this.nudHours.ReadOnly = true;
            this.nudHours.Size = new System.Drawing.Size(58, 25);
            this.nudHours.TabIndex = 19;
            this.nudHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(112, 163);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(90, 1);
            this.panel5.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(108, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "Repeticiones";
            // 
            // nudCount
            // 
            this.nudCount.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nudCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.nudCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudCount.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.nudCount.ForeColor = System.Drawing.Color.White;
            this.nudCount.Location = new System.Drawing.Point(112, 131);
            this.nudCount.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudCount.Name = "nudCount";
            this.nudCount.Size = new System.Drawing.Size(98, 25);
            this.nudCount.TabIndex = 16;
            this.nudCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.lstFoods);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(429, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(219, 361);
            this.panel3.TabIndex = 15;
            // 
            // lstFoods
            // 
            this.lstFoods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.lstFoods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFoods.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.lstFoods.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lstFoods.FormattingEnabled = true;
            this.lstFoods.ItemHeight = 17;
            this.lstFoods.Location = new System.Drawing.Point(0, 46);
            this.lstFoods.Name = "lstFoods";
            this.lstFoods.Size = new System.Drawing.Size(219, 315);
            this.lstFoods.TabIndex = 1;
            this.lstFoods.SelectedIndexChanged += new System.EventHandler(this.lstTrainings_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(179)))));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(219, 46);
            this.panel4.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comidas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(243, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 1);
            this.panel1.TabIndex = 21;
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnergy.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEnergy.Location = new System.Drawing.Point(256, 99);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(62, 21);
            this.lblEnergy.TabIndex = 20;
            this.lblEnergy.Text = "Energia";
            // 
            // nudEnergy
            // 
            this.nudEnergy.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.nudEnergy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.nudEnergy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nudEnergy.Font = new System.Drawing.Font("Nirmala UI", 12F);
            this.nudEnergy.ForeColor = System.Drawing.Color.White;
            this.nudEnergy.Location = new System.Drawing.Point(243, 131);
            this.nudEnergy.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudEnergy.Name = "nudEnergy";
            this.nudEnergy.Size = new System.Drawing.Size(98, 25);
            this.nudEnergy.TabIndex = 19;
            this.nudEnergy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // backgroundWorkerFood
            // 
            this.backgroundWorkerFood.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFood_DoWork);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(153)))), ((int)(((byte)(69)))));
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(198)))), ((int)(((byte)(132)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnActualizar.Location = new System.Drawing.Point(147, 338);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(156, 33);
            this.btnActualizar.TabIndex = 28;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // UCFood
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.btnInitTrain);
            this.Controls.Add(this.nudEnergy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudSeconds);
            this.Controls.Add(this.nudMinutes);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudCount);
            this.Controls.Add(this.panel3);
            this.Name = "UCFood";
            this.Size = new System.Drawing.Size(765, 465);
            ((System.ComponentModel.ISupportInitialize)(this.nudSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCount)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEnergy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInitTrain;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudSeconds;
        private System.Windows.Forms.NumericUpDown nudMinutes;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudHours;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudCount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstFoods;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEnergy;
        private System.Windows.Forms.NumericUpDown nudEnergy;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFood;
        private System.Windows.Forms.Button btnActualizar;
    }
}
