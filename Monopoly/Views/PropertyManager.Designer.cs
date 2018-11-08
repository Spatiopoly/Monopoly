namespace Monopoly.Views
{
    partial class PropertyManager
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

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMortgage = new System.Windows.Forms.Button();
            this.btnAddBuilding = new System.Windows.Forms.Button();
            this.btnRemoveBuilding = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbxBuilding = new System.Windows.Forms.PictureBox();
            this.btnLiftMortgage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBuilding)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMortgage
            // 
            this.btnMortgage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMortgage.Location = new System.Drawing.Point(3, 200);
            this.btnMortgage.Name = "btnMortgage";
            this.btnMortgage.Size = new System.Drawing.Size(94, 26);
            this.btnMortgage.TabIndex = 0;
            this.btnMortgage.Text = "Hypothéquer";
            this.btnMortgage.UseVisualStyleBackColor = true;
            this.btnMortgage.Click += new System.EventHandler(this.btnMortgage_Click);
            // 
            // btnAddBuilding
            // 
            this.btnAddBuilding.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBuilding.Location = new System.Drawing.Point(70, 163);
            this.btnAddBuilding.Name = "btnAddBuilding";
            this.btnAddBuilding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAddBuilding.Size = new System.Drawing.Size(27, 27);
            this.btnAddBuilding.TabIndex = 2;
            this.btnAddBuilding.Text = "+";
            this.btnAddBuilding.UseVisualStyleBackColor = true;
            this.btnAddBuilding.Click += new System.EventHandler(this.btnAddBuilding_Click);
            // 
            // btnRemoveBuilding
            // 
            this.btnRemoveBuilding.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBuilding.Location = new System.Drawing.Point(38, 163);
            this.btnRemoveBuilding.Name = "btnRemoveBuilding";
            this.btnRemoveBuilding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRemoveBuilding.Size = new System.Drawing.Size(27, 27);
            this.btnRemoveBuilding.TabIndex = 3;
            this.btnRemoveBuilding.Text = "-";
            this.btnRemoveBuilding.UseVisualStyleBackColor = true;
            this.btnRemoveBuilding.Click += new System.EventHandler(this.btnRemoveBuilding_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 150);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pbxBuilding
            // 
            this.pbxBuilding.BackgroundImage = global::Monopoly.Properties.Resources.House;
            this.pbxBuilding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxBuilding.Location = new System.Drawing.Point(3, 161);
            this.pbxBuilding.Name = "pbxBuilding";
            this.pbxBuilding.Size = new System.Drawing.Size(30, 30);
            this.pbxBuilding.TabIndex = 4;
            this.pbxBuilding.TabStop = false;
            // 
            // btnLiftMortgage
            // 
            this.btnLiftMortgage.Enabled = false;
            this.btnLiftMortgage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiftMortgage.Location = new System.Drawing.Point(3, 201);
            this.btnLiftMortgage.Name = "btnLiftMortgage";
            this.btnLiftMortgage.Size = new System.Drawing.Size(94, 26);
            this.btnLiftMortgage.TabIndex = 6;
            this.btnLiftMortgage.Text = "Récupérer";
            this.btnLiftMortgage.UseVisualStyleBackColor = true;
            this.btnLiftMortgage.Visible = false;
            this.btnLiftMortgage.Click += new System.EventHandler(this.btnLiftMortgage_Click);
            // 
            // PropertyManager
            // 
            this.Controls.Add(this.btnLiftMortgage);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbxBuilding);
            this.Controls.Add(this.btnRemoveBuilding);
            this.Controls.Add(this.btnAddBuilding);
            this.Controls.Add(this.btnMortgage);
            this.Name = "PropertyManager";
            this.Size = new System.Drawing.Size(100, 230);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBuilding)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMortgage;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.Button btnRemoveBuilding;
        private System.Windows.Forms.PictureBox pbxBuilding;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnLiftMortgage;
    }
}
