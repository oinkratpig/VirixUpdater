namespace VirixUpdater
{
    partial class FormInstalling
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
            progressBar1 = new ProgressBar();
            label1 = new Label();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 54);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(230, 25);
            progressBar1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(66, 13);
            label1.Name = "label1";
            label1.Size = new Size(124, 33);
            label1.TabIndex = 1;
            label1.Text = "Updating";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Roboto", 8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 88);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Both;
            textBox1.Size = new Size(230, 82);
            textBox1.TabIndex = 2;
            textBox1.WordWrap = false;
            // 
            // FormInstalling
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(56, 66, 123);
            ClientSize = new Size(254, 182);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Font = new Font("Roboto", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormInstalling";
            Text = "Updating Modpack";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBar1;
        private Label label1;
        private TextBox textBox1;
    }
}