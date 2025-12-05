namespace Shiny_Hunters_Companion
{
    partial class PastHunts
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
            this.flowpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowpanel
            // 
            this.flowpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowpanel.Location = new System.Drawing.Point(0, 0);
            this.flowpanel.Name = "flowpanel";
            this.flowpanel.Size = new System.Drawing.Size(800, 541);
            this.flowpanel.TabIndex = 0;
            this.flowpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowpanel_Paint);
            // 
            // PastHunts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.flowpanel);
            this.Name = "PastHunts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shiny Hunting History";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PastHunts_FormClosing);
            this.Load += new System.EventHandler(this.PastHunts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowpanel;
    }
}