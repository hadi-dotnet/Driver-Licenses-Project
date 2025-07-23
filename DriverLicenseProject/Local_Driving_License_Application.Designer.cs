namespace DriverLicenseProject
{
    partial class Local_Driving_License_Application
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
            this.components = new System.ComponentModel.Container();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.comfilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ClmAppID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNationalNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApllicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SechduleTest = new System.Windows.Forms.ToolStripMenuItem();
            this.VisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.WrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.StreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.IssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblrecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtfilter
            // 
            this.txtfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilter.Location = new System.Drawing.Point(349, 134);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(205, 32);
            this.txtfilter.TabIndex = 16;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // btnaddnew
            // 
            this.btnaddnew.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddnew.Location = new System.Drawing.Point(1234, 131);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Size = new System.Drawing.Size(232, 36);
            this.btnaddnew.TabIndex = 15;
            this.btnaddnew.Text = "Add Application";
            this.btnaddnew.UseVisualStyleBackColor = true;
            this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
            // 
            // comfilter
            // 
            this.comfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comfilter.FormattingEnabled = true;
            this.comfilter.Items.AddRange(new object[] {
            "none",
            "ApplicationID",
            "FullName",
            "NationalNO",
            "Status"});
            this.comfilter.Location = new System.Drawing.Point(160, 134);
            this.comfilter.Name = "comfilter";
            this.comfilter.Size = new System.Drawing.Size(170, 32);
            this.comfilter.TabIndex = 14;
            this.comfilter.SelectedIndexChanged += new System.EventHandler(this.comfilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 34);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter BY :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmAppID,
            this.Column2,
            this.ClmNationalNO,
            this.ClmFullName,
            this.Column5,
            this.Column6,
            this.ClmStatus});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 172);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1454, 417);
            this.dataGridView1.TabIndex = 12;
            // 
            // ClmAppID
            // 
            this.ClmAppID.HeaderText = "APPID";
            this.ClmAppID.MinimumWidth = 6;
            this.ClmAppID.Name = "ClmAppID";
            this.ClmAppID.ReadOnly = true;
            this.ClmAppID.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Driving Class";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // ClmNationalNO
            // 
            this.ClmNationalNO.HeaderText = "National NO";
            this.ClmNationalNO.MinimumWidth = 6;
            this.ClmNationalNO.Name = "ClmNationalNO";
            this.ClmNationalNO.ReadOnly = true;
            this.ClmNationalNO.Width = 150;
            // 
            // ClmFullName
            // 
            this.ClmFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmFullName.HeaderText = "Full Name";
            this.ClmFullName.MinimumWidth = 6;
            this.ClmFullName.Name = "ClmFullName";
            this.ClmFullName.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Application Date";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Passed Test";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // ClmStatus
            // 
            this.ClmStatus.HeaderText = "Status";
            this.ClmStatus.MinimumWidth = 6;
            this.ClmStatus.Name = "ClmStatus";
            this.ClmStatus.ReadOnly = true;
            this.ClmStatus.Width = 125;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApllicationDetailsToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.SechduleTest,
            this.IssueDrivingLicense,
            this.ShowLicense,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 172);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showApllicationDetailsToolStripMenuItem
            // 
            this.showApllicationDetailsToolStripMenuItem.Name = "showApllicationDetailsToolStripMenuItem";
            this.showApllicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.showApllicationDetailsToolStripMenuItem.Text = "Show Apllication Details";
            this.showApllicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApllicationDetailsToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // SechduleTest
            // 
            this.SechduleTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VisionTest,
            this.WrittenTest,
            this.StreetTest});
            this.SechduleTest.Name = "SechduleTest";
            this.SechduleTest.Size = new System.Drawing.Size(292, 24);
            this.SechduleTest.Text = "Sechdule Tests";
            // 
            // VisionTest
            // 
            this.VisionTest.Name = "VisionTest";
            this.VisionTest.Size = new System.Drawing.Size(230, 26);
            this.VisionTest.Text = "Schedule Vision Test";
            this.VisionTest.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // WrittenTest
            // 
            this.WrittenTest.Enabled = false;
            this.WrittenTest.Name = "WrittenTest";
            this.WrittenTest.Size = new System.Drawing.Size(230, 26);
            this.WrittenTest.Text = "Schedule Writen Test";
            this.WrittenTest.Click += new System.EventHandler(this.scheduleWritenTestToolStripMenuItem_Click);
            // 
            // StreetTest
            // 
            this.StreetTest.Enabled = false;
            this.StreetTest.Name = "StreetTest";
            this.StreetTest.Size = new System.Drawing.Size(230, 26);
            this.StreetTest.Text = "Schedule Street Test";
            this.StreetTest.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // IssueDrivingLicense
            // 
            this.IssueDrivingLicense.Name = "IssueDrivingLicense";
            this.IssueDrivingLicense.Size = new System.Drawing.Size(292, 24);
            this.IssueDrivingLicense.Text = "Issue Driving License (First Time)";
            this.IssueDrivingLicense.Click += new System.EventHandler(this.IssueDrivingLicense_Click);
            // 
            // ShowLicense
            // 
            this.ShowLicense.Enabled = false;
            this.ShowLicense.Name = "ShowLicense";
            this.ShowLicense.Size = new System.Drawing.Size(292, 24);
            this.ShowLicense.Text = "Show License";
            this.ShowLicense.Click += new System.EventHandler(this.ShowLicense_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(292, 24);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(380, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = "Local Driving License Application";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 34);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Record :";
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(154, 599);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(54, 34);
            this.lblrecord.TabIndex = 18;
            this.lblrecord.Text = "???";
            this.lblrecord.Click += new System.EventHandler(this.lblrecord_Click);
            // 
            // Local_Driving_License_Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 642);
            this.Controls.Add(this.lblrecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.btnaddnew);
            this.Controls.Add(this.comfilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Local_Driving_License_Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local_Driving_License_Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Local_Driving_License_Application_FormClosing);
            this.Load += new System.EventHandler(this.Local_Driving_License_Application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.Button btnaddnew;
        private System.Windows.Forms.ComboBox comfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showApllicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SechduleTest;
        private System.Windows.Forms.ToolStripMenuItem IssueDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem ShowLicense;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem VisionTest;
        private System.Windows.Forms.ToolStripMenuItem WrittenTest;
        private System.Windows.Forms.ToolStripMenuItem StreetTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblrecord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAppID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNationalNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmStatus;
    }
}