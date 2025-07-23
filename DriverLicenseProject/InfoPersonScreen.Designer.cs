namespace DriverLicenseProject
{
    partial class InfoPersonScreen
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
            this.informationcontrol1 = new DriverLicenseProject.informationcontrol();
            this.btnsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // informationcontrol1
            // 
            this.informationcontrol1.Location = new System.Drawing.Point(12, 64);
            this.informationcontrol1.Name = "informationcontrol1";
            this.informationcontrol1.Size = new System.Drawing.Size(844, 296);
            this.informationcontrol1.TabIndex = 0;
            this.informationcontrol1.Load += new System.EventHandler(this.informationcontrol1_Load);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(679, 366);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(142, 33);
            this.btnsave.TabIndex = 32;
            this.btnsave.Text = "Close";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Tahoma", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(219, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 52);
            this.label1.TabIndex = 33;
            this.label1.Text = "Information Screen";
            // 
            // InfoPersonScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.informationcontrol1);
            this.Name = "InfoPersonScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoPerson";
            this.Load += new System.EventHandler(this.InfoPersonScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private informationcontrol informationcontrol1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label1;
    }
}