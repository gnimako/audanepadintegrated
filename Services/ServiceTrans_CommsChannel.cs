using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_CommsChannel : ITrans_CommsChannelRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_CommsChannel> logger;
        public ServiceTrans_CommsChannel(AppDbContext context, ILogger<ServiceTrans_CommsChannel> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Trans_CommsChannel Add(Trans_CommsChannel rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_CommsChannel.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_CommsChannel Delete(string id)
        {
            Trans_CommsChannel rec = context.Trans_CommsChannel.Find(id);
            if (rec != null)
            {
                context.Trans_CommsChannel.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_CommsChannel> GetAllTrans_CommsChannel()
        {
            return context.Trans_CommsChannel;
        }

        public Trans_CommsChannel GetTrans_CommsChannel(string Id)
        {
            return context.Trans_CommsChannel.Find(Id);
        }

        public Trans_CommsChannel Update(Trans_CommsChannel recChanges)
        {
            var rec = context.Trans_CommsChannel.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}