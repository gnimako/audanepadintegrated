using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProjectScope : ITrans_ProjectScopeRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProjectScope> logger;
		public ServiceTrans_ProjectScope(AppDbContext context, ILogger<ServiceTrans_ProjectScope> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProjectScope Add(Trans_ProjectScope rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProjectScope.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProjectScope Delete(string id)
		{
		    Trans_ProjectScope rec = context.Trans_ProjectScope.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProjectScope.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProjectScope> GetAllRecords()
		{
		    return context.Trans_ProjectScope;
		}

		public Trans_ProjectScope GetRecord(string Id)
		{
		    return context.Trans_ProjectScope.Find(Id);
		}

		public Trans_ProjectScope Update(Trans_ProjectScope recChanges)
		{
		    var satype = context.Trans_ProjectScope.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}