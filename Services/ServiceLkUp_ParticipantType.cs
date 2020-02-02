using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ParticipantType: ILkUp_ParticipantTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ParticipantType> logger;    

        public ServiceLkUp_ParticipantType(AppDbContext context, ILogger<ServiceLkUp_ParticipantType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_ParticipantType Add(LkUp_ParticipantType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ParticipantType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ParticipantType Delete(int id)
        {
            LkUp_ParticipantType rec = context.LkUp_ParticipantType.Find(id);
            if (rec != null)
            {
                context.LkUp_ParticipantType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ParticipantType> GetAllRecords()
        {
            return context.LkUp_ParticipantType;
        }

        public LkUp_ParticipantType GetRecord(int Id)
        {
            return context.LkUp_ParticipantType.Find(Id);
        }

        public LkUp_ParticipantType GetRecordByName(string name)
        {
            var rec = context.LkUp_ParticipantType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ParticipantType Update(LkUp_ParticipantType recChanges)
        {
            var rec = context.LkUp_ParticipantType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}