namespace DessineMoi
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
            this.comboBoxSelectShape = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBoxActiveCplxShapes = new System.Windows.Forms.ComboBox();
            this.comboBoxActiveShapes = new System.Windows.Forms.ComboBox();
            this.bindingSourceActShapes = new System.Windows.Forms.BindingSource(this.components);
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.bindingSourceComplexShapeList = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateCplxShape = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActShapes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComplexShapeList)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelectShape
            // 
            this.comboBoxSelectShape.FormattingEnabled = true;
            this.comboBoxSelectShape.Location = new System.Drawing.Point(13, 104);
            this.comboBoxSelectShape.Name = "comboBoxSelectShape";
            this.comboBoxSelectShape.Size = new System.Drawing.Size(212, 21);
            this.comboBoxSelectShape.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Couleur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(38, 260);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(282, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(890, 537);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(136, 83);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Rempli";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // comboBoxActiveCplxShapes
            // 
            this.comboBoxActiveCplxShapes.FormattingEnabled = true;
            this.comboBoxActiveCplxShapes.Location = new System.Drawing.Point(13, 233);
            this.comboBoxActiveCplxShapes.Name = "comboBoxActiveCplxShapes";
            this.comboBoxActiveCplxShapes.Size = new System.Drawing.Size(212, 21);
            this.comboBoxActiveCplxShapes.TabIndex = 5;
            // 
            // comboBoxActiveShapes
            // 
            this.comboBoxActiveShapes.FormattingEnabled = true;
            this.comboBoxActiveShapes.Location = new System.Drawing.Point(13, 132);
            this.comboBoxActiveShapes.Name = "comboBoxActiveShapes";
            this.comboBoxActiveShapes.Size = new System.Drawing.Size(212, 21);
            this.comboBoxActiveShapes.TabIndex = 6;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(119, 159);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 7;
            this.buttonRefresh.Text = "Clear";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(119, 260);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(38, 77);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile.TabIndex = 9;
            this.buttonOpenFile.Text = "SelectImage";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonCreateCplxShape
            // 
            this.buttonCreateCplxShape.Location = new System.Drawing.Point(79, 204);
            this.buttonCreateCplxShape.Name = "buttonCreateCplxShape";
            this.buttonCreateCplxShape.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateCplxShape.TabIndex = 10;
            this.buttonCreateCplxShape.Text = "New Complex Shape";
            this.buttonCreateCplxShape.UseVisualStyleBackColor = true;
            this.buttonCreateCplxShape.Click += new System.EventHandler(this.buttonCreateCplxShape_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.buttonCreateCplxShape);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.comboBoxActiveShapes);
            this.Controls.Add(this.comboBoxActiveCplxShapes);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxSelectShape);
            this.Name = "Form1";
            this.Text = "DrawMe";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActShapes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceComplexShapeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSelectShape;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBoxActiveCplxShapes;
        private System.Windows.Forms.ComboBox comboBoxActiveShapes;
        private System.Windows.Forms.BindingSource bindingSourceActShapes;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.BindingSource bindingSourceComplexShapeList;
        private System.Windows.Forms.Button buttonCreateCplxShape;
    }
}

