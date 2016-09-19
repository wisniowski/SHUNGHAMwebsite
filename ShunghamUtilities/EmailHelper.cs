using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Services;

namespace ShunghamUtilities
{
    public static class EmailHelper
    {
        /// <summary>
        /// Sends email with default SMTP settings.
        /// </summary>
        /// <param name="fromAddress">From address.</param>
        /// <param name="fromDisplayName">From display name.</param>
        /// <param name="toAddress">To address.</param>
        /// <param name="toDisplayName">To display name.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="stream">The stream.</param>
        /// <param name="fileNames">The file names.</param>
        /// <param name="files">The files.</param>
        public static void SendWithDefaultSmtpSettings(string fromAddress, string fromDisplayName, string toAddress, string toDisplayName, string subject, string body, Stream[] stream, string[] fileNames, string[] files)
        {
            SmtpClient smtp = GetDefaultSmtpClient();

            // Send the email
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    // Set the from address
                    if (fromAddress.IndexOf(',') >= 0)
                        fromAddress = fromAddress.Substring(0, fromAddress.IndexOf(','));

                    if (!string.IsNullOrEmpty(fromDisplayName))
                        message.From = new MailAddress(fromAddress, fromDisplayName);
                    else
                        message.From = new MailAddress(fromAddress);

                    // Set the 'to' address
                    AddToAddress(toAddress, toDisplayName, message);

                    // Set the email subject and body
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    if (files != null)
                        foreach (string file in files)
                            message.Attachments.Add(new Attachment(file));

                    if (stream != null)
                        for (int i = 0; i < stream.Length; i++)
                            message.Attachments.Add(new Attachment(stream[i], fileNames[i]));

                    if (message.To.Count > 0)
                        smtp.Send(message);
                }
                Log.Write("Success sending en email!", ConfigurationPolicy.Trace);
            }
            catch (SmtpException smtpEx)
            {
                Log.Write(smtpEx.Message, ConfigurationPolicy.Trace);
                throw smtpEx;
            }
            catch (Exception ex)
            {
                Log.Write(ex.Message, ConfigurationPolicy.Trace);
                throw ex;
            }
        }

        /// <summary>
        /// Adds 'to' address
        /// </summary>
        /// <param name="toAddress">Email address.</param>
        /// <param name="toDisplayName">To display name.</param>
        /// <param name="message">Message to send.</param>
        private static void AddToAddress(string toAddress, string toDisplayName, MailMessage message)
        {
            toDisplayName = toDisplayName ?? string.Empty;

            string[] toAddressList = toAddress.Split(',');
            string[] toDisplayNameList = toDisplayName.Split(',');
            for (int i = 0; i < toAddressList.Length; i++)
            {
                MailAddress toAdd = null;

                if (!string.IsNullOrEmpty(toAddressList[i]))
                {
                    if (i <= toDisplayNameList.Length - 1)
                        toAdd = new MailAddress(toAddressList[i], toDisplayNameList[i]);
                    else
                        toAdd = new MailAddress(toAddressList[i]);
                }

                if (toAdd != null)
                    message.To.Add(toAdd);
            }
        }

        /// <summary>
        /// Gets the default SMTP client.
        /// </summary>
        /// <returns></returns>
        public static SmtpClient GetDefaultSmtpClient()
        {
            var smtpSettings = Config.Get<SystemConfig>().SmtpSettings;

            SmtpClient smtpClient = new SmtpClient();
            NetworkCredential basicCredentials = 
                new NetworkCredential(smtpSettings.UserName, smtpSettings.Password, smtpSettings.Domain);
            smtpClient.Host = smtpSettings.Host;
            smtpClient.Port = smtpSettings.Port;
            smtpClient.EnableSsl = smtpSettings.EnableSSL;
            smtpClient.Credentials = basicCredentials;

            return smtpClient;
        }
    }
}
