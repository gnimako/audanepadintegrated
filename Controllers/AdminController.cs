using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AUDANEPAD_Integrated.Interfaces;
using AUDANEPAD_Integrated.Models;
using AUDANEPAD_Integrated.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NodaTime;


namespace AUDANEPAD_Integrated.Controllers
{

    public class AdminController: Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILkUp_ActivityTypeRepository _lkupActivityTypeRepository;
        private readonly ILkUp_DSATypeRepository _lkupDSATypeRepository;
        private readonly ILkUp_CostCatelogueRepository _lkupCostCatelogueRepository ;
        private readonly ILkUp_CommsChannelRepository _lkupCommsChannelRepository ;
        private readonly ILkUp_CountryRepository _lkupCountryRepository ;
        private readonly ILkUp_ExtParticipantTypeRepository _lkupExtParticipantTypeRepository ;
        private readonly ILkUp_FiscalYearRepository _lkupFiscalYearRepository ;
        private readonly ILkUp_ImplementationTypeRepository _lkupImplementationTypeRepository  ;
        private readonly ILkUp_LeadershipStatusRepository _lkupLeadershipStatusRepository ;
        private readonly ILkUp_ParticipantTypeRepository _lkupParticipantTypeRepository ;
        private readonly ILkUp_ProcurementTypeRepository _lkupProcurementTypeRepository ;
        private readonly ILkUp_RiskCategoryRepository _lkupRiskCategoryRepository ;
        private readonly ILkUp_RiskImpactRepository _lkupRiskImpactRepository ;
        private readonly ILkUp_RiskProbabilityRepository _lkupRiskProbabilityRepository ;
        private readonly ILkUp_RiskRTimeframeRepository _lkupRiskRTimeframeRepository ;
        private readonly ILkUp_PeopleTypeRepository _lkupPeopleTypeRepository ;
        private readonly ILkUp_ProcurementLTimeRepository _lkupProcurementLTimeRepository ;
        private readonly ILkUp_ProjectScopeRepository _lkupProjectScopeRepository ;
        private readonly ILkUp_RegionScopeRepository _lkupRegionScopeRepository ;


        private readonly ITrans_ActivityTypeRepository _transActivityTypeRepository;
        private readonly ITrans_DSATypeRepository _transDSATypeRepository;
        private readonly ITrans_CostCatelogueRepository _transCostCatelogueRepository;
        private readonly ITrans_CommsChannelRepository _transCommsChannelRepository;
        private readonly ITrans_CountryRepository _transCountryRepository;
        private readonly ITrans_ExtParticipantTypeRepository _transExtParticipantTypeRepository ;
        private readonly ITrans_FiscalYearRepository _transFiscalYearRepository ;
        private readonly ITrans_ImplementationTypeRepository _transImplementationTypeRepository  ;
        private readonly ITrans_LeadershipStatusRepository _transLeadershipStatusRepository ;
        private readonly ITrans_ParticipantTypeRepository _transParticipantTypeRepository ;
        private readonly ITrans_ProcurementTypeRepository _transProcurementTypeRepository ;
        private readonly ITrans_RiskCategoryRepository _transRiskCategoryRepository  ;
        private readonly ITrans_RiskImpactRepository _transRiskImpactRepository;
        private readonly ITrans_RiskProbabilityRepository _transRiskProbabilityRepository ;
        private readonly ITrans_RiskRTimeframeRepository _transRiskRTimeframeRepository ;
        private readonly ITrans_PeopleTypeRepository _transPeopleTypeRepository ;
        private readonly ITrans_ProcurementLTimeRepository _transProcurementLTimeRepository;
        private readonly ITrans_ProjectScopeRepository _transProjectScopeRepository ;
        private readonly ITrans_RegionScopeRepository _transRegionScopeRepository ;



        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment hostingEnvironment;

