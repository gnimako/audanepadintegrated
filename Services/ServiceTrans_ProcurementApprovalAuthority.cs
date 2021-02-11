using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_ProcurementApprovalAuthority: ITrans_ProcurementApprovalAuthorityRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_ProcurementApprovalAuthority> logger;
		public ServiceTrans_ProcurementApprovalAuthority(AppDbContext context, ILogger<ServiceTrans_ProcurementApprovalAuthority> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_ProcurementApprovalAuthority Add(Trans_ProcurementApprovalAuthority rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_ProcurementApprovalAuthority.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_ProcurementApprovalAuthority Delete(string id)
		{
		    Trans_ProcurementApprovalAuthority rec = context.Trans_ProcurementApprovalAuthority.Find(id);
		    if (rec != null)
		    {
		        context.Trans_ProcurementApprovalAuthority.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_ProcurementApprovalAuthority> GetAllRecords()
		{
		    return context.Trans_ProcurementApprovalAuthority;
		}

		public Trans_ProcurementApprovalAuthority GetRecord(string Id)
		{
		    return context.Trans_ProcurementApprovalAuthority.Find(Id);
		}

		public Trans_ProcurementApprovalAuthority Update(Trans_ProcurementApprovalAuthority recChanges)
		{
		    var satype = context.Trans_ProcurementApprovalAuthority.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}