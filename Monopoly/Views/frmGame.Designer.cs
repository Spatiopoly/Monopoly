namespace Monopoly.Views
{
    partial class frmGame
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameView = new Monopoly.Views.GameView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.border = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNextPlayer = new System.Windows.Forms.Button();
            this.btnExchange = new System.Windows.Forms.Button();
            this.btnDice = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabCase = new System.Windows.Forms.TabPage();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.property1 = new Monopoly.Views.PropertyManager();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.gameView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(957, 604);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gameView
            // 
            this.gameView.BackColor = System.Drawing.Color.White;
            this.gameView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameView.Game = null;
            this.gameView.Location = new System.Drawing.Point(0, 0);
            this.gameView.Margin = new System.Windows.Forms.Padding(0);
            this.gameView.Name = "gameView";
            this.gameView.Size = new System.Drawing.Size(657, 604);
            this.gameView.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(0)))));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.border, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tabs, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(657, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 604);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // border
            // 
            this.border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.border.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border.Location = new System.Drawing.Point(0, 494);
            this.border.Margin = new System.Windows.Forms.Padding(0);
            this.border.Name = "border";
            this.border.Size = new System.Drawing.Size(300, 5);
            this.border.TabIndex = 0;
            this.border.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.btnNextPlayer, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnExchange, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDice, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 499);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(300, 105);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // btnNextPlayer
            // 
            this.btnNextPlayer.BackColor = System.Drawing.Color.White;
            this.btnNextPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextPlayer.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextPlayer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnNextPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnNextPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPlayer.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPlayer.Location = new System.Drawing.Point(205, 10);
            this.btnNextPlayer.Margin = new System.Windows.Forms.Padding(5, 10, 10, 10);
            this.btnNextPlayer.Name = "btnNextPlayer";
            this.btnNextPlayer.Size = new System.Drawing.Size(85, 85);
            this.btnNextPlayer.TabIndex = 4;
            this.btnNextPlayer.UseVisualStyleBackColor = false;
            // 
            // btnExchange
            // 
            this.btnExchange.BackColor = System.Drawing.Color.White;
            this.btnExchange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExchange.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExchange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnExchange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnExchange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExchange.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExchange.Location = new System.Drawing.Point(105, 10);
            this.btnExchange.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.btnExchange.Name = "btnExchange";
            this.btnExchange.Size = new System.Drawing.Size(90, 85);
            this.btnExchange.TabIndex = 3;
            this.btnExchange.UseVisualStyleBackColor = false;
            // 
            // btnDice
            // 
            this.btnDice.BackColor = System.Drawing.Color.White;
            this.btnDice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDice.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnDice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDice.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDice.Location = new System.Drawing.Point(10, 10);
            this.btnDice.Margin = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.btnDice.Name = "btnDice";
            this.btnDice.Size = new System.Drawing.Size(85, 85);
            this.btnDice.TabIndex = 2;
            this.btnDice.UseVisualStyleBackColor = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabCase);
            this.tabs.Controls.Add(this.tabProperties);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.Location = new System.Drawing.Point(10, 10);
            this.tabs.Margin = new System.Windows.Forms.Padding(10);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(280, 474);
            this.tabs.TabIndex = 3;
            // 
            // tabCase
            // 
            this.tabCase.Location = new System.Drawing.Point(4, 27);
            this.tabCase.Name = "tabCase";
            this.tabCase.Padding = new System.Windows.Forms.Padding(3);
            this.tabCase.Size = new System.Drawing.Size(272, 443);
            this.tabCase.TabIndex = 0;
            this.tabCase.Text = "Case actuelle";
            this.tabCase.UseVisualStyleBackColor = true;
            // 
            // tabProperties
            // 
            this.tabProperties.AutoScroll = true;
            this.tabProperties.Controls.Add(this.property1);
            this.tabProperties.Location = new System.Drawing.Point(4, 27);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(272, 443);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "Propriétés";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // property1
            // 
            this.property1.Location = new System.Drawing.Point(6, 6);
            this.property1.Name = "property1";
            this.property1.Size = new System.Drawing.Size(100, 230);
            this.property1.TabIndex = 0;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmGame";
            this.ShowIcon = false;
            this.Text = "Monopoly";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GameView gameView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnNextPlayer;
        private System.Windows.Forms.Button btnExchange;
        private System.Windows.Forms.Button btnDice;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabCase;
        private System.Windows.Forms.TabPage tabProperties;
        private PropertyManager property1;
    }
}

