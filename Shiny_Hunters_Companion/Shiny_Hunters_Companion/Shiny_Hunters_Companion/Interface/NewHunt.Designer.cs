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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbModifiers = new System.Windows.Forms.GroupBox();
            this.chkModifiers = new System.Windows.Forms.CheckedListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstPokemon = new System.Windows.Forms.ComboBox();
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
            this.grbSelectGame.Location = new System.Drawing.Point(30, 20);
            this.grbSelectGame.Name = "grbSelectGame";
            this.grbSelectGame.Size = new System.Drawing.Size(350, 80);
            this.grbSelectGame.TabIndex = 0;
            this.grbSelectGame.TabStop = false;
            this.grbSelectGame.Text = "#1 Select Game:";
            // 
            // cbGames
            // 
            this.cbGames.DropDownHeight = 200;
            this.cbGames.FormattingEnabled = true;
            this.cbGames.IntegralHeight = false;
            this.cbGames.Location = new System.Drawing.Point(20, 30);
            this.cbGames.MaxDropDownItems = 10;
            this.cbGames.Name = "cbGames";
            this.cbGames.Size = new System.Drawing.Size(310, 28);
            this.cbGames.TabIndex = 0;
            this.cbGames.SelectedIndexChanged += new System.EventHandler(this.cbGames_SelectedIndexChanged);
            // 
            // gbMethod
            // 
            this.gbMethod.Controls.Add(this.lblMethodDesc);
            this.gbMethod.Controls.Add(this.cbMethods);
            this.gbMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMethod.Location = new System.Drawing.Point(30, 120);
            this.gbMethod.Name = "gbMethod";
            this.gbMethod.Size = new System.Drawing.Size(350, 120);
            this.gbMethod.TabIndex = 1;
            this.gbMethod.TabStop = false;
            this.gbMethod.Text = "#2 Select Method:";
            // 
            // lblMethodDesc
            // 
            this.lblMethodDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMethodDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblMethodDesc.Location = new System.Drawing.Point(20, 65);
            this.lblMethodDesc.Name = "lblMethodDesc";
            this.lblMethodDesc.Size = new System.Drawing.Size(310, 45);
            this.lblMethodDesc.TabIndex = 1;
            this.lblMethodDesc.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbMethods
            // 
            this.cbMethods.FormattingEnabled = true;
            this.cbMethods.Location = new System.Drawing.Point(20, 30);
            this.cbMethods.Name = "cbMethods";
            this.cbMethods.Size = new System.Drawing.Size(310, 28);
            this.cbMethods.TabIndex = 0;
            this.cbMethods.SelectedIndexChanged += new System.EventHandler(this.cbMethods_SelectedIndexChanged);
            // 
            // gbPreview
            // 
            this.gbPreview.Controls.Add(this.lblPreviewOdds);
            this.gbPreview.Controls.Add(this.lblPreviewName);
            this.gbPreview.Controls.Add(this.pbPreview);
            this.gbPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPreview.Location = new System.Drawing.Point(420, 20);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(340, 530);
            this.gbPreview.TabIndex = 1;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Preview:";
            // 
            // lblPreviewOdds
            // 
            this.lblPreviewOdds.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewOdds.Location = new System.Drawing.Point(20, 378);
            this.lblPreviewOdds.Name = "lblPreviewOdds";
            this.lblPreviewOdds.Size = new System.Drawing.Size(300, 40);
            this.lblPreviewOdds.TabIndex = 2;
            // 
            // lblPreviewName
            // 
            this.lblPreviewName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreviewName.Location = new System.Drawing.Point(20, 320);
            this.lblPreviewName.Name = "lblPreviewName";
            this.lblPreviewName.Size = new System.Drawing.Size(300, 40);
            this.lblPreviewName.TabIndex = 1;
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(45, 50);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(250, 250);
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
            this.gbPokemonSelect.Location = new System.Drawing.Point(30, 260);
            this.gbPokemonSelect.Name = "gbPokemonSelect";
            this.gbPokemonSelect.Size = new System.Drawing.Size(350, 150);
            this.gbPokemonSelect.TabIndex = 2;
            this.gbPokemonSelect.TabStop = false;
            this.gbPokemonSelect.Text = "#3 Pokemon";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(23, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(310, 26);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "Search...";
            // 
            // gbModifiers
            // 
            this.gbModifiers.Controls.Add(this.chkModifiers);
            this.gbModifiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbModifiers.Location = new System.Drawing.Point(30, 420);
            this.gbModifiers.Name = "gbModifiers";
            this.gbModifiers.Size = new System.Drawing.Size(350, 120);
            this.gbModifiers.TabIndex = 3;
            this.gbModifiers.TabStop = false;
            this.gbModifiers.Text = "#4 Modifiers";
            // 
            // chkModifiers
            // 
            this.chkModifiers.CheckOnClick = true;
            this.chkModifiers.FormattingEnabled = true;
            this.chkModifiers.Location = new System.Drawing.Point(20, 25);
            this.chkModifiers.Name = "chkModifiers";
            this.chkModifiers.Size = new System.Drawing.Size(310, 70);
            this.chkModifiers.TabIndex = 0;
            this.chkModifiers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkModifiers_ItemCheck);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.PaleGreen;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(420, 560);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 50);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightPink;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(660, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 50);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstPokemon
            // 
            this.lstPokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.lstPokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.lstPokemon.DropDownHeight = 200;
            this.lstPokemon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstPokemon.DropDownWidth = 100;
            this.lstPokemon.FormattingEnabled = true;
            this.lstPokemon.IntegralHeight = false;
            this.lstPokemon.Location = new System.Drawing.Point(20, 69);
            this.lstPokemon.MaxDropDownItems = 5;
            this.lstPokemon.MaxLength = 10;
            this.lstPokemon.Name = "lstPokemon";
            this.lstPokemon.Size = new System.Drawing.Size(313, 28);
            this.lstPokemon.TabIndex = 3;
            this.lstPokemon.SelectedIndexChanged += new System.EventHandler(this.lstPokemon_SelectedIndexChanged);
            // 
            // NewHunt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 641);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbModifiers);
            this.Controls.Add(this.gbPokemonSelect);
            this.Controls.Add(this.gbPreview);
            this.Controls.Add(this.gbMethod);
            this.Controls.Add(this.grbSelectGame);
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
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox gbModifiers;
        private System.Windows.Forms.CheckedListBox chkModifiers;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox lstPokemon;
    }
}