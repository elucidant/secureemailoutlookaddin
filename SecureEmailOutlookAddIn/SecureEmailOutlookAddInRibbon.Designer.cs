namespace SecureEmailOutlookAddIn
{
   partial class SecureEmailOutlookAddInRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      public SecureEmailOutlookAddInRibbon()
          : base(Globals.Factory.GetRibbonFactory())
      {
         InitializeComponent();
      }

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

      #region Component Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.tab1 = this.Factory.CreateRibbonTab();
         this.group1 = this.Factory.CreateRibbonGroup();
         this.menu1 = this.Factory.CreateRibbonMenu();
         this.tab1.SuspendLayout();
         this.group1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tab1
         // 
         this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
         this.tab1.ControlId.OfficeId = "TabMail";
         this.tab1.Groups.Add(this.group1);
         this.tab1.Label = "TabMail";
         this.tab1.Name = "tab1";
         // 
         // group1
         // 
         this.group1.Items.Add(this.menu1);
         this.group1.Label = "{0} - Secure Email";
         this.group1.Name = "group1";
         // 
         // menu1
         // 
         this.menu1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
         this.menu1.Dynamic = true;
         this.menu1.Image = global::SecureEmailOutlookAddIn.Properties.Resources.send_secure_2;
         this.menu1.Label = "Secure Email";
         this.menu1.Name = "menu1";
         this.menu1.ShowImage = true;
         this.menu1.ItemsLoading += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.menu1_ItemsLoading);
         // 
         // SecureEmailOutlookAddInRibbon
         // 
         this.Name = "SecureEmailOutlookAddInRibbon";
         this.RibbonType = "Microsoft.Outlook.Explorer";
         this.Tabs.Add(this.tab1);
         this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
         this.tab1.ResumeLayout(false);
         this.tab1.PerformLayout();
         this.group1.ResumeLayout(false);
         this.group1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
      internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
      internal Microsoft.Office.Tools.Ribbon.RibbonMenu menu1;
   }

   partial class ThisRibbonCollection
   {
      internal SecureEmailOutlookAddInRibbon Ribbon1
      {
         get { return this.GetRibbon<SecureEmailOutlookAddInRibbon>(); }
      }
   }
}
