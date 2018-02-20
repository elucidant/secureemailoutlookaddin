using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;

namespace SecureEmailOutlookAddIn
{
   public partial class SecureEmailOutlookAddInRibbon
   {
      private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      private static bool menuItemsLoaded = false;

      public const string DEFAULT_ORGANIZATION_NAME = "IT";
      public const string DEFAULT_SECURE_EMAIL_INFORMATION_URL =
         "https://en.wikipedia.org/wiki/Secure_messaging";
      public const string DEFAULT_ABOUT_INFO =
         "The Secure Email Outlook Add-In will provide an end-user{0}" +
         "the ability to send secure externally bound emails based on{0}" +
         "their company's email infrastructure (e.g., CISCO Ironport,{0}" +
         "etc.).  This AddIn will add a literal to the email SUBJECT{0}" +
         "line, which trigger the email infrastructure to send the email{0}" +
         "securely";

      public const bool DEFAULT_SHOW_SETTINGS = false;
      public const bool DEFAULT_SECURE_EMAIL_ADDIN_DEBUG = false;
      public const bool DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK = false;
      public const bool DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION = false;

      public const string APPLICATION_NAME = "SecureEmailOutlookAddIn";

      public const string DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT = "[YOUR SEND SECURE LITERAL HERE]";

      // Add-In Registry constants...
      public const string ADD_IN_REGISTRY_ROOT = "HKEY_LOCAL_MACHINE";
      public const string ADD_IN_REGISTRY_ADDIN_PATH =
         "Software\\Microsoft\\Office\\Outlook\\Addins\\SecureEmailAddIn";
      public const string ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH =
         ADD_IN_REGISTRY_ADDIN_PATH + "\\Defaults";

      // Add-In Registry Keys
      public const string ADD_IN_REGISTRY_SHOW_SETTINGS_KEY =
         "ShowSettings";
      public const string ADD_IN_REGISTRY_ORGANIZATION_KEY =
         "OrganizationName";
      public const string ADD_IN_REGISTRY_SECURE_EMAIL_SEND_SUBJECT_LITERAL_KEY =
         "SecureEmailSubjectLiteral";
      public const string ADD_IN_REGISTRY_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_KEY =
         "SecureEmailSendEmailOnButtonClick";
      public const string ADD_IN_REGISTRY_DEBUG_KEY =
         "AddInDebug";
      public const string ADD_IN_REGISTRY_SECURE_EMAIL_INFORMATION_URL_KEY =
         "SecureEmailInformationURL";
      public const string ADD_IN_REGISTRY_SECURE_EMAIL_SEND_CONFIRMATION_KEY =
         "SecureEmailSendConfirmation";
      public const string ADD_IN_REGISTRY_ABOUT_INFO_KEY =
         "AboutInfo";

      public const string INITIALIZED_FILE_NAME = "initialized.txt";

      /**
       * 
       *  Add-In Property DEFAULT values are initially set to the application
       *  default values from source code control.  The application will need
       *  to override these settings based on what is in REGISTRY.
       *  
       */

      public static string DEFAULT_ABOUT_INFO_PROPERTY = DEFAULT_ABOUT_INFO;
      public static string DEFAULT_ORGANIZATION_NAME_PROPERTY =
         DEFAULT_ORGANIZATION_NAME;
      public static string DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT_PROPERTY =
         DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT;
      public static string DEFAULT_SECURE_EMAIL_INFORMATION_URL_PROPERTY =
         DEFAULT_SECURE_EMAIL_INFORMATION_URL;

      public static bool SHOW_SETTINGS_PROPERTY = DEFAULT_SHOW_SETTINGS;

      public static bool DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_PROPERTY =
         DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK;
      public static bool DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION_PROPERTY =
         DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION;
      public static bool DEFAULT_ADDIN_DEBUG_PROPERTY =
         DEFAULT_SECURE_EMAIL_ADDIN_DEBUG;

