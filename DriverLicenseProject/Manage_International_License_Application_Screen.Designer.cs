namespace DriverLicenseProject
{
    partial class Manage_International_License_Application_Screen
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
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblrecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comfilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmInterLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDriverID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtfilter
            // 
            this.txtfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilter.Location = new System.Drawing.Point(325, 95);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(205, 32);
            this.txtfilter.TabIndex = 32;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(234, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(640, 52);
            this.label1.TabIndex = 31;
            this.label1.Text = "International License Application";
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(143, 547);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(54, 34);
            this.lblrecord.TabIndex = 30;
            this.lblrecord.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 547);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 34);
            this.label3.TabIndex = 29;
            this.label3.Text = "# Record :";
            // 
            // comfilter
            // 
            this.comfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comfilter.FormattingEnabled = true;
            this.comfilter.Items.AddRange(new object[] {
            "none",
            "Inter.LicenseID",
            "ApplicationID",
            "DriverID",
            "LocalLicenseID"});
            this.comfilter.Location = new System.Drawing.Point(149, 95);
            this.comfilter.Name = "comfilter";
            this.comfilter.Size = new System.Drawing.Size(170, 32);
            this.comfilter.TabIndex = 28;
            this.comfilter.SelectedIndexChanged += new System.EventHandler(this.comfilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 34);
            this.label2.TabIndex = 27;
            this.label2.Text = "Filter BY :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmInterLicenseID,
            this.clmApplicationID,
            this.clmDriverID,
            this.clmLocalLicenseID,
            this.clmIssueDate,
            this.clmExDate,
            this.clmIsActive});
            this.dataGridView1.Location = new System.Drawing.Point(12, 142);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 388);
            this.dataGridView1.TabIndex = 33;
            // 
            // clmInterLicenseID
            // 
            this.clmInterLicenseID.HeaderText = "Int.License ID";
            this.clmInterLicenseID.MinimumWidth = 6;
            this.clmInterLicenseID.Name = "clmInterLicenseID";
            this.clmInterLicenseID.ReadOnly = true;
            this.clmInterLicenseID.Width = 125;
            // 
            // clmApplicationID
            // 
            this.clmApplicationID.HeaderText = "Application ID";
            this.clmApplicationID.MinimumWidth = 6;
            this.clmApplicationID.Name = "clmApplicationID";
            this.clmApplicationID.ReadOnly = true;
            this.clmApplicationID.Width = 125;
            // 
            // clmDriverID
            // 
            this.clmDriverID.HeaderText = "Driver ID";
            this.clmDriverID.MinimumWidth = 6;
            this.clmDriverID.Name = "clmDriverID";
            this.clmDriverID.ReadOnly = true;
            this.clmDriverID.Width = 125;
            // 
            // clmLocalLicenseID
            // 
            this.clmLocalLicenseID.HeaderText = "L.License ID";
            this.clmLocalLicenseID.MinimumWidth = 6;
            this.clmLocalLicenseID.Name = "clmLocalLicenseID";
            this.clmLocalLicenseID.ReadOnly = true;
            this.clmLocalLicenseID.Width = 125;
            // 
            // clmIssueDate
            // 
            this.clmIssueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmIssueDate.HeaderText = "Issue Date";
            this.clmIssueDate.MinimumWidth = 6;
            this.clmIssueDate.Name = "clmIssueDate";
            this.clmIssueDate.ReadOnly = true;
            // 
            // clmExDate
            // 
            this.clmExDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmExDate.HeaderText = "Expiration Date";
            this.clmExDate.MinimumWidth = 6;
            this.clmExDate.Name = "clmExDate";
            this.clmExDate.ReadOnly = true;
            // 
            // clmIsActive
            // 
            this.clmIsActive.HeaderText = "Is Active";
            this.clmIsActive.MinimumWidth = 6;
            this.clmIsActive.Name = "clmIsActive";
            this.clmIsActive.ReadOnly = true;
            this.clmIsActive.Width = 125;
            // 
            // Manage_International_License_Application_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 588);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblrecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comfilter);
            this.Controls.Add(this.label2);
            this.Name = "Manage_International_License_Application_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International_License_Application_Screen";
            this.Load += new System.EventHandler(this.Manage_International_License_Application_Screen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblrecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInterLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDriverID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsActive;
    }
}