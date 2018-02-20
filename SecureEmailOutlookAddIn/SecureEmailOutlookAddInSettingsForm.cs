using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecureEmailOutlookAddIn
{
   public partial class SecureEmailOutlookAddInSettingsForm : Form
   {
      private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      // Default form properties based on Ribbon class' default settings
      // initially...
      private static bool addInDebug = SecureEmailOutlookAddInRibbon.
         DEFAULT_ADDIN_DEBUG_PROPERTY;

      private static string sendSecureLiteralSubject = SecureEmailOutlookAddInRibbon.
         DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT_PROPERTY;

      private static bool sendEmailOnSendSecureButtonClick =
         SecureEmailOutlookAddInRibbon.
            DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_PROPERTY;

      private static bool sendConfirmation =
         SecureEmailOutlookAddInRibbon.
            DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION_PROPERTY;

      // Read-write instance properties
      public string SendSecureLiteralSubject
      {
         get { return sendSecureLiteralSubject; }
         set { sendSecureLiteralSubject = value; }
      }

      public bool SendEmailOnSendSecureButtonClick
      {
         get { return sendEmailOnSendSecureButtonClick; }
         set { sendEmailOnSendSecureButtonClick = value; }
      }

      public bool SendConfirmation
      {
         get { return sendConfirmation; }
         set { sendConfirmation = value; }
      }

      public bool AddInDebug
      {
         get { return addInDebug; }
         set { addInDebug = value; }
      }

      /**
       * 
       * Static constructor to be called upon class initialization and before
       * instance creation.  This constructor cannot be called directly.  The
       * static constructor will initialize the form properties used.
       *
       */

      static SecureEmailOutlookAddInSettingsForm()
      {
         // Upon initialization of the object, we need to determine if this is
         // the first run of the application.  We need to check for the
         // existence of the Initialized file in the User's local roaming
         // folder for the AddIn.  If it does not exist, we need to load
         // the properties from the Registry.

         if (SecureEmailOutlookAddInRibbon.isAddInInitialized() == false)
         {
            log.Debug(
               "Initialized flag does not EXIST.  Initializing application " +
               "settings from the registry.  Creating initialized file...");

            // We don't need to set the properties at this point since they
            // are defaulted to the Registry Key values.  Just need to
            // persist the Properties to the file system and then create the
            // initialized file...
            persistPropertySettings();

            // Create the Initialized file as a flag for future runs that we
            // don't initialize these values again.
            SecureEmailOutlookAddInRibbon.createInitializedFile();
         }
      }

      public SecureEmailOutlookAddInSettingsForm()
      {
         // Get local file system settings and set them if they are defined...
         updateUserSettings();

         log.Debug(
            "In SecureEmailOutlookAddInSettingsForm constructor, User " +
            "Application Settings:\n" + buildUserSettingsString());

         log.Debug(
            "In SecureEmailOutlookAddInSettingsForm constructor, " +
            "Application Registry Properties:\n" +
            buildRegistrySettingsString());

         InitializeComponent();
      }

      /**
       * 
       * Retrieves the user settings from the User Application Data
       * configuration file.
       * 
       */

      public static void updateUserSettings()
      {
         if (Properties.Settings.Default.secureEmailSendLiteral != null)
         {
            sendSecureLiteralSubject =
               Properties.Settings.Default.secureEmailSendLiteral;
         }

         addInDebug = Properties.Settings.Default.addInDebug;

         sendEmailOnSendSecureButtonClick =
            Properties.Settings.Default.secureEmailSendEmailOnButtonClick;

         sendConfirmation = Properties.Settings.Default.secureEmailSendConfirmation;
      }

      private void label1_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      private void label2_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      private void textBox1_TextChanged(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      private void label3_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      private void label4_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }
      
      private void label5_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      private void label6_Click(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      /**
       * 
       * AddIn Debug check box event.
       * 
       */

      private void checkBox1_CheckedChanged(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      /**
       * 
       * Send Email when Send Secure Button is Clicked check box event.
       * 
       */
      private void checkBox2_CheckedChanged(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      /**
       * 
       * Secure Email Send Confirmation button is clicked check box event.
       * 
       */
      private void checkBox3_CheckedChanged(object sender, EventArgs e)
      {
         // Do nothing for this event...
      }

      /**
       *
       * Event handler when Reset To Defaults button is clicked.
       * 
       */
      private void button1_Click(object sender, EventArgs e)
      {
         string sendSecureLiteralSubject = null;

         bool addInDebug = false;

         sendSecureLiteralSubject = SecureEmailOutlookAddInRibbon.
            DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT_PROPERTY;

         sendEmailOnSendSecureButtonClick = SecureEmailOutlookAddInRibbon.
            DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_PROPERTY;

         sendConfirmation = SecureEmailOutlookAddInRibbon.
            DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION_PROPERTY;

         addInDebug = SecureEmailOutlookAddInRibbon.
            DEFAULT_ADDIN_DEBUG_PROPERTY;

         log.Debug(
            "User pressed Reset to Defaults button!  " +
            "Reverting back to DEFAULT values!");

         // We want to set the form state to the default properties, BUT we DO
         // NOT want to set the properties UNTIL the user presses the OK
         // button.  This gives the user the ability to CANCEL out of the
         // process to set the properties permanently!
         setFormState(
            sendSecureLiteralSubject,
            sendEmailOnSendSecureButtonClick,
            sendConfirmation,
            addInDebug);
      }

      /**
       * 
       * Event handler when the OK button is clicked.
       * 
       */
      private void button2_Click(object sender, EventArgs e)
      {
         sendSecureLiteralSubject = textBox1.Text;

         addInDebug = checkBox1.Checked;

         sendEmailOnSendSecureButtonClick = checkBox2.Checked;

         sendConfirmation = checkBox3.Checked;

         // Now we need to persist the values to the Properties file...
         persistPropertySettings();

         log.Debug(
            "User pressed OK button!\n" + buildUserSettingsString());

         // Do a Hide() instead of a Close(), which kills the Form object...
         Hide();
      }

      /**
       * 
       * This method persists the current form settings to the Add-In User
       * property file on the user's file system.  This is how the settings are
       * used across Outlook application life-cycles for the specific user.
       * 
       */

      public static void persistPropertySettings()
      {
         // Now we need to persist the values to the Properties file...
         Properties.Settings.Default.secureEmailSendLiteral =
            sendSecureLiteralSubject;
         Properties.Settings.Default.addInDebug = addInDebug;
         Properties.Settings.Default.secureEmailSendEmailOnButtonClick =
            sendEmailOnSendSecureButtonClick;
         Properties.Settings.Default.secureEmailSendConfirmation =
            sendConfirmation;

         // Persist changes to user settings between application sessions.
         Properties.Settings.Default.Save();
      }

      /**
       *
       * Event handler when CANCEL button is clicked.
       * 
       */
      private void button3_Click(object sender, EventArgs e)
      {
         log.Debug(
            "User pressed CANCEL button!  " +
            "Reverting back to previous values!\n" +
            buildUserSettingsString());

         setFormStateBasedOnProperties();

         // Do a Hide() instead of a Close(), which kills the Form object...
         Hide();
      }

      /**
       * 
       * Event handler when the form is loaded.  This method will initialize
       * the form default values based on the current form settings.
       * 
       */
      private void SecureEmailOutlookAddInSettingsForm_Load(
         object sender, EventArgs e)
      {
         log.Debug("Loading Phish Settings form...");

         setFormStateBasedOnProperties();
      }

      /**
       * 
       * Sets the form state based on the current form properties.
       * 
       */

      private void setFormStateBasedOnProperties()
      {
         setFormState(
            sendSecureLiteralSubject,
            sendEmailOnSendSecureButtonClick,
            sendConfirmation,
            addInDebug);
      }

      /**
       * 
       * Sets the form state based on the parameters passed in.
       * 
       */
      private void setFormState(
         string sendSecureLiteralSubject,
         bool sendEmailOnSendSecureButtonClick,
         bool sendConfirmation,
         bool addInDebug)
      {
         this.textBox1.Text = sendSecureLiteralSubject;

         if (sendEmailOnSendSecureButtonClick == true)
         {
            this.checkBox2.CheckState = CheckState.Checked;
         }
         else
         {
            this.checkBox2.CheckState = CheckState.Unchecked;
         }

         if (sendConfirmation == true)
         {
            this.checkBox3.CheckState = CheckState.Checked;
         }
         else
         {
            this.checkBox3.CheckState = CheckState.Unchecked;
         }

         if (addInDebug == true)
         {
            this.checkBox1.CheckState = CheckState.Checked;
         }
         else
         {
            this.checkBox1.CheckState = CheckState.Unchecked;
         }
      }

      /**
       * 
       * Helper method to build the user settings string, typically used for
       * DEBUG purposes.
       * 
       */
      private string buildUserSettingsString()
      {
         string settingsString =
            "Send Secure Subject Literal: " + sendSecureLiteralSubject + "\n" +
            "Secure Email Send on Send Secure Button Click: " +
               sendEmailOnSendSecureButtonClick + "\n" +
            "Secure Email Send Confirmation: " + sendConfirmation + "\n" +
            "Debug Enabled: " + addInDebug;

         return settingsString;
      }

      /**
       * 
       * Helper method to build the registry settings string, typically used
       * for DEBUG purposes.
       * 
       */
      private String buildRegistrySettingsString()
      {
         string settingsString =
             "Show Settings: " +
               SecureEmailOutlookAddInRibbon.SHOW_SETTINGS_PROPERTY + "\n" +
            "Secure Email Subject: " +
               SecureEmailOutlookAddInRibbon.
                  DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT_PROPERTY + "\n" +
            "Organization Name: " +
               SecureEmailOutlookAddInRibbon.
                  DEFAULT_ORGANIZATION_NAME_PROPERTY + "\n" +
            "Secure Email URL: " +
               SecureEmailOutlookAddInRibbon.
                  DEFAULT_SECURE_EMAIL_INFORMATION_URL_PROPERTY + "\n" +
            "Secure Email Send on Send Secure Button Click: " +
               SecureEmailOutlookAddInRibbon.
                  DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_PROPERTY +
                  "\n" +
            "Secure Email Send Confirmation: " +
               SecureEmailOutlookAddInRibbon.
                  DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION_PROPERTY + "\n" +
            "AddIn Debug: " +
               SecureEmailOutlookAddInRibbon.DEFAULT_ADDIN_DEBUG_PROPERTY;

         return settingsString;
      }
   }
}
