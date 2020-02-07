using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_RegionScope : ITrans_RegionScopeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_RegionScope> logger;
		public ServiceTrans_RegionScope(AppDbContext context, ILogger<ServiceTrans_RegionScope> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_RegionScope Add(Trans_RegionScope rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_RegionScope.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_RegionScope Delete(string id)
		{
		    Trans_RegionScope rec = context.Trans_RegionScope.Find(id);
		    if (rec != null)
		    {
		        context.Trans_RegionScope.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_RegionScope> GetAllRecords()
		{
		    return context.Trans_RegionScope;
		}

		public Trans_RegionScope GetRecord(string Id)
		{
		    return context.Trans_RegionScope.Find(Id);
		}

		public Trans_RegionScope Update(Trans_RegionScope recChanges)
		{
		    var satype = context.Trans_RegionScope.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}