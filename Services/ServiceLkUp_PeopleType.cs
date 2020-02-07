using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_PeopleType: ILkUp_PeopleTypeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_PeopleType> logger;    

        public ServiceLkUp_PeopleType(AppDbContext context, ILogger<ServiceLkUp_PeopleType> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public LkUp_PeopleType Add(LkUp_PeopleType rec)
        {
            rec.Record_Id = GetAllRecords().Count() + 1;
            context.LkUp_PeopleType.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_PeopleType Delete(int id)
        {
            LkUp_PeopleType rec = context.LkUp_PeopleType.Find(id);
            if (rec != null)
            {
                context.LkUp_PeopleType.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_PeopleType> GetAllRecords()
        {
            return context.LkUp_PeopleType;
        }

        public LkUp_PeopleType GetRecord(int Id)
        {
            return context.LkUp_PeopleType.Find(Id);
        }

        public LkUp_PeopleType GetRecordByName(string name)
        {
            var rec = context.LkUp_PeopleType
                                  .Where(s => s.Record_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_PeopleType Update(LkUp_PeopleType recChanges)
        {
            var rec = context.LkUp_PeopleType.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
        
    }
}