using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Authorization;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.Interfaces;
using AUDANEPAD_Integrated.Services;
using Newtonsoft.Json.Serialization;

namespace AUDANEPAD_Integrated
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
             _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _config["DbContextSettings:ConnectionString"];
            services.AddDbContext<AppDbContext>(
                opts => opts.UseNpgsql(connectionString)
            );

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                //options.Authentication.CookieLifetime = TimeSpan.FromHours(2); 
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                //options.ExpireTimeSpan = TimeSpan.FromSeconds(5);
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.SlidingExpiration = true;
            });

         

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });


            services.AddControllersWithViews();
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });


             services.AddMvc().AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.PropertyNamingPolicy = null;
                    o.JsonSerializerOptions.DictionaryKeyPolicy = null;
                });
            //o.JsonSerializerOptions.PropertyNameCaseInsensitive = false;

            
            // services.AddMvc(config => {
            //     var policy = new AuthorizationPolicyBuilder()
            //                     .RequireAuthenticatedUser()
            //                     .Build();
            //     config.Filters.Add(new AuthorizeFilter(policy));
            // }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            //   .AddNewtonsoftJson(options =>
            //   {
            //         options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //   });

            services.AddScoped<IEmployeeRepository, ServiceEmployee>();

            services.AddScoped<ILkUp_ActivityTypeRepository, ServiceLkUp_ActivityType>();
            services.AddScoped<ILkUp_DSATypeRepository, ServiceLkUp_DSAType>();
            services.AddScoped<ILkUp_CostCatelogueRepository, ServiceLkUp_CostCatelogue>();
            services.AddScoped<ILkUp_CommsChannelRepository, ServiceLkUp_CommsChannel>();
            services.AddScoped<ILkUp_CountryRepository, ServiceLkUp_Country>();
            services.AddScoped<ILkUp_ExtParticipantTypeRepository, ServiceLkUp_ExtParticipantType>();
            services.AddScoped<ILkUp_FiscalYearRepository, ServiceLkUp_FiscalYear>();
            services.AddScoped<ILkUp_ImplementationTypeRepository, ServiceLkUp_ImplementationType>();
            services.AddScoped<ILkUp_LeadershipStatusRepository, ServiceLkUp_LeadershipStatus>();
            services.AddScoped<ILkUp_ParticipantTypeRepository, ServiceLkUp_ParticipantType>();
            services.AddScoped<ILkUp_ProcurementTypeRepository, ServiceLkUp_ProcurementType>();
            services.AddScoped<ILkUp_RiskCategoryRepository, ServiceLkUp_RiskCategory>();
            services.AddScoped<ILkUp_RiskImpactRepository, ServiceLkUp_RiskImpact>();
            services.AddScoped<ILkUp_RiskProbabilityRepository, ServiceLkUp_RiskProbability>();
            services.AddScoped<ILkUp_RiskRTimeframeRepository, ServiceLkUp_RiskRTimeframe>();
            services.AddScoped<ILkUp_PeopleTypeRepository, ServiceLkUp_PeopleType>();
            services.AddScoped<ILkUp_ProcurementLTimeRepository, ServiceLkUp_ProcurementLTime>();
            services.AddScoped<ILkUp_ProjectScopeRepository, ServiceLkUp_ProjectScope>();
            services.AddScoped<ILkUp_RegionScopeRepository, ServiceLkUp_RegionScope>();
            services.AddScoped<IStrategy_PriorityRepository, ServiceStrategy_Priority>();
            services.AddScoped<IStrategy_MTPRepository, ServiceStrategy_MTP>();
            services.AddScoped<IStrategy_MTPPriorityMappingRepository, ServiceStrategy_MTPPriorityMapping>();
            services.AddScoped<IStrategy_KeyPerformanceAreaRepository, ServiceStrategy_KeyPerformanceArea>();
            services.AddScoped<IStrategy_OutputIndicatorsRepository, ServiceStrategy_OutputIndicators>();
            services.AddScoped<IStrategy_OutputIndicatorsPriorityMappingRepository, ServiceStrategy_OutputIndicatorsPriorityMapping>();
            services.AddScoped<IStruc_DirectorateRepository, ServiceStruc_Directorate>();
            services.AddScoped<IStruc_DivisionRepository, ServiceStruc_Division>();
            services.AddScoped<ILkUp_ProgrammeRepository, ServiceLkUp_Programme>();
            services.AddScoped<ILkUp_ProjectRepository, ServiceLkUp_Project>();
            services.AddScoped<ILkUp_PeriodRepository, ServiceLkUp_Period>();
            


            services.AddScoped<ITrans_ActivityTypeRepository, ServiceTrans_ActivityType>();
            services.AddScoped<ITrans_DSATypeRepository, ServiceTrans_DSAType>();
            services.AddScoped<ITrans_CostCatelogueRepository, ServiceTrans_CostCatelogue>();
            services.AddScoped<ITrans_CommsChannelRepository, ServiceTrans_CommsChannel>();
            services.AddScoped<ITrans_CountryRepository, ServiceTrans_Country>();
            services.AddScoped<ITrans_ExtParticipantTypeRepository, ServiceTrans_ExtParticipantType>();
            services.AddScoped<ITrans_FiscalYearRepository, ServiceTrans_FiscalYear>();
            services.AddScoped<ITrans_ImplementationTypeRepository, ServiceTrans_ImplementationType>();
            services.AddScoped<ITrans_LeadershipStatusRepository, ServiceTrans_LeadershipStatus>();
            services.AddScoped<ITrans_ParticipantTypeRepository, ServiceTrans_ParticipantType>();
            services.AddScoped<ITrans_ProcurementTypeRepository, ServiceTrans_ProcurementType>();
            services.AddScoped<ITrans_RiskCategoryRepository, ServiceTrans_RiskCategory>();
            services.AddScoped<ITrans_RiskImpactRepository, ServiceTrans_RiskImpact>();
            services.AddScoped<ITrans_RiskProbabilityRepository, ServiceTrans_RiskProbability>();
            services.AddScoped<ITrans_RiskRTimeframeRepository, ServiceTrans_RiskRTimeframe>();
            services.AddScoped<ITrans_PeopleTypeRepository, ServiceTrans_PeopleType>();
            services.AddScoped<ITrans_ProcurementLTimeRepository, ServiceTrans_ProcurementLTime>();
            services.AddScoped<ITrans_ProjectScopeRepository, ServiceTrans_ProjectScope>();
            services.AddScoped<ITrans_RegionScopeRepository, ServiceTrans_RegionScope>();
            services.AddScoped<ITrans_StrategyPriorityRepository, ServiceTrans_StrategyPriority>();
            services.AddScoped<ITrans_StrategyMTPRepository, ServiceTrans_StrategyMTPRepository>();
            services.AddScoped<ITrans_StrategyKeyPerformanceAreaRepository, ServiceTrans_StrategyKeyPerformanceArea>();
            services.AddScoped<ITrans_StrategyOutputIndicators, ServiceTrans_StrategyOutputIndicators>();
            services.AddScoped<ITrans_StrucDirectorateRepository, ServiceTrans_StrucDirectorate>();
            services.AddScoped<ITrans_StrucDivisionRepository, ServiceTrans_StrucDivision>();
            services.AddScoped<IStruc_DirStaffMappingRepository, ServiceStruc_DirStaffMapping>();
            services.AddScoped<IStruc_DivStaffMappingRepository, ServiceStruc_DivStaffMapping>();
            services.AddScoped<IStruc_DirectorRepository, ServiceStruc_Director>();
            services.AddScoped<IStruc_DirectorOICRepository, ServiceStruc_DirectorOIC>();
            services.AddScoped<IStruc_DivHeadRepository, ServiceStruc_DivHead>();
            services.AddScoped<IStruc_DivHeadOICRepository, ServiceStruc_DivHeadOIC>();
            services.AddScoped<ITrans_ProgrammeRepository, ServiceTrans_Programme>();
            services.AddScoped<ITrans_ProjectRepository, ServiceTrans_Project>();
            services.AddScoped<ITrans_PeriodRepository, ServiceTrans_Period>();
            services.AddScoped<ISystem_AuditRepository, ServiceSystem_Audit>();

            
            
            services.AddScoped<IEmailSender, ServiceEmailSender>();

            //Workplans
            services.AddScoped<IWP_DispatchRepository, ServiceWP_Dispatch>();
            services.AddScoped<IWP_MainRecordRepository, ServiceWP_MainRecord>();
            services.AddScoped<IWP_OutcomesRepository, ServiceWP_Outcomes>();
            services.AddScoped<IWP_MTPRepository, ServiceWP_MTP>();
            services.AddScoped<IWP_AUDAPriorityRepository, ServiceWP_AUDAPriority>();
            services.AddScoped<IWP_ApprovalStatusRepository, ServiceWP_ApprovalStatus>();
            services.AddScoped<IWP_RegionScopeRepository, ServiceWP_RegionScope>();
            services.AddScoped<IWP_CountryScopeRepository, ServiceWP_CountryScope>();
            services.AddScoped<IWP_OutputsRepository, ServiceWP_Outputs>();
            services.AddScoped<IWP_OutputIndicatorsRepository, ServiceWP_OutputIndicators>();



            


            var emailConfig = Configuration
                                .GetSection("EmailConfiguration")
                                .Get<EmailConfiguration>();
                                services.AddSingleton(emailConfig);
           

           
        

           services.AddKendo();


           // services.AddControllers();
            //services.AddRazorPages();
            
           // services.AddMvc(options => options.EnableEndpointRouting = false);
           // services.AddMvc().AddRazorRuntimeCompilation()
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
           // {
                app.UseDeveloperExceptionPage();
            //}
            // else
            // {
            //     app.UseExceptionHandler("/Home/Error");
            //     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //     app.UseHsts();
            // }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            // });


            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllerRoute(
            //         name: "default",
            //         pattern: "{controller=Home}/{action=Index}/{id?}");
            // });

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
          
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");




               // endpoints.MapRazorPages();
                
            });
        }
    }
}
