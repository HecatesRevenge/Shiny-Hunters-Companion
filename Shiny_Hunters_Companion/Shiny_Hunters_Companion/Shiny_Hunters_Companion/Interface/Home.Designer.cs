namespace Shiny_Hunters_Companion
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.grbActiveHunt = new System.Windows.Forms.GroupBox();
            this.btnCaught = new System.Windows.Forms.Button();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.btnToggleTimer = new System.Windows.Forms.Button();
            this.lblLapTimer = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblEncounters = new System.Windows.Forms.Label();
            this.btnIncrease = new System.Windows.Forms.Button();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.lblMethod = new System.Windows.Forms.Label();
            this.lblTargetPokemon = new System.Windows.Forms.Label();
            this.picPokemonSprite = new System.Windows.Forms.PictureBox();
            this.grbStats = new System.Windows.Forms.GroupBox();
            this.lblTotalEncounters = new System.Windows.Forms.Label();
            this.lblTotalShinies = new System.Windows.Forms.Label();
            this.grbOdds = new System.Windows.Forms.GroupBox();
            this.lblCurrentOdds = new System.Windows.Forms.Label();
            this.lblBaseOdds = new System.Windows.Forms.Label();
            this.grbAchievements = new System.Windows.Forms.GroupBox();
            this.progAch3 = new System.Windows.Forms.ProgressBar();
            this.lblAch3 = new System.Windows.Forms.Label();
            this.progAch2 = new System.Windows.Forms.ProgressBar();
            this.lblAch2 = new System.Windows.Forms.Label();
            this.progAch1 = new System.Windows.Forms.ProgressBar();
            this.lblAch1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProbTitle = new System.Windows.Forms.Label();
            this.progProb = new System.Windows.Forms.ProgressBar();
            this.grpProb = new System.Windows.Forms.GroupBox();
            this.grbMilestones = new System.Windows.Forms.GroupBox();
            this.lblMilestone50 = new System.Windows.Forms.Label();
            this.lblEstTime = new System.Windows.Forms.Label();
            this.lblEstTitle = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.grbHuntPace = new System.Windows.Forms.GroupBox();
            this.lblMilestone90 = new System.Windows.Forms.Label();
            this.lblMilestone99 = new System.Windows.Forms.Label();
            this.lblLuckStatus = new System.Windows.Forms.Label();
            this.lblPercentile = new System.Windows.Forms.Label();
            this.grbActiveHunt.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).BeginInit();
            this.grbStats.SuspendLayout();
            this.grbOdds.SuspendLayout();
            this.grbAchievements.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.grpProb.SuspendLayout();
            this.grbMilestones.SuspendLayout();
            this.grbHuntPace.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // grbActiveHunt
            // 
            this.grbActiveHunt.Controls.Add(this.btnCaught);
            this.grbActiveHunt.Controls.Add(this.pnlTimer);
            this.grbActiveHunt.Controls.Add(this.lblEncounters);
            this.grbActiveHunt.Controls.Add(this.btnIncrease);
            this.grbActiveHunt.Controls.Add(this.btnDecrease);
            this.grbActiveHunt.Controls.Add(this.lblMethod);
            this.grbActiveHunt.Controls.Add(this.lblTargetPokemon);
            this.grbActiveHunt.Controls.Add(this.picPokemonSprite);
            this.grbActiveHunt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbActiveHunt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbActiveHunt.Location = new System.Drawing.Point(40, 80);
            this.grbActiveHunt.Name = "grbActiveHunt";
            this.grbActiveHunt.Size = new System.Drawing.Size(400, 640);
            this.grbActiveHunt.TabIndex = 1;
            this.grbActiveHunt.TabStop = false;
            this.grbActiveHunt.Text = "Active Shiny Hunts";
            // 
            // btnCaught
            // 
            this.btnCaught.BackColor = System.Drawing.Color.Gold;
            this.btnCaught.Location = new System.Drawing.Point(20, 580);
            this.btnCaught.Name = "btnCaught";
            this.btnCaught.Size = new System.Drawing.Size(360, 50);
            this.btnCaught.TabIndex = 0;
            this.btnCaught.Text = "Caught!";
            this.btnCaught.UseVisualStyleBackColor = false;
            // 
            // pnlTimer
            // 
            this.pnlTimer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTimer.Controls.Add(this.btnToggleTimer);
            this.pnlTimer.Controls.Add(this.lblLapTimer);
            this.pnlTimer.Controls.Add(this.lblTimer);
            this.pnlTimer.Location = new System.Drawing.Point(20, 500);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(360, 70);
            this.pnlTimer.TabIndex = 6;
            // 
            // btnToggleTimer
            // 
            this.btnToggleTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleTimer.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnToggleTimer.Location = new System.Drawing.Point(280, 10);
            this.btnToggleTimer.Name = "btnToggleTimer";
            this.btnToggleTimer.Size = new System.Drawing.Size(50, 50);
            this.btnToggleTimer.TabIndex = 2;
            this.btnToggleTimer.Text = "▶";
            this.btnToggleTimer.UseVisualStyleBackColor = true;
            // 
            // lblLapTimer
            // 
            this.lblLapTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapTimer.Location = new System.Drawing.Point(10, 40);
            this.lblLapTimer.Name = "lblLapTimer";
            this.lblLapTimer.Size = new System.Drawing.Size(200, 25);
            this.lblLapTimer.TabIndex = 1;
            this.lblLapTimer.Text = "00:00:00";
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(10, 5);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(200, 35);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00";
            // 
            // lblEncounters
            // 
            this.lblEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncounters.Location = new System.Drawing.Point(90, 440);
            this.lblEncounters.Name = "lblEncounters";
            this.lblEncounters.Size = new System.Drawing.Size(220, 50);
            this.lblEncounters.TabIndex = 5;
            this.lblEncounters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrease.Location = new System.Drawing.Point(320, 440);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(50, 50);
            this.btnIncrease.TabIndex = 4;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            // 
            // btnDecrease
            // 
            this.btnDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.Location = new System.Drawing.Point(30, 440);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(50, 50);
            this.btnDecrease.TabIndex = 3;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            // 
            // lblMethod
            // 
            this.lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethod.Location = new System.Drawing.Point(20, 390);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(360, 30);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Method:";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetPokemon
            // 
            this.lblTargetPokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetPokemon.Location = new System.Drawing.Point(20, 350);
            this.lblTargetPokemon.Name = "lblTargetPokemon";
            this.lblTargetPokemon.Size = new System.Drawing.Size(360, 40);
            this.lblTargetPokemon.TabIndex = 1;
            this.lblTargetPokemon.Text = "Target:";
            this.lblTargetPokemon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPokemonSprite
            // 
            this.picPokemonSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPokemonSprite.Location = new System.Drawing.Point(50, 40);
            this.picPokemonSprite.Name = "picPokemonSprite";
            this.picPokemonSprite.Size = new System.Drawing.Size(300, 300);
            this.picPokemonSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPokemonSprite.TabIndex = 0;
            this.picPokemonSprite.TabStop = false;
            // 
            // grbStats
            // 
            this.grbStats.Controls.Add(this.lblTotalEncounters);
            this.grbStats.Controls.Add(this.lblTotalShinies);
            this.grbStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbStats.Location = new System.Drawing.Point(460, 80);
            this.grbStats.Name = "grbStats";
            this.grbStats.Size = new System.Drawing.Size(600, 120);
            this.grbStats.TabIndex = 2;
            this.grbStats.TabStop = false;
            this.grbStats.Text = "Hunter Stats";
            // 
            // lblTotalEncounters
            // 
            this.lblTotalEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEncounters.Location = new System.Drawing.Point(30, 70);
            this.lblTotalEncounters.Name = "lblTotalEncounters";
            this.lblTotalEncounters.Size = new System.Drawing.Size(250, 30);
            this.lblTotalEncounters.TabIndex = 1;
            this.lblTotalEncounters.Text = "Total Encounters:";
            // 
            // lblTotalShinies
            // 
            this.lblTotalShinies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalShinies.Location = new System.Drawing.Point(30, 40);
            this.lblTotalShinies.Name = "lblTotalShinies";
            this.lblTotalShinies.Size = new System.Drawing.Size(250, 30);
            this.lblTotalShinies.TabIndex = 0;
            this.lblTotalShinies.Text = "Total Shinies:";
            this.lblTotalShinies.Click += new System.EventHandler(this.label2_Click);
            // 
            // grbOdds
            // 
            this.grbOdds.Controls.Add(this.lblPercentile);
            this.grbOdds.Controls.Add(this.lblLuckStatus);
            this.grbOdds.Controls.Add(this.grbMilestones);
            this.grbOdds.Controls.Add(this.grbHuntPace);
            this.grbOdds.Controls.Add(this.grpProb);
            this.grbOdds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOdds.Location = new System.Drawing.Point(461, 220);
            this.grbOdds.Name = "grbOdds";
            this.grbOdds.Size = new System.Drawing.Size(600, 360);
            this.grbOdds.TabIndex = 3;
            this.grbOdds.TabStop = false;
            this.grbOdds.Text = "Hunt Analysis";
            // 
            // lblCurrentOdds
            // 
            this.lblCurrentOdds.AutoSize = true;
            this.lblCurrentOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentOdds.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentOdds.Location = new System.Drawing.Point(250, 25);
            this.lblCurrentOdds.Name = "lblCurrentOdds";
            this.lblCurrentOdds.Size = new System.Drawing.Size(137, 17);
            this.lblCurrentOdds.TabIndex = 3;
            this.lblCurrentOdds.Text = "Current Odds: 1/512";
            this.lblCurrentOdds.Click += new System.EventHandler(this.lblCurrentOdds_Click);
            // 
            // lblBaseOdds
            // 
            this.lblBaseOdds.AutoSize = true;
            this.lblBaseOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseOdds.Location = new System.Drawing.Point(20, 25);
            this.lblBaseOdds.Name = "lblBaseOdds";
            this.lblBaseOdds.Size = new System.Drawing.Size(134, 17);
            this.lblBaseOdds.TabIndex = 2;
            this.lblBaseOdds.Text = "Base Odds: 1/4,096";
            // 
            // grbAchievements
            // 
            this.grbAchievements.Controls.Add(this.progAch3);
            this.grbAchievements.Controls.Add(this.lblAch3);
            this.grbAchievements.Controls.Add(this.progAch2);
            this.grbAchievements.Controls.Add(this.lblAch2);
            this.grbAchievements.Controls.Add(this.progAch1);
            this.grbAchievements.Controls.Add(this.lblAch1);
            this.grbAchievements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAchievements.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAchievements.Location = new System.Drawing.Point(460, 600);
            this.grbAchievements.Name = "grbAchievements";
            this.grbAchievements.Size = new System.Drawing.Size(600, 120);
            this.grbAchievements.TabIndex = 4;
            this.grbAchievements.TabStop = false;
            this.grbAchievements.Text = "Achievements";
            // 
            // progAch3
            // 
            this.progAch3.Location = new System.Drawing.Point(222, 90);
            this.progAch3.Name = "progAch3";
            this.progAch3.Size = new System.Drawing.Size(200, 20);
            this.progAch3.TabIndex = 9;
            this.progAch3.Value = 66;
            // 
            // lblAch3
            // 
            this.lblAch3.AutoSize = true;
            this.lblAch3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch3.Location = new System.Drawing.Point(22, 90);
            this.lblAch3.Name = "lblAch3";
            this.lblAch3.Size = new System.Drawing.Size(163, 20);
            this.lblAch3.TabIndex = 8;
            this.lblAch3.Text = "Place Holder Achiev 2";
            // 
            // progAch2
            // 
            this.progAch2.Location = new System.Drawing.Point(220, 60);
            this.progAch2.Name = "progAch2";
            this.progAch2.Size = new System.Drawing.Size(200, 20);
            this.progAch2.TabIndex = 7;
            this.progAch2.Value = 66;
            // 
            // lblAch2
            // 
            this.lblAch2.AutoSize = true;
            this.lblAch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch2.Location = new System.Drawing.Point(20, 60);
            this.lblAch2.Name = "lblAch2";
            this.lblAch2.Size = new System.Drawing.Size(195, 20);
            this.lblAch2.TabIndex = 6;
            this.lblAch2.Text = "Place Holder Achievement";
            // 
            // progAch1
            // 
            this.progAch1.Location = new System.Drawing.Point(220, 30);
            this.progAch1.Name = "progAch1";
            this.progAch1.Size = new System.Drawing.Size(200, 20);
            this.progAch1.TabIndex = 5;
            this.progAch1.Value = 66;
            // 
            // lblAch1
            // 
            this.lblAch1.AutoSize = true;
            this.lblAch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch1.Location = new System.Drawing.Point(20, 30);
            this.lblAch1.Name = "lblAch1";
            this.lblAch1.Size = new System.Drawing.Size(197, 20);
            this.lblAch1.TabIndex = 4;
            this.lblAch1.Text = "Hat Trick (Catch 3 Shinies)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.picProfile);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 60);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMenu.Location = new System.Drawing.Point(970, 10);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(100, 40);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "▼ Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.Gray;
            this.picProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProfile.Location = new System.Drawing.Point(920, 10);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(40, 40);
            this.picProfile.TabIndex = 1;
            this.picProfile.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(259, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shiny Hunter\'s Companion";
            // 
            // lblProbTitle
            // 
            this.lblProbTitle.AutoSize = true;
            this.lblProbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProbTitle.Location = new System.Drawing.Point(20, 50);
            this.lblProbTitle.Name = "lblProbTitle";
            this.lblProbTitle.Size = new System.Drawing.Size(90, 17);
            this.lblProbTitle.TabIndex = 4;
            this.lblProbTitle.Text = "Probability:";
            // 
            // progProb
            // 
            this.progProb.Location = new System.Drawing.Point(20, 70);
            this.progProb.Name = "progProb";
            this.progProb.Size = new System.Drawing.Size(530, 25);
            this.progProb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progProb.TabIndex = 5;
            // 
            // grpProb
            // 
            this.grpProb.Controls.Add(this.lblBaseOdds);
            this.grpProb.Controls.Add(this.lblCurrentOdds);
            this.grpProb.Controls.Add(this.progProb);
            this.grpProb.Controls.Add(this.lblProbTitle);
            this.grpProb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProb.Location = new System.Drawing.Point(15, 30);
            this.grpProb.Name = "grpProb";
            this.grpProb.Size = new System.Drawing.Size(570, 100);
            this.grpProb.TabIndex = 7;
            this.grpProb.TabStop = false;
            this.grpProb.Text = "Live Probability";
            // 
            // grbMilestones
            // 
            this.grbMilestones.Controls.Add(this.lblMilestone99);
            this.grbMilestones.Controls.Add(this.lblMilestone90);
            this.grbMilestones.Controls.Add(this.lblMilestone50);
            this.grbMilestones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMilestones.Location = new System.Drawing.Point(310, 140);
            this.grbMilestones.Name = "grbMilestones";
            this.grbMilestones.Size = new System.Drawing.Size(275, 130);
            this.grbMilestones.TabIndex = 9;
            this.grbMilestones.TabStop = false;
            this.grbMilestones.Text = "Next Milestones";
            // 
            // lblMilestone50
            // 
            this.lblMilestone50.AutoSize = true;
            this.lblMilestone50.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone50.Location = new System.Drawing.Point(20, 30);
            this.lblMilestone50.Name = "lblMilestone50";
            this.lblMilestone50.Size = new System.Drawing.Size(146, 17);
            this.lblMilestone50.TabIndex = 7;
            this.lblMilestone50.Text = "50%: Reached (0 left)";
            // 
            // lblEstTime
            // 
            this.lblEstTime.AutoSize = true;
            this.lblEstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTime.Location = new System.Drawing.Point(20, 90);
            this.lblEstTime.Name = "lblEstTime";
            this.lblEstTime.Size = new System.Drawing.Size(87, 20);
            this.lblEstTime.TabIndex = 6;
            this.lblEstTime.Text = "4.2 Hours";
            // 
            // lblEstTitle
            // 
            this.lblEstTitle.AutoSize = true;
            this.lblEstTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblEstTitle.Location = new System.Drawing.Point(20, 70);
            this.lblEstTitle.Name = "lblEstTitle";
            this.lblEstTitle.Size = new System.Drawing.Size(139, 20);
            this.lblEstTitle.TabIndex = 6;
            this.lblEstTitle.Text = "Est. Time to Odds:";
            this.lblEstTitle.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(20, 30);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(122, 20);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "Speed: 145/hr";
            // 
            // grbHuntPace
            // 
            this.grbHuntPace.Controls.Add(this.lblSpeed);
            this.grbHuntPace.Controls.Add(this.lblEstTitle);
            this.grbHuntPace.Controls.Add(this.lblEstTime);
            this.grbHuntPace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHuntPace.Location = new System.Drawing.Point(15, 136);
            this.grbHuntPace.Name = "grbHuntPace";
            this.grbHuntPace.Size = new System.Drawing.Size(275, 130);
            this.grbHuntPace.TabIndex = 8;
            this.grbHuntPace.TabStop = false;
            this.grbHuntPace.Text = "Hunting Pace";
            // 
            // lblMilestone90
            // 
            this.lblMilestone90.AutoSize = true;
            this.lblMilestone90.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone90.Location = new System.Drawing.Point(20, 60);
            this.lblMilestone90.Name = "lblMilestone90";
            this.lblMilestone90.Size = new System.Drawing.Size(133, 17);
            this.lblMilestone90.TabIndex = 8;
            this.lblMilestone90.Text = "90%: 1,100 left (7h)";
            // 
            // lblMilestone99
            // 
            this.lblMilestone99.AutoSize = true;
            this.lblMilestone99.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone99.Location = new System.Drawing.Point(20, 90);
            this.lblMilestone99.Name = "lblMilestone99";
            this.lblMilestone99.Size = new System.Drawing.Size(141, 17);
            this.lblMilestone99.TabIndex = 9;
            this.lblMilestone99.Text = "99%: 2,300 left (15h)";
            // 
            // lblLuckStatus
            // 
            this.lblLuckStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuckStatus.Location = new System.Drawing.Point(21, 289);
            this.lblLuckStatus.Name = "lblLuckStatus";
            this.lblLuckStatus.Size = new System.Drawing.Size(570, 35);
            this.lblLuckStatus.TabIndex = 8;
            this.lblLuckStatus.Text = "Status:";
            this.lblLuckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercentile
            // 
            this.lblPercentile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentile.Location = new System.Drawing.Point(15, 320);
            this.lblPercentile.Name = "lblPercentile";
            this.lblPercentile.Size = new System.Drawing.Size(570, 35);
            this.lblPercentile.TabIndex = 10;
            this.lblPercentile.Text = "Slightly Lucky";
            this.lblPercentile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbAchievements);
            this.Controls.Add(this.grbOdds);
            this.Controls.Add(this.grbStats);
            this.Controls.Add(this.grbActiveHunt);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shiny Hunter\'s Companion";
            this.grbActiveHunt.ResumeLayout(false);
            this.pnlTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).EndInit();
            this.grbStats.ResumeLayout(false);
            this.grbOdds.ResumeLayout(false);
            this.grbAchievements.ResumeLayout(false);
            this.grbAchievements.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.grpProb.ResumeLayout(false);
            this.grpProb.PerformLayout();
            this.grbMilestones.ResumeLayout(false);
            this.grbMilestones.PerformLayout();
            this.grbHuntPace.ResumeLayout(false);
            this.grbHuntPace.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox grbActiveHunt;
        private System.Windows.Forms.GroupBox grbStats;
        private System.Windows.Forms.GroupBox grbOdds;
        private System.Windows.Forms.GroupBox grbAchievements;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.Label lblTargetPokemon;
        private System.Windows.Forms.PictureBox picPokemonSprite;
        private System.Windows.Forms.Label lblEncounters;
        private System.Windows.Forms.Button btnIncrease;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnCaught;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.Button btnToggleTimer;
        private System.Windows.Forms.Label lblLapTimer;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblTotalShinies;
        private System.Windows.Forms.Label lblTotalEncounters;
        private System.Windows.Forms.Label lblCurrentOdds;
        private System.Windows.Forms.Label lblBaseOdds;
        private System.Windows.Forms.Label lblAch1;
        private System.Windows.Forms.ProgressBar progAch3;
        private System.Windows.Forms.Label lblAch3;
        private System.Windows.Forms.ProgressBar progAch2;
        private System.Windows.Forms.Label lblAch2;
        private System.Windows.Forms.ProgressBar progAch1;
        private System.Windows.Forms.ProgressBar progProb;
        private System.Windows.Forms.Label lblProbTitle;
        private System.Windows.Forms.GroupBox grpProb;
        private System.Windows.Forms.GroupBox grbMilestones;
        private System.Windows.Forms.Label lblMilestone50;
        private System.Windows.Forms.GroupBox grbHuntPace;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblEstTitle;
        private System.Windows.Forms.Label lblEstTime;
        private System.Windows.Forms.Label lblLuckStatus;
        private System.Windows.Forms.Label lblMilestone99;
        private System.Windows.Forms.Label lblMilestone90;
        private System.Windows.Forms.Label lblPercentile;
    }
}