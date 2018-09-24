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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gameView = new Monopoly.Views.GameView();
            this.tlpSidebar = new System.Windows.Forms.TableLayoutPanel();
            this.border = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNextPlayer = new System.Windows.Forms.Button();
            this.btnExchange = new System.Windows.Forms.Button();
            this.btnDice = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabCaseDes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxDe1 = new System.Windows.Forms.PictureBox();
            this.pbxDe2 = new System.Windows.Forms.PictureBox();
            this.btnLancerDes = new System.Windows.Forms.Button();
            this.tabCasePropSimple = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAcheterPropriete = new System.Windows.Forms.Button();
            this.lblCasePropSimplePrixAchat = new System.Windows.Forms.Label();
            this.pbxCasePropSimple = new System.Windows.Forms.PictureBox();
            this.tabCasePropAchetee = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCasePropAchetee = new System.Windows.Forms.Label();
            this.pbxCasePropAchetee = new System.Windows.Forms.PictureBox();
            this.pbxCasePropAcheteeImage = new System.Windows.Forms.PictureBox();
            this.tabCaseChanceChancel = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaseChanceChancelTitre = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCouleur = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCaseChanceChancel = new System.Windows.Forms.Label();
            this.pbxCaseChanceImage = new System.Windows.Forms.PictureBox();
            this.tabCaseTaxe = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaseTaxeTitre = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.pbxCaseTaxeCarte = new System.Windows.Forms.PictureBox();
            this.tabCaseCoin = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCaseCoin = new System.Windows.Forms.Label();
            this.pbxCaseCoin = new System.Windows.Forms.PictureBox();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.flpProperties = new System.Windows.Forms.FlowLayoutPanel();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tmrDiceAnimation = new System.Windows.Forms.Timer(this.components);
            this.tmrDice = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpSidebar.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabs.SuspendLayout();
            this.tabCaseDes.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDe1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDe2)).BeginInit();
            this.tabCasePropSimple.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropSimple)).BeginInit();
            this.tabCasePropAchetee.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropAchetee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropAcheteeImage)).BeginInit();
            this.tabCaseChanceChancel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseChanceImage)).BeginInit();
            this.tabCaseTaxe.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseTaxeCarte)).BeginInit();
            this.tabCaseCoin.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseCoin)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.tlpSidebar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 890);
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
            this.gameView.Size = new System.Drawing.Size(724, 890);
            this.gameView.TabIndex = 0;
            // 
            // tlpSidebar
            // 
            this.tlpSidebar.BackColor = System.Drawing.Color.Silver;
            this.tlpSidebar.ColumnCount = 1;
            this.tlpSidebar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.Controls.Add(this.border, 0, 1);
            this.tlpSidebar.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tlpSidebar.Controls.Add(this.tabs, 0, 0);
            this.tlpSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSidebar.Location = new System.Drawing.Point(724, 0);
            this.tlpSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSidebar.Name = "tlpSidebar";
            this.tlpSidebar.RowCount = 3;
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpSidebar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tlpSidebar.Size = new System.Drawing.Size(300, 890);
            this.tlpSidebar.TabIndex = 1;
            // 
            // border
            // 
            this.border.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.border.Dock = System.Windows.Forms.DockStyle.Fill;
            this.border.Location = new System.Drawing.Point(0, 780);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 785);
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
            this.btnNextPlayer.Click += new System.EventHandler(this.btnNextPlayer_Click);
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
            this.tabs.Controls.Add(this.tabCaseDes);
            this.tabs.Controls.Add(this.tabCasePropSimple);
            this.tabs.Controls.Add(this.tabCasePropAchetee);
            this.tabs.Controls.Add(this.tabCaseChanceChancel);
            this.tabs.Controls.Add(this.tabCaseTaxe);
            this.tabs.Controls.Add(this.tabCaseCoin);
            this.tabs.Controls.Add(this.tabProperties);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs.Location = new System.Drawing.Point(10, 10);
            this.tabs.Margin = new System.Windows.Forms.Padding(10);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(280, 760);
            this.tabs.TabIndex = 3;
            // 
            // tabCaseDes
            // 
            this.tabCaseDes.Controls.Add(this.tableLayoutPanel2);
            this.tabCaseDes.Location = new System.Drawing.Point(4, 27);
            this.tabCaseDes.Name = "tabCaseDes";
            this.tabCaseDes.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaseDes.Size = new System.Drawing.Size(272, 729);
            this.tabCaseDes.TabIndex = 0;
            this.tabCaseDes.Text = "Lancer les dés";
            this.tabCaseDes.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnLancerDes, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 212);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(260, 297);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pbxDe1);
            this.flowLayoutPanel1.Controls.Add(this.pbxDe2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(254, 142);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // pbxDe1
            // 
            this.pbxDe1.BackgroundImage = global::Monopoly.Properties.Resources.de1;
            this.pbxDe1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxDe1.Location = new System.Drawing.Point(43, 3);
            this.pbxDe1.Margin = new System.Windows.Forms.Padding(43, 3, 10, 3);
            this.pbxDe1.Name = "pbxDe1";
            this.pbxDe1.Size = new System.Drawing.Size(79, 79);
            this.pbxDe1.TabIndex = 0;
            this.pbxDe1.TabStop = false;
            // 
            // pbxDe2
            // 
            this.pbxDe2.BackgroundImage = global::Monopoly.Properties.Resources.de2;
            this.pbxDe2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxDe2.Location = new System.Drawing.Point(135, 3);
            this.pbxDe2.Name = "pbxDe2";
            this.pbxDe2.Size = new System.Drawing.Size(79, 79);
            this.pbxDe2.TabIndex = 1;
            this.pbxDe2.TabStop = false;
            // 
            // btnLancerDes
            // 
            this.btnLancerDes.Location = new System.Drawing.Point(45, 158);
            this.btnLancerDes.Margin = new System.Windows.Forms.Padding(45, 10, 3, 3);
            this.btnLancerDes.Name = "btnLancerDes";
            this.btnLancerDes.Size = new System.Drawing.Size(173, 36);
            this.btnLancerDes.TabIndex = 1;
            this.btnLancerDes.Text = "Lancer les dés !";
            this.btnLancerDes.UseVisualStyleBackColor = true;
            this.btnLancerDes.Click += new System.EventHandler(this.btnLancerDes_Click);
            // 
            // tabCasePropSimple
            // 
            this.tabCasePropSimple.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabCasePropSimple.Controls.Add(this.tableLayoutPanel5);
            this.tabCasePropSimple.Location = new System.Drawing.Point(4, 27);
            this.tabCasePropSimple.Name = "tabCasePropSimple";
            this.tabCasePropSimple.Padding = new System.Windows.Forms.Padding(3);
            this.tabCasePropSimple.Size = new System.Drawing.Size(272, 729);
            this.tabCasePropSimple.TabIndex = 2;
            this.tabCasePropSimple.Text = "Acheter une case";
            this.tabCasePropSimple.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.btnAcheterPropriete, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblCasePropSimplePrixAchat, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.pbxCasePropSimple, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.60305F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.0458F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.35115F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btnAcheterPropriete
            // 
            this.btnAcheterPropriete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAcheterPropriete.Location = new System.Drawing.Point(33, 527);
            this.btnAcheterPropriete.Margin = new System.Windows.Forms.Padding(33, 3, 35, 3);
            this.btnAcheterPropriete.Name = "btnAcheterPropriete";
            this.btnAcheterPropriete.Size = new System.Drawing.Size(198, 67);
            this.btnAcheterPropriete.TabIndex = 2;
            this.btnAcheterPropriete.Text = "Acheter propriété";
            this.btnAcheterPropriete.UseVisualStyleBackColor = true;
            this.btnAcheterPropriete.Click += new System.EventHandler(this.btnAcheterPropriete_Click);
            // 
            // lblCasePropSimplePrixAchat
            // 
            this.lblCasePropSimplePrixAchat.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCasePropSimplePrixAchat.Location = new System.Drawing.Point(10, 354);
            this.lblCasePropSimplePrixAchat.Margin = new System.Windows.Forms.Padding(10);
            this.lblCasePropSimplePrixAchat.Name = "lblCasePropSimplePrixAchat";
            this.lblCasePropSimplePrixAchat.Size = new System.Drawing.Size(246, 56);
            this.lblCasePropSimplePrixAchat.TabIndex = 1;
            this.lblCasePropSimplePrixAchat.Text = "Prix d\'achat : \r\n000 F";
            this.lblCasePropSimplePrixAchat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxCasePropSimple
            // 
            this.pbxCasePropSimple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxCasePropSimple.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbxCasePropSimple.Location = new System.Drawing.Point(63, 127);
            this.pbxCasePropSimple.Margin = new System.Windows.Forms.Padding(63, 40, 63, 7);
            this.pbxCasePropSimple.Name = "pbxCasePropSimple";
            this.pbxCasePropSimple.Size = new System.Drawing.Size(140, 210);
            this.pbxCasePropSimple.TabIndex = 0;
            this.pbxCasePropSimple.TabStop = false;
            // 
            // tabCasePropAchetee
            // 
            this.tabCasePropAchetee.Controls.Add(this.tableLayoutPanel6);
            this.tabCasePropAchetee.Location = new System.Drawing.Point(4, 27);
            this.tabCasePropAchetee.Name = "tabCasePropAchetee";
            this.tabCasePropAchetee.Padding = new System.Windows.Forms.Padding(3);
            this.tabCasePropAchetee.Size = new System.Drawing.Size(272, 729);
            this.tabCasePropAchetee.TabIndex = 3;
            this.tabCasePropAchetee.Text = "Ma case";
            this.tabCasePropAchetee.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.lblCasePropAchetee, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.pbxCasePropAchetee, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.pbxCasePropAcheteeImage, 0, 3);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.944445F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.41667F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.71462F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 290F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // lblCasePropAchetee
            // 
            this.lblCasePropAchetee.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCasePropAchetee.Location = new System.Drawing.Point(10, 301);
            this.lblCasePropAchetee.Margin = new System.Windows.Forms.Padding(10);
            this.lblCasePropAchetee.Name = "lblCasePropAchetee";
            this.lblCasePropAchetee.Size = new System.Drawing.Size(246, 93);
            this.lblCasePropAchetee.TabIndex = 1;
            this.lblCasePropAchetee.Text = "Bienvenue chez vous!!\r\nou\r\nVous êtes chez Player1 : \r\nVous payez 000 F de loyer";
            this.lblCasePropAchetee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxCasePropAchetee
            // 
            this.pbxCasePropAchetee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxCasePropAchetee.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbxCasePropAchetee.Location = new System.Drawing.Point(63, 74);
            this.pbxCasePropAchetee.Margin = new System.Windows.Forms.Padding(63, 40, 63, 7);
            this.pbxCasePropAchetee.Name = "pbxCasePropAchetee";
            this.pbxCasePropAchetee.Size = new System.Drawing.Size(140, 210);
            this.pbxCasePropAchetee.TabIndex = 0;
            this.pbxCasePropAchetee.TabStop = false;
            // 
            // pbxCasePropAcheteeImage
            // 
            this.pbxCasePropAcheteeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxCasePropAcheteeImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxCasePropAcheteeImage.Location = new System.Drawing.Point(33, 442);
            this.pbxCasePropAcheteeImage.Margin = new System.Windows.Forms.Padding(33, 10, 35, 3);
            this.pbxCasePropAcheteeImage.Name = "pbxCasePropAcheteeImage";
            this.pbxCasePropAcheteeImage.Size = new System.Drawing.Size(198, 214);
            this.pbxCasePropAcheteeImage.TabIndex = 2;
            this.pbxCasePropAcheteeImage.TabStop = false;
            // 
            // tabCaseChanceChancel
            // 
            this.tabCaseChanceChancel.Controls.Add(this.tableLayoutPanel7);
            this.tabCaseChanceChancel.Location = new System.Drawing.Point(4, 27);
            this.tabCaseChanceChancel.Name = "tabCaseChanceChancel";
            this.tabCaseChanceChancel.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaseChanceChancel.Size = new System.Drawing.Size(272, 729);
            this.tabCaseChanceChancel.TabIndex = 4;
            this.tabCaseChanceChancel.Text = "Carte";
            this.tabCaseChanceChancel.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.lblCaseChanceChancelTitre, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.pbxCaseChanceImage, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.36743F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.63258F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // lblCaseChanceChancelTitre
            // 
            this.lblCaseChanceChancelTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaseChanceChancelTitre.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseChanceChancelTitre.ForeColor = System.Drawing.Color.Black;
            this.lblCaseChanceChancelTitre.Location = new System.Drawing.Point(3, 30);
            this.lblCaseChanceChancelTitre.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.lblCaseChanceChancelTitre.Name = "lblCaseChanceChancelTitre";
            this.lblCaseChanceChancelTitre.Size = new System.Drawing.Size(260, 84);
            this.lblCaseChanceChancelTitre.TabIndex = 0;
            this.lblCaseChanceChancelTitre.Text = "Chance/Chancellerie";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.flpCouleur);
            this.flowLayoutPanel2.Controls.Add(this.lblCaseChanceChancel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 117);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(260, 282);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // flpCouleur
            // 
            this.flpCouleur.BackColor = System.Drawing.Color.Green;
            this.flpCouleur.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpCouleur.Location = new System.Drawing.Point(3, 3);
            this.flpCouleur.Name = "flpCouleur";
            this.flpCouleur.Size = new System.Drawing.Size(260, 16);
            this.flpCouleur.TabIndex = 2;
            // 
            // lblCaseChanceChancel
            // 
            this.lblCaseChanceChancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaseChanceChancel.Location = new System.Drawing.Point(3, 22);
            this.lblCaseChanceChancel.Name = "lblCaseChanceChancel";
            this.lblCaseChanceChancel.Size = new System.Drawing.Size(254, 217);
            this.lblCaseChanceChancel.TabIndex = 3;
            this.lblCaseChanceChancel.Text = "Visite chez le Spatio-Dentiste : \r\nVous payez 000 F";
            this.lblCaseChanceChancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxCaseChanceImage
            // 
            this.pbxCaseChanceImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxCaseChanceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCaseChanceImage.Location = new System.Drawing.Point(30, 432);
            this.pbxCaseChanceImage.Margin = new System.Windows.Forms.Padding(30, 30, 30, 50);
            this.pbxCaseChanceImage.Name = "pbxCaseChanceImage";
            this.pbxCaseChanceImage.Size = new System.Drawing.Size(206, 241);
            this.pbxCaseChanceImage.TabIndex = 2;
            this.pbxCaseChanceImage.TabStop = false;
            // 
            // tabCaseTaxe
            // 
            this.tabCaseTaxe.Controls.Add(this.tableLayoutPanel8);
            this.tabCaseTaxe.Location = new System.Drawing.Point(4, 27);
            this.tabCaseTaxe.Name = "tabCaseTaxe";
            this.tabCaseTaxe.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaseTaxe.Size = new System.Drawing.Size(272, 729);
            this.tabCaseTaxe.TabIndex = 5;
            this.tabCaseTaxe.Text = "Taxe";
            this.tabCaseTaxe.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.lblCaseTaxeTitre, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.flowLayoutPanel4, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.78723F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.21277F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // lblCaseTaxeTitre
            // 
            this.lblCaseTaxeTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaseTaxeTitre.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaseTaxeTitre.ForeColor = System.Drawing.Color.Black;
            this.lblCaseTaxeTitre.Location = new System.Drawing.Point(3, 30);
            this.lblCaseTaxeTitre.Margin = new System.Windows.Forms.Padding(3, 30, 3, 0);
            this.lblCaseTaxeTitre.Name = "lblCaseTaxeTitre";
            this.lblCaseTaxeTitre.Size = new System.Drawing.Size(260, 138);
            this.lblCaseTaxeTitre.TabIndex = 0;
            this.lblCaseTaxeTitre.Text = "Taxe";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel4.Controls.Add(this.pbxCaseTaxeCarte);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 171);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(260, 390);
            this.flowLayoutPanel4.TabIndex = 1;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.BackColor = System.Drawing.Color.Gold;
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(260, 16);
            this.flowLayoutPanel5.TabIndex = 2;
            // 
            // pbxCaseTaxeCarte
            // 
            this.pbxCaseTaxeCarte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxCaseTaxeCarte.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbxCaseTaxeCarte.Location = new System.Drawing.Point(62, 102);
            this.pbxCaseTaxeCarte.Margin = new System.Windows.Forms.Padding(62, 80, 64, 7);
            this.pbxCaseTaxeCarte.Name = "pbxCaseTaxeCarte";
            this.pbxCaseTaxeCarte.Size = new System.Drawing.Size(140, 210);
            this.pbxCaseTaxeCarte.TabIndex = 3;
            this.pbxCaseTaxeCarte.TabStop = false;
            // 
            // tabCaseCoin
            // 
            this.tabCaseCoin.Controls.Add(this.tableLayoutPanel9);
            this.tabCaseCoin.Location = new System.Drawing.Point(4, 27);
            this.tabCaseCoin.Name = "tabCaseCoin";
            this.tabCaseCoin.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaseCoin.Size = new System.Drawing.Size(272, 729);
            this.tabCaseCoin.TabIndex = 6;
            this.tabCaseCoin.Text = "Inactive";
            this.tabCaseCoin.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.lblCaseCoin, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.pbxCaseCoin, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.26241F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.73759F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 158F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(266, 723);
            this.tableLayoutPanel9.TabIndex = 2;
            // 
            // lblCaseCoin
            // 
            this.lblCaseCoin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaseCoin.Location = new System.Drawing.Point(3, 385);
            this.lblCaseCoin.Name = "lblCaseCoin";
            this.lblCaseCoin.Size = new System.Drawing.Size(260, 179);
            this.lblCaseCoin.TabIndex = 4;
            this.lblCaseCoin.Text = "Pause Temporel/Start/Parloir/GoPrison\r\nSi CaseStart vous gagnez 000 F";
            this.lblCaseCoin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbxCaseCoin
            // 
            this.pbxCaseCoin.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxCaseCoin.Location = new System.Drawing.Point(23, 30);
            this.pbxCaseCoin.Margin = new System.Windows.Forms.Padding(23, 30, 23, 0);
            this.pbxCaseCoin.Name = "pbxCaseCoin";
            this.pbxCaseCoin.Size = new System.Drawing.Size(220, 330);
            this.pbxCaseCoin.TabIndex = 3;
            this.pbxCaseCoin.TabStop = false;
            // 
            // tabProperties
            // 
            this.tabProperties.AutoScroll = true;
            this.tabProperties.Controls.Add(this.flpProperties);
            this.tabProperties.Location = new System.Drawing.Point(4, 27);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(272, 729);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "Propriétés";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // flpProperties
            // 
            this.flpProperties.AutoScroll = true;
            this.flpProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProperties.Location = new System.Drawing.Point(3, 3);
            this.flpProperties.Name = "flpProperties";
            this.flpProperties.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.flpProperties.Size = new System.Drawing.Size(266, 723);
            this.flpProperties.TabIndex = 1;
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Enabled = true;
            this.tmrRefresh.Interval = 16;
            this.tmrRefresh.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // tmrDiceAnimation
            // 
            this.tmrDiceAnimation.Interval = 10;
            this.tmrDiceAnimation.Tick += new System.EventHandler(this.tmrLancerDes_Tick);
            // 
            // tmrDice
            // 
            this.tmrDice.Interval = 2000;
            this.tmrDice.Tick += new System.EventHandler(this.tmrDice_Tick);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 890);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmGame";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monopoly";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpSidebar.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.tabCaseDes.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDe1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDe2)).EndInit();
            this.tabCasePropSimple.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropSimple)).EndInit();
            this.tabCasePropAchetee.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropAchetee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCasePropAcheteeImage)).EndInit();
            this.tabCaseChanceChancel.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseChanceImage)).EndInit();
            this.tabCaseTaxe.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseTaxeCarte)).EndInit();
            this.tabCaseCoin.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCaseCoin)).EndInit();
            this.tabProperties.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GameView gameView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tlpSidebar;
        private System.Windows.Forms.Label border;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnNextPlayer;
        private System.Windows.Forms.Button btnExchange;
        private System.Windows.Forms.Button btnDice;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabCaseDes;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.FlowLayoutPanel flpProperties;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.TabPage tabCasePropSimple;
        private System.Windows.Forms.TabPage tabCasePropAchetee;
        private System.Windows.Forms.TabPage tabCaseChanceChancel;
        private System.Windows.Forms.TabPage tabCaseTaxe;
        private System.Windows.Forms.TabPage tabCaseCoin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pbxDe1;
        private System.Windows.Forms.PictureBox pbxDe2;
        private System.Windows.Forms.Button btnLancerDes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.PictureBox pbxCasePropSimple;
        private System.Windows.Forms.Label lblCasePropSimplePrixAchat;
        private System.Windows.Forms.Button btnAcheterPropriete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblCasePropAchetee;
        private System.Windows.Forms.PictureBox pbxCasePropAchetee;
        private System.Windows.Forms.PictureBox pbxCasePropAcheteeImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblCaseChanceChancelTitre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flpCouleur;
        private System.Windows.Forms.Label lblCaseChanceChancel;
        private System.Windows.Forms.PictureBox pbxCaseChanceImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblCaseTaxeTitre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.PictureBox pbxCaseTaxeCarte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label lblCaseCoin;
        private System.Windows.Forms.Timer tmrDiceAnimation;
        private System.Windows.Forms.Timer tmrDice;
        private System.Windows.Forms.PictureBox pbxCaseCoin;
    }
}

