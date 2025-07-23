namespace DriverLicenseProject
{
    partial class addnewscreen
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
            this.addnewcontrol1 = new DriverLicenseProject.addnewcontrol();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addnewcontrol1
            // 
            this.addnewcontrol1.Location = new System.Drawing.Point(12, 12);
            this.addnewcontrol1.Name = "addnewcontrol1";
            this.addnewcontrol1.Size = new System.Drawing.Size(851, 504);
            this.addnewcontrol1.TabIndex = 0;
            this.addnewcontrol1.Load += new System.EventHandler(this.addnewcontrol1_Load);
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(704, 497);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(142, 33);
            this.btnclose.TabIndex = 33;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // addnewscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 543);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.addnewcontrol1);
            this.Name = "addnewscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addnewscreen";
            this.Load += new System.EventHandler(this.addnewscreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private addnewcontrol addnewcontrol1;
        private System.Windows.Forms.Button btnclose;
    }
}