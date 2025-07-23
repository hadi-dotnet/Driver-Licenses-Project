namespace DriverLicenseProject
{
    partial class InfoApplicationScreen
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
            this.btnclose = new System.Windows.Forms.Button();
            this.applcation_Details_Control1 = new DriverLicenseProject.Applcation_Details_Control();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(742, 439);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(133, 37);
            this.btnclose.TabIndex = 59;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // applcation_Details_Control1
            // 
            this.applcation_Details_Control1.Location = new System.Drawing.Point(12, 0);
            this.applcation_Details_Control1.Name = "applcation_Details_Control1";
            this.applcation_Details_Control1.Size = new System.Drawing.Size(877, 441);
            this.applcation_Details_Control1.TabIndex = 0;
            // 
            // InfoApplicationScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 482);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.applcation_Details_Control1);
            this.Name = "InfoApplicationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoApplicationScreen";
            this.Load += new System.EventHandler(this.InfoApplicationScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Applcation_Details_Control applcation_Details_Control1;
        private System.Windows.Forms.Button btnclose;
    }
}