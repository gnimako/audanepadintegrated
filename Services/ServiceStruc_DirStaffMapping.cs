using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceStruc_DirStaffMapping: IStruc_DirStaffMappingRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceStruc_DirStaffMapping> logger;
		public ServiceStruc_DirStaffMapping(AppDbContext context, ILogger<ServiceStruc_DirStaffMapping> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Struc_DirStaffMapping Add(Struc_DirStaffMapping rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Struc_DirStaffMapping.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Struc_DirStaffMapping Delete(string id)
		{
		    Struc_DirStaffMapping rec = context.Struc_DirStaffMapping.Find(id);
		    if (rec != null)
		    {
		        context.Struc_DirStaffMapping.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Struc_DirStaffMapping> GetAllRecords()
		{
		    return context.Struc_DirStaffMapping;
		}
		public IEnumerable<Struc_DirStaffMapping> GetAllRecordsByDirectorate(int Directorate_Id)
        {
            var records = context.Struc_DirStaffMapping
                                .Where(s => s.Directorate_Id == Directorate_Id)
                                .ToList();

            return records;
        }
		public Struc_DirStaffMapping GetRecordByEmployeeAndDirectorate (int Employee_Id, int Directorate_Id)
        {
            var rec = context.Struc_DirStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id==Directorate_Id)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DirStaffMapping GetRecordByEmployeeAndPrimaryDirectorate (int Employee_Id)
        {
            var rec = context.Struc_DirStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.PrimaryDirectorate==true)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DirStaffMapping GetRecordByEmployeeAndThisPrimaryDirectorate (int Employee_Id, int Directorate_Id)
        {
            var rec = context.Struc_DirStaffMapping
                                  .Where(s => s.EmployeePK == Employee_Id && s.Directorate_Id == Directorate_Id && s.PrimaryDirectorate==true)
                                  .FirstOrDefault();
            return rec;
        }

		public Struc_DirStaffMapping GetRecord(string Id)
		{
		    return context.Struc_DirStaffMapping.Find(Id);
		}

		public Struc_DirStaffMapping Update(Struc_DirStaffMapping recChanges)
		{
		    var satype = context.Struc_DirStaffMapping.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}