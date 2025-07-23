namespace DriverLicenseProject
{
    partial class License_History_Screen
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
            this.label1 = new System.Windows.Forms.Label();
            this.Local = new System.Windows.Forms.TabControl();
            this.Tap1 = new System.Windows.Forms.TabPage();
            this.LocaldataGridView = new System.Windows.Forms.DataGridView();
            this.Tap2 = new System.Windows.Forms.TabPage();
            this.InternationaldataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.filterAndShow1 = new DriverLicenseProject.FilterAndShow();
            this.clmInterLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApplicationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocalLicenseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIssueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmExDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Local.SuspendLayout();
            this.Tap1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocaldataGridView)).BeginInit();
            this.Tap2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InternationaldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1000, 22);
            this.label1.TabIndex = 52;
            this.label1.Text = "_________________________________________________________________________________" +
    "__________________";
            // 
            // Local
            // 
            this.Local.Controls.Add(this.Tap1);
            this.Local.Controls.Add(this.Tap2);
            this.Local.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Local.Location = new System.Drawing.Point(58, 435);
            this.Local.Name = "Local";
            this.Local.SelectedIndex = 0;
            this.Local.Size = new System.Drawing.Size(977, 273);
            this.Local.TabIndex = 53;
            // 
            // Tap1
            // 
            this.Tap1.Controls.Add(this.LocaldataGridView);
            this.Tap1.Location = new System.Drawing.Point(4, 27);
            this.Tap1.Name = "Tap1";
            this.Tap1.Padding = new System.Windows.Forms.Padding(3);
            this.Tap1.Size = new System.Drawing.Size(969, 242);
            this.Tap1.TabIndex = 0;
            this.Tap1.Text = "Local";
            this.Tap1.UseVisualStyleBackColor = true;
            // 
            // LocaldataGridView
            // 
            this.LocaldataGridView.AllowUserToAddRows = false;
            this.LocaldataGridView.AllowUserToDeleteRows = false;
            this.LocaldataGridView.BackgroundColor = System.Drawing.Color.White;
            this.LocaldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LocaldataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2,
            this.clmClassName,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewCheckBoxColumn1});
            this.LocaldataGridView.Location = new System.Drawing.Point(6, 3);
            this.LocaldataGridView.Name = "LocaldataGridView";
            this.LocaldataGridView.ReadOnly = true;
            this.LocaldataGridView.RowHeadersWidth = 51;
            this.LocaldataGridView.RowTemplate.Height = 26;
            this.LocaldataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LocaldataGridView.Size = new System.Drawing.Size(957, 233);
            this.LocaldataGridView.TabIndex = 54;
            // 
            // Tap2
            // 
            this.Tap2.Controls.Add(this.InternationaldataGridView);
            this.Tap2.Location = new System.Drawing.Point(4, 27);
            this.Tap2.Name = "Tap2";
            this.Tap2.Padding = new System.Windows.Forms.Padding(3);
            this.Tap2.Size = new System.Drawing.Size(969, 242);
            this.Tap2.TabIndex = 1;
            this.Tap2.Text = "International";
            this.Tap2.UseVisualStyleBackColor = true;
            // 
            // InternationaldataGridView
            // 
            this.InternationaldataGridView.AllowUserToAddRows = false;
            this.InternationaldataGridView.AllowUserToDeleteRows = false;
            this.InternationaldataGridView.BackgroundColor = System.Drawing.Color.White;
            this.InternationaldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InternationaldataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmInterLicenseID,
            this.clmApplicationID,
            this.clmLocalLicenseID,
            this.clmIssueDate,
            this.clmExDate,
            this.clmIsActive});
            this.InternationaldataGridView.Location = new System.Drawing.Point(6, 6);
            this.InternationaldataGridView.Name = "InternationaldataGridView";
            this.InternationaldataGridView.ReadOnly = true;
            this.InternationaldataGridView.RowHeadersWidth = 51;
            this.InternationaldataGridView.RowTemplate.Height = 26;
            this.InternationaldataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InternationaldataGridView.Size = new System.Drawing.Size(957, 230);
            this.InternationaldataGridView.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "L.License ID";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Application ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // clmClassName
            // 
            this.clmClassName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmClassName.HeaderText = "Class Name";
            this.clmClassName.MinimumWidth = 6;
            this.clmClassName.Name = "clmClassName";
            this.clmClassName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Issue Date";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Expiration Date";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Is Active";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 163;
            // 
            // filterAndShow1
            // 
            this.filterAndShow1.Location = new System.Drawing.Point(155, 12);
            this.filterAndShow1.Name = "filterAndShow1";
            this.filterAndShow1.Size = new System.Drawing.Size(805, 381);
            this.filterAndShow1.TabIndex = 0;
            // 
            // clmInterLicenseID
            // 
            this.clmInterLicenseID.HeaderText = "Int.License ID";
            this.clmInterLicenseID.MinimumWidth = 6;
            this.clmInterLicenseID.Name = "clmInterLicenseID";
            this.clmInterLicenseID.ReadOnly = true;
            this.clmInterLicenseID.Width = 129;
            // 
            // clmApplicationID
            // 
            this.clmApplicationID.HeaderText = "Application ID";
            this.clmApplicationID.MinimumWidth = 6;
            this.clmApplicationID.Name = "clmApplicationID";
            this.clmApplicationID.ReadOnly = true;
            this.clmApplicationID.Width = 125;
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
            // License_History_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 745);
            this.Controls.Add(this.Local);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterAndShow1);
            this.Name = "License_History_Screen";
            this.Text = "License_History_Screen";
            this.Load += new System.EventHandler(this.License_History_Screen_Load);
            this.Local.ResumeLayout(false);
            this.Tap1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LocaldataGridView)).EndInit();
            this.Tap2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InternationaldataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FilterAndShow filterAndShow1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Local;
        private System.Windows.Forms.TabPage Tap1;
        private System.Windows.Forms.TabPage Tap2;
        private System.Windows.Forms.DataGridView LocaldataGridView;
        private System.Windows.Forms.DataGridView InternationaldataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInterLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApplicationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocalLicenseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIssueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmExDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsActive;
    }
}