using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    //Направляет на использование сервиса
    public class EmailService
    {
        public class Email
        {
            public string? From, To, Subject, Body;
        }
        public class EmailBuilder
        {
            private readonly Email email;
            public EmailBuilder(Email email)
            {
                this.email = email;
            }

            public EmailBuilder From(string from)
            {
                email.From = from;
                return this;
            }

            public EmailBuilder To(string to)
            {
                email.To = to;
                return this;
            }

            public EmailBuilder Subject(string subject)
            {
                email.Subject = subject;
                return this;
            }

            public EmailBuilder Body(string body)
            {
                email.Body = body;
                return this;
            }
        }

        private void SendEmailInternal(Email email)
        {

        }
        public void SendEmail(Action<EmailBuilder> builder)
        {
            var email = new Email();
            builder(new EmailBuilder(email));
            SendEmailInternal(email);
        }
    }

}


