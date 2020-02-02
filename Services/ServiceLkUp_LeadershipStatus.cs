using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_LeadershipStatus: ILkUp_LeadershipStatusRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_LeadershipStatus> logger;    

        public ServiceLkUp_LeadershipStatus(AppDbContext context, ILogger<ServiceLkUp_LeadershipStatus> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_LeadershipStatus Add(LkUp_LeadershipStatus rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_LeadershipStatus.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_LeadershipStatus Delete(int id)
        {
            LkUp_LeadershipStatus rec = context.LkUp_LeadershipStatus.Find(id);
            if (rec != null)
            {
                context.LkUp_LeadershipStatus.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_LeadershipStatus> GetAllRecords()
        {
            return context.LkUp_LeadershipStatus;
        }

        public LkUp_LeadershipStatus GetRecord(int Id)
        {
            return context.LkUp_LeadershipStatus.Find(Id);
        }

        public LkUp_LeadershipStatus GetRecordByName(string name)
        {
            var rec = context.LkUp_LeadershipStatus
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_LeadershipStatus Update(LkUp_LeadershipStatus recChanges)
        {
            var rec = context.LkUp_LeadershipStatus.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}