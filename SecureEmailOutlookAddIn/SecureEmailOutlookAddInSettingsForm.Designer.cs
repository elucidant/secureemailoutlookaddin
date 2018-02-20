namespace SecureEmailOutlookAddIn
{
   partial class SecureEmailOutlookAddInSettingsForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecureEmailOutlookAddInSettingsForm));
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.button1 = new System.Windows.Forms.Button();
         this.button2 = new System.Windows.Forms.Button();
         this.button3 = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.checkBox2 = new System.Windows.Forms.CheckBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.checkBox3 = new System.Windows.Forms.CheckBox();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(24, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(394, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "This dialogue is used to configure the settings of the Secure Send Outlook Add-In" +
    ".";
         this.label1.Click += new System.EventHandler(this.label1_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(24, 59);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(200, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Send Secure email Subject prepend text:";
         this.label2.Click += new System.EventHandler(this.label2_Click);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(230, 56);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(279, 20);
         this.textBox1.TabIndex = 2;
         this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(110, 162);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(113, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Enable DEBUG mode:";
         this.label3.Click += new System.EventHandler(this.label3_Click);
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(230, 162);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(15, 14);
         this.checkBox1.TabIndex = 4;
         this.checkBox1.UseVisualStyleBackColor = true;
         this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(192, 197);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(117, 23);
         this.button1.TabIndex = 5;
         this.button1.Text = "Reset to Defaults";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(337, 197);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 6;
         this.button2.Text = "OK";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // button3
         // 
         this.button3.Location = new System.Drawing.Point(433, 197);
         this.button3.Name = "button3";
         this.button3.Size = new System.Drawing.Size(75, 23);
         this.button3.TabIndex = 7;
         this.button3.Text = "Cancel";
         this.button3.UseVisualStyleBackColor = true;
         this.button3.Click += new System.EventHandler(this.button3_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(20, 90);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(203, 13);
         this.label4.TabIndex = 8;
         this.label4.Text = "Send Email on Secure Send Button Click:";
         this.label4.Click += new System.EventHandler(this.label4_Click);
         // 
         // checkBox2
         // 
         this.checkBox2.AutoSize = true;
         this.checkBox2.Location = new System.Drawing.Point(230, 96);
         this.checkBox2.Name = "checkBox2";
         this.checkBox2.Size = new System.Drawing.Size(15, 14);
         this.checkBox2.TabIndex = 9;
         this.checkBox2.UseVisualStyleBackColor = true;
         this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(121, 105);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(96, 13);
         this.label5.TabIndex = 10;
         this.label5.Text = "(Composition View)";
         this.label5.Click += new System.EventHandler(this.label5_Click);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(24, 130);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(197, 13);
         this.label6.TabIndex = 11;
         this.label6.Text = "Secure Email Send Confirmation Prompt:";
         this.label6.Click += new System.EventHandler(this.label6_Click);
         // 
         // checkBox3
         // 
         this.checkBox3.AutoSize = true;
         this.checkBox3.Location = new System.Drawing.Point(230, 131);
         this.checkBox3.Name = "checkBox3";
         this.checkBox3.Size = new System.Drawing.Size(15, 14);
         this.checkBox3.TabIndex = 12;
         this.checkBox3.UseVisualStyleBackColor = true;
         this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
         // 
         // SecureEmailOutlookAddInSettingsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(521, 242);
         this.Controls.Add(this.checkBox3);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.checkBox2);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.button3);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.checkBox1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "SecureEmailOutlookAddInSettingsForm";
         this.Text = "Secure Email Outlook AddIn Settings";
         this.Load += new System.EventHandler(this.SecureEmailOutlookAddInSettingsForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox checkBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.CheckBox checkBox2;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox checkBox3;
   }
}
