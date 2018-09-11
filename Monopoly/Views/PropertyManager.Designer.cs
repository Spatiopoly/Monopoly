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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Monopoly.Properties.Resources.House;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 161);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 150);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // PropertyManager
            // 
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRemoveBuilding);
            this.Controls.Add(this.btnAddBuilding);
            this.Controls.Add(this.btnMortgage);
            this.Name = "PropertyManager";
            this.Size = new System.Drawing.Size(100, 230);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMortgage;
        private System.Windows.Forms.Button btnAddBuilding;
        private System.Windows.Forms.Button btnRemoveBuilding;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
