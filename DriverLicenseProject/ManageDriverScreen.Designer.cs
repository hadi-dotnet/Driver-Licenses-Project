namespace DriverLicenseProject
{
    partial class ManageDriverScreen
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
            this.lblrecord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comfilter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNationalNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmActiveLicense = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblrecord
            // 
            this.lblrecord.AutoSize = true;
            this.lblrecord.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrecord.Location = new System.Drawing.Point(149, 535);
            this.lblrecord.Name = "lblrecord";
            this.lblrecord.Size = new System.Drawing.Size(54, 34);
            this.lblrecord.TabIndex = 23;
            this.lblrecord.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 34);
            this.label3.TabIndex = 22;
            this.label3.Text = "# Record :";
            // 
            // comfilter
            // 
            this.comfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comfilter.FormattingEnabled = true;
            this.comfilter.Items.AddRange(new object[] {
            "none",
            "PersonID",
            "FullName",
            "NationalNO"});
            this.comfilter.Location = new System.Drawing.Point(155, 87);
            this.comfilter.Name = "comfilter";
            this.comfilter.Size = new System.Drawing.Size(170, 32);
            this.comfilter.TabIndex = 21;
            this.comfilter.SelectedIndexChanged += new System.EventHandler(this.comfilter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 34);
            this.label2.TabIndex = 20;
            this.label2.Text = "Filter BY :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(400, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 52);
            this.label1.TabIndex = 24;
            this.label1.Text = "Manage Driver";
            // 
            // txtfilter
            // 
            this.txtfilter.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfilter.Location = new System.Drawing.Point(331, 87);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(205, 32);
            this.txtfilter.TabIndex = 25;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ClmPersonID,
            this.ClmNationalNO,
            this.ClmFullName,
            this.ClmDate,
            this.ClmActiveLicense});
            this.dataGridView1.Location = new System.Drawing.Point(12, 134);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 26;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1056, 388);
            this.dataGridView1.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Driver iD";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // ClmPersonID
            // 
            this.ClmPersonID.HeaderText = "Person ID";
            this.ClmPersonID.MinimumWidth = 6;
            this.ClmPersonID.Name = "ClmPersonID";
            this.ClmPersonID.ReadOnly = true;
            this.ClmPersonID.Width = 120;
            // 
            // ClmNationalNO
            // 
            this.ClmNationalNO.HeaderText = "National NO";
            this.ClmNationalNO.MinimumWidth = 6;
            this.ClmNationalNO.Name = "ClmNationalNO";
            this.ClmNationalNO.ReadOnly = true;
            this.ClmNationalNO.Width = 120;
            // 
            // ClmFullName
            // 
            this.ClmFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmFullName.HeaderText = "Full Name";
            this.ClmFullName.MinimumWidth = 6;
            this.ClmFullName.Name = "ClmFullName";
            this.ClmFullName.ReadOnly = true;
            // 
            // ClmDate
            // 
            this.ClmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClmDate.HeaderText = "Date";
            this.ClmDate.MinimumWidth = 6;
            this.ClmDate.Name = "ClmDate";
            this.ClmDate.ReadOnly = true;
            this.ClmDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ClmActiveLicense
            // 
            this.ClmActiveLicense.HeaderText = "Active License";
            this.ClmActiveLicense.MinimumWidth = 6;
            this.ClmActiveLicense.Name = "ClmActiveLicense";
            this.ClmActiveLicense.ReadOnly = true;
            this.ClmActiveLicense.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmActiveLicense.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ClmActiveLicense.Width = 125;
            // 
            // ManageDriverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 593);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblrecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comfilter);
            this.Controls.Add(this.label2);
            this.Name = "ManageDriverScreen";
            this.Text = "ManageDriverScreen";
            this.Load += new System.EventHandler(this.ManageDriverScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblrecord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comfilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNationalNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClmActiveLicense;
    }
}