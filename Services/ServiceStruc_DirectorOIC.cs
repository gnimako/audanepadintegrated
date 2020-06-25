using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DirectorOIC: IStruc_DirectorOICRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_DirectorOIC> logger;
		public ServiceStruc_DirectorOIC(AppDbContext context, ILogger<ServiceStruc_DirectorOIC> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_DirectorOIC Add(Struc_DirectorOIC rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_DirectorOIC.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_DirectorOIC Delete(string id)
		{
		    Struc_DirectorOIC rec = context.Struc_DirectorOIC.Find(id);
		    if (rec != null)
		    {
		        context.Struc_DirectorOIC.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_DirectorOIC> GetAllRecords()
		{
		    return context.Struc_DirectorOIC;
		}
		public IEnumerable<Struc_DirectorOIC> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Struc_DirectorOIC
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }
		public Struc_DirectorOIC GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id)
        {
            var rec = context.Struc_DirectorOIC
                                  .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id==Directorate_Id)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DirectorOIC GetRecord(string Id)
		{
		    return context.Struc_DirectorOIC.Find(Id);
		}

		public Struc_DirectorOIC Update(Struc_DirectorOIC recChanges)
		{
		    var satype = context.Struc_DirectorOIC.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}