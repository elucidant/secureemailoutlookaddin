namespace SecureEmailOutlookAddIn
{
   partial class SecureEmailOutlookAddInSendConfirmationForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecureEmailOutlookAddInSendConfirmationForm));
         this.label1 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.label2 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(78, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(362, 18);
         this.label1.TabIndex = 0;
         this.label1.Text = "Are you sure you want to send the email SECURELY?";
         this.label1.Click += new System.EventHandler(this.label1_Click);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(273, 71);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "Yes";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(354, 71);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 2;
         this.button2.Text = "No";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(12, 76);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(15, 14);
         this.checkBox1.TabIndex = 3;
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(31, 77);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(218, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "In the future, do not show me this dialog box.";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::SecureEmailOutlookAddIn.Properties.Resources.warning_32x32;
         this.pictureBox1.Location = new System.Drawing.Point(21, 21);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(37, 37);
         this.pictureBox1.TabIndex = 5;
         this.pictureBox1.TabStop = false;
         this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
         // 
         // SecureEmailOutlookAddInSendConfirmationForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(468, 122);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.checkBox1);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "SecureEmailOutlookAddInSendConfirmationForm";
         this.Text = "Secure Email Send Confirmation";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.PictureBox pictureBox1;
   }
}