using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementLTime : ITrans_ProcurementLTimeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementLTime> logger;
		public ServiceTrans_ProcurementLTime(AppDbContext context, ILogger<ServiceTrans_ProcurementLTime> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementLTime Add(Trans_ProcurementLTime rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementLTime.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProcurementLTime Delete(string id)
		{
		    Trans_ProcurementLTime rec = context.Trans_ProcurementLTime.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementLTime.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementLTime> GetAllRecords()
		{
		    return context.Trans_ProcurementLTime;
		}

		public Trans_ProcurementLTime GetRecord(string Id)
		{
		    return context.Trans_ProcurementLTime.Find(Id);
		}

		public Trans_ProcurementLTime Update(Trans_ProcurementLTime recChanges)
		{
		    var satype = context.Trans_ProcurementLTime.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}