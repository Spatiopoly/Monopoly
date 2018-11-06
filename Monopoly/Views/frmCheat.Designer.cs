namespace Monopoly.Views
{
    partial class frmCheat
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
            this.tbxResultFirstDice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxResultSecDice = new System.Windows.Forms.TextBox();
            this.btnValiderDes = new System.Windows.Forms.Button();
            this.gbxValeurDes = new System.Windows.Forms.GroupBox();
            this.gbxArgentJoueurs = new System.Windows.Forms.GroupBox();
            this.rbtnEnlever = new System.Windows.Forms.RadioButton();
            this.rbtnAjouter = new System.Windows.Forms.RadioButton();
            this.lblArgentActuelJoueur = new System.Windows.Forms.Label();
            this.nudArgentJoueur = new System.Windows.Forms.NumericUpDown();
            this.btnValiderArgent = new System.Windows.Forms.Button();
            this.lblNomJoueurArgent = new System.Windows.Forms.Label();
            this.lbxArgentJoueurs = new System.Windows.Forms.ListBox();
            this.gbxProprietesJoueurs = new System.Windows.Forms.GroupBox();
            this.btnEnleverPropriete = new System.Windows.Forms.Button();
            this.btnAjouterPropriete = new System.Windows.Forms.Button();
            this.lbxProprietesDispo = new System.Windows.Forms.ListBox();
            this.lbxProprietesJoueur = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNomJoueurPropriete = new System.Windows.Forms.Label();
            this.gbxValeurDes.SuspendLayout();
            this.gbxArgentJoueurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArgentJoueur)).BeginInit();
            this.gbxProprietesJoueurs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxResultFirstDice
            // 
            this.tbxResultFirstDice.Location = new System.Drawing.Point(138, 33);
            this.tbxResultFirstDice.Name = "tbxResultFirstDice";
            this.tbxResultFirstDice.Size = new System.Drawing.Size(100, 20);
            this.tbxResultFirstDice.TabIndex = 0;
            this.tbxResultFirstDice.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result first dice :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result sec dice :";
            // 
            // tbxResultSecDice
            // 
            this.tbxResultSecDice.Location = new System.Drawing.Point(138, 59);
            this.tbxResultSecDice.Name = "tbxResultSecDice";
            this.tbxResultSecDice.Size = new System.Drawing.Size(100, 20);
            this.tbxResultSecDice.TabIndex = 2;
            this.tbxResultSecDice.Text = "0";
            // 
            // btnValiderDes
            // 
            this.btnValiderDes.Location = new System.Drawing.Point(22, 91);
            this.btnValiderDes.Name = "btnValiderDes";
            this.btnValiderDes.Size = new System.Drawing.Size(216, 23);
            this.btnValiderDes.TabIndex = 4;
            this.btnValiderDes.Text = "Valider";
            this.btnValiderDes.UseVisualStyleBackColor = true;
            this.btnValiderDes.Click += new System.EventHandler(this.btnValiderDes_Click);
            // 
            // gbxValeurDes
            // 
            this.gbxValeurDes.Controls.Add(this.label1);
            this.gbxValeurDes.Controls.Add(this.btnValiderDes);
            this.gbxValeurDes.Controls.Add(this.tbxResultFirstDice);
            this.gbxValeurDes.Controls.Add(this.label2);
            this.gbxValeurDes.Controls.Add(this.tbxResultSecDice);
            this.gbxValeurDes.Location = new System.Drawing.Point(12, 12);
            this.gbxValeurDes.Name = "gbxValeurDes";
            this.gbxValeurDes.Size = new System.Drawing.Size(331, 136);
            this.gbxValeurDes.TabIndex = 5;
            this.gbxValeurDes.TabStop = false;
            this.gbxValeurDes.Text = "Valeurs des dés";
            // 
            // gbxArgentJoueurs
            // 
            this.gbxArgentJoueurs.Controls.Add(this.rbtnEnlever);
            this.gbxArgentJoueurs.Controls.Add(this.rbtnAjouter);
            this.gbxArgentJoueurs.Controls.Add(this.lblArgentActuelJoueur);
            this.gbxArgentJoueurs.Controls.Add(this.nudArgentJoueur);
            this.gbxArgentJoueurs.Controls.Add(this.btnValiderArgent);
            this.gbxArgentJoueurs.Controls.Add(this.lblNomJoueurArgent);
            this.gbxArgentJoueurs.Location = new System.Drawing.Point(150, 154);
            this.gbxArgentJoueurs.Name = "gbxArgentJoueurs";
            this.gbxArgentJoueurs.Size = new System.Drawing.Size(193, 193);
            this.gbxArgentJoueurs.TabIndex = 6;
            this.gbxArgentJoueurs.TabStop = false;
            this.gbxArgentJoueurs.Text = "Argent joueurs";
            // 
            // rbtnEnlever
            // 
            this.rbtnEnlever.AutoSize = true;
            this.rbtnEnlever.Location = new System.Drawing.Point(85, 111);
            this.rbtnEnlever.Name = "rbtnEnlever";
            this.rbtnEnlever.Size = new System.Drawing.Size(61, 17);
            this.rbtnEnlever.TabIndex = 9;
            this.rbtnEnlever.TabStop = true;
            this.rbtnEnlever.Text = "Enlever";
            this.rbtnEnlever.UseVisualStyleBackColor = true;
            // 
            // rbtnAjouter
            // 
            this.rbtnAjouter.AutoSize = true;
            this.rbtnAjouter.Location = new System.Drawing.Point(11, 111);
            this.rbtnAjouter.Name = "rbtnAjouter";
            this.rbtnAjouter.Size = new System.Drawing.Size(58, 17);
            this.rbtnAjouter.TabIndex = 8;
            this.rbtnAjouter.TabStop = true;
            this.rbtnAjouter.Text = "Ajouter";
            this.rbtnAjouter.UseVisualStyleBackColor = true;
            // 
            // lblArgentActuelJoueur
            // 
            this.lblArgentActuelJoueur.AutoSize = true;
            this.lblArgentActuelJoueur.Location = new System.Drawing.Point(20, 41);
            this.lblArgentActuelJoueur.Name = "lblArgentActuelJoueur";
            this.lblArgentActuelJoueur.Size = new System.Drawing.Size(110, 13);
            this.lblArgentActuelJoueur.TabIndex = 7;
            this.lblArgentActuelJoueur.Text = "lblArgentActuelJoueur";
            // 
            // nudArgentJoueur
            // 
            this.nudArgentJoueur.Location = new System.Drawing.Point(22, 64);
            this.nudArgentJoueur.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudArgentJoueur.Name = "nudArgentJoueur";
            this.nudArgentJoueur.Size = new System.Drawing.Size(108, 20);
            this.nudArgentJoueur.TabIndex = 6;
            // 
            // btnValiderArgent
            // 
            this.btnValiderArgent.Location = new System.Drawing.Point(11, 158);
            this.btnValiderArgent.Name = "btnValiderArgent";
            this.btnValiderArgent.Size = new System.Drawing.Size(135, 23);
            this.btnValiderArgent.TabIndex = 5;
            this.btnValiderArgent.Text = "Valider";
            this.btnValiderArgent.UseVisualStyleBackColor = true;
            this.btnValiderArgent.Click += new System.EventHandler(this.btnValiderArgent_Click);
            // 
            // lblNomJoueurArgent
            // 
            this.lblNomJoueurArgent.AutoSize = true;
            this.lblNomJoueurArgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomJoueurArgent.Location = new System.Drawing.Point(20, 21);
            this.lblNomJoueurArgent.Name = "lblNomJoueurArgent";
            this.lblNomJoueurArgent.Size = new System.Drawing.Size(120, 13);
            this.lblNomJoueurArgent.TabIndex = 0;
            this.lblNomJoueurArgent.Text = "lblNomJoueurArgent";
            // 
            // lbxArgentJoueurs
            // 
            this.lbxArgentJoueurs.FormattingEnabled = true;
            this.lbxArgentJoueurs.Location = new System.Drawing.Point(12, 154);
            this.lbxArgentJoueurs.Name = "lbxArgentJoueurs";
            this.lbxArgentJoueurs.Size = new System.Drawing.Size(130, 186);
            this.lbxArgentJoueurs.TabIndex = 1;
            this.lbxArgentJoueurs.DoubleClick += new System.EventHandler(this.lbxArgentJoueurs_DoubleClick);
            // 
            // gbxProprietesJoueurs
            // 
            this.gbxProprietesJoueurs.Controls.Add(this.btnEnleverPropriete);
            this.gbxProprietesJoueurs.Controls.Add(this.btnAjouterPropriete);
            this.gbxProprietesJoueurs.Controls.Add(this.lbxProprietesDispo);
            this.gbxProprietesJoueurs.Controls.Add(this.lbxProprietesJoueur);
            this.gbxProprietesJoueurs.Controls.Add(this.label3);
            this.gbxProprietesJoueurs.Controls.Add(this.lblNomJoueurPropriete);
            this.gbxProprietesJoueurs.Location = new System.Drawing.Point(12, 353);
            this.gbxProprietesJoueurs.Name = "gbxProprietesJoueurs";
            this.gbxProprietesJoueurs.Size = new System.Drawing.Size(331, 178);
            this.gbxProprietesJoueurs.TabIndex = 7;
            this.gbxProprietesJoueurs.TabStop = false;
            this.gbxProprietesJoueurs.Text = "Propriétés des joueurs";
            // 
            // btnEnleverPropriete
            // 
            this.btnEnleverPropriete.Location = new System.Drawing.Point(154, 119);
            this.btnEnleverPropriete.Name = "btnEnleverPropriete";
            this.btnEnleverPropriete.Size = new System.Drawing.Size(29, 23);
            this.btnEnleverPropriete.TabIndex = 5;
            this.btnEnleverPropriete.Text = ">";
            this.btnEnleverPropriete.UseVisualStyleBackColor = true;
            this.btnEnleverPropriete.Click += new System.EventHandler(this.btnEnleverPropriete_Click);
            // 
            // btnAjouterPropriete
            // 
            this.btnAjouterPropriete.Location = new System.Drawing.Point(154, 90);
            this.btnAjouterPropriete.Name = "btnAjouterPropriete";
            this.btnAjouterPropriete.Size = new System.Drawing.Size(29, 23);
            this.btnAjouterPropriete.TabIndex = 4;
            this.btnAjouterPropriete.Text = "<";
            this.btnAjouterPropriete.UseVisualStyleBackColor = true;
            this.btnAjouterPropriete.Click += new System.EventHandler(this.btnAjouterPropriete_Click);
            // 
            // lbxProprietesDispo
            // 
            this.lbxProprietesDispo.FormattingEnabled = true;
            this.lbxProprietesDispo.Location = new System.Drawing.Point(196, 66);
            this.lbxProprietesDispo.Name = "lbxProprietesDispo";
            this.lbxProprietesDispo.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxProprietesDispo.Size = new System.Drawing.Size(120, 95);
            this.lbxProprietesDispo.TabIndex = 3;
            // 
            // lbxProprietesJoueur
            // 
            this.lbxProprietesJoueur.FormattingEnabled = true;
            this.lbxProprietesJoueur.Location = new System.Drawing.Point(21, 66);
            this.lbxProprietesJoueur.Name = "lbxProprietesJoueur";
            this.lbxProprietesJoueur.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxProprietesJoueur.Size = new System.Drawing.Size(120, 95);
            this.lbxProprietesJoueur.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Propriétés du joueur :";
            // 
            // lblNomJoueurPropriete
            // 
            this.lblNomJoueurPropriete.AutoSize = true;
            this.lblNomJoueurPropriete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomJoueurPropriete.Location = new System.Drawing.Point(18, 28);
            this.lblNomJoueurPropriete.Name = "lblNomJoueurPropriete";
            this.lblNomJoueurPropriete.Size = new System.Drawing.Size(134, 13);
            this.lblNomJoueurPropriete.TabIndex = 0;
            this.lblNomJoueurPropriete.Text = "lblNomJoueurPropriete";
            // 
            // frmCheat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 541);
            this.Controls.Add(this.gbxProprietesJoueurs);
            this.Controls.Add(this.gbxArgentJoueurs);
            this.Controls.Add(this.gbxValeurDes);
            this.Controls.Add(this.lbxArgentJoueurs);
            this.Name = "frmCheat";
            this.Text = "frmCheat";
            this.gbxValeurDes.ResumeLayout(false);
            this.gbxValeurDes.PerformLayout();
            this.gbxArgentJoueurs.ResumeLayout(false);
            this.gbxArgentJoueurs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudArgentJoueur)).EndInit();
            this.gbxProprietesJoueurs.ResumeLayout(false);
            this.gbxProprietesJoueurs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxResultFirstDice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxResultSecDice;
        private System.Windows.Forms.Button btnValiderDes;
        private System.Windows.Forms.GroupBox gbxValeurDes;
        private System.Windows.Forms.GroupBox gbxArgentJoueurs;
        private System.Windows.Forms.ListBox lbxArgentJoueurs;
        private System.Windows.Forms.Label lblNomJoueurArgent;
        private System.Windows.Forms.Button btnValiderArgent;
        private System.Windows.Forms.RadioButton rbtnEnlever;
        private System.Windows.Forms.RadioButton rbtnAjouter;
        private System.Windows.Forms.Label lblArgentActuelJoueur;
        private System.Windows.Forms.NumericUpDown nudArgentJoueur;
        private System.Windows.Forms.GroupBox gbxProprietesJoueurs;
        private System.Windows.Forms.Button btnEnleverPropriete;
        private System.Windows.Forms.Button btnAjouterPropriete;
        private System.Windows.Forms.ListBox lbxProprietesDispo;
        private System.Windows.Forms.ListBox lbxProprietesJoueur;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNomJoueurPropriete;
    }
}