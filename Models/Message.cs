using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AUDANEPAD_Integrated.Interfaces;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;
using MailKit;
using MimeKit;

namespace AUDANEPAD_Integrated.Models
{
    public class Message
    {
            public List<MailboxAddress> To { get; set; }
            public string Subject { get; set; }
            public string Content { get; set; }
        
            public Message(IEnumerable<string> to, string subject, string content)
            {
                To = new List<MailboxAddress>();
        
                To.AddRange(to.Select(x => new MailboxAddress(x)));
                Subject = subject;
                Content = content;        
            }
        
    }
}