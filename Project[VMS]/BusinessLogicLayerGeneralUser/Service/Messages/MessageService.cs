using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.Messages
{
    public class MessageService
    {
        public static bool SendMessage(string value)
        {
            if (value.All(char.IsDigit))
            {
                string result = "";
                WebRequest request = null;
                HttpWebResponse response = null;
                try
                {
                    String to = value;
                    String token = "838611234516924226255819434dff3b74545c106fa94d22105b";
                    String message = System.Uri.EscapeUriString("Your Account Created Successfully. [VMS Team]");
                    String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                    request = WebRequest.Create(url);

                    response = (HttpWebResponse)request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader reader = new
                    System.IO.StreamReader(stream, ec);
                    result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    reader.Close();
                    stream.Close();
                }
                catch (Exception exp)
                {
                    return false;
                }
                finally
                {
                    if (response != null)
                    {
                        response.Close();
                    }
                }
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                string senderEmail = "ahmedsad0819@gmail.com";
                string senderPassword = "oefsishlanouxmwe";

                string recipientEmail = value;

                MailMessage mailSender = new MailMessage(senderEmail, recipientEmail);
                mailSender.Subject = "OTP code from VMS system";
                mailSender.Body = "Your Account Created Successfully. [VMS Team]";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                try
                {
                    smtpClient.Send(mailSender);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
