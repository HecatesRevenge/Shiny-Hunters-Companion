namespace Shiny_Hunters_Companion
{
    partial class NewHunt
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
            this.grbSelectGame = new System.Windows.Forms.GroupBox();
            this.cbGames = new System.Windows.Forms.ComboBox();
            this.gbMethod = new System.Windows.Forms.GroupBox();
            this.lblMethodDesc = new System.Windows.Forms.Label();
            this.cbMethods = new System.Windows.Forms.ComboBox();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.lblPreviewOdds = new System.Windows.Forms.Label();
            this.lblPreviewName = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.gbPokemonSelect = new System.Windows.Forms.GroupBox();
            this.lstPokemon = new System.Windows.Forms.ListBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbModifiers = new System.Windows.Forms.GroupBox();
            this.chkModifiers = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbSelectGame.SuspendLayout();
            this.gbMethod.SuspendLayout();
            this.gbPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbPokemonSelect.SuspendLayout();
            this.gbModifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSelectGame
            // 
            this.grbSelectGame.Controls.Add(this.cbGames);
            this.grbSelectGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSelectGame.Location = new System.Drawing.Point(40, 25);
            this.grbSelectGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbSelectGame.Name = "grbSelectGame";
            this.grbSelectGame.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grbSelectGame.Size = new System.Drawing.Size(467, 98);
            this.grbSelectGame.TabIndex = 0;
            this.grbSelectGame.TabStop = false;
            this.grbSelectGame.Text = "#1 Select Game:";
            // 
            // cbGames
            // 
            this.cbGames.FormattingEnabled = true;
            this.cbGames.Location = new System.Drawing.Point(27, 37);
            this.cbGames.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbGames.Name = "cbGames";
            this.cbGames.Size = new System.Drawing.Size(412, 34);
            this.cbGames.TabIndex = 0;
            this.cbGames.SelectedIndexChanged += new System.EventHandler(this.cbGames_SelectedIndexChanged);
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.lblMethodDesc);
            this.gbMethod.Controls.Add(this.cbMethods);
            this.gbMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMethod.Location = new System.Drawing.Point(40, 148);
            this.gbMethod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbMethod.Size = new System.Drawing.Size(467, 148);
            this.gbMethod.TabIndex = 1;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "#2 Select Method:";
            // 
            // lblMethodDesc
            // 
            this.lblMethodDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethodDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblMethodDesc.Location = new System.Drawing.Point(27, 80);
            this.lblMethodDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMethodDesc.Name = "lblMethodDesc";
            this.lblMethodDesc.Size = new System.Drawing.Size(413, 55);
            this.lblMethodDesc.TabIndex = 1;
            this.lblMethodDesc.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbMethods
            // 
            this.cbMethods.FormattingEnabled = true;
            this.cbMethods.Location = new System.Drawing.Point(27, 37);
            this.cbMethods.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbMethods.Name = "cbMethods";
            this.cbMethods.Size = new System.Drawing.Size(412, 34);
            this.cbMethods.TabIndex = 0;
            this.cbMethods.SelectedIndexChanged += new System.EventHandler(this.cbMethods_SelectedIndexChanged);
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.lblPreviewOdds);
            this.gbPreview.Controls.Add(this.lblPreviewName);
            this.gbPreview.Controls.Add(this.pbPreview);
            this.gbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPreview.Location = new System.Drawing.Point(560, 25);
            this.gbPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPreview.Size = new System.Drawing.Size(453, 652);
            this.gbPreview.TabIndex = 1;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview:";
            // 
            // lblPreviewOdds
            // 
            this.lblPreviewOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewOdds.Location = new System.Drawing.Point(27, 465);
            this.lblPreviewOdds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreviewOdds.Name = "lblPreviewOdds";
            this.lblPreviewOdds.Size = new System.Drawing.Size(400, 49);
            this.lblPreviewOdds.TabIndex = 2;
            // 
            // lblPreviewName
            // 
            this.lblPreviewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewName.Location = new System.Drawing.Point(27, 394);
            this.lblPreviewName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPreviewName.Name = "lblPreviewName";
            this.lblPreviewName.Size = new System.Drawing.Size(400, 49);
            this.lblPreviewName.TabIndex = 1;
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(60, 62);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(333, 307);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            this.pbPreview.Click += new System.EventHandler(this.pbPreview_Click);
            // 
            // gbPokemonSelect
            // 
            this.gbPokemonSelect.Controls.Add(this.lstPokemon);
            this.gbPokemonSelect.Controls.Add(this.txtSearch);
            this.gbPokemonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPokemonSelect.Location = new System.Drawing.Point(40, 320);
            this.gbPokemonSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPokemonSelect.Name = "gbPokemonSelect";
            this.gbPokemonSelect.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbPokemonSelect.Size = new System.Drawing.Size(467, 185);
            this.gbPokemonSelect.TabIndex = 2;
            this.gbPokemonSelect.TabStop = false;
            this.gbPokemonSelect.Text = "#3 Pokemon";
            // 
            // lstPokemon
            // 
            this.lstPokemon.FormattingEnabled = true;
            this.lstPokemon.ItemHeight = 26;
            this.lstPokemon.Location = new System.Drawing.Point(27, 86);
            this.lstPokemon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstPokemon.Name = "lstPokemon";
            this.lstPokemon.Size = new System.Drawing.Size(412, 30);
            this.lstPokemon.TabIndex = 3;
            this.lstPokemon.SelectedIndexChanged += new System.EventHandler(this.lstPokemon_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(31, 46);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(412, 30);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search...";
            // 
            // gbModifiers
            // 
            this.gbModifiers.Controls.Add(this.chkModifiers);
            this.gbModifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbModifiers.Location = new System.Drawing.Point(40, 517);
            this.gbModifiers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModifiers.Name = "gbModifiers";
            this.gbModifiers.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbModifiers.Size = new System.Drawing.Size(467, 148);
            this.gbModifiers.TabIndex = 3;
            this.gbModifiers.TabStop = false;
            this.gbModifiers.Text = "#4 Modifiers";
            // 
            // chkModifiers
            // 
            this.chkModifiers.CheckOnClick = true;
            this.chkModifiers.FormattingEnabled = true;
            this.chkModifiers.Location = new System.Drawing.Point(27, 31);
            this.chkModifiers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkModifiers.Name = "chkModifiers";
            this.chkModifiers.Size = new System.Drawing.Size(412, 85);
            this.chkModifiers.TabIndex = 0;
            this.chkModifiers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkModifiers_ItemCheck);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.PaleGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(560, 689);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(267, 62);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightPink;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(880, 689);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 62);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NewHunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 789);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbModifiers);
            this.Controls.Add(this.gbPokemonSelect);
            this.Controls.Add(this.gbPreview);
            this.Controls.Add(this.gbMethod);
            this.Controls.Add(this.grbSelectGame);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "NewHunt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start New Shiny Hunt";
            this.Load += new System.EventHandler(this.NewHunt_Load);
            this.grbSelectGame.ResumeLayout(false);
            this.gbMethod.ResumeLayout(false);
            this.gbPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbPokemonSelect.ResumeLayout(false);
            this.gbPokemonSelect.PerformLayout();
            this.gbModifiers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSelectGame;
        private System.Windows.Forms.ComboBox cbGames;
        private System.Windows.Forms.GroupBox gbMethod;
        private System.Windows.Forms.Label lblMethodDesc;
        private System.Windows.Forms.ComboBox cbMethods;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Label lblPreviewOdds;
        private System.Windows.Forms.Label lblPreviewName;
        private System.Windows.Forms.GroupBox gbPokemonSelect;
        private System.Windows.Forms.ListBox lstPokemon;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbModifiers;
        private System.Windows.Forms.CheckedListBox chkModifiers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
    }
}