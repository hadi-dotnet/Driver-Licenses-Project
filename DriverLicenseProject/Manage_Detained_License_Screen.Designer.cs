namespace DriverLicenseProject
{
    partial class Manage_Detained_License_Screen
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
            this.lblrecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.btnRelease = new System.Windows.Forms.Button();
            this.comfilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ClmDetainedID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDateDetain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmISReleased = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmFineFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReleaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNationalNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHisotryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(154, 587);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(54, 34);
            this.lblrecord.TabIndex = 26;
            this.lblrecord.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 587);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 34);
            this.label3.TabIndex = 25;
            this.label3.Text = "# Record :";
            // 
            // txtfilter
            // 
            this.txtfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilter.Location = new System.Drawing.Point(349, 122);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(205, 32);
            this.txtfilter.TabIndex = 24;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Location = new System.Drawing.Point(1079, 116);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(187, 36);
            this.btnRelease.TabIndex = 23;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // comfilter
            // 
            this.comfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comfilter.FormattingEnabled = true;
            this.comfilter.Items.AddRange(new object[] {
            "none",
            "DetainID",
            "LicenseID",
            "FullName"});
            this.comfilter.Location = new System.Drawing.Point(160, 122);
            this.comfilter.Name = "comfilter";
            this.comfilter.Size = new System.Drawing.Size(170, 32);
            this.comfilter.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 34);
            this.label2.TabIndex = 21;
            this.label2.Text = "Filter BY :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmDetainedID,
            this.clmLicenseID,
            this.clmDateDetain,
            this.clmISReleased,
            this.clmFineFees,
            this.clmReleaseDate,
            this.clmNationalNO,
            this.clmName,
            this.clmApplicationID});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 160);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1454, 417);
            this.dataGridView1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(579, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 52);
            this.label1.TabIndex = 19;
            this.label1.Text = "List Detained License";
            // 
            // btnDetain
            // 
            this.btnDetain.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Location = new System.Drawing.Point(1287, 116);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(177, 36);
            this.btnDetain.TabIndex = 27;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1311, 583);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(155, 38);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ClmDetainedID
            // 
            this.ClmDetainedID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ClmDetainedID.HeaderText = "D.ID";
            this.ClmDetainedID.MinimumWidth = 6;
            this.ClmDetainedID.Name = "ClmDetainedID";
            this.ClmDetainedID.ReadOnly = true;
            this.ClmDetainedID.Width = 65;
            // 
            // clmLicenseID
            // 
            this.clmLicenseID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmLicenseID.HeaderText = "L.ID";
            this.clmLicenseID.MinimumWidth = 6;
            this.clmLicenseID.Name = "clmLicenseID";
            this.clmLicenseID.ReadOnly = true;
            this.clmLicenseID.Width = 62;
            // 
            // clmDateDetain
            // 
            this.clmDateDetain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDateDetain.HeaderText = "D.Date";
            this.clmDateDetain.MinimumWidth = 6;
            this.clmDateDetain.Name = "clmDateDetain";
            this.clmDateDetain.ReadOnly = true;
            // 
            // clmISReleased
            // 
            this.clmISReleased.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmISReleased.HeaderText = "IS Released";
            this.clmISReleased.MinimumWidth = 6;
            this.clmISReleased.Name = "clmISReleased";
            this.clmISReleased.ReadOnly = true;
            this.clmISReleased.Width = 83;
            // 
            // clmFineFees
            // 
            this.clmFineFees.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmFineFees.HeaderText = "Fine Fees";
            this.clmFineFees.MinimumWidth = 6;
            this.clmFineFees.Name = "clmFineFees";
            this.clmFineFees.ReadOnly = true;
            this.clmFineFees.Width = 92;
            // 
            // clmReleaseDate
            // 
            this.clmReleaseDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmReleaseDate.HeaderText = "Release Date";
            this.clmReleaseDate.MinimumWidth = 6;
            this.clmReleaseDate.Name = "clmReleaseDate";
            this.clmReleaseDate.ReadOnly = true;
            // 
            // clmNationalNO
            // 
            this.clmNationalNO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.clmNationalNO.HeaderText = "N.NO";
            this.clmNationalNO.MinimumWidth = 6;
            this.clmNationalNO.Name = "clmNationalNO";
            this.clmNationalNO.ReadOnly = true;
            this.clmNationalNO.Width = 69;
            // 
            // clmName
            // 
            this.clmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmName.HeaderText = "Full Name";
            this.clmName.MinimumWidth = 6;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmApplicationID
            // 
            this.clmApplicationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmApplicationID.HeaderText = "ApplicationID";
            this.clmApplicationID.MinimumWidth = 6;
            this.clmApplicationID.Name = "clmApplicationID";
            this.clmApplicationID.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetilesToolStripMenuItem,
            this.showLicenseDetilesToolStripMenuItem,
            this.showPersonLicenseHisotryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(265, 132);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showPersonDetilesToolStripMenuItem
            // 
            this.showPersonDetilesToolStripMenuItem.Name = "showPersonDetilesToolStripMenuItem";
            this.showPersonDetilesToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showPersonDetilesToolStripMenuItem.Text = "Show Person Detiles";
            this.showPersonDetilesToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetilesToolStripMenuItem_Click);
            // 
            // showLicenseDetilesToolStripMenuItem
            // 
            this.showLicenseDetilesToolStripMenuItem.Name = "showLicenseDetilesToolStripMenuItem";
            this.showLicenseDetilesToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showLicenseDetilesToolStripMenuItem.Text = "Show License Detiles";
            this.showLicenseDetilesToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetilesToolStripMenuItem_Click);
            // 
            // showPersonLicenseHisotryToolStripMenuItem
            // 
            this.showPersonLicenseHisotryToolStripMenuItem.Name = "showPersonLicenseHisotryToolStripMenuItem";
            this.showPersonLicenseHisotryToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.showPersonLicenseHisotryToolStripMenuItem.Text = "Show Person License Hisotry";
            this.showPersonLicenseHisotryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHisotryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // Manage_Detained_License_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 628);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.lblrecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.comfilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Manage_Detained_License_Screen";
            this.Text = "Manage_Detained_License_Screen";
            this.Load += new System.EventHandler(this.Manage_Detained_License_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblrecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.ComboBox comfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDetainedID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDateDetain;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmISReleased;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFineFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReleaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNationalNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApplicationID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHisotryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}