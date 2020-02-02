using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    
    public class ServiceTrans_FiscalYear: ITrans_FiscalYearRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_FiscalYear> logger;
		public ServiceTrans_FiscalYear(AppDbContext context, ILogger<ServiceTrans_FiscalYear> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_FiscalYear Add(Trans_FiscalYear rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_FiscalYear.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_FiscalYear Delete(string id)
		{
		    Trans_FiscalYear rec = context.Trans_FiscalYear.Find(id);
		    if (rec != null)
		    {
		        context.Trans_FiscalYear.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_FiscalYear> GetAllRecords()
		{
		    return context.Trans_FiscalYear;
		}

		public Trans_FiscalYear GetRecord(string Id)
		{
		    return context.Trans_FiscalYear.Find(Id);
		}

		public Trans_FiscalYear Update(Trans_FiscalYear recChanges)
		{
		    var satype = context.Trans_FiscalYear.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
        
    }
}