using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementProcessSteps: ITrans_ProcurementProcessStepsRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementProcessSteps> logger;

		public ServiceTrans_ProcurementProcessSteps(AppDbContext context, ILogger<ServiceTrans_ProcurementProcessSteps> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementProcessSteps Add(Trans_ProcurementProcessSteps rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementProcessSteps.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProcurementProcessSteps Delete(string id)
		{
		    Trans_ProcurementProcessSteps rec = context.Trans_ProcurementProcessSteps.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementProcessSteps.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementProcessSteps> GetAllRecords()
		{
		    return context.Trans_ProcurementProcessSteps;
		}
        public IEnumerable<Trans_ProcurementProcessSteps> GetAllRecordsByType(string recid)
        {
            var records = context.Trans_ProcurementProcessSteps
                                .Where(s => s.Record_Type == recid)
                                .ToList();

            return records;
        }

		public Trans_ProcurementProcessSteps GetRecord(string Id)
		{
		    return context.Trans_ProcurementProcessSteps.Find(Id);
		}

		public Trans_ProcurementProcessSteps Update(Trans_ProcurementProcessSteps recChanges)
		{
		    var satype = context.Trans_ProcurementProcessSteps.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}

        
    }
}