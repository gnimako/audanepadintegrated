using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_CommsChannel : ILkUp_CommsChannelRepository
    {

        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_CommsChannel> logger;    

        public ServiceLkUp_CommsChannel(AppDbContext context, ILogger<ServiceLkUp_CommsChannel> logger)
        {
            this.context = context;
            this.logger = logger;
        }
    
        
        public LkUp_CommsChannel Add(LkUp_CommsChannel rec)
        {
            rec.CommsChannel_Id = GetAllCommsChannel().Count() + 1;
            context.LkUp_CommsChannel.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_CommsChannel Delete(int id)
        {
            LkUp_CommsChannel rec = context.LkUp_CommsChannel.Find(id);
            if (rec != null)
            {
                context.LkUp_CommsChannel.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_CommsChannel> GetAllCommsChannel()
        {
            return context.LkUp_CommsChannel;
        }

        public LkUp_CommsChannel GetCommsChannel(int Id)
        {
            return context.LkUp_CommsChannel.Find(Id);
        }

        public LkUp_CommsChannel GetCommsChannelByName(string name)
        {
            var rec = context.LkUp_CommsChannel
                                  .Where(s => s.CommsChannel_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_CommsChannel Update(LkUp_CommsChannel recChanges)
        {
            var rec = context.LkUp_CommsChannel.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}