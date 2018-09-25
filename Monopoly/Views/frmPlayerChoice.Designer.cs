namespace Monopoly.Views
{
    partial class frmPlayerChoice
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
            this.btnValider = new System.Windows.Forms.Button();
            this.selectorPlayerYellow = new Monopoly.Views.PlayerSelector();
            this.selectorPlayerPurple = new Monopoly.Views.PlayerSelector();
            this.selectorPlayerBlue = new Monopoly.Views.PlayerSelector();
            this.selectorPlayerGreen = new Monopoly.Views.PlayerSelector();
            this.selectorPlayerRed = new Monopoly.Views.PlayerSelector();
            this.SuspendLayout();
            // 
            // btnValider
            // 
            this.btnValider.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(13, 363);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(389, 43);
            this.btnValider.TabIndex = 5;
            this.btnValider.Text = "Démarrer";
            this.btnValider.UseVisualStyleBackColor = true;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // selectorPlayerYellow
            // 
            this.selectorPlayerYellow.Color = Monopoly.Models.Player.PlayerColor.Yellow;
            this.selectorPlayerYellow.IsActive = false;
            this.selectorPlayerYellow.Location = new System.Drawing.Point(12, 286);
            this.selectorPlayerYellow.Name = "selectorPlayerYellow";
            this.selectorPlayerYellow.PlayerName = "";
            this.selectorPlayerYellow.Size = new System.Drawing.Size(390, 60);
            this.selectorPlayerYellow.TabIndex = 4;
            // 
            // selectorPlayerPurple
            // 
            this.selectorPlayerPurple.Color = Monopoly.Models.Player.PlayerColor.Purple;
            this.selectorPlayerPurple.IsActive = false;
            this.selectorPlayerPurple.Location = new System.Drawing.Point(12, 217);
            this.selectorPlayerPurple.Name = "selectorPlayerPurple";
            this.selectorPlayerPurple.PlayerName = "";
            this.selectorPlayerPurple.Size = new System.Drawing.Size(390, 60);
            this.selectorPlayerPurple.TabIndex = 3;
            // 
            // selectorPlayerBlue
            // 
            this.selectorPlayerBlue.Color = Monopoly.Models.Player.PlayerColor.Blue;
            this.selectorPlayerBlue.IsActive = true;
            this.selectorPlayerBlue.Location = new System.Drawing.Point(12, 79);
            this.selectorPlayerBlue.Name = "selectorPlayerBlue";
            this.selectorPlayerBlue.PlayerName = "Stitch";
            this.selectorPlayerBlue.Size = new System.Drawing.Size(390, 60);
            this.selectorPlayerBlue.TabIndex = 1;
            // 
            // selectorPlayerGreen
            // 
            this.selectorPlayerGreen.Color = Monopoly.Models.Player.PlayerColor.Green;
            this.selectorPlayerGreen.IsActive = false;
            this.selectorPlayerGreen.Location = new System.Drawing.Point(12, 148);
            this.selectorPlayerGreen.Name = "selectorPlayerGreen";
            this.selectorPlayerGreen.PlayerName = "";
            this.selectorPlayerGreen.Size = new System.Drawing.Size(390, 60);
            this.selectorPlayerGreen.TabIndex = 2;
            // 
            // selectorPlayerRed
            // 
            this.selectorPlayerRed.Color = Monopoly.Models.Player.PlayerColor.Red;
            this.selectorPlayerRed.IsActive = true;
            this.selectorPlayerRed.Location = new System.Drawing.Point(12, 10);
            this.selectorPlayerRed.Name = "selectorPlayerRed";
            this.selectorPlayerRed.PlayerName = "Deadpool";
            this.selectorPlayerRed.Size = new System.Drawing.Size(390, 60);
            this.selectorPlayerRed.TabIndex = 0;
            // 
            // frmPlayerChoice
            // 
            this.AcceptButton = this.btnValider;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 418);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.selectorPlayerYellow);
            this.Controls.Add(this.selectorPlayerPurple);
            this.Controls.Add(this.selectorPlayerBlue);
            this.Controls.Add(this.selectorPlayerGreen);
            this.Controls.Add(this.selectorPlayerRed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmPlayerChoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choix des joueurs";
            this.ResumeLayout(false);

        }

        #endregion

        private PlayerSelector selectorPlayerRed;
        private PlayerSelector selectorPlayerGreen;
        private PlayerSelector selectorPlayerBlue;
        private PlayerSelector selectorPlayerPurple;
        private PlayerSelector selectorPlayerYellow;
        private System.Windows.Forms.Button btnValider;
    }
}