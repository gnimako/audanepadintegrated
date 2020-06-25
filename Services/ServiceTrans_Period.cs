using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_Period: ITrans_PeriodRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_Period> logger;
		public ServiceTrans_Period(AppDbContext context, ILogger<ServiceTrans_Period> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_Period Add(Trans_Period rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_Period.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_Period Delete(string id)
		{
		    Trans_Period rec = context.Trans_Period.Find(id);
		    if (rec != null)
		    {
		        context.Trans_Period.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_Period> GetAllRecords()
		{
		    return context.Trans_Period;
		}

		public Trans_Period GetRecord(string Id)
		{
		    return context.Trans_Period.Find(Id);
		}

		public Trans_Period Update(Trans_Period recChanges)
		{
		    var satype = context.Trans_Period.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}