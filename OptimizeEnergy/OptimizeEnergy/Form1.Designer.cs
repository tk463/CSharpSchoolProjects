namespace OptimizeEnergy
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.UsersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUser = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonForward = new System.Windows.Forms.Button();
            this.buttonSimulation = new System.Windows.Forms.Button();
            this.buttonLoadInTree = new System.Windows.Forms.Button();
            this.buttonSaveMaison = new System.Windows.Forms.Button();
            this.buttonNewHouse = new System.Windows.Forms.Button();
            this.comboBoxMaisons = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.labelErrorUser = new System.Windows.Forms.Label();
            this.radioButtonAdmin = new System.Windows.Forms.RadioButton();
            this.radioButtonOwner = new System.Windows.Forms.RadioButton();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonApplyUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxAdmin = new System.Windows.Forms.GroupBox();
            this.labelErrorPasswdAdmin = new System.Windows.Forms.Label();
            this.buttonApplyAdmin = new System.Windows.Forms.Button();
            this.textBoxAdminPasswdConfirm = new System.Windows.Forms.TextBox();
            this.textBoxAdminPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajoutNiveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renommerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consommationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSourceUserList = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceMaisonList = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelAdmin.SuspendLayout();
            this.groupBoxUser.SuspendLayout();
            this.groupBoxAdmin.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaisonList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsersMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // UsersMenuItem
            // 
            this.UsersMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connecterToolStripMenuItem,
            this.deconnecterToolStripMenuItem});
            this.UsersMenuItem.Name = "UsersMenuItem";
            this.UsersMenuItem.Size = new System.Drawing.Size(81, 20);
            this.UsersMenuItem.Text = "Connection";
            // 
            // connecterToolStripMenuItem
            // 
            this.connecterToolStripMenuItem.Name = "connecterToolStripMenuItem";
            this.connecterToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.connecterToolStripMenuItem.Text = "Connecter";
            this.connecterToolStripMenuItem.Click += new System.EventHandler(this.connecterToolStripMenuItem_Click);
            // 
            // deconnecterToolStripMenuItem
            // 
            this.deconnecterToolStripMenuItem.Name = "deconnecterToolStripMenuItem";
            this.deconnecterToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deconnecterToolStripMenuItem.Text = "Déconnecter";
            this.deconnecterToolStripMenuItem.Click += new System.EventHandler(this.deconnecterToolStripMenuItem_Click);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.treeView);
            this.panelUser.Controls.Add(this.pictureBox1);
            this.panelUser.Controls.Add(this.labelTimer);
            this.panelUser.Controls.Add(this.buttonForward);
            this.panelUser.Controls.Add(this.buttonSimulation);
            this.panelUser.Controls.Add(this.buttonLoadInTree);
            this.panelUser.Controls.Add(this.buttonSaveMaison);
            this.panelUser.Controls.Add(this.buttonNewHouse);
            this.panelUser.Controls.Add(this.comboBoxMaisons);
            this.panelUser.Controls.Add(this.label6);
            this.panelUser.Location = new System.Drawing.Point(0, 27);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(1160, 722);
            this.panelUser.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.LabelEdit = true;
            this.treeView.Location = new System.Drawing.Point(838, 60);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(303, 649);
            this.treeView.TabIndex = 9;
            this.treeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_NodeMouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(807, 649);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(1028, 26);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(28, 13);
            this.labelTimer.TabIndex = 7;
            this.labelTimer.Text = "0:00";
            // 
            // buttonForward
            // 
            this.buttonForward.Location = new System.Drawing.Point(880, 21);
            this.buttonForward.Name = "buttonForward";
            this.buttonForward.Size = new System.Drawing.Size(118, 23);
            this.buttonForward.TabIndex = 6;
            this.buttonForward.Text = "Avance rapide";
            this.buttonForward.UseVisualStyleBackColor = true;
            this.buttonForward.Click += new System.EventHandler(this.buttonForward_Click);
            // 
            // buttonSimulation
            // 
            this.buttonSimulation.Location = new System.Drawing.Point(756, 21);
            this.buttonSimulation.Name = "buttonSimulation";
            this.buttonSimulation.Size = new System.Drawing.Size(118, 23);
            this.buttonSimulation.TabIndex = 5;
            this.buttonSimulation.Text = "Simulation";
            this.buttonSimulation.UseVisualStyleBackColor = true;
            this.buttonSimulation.Click += new System.EventHandler(this.buttonSimulation_Click);
            // 
            // buttonLoadInTree
            // 
            this.buttonLoadInTree.Location = new System.Drawing.Point(541, 21);
            this.buttonLoadInTree.Name = "buttonLoadInTree";
            this.buttonLoadInTree.Size = new System.Drawing.Size(137, 23);
            this.buttonLoadInTree.TabIndex = 4;
            this.buttonLoadInTree.Text = "Charger dans l\'arbre";
            this.buttonLoadInTree.UseVisualStyleBackColor = true;
            this.buttonLoadInTree.Click += new System.EventHandler(this.buttonLoadInTree_Click);
            // 
            // buttonSaveMaison
            // 
            this.buttonSaveMaison.Location = new System.Drawing.Point(395, 21);
            this.buttonSaveMaison.Name = "buttonSaveMaison";
            this.buttonSaveMaison.Size = new System.Drawing.Size(111, 23);
            this.buttonSaveMaison.TabIndex = 3;
            this.buttonSaveMaison.Text = "Sauver maison";
            this.buttonSaveMaison.UseVisualStyleBackColor = true;
            this.buttonSaveMaison.Click += new System.EventHandler(this.buttonSaveMaison_Click);
            // 
            // buttonNewHouse
            // 
            this.buttonNewHouse.Location = new System.Drawing.Point(278, 21);
            this.buttonNewHouse.Name = "buttonNewHouse";
            this.buttonNewHouse.Size = new System.Drawing.Size(111, 23);
            this.buttonNewHouse.TabIndex = 2;
            this.buttonNewHouse.Text = "Nouvelle maison";
            this.buttonNewHouse.UseVisualStyleBackColor = true;
            this.buttonNewHouse.Click += new System.EventHandler(this.buttonNewHouse_Click);
            // 
            // comboBoxMaisons
            // 
            this.comboBoxMaisons.FormattingEnabled = true;
            this.comboBoxMaisons.Location = new System.Drawing.Point(28, 23);
            this.comboBoxMaisons.Name = "comboBoxMaisons";
            this.comboBoxMaisons.Size = new System.Drawing.Size(212, 21);
            this.comboBoxMaisons.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Maisons";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panelAdmin.Controls.Add(this.groupBoxUser);
            this.panelAdmin.Controls.Add(this.groupBoxAdmin);
            this.panelAdmin.Controls.Add(this.comboBoxUser);
            this.panelAdmin.Controls.Add(this.label1);
            this.panelAdmin.Controls.Add(this.buttonAddUser);
            this.panelAdmin.Location = new System.Drawing.Point(12, 27);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(993, 494);
            this.panelAdmin.TabIndex = 2;
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxUser.Controls.Add(this.labelErrorUser);
            this.groupBoxUser.Controls.Add(this.radioButtonAdmin);
            this.groupBoxUser.Controls.Add(this.radioButtonOwner);
            this.groupBoxUser.Controls.Add(this.buttonDelete);
            this.groupBoxUser.Controls.Add(this.buttonApplyUser);
            this.groupBoxUser.Controls.Add(this.label5);
            this.groupBoxUser.Controls.Add(this.textBoxLogin);
            this.groupBoxUser.Controls.Add(this.textBoxPassword);
            this.groupBoxUser.Controls.Add(this.label4);
            this.groupBoxUser.Location = new System.Drawing.Point(29, 142);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(463, 222);
            this.groupBoxUser.TabIndex = 4;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Change user data";
            // 
            // labelErrorUser
            // 
            this.labelErrorUser.AutoSize = true;
            this.labelErrorUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorUser.Location = new System.Drawing.Point(254, 135);
            this.labelErrorUser.Name = "labelErrorUser";
            this.labelErrorUser.Size = new System.Drawing.Size(153, 13);
            this.labelErrorUser.TabIndex = 14;
            this.labelErrorUser.Text = "Veuillez remplir tout les champs";
            this.labelErrorUser.Visible = false;
            // 
            // radioButtonAdmin
            // 
            this.radioButtonAdmin.AutoSize = true;
            this.radioButtonAdmin.Location = new System.Drawing.Point(257, 93);
            this.radioButtonAdmin.Name = "radioButtonAdmin";
            this.radioButtonAdmin.Size = new System.Drawing.Size(91, 17);
            this.radioButtonAdmin.TabIndex = 11;
            this.radioButtonAdmin.Text = "Administrateur";
            this.radioButtonAdmin.UseVisualStyleBackColor = true;
            // 
            // radioButtonOwner
            // 
            this.radioButtonOwner.Checked = true;
            this.radioButtonOwner.Location = new System.Drawing.Point(257, 63);
            this.radioButtonOwner.Name = "radioButtonOwner";
            this.radioButtonOwner.Size = new System.Drawing.Size(78, 17);
            this.radioButtonOwner.TabIndex = 10;
            this.radioButtonOwner.TabStop = true;
            this.radioButtonOwner.Text = "Propriétaire";
            this.radioButtonOwner.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(237, 168);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Effacer user";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonApplyUser
            // 
            this.buttonApplyUser.Location = new System.Drawing.Point(90, 168);
            this.buttonApplyUser.Name = "buttonApplyUser";
            this.buttonApplyUser.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyUser.TabIndex = 8;
            this.buttonApplyUser.Text = "Appliquer";
            this.buttonApplyUser.UseVisualStyleBackColor = true;
            this.buttonApplyUser.Click += new System.EventHandler(this.buttonApplyUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(25, 63);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(158, 20);
            this.textBoxLogin.TabIndex = 6;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(25, 112);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(158, 20);
            this.textBoxPassword.TabIndex = 5;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Login";
            // 
            // groupBoxAdmin
            // 
            this.groupBoxAdmin.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxAdmin.Controls.Add(this.labelErrorPasswdAdmin);
            this.groupBoxAdmin.Controls.Add(this.buttonApplyAdmin);
            this.groupBoxAdmin.Controls.Add(this.textBoxAdminPasswdConfirm);
            this.groupBoxAdmin.Controls.Add(this.textBoxAdminPasswd);
            this.groupBoxAdmin.Controls.Add(this.label3);
            this.groupBoxAdmin.Controls.Add(this.label2);
            this.groupBoxAdmin.Location = new System.Drawing.Point(637, 34);
            this.groupBoxAdmin.Name = "groupBoxAdmin";
            this.groupBoxAdmin.Size = new System.Drawing.Size(307, 208);
            this.groupBoxAdmin.TabIndex = 3;
            this.groupBoxAdmin.TabStop = false;
            this.groupBoxAdmin.Text = "Admin settings";
            // 
            // labelErrorPasswdAdmin
            // 
            this.labelErrorPasswdAdmin.AutoSize = true;
            this.labelErrorPasswdAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorPasswdAdmin.Location = new System.Drawing.Point(176, 177);
            this.labelErrorPasswdAdmin.Name = "labelErrorPasswdAdmin";
            this.labelErrorPasswdAdmin.Size = new System.Drawing.Size(55, 13);
            this.labelErrorPasswdAdmin.TabIndex = 6;
            this.labelErrorPasswdAdmin.Text = "ErrorLabel";
            this.labelErrorPasswdAdmin.Visible = false;
            // 
            // buttonApplyAdmin
            // 
            this.buttonApplyAdmin.Location = new System.Drawing.Point(25, 172);
            this.buttonApplyAdmin.Name = "buttonApplyAdmin";
            this.buttonApplyAdmin.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyAdmin.TabIndex = 4;
            this.buttonApplyAdmin.Text = "Appliquer";
            this.buttonApplyAdmin.UseVisualStyleBackColor = true;
            this.buttonApplyAdmin.Click += new System.EventHandler(this.buttonApplyAdmin_Click);
            // 
            // textBoxAdminPasswdConfirm
            // 
            this.textBoxAdminPasswdConfirm.Location = new System.Drawing.Point(25, 110);
            this.textBoxAdminPasswdConfirm.Name = "textBoxAdminPasswdConfirm";
            this.textBoxAdminPasswdConfirm.Size = new System.Drawing.Size(158, 20);
            this.textBoxAdminPasswdConfirm.TabIndex = 3;
            this.textBoxAdminPasswdConfirm.UseSystemPasswordChar = true;
            // 
            // textBoxAdminPasswd
            // 
            this.textBoxAdminPasswd.Location = new System.Drawing.Point(25, 61);
            this.textBoxAdminPasswd.Name = "textBoxAdminPasswd";
            this.textBoxAdminPasswd.Size = new System.Drawing.Size(158, 20);
            this.textBoxAdminPasswd.TabIndex = 2;
            this.textBoxAdminPasswd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Confirm password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Admin password";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(29, 95);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(463, 21);
            this.comboBoxUser.TabIndex = 2;
            this.comboBoxUser.SelectedIndexChanged += new System.EventHandler(this.comboBoxUser_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "User list";
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(29, 34);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(75, 23);
            this.buttonAddUser.TabIndex = 0;
            this.buttonAddUser.Text = "Add User";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajoutNiveauToolStripMenuItem,
            this.renommerToolStripMenuItem,
            this.consommationToolStripMenuItem,
            this.selectImageToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(158, 92);
            // 
            // ajoutNiveauToolStripMenuItem
            // 
            this.ajoutNiveauToolStripMenuItem.Name = "ajoutNiveauToolStripMenuItem";
            this.ajoutNiveauToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.ajoutNiveauToolStripMenuItem.Text = "Ajout niveau";
            this.ajoutNiveauToolStripMenuItem.Click += new System.EventHandler(this.ajoutNiveauToolStripMenuItem_Click);
            // 
            // renommerToolStripMenuItem
            // 
            this.renommerToolStripMenuItem.Name = "renommerToolStripMenuItem";
            this.renommerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.renommerToolStripMenuItem.Text = "Renommer";
            this.renommerToolStripMenuItem.Click += new System.EventHandler(this.renommerToolStripMenuItem_Click);
            // 
            // consommationToolStripMenuItem
            // 
            this.consommationToolStripMenuItem.Name = "consommationToolStripMenuItem";
            this.consommationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.consommationToolStripMenuItem.Text = "Consommation";
            this.consommationToolStripMenuItem.Click += new System.EventHandler(this.consommationToolStripMenuItem_Click);
            // 
            // selectImageToolStripMenuItem
            // 
            this.selectImageToolStripMenuItem.Name = "selectImageToolStripMenuItem";
            this.selectImageToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.selectImageToolStripMenuItem.Text = "Select image";
            this.selectImageToolStripMenuItem.Click += new System.EventHandler(this.selectImageToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelUser);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Optimize Energy Consumption";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.groupBoxAdmin.ResumeLayout(false);
            this.groupBoxAdmin.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMaisonList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem UsersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connecterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deconnecterToolStripMenuItem;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.BindingSource bindingSourceUserList;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.GroupBox groupBoxAdmin;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Label labelErrorPasswdAdmin;
        private System.Windows.Forms.Button buttonApplyAdmin;
        private System.Windows.Forms.TextBox textBoxAdminPasswdConfirm;
        private System.Windows.Forms.TextBox textBoxAdminPasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Label labelErrorUser;
        private System.Windows.Forms.RadioButton radioButtonAdmin;
        private System.Windows.Forms.RadioButton radioButtonOwner;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonApplyUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button buttonForward;
        private System.Windows.Forms.Button buttonSimulation;
        private System.Windows.Forms.Button buttonLoadInTree;
        private System.Windows.Forms.Button buttonSaveMaison;
        private System.Windows.Forms.Button buttonNewHouse;
        private System.Windows.Forms.ComboBox comboBoxMaisons;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bindingSourceMaisonList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ajoutNiveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renommerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consommationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectImageToolStripMenuItem;
    }
}

