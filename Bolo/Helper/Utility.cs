﻿using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace Bolo.Helper
{
    public class Utility
    {
        public static DateTime OTPExpiry
        {
            get
            {
                return DateTime.UtcNow.AddDays(1);
            }
        }

        public static string GenerateOTP()
        {
            Random r = new Random();
            return string.Format("{0}{1}{2}{3}{4}{5}", r.Next(0, 9), r.Next(0, 9), r.Next(0, 9), r.Next(0, 9), r.Next(0, 9), r.Next(0, 9));
        }

        public static void SendEmail(string toemail, string toname, string fromemail, string fromname, string Subject, string Body)
        {
            try
            {
                MimeMessage message = new MimeMessage();

                MailboxAddress from = new MailboxAddress(fromname, fromemail);
                message.From.Add(from);

                MailboxAddress to = new MailboxAddress(toname, toemail);
                message.To.Add(to);

                message.Subject = Subject;
                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = Body;
                bodyBuilder.TextBody = Body;
                //bodyBuilder.Attachments.Add(env.WebRootPath + "\\file.png");
                message.Body = bodyBuilder.ToMessageBody();
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("contactus@rudrasofttech.com", "Welcome1!");
                    client.Send(message);
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            catch(Exception ex) {
                throw ex;
            }
        }

        public static void SendSMS(string phone, string sms)
        {

        }
    }
}
