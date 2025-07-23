namespace DriverLicenseProject
{
    partial class Show_International_License_Screen
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
            this.show_International_License_Control1 = new DriverLicenseProject.Show_International_License_Control();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(133, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(637, 52);
            this.label1.TabIndex = 34;
            this.label1.Text = "Driver International License Info";
            // 
            // show_International_License_Control1
            // 
            this.show_International_License_Control1.Location = new System.Drawing.Point(12, 83);
            this.show_International_License_Control1.Name = "show_International_License_Control1";
            this.show_International_License_Control1.Size = new System.Drawing.Size(895, 358);
            this.show_International_License_Control1.TabIndex = 0;
            // 
            // Show_International_License_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 497);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.show_International_License_Control1);
            this.Name = "Show_International_License_Screen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show_International_License_Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Show_International_License_Control show_International_License_Control1;
        private System.Windows.Forms.Label label1;
    }
}