using System;
using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceWP_Tasks: IWP_TasksRepository
    {
        private readonly AppDbContext context;
		private readonly ILogger<ServiceWP_Tasks> logger;
		public ServiceWP_Tasks (AppDbContext context, ILogger<ServiceWP_Tasks> logger)
		{
		    this.context = context;
		    this.logger = logger;
		}
		public WP_Tasks Add(WP_Tasks rec)
		{
		    rec.Transaction_Id = Guid.NewGuid().ToString();
		    context.WP_Tasks.Add(rec);
		    context.SaveChanges();
		    return rec;
		}

		public WP_Tasks Delete(string id)
		{
		    WP_Tasks rec = context.WP_Tasks.Find(id);
		    if (rec != null)
		    {
		        context.WP_Tasks.Remove(rec);
		        context.SaveChanges();
		    }
		    return rec;
		}

		public IEnumerable<WP_Tasks> GetAllRecords()
		{
		    return context.WP_Tasks;
		}
		
        public IEnumerable<WP_Tasks> GetRecordsByCategoryMain (string recid)
        {
            var records = context.WP_Tasks
                                .Where(s => s.WPCategoryMain==recid)
                                .ToList();

            return records;
        }
        public IEnumerable<WP_Tasks> GetRecordsByDirDivDeptTypeAndStatus (int dirid, int divid, string depttype, string status)
        {
            var records = context.WP_Tasks
                                .Where(s => s.WPDirectorate_Id==dirid && s.WPDivision_Id==divid && s.WPResponsibleDeptType==depttype && s.WPTaskStatus==status)
                                .ToList();

            return records;
        }
		public IEnumerable<WP_Tasks> GetRecordsByCategoryDirDivDeptTypeAndStatus (string category, int dirid, int divid, string depttype, string status)
        {
            var records = context.WP_Tasks
                                .Where(s => s.WPCategoryMain==category && s.WPDirectorate_Id==dirid && s.WPDivision_Id==divid && s.WPResponsibleDeptType==depttype && s.WPTaskStatus==status)
                                .ToList();

            return records;
        }

		public IEnumerable<WP_Tasks> GetRecordsByReference_Id (string recid)
        {
            var records = context.WP_Tasks
                                .Where(s => s.WPReference_Id==recid)
                                .ToList();

            return records;
        }

		

		public WP_Tasks GetRecordByCategoryReferenceIdSubcategory1AndTask (string category, string referenceid, string subcategory1, string task)
        {
            var rec = context.WP_Tasks
						.Where(s => s.WPCategoryMain == category && s.WPReference_Id==referenceid && s.WPCategorySub1==subcategory1 && s.WPTaskDescription==task)
						.FirstOrDefault();
            return rec;
        }

		public WP_Tasks GetRecordByCategoryReferenceIdAndStatus (string category, string referenceid, string status)
        {
            var rec = context.WP_Tasks
						.Where(s => s.WPCategoryMain == category && s.WPReference_Id==referenceid && s.WPTaskStatus==status)
						.FirstOrDefault();
            return rec;
        }

		public WP_Tasks GetRecordByCategoryReferenceIdDirDivDeptTypeAndStatus (string category, string referenceid,  int dirid, int divid, string depttype, string status)
        {
            var rec = context.WP_Tasks
						.Where(s => s.WPCategoryMain == category && s.WPReference_Id==referenceid && s.WPDirectorate_Id==dirid && s.WPDivision_Id==divid && s.WPResponsibleDeptType==depttype && s.WPTaskStatus==status)
						.FirstOrDefault();
            return rec;
        }

		public WP_Tasks GetRecordBySubcategory1ReferenceIdAndStatus (string subcategory1, string referenceid, string status)
        {
            var rec = context.WP_Tasks
						.Where(s => s.WPCategorySub1 == subcategory1 && s.WPReference_Id==referenceid && s.WPTaskStatus==status)
						.FirstOrDefault();
            return rec;
        }

		public WP_Tasks GetRecordBySubcategory1ReferenceIdDirDivDeptTypeAndStatus (string subcategory1, string referenceid, int dirid, int divid, string depttype, string status)
        {
            var rec = context.WP_Tasks
						.Where(s => s.WPCategorySub1 == subcategory1 && s.WPReference_Id==referenceid && s.WPDirectorate_Id==dirid && s.WPDivision_Id==divid && s.WPResponsibleDeptType==depttype && s.WPTaskStatus==status)
						.FirstOrDefault();
            return rec;
        }

		

		public WP_Tasks GetRecord(string Id)
		{
		    return context.WP_Tasks.Find(Id);
		}


        public WP_Tasks Update(WP_Tasks recChanges)
		{
		    var satype = context.WP_Tasks.Attach(recChanges);
		    satype.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
		    context.SaveChanges();
		    return recChanges;
		}
        
    }
}