         public AdminController(IEmployeeRepository employeeRepository,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<ApplicationUser> signInManager,
                                AppDbContext context,
                                IWebHostEnvironment hostingEnvironment,
                                ILkUp_ActivityTypeRepository lkupActivityTypeRepository,
                                ILkUp_DSATypeRepository lkupDSATypeRepository,
                                ILkUp_CostCatelogueRepository lkupCostCatelogueRepository,
                                ILkUp_CommsChannelRepository lkupCommsChannelRepository,
                                ILkUp_CountryRepository lkupCountryRepository,
                                ILkUp_ExtParticipantTypeRepository lkupExtParticipantTypeRepository,
                                ILkUp_FiscalYearRepository lkupFiscalYearRepository,
                                ILkUp_ImplementationTypeRepository lkupImplementationTypeRepository,
                                ILkUp_LeadershipStatusRepository lkupLeadershipStatusRepository,
                                ILkUp_ParticipantTypeRepository lkupParticipantTypeRepository,
                                ILkUp_ProcurementTypeRepository lkupProcurementTypeRepository, 
                                ILkUp_RiskCategoryRepository lkupRiskCategoryRepository, 
                                ILkUp_RiskImpactRepository lkupRiskImpactRepository, 
                                ILkUp_RiskProbabilityRepository lkupRiskProbabilityRepository,
                                ILkUp_RiskRTimeframeRepository lkupRiskRTimeframeRepository,
                                ILkUp_PeopleTypeRepository lkupPeopleTypeRepository ,
                                ILkUp_ProcurementLTimeRepository lkupProcurementLTimeRepository ,
                                ILkUp_ProjectScopeRepository lkupProjectScopeRepository,
                                ILkUp_RegionScopeRepository lkupRegionScopeRepository ,

                                ITrans_ActivityTypeRepository transActivityTypeRepository,
                                ITrans_DSATypeRepository transDSATypeRepository,
                                ITrans_CostCatelogueRepository transCostCatelogueRepository,
                                ITrans_CommsChannelRepository transCommsChannelRepository,
                                ITrans_CountryRepository transCountryRepository,
                                ITrans_ExtParticipantTypeRepository transExtParticipantTypeRepository,
                                ITrans_FiscalYearRepository transFiscalYearRepository,
                                ITrans_ImplementationTypeRepository transImplementationTypeRepository,
                                ITrans_LeadershipStatusRepository transLeadershipStatusRepository,
                                ITrans_ParticipantTypeRepository transParticipantTypeRepository,
                                ITrans_ProcurementTypeRepository transProcurementTypeRepository,
                                ITrans_RiskCategoryRepository transRiskCategoryRepository,
                                ITrans_RiskImpactRepository transRiskImpactRepository,
                                ITrans_RiskProbabilityRepository transRiskProbabilityRepository,
                                ITrans_RiskRTimeframeRepository transRiskRTimeframeRepository,
                                ITrans_PeopleTypeRepository transPeopleTypeRepository ,
                                ITrans_ProcurementLTimeRepository transProcurementLTimeRepository,
                                ITrans_ProjectScopeRepository transProjectScopeRepository,
                                ITrans_RegionScopeRepository transRegionScopeRepository )
        {
            this._employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.hostingEnvironment = hostingEnvironment;

            _lkupActivityTypeRepository=lkupActivityTypeRepository;
            _lkupDSATypeRepository=lkupDSATypeRepository;
            _lkupCostCatelogueRepository=lkupCostCatelogueRepository;
            _lkupCommsChannelRepository=lkupCommsChannelRepository;
            _lkupCountryRepository=lkupCountryRepository;
            _lkupExtParticipantTypeRepository=lkupExtParticipantTypeRepository;
            _lkupFiscalYearRepository=lkupFiscalYearRepository;
            _lkupImplementationTypeRepository=lkupImplementationTypeRepository;
            _lkupLeadershipStatusRepository=lkupLeadershipStatusRepository;
            _lkupParticipantTypeRepository=lkupParticipantTypeRepository;
            _lkupProcurementTypeRepository=lkupProcurementTypeRepository; 
            _lkupRiskCategoryRepository=lkupRiskCategoryRepository; 
            _lkupRiskImpactRepository=lkupRiskImpactRepository;
            _lkupRiskProbabilityRepository=lkupRiskProbabilityRepository;
            _lkupRiskRTimeframeRepository=lkupRiskRTimeframeRepository;
            _lkupPeopleTypeRepository =lkupPeopleTypeRepository;
            _lkupProcurementLTimeRepository =lkupProcurementLTimeRepository;
            _lkupProjectScopeRepository = lkupProjectScopeRepository;
            _lkupRegionScopeRepository= lkupRegionScopeRepository;


            _transActivityTypeRepository=transActivityTypeRepository;
            _transDSATypeRepository=transDSATypeRepository;
            _transCostCatelogueRepository=transCostCatelogueRepository;
            _transCommsChannelRepository=transCommsChannelRepository;
            _transCountryRepository=transCountryRepository;
            _transExtParticipantTypeRepository=transExtParticipantTypeRepository;
            _transFiscalYearRepository=transFiscalYearRepository;
            _transImplementationTypeRepository=transImplementationTypeRepository;
            _transLeadershipStatusRepository=transLeadershipStatusRepository;
            _transParticipantTypeRepository=transParticipantTypeRepository;
            _transProcurementTypeRepository =transProcurementTypeRepository ;
            _transRiskCategoryRepository =transRiskCategoryRepository  ;
            _transRiskImpactRepository =transRiskImpactRepository;
            _transRiskProbabilityRepository =transRiskProbabilityRepository ;
            _transRiskRTimeframeRepository =transRiskRTimeframeRepository ;
            _transPeopleTypeRepository =transPeopleTypeRepository;
            _transProcurementLTimeRepository=transProcurementLTimeRepository;
            _transProjectScopeRepository =transProjectScopeRepository;
            _transRegionScopeRepository= transRegionScopeRepository;
      



            _context = context;
            
        }

