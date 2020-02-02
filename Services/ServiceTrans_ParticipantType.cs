using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ParticipantType: ITrans_ParticipantTypeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ParticipantType> logger;
		public ServiceTrans_ParticipantType(AppDbContext context, ILogger<ServiceTrans_ParticipantType> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ParticipantType Add(Trans_ParticipantType rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ParticipantType.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ParticipantType Delete(string id)
		{
		    Trans_ParticipantType rec = context.Trans_ParticipantType.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ParticipantType.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ParticipantType> GetAllRecords()
		{
		    return context.Trans_ParticipantType;
		}

		public Trans_ParticipantType GetRecord(string Id)
		{
		    return context.Trans_ParticipantType.Find(Id);
		}

		public Trans_ParticipantType Update(Trans_ParticipantType recChanges)
		{
		    var satype = context.Trans_ParticipantType.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}