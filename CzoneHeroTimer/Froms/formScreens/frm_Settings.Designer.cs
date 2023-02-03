namespace CzoneHeroTimer.Froms.formScreens
{
    partial class frm_Settings
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
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNormalHours = new System.Windows.Forms.TextBox();
            this.tbBreak = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbDatabase
            // 
            this.tbDatabase.Enabled = false;
            this.tbDatabase.Location = new System.Drawing.Point(28, 42);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.PlaceholderText = "Choose Database Folder";
            this.tbDatabase.Size = new System.Drawing.Size(231, 25);
            this.tbDatabase.TabIndex = 1;
            // 
            // btnFolder
            // 
            this.btnFolder.Location = new System.Drawing.Point(265, 42);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(37, 25);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "...";
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Break Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Normal Working Hours";
            // 
            // tbNormalHours
            // 
            this.tbNormalHours.Location = new System.Drawing.Point(181, 106);
            this.tbNormalHours.Name = "tbNormalHours";
            this.tbNormalHours.Size = new System.Drawing.Size(121, 25);
            this.tbNormalHours.TabIndex = 4;
            // 
            // tbBreak
            // 
            this.tbBreak.Location = new System.Drawing.Point(181, 137);
            this.tbBreak.Name = "tbBreak";
            this.tbBreak.Size = new System.Drawing.Size(121, 25);
            this.tbBreak.TabIndex = 5;
            // 
            // frm_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 190);
            this.Controls.Add(this.tbBreak);
            this.Controls.Add(this.tbNormalHours);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.tbDatabase);
            this.Name = "frm_Settings";
            this.Text = "frm_Settings";
            this.Controls.SetChildIndex(this.tbDatabase, 0);
            this.Controls.SetChildIndex(this.btnFolder, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbNormalHours, 0);
            this.Controls.SetChildIndex(this.tbBreak, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbDatabase;
        private Button btnFolder;
        private Label label1;
        private Label label2;
        private TextBox tbNormalHours;
        private TextBox tbBreak;
    }
}