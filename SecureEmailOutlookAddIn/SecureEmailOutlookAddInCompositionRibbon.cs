using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;

namespace SecureEmailOutlookAddIn
{
   public partial class SecureEmailOutlookAddInCompositionRibbon
   {
      private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger(
            System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      private SecureEmailOutlookAddInSendConfirmationForm
         sendConfirmationForm = null;

      private void SecureEmailOutlookAddInCompositionRibbon_Load(
         object sender, RibbonUIEventArgs e)
      {
         sendConfirmationForm =
            new SecureEmailOutlookAddInSendConfirmationForm();

         this.group1.Label = String.Format(
            this.group1.Label,
            SecureEmailOutlookAddInRibbon.DEFAULT_ORGANIZATION_NAME_PROPERTY);
      }

      private void button1_Click(object sender, RibbonControlEventArgs e)
      {
         // Process to receive active selection and save email files only
         Microsoft.Office.Interop.Outlook.Inspector currInspector = null;
         Microsoft.Office.Interop.Outlook.Explorer currExplorer = null;
         Microsoft.Office.Interop.Outlook.MailItem currMail = null;

         log.Debug("User selected button to SendSecure!");

         try
         {
            currExplorer = Globals.ThisAddIn.Application.ActiveExplorer();
            currInspector = Globals.ThisAddIn.Application.ActiveInspector();

            log.Debug("Verifying we are in a Mail Editor...");

            // We are in the Mail Editor...
            if (currInspector.CurrentItem is Microsoft.Office.Interop.Outlook.MailItem)
            {
               currMail = (Microsoft.Office.Interop.Outlook.MailItem)currInspector.CurrentItem;

               // There are cases where the user may be in the Subject area
               // and edited, and they did not tab our save the email.  In
               // those cases, the current mail's subject would not be
               // updated accordingly.  In order to get around that, we
               // need to save the current email and then pull the subject.
               currMail.Save();

               if (currMail.Subject != null)
               {
                  // Check if the send secure literal already exists prepended on
                  // the subject...if todes...don't prepend another literal!!!
                  string currMailSubject = currMail.Subject.ToUpper();

                  log.Debug("Secure Email Subject: " + currMailSubject);

                  string secureSendLiteral =
                     Properties.Settings.Default.secureEmailSendLiteral;

                  if (currMailSubject.StartsWith(
                     secureSendLiteral.ToUpper()) == false)
                  {
                     string subject = secureSendLiteral + currMail.Subject;

                     log.Debug(
                        "Prepending send secure literal to subject: " +
                        subject);

                     currMail.Subject = subject;
                  }
                  else
                  {
                     if (Properties.Settings.Default.addInDebug == true)
                     {
                        string message =
                           "Secure Literal already exists!  Skipping step to prepend...";

                        MessageBox.Show(message);

                        log.Debug(message);
                     }
                  }
               }

               // Add check for property to send email out after the button is
               // clicked...
               if (Properties.Settings.Default.secureEmailSendEmailOnButtonClick == true)
               {
                  bool sendEmail = true;

                  log.Debug("Sending Email due to Send Secure Button click...");

                  if (Properties.Settings.Default.secureEmailSendConfirmation == true)
                  {
                     // Display the confirmation form to the user...
                     var result = sendConfirmationForm.ShowDialog();

                     if (result != DialogResult.Yes)
                     {
                        log.Debug("User has opted to NOT send the secure email!");

                        sendEmail = false;
                     }
                  }
                  
                  if (sendEmail == true)
                  {
                     log.Debug("Sending secure email...");

                     currMail.Send();
                  }
               }
            }
         }
         catch (System.Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      /**
       * 
       * This method will perform the sending of the secure email based on the
       * AddIn settings.
       * 
       */

      private void sendSecureEmail(Microsoft.Office.Interop.Outlook.MailItem mailItem)
      {
         // Add check for property to send email out after the button is
         // clicked...
         if (Properties.Settings.Default.secureEmailSendEmailOnButtonClick == true)
         {
            log.Debug("Sent Email upon Send Secure Button click!");

            // Display the confirmation form to the user...
            var result = sendConfirmationForm.ShowDialog();

            if (result == DialogResult.Yes)
            {
               log.Debug("Sending secure email...");

               mailItem.Send();
            }
            else
            {
               log.Debug("User has opted to NOT send the secure email!");
            }
         }
      }
   }
}
