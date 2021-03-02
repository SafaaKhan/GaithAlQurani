using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaithAlQuraniProject.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }


        public async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient("c662bdad726ad22411cd5f010dc0c0a5", "067cfb360060d836025f8cd4473ce1e2")
            {

            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From",
       new JObject {
        {"Email", "safa.199841@gmail.com"},
        {"Name", "Gaith"}
       }
      }, {
       "To",
       new JArray {
        new JObject {
         {
          "Email",
          email
         }, {
          "Name",
          "Gaith"
         }
        }
       }
      }, {
       "Subject",
       subject
      }, {
       "HTMLPart",
       //"<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"
       body
      },
     }
             });
            MailjetResponse response = await client.PostAsync(request);
        }
           
    }

}