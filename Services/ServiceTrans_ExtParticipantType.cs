using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ExtParticipantType: ITrans_ExtParticipantTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceTrans_ExtParticipantType> logger;
        public ServiceTrans_ExtParticipantType(AppDbContext context, ILogger<ServiceTrans_ExtParticipantType> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public Trans_ExtParticipantType Add(Trans_ExtParticipantType rec)
        {
            rec.Transaction_Id = Guid.NewGuid().ToString();
            context.Trans_ExtParticipantType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public Trans_ExtParticipantType Delete(string id)
        {
            Trans_ExtParticipantType rec = context.Trans_ExtParticipantType.Find(id);
            if (rec != null)
            {
                context.Trans_ExtParticipantType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<Trans_ExtParticipantType> GetAllRecords()
        {
            return context.Trans_ExtParticipantType;
        }

        public Trans_ExtParticipantType GetRecord(string Id)
        {
            return context.Trans_ExtParticipantType.Find(Id);
        }

        public Trans_ExtParticipantType Update(Trans_ExtParticipantType recChanges)
        {
            var satype = context.Trans_ExtParticipantType.Attach(recChanges);
            satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}