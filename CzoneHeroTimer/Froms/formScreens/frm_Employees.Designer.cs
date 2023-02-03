namespace CzoneHeroTimer.Froms.formScreens
{
    partial class frm_Employees
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvWage = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbEnroll = new System.Windows.Forms.TextBox();
            this.tbDepartment = new System.Windows.Forms.ComboBox();
            this.tbDateStart = new System.Windows.Forms.DateTimePicker();
            this.tbDateEnd = new System.Windows.Forms.DateTimePicker();
            this.tbWageDate = new System.Windows.Forms.DateTimePicker();
            this.tbWageType = new System.Windows.Forms.ComboBox();
            this.tbWage = new System.Windows.Forms.TextBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEmployees);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(396, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 425);
            this.panel1.TabIndex = 1;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 0);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowTemplate.Height = 25;
            this.dgvEmployees.Size = new System.Drawing.Size(455, 425);
            this.dgvEmployees.TabIndex = 0;
            this.dgvEmployees.Click += new System.EventHandler(this.dgvEmployees_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enroll Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "End Date";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbWage);
            this.panel2.Controls.Add(this.tbWageType);
            this.panel2.Controls.Add(this.tbWageDate);
            this.panel2.Controls.Add(this.dgvWage);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 235);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 215);
            this.panel2.TabIndex = 3;
            // 
            // dgvWage
            // 
            this.dgvWage.AllowUserToAddRows = false;
            this.dgvWage.AllowUserToDeleteRows = false;
            this.dgvWage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvWage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvWage.Location = new System.Drawing.Point(0, 91);
            this.dgvWage.Name = "dgvWage";
            this.dgvWage.ReadOnly = true;
            this.dgvWage.RowTemplate.Height = 25;
            this.dgvWage.Size = new System.Drawing.Size(396, 124);
            this.dgvWage.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(201, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(12, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "Wage";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(138, 50);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(229, 25);
            this.tbName.TabIndex = 4;
            // 
            // tbEnroll
            // 
            this.tbEnroll.Location = new System.Drawing.Point(138, 86);
            this.tbEnroll.Name = "tbEnroll";
            this.tbEnroll.Size = new System.Drawing.Size(100, 25);
            this.tbEnroll.TabIndex = 5;
            this.tbEnroll.Leave += new System.EventHandler(this.tbEnroll_Leave);
            // 
            // tbDepartment
            // 
            this.tbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbDepartment.FormattingEnabled = true;
            this.tbDepartment.Location = new System.Drawing.Point(138, 122);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(229, 26);
            this.tbDepartment.TabIndex = 6;
            // 
            // tbDateStart
            // 
            this.tbDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDateStart.Location = new System.Drawing.Point(138, 159);
            this.tbDateStart.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.tbDateStart.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.tbDateStart.Name = "tbDateStart";
            this.tbDateStart.Size = new System.Drawing.Size(118, 25);
            this.tbDateStart.TabIndex = 7;
            // 
            // tbDateEnd
            // 
            this.tbDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDateEnd.Location = new System.Drawing.Point(138, 195);
            this.tbDateEnd.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.tbDateEnd.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.tbDateEnd.Name = "tbDateEnd";
            this.tbDateEnd.Size = new System.Drawing.Size(118, 25);
            this.tbDateEnd.TabIndex = 8;
            // 
            // tbWageDate
            // 
            this.tbWageDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbWageDate.Location = new System.Drawing.Point(68, 10);
            this.tbWageDate.MaxDate = new System.DateTime(2030, 12, 31, 0, 0, 0, 0);
            this.tbWageDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.tbWageDate.Name = "tbWageDate";
            this.tbWageDate.Size = new System.Drawing.Size(118, 25);
            this.tbWageDate.TabIndex = 4;
            // 
            // tbWageType
            // 
            this.tbWageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbWageType.FormattingEnabled = true;
            this.tbWageType.Items.AddRange(new object[] {
            "Choose Type",
            "Hourly",
            "Daily",
            "Monthly"});
            this.tbWageType.Location = new System.Drawing.Point(246, 9);
            this.tbWageType.Name = "tbWageType";
            this.tbWageType.Size = new System.Drawing.Size(121, 26);
            this.tbWageType.TabIndex = 5;
            // 
            // tbWage
            // 
            this.tbWage.Location = new System.Drawing.Point(68, 45);
            this.tbWage.Name = "tbWage";
            this.tbWage.Size = new System.Drawing.Size(118, 25);
            this.tbWage.TabIndex = 6;
            this.tbWage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWage_KeyDown);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "StartDate";
            this.Column2.HeaderText = "Start Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "EmploymentType";
            this.Column3.HeaderText = "Type";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Wage";
            this.Column4.HeaderText = "Wage";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Id";
            this.Column5.HeaderText = "Id";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.DataPropertyName = "Name";
            this.Column6.HeaderText = "Name";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "EmploymentStartDate";
            this.Column7.HeaderText = "Start Date";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "EmploymentEndDate";
            this.Column8.HeaderText = "End Date";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // frm_Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 450);
            this.Controls.Add(this.tbDateEnd);
            this.Controls.Add(this.tbDateStart);
            this.Controls.Add(this.tbDepartment);
            this.Controls.Add(this.tbEnroll);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Employees";
            this.Text = "frm_Employees";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tbName, 0);
            this.Controls.SetChildIndex(this.tbEnroll, 0);
            this.Controls.SetChildIndex(this.tbDepartment, 0);
            this.Controls.SetChildIndex(this.tbDateStart, 0);
            this.Controls.SetChildIndex(this.tbDateEnd, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dgvEmployees;
        private Panel panel2;
        private DataGridView dgvWage;
        private Label label6;
        private TextBox tbWage;
        private ComboBox tbWageType;
        private DateTimePicker tbWageDate;
        private Label label8;
        private Label label7;
        private TextBox tbName;
        private TextBox tbEnroll;
        private ComboBox tbDepartment;
        private DateTimePicker tbDateStart;
        private DateTimePicker tbDateEnd;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
    }
}