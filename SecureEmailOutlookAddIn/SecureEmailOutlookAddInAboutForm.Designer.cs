﻿namespace SecureEmailOutlookAddIn
{
   partial class SecureEmailOutlookAddInAboutForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecureEmailOutlookAddInAboutForm));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.label3 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::SecureEmailOutlookAddIn.Properties.Resources.send_secure_1_128x128;
         this.pictureBox1.Location = new System.Drawing.Point(27, 26);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(131, 128);
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(195, 26);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(244, 20);
         this.label1.TabIndex = 1;
         this.label1.Text = "Secure Email Outlook Add-In";
         this.label1.Click += new System.EventHandler(this.label1_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
         this.label2.Location = new System.Drawing.Point(197, 62);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(21, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "{0}";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(234, 199);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 3;
         this.button1.Text = "OK";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(36, 173);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(113, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Version: {0}.{1}.{2}.{3}";
         this.label3.Click += new System.EventHandler(this.label3_Click);
         // 
         // SecureEmailOutlookAddInAboutForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(542, 243);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.pictureBox1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "SecureEmailOutlookAddInAboutForm";
         this.Text = "About";
         this.Load += new System.EventHandler(this.SecureEmailOutlookAddInAboutFormcs_Load);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label3;
   }
}
