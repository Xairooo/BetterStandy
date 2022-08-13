namespace BetterStandby.Views
{
    partial class Settings
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
            this.GraceTimeTextBox = new System.Windows.Forms.TextBox();
            this.IdleTimeTextBox = new System.Windows.Forms.TextBox();
            this.GraceTimeLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.idleTimeLabel = new System.Windows.Forms.Label();
            this.IgnoredWakesListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IdleTimeMaxTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GraceTimeTextBox
            // 
            this.GraceTimeTextBox.Location = new System.Drawing.Point(326, 11);
            this.GraceTimeTextBox.Name = "GraceTimeTextBox";
            this.GraceTimeTextBox.Size = new System.Drawing.Size(110, 25);
            this.GraceTimeTextBox.TabIndex = 11;
            this.GraceTimeTextBox.TextChanged += new System.EventHandler(this.GraceTimeTextBox_TextChanged);
            // 
            // IdleTimeTextBox
            // 
            this.IdleTimeTextBox.Location = new System.Drawing.Point(106, 11);
            this.IdleTimeTextBox.Name = "IdleTimeTextBox";
            this.IdleTimeTextBox.Size = new System.Drawing.Size(110, 25);
            this.IdleTimeTextBox.TabIndex = 10;
            this.IdleTimeTextBox.TextChanged += new System.EventHandler(this.IdleTimeTextBox_TextChanged);
            // 
            // GraceTimeLabel
            // 
            this.GraceTimeLabel.AutoSize = true;
            this.GraceTimeLabel.Location = new System.Drawing.Point(232, 14);
            this.GraceTimeLabel.Name = "GraceTimeLabel";
            this.GraceTimeLabel.Size = new System.Drawing.Size(71, 17);
            this.GraceTimeLabel.TabIndex = 9;
            this.GraceTimeLabel.Text = "Grace time";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(106, 280);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(83, 25);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(17, 280);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(83, 25);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // idleTimeLabel
            // 
            this.idleTimeLabel.AutoSize = true;
            this.idleTimeLabel.Location = new System.Drawing.Point(12, 14);
            this.idleTimeLabel.Name = "idleTimeLabel";
            this.idleTimeLabel.Size = new System.Drawing.Size(58, 17);
            this.idleTimeLabel.TabIndex = 6;
            this.idleTimeLabel.Text = "Idle time";
            // 
            // IgnoredWakesListBox
            // 
            this.IgnoredWakesListBox.FormattingEnabled = true;
            this.IgnoredWakesListBox.HorizontalScrollbar = true;
            this.IgnoredWakesListBox.Location = new System.Drawing.Point(12, 168);
            this.IgnoredWakesListBox.Name = "IgnoredWakesListBox";
            this.IgnoredWakesListBox.Size = new System.Drawing.Size(424, 104);
            this.IgnoredWakesListBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Ignored wake requests";
            // 
            // IdleTimeMaxTextBox
            // 
            this.IdleTimeMaxTextBox.Location = new System.Drawing.Point(106, 42);
            this.IdleTimeMaxTextBox.Name = "IdleTimeMaxTextBox";
            this.IdleTimeMaxTextBox.Size = new System.Drawing.Size(110, 25);
            this.IdleTimeMaxTextBox.TabIndex = 15;
            this.IdleTimeMaxTextBox.TextChanged += new System.EventHandler(this.IdleTimeMaxTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Idle time max";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 309);
            this.Controls.Add(this.IdleTimeMaxTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IgnoredWakesListBox);
            this.Controls.Add(this.GraceTimeTextBox);
            this.Controls.Add(this.IdleTimeTextBox);
            this.Controls.Add(this.GraceTimeLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.idleTimeLabel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(457, 350);
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox GraceTimeTextBox;
        private TextBox IdleTimeTextBox;
        private Label GraceTimeLabel;
        private Button CancelButton;
        private Button OkButton;
        private Label idleTimeLabel;
        private CheckedListBox IgnoredWakesListBox;
        private Label label1;
        private TextBox IdleTimeMaxTextBox;
        private Label label2;
    }
}