using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using B2BService.Domain.Coparate;
using B2BService.ViewModels.Organisazion;

namespace B2BService.Repository
{
    public class MessagingService
    {
        public static void SendMailAsync(EmailSettings Obj , EmailVM objemailvm, string path) {
            var fromAddress = new MailAddress(Obj.InfoEmail, "Techthrong");
            var toAddress = new MailAddress(objemailvm.ToAddress, "Hacker Name");
            string fromPassword = Obj.FromPassword;
            string subject = Obj.Subject;
            string body = "You’re receiving this message because you recently signed up for a Shopify account." +
                           "Confirm your email address by clicking the button below.This step adds extra security to your business by verifying you own this email."+
                           path + objemailvm.UserId;

            var smtp = new SmtpClient
            {
                Host = Obj.Host, // "smtp.gmail.com",
                Port = int.Parse(Obj.Port),
                EnableSsl = Obj.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = Obj.UseDefaultCredentials,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
