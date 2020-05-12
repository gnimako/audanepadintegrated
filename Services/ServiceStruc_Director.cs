using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_Director: IStruc_DirectorRepository
    {

        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_Director> logger;
		public ServiceStruc_Director(AppDbContext context, ILogger<ServiceStruc_Director> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_Director Add(Struc_Director rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_Director.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_Director Delete(string id)
		{
		    Struc_Director rec = context.Struc_Director.Find(id);
		    if (rec != null)
		    {
		        context.Struc_Director.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_Director> GetAllRecords()
		{
		    return context.Struc_Director;
		}
		public IEnumerable<Struc_Director> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Struc_Director
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }
		public Struc_Director GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id)
        {
            var rec = context.Struc_Director
                                  .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id==Directorate_Id)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_Director GetRecord(string Id)
		{
		    return context.Struc_Director.Find(Id);
		}

		public Struc_Director Update(Struc_Director recChanges)
		{
		    var satype = context.Struc_Director.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}