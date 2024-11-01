﻿using System;
using System.Net;
using System.Net.Mail;

namespace Utilities.StaticHelpers
{
    public static class Email
    {
        public static void Send(string displayName, string to, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("agamytest2020@gmail.com", displayName);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("agamytest2020@gmail.com", @"dkw47@W.\`EfRf7~");
                  
                    try
                    {
                        smtp.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }


        }
    }
}