      private SecureEmailOutlookAddInSettingsForm settingsForm = null;
      private SecureEmailOutlookAddInAboutForm aboutForm = null;

      public enum KeyValueTypes
      {
         String = 1,
         Integer = 2,
         Boolean = 3
      }

      /**
       * 
       * Static constructor to be called upon class initialization and before
       * instance creation.  This constructor cannot be called directly.  The
       * static constructor will get the Registry key values that will be used
       * by the Add-In.
       *
       */

      static SecureEmailOutlookAddInRibbon()
      {
         log4net.Config.XmlConfigurator.Configure();

         getRegistryKeyValues();
      }

      /**
       * 
       * This method checks if the AddIn has been initialized based on the
       * presence of an initialized.txt file in the User's application data
       * folder.  Was having issues with being able to set the Initialized
       * registry flag, so going to use a "folder" flag instead.
       * 
       */
      public static bool isAddInInitialized()
      {
         bool isInitialized = false;

         string localAppData =
            Environment.GetFolderPath(
               System.Environment.SpecialFolder.ApplicationData);

         string addInLocalAppData =
            Path.Combine(localAppData, APPLICATION_NAME);

         string initializedFilePath =
            Path.Combine(addInLocalAppData, INITIALIZED_FILE_NAME);

         if (File.Exists(initializedFilePath) == true)
         {
            isInitialized = true;
         }

         return isInitialized;
      }

      /**
       * 
       * Creates initialized file on the file system.  Used as a flag to
       * indicate that the AddIn has been initialized upon first installation.
       * Initialization is executed via the use of Registry Default keys for
       * the AddIn.
       * 
       */
      public static void createInitializedFile()
      {
         string localAppData =
            Environment.GetFolderPath(
               System.Environment.SpecialFolder.ApplicationData);

         string addInLocalAppData =
            Path.Combine(localAppData, APPLICATION_NAME);

         try
         {
            // Need to check if the directory exists...if not, create all
            // directories and subdirectories in the path unless they
            // already exist...
            if (Directory.Exists(addInLocalAppData) == false)
            {
               Directory.CreateDirectory(addInLocalAppData);
            }

            string initializedFilePath =
               Path.Combine(addInLocalAppData, INITIALIZED_FILE_NAME);

            string initFileContent =
               "This file denotes that the SecureEmailOutlookAddIn has been " +
               "initialized.  Please DO NOT delete this file unless you " +
               "know what you are doing!";

            System.IO.StreamWriter file =
               new System.IO.StreamWriter(initializedFilePath);

            file.WriteLine(initFileContent);

            file.Close();
         }
         catch (System.Exception ex)
         {
            log.Error("Exception found during createInitializedFile(): " +
               ex.Message);
         }
      }

      /**
       * 
       * This method retrieves ALL the Add-In's needed properties from the
       * Windows Registry.
       * 
       */
      private static void getRegistryKeyValues()
      {
         object returnValue = null;

         // Get Registry setting for ShowSettings key.
         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_PATH,
            ADD_IN_REGISTRY_SHOW_SETTINGS_KEY,
            KeyValueTypes.Boolean);

         if (returnValue != null)
         {
            SHOW_SETTINGS_PROPERTY = (bool)returnValue;
         }

         // Get Registry setting for SecureEmailSendEmailOnButtonClick key.
         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_KEY,
            KeyValueTypes.Boolean);

         if (returnValue != null)
         {
            DEFAULT_SECURE_EMAIL_SEND_EMAIL_ON_BUTTON_CLICK_PROPERTY =
               (bool)returnValue;
         }

