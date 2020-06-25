using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AUDANEPAD_Integrated.Services
{
    public class ServiceTrans_Project: ITrans_ProjectRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceTrans_Project> logger;
        
		public ServiceTrans_Project(AppDbContext context, ILogger<ServiceTrans_Project> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public Trans_Project Add(Trans_Project rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.Trans_Project.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public Trans_Project Delete(string id)
		{
        
		    Trans_Project rec = context.Trans_Project.Find(id);

		    if (rec != null)
		    {
		        context.Trans_Project.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<Trans_Project> GetAllRecords()
		{
		    return context.Trans_Project;
		}
        public IEnumerable<Trans_Project> GetAllRecordsByTransProgrammeID(string TransID)
        {
            var records = context.Trans_Project
                                .Where(s => s.TransProgramme_Id == TransID)
                                .ToList();

            return records;
        }
        public IEnumerable<Trans_Project> GetAllRecordsByProgrammeID(int Id)
        {
            var records = context.Trans_Project
                                .Where(s => s.MainProgramme_Id == Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Trans_Project> GetAllRecordsByDirectorateID(int Id)
        {
            var records = context.Trans_Project
                                .Where(s => s.Directorate_Id == Id)
                                .ToList();

            return records;
        }

        public IEnumerable<Trans_Project> GetAllRecordsByDivisionID(int Id)
        {
            var records = context.Trans_Project
                                .Where(s => s.Division_Id == Id)
                                .ToList();

            return records;
        }

        public Trans_Project GetRecord(string Id)
		{
		    return context.Trans_Project.Find(Id);
		}

		public Trans_Project Update(Trans_Project recChanges)
		{
		    var satype = context.Trans_Project.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}