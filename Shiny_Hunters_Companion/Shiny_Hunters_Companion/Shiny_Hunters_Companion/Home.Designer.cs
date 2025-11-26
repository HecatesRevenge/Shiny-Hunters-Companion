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
            this.grbStats = new System.Windows.Forms.GroupBox();
            this.grbOdds = new System.Windows.Forms.GroupBox();
            this.grbAchievements = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.Button();
            this.picPokemonSprite = new System.Windows.Forms.PictureBox();
            this.lblTargetPokemon = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDecrease = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEncounters = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCaught = new System.Windows.Forms.Button();
            this.grbActiveHunt.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).BeginInit();
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
            this.grbActiveHunt.Controls.Add(this.panel2);
            this.grbActiveHunt.Controls.Add(this.lblEncounters);
            this.grbActiveHunt.Controls.Add(this.button1);
            this.grbActiveHunt.Controls.Add(this.btnDecrease);
            this.grbActiveHunt.Controls.Add(this.label1);
            this.grbActiveHunt.Controls.Add(this.lblTargetPokemon);
            this.grbActiveHunt.Controls.Add(this.picPokemonSprite);
            this.grbActiveHunt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbActiveHunt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbActiveHunt.Location = new System.Drawing.Point(40, 80);
            this.grbActiveHunt.Name = "grbActiveHunt";
            this.grbActiveHunt.Size = new System.Drawing.Size(400, 640);
            this.grbActiveHunt.TabIndex = 1;
            this.grbActiveHunt.TabStop = false;
            this.grbActiveHunt.Text = "Active Shiny Hunts";
            // 
            // grbStats
            // 
            this.grbStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbStats.Location = new System.Drawing.Point(460, 80);
            this.grbStats.Name = "grbStats";
            this.grbStats.Size = new System.Drawing.Size(600, 120);
            this.grbStats.TabIndex = 2;
            this.grbStats.TabStop = false;
            this.grbStats.Text = "Hunter Stats";
            // 
            // grbOdds
            // 
            this.grbOdds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOdds.Location = new System.Drawing.Point(461, 220);
            this.grbOdds.Name = "grbOdds";
            this.grbOdds.Size = new System.Drawing.Size(600, 360);
            this.grbOdds.TabIndex = 3;
            this.grbOdds.TabStop = false;
            this.grbOdds.Text = "Hunt Analysis";
            // 
            // grbAchievements
            // 
            this.grbAchievements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grbAchievements.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbAchievements.Location = new System.Drawing.Point(460, 600);
            this.grbAchievements.Name = "grbAchievements";
            this.grbAchievements.Size = new System.Drawing.Size(600, 120);
            this.grbAchievements.TabIndex = 4;
            this.grbAchievements.TabStop = false;
            this.grbAchievements.Text = "Achievements";
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
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Shiny Hunter\'s Companion";
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "Method:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(320, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Location = new System.Drawing.Point(20, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 70);
            this.panel2.TabIndex = 6;
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPokemonSprite)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTargetPokemon;
        private System.Windows.Forms.PictureBox picPokemonSprite;
        private System.Windows.Forms.Label lblEncounters;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDecrease;
        private System.Windows.Forms.Button btnCaught;
        private System.Windows.Forms.Panel panel2;
    }
}