         // Get Registry setting for SecureEmailSendConfirmation key.
         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_SECURE_EMAIL_SEND_CONFIRMATION_KEY,
            KeyValueTypes.Boolean);

         if (returnValue != null)
         {
            DEFAULT_SECURE_EMAIL_SEND_CONFIRMATION_PROPERTY =
               (bool)returnValue;
         }

         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_SECURE_EMAIL_SEND_SUBJECT_LITERAL_KEY,
            KeyValueTypes.String);

         if (returnValue != null)
         {
            DEFAULT_SECURE_EMAIL_SEND_LITERAL_SUBJECT_PROPERTY =
               (string)returnValue;
         }

         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_DEBUG_KEY,
            KeyValueTypes.Boolean);

         if (returnValue != null)
         {
            DEFAULT_ADDIN_DEBUG_PROPERTY = (bool)returnValue;
         }

         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_SECURE_EMAIL_INFORMATION_URL_KEY,
            KeyValueTypes.String);

         if (returnValue != null)
         {
            DEFAULT_SECURE_EMAIL_INFORMATION_URL_PROPERTY = (string)returnValue;
         }

         returnValue = retrieveHLMRegistryKeyValue(
            ADD_IN_REGISTRY_ADDIN_DEFAULTS_PATH,
            ADD_IN_REGISTRY_ABOUT_INFO_KEY,
            KeyValueTypes.String);

         if (returnValue != null)
         {
            DEFAULT_ABOUT_INFO_PROPERTY = (string)returnValue;
         }
      }

      private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
      {
         try
         {
            // Initialize the forms that will be used with the ribbon...
            settingsForm = new SecureEmailOutlookAddInSettingsForm();
            aboutForm = new SecureEmailOutlookAddInAboutForm();
         }
         catch (System.Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

         this.group1.Label = String.Format(
            this.group1.Label, DEFAULT_ORGANIZATION_NAME_PROPERTY);
      }

      private void menu1_ItemsLoading(object sender, Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs e)
      {
         // Had to add the following condition because everytime the Menu was accessed,
         // the ItemsLoading event kept getting fired and the would keep adding the same
         // menu items over and over again!!!!
         if (menuItemsLoaded == false)
         {
            if (SHOW_SETTINGS_PROPERTY == true)
            {
               RibbonButton menuButton1 = Factory.CreateRibbonButton();

               menuButton1.Label = "&Secure Email Settings";
               menuButton1.Click +=
                  new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                     secureEmailSettingsForm_Click);

               menu1.Items.Add(menuButton1);
            }

            RibbonButton menuButton2 = Factory.CreateRibbonButton();

            menuButton2.Label = "Secure Email Information";
            menuButton2.Click +=
               new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                  secureEmailInformation_Click);

            menu1.Items.Add(menuButton2);

            RibbonButton menuButton3 = Factory.CreateRibbonButton();

            menuButton3.Label = "About";
            menuButton3.Click +=
               new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(
                  secureEmailAboutForm_Click);

            menu1.Items.Add(menuButton3);

            menuItemsLoaded = true;
         }
      }

      private void secureEmailSettingsForm_Click(
         object sender, RibbonControlEventArgs e)
      {
         // Need to force the update here...in the case where the show
         // confirmation dialog setting is updated outside the settings form.
         SecureEmailOutlookAddInSettingsForm.updateUserSettings();

         // Display the form to the user...
         settingsForm.ShowDialog();
      }

      private void secureEmailInformation_Click(object sender, RibbonControlEventArgs e)
      {
         Process.Start(@DEFAULT_SECURE_EMAIL_INFORMATION_URL_PROPERTY);
      }

      private void secureEmailAboutForm_Click(object sender, RibbonControlEventArgs e)
      {
         // Display the form to the user...
         aboutForm.ShowDialog();
      }

      /**
       * 
       * This method will retrieve an HKEY_CURRENT_USER boolean key value from
       * the registry.
       * 
       */
      public static object retrieveHCURegistryKeyValue(
         string keyName,
         string valueName,
         KeyValueTypes keyValueType)
      {
         object result = null;

         log.Debug("Getting HCU Registry Key Value [" + keyName + ", " + valueName + "]");

         RegistryKey rk = Registry.CurrentUser.OpenSubKey(
            keyName, false);

         // If the Registry Key Parent path is NOT FOUND, we will just return
         // false!
         if (rk != null)
         {
            object keyValue = rk.GetValue(valueName);

            if (keyValue != null)
            {
               if (keyValueType == KeyValueTypes.Boolean)
               {
                  result = Convert.ToBoolean(keyValue);

                  log.Debug("Boolean Value Found: " + (bool)result);
               }
               else if (keyValueType == KeyValueTypes.String)
               {
                  // Need to determine what type of word we are dealing with...
                  if (rk.GetValueKind(valueName) == RegistryValueKind.DWord)
                  {
                     result = Convert.ToString((Int32)keyValue);
                  }
                  else if (rk.GetValueKind(valueName) == RegistryValueKind.QWord)
                  {
                     result = Convert.ToString((Int64)keyValue);
                  }
                  else
                  {
                     result = keyValue;
                  }

                  log.Debug("String Value Found: " + result);
               }
               else if (keyValueType == KeyValueTypes.Integer)
               {
                  result = int.Parse(keyValue.ToString());

                  log.Debug("Integer Value Found: " + (int)result);
               }
               else
               {
                  string message = "We DO NOT support the Key Value Type: " +
                     keyValueType.ToString();

                  log.Debug(message);

                  MessageBox.Show(
                     message,
                     "Unsupported Registry Key Value Type",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
               }
            }

            rk.Close();
         }
         else
         {
            string message =
               "HCU Registry Key [" +
               keyName + "\\" +
               valueName + "] NOT Found!";

            log.Warn(message);

            MessageBox.Show(
               message,
               "Registry Key Not Found",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
         }

         log.Debug(
            "Value of HCU Registry Key Value [" +
            keyName + ", " + valueName + "] = " +
            result.ToString());

         return result;
      }

      /**
       * 
       * This method will retrieve an HKEY_LOCAL_MACHINE boolean key value from
       * the registry.
       * 
       */
      public static object retrieveHLMRegistryKeyValue(
         string keyName,
         string valueName,
         KeyValueTypes keyValueType)
      {
         object result = null;

         log.Debug("Getting HLM Registry Key Value [" + keyName + ", " + valueName + "]");

         RegistryKey rk = Registry.LocalMachine.OpenSubKey(
            keyName, false);

         // If the Registry Key Parent path is NOT FOUND, we will just return
         // false!
         if (rk != null)
         {
            object keyValue = rk.GetValue(valueName);

            if (keyValue != null)
            {
               if (keyValueType == KeyValueTypes.Boolean)
               {
                  result = Convert.ToBoolean(keyValue);
               }
               else if (keyValueType == KeyValueTypes.String)
               {
                  // Need to determine what type of word we are dealing with...
                  if (rk.GetValueKind(valueName) == RegistryValueKind.DWord)
                  {
                     result = Convert.ToString((Int32)keyValue);
                  }
                  else if (rk.GetValueKind(valueName) == RegistryValueKind.QWord)
                  {
                     result = Convert.ToString((Int64)keyValue);
                  }
                  else
                  {
                     result = keyValue;
                  }
               }
               else if (keyValueType == KeyValueTypes.Integer)
               {
                  result = int.Parse(keyValue.ToString());
               }
               else
               {
                  MessageBox.Show(
                     "We DO NOT support the Key Value Type: " +
                     keyValueType.ToString(),
                     "Unsupported Registry Key Value Type",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning);
               }
            }
            else
            {
               log.Debug("Registry Key Value is NULL!");
            }

            rk.Close();
         }
         else
         {
            MessageBox.Show(
               "HLM Registry Key [" +
               keyName + "\\" +
               valueName + "] NOT Found!",
               "Registry Key Not Found",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);

            log.Warn("Registry Key Value NOT Found!");
         }

         log.Debug(
            "Value of HLM Registry Key Value [" +
            keyName + ", " + valueName + "] = " +
            result.ToString());

         return result;
      }
   }
}