        // GET: /<controller>/

        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);

            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                //DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank
            };

            
            return View(emp_view);
        }

        public async Task<ActionResult> LoadLookUps()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);
            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            // DateTime test = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day);

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                ExistingPhotoPath = employee.PhotoPath

            };



            return View(emp_view);

        }


        public async Task<ActionResult> LookUpActivityType()
        {

            var user = await userManager.GetUserAsync(HttpContext.User);

            string profilepicpath = "";



            Employee employee = _employeeRepository.GetEmployeeByLoginIdentAndStaffNumber(user.Id, user.Staff_Number);
            if (employee.PhotoPath == null)
            {
                if (employee.Gender == 1)
                    profilepicpath = "/appdirectory/profilepics/male_null_profile.jpg";
                else
                    profilepicpath = "/appdirectory/profilepics/female_null_profile.jpg";
            }
            else
            {
                profilepicpath = "/appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

            }

            // DateTime test = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day);

            EmployeeViewModel emp_view = new EmployeeViewModel
            {
                Id = employee.Id,
                IdentityUserId = employee.IdentityUserId,
                Staff_Number = employee.Staff_Number,
                Address_Street = employee.Address_Street,
                Address_City = employee.Address_City,
                Address_PostCode = employee.Address_PostCode,
                Address_State = employee.Address_State,
                RankStep = employee.RankStep,
                Country = employee.Country,
                Directorate_Id = employee.Directorate_Id,
                Department_Id = employee.Department_Id,
                // DOB=employee.DOB,
                DOB = new DateTime(employee.DOB.Year, employee.DOB.Month, employee.DOB.Day),
                Email = employee.Email,
                First_Name = employee.First_Name,
                Last_Name = employee.Last_Name,
                Gender = employee.Gender,
                PhotoPath = profilepicpath,
                Rank = employee.Rank,
                ExistingPhotoPath = employee.PhotoPath

            };



            return View(emp_view);

        }

        //**************LOAD LOOK-UPS TABLES******************///

        [HttpPost]
        public ActionResult LoadAllLookUps()
        {
            Chilkat.Csv csv_activitytype = new Chilkat.Csv();
            Chilkat.Csv csv_dsatype = new Chilkat.Csv();
            Chilkat.Csv csv_costcatelogue = new Chilkat.Csv();
            Chilkat.Csv csv_commschannel = new Chilkat.Csv();
            Chilkat.Csv csv_country = new Chilkat.Csv();
            Chilkat.Csv csv_extparticipanttype= new Chilkat.Csv();
            Chilkat.Csv csv_fiscalyear = new Chilkat.Csv();
            Chilkat.Csv csv_implementationtype = new Chilkat.Csv();
            Chilkat.Csv csv_leadershipstatus = new Chilkat.Csv();
            Chilkat.Csv csv_participanttype = new Chilkat.Csv();

            Chilkat.Csv csv_procurementtype = new Chilkat.Csv();
            Chilkat.Csv csv_riskcategory = new Chilkat.Csv();
            Chilkat.Csv csv_riskimpact = new Chilkat.Csv();
            Chilkat.Csv csv_riskprobability = new Chilkat.Csv();
            Chilkat.Csv csv_riskreptimeframe = new Chilkat.Csv();

            Chilkat.Csv csv_peopletype= new Chilkat.Csv();
            Chilkat.Csv csv_procurementleadtime = new Chilkat.Csv();
            Chilkat.Csv csv_projectscope = new Chilkat.Csv();
            Chilkat.Csv csv_regionscope= new Chilkat.Csv();



            string activitytype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ActivityType.csv");
            string dsatype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/DSAType.csv");
            string costcatelogue_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CostCatelogue.csv");
            string commschannel_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/CommunicationChannels.csv");
            string country_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Country.csv");
            string extparticipanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ExternalPersonsType.csv");
            string fiscalyear_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/FiscalYears.csv");
            string implementationtype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ImplementationTypes.csv");
            string leadershipstatus_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/LeadershipStatus.csv");
            string participanttype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ParticipantType.csv");
            string procurementtype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProcurementTypes.csv");
            string riskcategory_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskCategories.csv");
            string riskimpact_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskImpact.csv");
            string riskprobability_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskProbability.csv");
            string riskreptimeframe_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RiskTimeframes.csv");
            string peopletype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/PeopleTypes.csv");
            string procurementleadtime_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProcurementLeadTimes.csv");
            string projectscope_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/ProjectScope.csv");
            string regionscope_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/RegionScope.csv");
            


            try
            {
                bool success_activitytype = csv_activitytype.LoadFile(activitytype_path);
                bool success_dsatype = csv_dsatype.LoadFile(dsatype_path);
                bool success_costcatelogue = csv_costcatelogue.LoadFile(costcatelogue_path);
                bool success_commschannel = csv_commschannel.LoadFile(commschannel_path);
                bool success_country = csv_country.LoadFile(country_path);
                bool success_extparticipanttype = csv_extparticipanttype.LoadFile(extparticipanttype_path);
                bool success_fiscalyear = csv_fiscalyear.LoadFile(fiscalyear_path);
                bool success_implementationtype = csv_implementationtype.LoadFile(implementationtype_path);
                bool success_leadershipstatus= csv_leadershipstatus.LoadFile(leadershipstatus_path);
                bool success_participanttype = csv_participanttype.LoadFile(participanttype_path);
                bool success_procurementtype= csv_procurementtype.LoadFile(procurementtype_path);
                bool success_riskcategory = csv_riskcategory.LoadFile(riskcategory_path);
                bool success_riskimpact = csv_riskimpact.LoadFile(riskimpact_path);
                bool success_riskprobability= csv_riskprobability.LoadFile(riskprobability_path);
                bool success_riskreptimeframe = csv_riskreptimeframe.LoadFile(riskreptimeframe_path);
                bool success_peopletype= csv_peopletype.LoadFile(peopletype_path);
                bool success_procurementleadtime = csv_procurementleadtime.LoadFile(procurementleadtime_path);
                bool success_projectscope = csv_projectscope.LoadFile(projectscope_path);
                bool success_regionscope = csv_regionscope.LoadFile(regionscope_path);

                if (success_activitytype == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_activitytypes = _lkupActivityTypeRepository.GetAllActivityType().Count();
                    if (count_activitytypes <= 0)
                    {
                        int row;
                        int n = csv_activitytype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ActivityType rec = new LkUp_ActivityType
                            {

                                Activity_Id = Int32.Parse(csv_activitytype.GetCell(row, 0)),
                                Activity_Name = csv_activitytype.GetCell(row, 1),
                                ActivityType_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupActivityTypeRepository.Add(rec);

                            Trans_ActivityType rec_trans = new Trans_ActivityType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Activity_Id = Int32.Parse(csv_activitytype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transActivityTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_dsatype == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_dsatypes = _lkupDSATypeRepository.GetAllDSAType().Count();
                    if (count_dsatypes <= 0)
                    {
                        int row;
                        int n = csv_dsatype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_DSAType sDSAType = new LkUp_DSAType
                            {

                                DSA_Id = Int32.Parse(csv_dsatype.GetCell(row, 0)),
                                DSA_Name = csv_dsatype.GetCell(row, 1),
                                DSA_Value = float.Parse(csv_dsatype.GetCell(row, 2)),
                                DSAType_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupDSATypeRepository.Add(sDSAType);

                            Trans_DSAType rec_trans = new Trans_DSAType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                DSA_Id = Int32.Parse(csv_dsatype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transDSATypeRepository.Add(rec_trans);
                        }
                    }
                } 
                if (success_costcatelogue == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_costcatelogue = _lkupCostCatelogueRepository.GetAllCostCatelogue().Count();
                    if (count_costcatelogue <= 0)
                    {
                        int row;
                        int n = csv_costcatelogue.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_CostCatelogue rec = new LkUp_CostCatelogue
                            {

                                Cost_Id = Int32.Parse(csv_costcatelogue.GetCell(row, 0)),
                                Cost_Code = csv_costcatelogue.GetCell(row, 1),
                                Cost_Category = csv_costcatelogue.GetCell(row, 2),
                                Cost_Description = csv_costcatelogue.GetCell(row, 3),
                                Unit_Of_Measure = csv_costcatelogue.GetCell(row, 4),
                                Unit_Cost = float.Parse(csv_costcatelogue.GetCell(row, 5)),
                                Cost_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCostCatelogueRepository.Add(rec);

                            Trans_CostCatelogue rec_trans = new Trans_CostCatelogue
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Cost_Id = Int32.Parse(csv_costcatelogue.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCostCatelogueRepository.Add(rec_trans);
                        }
                    }
                }

                if (success_commschannel == true)
                {

                    // IEnumerable <EmployeeCountry> countries= _empcountryRepository.GetAllEmployeeCountry();
                    int count_commschannel = _lkupCommsChannelRepository.GetAllCommsChannel().Count();
                    if (count_commschannel <= 0)
                    {
                        int row;
                        int n = csv_commschannel.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_CommsChannel rec = new LkUp_CommsChannel
                            {

                                CommsChannel_Id = Int32.Parse(csv_commschannel.GetCell(row, 0)),
                                CommsChannel_Name = csv_commschannel.GetCell(row, 1),
                                CommsChannel_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCommsChannelRepository.Add(rec);

                            Trans_CommsChannel rec_trans = new Trans_CommsChannel
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                CommsChannel_Id = Int32.Parse(csv_commschannel.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCommsChannelRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_country== true)
                {
                    int count_country = _lkupCountryRepository.GetAllCountry().Count();
                    if (count_country <= 0)
                    {
                        int row;
                        int n = csv_country.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Country rec = new LkUp_Country
                            {

                                Country_Id = Int32.Parse(csv_country.GetCell(row, 0)),
                                Country_Name = csv_country.GetCell(row, 1),
                                Country_Capital=csv_country.GetCell(row, 2),
                                AfricanCountry=Int32.Parse(csv_country.GetCell(row, 3)),
                                Country_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupCountryRepository.Add(rec);

                            Trans_Country rec_trans = new Trans_Country
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Country_Id = Int32.Parse(csv_country.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transCountryRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_extparticipanttype == true)
                {
                    int _count= _lkupExtParticipantTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_extparticipanttype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ExtParticipantType rec = new LkUp_ExtParticipantType
                            {

                                Record_Id = Int32.Parse(csv_extparticipanttype.GetCell(row, 0)),
                                Record_Name = csv_extparticipanttype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupExtParticipantTypeRepository.Add(rec);

                            Trans_ExtParticipantType rec_trans = new Trans_ExtParticipantType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_extparticipanttype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transExtParticipantTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_fiscalyear == true)
                {
                    int _count= _lkupFiscalYearRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_fiscalyear.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_FiscalYear rec = new LkUp_FiscalYear
                            {

                                Record_Id = Int32.Parse(csv_fiscalyear.GetCell(row, 0)),
                                Record_Name = csv_fiscalyear.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupFiscalYearRepository.Add(rec);

                            Trans_FiscalYear rec_trans = new Trans_FiscalYear
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_fiscalyear.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transFiscalYearRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_implementationtype == true)
                {
                    int _count= _lkupImplementationTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_implementationtype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ImplementationType rec = new LkUp_ImplementationType
                            {

                                Record_Id = Int32.Parse(csv_implementationtype.GetCell(row, 0)),
                                Record_Name = csv_implementationtype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupImplementationTypeRepository.Add(rec);

                            Trans_ImplementationType rec_trans = new Trans_ImplementationType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_implementationtype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transImplementationTypeRepository.Add(rec_trans);

                        }
                    }
                }


                if (success_leadershipstatus == true)
                {
                    int _count= _lkupLeadershipStatusRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_leadershipstatus.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_LeadershipStatus rec = new LkUp_LeadershipStatus
                            {

                                Record_Id = Int32.Parse(csv_leadershipstatus.GetCell(row, 0)),
                                Record_Name = csv_leadershipstatus.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupLeadershipStatusRepository.Add(rec);

                            Trans_LeadershipStatus rec_trans = new Trans_LeadershipStatus
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_leadershipstatus.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transLeadershipStatusRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_participanttype == true)
                {
                    int _count= _lkupParticipantTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_participanttype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ParticipantType rec = new LkUp_ParticipantType
                            {

                                Record_Id = Int32.Parse(csv_participanttype.GetCell(row, 0)),
                                Record_Name = csv_participanttype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupParticipantTypeRepository.Add(rec);

                            Trans_ParticipantType rec_trans = new Trans_ParticipantType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_participanttype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transParticipantTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_procurementtype == true)
                {
                    int _count= _lkupProcurementTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_procurementtype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProcurementType rec = new LkUp_ProcurementType
                            {

                                Record_Id = Int32.Parse(csv_procurementtype.GetCell(row, 0)),
                                Record_Name = csv_procurementtype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProcurementTypeRepository.Add(rec);

                            Trans_ProcurementType rec_trans = new Trans_ProcurementType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_procurementtype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProcurementTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskcategory == true)
                {
                    int _count= _lkupRiskCategoryRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskcategory.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskCategory rec = new LkUp_RiskCategory
                            {

                                Record_Id = Int32.Parse(csv_riskcategory.GetCell(row, 0)),
                                Record_Name = csv_riskcategory.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskCategoryRepository.Add(rec);

                            Trans_RiskCategory rec_trans = new Trans_RiskCategory
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskcategory.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskCategoryRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskimpact == true)
                {
                    int _count= _lkupRiskImpactRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskimpact.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskImpact rec = new LkUp_RiskImpact
                            {

                                Record_Id = Int32.Parse(csv_riskimpact.GetCell(row, 0)),
                                Record_Name = csv_riskimpact.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskImpactRepository.Add(rec);

                            Trans_RiskImpact rec_trans = new Trans_RiskImpact
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskimpact.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskImpactRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskprobability == true)
                {
                    int _count= _lkupRiskProbabilityRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskprobability.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskProbability rec = new LkUp_RiskProbability
                            {

                                Record_Id = Int32.Parse(csv_riskprobability.GetCell(row, 0)),
                                Record_Name = csv_riskprobability.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskProbabilityRepository.Add(rec);

                            Trans_RiskProbability rec_trans = new Trans_RiskProbability
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskprobability.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskProbabilityRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_riskreptimeframe == true)
                {
                    int _count= _lkupRiskRTimeframeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_riskreptimeframe.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RiskRTimeframe rec = new LkUp_RiskRTimeframe
                            {

                                Record_Id = Int32.Parse(csv_riskreptimeframe.GetCell(row, 0)),
                                Record_Name = csv_riskreptimeframe.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRiskRTimeframeRepository.Add(rec);

                            Trans_RiskRTimeframe rec_trans = new Trans_RiskRTimeframe
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_riskreptimeframe.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRiskRTimeframeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_peopletype == true)
                {
                    int _count= _lkupPeopleTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_peopletype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_PeopleType rec = new LkUp_PeopleType
                            {

                                Record_Id = Int32.Parse(csv_peopletype.GetCell(row, 0)),
                                Record_Name = csv_peopletype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupPeopleTypeRepository.Add(rec);

                            Trans_PeopleType rec_trans = new Trans_PeopleType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_peopletype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transPeopleTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_procurementleadtime == true)
                {
                    int _count= _lkupProcurementLTimeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_procurementleadtime.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProcurementLTime rec = new LkUp_ProcurementLTime
                            {

                                Record_Id = Int32.Parse(csv_procurementleadtime.GetCell(row, 0)),
                                Record_Name = csv_procurementleadtime.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProcurementLTimeRepository.Add(rec);

                            Trans_ProcurementLTime rec_trans = new Trans_ProcurementLTime
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_procurementleadtime.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProcurementLTimeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_projectscope == true)
                {
                    int _count= _lkupProjectScopeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_projectscope.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_ProjectScope rec = new LkUp_ProjectScope
                            {

                                Record_Id = Int32.Parse(csv_projectscope.GetCell(row, 0)),
                                Record_Name = csv_projectscope.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProjectScopeRepository.Add(rec);

                            Trans_ProjectScope rec_trans = new Trans_ProjectScope
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_projectscope.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProjectScopeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_regionscope == true)
                {
                    int _count= _lkupRegionScopeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_regionscope.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_RegionScope rec = new LkUp_RegionScope
                            {

                                Record_Id = Int32.Parse(csv_regionscope.GetCell(row, 0)),
                                Record_Name = csv_regionscope.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupRegionScopeRepository.Add(rec);

                            Trans_RegionScope rec_trans = new Trans_RegionScope
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_regionscope.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transRegionScopeRepository.Add(rec_trans);

                        }
                    }
                }

                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }

        }
        //**************GRID CREATE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityTypeByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _lkupActivityTypeRepository.GetAllActivityType();
                        int _count = DB_Recs.Count();

                        LkUp_ActivityType rec_to_add = new LkUp_ActivityType
                        {
                            Activity_Id=_count+1,
                            Activity_Name=record.LookUp_Name,
                            ActivityType_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _lkupActivityTypeRepository.Add(rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID UPDATE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(record.LookUp_Id);
                
                if (rec != null)
                {

                        LkUp_ActivityType rec_already_exist = _lkupActivityTypeRepository.GetActivityTypeByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Activity_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _lkupActivityTypeRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID DELETE RECORDS******************///
        [AcceptVerbs("Post")]
		public ActionResult LkUp_ActivityType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.ActivityType_Status==null)
                        {
                            _lkupActivityTypeRepository.Delete(rec.Activity_Id);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_ActivityType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_ActivityType rec = _transActivityTypeRepository.GetTrans_ActivityType(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transActivityTypeRepository.Delete(rec.Transaction_Id);

                    LkUp_ActivityType rec_update=_lkupActivityTypeRepository.GetActivityType(rec.Activity_Id);
                    rec_update.ActivityType_Status=false;
                    _lkupActivityTypeRepository.Update(rec_update);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        //**************GRID DATA READS******************///

        public ActionResult LkUp_ActivityType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _lkupActivityTypeRepository.GetAllActivityType();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Activity_Id,
                        LookUp_Name =rec.Activity_Name,
                        Show_trans_button=rec.ActivityType_Status.HasValue? rec.ActivityType_Status.Value? false: true: true,
                        LookUp_Status = rec.ActivityType_Status.HasValue? rec.ActivityType_Status.Value? "Transactional": "Active": "Inactive",
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Trans_ActivityType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transActivityTypeRepository.GetAllTransActivityType().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Activity_Id,
                        Trans_LookUp_Id=rec.Transaction_Id,
                        LookUp_Name =_lkupActivityTypeRepository.GetActivityType(rec.Activity_Id).Activity_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        //**************GRID COMMAND ACTIONS******************///
        [HttpPost]
        public ActionResult MakeActivityTypeTrans(string recid)
        {
            try
            {
                LkUp_ActivityType rec = _lkupActivityTypeRepository.GetActivityType(Int32.Parse(recid));
                rec.ActivityType_Status=true;
                _lkupActivityTypeRepository.Update(rec);

                Trans_ActivityType rec_trans = new Trans_ActivityType
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Activity_Id = rec.Activity_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transActivityTypeRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

    }
}