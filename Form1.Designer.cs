namespace VirixUpdater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            label2 = new Label();
            textBoxCurrentVersion = new TextBox();
            label3 = new Label();
            textBoxLatestVersion = new TextBox();
            buttonUpdate = new Button();
            textBoxModsFolder = new TextBox();
            label4 = new Label();
            buttonBrowse = new Button();
            labelMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.VirixLarge;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(55, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.WhiteSmoke;
            label2.Location = new Point(50, 227);
            label2.Name = "label2";
            label2.Size = new Size(91, 14);
            label2.TabIndex = 3;
            label2.Text = "Current Version";
            // 
            // textBoxCurrentVersion
            // 
            textBoxCurrentVersion.BackColor = SystemColors.Control;
            textBoxCurrentVersion.Enabled = false;
            textBoxCurrentVersion.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCurrentVersion.ForeColor = Color.FromArgb(35, 35, 52);
            textBoxCurrentVersion.Location = new Point(147, 222);
            textBoxCurrentVersion.Name = "textBoxCurrentVersion";
            textBoxCurrentVersion.ReadOnly = true;
            textBoxCurrentVersion.Size = new Size(106, 23);
            textBoxCurrentVersion.TabIndex = 4;
            textBoxCurrentVersion.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(50, 256);
            label3.Name = "label3";
            label3.Size = new Size(84, 14);
            label3.TabIndex = 5;
            label3.Text = "Latest Version";
            // 
            // textBoxLatestVersion
            // 
            textBoxLatestVersion.BackColor = SystemColors.Control;
            textBoxLatestVersion.Enabled = false;
            textBoxLatestVersion.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxLatestVersion.ForeColor = Color.FromArgb(35, 35, 52);
            textBoxLatestVersion.Location = new Point(147, 251);
            textBoxLatestVersion.Name = "textBoxLatestVersion";
            textBoxLatestVersion.ReadOnly = true;
            textBoxLatestVersion.Size = new Size(106, 23);
            textBoxLatestVersion.TabIndex = 6;
            textBoxLatestVersion.TextAlign = HorizontalAlignment.Right;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Enabled = false;
            buttonUpdate.Font = new Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonUpdate.ForeColor = Color.FromArgb(35, 35, 52);
            buttonUpdate.Location = new Point(53, 310);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(200, 26);
            buttonUpdate.TabIndex = 7;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // textBoxModsFolder
            // 
            textBoxModsFolder.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxModsFolder.ForeColor = Color.FromArgb(35, 35, 52);
            textBoxModsFolder.Location = new Point(97, 280);
            textBoxModsFolder.Name = "textBoxModsFolder";
            textBoxModsFolder.ReadOnly = true;
            textBoxModsFolder.Size = new Size(123, 23);
            textBoxModsFolder.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(17, 285);
            label4.Name = "label4";
            label4.Size = new Size(74, 14);
            label4.TabIndex = 8;
            label4.Text = "Mods Folder";
            // 
            // buttonBrowse
            // 
            buttonBrowse.ForeColor = Color.FromArgb(35, 35, 52);
            buttonBrowse.Location = new Point(226, 279);
            buttonBrowse.Name = "buttonBrowse";
            buttonBrowse.Size = new Size(68, 25);
            buttonBrowse.TabIndex = 10;
            buttonBrowse.Text = "Browse";
            buttonBrowse.UseVisualStyleBackColor = true;
            buttonBrowse.Click += buttonBrowse_Click;
            // 
            // labelMessage
            // 
            labelMessage.Font = new Font("Roboto", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelMessage.ForeColor = Color.WhiteSmoke;
            labelMessage.Location = new Point(1, 348);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(312, 23);
            labelMessage.TabIndex = 11;
            labelMessage.Text = "Unknown version.";
            labelMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 66, 123);
            ClientSize = new Size(314, 387);
            Controls.Add(labelMessage);
            Controls.Add(buttonBrowse);
            Controls.Add(textBoxModsFolder);
            Controls.Add(label4);
            Controls.Add(buttonUpdate);
            Controls.Add(textBoxLatestVersion);
            Controls.Add(label3);
            Controls.Add(textBoxCurrentVersion);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Virix Modpack Updater";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private TextBox textBoxCurrentVersion;
        private Label label3;
        private TextBox textBoxLatestVersion;
        private Button buttonUpdate;
        private TextBox textBoxModsFolder;
        private Label label4;
        private Button buttonBrowse;
        private Label labelMessage;
    }
}