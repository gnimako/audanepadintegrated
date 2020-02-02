using System.Linq;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace AUDANEPAD_Integrated.Services
{
    public class ServiceLkUp_Country : ILkUp_CountryRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<ServiceLkUp_Country> logger;
        public ServiceLkUp_Country(AppDbContext context, ILogger<ServiceLkUp_Country> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public LkUp_Country Add(LkUp_Country rec)
        {
            rec.Country_Id = GetAllCountry().Count() + 1;
            context.LkUp_Country.Add(rec);
            context.SaveChanges();
            return rec;
        }

        public LkUp_Country Delete(int id)
        {
            LkUp_Country rec = context.LkUp_Country.Find(id);
            if (rec != null)
            {
                context.LkUp_Country.Remove(rec);
                context.SaveChanges();
            }
            return rec;
        }

        public IEnumerable<LkUp_Country> GetAllCountry()
        {
            return context.LkUp_Country;
        }

        public LkUp_Country GetCountry(int Id)
        {
            return context.LkUp_Country.Find(Id);
        }

        public LkUp_Country GetCountryByName(string name)
        {
            var rec = context.LkUp_Country
                                  .Where(s => s.Country_Name == name)
                                  .FirstOrDefault();
            return rec;
        }

        public LkUp_Country Update(LkUp_Country recChanges)
        {
            var rec = context.LkUp_Country.Attach(recChanges);
            rec.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return recChanges;
        }
    }
}