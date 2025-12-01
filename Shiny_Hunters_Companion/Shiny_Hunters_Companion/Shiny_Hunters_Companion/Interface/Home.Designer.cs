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
            this.components = new System.ComponentModel.Container();
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
            this.lblPercentile = new System.Windows.Forms.Label();
            this.lblLuckStatus = new System.Windows.Forms.Label();
            this.grbMilestones = new System.Windows.Forms.GroupBox();
            this.lblMilestone99 = new System.Windows.Forms.Label();
            this.lblMilestone90 = new System.Windows.Forms.Label();
            this.lblMilestone50 = new System.Windows.Forms.Label();
            this.grbHuntPace = new System.Windows.Forms.GroupBox();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblEstTitle = new System.Windows.Forms.Label();
            this.lblEstTime = new System.Windows.Forms.Label();
            this.grpProb = new System.Windows.Forms.GroupBox();
            this.lblBaseOdds = new System.Windows.Forms.Label();
            this.lblCurrentOdds = new System.Windows.Forms.Label();
            this.progProb = new System.Windows.Forms.ProgressBar();
            this.lblProbTitle = new System.Windows.Forms.Label();
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
            this.huntTimer = new System.Windows.Forms.Timer(this.components);
            this.dropDownMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startNewHuntToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewShinyPokedexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grbActiveHunt.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).BeginInit();
            this.grbStats.SuspendLayout();
            this.grbOdds.SuspendLayout();
            this.grbMilestones.SuspendLayout();
            this.grbHuntPace.SuspendLayout();
            this.grpProb.SuspendLayout();
            this.grbAchievements.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.dropDownMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1445, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
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
            this.grbActiveHunt.Location = new System.Drawing.Point(53, 98);
            this.grbActiveHunt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbActiveHunt.Name = "grbActiveHunt";
            this.grbActiveHunt.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbActiveHunt.Size = new System.Drawing.Size(533, 788);
            this.grbActiveHunt.TabIndex = 1;
            this.grbActiveHunt.TabStop = false;
            this.grbActiveHunt.Text = "Active Shiny Hunts";
            // 
            // btnCaught
            // 
            this.btnCaught.BackColor = System.Drawing.Color.Gold;
            this.btnCaught.Location = new System.Drawing.Point(27, 714);
            this.btnCaught.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCaught.Name = "btnCaught";
            this.btnCaught.Size = new System.Drawing.Size(480, 62);
            this.btnCaught.TabIndex = 0;
            this.btnCaught.Text = "Caught!";
            this.btnCaught.UseVisualStyleBackColor = false;
            this.btnCaught.Click += new System.EventHandler(this.btnCaught_Click);
            // 
            // pnlTimer
            // 
            this.pnlTimer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlTimer.Controls.Add(this.btnToggleTimer);
            this.pnlTimer.Controls.Add(this.lblLapTimer);
            this.pnlTimer.Controls.Add(this.lblTimer);
            this.pnlTimer.Location = new System.Drawing.Point(27, 615);
            this.pnlTimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(480, 86);
            this.pnlTimer.TabIndex = 6;
            // 
            // btnToggleTimer
            // 
            this.btnToggleTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleTimer.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnToggleTimer.Location = new System.Drawing.Point(373, 12);
            this.btnToggleTimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnToggleTimer.Name = "btnToggleTimer";
            this.btnToggleTimer.Size = new System.Drawing.Size(67, 62);
            this.btnToggleTimer.TabIndex = 2;
            this.btnToggleTimer.Text = "▶";
            this.btnToggleTimer.UseVisualStyleBackColor = true;
            this.btnToggleTimer.Click += new System.EventHandler(this.btnToggleTimer_Click);
            // 
            // lblLapTimer
            // 
            this.lblLapTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapTimer.Location = new System.Drawing.Point(13, 49);
            this.lblLapTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLapTimer.Name = "lblLapTimer";
            this.lblLapTimer.Size = new System.Drawing.Size(267, 31);
            this.lblLapTimer.TabIndex = 1;
            this.lblLapTimer.Text = "00:00:00";
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(13, 6);
            this.lblTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(267, 43);
            this.lblTimer.TabIndex = 0;
            this.lblTimer.Text = "00:00:00";
            // 
            // lblEncounters
            // 
            this.lblEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncounters.Location = new System.Drawing.Point(120, 542);
            this.lblEncounters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEncounters.Name = "lblEncounters";
            this.lblEncounters.Size = new System.Drawing.Size(293, 62);
            this.lblEncounters.TabIndex = 5;
            this.lblEncounters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIncrease
            // 
            this.btnIncrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncrease.Location = new System.Drawing.Point(427, 542);
            this.btnIncrease.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIncrease.Name = "btnIncrease";
            this.btnIncrease.Size = new System.Drawing.Size(67, 62);
            this.btnIncrease.TabIndex = 4;
            this.btnIncrease.Text = "+";
            this.btnIncrease.UseVisualStyleBackColor = true;
            this.btnIncrease.Click += new System.EventHandler(this.btnIncrease_Click);
            // 
            // btnDecrease
            // 
            this.btnDecrease.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrease.Location = new System.Drawing.Point(40, 542);
            this.btnDecrease.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(67, 62);
            this.btnDecrease.TabIndex = 3;
            this.btnDecrease.Text = "-";
            this.btnDecrease.UseVisualStyleBackColor = true;
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // lblMethod
            // 
            this.lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethod.Location = new System.Drawing.Point(27, 480);
            this.lblMethod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(480, 37);
            this.lblMethod.TabIndex = 2;
            this.lblMethod.Text = "Method:";
            this.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTargetPokemon
            // 
            this.lblTargetPokemon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetPokemon.Location = new System.Drawing.Point(27, 431);
            this.lblTargetPokemon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetPokemon.Name = "lblTargetPokemon";
            this.lblTargetPokemon.Size = new System.Drawing.Size(480, 49);
            this.lblTargetPokemon.TabIndex = 1;
            this.lblTargetPokemon.Text = "Target:";
            this.lblTargetPokemon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picPokemonSprite
            // 
            this.picPokemonSprite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPokemonSprite.Location = new System.Drawing.Point(67, 49);
            this.picPokemonSprite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picPokemonSprite.Name = "picPokemonSprite";
            this.picPokemonSprite.Size = new System.Drawing.Size(399, 369);
            this.picPokemonSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPokemonSprite.TabIndex = 0;
            this.picPokemonSprite.TabStop = false;
            this.picPokemonSprite.Click += new System.EventHandler(this.picPokemonSprite_Click);
            // 
            // grbStats
            // 
            this.grbStats.Controls.Add(this.lblTotalEncounters);
            this.grbStats.Controls.Add(this.lblTotalShinies);
            this.grbStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbStats.Location = new System.Drawing.Point(613, 98);
            this.grbStats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbStats.Name = "grbStats";
            this.grbStats.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbStats.Size = new System.Drawing.Size(800, 148);
            this.grbStats.TabIndex = 2;
            this.grbStats.TabStop = false;
            this.grbStats.Text = "Hunter Stats";
            // 
            // lblTotalEncounters
            // 
            this.lblTotalEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalEncounters.Location = new System.Drawing.Point(40, 86);
            this.lblTotalEncounters.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalEncounters.Name = "lblTotalEncounters";
            this.lblTotalEncounters.Size = new System.Drawing.Size(333, 37);
            this.lblTotalEncounters.TabIndex = 1;
            this.lblTotalEncounters.Text = "Total Encounters:";
            // 
            // lblTotalShinies
            // 
            this.lblTotalShinies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalShinies.Location = new System.Drawing.Point(40, 49);
            this.lblTotalShinies.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalShinies.Name = "lblTotalShinies";
            this.lblTotalShinies.Size = new System.Drawing.Size(333, 37);
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
            this.grbOdds.Location = new System.Drawing.Point(615, 271);
            this.grbOdds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbOdds.Name = "grbOdds";
            this.grbOdds.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbOdds.Size = new System.Drawing.Size(800, 443);
            this.grbOdds.TabIndex = 3;
            this.grbOdds.TabStop = false;
            this.grbOdds.Text = "Hunt Analysis";
            // 
            // lblPercentile
            // 
            this.lblPercentile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentile.Location = new System.Drawing.Point(20, 394);
            this.lblPercentile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPercentile.Name = "lblPercentile";
            this.lblPercentile.Size = new System.Drawing.Size(760, 43);
            this.lblPercentile.TabIndex = 10;
            this.lblPercentile.Text = "Slightly Lucky";
            this.lblPercentile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLuckStatus
            // 
            this.lblLuckStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuckStatus.Location = new System.Drawing.Point(28, 356);
            this.lblLuckStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLuckStatus.Name = "lblLuckStatus";
            this.lblLuckStatus.Size = new System.Drawing.Size(760, 43);
            this.lblLuckStatus.TabIndex = 8;
            this.lblLuckStatus.Text = "Status:";
            this.lblLuckStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grbMilestones
            // 
            this.grbMilestones.Controls.Add(this.lblMilestone99);
            this.grbMilestones.Controls.Add(this.lblMilestone90);
            this.grbMilestones.Controls.Add(this.lblMilestone50);
            this.grbMilestones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMilestones.Location = new System.Drawing.Point(413, 172);
            this.grbMilestones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbMilestones.Name = "grbMilestones";
            this.grbMilestones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbMilestones.Size = new System.Drawing.Size(367, 160);
            this.grbMilestones.TabIndex = 9;
            this.grbMilestones.TabStop = false;
            this.grbMilestones.Text = "Next Milestones";
            // 
            // lblMilestone99
            // 
            this.lblMilestone99.AutoSize = true;
            this.lblMilestone99.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone99.Location = new System.Drawing.Point(27, 111);
            this.lblMilestone99.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMilestone99.Name = "lblMilestone99";
            this.lblMilestone99.Size = new System.Drawing.Size(164, 20);
            this.lblMilestone99.TabIndex = 9;
            this.lblMilestone99.Text = "99%: 2,300 left (15h)";
            // 
            // lblMilestone90
            // 
            this.lblMilestone90.AutoSize = true;
            this.lblMilestone90.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone90.Location = new System.Drawing.Point(27, 74);
            this.lblMilestone90.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMilestone90.Name = "lblMilestone90";
            this.lblMilestone90.Size = new System.Drawing.Size(155, 20);
            this.lblMilestone90.TabIndex = 8;
            this.lblMilestone90.Text = "90%: 1,100 left (7h)";
            // 
            // lblMilestone50
            // 
            this.lblMilestone50.AutoSize = true;
            this.lblMilestone50.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilestone50.Location = new System.Drawing.Point(27, 37);
            this.lblMilestone50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMilestone50.Name = "lblMilestone50";
            this.lblMilestone50.Size = new System.Drawing.Size(172, 20);
            this.lblMilestone50.TabIndex = 7;
            this.lblMilestone50.Text = "50%: Reached (0 left)";
            // 
            // grbHuntPace
            // 
            this.grbHuntPace.Controls.Add(this.lblSpeed);
            this.grbHuntPace.Controls.Add(this.lblEstTitle);
            this.grbHuntPace.Controls.Add(this.lblEstTime);
            this.grbHuntPace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbHuntPace.Location = new System.Drawing.Point(20, 167);
            this.grbHuntPace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbHuntPace.Name = "grbHuntPace";
            this.grbHuntPace.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbHuntPace.Size = new System.Drawing.Size(367, 160);
            this.grbHuntPace.TabIndex = 8;
            this.grbHuntPace.TabStop = false;
            this.grbHuntPace.Text = "Hunting Pace";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(27, 37);
            this.lblSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(150, 25);
            this.lblSpeed.TabIndex = 7;
            this.lblSpeed.Text = "Speed: 145/hr";
            // 
            // lblEstTitle
            // 
            this.lblEstTitle.AutoSize = true;
            this.lblEstTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblEstTitle.Location = new System.Drawing.Point(27, 86);
            this.lblEstTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstTitle.Name = "lblEstTitle";
            this.lblEstTitle.Size = new System.Drawing.Size(174, 25);
            this.lblEstTitle.TabIndex = 6;
            this.lblEstTitle.Text = "Est. Time to Odds:";
            this.lblEstTitle.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblEstTime
            // 
            this.lblEstTime.AutoSize = true;
            this.lblEstTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTime.Location = new System.Drawing.Point(27, 111);
            this.lblEstTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstTime.Name = "lblEstTime";
            this.lblEstTime.Size = new System.Drawing.Size(105, 25);
            this.lblEstTime.TabIndex = 6;
            this.lblEstTime.Text = "4.2 Hours";
            // 
            // grpProb
            // 
            this.grpProb.Controls.Add(this.lblBaseOdds);
            this.grpProb.Controls.Add(this.lblCurrentOdds);
            this.grpProb.Controls.Add(this.progProb);
            this.grpProb.Controls.Add(this.lblProbTitle);
            this.grpProb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProb.Location = new System.Drawing.Point(20, 37);
            this.grpProb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpProb.Name = "grpProb";
            this.grpProb.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpProb.Size = new System.Drawing.Size(760, 123);
            this.grpProb.TabIndex = 7;
            this.grpProb.TabStop = false;
            this.grpProb.Text = "Live Probability";
            // 
            // lblBaseOdds
            // 
            this.lblBaseOdds.AutoSize = true;
            this.lblBaseOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaseOdds.Location = new System.Drawing.Point(27, 31);
            this.lblBaseOdds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaseOdds.Name = "lblBaseOdds";
            this.lblBaseOdds.Size = new System.Drawing.Size(157, 20);
            this.lblBaseOdds.TabIndex = 2;
            this.lblBaseOdds.Text = "Base Odds: 1/4,096";
            // 
            // lblCurrentOdds
            // 
            this.lblCurrentOdds.AutoSize = true;
            this.lblCurrentOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentOdds.ForeColor = System.Drawing.Color.Blue;
            this.lblCurrentOdds.Location = new System.Drawing.Point(333, 31);
            this.lblCurrentOdds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentOdds.Name = "lblCurrentOdds";
            this.lblCurrentOdds.Size = new System.Drawing.Size(161, 20);
            this.lblCurrentOdds.TabIndex = 3;
            this.lblCurrentOdds.Text = "Current Odds: 1/512";
            this.lblCurrentOdds.Click += new System.EventHandler(this.lblCurrentOdds_Click);
            // 
            // progProb
            // 
            this.progProb.Location = new System.Drawing.Point(27, 86);
            this.progProb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progProb.Name = "progProb";
            this.progProb.Size = new System.Drawing.Size(707, 31);
            this.progProb.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progProb.TabIndex = 5;
            // 
            // lblProbTitle
            // 
            this.lblProbTitle.AutoSize = true;
            this.lblProbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProbTitle.Location = new System.Drawing.Point(27, 62);
            this.lblProbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProbTitle.Name = "lblProbTitle";
            this.lblProbTitle.Size = new System.Drawing.Size(104, 20);
            this.lblProbTitle.TabIndex = 4;
            this.lblProbTitle.Text = "Probability:";
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
            this.grbAchievements.Location = new System.Drawing.Point(613, 738);
            this.grbAchievements.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbAchievements.Name = "grbAchievements";
            this.grbAchievements.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbAchievements.Size = new System.Drawing.Size(800, 148);
            this.grbAchievements.TabIndex = 4;
            this.grbAchievements.TabStop = false;
            this.grbAchievements.Text = "Achievements";
            // 
            // progAch3
            // 
            this.progAch3.Location = new System.Drawing.Point(296, 111);
            this.progAch3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progAch3.Name = "progAch3";
            this.progAch3.Size = new System.Drawing.Size(267, 25);
            this.progAch3.TabIndex = 9;
            this.progAch3.Value = 66;
            // 
            // lblAch3
            // 
            this.lblAch3.AutoSize = true;
            this.lblAch3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch3.Location = new System.Drawing.Point(29, 111);
            this.lblAch3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAch3.Name = "lblAch3";
            this.lblAch3.Size = new System.Drawing.Size(204, 25);
            this.lblAch3.TabIndex = 8;
            this.lblAch3.Text = "Place Holder Achiev 2";
            // 
            // progAch2
            // 
            this.progAch2.Location = new System.Drawing.Point(293, 74);
            this.progAch2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progAch2.Name = "progAch2";
            this.progAch2.Size = new System.Drawing.Size(267, 25);
            this.progAch2.TabIndex = 7;
            this.progAch2.Value = 66;
            // 
            // lblAch2
            // 
            this.lblAch2.AutoSize = true;
            this.lblAch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch2.Location = new System.Drawing.Point(27, 74);
            this.lblAch2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAch2.Name = "lblAch2";
            this.lblAch2.Size = new System.Drawing.Size(242, 25);
            this.lblAch2.TabIndex = 6;
            this.lblAch2.Text = "Place Holder Achievement";
            // 
            // progAch1
            // 
            this.progAch1.Location = new System.Drawing.Point(293, 37);
            this.progAch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progAch1.Name = "progAch1";
            this.progAch1.Size = new System.Drawing.Size(267, 25);
            this.progAch1.TabIndex = 5;
            this.progAch1.Value = 66;
            // 
            // lblAch1
            // 
            this.lblAch1.AutoSize = true;
            this.lblAch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAch1.Location = new System.Drawing.Point(27, 37);
            this.lblAch1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAch1.Name = "lblAch1";
            this.lblAch1.Size = new System.Drawing.Size(247, 25);
            this.lblAch1.TabIndex = 4;
            this.lblAch1.Text = "Hat Trick (Catch 3 Shinies)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.picProfile);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1467, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnMenu.Location = new System.Drawing.Point(1293, 12);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(133, 49);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "▼ Menu";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.Gray;
            this.picProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProfile.Location = new System.Drawing.Point(1227, 12);
            this.picProfile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(53, 49);
            this.picProfile.TabIndex = 1;
            this.picProfile.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(27, 18);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shiny Hunter\'s Companion";
            // 
            // huntTimer
            // 
            this.huntTimer.Interval = 1000;
            this.huntTimer.Tick += new System.EventHandler(this.huntTimer_Tick);
            // 
            // dropDownMenu
            // 
            this.dropDownMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.dropDownMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewHuntToolStripMenuItem,
            this.viewShinyPokedexToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.dropDownMenu.Name = "dropDownMenu";
            this.dropDownMenu.Size = new System.Drawing.Size(209, 76);
            // 
            // startNewHuntToolStripMenuItem
            // 
            this.startNewHuntToolStripMenuItem.Name = "startNewHuntToolStripMenuItem";
            this.startNewHuntToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.startNewHuntToolStripMenuItem.Text = "Start New Hunt";
            this.startNewHuntToolStripMenuItem.Click += new System.EventHandler(this.Menu_NewHunt_Click);
            // 
            // viewShinyPokedexToolStripMenuItem
            // 
            this.viewShinyPokedexToolStripMenuItem.Name = "viewShinyPokedexToolStripMenuItem";
            this.viewShinyPokedexToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.viewShinyPokedexToolStripMenuItem.Text = "View Shiny Pokedex";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.Menu_LogOut_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 887);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbAchievements);
            this.Controls.Add(this.grbOdds);
            this.Controls.Add(this.grbStats);
            this.Controls.Add(this.grbActiveHunt);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shiny Hunter\'s Companion";
            this.Load += new System.EventHandler(this.Home_Load);
            this.grbActiveHunt.ResumeLayout(false);
            this.pnlTimer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).EndInit();
            this.grbStats.ResumeLayout(false);
            this.grbOdds.ResumeLayout(false);
            this.grbMilestones.ResumeLayout(false);
            this.grbMilestones.PerformLayout();
            this.grbHuntPace.ResumeLayout(false);
            this.grbHuntPace.PerformLayout();
            this.grpProb.ResumeLayout(false);
            this.grpProb.PerformLayout();
            this.grbAchievements.ResumeLayout(false);
            this.grbAchievements.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.dropDownMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Timer huntTimer;
        private System.Windows.Forms.ContextMenuStrip dropDownMenu;
        private System.Windows.Forms.ToolStripMenuItem startNewHuntToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewShinyPokedexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}