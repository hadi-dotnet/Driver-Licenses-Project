namespace DriverLicenseProject
{
    partial class ShowLicenseScreen
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
            this.showLicenseControl1 = new DriverLicenseProject.ShowLicenseControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // showLicenseControl1
            // 
            this.showLicenseControl1.Location = new System.Drawing.Point(12, 64);
            this.showLicenseControl1.Name = "showLicenseControl1";
            this.showLicenseControl1.Size = new System.Drawing.Size(844, 500);
            this.showLicenseControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(257, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 52);
            this.label1.TabIndex = 12;
            this.label1.Text = "Driver License Info";
            // 
            // ShowLicenseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 555);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showLicenseControl1);
            this.Name = "ShowLicenseScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowLicenseScreen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ShowLicenseControl showLicenseControl1;
        private System.Windows.Forms.Label label1;
    }
}