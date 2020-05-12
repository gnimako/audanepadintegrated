using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;
using MailKit;

namespace AUDANEPAD_Integrated.Models
{
    public class EmailConfiguration
    {
            public string From { get; set; }
            public string SmtpServer { get; set; }
            public int Port { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        
    }
}