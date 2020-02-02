using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_ExtParticipantType: ILkUp_ExtParticipantTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_ExtParticipantType> logger;    

        public ServiceLkUp_ExtParticipantType(AppDbContext context, ILogger<ServiceLkUp_ExtParticipantType> logger)
        {
            this.context = context;
            this.logger = logger;
        }
    
        
        public LkUp_ExtParticipantType Add(LkUp_ExtParticipantType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_ExtParticipantType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_ExtParticipantType Delete(int id)
        {
            LkUp_ExtParticipantType rec = context.LkUp_ExtParticipantType.Find(id);
            if (rec != null)
            {
                context.LkUp_ExtParticipantType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_ExtParticipantType> GetAllRecords()
        {
            return context.LkUp_ExtParticipantType;
        }

        public LkUp_ExtParticipantType GetRecord(int Id)
        {
            return context.LkUp_ExtParticipantType.Find(Id);
        }

        public LkUp_ExtParticipantType GetRecordByName(string name)
        {
            var rec = context.LkUp_ExtParticipantType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_ExtParticipantType Update(LkUp_ExtParticipantType recChanges)
        {
            var rec = context.LkUp_ExtParticipantType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}