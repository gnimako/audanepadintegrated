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
        private readonly IStrategy_PriorityRepository _strategyPriorityRepository ;
        private readonly IStrategy_MTPRepository _strategyMTPRepository;
        private readonly IStrategy_MTPPriorityMappingRepository _strategyMTPPriorityMappingRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStrategy_OutputIndicatorsRepository _strategyOutputIndicatorsRepository ;
        private readonly IStrategy_OutputIndicatorsPriorityMappingRepository _strategyOutputIndicatorsPriorityMappingRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly ILkUp_ProgrammeRepository _lkupProgrammeRepository;
        private readonly ILkUp_ProjectRepository _lkupProjectRepository;
        private readonly ILkUp_PeriodRepository _lkupPeriodRepository;
        private readonly ILkUp_IndicatorTypeRepository _lkupIndicatorTypeRepository;


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
        private readonly ITrans_StrategyPriorityRepository _transStrategyPriorityRepository ;
        private readonly ITrans_StrategyMTPRepository _transStrategyMTPRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrategyOutputIndicators _transStrategyOutputIndicators  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_ProgrammeRepository _transProgrammeRepository ;
        private readonly ITrans_ProjectRepository _transProjectRepository  ;
        private readonly ITrans_PeriodRepository _transPeriodRepository ;
        private readonly ITrans_IndicatorTypeRepository _transIndicatorTypeRepository ;
        private readonly ISystem_AuditRepository _sysSystemAuditRepository;

        


        private readonly IStruc_DirStaffMappingRepository _strucDirStaffMappingRepository  ;
        private readonly IStruc_DivStaffMappingRepository _strucDivStaffMappingRepository  ;

        private readonly IStruc_DirectorRepository _strucDirectorRepository   ;
        private readonly IStruc_DirectorOICRepository _strucDirectorOICRepository   ;
        private readonly IStruc_DivHeadRepository _strucDivHeadRepository   ;
        private readonly IStruc_DivHeadOICRepository _strucDivHeadOICRepository  ;
        private readonly IEmailSender _emailSender  ;

        //Workplans
        private readonly IWP_DispatchCycleRepository _wpDispatchCycleRepository;
        private readonly IWP_MainRecordRepository _wpMainRecordRepository;
        private readonly IWP_OutcomesRepository _wpOutcomesRepository;
        private readonly IWP_MTPRepository _wpMTPRepository;
        private readonly IWP_AUDAPriorityRepository _wpAUDAPriorityRepository;
        private readonly IWP_ApprovalStatusRepository _wpApprovalStatusRepository;
        private readonly IWP_RegionScopeRepository _wpRegionScopeRepository;
        private readonly IWP_CountryScopeRepository _wpCountryScopeRepository ;
        private readonly IWP_OutputsRepository _wpOutputsRepository ;
        private readonly IWP_OutputIndicatorsRepository _wpOutputIndicatorsRepository ;
        private readonly IWP_OutputActivitiesRepository _wpOutputActivitiesRepository ;
        private readonly IWP_SAPLinkRepository _wpSAPLinkRepository  ;
        private readonly IWP_OutputBudgetRepository _wpOutputBudgetRepository ;
        private readonly IWP_OutputActivityCountriesRepository _wpOutputActivityCountriesRepository;




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
                                IStrategy_PriorityRepository strategyPriorityRepository,
                                IStrategy_MTPRepository strategyMTPRepository,
                                IStrategy_MTPPriorityMappingRepository strategyMTPPriorityMappingRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStrategy_OutputIndicatorsRepository strategyOutputIndicatorsRepository,
                                IStrategy_OutputIndicatorsPriorityMappingRepository strategyOutputIndicatorsPriorityMappingRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                ILkUp_ProgrammeRepository lkupProgrammeRepository,
                                ILkUp_ProjectRepository lkupProjectRepository,
                                ILkUp_PeriodRepository lkupPeriodRepository,
                                ILkUp_IndicatorTypeRepository lkupIndicatorTypeRepository,

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
                                ITrans_RegionScopeRepository transRegionScopeRepository,
                                ITrans_StrategyPriorityRepository transStrategyPriorityRepository,
                                ITrans_StrategyMTPRepository transStrategyMTPRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrategyOutputIndicators transStrategyOutputIndicators,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_ProgrammeRepository transProgrammeRepository, 
                                ITrans_ProjectRepository transProjectRepository, 
                                ITrans_PeriodRepository transPeriodRepository,
                                ITrans_IndicatorTypeRepository transIndicatorTypeRepository,
                                ISystem_AuditRepository sysSystemAuditRepository,
                                IStruc_DirStaffMappingRepository strucDirStaffMappingRepository,
                                IStruc_DivStaffMappingRepository strucDivStaffMappingRepository,
                                IStruc_DirectorRepository strucDirectorRepository,
                                IStruc_DirectorOICRepository strucDirectorOICRepository,
                                IStruc_DivHeadRepository strucDivHeadRepository,
                                IStruc_DivHeadOICRepository strucDivHeadOICRepository,
                                IEmailSender emailSender,
                                //workplans
                                IWP_DispatchCycleRepository wpDispatchCycleRepository,
                                IWP_MainRecordRepository wpMainRecordRepository,
                                IWP_OutcomesRepository wpOutcomesRepository,
                                IWP_MTPRepository wpMTPRepository,
                                IWP_AUDAPriorityRepository wpAUDAPriorityRepository,
                                IWP_ApprovalStatusRepository wpApprovalStatusRepository,
                                IWP_RegionScopeRepository wpRegionScopeRepository,
                                IWP_CountryScopeRepository wpCountryScopeRepository,
                                IWP_OutputsRepository wpOutputsRepository,
                                IWP_OutputIndicatorsRepository wpOutputIndicatorsRepository,
                                IWP_OutputActivitiesRepository wpOutputActivitiesRepository,
                                IWP_SAPLinkRepository wpSAPLinkRepository,
                                IWP_OutputBudgetRepository wpOutputBudgetRepository,
                                IWP_OutputActivityCountriesRepository wpOutputActivityCountriesRepository)
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
            _lkupProgrammeRepository=lkupProgrammeRepository;
            _lkupProjectRepository=lkupProjectRepository;
            _lkupPeriodRepository=lkupPeriodRepository;
            _lkupIndicatorTypeRepository=lkupIndicatorTypeRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyMTPRepository=strategyMTPRepository;
            _strategyMTPPriorityMappingRepository=strategyMTPPriorityMappingRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strategyOutputIndicatorsRepository=strategyOutputIndicatorsRepository;
            _strategyOutputIndicatorsPriorityMappingRepository=strategyOutputIndicatorsPriorityMappingRepository;
            _strucDirectorateRepository=strucDirectorateRepository;
            _strucDivisionRepository=strucDivisionRepository;


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
            _transStrategyPriorityRepository=transStrategyPriorityRepository;
            _transStrategyMTPRepository=transStrategyMTPRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrategyOutputIndicators=transStrategyOutputIndicators;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transProgrammeRepository=transProgrammeRepository;
            _transProjectRepository=transProjectRepository;
            _transPeriodRepository=transPeriodRepository;
            _transIndicatorTypeRepository=transIndicatorTypeRepository;
            _sysSystemAuditRepository=sysSystemAuditRepository;
            _strucDirStaffMappingRepository=strucDirStaffMappingRepository;
            _strucDivStaffMappingRepository=strucDivStaffMappingRepository;
            _strucDirectorRepository=strucDirectorRepository;
            _strucDirectorOICRepository=strucDirectorOICRepository;
            _strucDivHeadRepository=strucDivHeadRepository;
            _strucDivHeadOICRepository=strucDivHeadOICRepository;
            _emailSender=emailSender;

            //workplans
            _wpDispatchCycleRepository=wpDispatchCycleRepository;
            _wpMainRecordRepository=wpMainRecordRepository;
            _wpOutcomesRepository=wpOutcomesRepository;
            _wpMTPRepository=wpMTPRepository;
            _wpAUDAPriorityRepository=wpAUDAPriorityRepository;
            _wpApprovalStatusRepository=wpApprovalStatusRepository;
            _wpRegionScopeRepository=wpRegionScopeRepository;
            _wpCountryScopeRepository=wpCountryScopeRepository;
            _wpOutputsRepository=wpOutputsRepository;
            _wpOutputIndicatorsRepository=wpOutputIndicatorsRepository;
            _wpOutputActivitiesRepository=wpOutputActivitiesRepository;
            _wpSAPLinkRepository=wpSAPLinkRepository;
            _wpOutputBudgetRepository=wpOutputBudgetRepository;
            _wpOutputActivityCountriesRepository=wpOutputActivityCountriesRepository;
      



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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> ManageStrucDirectorate()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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


        public async Task<ActionResult> ManageIdentRoles()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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
        public async Task<ActionResult> StaffDirectorateMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDirectorsMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDivisionHeadMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> StaffDivisionMapping()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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

        public async Task<ActionResult> ManageStrucDivision()
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
                profilepicpath = "/appdirectory/profilepics/" + employee.Staff_Number + "/" + employee.PhotoPath;

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


            PopulateDirectorateDropDownList();

            return View(emp_view);

        }
        private void PopulateDirectorateDropDownList()
        {
           // var dataContext = new SampleEntities();
            var categories = _transStrucDirectorateRepository.GetAllRecords().ToList()
                        .Select(c => new DropDownListViewModel {
                            DropDown_IntId = c.Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(c.Record_Id).Record_Name
                        })
                        .OrderBy(e => e.DropDown_Name);

            ViewData["categories"] = categories;
            ViewData["defaultCategory"] = categories.First();            
        }

        //**************LOAD LOOK-UPS TABLES******************///

        [HttpPost]
        public async Task<ActionResult> LoadAllLookUps()
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
            Chilkat.Csv csv_strategypriority= new Chilkat.Csv();
            Chilkat.Csv csv_strategymtp= new Chilkat.Csv();
            Chilkat.Csv csv_strategykeyperformancearea= new Chilkat.Csv();
            Chilkat.Csv csv_strategyoutputindicators= new Chilkat.Csv();
            Chilkat.Csv csv_strategyoutputindicatorsmapping= new Chilkat.Csv();
            Chilkat.Csv csv_strucdirectorate= new Chilkat.Csv();
            Chilkat.Csv csv_strucdivision= new Chilkat.Csv();
            Chilkat.Csv csv_programme= new Chilkat.Csv();
            Chilkat.Csv csv_project =new Chilkat.Csv();
            Chilkat.Csv csv_period =new Chilkat.Csv();
            Chilkat.Csv csv_indicatortype =new Chilkat.Csv();
            Chilkat.Csv csv_roles =new Chilkat.Csv();



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
            string strategypriority_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategicPriorities.csv");
            string strategymtp_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/MTPs.csv");
            string strategykeyperformancearea_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategicPrioritiesKeyPerformanceAreas.csv");
            string strategyoutputindicators_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategyOutputIndicators.csv");
            string strategyoutputindicatorsmapping_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/StrategyOutputIndicatorsMapping.csv");
            string strucdirectorate_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Directorates.csv");
            string strucdivision_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Division.csv");
            string programme_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/AUDANEPADProgrammes.csv");
            string project_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/AUDANEPADProjects.csv");
            string period_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Periods.csv");
            string indicatortype_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/IndicatorType.csv");
            string roles_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/Roles.csv");
            


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
                bool success_strategypriority = csv_strategypriority.LoadFile(strategypriority_path);
                bool success_strategymtp = csv_strategymtp.LoadFile(strategymtp_path);
                bool success_strategykeyperformancearea = csv_strategykeyperformancearea.LoadFile(strategykeyperformancearea_path);
                bool success_strategyoutputindicators = csv_strategyoutputindicators.LoadFile(strategyoutputindicators_path);
                bool success_strategyoutputindicatorsmapping = csv_strategyoutputindicatorsmapping.LoadFile(strategyoutputindicatorsmapping_path);
                bool success_strucdirectorate = csv_strucdirectorate.LoadFile(strucdirectorate_path);
                bool success_strucdivision = csv_strucdivision.LoadFile(strucdivision_path);
                bool success_programme = csv_programme.LoadFile(programme_path);
                bool success_project = csv_project.LoadFile(project_path);
                bool success_period= csv_period.LoadFile(period_path);
                bool success_indicatortype= csv_indicatortype.LoadFile(indicatortype_path);
                bool success_roles= csv_roles.LoadFile(roles_path);


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

                if (success_strategypriority == true)
                {
                    int _count= _strategyPriorityRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategypriority.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_Priority rec = new Strategy_Priority
                            {

                                Record_Id = Int32.Parse(csv_strategypriority.GetCell(row, 0)),
                                Record_Name = csv_strategypriority.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyPriorityRepository.Add(rec);

                            Trans_StrategyPriority rec_trans = new Trans_StrategyPriority
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strategypriority.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyPriorityRepository.Add(rec_trans);

                        }
                    }
                }


                if (success_strategymtp == true)
                {
                    int _count= _strategyMTPRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategymtp.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_MTP rec = new Strategy_MTP
                            {

                                Record_Id = Int32.Parse(csv_strategymtp.GetCell(row, 0)),
                                Record_Name = csv_strategymtp.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyMTPRepository.Add(rec);

                            Trans_StrategyMTP rec_trans = new Trans_StrategyMTP
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strategymtp.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyMTPRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strategykeyperformancearea == true)
                {
                    int _count= _strategyKeyPerformanceAreaRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategykeyperformancearea.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_KeyPerformanceArea rec = new Strategy_KeyPerformanceArea
                            {

                                Record_Id = Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 0)),
                                StrategicPriority_Id=Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 1)),
                                Record_Name = csv_strategykeyperformancearea.GetCell(row, 2),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyKeyPerformanceAreaRepository.Add(rec);

                            Trans_StrategyKeyPerformanceArea rec_trans = new Trans_StrategyKeyPerformanceArea
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                StrategicKeyPerformanceArea_Id = Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 0)),
                                TransStrategicPriority_Id=_transStrategyPriorityRepository.GetRecordByMasterStrategyPriorityId(Int32.Parse(csv_strategykeyperformancearea.GetCell(row, 1))).Transaction_Id,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyKeyPerformanceAreaRepository.Add(rec_trans);

                        }
                    }
                }
                //Indicators
                if (success_strategyoutputindicators == true)
                {
                    int _count= _strategyOutputIndicatorsRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategyoutputindicators.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_OutputIndicators rec = new Strategy_OutputIndicators
                            {

                                Record_Id = Int32.Parse(csv_strategyoutputindicators.GetCell(row, 0)),
                                Record_Name = csv_strategyoutputindicators.GetCell(row, 1),
                                Indicator_Type=csv_strategyoutputindicators.GetCell(row, 2),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyOutputIndicatorsRepository.Add(rec);

                            Trans_StrategyOutputIndicators rec_trans = new Trans_StrategyOutputIndicators
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strategyoutputindicators.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrategyOutputIndicators.Add(rec_trans);

                        }
                    }
                }

                if (success_strategyoutputindicatorsmapping == true)
                {
                    int _count= _strategyOutputIndicatorsPriorityMappingRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strategyoutputindicatorsmapping.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Strategy_OutputIndicatorsPriorityMapping rec = new Strategy_OutputIndicatorsPriorityMapping
                            {

                                Transaction_Id = Guid.NewGuid().ToString(),
                                OutputIndicator_Id = Int32.Parse(csv_strategyoutputindicatorsmapping.GetCell(row, 0)),
                                Priority_Id=Int32.Parse(csv_strategyoutputindicatorsmapping.GetCell(row, 1)),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strategyOutputIndicatorsPriorityMappingRepository.Add(rec);

              
                        }
                    }
                }


                //End of Indicators

                if (success_strucdirectorate == true)
                {
                    int _count= _strucDirectorateRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strucdirectorate.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Struc_Directorate rec = new Struc_Directorate
                            {

                                Record_Id = Int32.Parse(csv_strucdirectorate.GetCell(row, 0)),
                                Record_Name = csv_strucdirectorate.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strucDirectorateRepository.Add(rec);

                            Trans_StrucDirectorate rec_trans = new Trans_StrucDirectorate
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_strucdirectorate.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrucDirectorateRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_strucdivision == true)
                {
                    int _count= _strucDivisionRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_strucdivision.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            Struc_Division rec = new Struc_Division
                            {

                                Record_Id = Int32.Parse(csv_strucdivision.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_strucdivision.GetCell(row, 1)),
                                Record_Name = csv_strucdivision.GetCell(row, 2),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _strucDivisionRepository.Add(rec);

                            Trans_StrucDivision rec_trans = new Trans_StrucDivision
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Division_Id = Int32.Parse(csv_strucdivision.GetCell(row, 0)),
                                TransDirectorate_Id=_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(Int32.Parse(csv_strucdivision.GetCell(row, 1))).Transaction_Id,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transStrucDivisionRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_programme == true)
                {
                    int _count= _lkupProgrammeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_programme.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Programme rec = new LkUp_Programme
                            {

                                Record_Id = Int32.Parse(csv_programme.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_programme.GetCell(row, 1)),
                                Division_Id=Int32.Parse(csv_programme.GetCell(row, 2)),
                                Record_Name = csv_programme.GetCell(row, 3),
                                DocPath="",
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProgrammeRepository.Add(rec);

                            Trans_Programme rec_trans = new Trans_Programme
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                MainProgramme_Id= Int32.Parse(csv_programme.GetCell(row, 0)),
                                Directorate_Id=Int32.Parse(csv_programme.GetCell(row, 1)),
                                Division_Id=Int32.Parse(csv_programme.GetCell(row, 2)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transProgrammeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_project == true)
                {
                    int _count= _lkupProjectRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_project.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Project rec = new LkUp_Project
                            {

                                Record_Id = Int32.Parse(csv_project.GetCell(row, 0)),
                                Programme_Id=Int32.Parse(csv_project.GetCell(row, 1)),
                                Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                Record_Name = csv_project.GetCell(row, 4),
                                DocPath="",
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupProjectRepository.Add(rec);

                            Trans_Programme transrec=_transProgrammeRepository.GetRecordByMainProgrammeID(Int32.Parse(csv_project.GetCell(row, 1)));
                            if(transrec!=null)
                            {
                                Trans_Project rec_trans = new Trans_Project
                                {
                                    Transaction_Id = Guid.NewGuid().ToString(),
                                    TransProgramme_Id=transrec.Transaction_Id,
                                    MainProject_Id= Int32.Parse(csv_project.GetCell(row, 0)),
                                    MainProgramme_Id= Int32.Parse(csv_project.GetCell(row, 1)),
                                    Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                    Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                                };
                                 _transProjectRepository.Add(rec_trans);
                            }
                            else
                            {
                                Trans_Project rec_trans = new Trans_Project
                                {
                                    Transaction_Id = Guid.NewGuid().ToString(),
                                    TransProgramme_Id="", 
                                    MainProject_Id= Int32.Parse(csv_project.GetCell(row, 0)),
                                    MainProgramme_Id= Int32.Parse(csv_project.GetCell(row, 1)),
                                    Directorate_Id=Int32.Parse(csv_project.GetCell(row, 2)),
                                    Division_Id=Int32.Parse(csv_project.GetCell(row, 3)),
                                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                                };
                                 _transProjectRepository.Add(rec_trans);


                            }

                           

                        }
                    }
                }

                if (success_period == true)
                {
                    int _count= _lkupPeriodRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_period.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_Period rec = new LkUp_Period
                            {

                                Record_Id = Int32.Parse(csv_period.GetCell(row, 0)),
                                Record_Name = csv_period.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupPeriodRepository.Add(rec);

                            Trans_Period rec_trans = new Trans_Period
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_period.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transPeriodRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_indicatortype == true)
                {
                    int _count= _lkupIndicatorTypeRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_indicatortype.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_IndicatorType rec = new LkUp_IndicatorType
                            {

                                Record_Id = Int32.Parse(csv_indicatortype.GetCell(row, 0)),
                                Record_Name = csv_indicatortype.GetCell(row, 1),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupIndicatorTypeRepository.Add(rec);

                            Trans_IndicatorType rec_trans = new Trans_IndicatorType
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_indicatortype.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transIndicatorTypeRepository.Add(rec_trans);

                        }
                    }
                }

                if (success_roles == true)
                {
                    int row;
                    int n = csv_roles.NumRows;


                    for (row = 0; row <= n - 1; row++)
                    {

                        bool role_exist = await roleManager.RoleExistsAsync(csv_roles.GetCell(row, 0));
                        if (!role_exist )
                        {
                            var role = new IdentityRole();
                            role.Name = csv_roles.GetCell(row, 0);
                            await roleManager.CreateAsync(role);
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



        [HttpPost]
        public ActionResult SetTestStaffEmails()
        {
            try
            {
                    var recs =  _employeeRepository.GetAllEmployee().ToList();

                    int _count = recs.Count();

                   // List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

                    string staffemail = "";
                    string testmail = "";

                    if (_count > 0)
                    {
                        foreach (var rec in recs)
                        {
                            staffemail=rec.First_Name+rec.Last_Name.Substring(0,2)+"@nepad.org";
                            staffemail=staffemail.ToLower();
                            testmail="gideonn@nepad.org";

                            rec.Email=staffemail;
                            rec.TestEmail=testmail;

                            _employeeRepository.Update(rec);
                            
                        

                        }
                    }


                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAllTestData()
        {
            try
            {
                    //Delete All Division Staff Mapping
                    var DB_Recs_Div =  _strucDivStaffMappingRepository.GetAllRecords().ToList();
                    foreach (var recordset in DB_Recs_Div)
                    {
                        _strucDivStaffMappingRepository.Delete(recordset.Transaction_Id);
                    }
                    //Delete All Division Head Mapping
                    var DB_Recs_Divhead =  _strucDivHeadRepository.GetAllRecords().ToList();
                    foreach (var recordset in DB_Recs_Divhead)
                    {
                        _strucDivHeadRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Directors Mapping
                    var DB_Recs_Directors =  _strucDirectorRepository.GetAllRecords().ToList();
                    foreach (var recordset in DB_Recs_Directors)
                    {
                        _strucDirectorRepository.Delete(recordset.Transaction_Id);
                    }


                    //Delete All Directorate Staff Mapping and Roles
                    var DB_Recs_Dir =  _strucDirStaffMappingRepository.GetAllRecords().ToList();
                    foreach (var recordset in DB_Recs_Dir)
                    {
                        _strucDirStaffMappingRepository.Delete(recordset.Transaction_Id);

                        Employee _emp = _employeeRepository.GetEmployee(recordset.EmployeePK);
                        var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);
                        if(_user!=null)
                        {
                            var userRoles = await userManager.GetRolesAsync(_user);
                            IdentityResult _result;

                            foreach (var userrec in userRoles)
                            {
                                if(userrec !="Admin")
                                {
                                    _result = await userManager.RemoveFromRoleAsync(_user, userrec);
                                }
                            }
                        }
                    }

                    //Delete All Login Account Except gideonn@nepad.org
                    var userUsers =  userManager.Users.ToList();
                    IdentityResult _resultmain;
                    foreach (var userrec in userUsers)
                    {
                        if(userrec.UserName!="gideonn@nepad.org")
                        {
                            _resultmain = await userManager.DeleteAsync(userrec);
                        }
                    }

                    //Update or Set the IdentityUserId field of Employee Table to null or ""
                    var recs =  _employeeRepository.GetAllEmployee().ToList();
                    int _count = recs.Count();

                    if (_count > 0)
                    {
                        foreach (var rec in recs)
                        {
                            if(rec.Id !=73)
                            {
                                rec.IdentityUserId="";
                                _employeeRepository.Update(rec);
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

        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _strucDirectorateRepository.GetAllRecords();
                        int _count = DB_Recs.Count();

                        Struc_Directorate rec_to_add = new Struc_Directorate
                        {
                            Record_Id=_count+1,
                            Record_Name=record.LookUp_Name,
                            Record_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _strucDirectorateRepository.Add(rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_Outcomes_Create([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string progid, string projid, string fyear, string fperiod, string empid, string dirid, string divid)
        {
            if (record != null && ModelState.IsValid)
            {  
                WP_Outcomes rec = _wpOutcomesRepository.GetRecordByOutcomeStatement(record.Outcome);

                if (rec == null && record.Outcome !=null)
                {
                        WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                        if(wp_mainrec_check==null)
                        {
                            WP_MainRecord mainrec_to_add = new WP_MainRecord
                            {
                                Transaction_Id=Guid.NewGuid().ToString(),
                                Directorate_Id=Int32.Parse(dirid),
                                Division_Id=Int32.Parse(divid),
                                Programme_Id=Int32.Parse(progid),
                                Project_Id=Int32.Parse(projid),
                                FiscalYear_Id=Int32.Parse(fyear),
                                Period_Id=Int32.Parse(fperiod),
                                WP_Status="Drafting Mode",
                                WP_ApprovalStatus="Drafting Mode: Within Division",
                                Employee_Id=Int32.Parse(empid),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };
                            WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));

                            if(wpcycle.LinkToSAPExecution==true)
                                mainrec_to_add.LinkToSAPExecution=true;
                            else
                                mainrec_to_add.LinkToSAPExecution=false;

                            _wpMainRecordRepository.Add(mainrec_to_add);

	                        WP_MainRecord wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                            //Save the Status
                            WP_ApprovalStatus wpstatus_to_add = new WP_ApprovalStatus
                            {
                                Transaction_Id=Guid.NewGuid().ToString(),
                                WPMainRecord_id=wp_mainrec_fetch1.Transaction_Id,
                                Project_Id=Int32.Parse(projid),
                                FiscalYear_Id=Int32.Parse(fyear),
                                Period_Id=Int32.Parse(fperiod),
                                WPStatusStatement="Drafting Mode: Within Division",
                                Employee_Id=Int32.Parse(empid),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _wpApprovalStatusRepository.Add(wpstatus_to_add);

                            //Log the transaction for auditiong

                            System_Audit sysaudit_to_add = new System_Audit
                            {
                                Transaction_Id=Guid.NewGuid().ToString(),
                                AuditStatement="Drafting of Project: '" +_lkupProjectRepository.GetRecord(Int32.Parse(projid)).Record_Name + "' for " + _lkupFiscalYearRepository.GetRecord(Int32.Parse(fyear)).Record_Name+ ", " + 
                                                _lkupPeriodRepository.GetRecord(Int32.Parse(fperiod)).Record_Name+ " has been initiated.",
                                Employee_Id=Int32.Parse(empid),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _sysSystemAuditRepository.Add(sysaudit_to_add);


                        }

                        WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                        WP_Outcomes rec_to_add = new WP_Outcomes
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            WPMainRecord_id=wp_mainrec_fetch.Transaction_Id,
                            Project_Id=Int32.Parse(projid),
                            FiscalYear_Id=Int32.Parse(fyear),
                            Period_Id=Int32.Parse(fperiod),
                            Outcome=record.Outcome,
                            Employee_Id=Int32.Parse(empid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _wpOutcomesRepository.Add(rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult WP_Outputs_Create([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string progid, string projid, string fyear, string fperiod, string empid, string dirid, string divid)
        {
            if (record != null && ModelState.IsValid)
            {  
                WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                WP_Outputs rec = _wpOutputsRepository.GetRecordByOutputStatement(record.Output);
                if(wp_mainrec_check!=null)
                {
                    if (rec == null && record.Output != null)
                    {

                            WP_Outputs rec_to_add = new WP_Outputs
                            {
                                Transaction_Id=Guid.NewGuid().ToString(),
                                WPMainRecord_id=wp_mainrec_check.Transaction_Id,
                                Project_Id=Int32.Parse(projid),
                                FiscalYear_Id=Int32.Parse(fyear),
                                Period_Id=Int32.Parse(fperiod),
                                Output=record.Output,
                                Employee_Id=Int32.Parse(empid),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _wpOutputsRepository.Add(rec_to_add);
                    }
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
        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        Struc_Directorate rec_already_exist = _strucDirectorateRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _strucDirectorateRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_Outcomes_Update([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string empid)
        {
            if (record != null && ModelState.IsValid)
            {  
                
                WP_Outcomes wp_rec_fetch=_wpOutcomesRepository.GetRecord(record.Transaction_Id);
                if (wp_rec_fetch != null)
                {


                        WP_Outcomes rec_already_exist = _wpOutcomesRepository.GetRecordByOutcomeStatement(record.Outcome);

                        if(rec_already_exist==null)
                        {
                            wp_rec_fetch.Outcome=record.Outcome;
                            wp_rec_fetch.Employee_Id=Int32.Parse(empid);
                            wp_rec_fetch.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _wpOutcomesRepository.Update(wp_rec_fetch);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult WP_Outputs_Update([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string empid)
        {
            if (record != null && ModelState.IsValid)
            {  
                
                WP_Outputs wp_rec_fetch=_wpOutputsRepository.GetRecord(record.Transaction_Id);
                if (wp_rec_fetch != null)
                {


                        WP_Outputs rec_already_exist = _wpOutputsRepository.GetRecordByOutputStatement(record.Output);

                        if(rec_already_exist==null)
                        {
                            wp_rec_fetch.Output=record.Output;
                            wp_rec_fetch.Employee_Id=Int32.Parse(empid);
                            wp_rec_fetch.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _wpOutputsRepository.Update(wp_rec_fetch);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult Struc_Division_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        Struc_Division rec_already_exist = _strucDivisionRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _strucDivisionRepository.Update(rec);
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
		public ActionResult Strategy_MTPStrategyMapping_Delete([DataSourceRequest] DataSourceRequest request, StrategyPriorityViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Strategy_MTPPriorityMapping rec = _strategyMTPPriorityMappingRepository.GetRecordsByMTPAndPriority(record.MTPPriority_Id, record.Priority_Id);
                
                if (rec != null)
                {

                    _strategyMTPPriorityMappingRepository.Delete(rec.Transaction_Id);
                        
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public async Task<ActionResult> Struc_DirStaffMapping_Delete([DataSourceRequest] DataSourceRequest request, EmployeeMappingViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    //Delete all division level mapping related to this directorate
                    var DB_Recs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(rec.EmployeePK, rec.Directorate_Id);
                    foreach (var recordset in DB_Recs)
                    {
                        _strucDivStaffMappingRepository.Delete(recordset.Transaction_Id);
                    }
                    //If this is the primary directorate, delete all assigned roles
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, rec.Directorate_Id);

                    Employee _emp = _employeeRepository.GetEmployee(rec.EmployeePK);
                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var userRoles = await userManager.GetRolesAsync(_user);

                    IdentityResult _result;

                    if(thisprimarydir!=null)
                    {
                        foreach (var userrec in userRoles)
                        {
                            if(userrec !="Admin")
                            {
                                _result = await userManager.RemoveFromRoleAsync(_user, userrec);
                            }
                        }
                        

                    }

                    //Delete directate mapping
                    _strucDirStaffMappingRepository.Delete(rec.Transaction_Id);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public async Task<ActionResult> Struc_DivStaffMapping_Delete([DataSourceRequest] DataSourceRequest request, EmployeeMappingViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    //If this is the primary directorate and primary division, delete all assigned roles
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, rec.Directorate_Id);
                    Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, rec.Division_Id);

                    Employee _emp = _employeeRepository.GetEmployee(rec.EmployeePK);
                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var userRoles = await userManager.GetRolesAsync(_user);

                    IdentityResult _result;

                    if(thisprimarydir!=null && thisprimarydiv!=null)
                    {
                        foreach (var userrec in userRoles)
                        {
                            if(userrec =="Division Head" || userrec =="Unit Lead" || userrec =="Programme Lead"  || userrec =="Nepad Staff" )
                            {
                                _result = await userManager.RemoveFromRoleAsync(_user, userrec);
                            }
                        }
                        

                    }

                    //Delete division mapping
                    _strucDivStaffMappingRepository.Delete(rec.Transaction_Id);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Struc_Directorate_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.Record_Status==null)
                        {
                            _strucDirectorateRepository.Delete(rec.Record_Id);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_Outcomes_Delete([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_Outcomes rec=_wpOutcomesRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    _wpOutcomesRepository.Delete(rec.Transaction_Id);

                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
		public ActionResult WP_Outputs_Delete([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_Outputs rec=_wpOutputsRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    _wpOutputsRepository.Delete(rec.Transaction_Id);

                } 

                var DB_Recs =  _wpOutputIndicatorsRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);

                //Delete all related indicators
                foreach (var recordset in DB_Recs)
                {
                        _wpOutputIndicatorsRepository.Delete(recordset.Transaction_Id);
                }

                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }





        [AcceptVerbs("Post")]
		public ActionResult WP_MTP_Delete([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_MTP rec=_wpMTPRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    _wpMTPRepository.Delete(rec.Transaction_Id);

                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_MemberState_Delete([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_CountryScope rec=_wpCountryScopeRepository.GetRecord(record.Transaction_Id);
                
                if (rec != null)
                {
                    _wpCountryScopeRepository.Delete(rec.Transaction_Id);

                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult Struc_Division_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {


                        if(rec.Record_Status==null)
                        {
                            _strucDivisionRepository.Delete(rec.Record_Id);
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
        [AcceptVerbs("Post")]
		public ActionResult Trans_StrucDirectorate_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_StrucDirectorate rec = _transStrucDirectorateRepository.GetRecord(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transStrucDirectorateRepository.Delete(rec.Transaction_Id);

                    Struc_Directorate rec_update=_strucDirectorateRepository.GetRecord(rec.Record_Id);
                    rec_update.Record_Status=false;
                    _strucDirectorateRepository.Update(rec_update);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_StrucDivision_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_StrucDivision rec = _transStrucDivisionRepository.GetRecord(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transStrucDivisionRepository.Delete(rec.Transaction_Id);

                    Struc_Division rec_update=_strucDivisionRepository.GetRecord(rec.Division_Id);
                    rec_update.Record_Status=false;
                    _strucDivisionRepository.Update(rec_update);
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

        public ActionResult Struc_Directorate_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _strucDirectorateRepository.GetAllRecords();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        LookUp_Name =rec.Record_Name,
                        Show_trans_button=rec.Record_Status.HasValue? rec.Record_Status.Value? false: true: true,
                        LookUp_Status = rec.Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive",
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_Outcomes_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutcomesRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WorkplansViewModel srec = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Outcome=rec.Outcome,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_Outputs_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WorkplansViewModel srec = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_OutputsBudget_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();
            double grandtotal=0;

            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    WP_OutputBudget wpoutputbudget_recfetch=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Transaction_Id);
                    
                    if(wpoutputbudget_recfetch!=null)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wpoutputbudget_recfetch.WPMainRecord_id);
                        WorkplansViewModel srec_1 = new WorkplansViewModel
                        {
                            Transaction_Id = wpoutputbudget_recfetch.Transaction_Id,
                            WPMainRecord_Ident=rec.WPMainRecord_id,
                            Output=rec.Output,
                            WPOutput_Id=rec.Transaction_Id,
                            Output_BudgetAmount=wpoutputbudget_recfetch.Output_BudgetAmount,
                            WPSAPLink_Id=wpoutputbudget_recfetch.WPSAPLink_Id,
                            UtilizationPercentage=wpoutputbudget_recfetch.UtilizationPercentage,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        if(mainrec.LinkToSAPExecution==true)
                        {
                            srec_1.LinkToSAPExecutionVM=true;
                            srec_1.LinkToSAPExecutionStringVM="true";
                            
                        }
                        else
                        {
                            srec_1.LinkToSAPExecutionVM=false;
                            srec_1.LinkToSAPExecutionStringVM="false";
                            
                        }

                        if(wpoutputbudget_recfetch.WPSAPLink_Id!=null)
                        {
                            srec_1.LinkToSAPExecutionDisplayVM="Linked to SAP";

                        }
                        else
                        {
                            srec_1.LinkToSAPExecutionDisplayVM="Not Linked to SAP";

                        }
                        grandtotal=grandtotal+wpoutputbudget_recfetch.Output_BudgetAmount;

                        collection_recs.Add(srec_1);
                    }
                    else
                    {
                        WorkplansViewModel srec_2 = new WorkplansViewModel
                        {
                            Transaction_Id = "",
                            WPMainRecord_Ident=rec.WPMainRecord_id,
                            Output=rec.Output,
                            WPOutput_Id=rec.Transaction_Id,
                            Output_BudgetAmount=0,
                            WPSAPLink_Id="",
                            UtilizationPercentage=0,
                            LinkToSAPExecutionVM=false,
                            LinkToSAPExecutionStringVM="false",
                            LinkToSAPExecutionDisplayVM="Not Linked to SAP",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };

                        collection_recs.Add(srec_2);
                    }
                    

                }
                WorkplansViewModel srec_3 = new WorkplansViewModel
                {
                    Transaction_Id = "",
                    WPMainRecord_Ident="",
                    Output="Grand Total (USD)",
                    WPOutput_Id="",
                    Output_BudgetAmount=grandtotal,
                    WPSAPLink_Id="",
                    UtilizationPercentage=0,
                    LinkToSAPExecutionVM=false,
                    LinkToSAPExecutionStringVM="false",
                    LinkToSAPExecutionDisplayVM=""
                };

                collection_recs.Add(srec_3);
            }
            



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_OutputsBudgetLink_Read([DataSourceRequest]DataSourceRequest request, string transid)
        {


            List<WP_OutputBudgetSAPLinkVM> collection_recs = new List<WP_OutputBudgetSAPLinkVM>();


            WP_OutputBudget recbudget=  _wpOutputBudgetRepository.GetRecord(transid);

            if(recbudget!=null)
            {
                if(recbudget.WPSAPLink_Id!=null)
                {
                    var DB_BudgetSAPLinks=_wpOutputBudgetRepository.GetRecordsBySAPLinkId(recbudget.WPSAPLink_Id);
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(recbudget.WPSAPLink_Id);

                    double totalalreadylinkcost=0;
                    double sapbudgetutilization=0;

                    foreach (var record in DB_BudgetSAPLinks)
                    {
                        totalalreadylinkcost=totalalreadylinkcost+record.Output_BudgetAmount;
                    }

                    sapbudgetutilization=Math.Round((totalalreadylinkcost/saplinkrec.SAP_BudgetAmount)*100);

                    WP_OutputBudgetSAPLinkVM srec = new WP_OutputBudgetSAPLinkVM
                    {
                        Transaction_IdSAPVM = transid,
                        WPSAPBudget_WBSSAPVM=saplinkrec.SAP_WBS,
                        UtilizationPercentageSAPVM=sapbudgetutilization
                    };

                    collection_recs.Add(srec);

                }
            }

           
            



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_OutputsSubIndicators_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputIndicatorsSubGridVM> collection_recs = new List<WP_OutputIndicatorsSubGridVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputIndicatorsRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WP_OutputIndicatorsSubGridVM srec = new WP_OutputIndicatorsSubGridVM
                    {
                        Transaction_IndicatorId = rec.WPOutput_Id,
                        Output_ChildGridId = rec.WPOutput_Id,
                        Transaction_IdOIVM=rec.Transaction_Id,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    if(rec.IndicatorCategory=="Strategic")
                    {
                        srec.IndicatorStatementOIVM=_strategyOutputIndicatorsRepository.GetRecord(rec.OutputIndicator_Id).Record_Name;
                    }
                    else if (rec.IndicatorCategory=="Project-Based")
                    {
                        srec.IndicatorStatementOIVM=rec.ProjectBasedIndicatorStatement;

                    }


                    if(rec.IndicatorType=="Quantitative")
                    {
                        srec.BaselineOIVM=rec.BaselineQuantitative.ToString();
                        srec.TargetOIVM=rec.TargetQuantitative.ToString();
                    }
                    else
                    {
                        srec.BaselineOIVM=rec.BaselineQuanlitative;
                        srec.TargetOIVM=rec.TargetQuanlitative;

                    }

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_OutputsSubActivities_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputActivitiesSubGridVM> collection_recs = new List<WP_OutputActivitiesSubGridVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputActivitiesRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();
            double totalcost=0;


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WP_OutputActivitiesSubGridVM srec = new WP_OutputActivitiesSubGridVM
                    {
                        Transaction_IdOAVM=rec.Transaction_Id,
                        ActivityTypeName_IdOAVM=_lkupActivityTypeRepository.GetActivityType(rec.ActivityType_Id).Activity_Name,
                        ActivityDescriptionOAVM=rec.ActivityDescription,
                        ActivityCostOAVM=rec.ActivityCost,
                        ShowGridButtons="YES",

                        TransactionDateOAVM = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    totalcost=totalcost+rec.ActivityCost;

                    collection_recs.Add(srec);
                }
                   
                WP_OutputActivitiesSubGridVM srectotal = new WP_OutputActivitiesSubGridVM
                {
                    Transaction_IdOAVM="",
                    ActivityTypeName_IdOAVM="",
                    ActivityDescriptionOAVM="TOTAL COST",
                    ActivityCostOAVM=totalcost,
                    ShowGridButtons="NO"
                };
                collection_recs.Add(srectotal);


            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_MTPs_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WorkplansViewModel srec = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        MTP_Ident=rec.MTP_Id,
                        MTP_PriorityStatement=_strategyMTPRepository.GetRecord(rec.MTP_Id).Record_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_CountryScope_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpCountryScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WorkplansViewModel srec = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Counry_Ident=rec.Country_Id,
                        Statement=_lkupCountryRepository.GetCountry(rec.Country_Id).Country_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_MTPsActual_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

          //  var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            var DB_RecsTrans =  _transStrategyMTPRepository.GetAllRecords().ToList();

            //int _count =  DB_Recs.Count();
            int iter=0;



            foreach (var rec in DB_RecsTrans)
            {
                WP_MTP wpmtp_recfetch=_wpMTPRepository.GetRecordsByProjectYearPeriodAndMTP(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id);
                
                iter=iter+1;
                if(wpmtp_recfetch!=null)
                {
                        WorkplansViewModel srec_1 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=wpmtp_recfetch.Transaction_Id,
                            Transaction_Id = wpmtp_recfetch.Transaction_Id,
                            WPMainRecord_Ident=wpmtp_recfetch.WPMainRecord_id,
                            MTP_Ident=wpmtp_recfetch.MTP_Id,
                            MTP_PriorityStatement=_strategyMTPRepository.GetRecord(wpmtp_recfetch.MTP_Id).Record_Name,
                            SelectedRow="Selected",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_1);
                }
                else
                {
                        WorkplansViewModel srec_2 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=Guid.NewGuid().ToString(),
                            Transaction_Id = "",
                            WPMainRecord_Ident="",
                            MTP_Ident=rec.Record_Id,
                            SelectedRow="UnSelected",
                            MTP_PriorityStatement=_strategyMTPRepository.GetRecord(rec.Record_Id).Record_Name,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_2);


                }
            }





            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_RECsActual_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

          //  var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            var DB_RecsTrans =  _transRegionScopeRepository.GetAllRecords().ToList();

            //int _count =  DB_Recs.Count();
            int iter=0;



            foreach (var rec in DB_RecsTrans)
            {
                WP_RegionScope wp_recfetch=_wpRegionScopeRepository.GetRecordsByProjectYearPeriodAndRegion(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id);
                
                iter=iter+1;
                if(wp_recfetch!=null)
                {
                        WorkplansViewModel srec_1 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=wp_recfetch.Transaction_Id,
                            Transaction_Id = wp_recfetch.Transaction_Id,
                            WPMainRecord_Ident=wp_recfetch.WPMainRecord_id,
                            REC_Ident=wp_recfetch.Region_Id,
                            Statement=_lkupRegionScopeRepository.GetRecord(wp_recfetch.Region_Id).Record_Name,
                            SelectedRow="Selected",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_1);
                }
                else
                {
                        WorkplansViewModel srec_2 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=Guid.NewGuid().ToString(),
                            Transaction_Id = "",
                            WPMainRecord_Ident="",
                            REC_Ident=rec.Record_Id,
                            SelectedRow="UnSelected",
                            Statement=_lkupRegionScopeRepository.GetRecord(rec.Record_Id).Record_Name,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_2);


                }
            }





            return Json(collection_recs.ToDataSourceResult(request));
        }
        public ActionResult WP_AUDAPrioritiesActual_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_RecsTrans =  _transStrategyPriorityRepository.GetAllRecords().ToList();


            int iter=0;



            foreach (var rec in DB_RecsTrans)
            {
                WP_AUDAPriority wpaudapriority_recfetch=_wpAUDAPriorityRepository.GetRecordsByProjectYearPeriodAndPriority(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id);
                
                iter=iter+1;
                if(wpaudapriority_recfetch!=null)
                {
                        WorkplansViewModel srec_1 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=wpaudapriority_recfetch.Transaction_Id,
                            Transaction_Id = wpaudapriority_recfetch.Transaction_Id,
                            WPMainRecord_Ident=wpaudapriority_recfetch.WPMainRecord_id,
                            AUDAPriority_Ident=wpaudapriority_recfetch.Priority_Id,
                            MTP_Ident=wpaudapriority_recfetch.MTP_Id,
                            AUDA_PriorityStatement=_strategyPriorityRepository.GetRecord(wpaudapriority_recfetch.Priority_Id).Record_Name,
                            SelectedRow="Selected",
                            EnableRow=GetEnableStatus(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id),
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_1);
                }
                else
                {
                        WorkplansViewModel srec_2 = new WorkplansViewModel
                        {
                            SessionTransaction_Id=Guid.NewGuid().ToString(),
                            Transaction_Id = "",
                            WPMainRecord_Ident="",
                            AUDAPriority_Ident=rec.Record_Id,
                            MTP_Ident=999,
                            SelectedRow="UnSelected",
                            EnableRow=GetEnableStatus(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id),
                            AUDA_PriorityStatement=_strategyPriorityRepository.GetRecord(rec.Record_Id).Record_Name,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_2);


                }
            }




            return Json(collection_recs.ToDataSourceResult(request));
        }
        public string GetEnableStatus(int projid, int fyear, int fperiod, int priority)
        {

            var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(projid, fyear, fperiod);

            int _count =  DB_Recs.Count();

            string rtnval="No";

            foreach (var rec in DB_Recs)
            {
                Strategy_MTPPriorityMapping fetched_rec=_strategyMTPPriorityMappingRepository.GetRecordsByMTPAndPriority(rec.MTP_Id, priority);
                
                if(fetched_rec!=null)
                {
                    rtnval="Yes";
                }
            }



            return rtnval;


        }

        public ActionResult Ident_Roles_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var userRoles = roleManager.Roles;

            int _count =  userRoles.Count();


            if (_count > 0)
            {
                foreach (var rec in userRoles)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        Trans_LookUp_Id = rec.Id,
                        LookUp_Name =rec.Name
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        public ActionResult Struc_Division_Read([DataSourceRequest]DataSourceRequest request, string text)
        {
            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _strucDivisionRepository.GetAllRecords().ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        LookUp_Name =rec.Record_Name,
                        ParentLink_Id=rec.Directorate_Id,
                        Show_trans_button=rec.Record_Status.HasValue? rec.Record_Status.Value? false: true: true,
                        LookUp_Status = rec.Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive",
                        Category = new DropDownListViewModel()
                        {
                            DropDown_IntId = rec.Directorate_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name
                        },
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

        public ActionResult Trans_StrucDirectorate_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        Trans_LookUp_Id=rec.Transaction_Id,
                        LookUp_Name =_strucDirectorateRepository.GetRecord(rec.Record_Id).Record_Name,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Trans_StrucDivision_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transStrucDivisionRepository.GetAllRecords().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        
                        Trans_LookUp_Id=rec.Transaction_Id,
                        Trans_Parent_LookUp_Id=rec.TransDirectorate_Id,
                        ParentLink_Id=rec.Division_Id,
                        LookUp_Name =_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                        Category = new DropDownListViewModel()
                        {
                            DropDown_IntId = _transStrucDirectorateRepository.GetRecord(rec.TransDirectorate_Id).Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(_transStrucDirectorateRepository.GetRecord(rec.TransDirectorate_Id).Record_Id).Record_Name
                        },
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        
        public ActionResult DirectorateStaffMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Mapping_Status == true ? "Enabled" : "Disabled",
                            Primary_String = rec.PrimaryDirectorate == true ? "Primary" : "Secondary",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult MTPPriorityMapping_Read ([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<StrategyPriorityViewModel> collection_recs = new List<StrategyPriorityViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strategyMTPPriorityMappingRepository.GetAllRecordsByMTP(Int32.Parse(recid)).ToList();

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        StrategyPriorityViewModel srec = new StrategyPriorityViewModel
                        {
                            
                            Transaction_Id=rec.Transaction_Id,
                            MTPPriority_Id = rec.MTP_Id,
                            Priority_Id=rec.Priority_Id,
                            Priority_Name=_strategyPriorityRepository.GetRecord(rec.Priority_Id).Record_Name,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult DirectorateWPCycleSAPLink_Read ([DataSourceRequest]DataSourceRequest request, string dir_id, string wpcycle_id)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

            if (dir_id != null && wpcycle_id != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _wpSAPLinkRepository.GetAllRecordsByDirectorateAndWPCycle(Int32.Parse(dir_id), wpcycle_id).ToList();

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        string str="";
                        WorkplansViewModel srec = new WorkplansViewModel
                        {
                            
                            Transaction_Id=rec.Transaction_Id,
                            WPDispatchCycle_Ident=rec.WPDispatchCycle_Id,
                            Directorate_Id=rec.Directorate_Id,
                            SAPWBS=rec.SAP_WBS,
                            SAPDescription=rec.SAP_Description,
                            SAPAmount=rec.SAP_BudgetAmount,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        var linkedbudgets=_wpOutputBudgetRepository.GetRecordsBySAPLinkId(rec.Transaction_Id).GroupBy(x => x.Period_Id).Select(x => x.First()).ToList();
                        int itercount=linkedbudgets.Count();

                        int iter=0;
                        if(linkedbudgets.Count()<=0)
                        {
                            str="No Linked Project";
                        }
                        else
                        {
                            foreach (var recordset in linkedbudgets)
                            {
                                iter=iter+1;
                                if(iter==itercount)
                                {
                                    str += "["+iter+"]"+  _lkupProjectRepository.GetRecord(recordset.Project_Id).Record_Name;
                                }
                                else
                                {
                                    str += "["+iter+"]"+  _lkupProjectRepository.GetRecord(recordset.Project_Id).Record_Name+", ";
                                }
                               
                            }
                        }

                        srec.SAPWBSLinkedProjects=str;


                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WorkplanCurrentCycles_Read([DataSourceRequest]DataSourceRequest request)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();



                var DB_Recs = _wpDispatchCycleRepository.GetAllCurrentAndInactiveWPDispatch();

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {


                        WorkplansViewModel srec = new WorkplansViewModel
                        {
                            Transaction_Id=rec.Transaction_Id,
                            Employee_Id = rec.Employee_Id,
                            FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                            FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name,
                            WPStatus_String = rec.Dispatch_Status.HasValue? rec.Dispatch_Status.Value? "Current": "Closed": "Inactive",
                            WPSAPLinkView_String= rec.LinkToSAPExecution.HasValue? rec.LinkToSAPExecution.Value? "Linked": "Not Linked": "Not Linked",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WorkplanClosedCycles_Read([DataSourceRequest]DataSourceRequest request)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();



                var DB_Recs = _wpDispatchCycleRepository.GetAllClosedWPDispatch();

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {


                        WorkplansViewModel srec = new WorkplansViewModel
                        {
                            Transaction_Id=rec.Transaction_Id,
                            Employee_Id = rec.Employee_Id,
                            FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                            FisPeriod=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name,
                            WPStatus_String = rec.Dispatch_Status.HasValue? rec.Dispatch_Status.Value? "Current": "Closed": "Inactive",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult DirectorateDirectorMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDirectorRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Status.HasValue? rec.Status.Value? "Substantive": "Not Assigned": "Inactive",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }
        public ActionResult DivisionHeadMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
               // var DB_Recs = _strucDirectorRepository.GetAllRecordsByDirectorate(Int32.Parse(recid));
                var DB_Recs = _strucDivHeadRepository.GetAllRecordsByDivision(Int32.Parse(recid));


                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Mapping_Status_String = rec.Status.HasValue? rec.Status.Value? "Substantive": "Not Assigned": "Inactive",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }




        public ActionResult DivisionStaffMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _strucDivStaffMappingRepository.GetAllRecordsByDivision(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);

                        string profilepicpath = "";
                        if (employee.PhotoPath == null)
                        {
                            if (employee.Gender == 1)
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                            else if (employee.Gender == 2)
                                profilepicpath = "appdirectory/profilepics/female_null_profile.jpg";
                            else
                                profilepicpath = "appdirectory/profilepics/male_null_profile.jpg";
                        }
                        else
                        {
                            profilepicpath = "appdirectory/" + employee.Staff_Number + "/" + employee.PhotoPath;

                        }

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            EmployeePK = employee.Id,
                            Transaction_Id=rec.Transaction_Id,
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
                            Directorate_Id=rec.Directorate_Id,
                            Division_Id=rec.Division_Id,
                            Mapping_Status_String = rec.Mapping_Status == true ? "Enabled" : "Disabled",
                            Primary_String = rec.PrimaryDivision == true ? "Primary" : "Secondary",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
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

        [HttpPost]
        public async Task<ActionResult> CloseWorkplanCycle(string recid)
        {
             var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(recid);

                if(rec!=null)
                {
                    rec.Dispatch_Status=false;
                    rec.Employee_Id=user.Employee_Id;
                    _wpDispatchCycleRepository.Update(rec);
                }


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult WP_OutputsSubIndicators_Delete(string subindicatorid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                WP_OutputIndicators rec=_wpOutputIndicatorsRepository.GetRecord(subindicatorid);
                
                if (rec != null)
                {
                    _wpOutputIndicatorsRepository.Delete(rec.Transaction_Id);

                } 


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult WP_SAPWBSLink_Delete(string transid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                var linkedbudgets=_wpOutputBudgetRepository.GetRecordsBySAPLinkId(transid);

                if(linkedbudgets.Count()<=0)
                {
                    WP_SAPLink rec=_wpSAPLinkRepository.GetRecord(transid);
                    
                    if (rec != null)
                    {
                        _wpSAPLinkRepository.Delete(rec.Transaction_Id);

                    } 
                }


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> OpenWorkplanCycle(string recid)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(recid);

                if(rec!=null)
                {
                    rec.Dispatch_Status=true;
                    rec.Employee_Id=user.Employee_Id;
                    _wpDispatchCycleRepository.Update(rec);
                }


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult MakeDirectorateTrans(string recid)
        {
            try
            {
                Struc_Directorate rec = _strucDirectorateRepository.GetRecord(Int32.Parse(recid));
                rec.Record_Status=true;
                _strucDirectorateRepository.Update(rec);

                Trans_StrucDirectorate rec_trans = new Trans_StrucDirectorate
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Record_Id = rec.Record_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transStrucDirectorateRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult MakeDivisionTrans(string recid)
        {
            try
            {
                Struc_Division rec = _strucDivisionRepository.GetRecord(Int32.Parse(recid));
                rec.Record_Status=true;
                _strucDivisionRepository.Update(rec);

                Trans_StrucDivision rec_trans = new Trans_StrucDivision
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Division_Id = rec.Record_Id,
                    TransDirectorate_Id=_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(rec.Directorate_Id).Transaction_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transStrucDivisionRepository.Add(rec_trans);

                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        //**************KENDO WINDOW PARTIAL VIEWS******************///
        public ActionResult AddStrucDivision()
        {
            LookUpTablesViewModel model = new LookUpTablesViewModel
            {
            };

            return PartialView("_AddStrucDivision", model);
        }


        public ActionResult EditStaffDirectorateMapping(string transid)
        {
            Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(transid);
            EmployeeMappingViewModel model = new EmployeeMappingViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                EmployeePK=rec.EmployeePK,
                Directorate_Id=rec.Directorate_Id,
                Directorate_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name,
                EmployeeName=_employeeRepository.GetEmployee(rec.EmployeePK).First_Name+" "+_employeeRepository.GetEmployee(rec.EmployeePK).Last_Name,
                Mapping_Status=rec.Mapping_Status,
                Primary=rec.PrimaryDirectorate


            };




            return PartialView("_EditStaffDirectorateMapping", model);
        }
        public ActionResult EditStaffDivisionMapping(string transid)
        {
            Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(transid);
            EmployeeMappingViewModel model = new EmployeeMappingViewModel
            {
                Transaction_Id=rec.Transaction_Id,
                EmployeePK=rec.EmployeePK,
                Directorate_Id=rec.Directorate_Id,
                Division_Id=rec.Division_Id,
                Directorate_Name = _strucDirectorateRepository.GetRecord(rec.Directorate_Id).Record_Name,
                Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                EmployeeName=_employeeRepository.GetEmployee(rec.EmployeePK).First_Name+" "+_employeeRepository.GetEmployee(rec.EmployeePK).Last_Name,
                Mapping_Status=rec.Mapping_Status,
                Primary=rec.PrimaryDivision


            };




            return PartialView("_EditStaffDivisionMapping", model);
        }

        [HttpPost]
        public ActionResult EditStaffDirectorateMapping(EmployeeMappingViewModel model)
        {
            
            Struc_DirStaffMapping rec = _strucDirStaffMappingRepository.GetRecord(model.Transaction_Id);

            
            if (rec != null)
            {
                Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(rec.EmployeePK);

                Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, model.Directorate_Id);

                if(model.Primary==false || (model.Primary==true && primarydir ==null) || thisprimarydir!=null)
                {
                    try
                    {

                        rec.Mapping_Status=model.Mapping_Status;
                        rec.PrimaryDirectorate=model.Primary;

                        _strucDirStaffMappingRepository.Update(rec);

                        Struc_DivStaffMapping primarydivrec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(rec.EmployeePK);

                        if(primarydivrec!=null)
                        {
                            if(primarydivrec.Directorate_Id==model.Directorate_Id)
                            {
                                primarydivrec.PrimaryDivision=false;
                                _strucDivStaffMappingRepository.Update(primarydivrec);

                            }
                        }

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "otherprimaryalreadyexist" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "doesnotexist" });
            }



        }



        [HttpPost]
        public ActionResult EditWorkplanCycle(WorkplansViewModel model)
        {
            
            WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecord(model.Transaction_Id);

            
            if (rec != null)
            {
                try
                {

                    rec.Employee_Id=model.Employee_Id;

                    //WP Status
                    if(model.WPStatus==false)
                        rec.Dispatch_Status=null;
                    else
                        rec.Dispatch_Status=model.WPStatus;


                    //Link to SAP
                    if(model.WPSAPLinkView==false)
                        rec.LinkToSAPExecution=null;
                    else
                        rec.LinkToSAPExecution=model.WPSAPLinkView;


                    _wpDispatchCycleRepository.Update(rec);

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
             
            }
            else
            {
                return Json(new { rtnmsg = "doesnotexist" });
            }



        }

        [HttpPost]
        public ActionResult AddStrategicIndicator(WP_OutputIndicatorsVM model)
        {
            
            WP_OutputIndicators rec = _wpOutputIndicatorsRepository.GetRecordByProjectYearAndPeriodOutputIdIndicatorId(model.Project_IdOIVM, model.FiscalYear_IdOIVM, model.Period_IdOIVM, model.Transaction_IdOIVM, model.OutputIndicator_IdOIVM);

            
            if (rec == null)
            {
                try
                {
                        WP_OutputIndicators rec_to_add = new WP_OutputIndicators
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id= model.WPMainRecord_idOIVM,
                            WPOutput_Id=model.Transaction_IdOIVM,
                            Project_Id=model.Project_IdOIVM,
                            FiscalYear_Id=model.FiscalYear_IdOIVM,
                            Period_Id=model.Period_IdOIVM,
                            IndicatorCategory="Strategic",
                            IndicatorType=_strategyOutputIndicatorsRepository.GetRecord(model.OutputIndicator_IdOIVM).Indicator_Type,
                            OutputIndicator_Id=model.OutputIndicator_IdOIVM,
                            Priority_Id=model.Priority_IdOIVM,
                            Employee_Id= model.Employee_IdOIVM,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        if(_strategyOutputIndicatorsRepository.GetRecord(model.OutputIndicator_IdOIVM).Indicator_Type=="Quantitative")
                        {
                            rec_to_add.BaselineQuantitative=model.BaselineQuantitativeOIVM;
                            rec_to_add.TargetQuantitative=model.TargetQuantitativeOIVM;
                        } 
                        else
                        {
                            rec_to_add.BaselineQuanlitative=model.BaselineQuanlitativeOIVM;
                            rec_to_add.TargetQuanlitative=model.TargetQuanlitativeOIVM;

                        }

                        _wpOutputIndicatorsRepository.Add(rec_to_add);


                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
             
            }
            else
            {
                return Json(new { rtnmsg = "pkerror" });
            }



        }

        [HttpPost]
        public ActionResult AddOutputActivity(WP_OutputActivitiesVM model)
        {
            
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.Transaction_IdOAVMMain);

                if(recbudget==null)
                {
                    WP_OutputActivities rec_to_add_1 = new WP_OutputActivities
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.Transaction_IdOAVMMain,
                        Project_Id=model.Project_IdOAVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOAVMMain,
                        Period_Id=model.Period_IdOAVMMain,
                        ActivityType_Id=model.ActivityType_IdOAVMMain,
                        ActivityDescription=model.ActivityDescriptionOAVMMain,
                        ActivityCost=model.ActivityCostOAVMMain,
                        ActivityStartDate=new LocalDate(model.ActivityStartDateOAVMMain.Year, model.ActivityStartDateOAVMMain.Month, model.ActivityStartDateOAVMMain.Day),
                        ActivityEndDate=new LocalDate(model.ActivityEndDateOAVMMain.Year, model.ActivityEndDateOAVMMain.Month, model.ActivityEndDateOAVMMain.Day),
                        ImplementationType_Id=model.ImplementationType_IdOAVMMain,
                        BaselineTechnical=model.BaselineTechnicalOAVMMain,
                        BaselineFinancial=model.BaselineFinancialOAVMMain,
                        Employee_Id= model.Employee_IdOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpOutputActivitiesRepository.Add(rec_to_add_1);

                    WP_OutputBudget recbudget_to_add_1 =new WP_OutputBudget
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.Transaction_IdOAVMMain,
                        Project_Id=model.Project_IdOAVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOAVMMain,
                        Period_Id=model.Period_IdOAVMMain,
                        Output_BudgetAmount=model.ActivityCostOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)

                    };
                    _wpOutputBudgetRepository.Add(recbudget_to_add_1);

                    var DB_Recs_1 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                    double totalcost_1=0;
                    foreach (var record in DB_Recs_1)
                    {
                        totalcost_1=totalcost_1+record.ActivityCost;

                    }
                    
                    WP_OutputBudget recbudget_1=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.Transaction_IdOAVMMain);
                    
                    recbudget_1.Output_BudgetAmount=totalcost_1;
                    _wpOutputBudgetRepository.Update(recbudget_1);

                }
                else if (recbudget.WPSAPLink_Id==null)
                {
                    WP_OutputActivities rec_to_add_2 = new WP_OutputActivities
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.Transaction_IdOAVMMain,
                        Project_Id=model.Project_IdOAVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOAVMMain,
                        Period_Id=model.Period_IdOAVMMain,
                        ActivityType_Id=model.ActivityType_IdOAVMMain,
                        ActivityDescription=model.ActivityDescriptionOAVMMain,
                        ActivityCost=model.ActivityCostOAVMMain,
                        ActivityStartDate=new LocalDate(model.ActivityStartDateOAVMMain.Year, model.ActivityStartDateOAVMMain.Month, model.ActivityStartDateOAVMMain.Day),
                        ActivityEndDate=new LocalDate(model.ActivityEndDateOAVMMain.Year, model.ActivityEndDateOAVMMain.Month, model.ActivityEndDateOAVMMain.Day),
                        ImplementationType_Id=model.ImplementationType_IdOAVMMain,
                        BaselineTechnical=model.BaselineTechnicalOAVMMain,
                        BaselineFinancial=model.BaselineFinancialOAVMMain,
                        Employee_Id= model.Employee_IdOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpOutputActivitiesRepository.Add(rec_to_add_2);


                    var DB_Recs_2 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                    double totalcost_2=0;
                    foreach (var record in DB_Recs_2)
                    {
                        totalcost_2=totalcost_2+record.ActivityCost;

                    }

                    recbudget.Output_BudgetAmount=totalcost_2;
                    _wpOutputBudgetRepository.Update(recbudget);

                }
                else
                {

                    var DB_BudgetSAPLinks=_wpOutputBudgetRepository.GetRecordsBySAPLinkId(recbudget.WPSAPLink_Id);
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(recbudget.WPSAPLink_Id);

                    double totalcost_3=0;
                    double totalalreadylinkcost_3=0;
                    double totalremainingsapbudget_3=0;



                    foreach (var record in DB_BudgetSAPLinks)
                    {
                        totalalreadylinkcost_3=totalalreadylinkcost_3+record.Output_BudgetAmount;
                    }

                    totalremainingsapbudget_3=saplinkrec.SAP_BudgetAmount-totalalreadylinkcost_3;
                

                    if(totalremainingsapbudget_3>=model.ActivityCostOAVMMain)
                    {
                        WP_OutputActivities rec_to_add_3 = new WP_OutputActivities
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                            WPOutput_Id=model.Transaction_IdOAVMMain,
                            Project_Id=model.Project_IdOAVMMain,
                            FiscalYear_Id=model.FiscalYear_IdOAVMMain,
                            Period_Id=model.Period_IdOAVMMain,
                            ActivityType_Id=model.ActivityType_IdOAVMMain,
                            ActivityDescription=model.ActivityDescriptionOAVMMain,
                            ActivityCost=model.ActivityCostOAVMMain,
                            ActivityStartDate=new LocalDate(model.ActivityStartDateOAVMMain.Year, model.ActivityStartDateOAVMMain.Month, model.ActivityStartDateOAVMMain.Day),
                            ActivityEndDate=new LocalDate(model.ActivityEndDateOAVMMain.Year, model.ActivityEndDateOAVMMain.Month, model.ActivityEndDateOAVMMain.Day),
                            ImplementationType_Id=model.ImplementationType_IdOAVMMain,
                            BaselineTechnical=model.BaselineTechnicalOAVMMain,
                            BaselineFinancial=model.BaselineFinancialOAVMMain,
                            Employee_Id= model.Employee_IdOAVMMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _wpOutputActivitiesRepository.Add(rec_to_add_3);

                        var DB_Recs_3 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                        foreach (var record in DB_Recs_3)
                        {
                            totalcost_3=totalcost_3+record.ActivityCost;

                        }

                        recbudget.Output_BudgetAmount=totalcost_3;
                        _wpOutputBudgetRepository.Update(recbudget);

                    }
                    else
                    {
                        return Json(new { rtnmsg = "insufficientsapfunds" });

                    }

                }


                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
             




        }

        [HttpPost]
        public ActionResult AddStrategicIndicator_ProjectBased(WP_OutputIndicatorsVM model)
        {
            
            try
            {
                    WP_OutputIndicators rec_to_add = new WP_OutputIndicators
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOIVM,
                        WPOutput_Id=model.Transaction_IdOIVM,
                        Project_Id=model.Project_IdOIVM,
                        FiscalYear_Id=model.FiscalYear_IdOIVM,
                        Period_Id=model.Period_IdOIVM,
                        IndicatorCategory="Project-Based",
                        ProjectBasedIndicatorStatement=model.ProjectBasedIndicatorStatementOIVM,
                        Employee_Id= model.Employee_IdOIVM,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    if(model.IndicatorTypeOIVM_Proj== 1)
                    {
                        rec_to_add.BaselineQuantitative=model.BaselineQuantitativeOIVM_Proj;
                        rec_to_add.TargetQuantitative=model.TargetQuantitativeOIVM_Proj;
                        rec_to_add.IndicatorType="Quantitative";
                    } 
                    else
                    {
                        rec_to_add.BaselineQuanlitative=model.BaselineQuanlitativeOIVM_Proj;
                        rec_to_add.TargetQuanlitative=model.TargetQuanlitativeOIVM_Proj;
                        rec_to_add.IndicatorType="Qualitative";

                    }

                    _wpOutputIndicatorsRepository.Add(rec_to_add);


                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
   



        }

        [HttpPost]
        public ActionResult AddWorkplanCycle(WorkplansViewModel model)
        {
            
            WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecordByYearAndPeriod(model.FYearIdent, model.FPeriodIdent);

            
            if (rec == null)
            {
                    try
                    {
                        WP_DispatchCycle rec_to_add = new WP_DispatchCycle
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            FiscalYear_Id= model.FYearIdent,
                            Period_Id=model.FPeriodIdent,
                            Employee_Id= model.Employee_Id,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        //WP Status
                        if(model.WPStatus==false)
                            rec_to_add.Dispatch_Status=null;
                        else
                            rec_to_add.Dispatch_Status=model.WPStatus;

                        //Link to SAP
                        if(model.WPSAPLinkView==false)
                            rec_to_add.LinkToSAPExecution=null;
                        else
                            rec_to_add.LinkToSAPExecution=model.WPSAPLinkView;

                        _wpDispatchCycleRepository.Add(rec_to_add);

                        

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
           
            }
            else
            {
                return Json(new { rtnmsg = "pkerror" });
            }



        }

        [HttpPost]
        public ActionResult AddWPCycleSAPLink(WorkplansViewModel model)
        {
            
            WP_SAPLink rec = _wpSAPLinkRepository.GetAllRecordsByDirectorateWPCycleAndWBS(model.Directorate_Id, model.WPDispatchCycle_Ident, model.SAPWBS);

            
            if (rec == null)
            {
                    try
                    {
                        WP_SAPLink rec_to_add = new WP_SAPLink
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPDispatchCycle_Id= model.WPDispatchCycle_Ident,
                            Directorate_Id=model.Directorate_Id,
                            SAP_WBS= model.SAPWBS,
                            SAP_Description=model.SAPDescription,
                            SAP_BudgetAmount=model.SAPAmount,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _wpSAPLinkRepository.Add(rec_to_add);

                        

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
           
            }
            else
            {
                return Json(new { rtnmsg = "pkerror" });
            }



        }

        [HttpPost]
        public ActionResult EditStaffDivisionMapping(EmployeeMappingViewModel model)
        {
            
            Struc_DivStaffMapping rec = _strucDivStaffMappingRepository.GetRecord(model.Transaction_Id);


            if (rec != null)
            {
                Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, model.Division_Id);
                Struc_DivStaffMapping primarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(rec.EmployeePK);

                Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(rec.EmployeePK);
                Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, model.Directorate_Id);

                

                if(model.Primary==false || (model.Primary==true && thisprimarydir !=null && primarydiv==null) || (thisprimarydiv!=null && thisprimarydir!=null))
                {
                    try
                    {

                        rec.Mapping_Status=model.Mapping_Status;
                        rec.PrimaryDivision=model.Primary;

                        _strucDivStaffMappingRepository.Update(rec);

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "notprimarydirectorate" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "doesnotexist" });
            }



        }


        //**************AJAX ACTIONS******************///

        [HttpPost]
        public ActionResult AddStrucDivision(LookUpTablesViewModel record)
        {

            string returnmessage = "";


            if (record != null && ModelState.IsValid)
            {  
                Struc_Division rec = _strucDivisionRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _strucDivisionRepository.GetAllRecords();
                        int _count = DB_Recs.Count();

                        Struc_Division rec_to_add = new Struc_Division
                        {
                            Record_Id=_count+1,
                            Record_Name=record.LookUp_Name,
                            Directorate_Id=record.ParentLink_Id,
                            Record_Status=null,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _strucDivisionRepository.Add(rec_to_add);
                        returnmessage = "success";
                }    
                else
                {
                    returnmessage = "alreadyexist";

                }      
                           
            }
            else
            {
                returnmessage = "error";

            }
            
           return Json(new { rtnmsg = returnmessage });
        }
        //public async Task<ActionResult> AddStaffDirectorateMapping(string dirid, string empid, bool primaryid)
        [HttpPost]
        public async Task<ActionResult> AddStaffDirectorateMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            IdentityResult _result;

            Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            if (rec == null)
            {
                if(model.PrimaryMain==false || (model.PrimaryMain==true && primarydir ==null))
                {
                    try
                    {
                        Struc_DirStaffMapping rec_to_add = new Struc_DirStaffMapping
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            EmployeePK= model.Employee_Id,
                            Staff_Number=emp.Staff_Number,
                            IdentityUserId=emp.IdentityUserId,
                            Directorate_Id= model.Directorate_Id,
                            Mapping_Status=true,
                            PrimaryDirectorate=model.PrimaryMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        _strucDirStaffMappingRepository.Add(rec_to_add);

                        if(emp.IdentityUserId==null || emp.IdentityUserId=="")
                        {
                            var user = new ApplicationUser
                            {
                                UserName = emp.Email,
                                Email = emp.Email,
                                Staff_Number = emp.Staff_Number,
                                Employee_Id = emp.Id,
                                Admin_Generated = true,
                                Ever_LoggedIn=false,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)

                            };

                            // Store user data in AspNetUsers database table
                            string initpassword="AUDAData112233";
                            var result = await userManager.CreateAsync(user, initpassword);

                            if (result.Succeeded)
                            {
                                //await signInManager.SignInAsync(user, isPersistent: false);


                                emp.IdentityUserId = user.Id;
                                //Update Employee Record
                                var employee = _context.Employees.Attach(emp);
                                employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                _context.SaveChanges();

                            }
                            //SEND EMAIL WITH CREDENTIALS

                            string content="<p>Dear "+ emp.First_Name+" "+emp.Last_Name+"</p>"+ 
                                        "<p>&nbsp;</p>" +
                                        "<p>Welcome to <strong>AUDA-NEPAD Integrated Planning System</strong>. An account has been created for you with the following credentials:</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p><strong>Username</strong>:"+" "+ emp.Email+"</p>"+
                                        "<p><strong>Password</strong>: "+ initpassword+ "</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p>You will be required to change the initial password when you login for the first time. Please ensure the password is not shared.&nbsp;</p>"+
                                        "<p>&nbsp;</p>"+
                                        "<p>Kind regards.</p>"+
                                        "<p>AUDA-NEPAD Integrated Planning System Team</p>";

                            var message = new Message(new string[] { emp.TestEmail}, "AUDA-NEPAD Integrated: Password Created", content);
                            await _emailSender.SendEmailAsync(message);
                        }

                        Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                        var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);
                        
                        if(_user!=null)
                        {
                            var isInRole = await userManager.IsInRoleAsync(_user, "Nepad Staff");

                            if (!isInRole)
                            {
                                _result = await userManager.AddToRoleAsync(_user, "Nepad Staff");
                            }
                        }


                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "otherprimaryalreadyexist" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }



        [HttpPost]
        public ActionResult MappMTPAUDAPriority(EmployeeViewModel model)
        {
            
            Strategy_MTPPriorityMapping rec=_strategyMTPPriorityMappingRepository.GetRecordsByMTPAndPriority(model.MTP_Id, model.Priority_Id);


            if (rec == null)
            {
   
                try
                {
                    Strategy_MTPPriorityMapping rec_to_add = new Strategy_MTPPriorityMapping
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        MTP_Id= model.MTP_Id,
                        Priority_Id=model.Priority_Id,
                        Record_Status=true,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };


                    _strategyMTPPriorityMappingRepository.Add(rec_to_add);

                    


                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
           
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }

        [HttpPost]
        public ActionResult AddWPMTPPriority(string projid, string fyear, string fperiod, string mtpid, string empid )
        {

            WP_MTP rec=_wpMTPRepository.GetRecordsByProjectYearPeriodAndMTP(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), Int32.Parse(mtpid));
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            if (rec == null)
            {
   
                try
                {
                    WP_MTP rec_to_add = new WP_MTP
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id=mainrec.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        MTP_Id=Int32.Parse(mtpid),
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };


                    _wpMTPRepository.Add(rec_to_add);

                    


                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
           
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }

        [HttpPost]
        public ActionResult AddWPMemberState(string projid, string fyear, string fperiod, string countryid, string empid )
        {

            WP_CountryScope rec=_wpCountryScopeRepository.GetRecordsByProjectYearPeriodAndCountry(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), Int32.Parse(countryid));
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            if (rec == null)
            {
   
                try
                {
                    WP_CountryScope rec_to_add = new WP_CountryScope
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id=mainrec.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        Country_Id=Int32.Parse(countryid),
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };


                    _wpCountryScopeRepository.Add(rec_to_add);

                    


                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
           
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }

        [HttpPost]
        public ActionResult AddWPMTPPrioritiesXX(string projid, string fyear, string fperiod, string selectkeys, string empid, List<WorkplansViewModel> selectedrows)
        {

            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            string[] selectedkeys = selectkeys.Split(',');

            if(mainrec!=null)
            {
                foreach (string mtpid in selectedkeys)
                {
                    WP_MTP rec=_wpMTPRepository.GetRecordsByProjectYearPeriodAndMTP(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), Int32.Parse(mtpid));

                    if(rec==null)
                    {
                        WP_MTP rec_to_add = new WP_MTP
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=mainrec.Transaction_Id,
                            Project_Id=Int32.Parse(projid),
                            FiscalYear_Id=Int32.Parse(fyear),
                            Period_Id=Int32.Parse(fperiod),
                            MTP_Id=Int32.Parse(mtpid),
                            Employee_Id=Int32.Parse(empid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpMTPRepository.Add(rec_to_add);
                    }
                    else
                    {

                    }  
                }
            }
            else
            {
                //Create main record before saving the mtp workplan mapping
            }

            

  
                    


            return Json(new { rtnmsg = "success" });
       



        }

        [HttpPost]
        public ActionResult AddWPMTPPriorities(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            if(selectkeys!=null)
            {
                string[] selectedkeys = selectkeys.Split(',');


                WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                if(wp_mainrec_check==null)
                {
                    WP_MainRecord mainrec_to_add = new WP_MainRecord
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        Directorate_Id=Int32.Parse(dirid),
                        Division_Id=Int32.Parse(divid),
                        Programme_Id=Int32.Parse(progid),
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        WP_Status="Drafting Mode",
                        WP_ApprovalStatus="Drafting Mode: Within Division",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));

                    if(wpcycle.LinkToSAPExecution==true)
                        mainrec_to_add.LinkToSAPExecution=true;
                    else
                        mainrec_to_add.LinkToSAPExecution=false;

                    _wpMainRecordRepository.Add(mainrec_to_add);

                    WP_MainRecord wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    //Save the Status
                    WP_ApprovalStatus wpstatus_to_add = new WP_ApprovalStatus
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=wp_mainrec_fetch1.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        WPStatusStatement="Drafting Mode: Within Division",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpApprovalStatusRepository.Add(wpstatus_to_add);

                     //Log the transaction for auditiong

                    System_Audit sysaudit_to_add = new System_Audit
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        AuditStatement="Drafting of Project: '" +_lkupProjectRepository.GetRecord(Int32.Parse(projid)).Record_Name + "' for " + _lkupFiscalYearRepository.GetRecord(Int32.Parse(fyear)).Record_Name+ ", " + 
                                        _lkupPeriodRepository.GetRecord(Int32.Parse(fperiod)).Record_Name+ " has been initiated.",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _sysSystemAuditRepository.Add(sysaudit_to_add);

                }

                WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                //delete all related records
                var records =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                foreach (var record in records)
                {
                    _wpMTPRepository.Delete(record.Transaction_Id);
                }

                //Now add new selection
                foreach (string mtpid in selectedkeys)
                {
                    WP_MTP rec_to_add = new WP_MTP
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id=wp_mainrec_fetch.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        MTP_Id=Int32.Parse(mtpid),
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    _wpMTPRepository.Add(rec_to_add);
            
                }

                
            }
            else
            {
                    //delete all related records
                    var records =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpMTPRepository.Delete(record.Transaction_Id);
                    }


            }

            return Json(new { rtnmsg = "success" });

        }


        [HttpPost]
        public ActionResult AddWPMemberStateMultiSelect(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";


            WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            
            if(wp_mainrec_check!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    //delete all related records
                    var records =  _wpCountryScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpCountryScopeRepository.Delete(record.Transaction_Id);
                    }

                    //Now add new selection
                    foreach (string recid in selectedkeys)
                    {
                        WP_CountryScope rec_to_add = new WP_CountryScope
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=wp_mainrec_check.Transaction_Id,
                            Project_Id=Int32.Parse(projid),
                            FiscalYear_Id=Int32.Parse(fyear),
                            Period_Id=Int32.Parse(fperiod),
                            Country_Id=Int32.Parse(recid),
                            Employee_Id=Int32.Parse(empid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpCountryScopeRepository.Add(rec_to_add);
                
                    } 
                }
                else
                {
                    //delete all related records
                    var records =  _wpCountryScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpCountryScopeRepository.Delete(record.Transaction_Id);
                    }
                }
                returnstring="success";
            }
            else
            {
                returnstring="nomainrecord";

            }

            return Json(new { rtnmsg = returnstring });

        }

        [HttpPost]
        public ActionResult CheckOutputIndicatorType(string indicatorid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";


            Strategy_OutputIndicators rec=_strategyOutputIndicatorsRepository.GetRecord(Int32.Parse(indicatorid));
            
            if(rec!=null && rec.Indicator_Type=="Qualitative")
            {
               
                returnstring="quanlitative";
            }
            else
            {
                returnstring="quantitative";

            }

            return Json(new { rtnmsg = returnstring });

        }

        [HttpPost]
        public ActionResult CheckAvailabilityOfSAPFunds(string sapwbsselect, string budgetamount)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";


            WP_SAPLink saprec=_wpSAPLinkRepository.GetRecord(sapwbsselect);

            if(saprec.SAP_BudgetAmount<= Double.Parse(budgetamount) )
            {
                returnstring="budgetexceedssapamount";
            }
            else
            {
                double totalutilization=0;

                var records =  _wpOutputBudgetRepository.GetRecordsBySAPLinkId(sapwbsselect);

                foreach (var record in records)
                {
                    totalutilization=totalutilization+record.Output_BudgetAmount;
                }

                if(saprec.SAP_BudgetAmount<=totalutilization)
                {
                    returnstring="insufficientfunds";
                }
                else
                {
                    returnstring="fundsavailable";
                }



            }
            


            return Json(new { rtnmsg = returnstring });

        }

        [HttpPost]
        public ActionResult AddBudgetSAPLink(string sapwbsselect, string transid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";


            WP_SAPLink saprec=_wpSAPLinkRepository.GetRecord(sapwbsselect);
            WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecord(transid);

            if(saprec.SAP_BudgetAmount<= recbudget.Output_BudgetAmount )
            {
                returnstring="budgetexceedssapamount";
            }
            else
            {
                double totalutilization=0;

                var records =  _wpOutputBudgetRepository.GetRecordsBySAPLinkId(sapwbsselect);

                foreach (var record in records)
                {
                    totalutilization=totalutilization+record.Output_BudgetAmount;
                }

                if(saprec.SAP_BudgetAmount<=totalutilization)
                {
                    returnstring="insufficientfunds";
                }
                else
                {
                    recbudget.WPSAPLink_Id=sapwbsselect;
                    _wpOutputBudgetRepository.Update(recbudget);
                    returnstring="success";
                }



            }
            


            return Json(new { rtnmsg = returnstring });

        }

         [HttpPost]
        public ActionResult DeleteBudgetSAPLink(string transid)
        {
            try
            {
                WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecord(transid);

                if (recbudget != null)
                {
                    recbudget.WPSAPLink_Id=null;
                    _wpOutputBudgetRepository.Update(recbudget); 
                }
                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }
        [HttpPost]
        public ActionResult AddWPRECCoverage(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            string returnstring="";
            WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            if(wp_mainrec_check!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    //WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                    //delete all related records
                    var records =  _wpRegionScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpRegionScopeRepository.Delete(record.Transaction_Id);
                    }

                    //Now add new selection
                    foreach (string recid in selectedkeys)
                    {
                        WP_RegionScope rec_to_add = new WP_RegionScope
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=wp_mainrec_check.Transaction_Id,
                            Project_Id=Int32.Parse(projid),
                            FiscalYear_Id=Int32.Parse(fyear),
                            Period_Id=Int32.Parse(fperiod),
                            Region_Id=Int32.Parse(recid),
                            Employee_Id=Int32.Parse(empid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpRegionScopeRepository.Add(rec_to_add);
                
                    }

                    
                }
                else
                {
                        //delete all related records
                        var records =  _wpRegionScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                        foreach (var record in records)
                        {
                            _wpRegionScopeRepository.Delete(record.Transaction_Id);
                        }


                }
                returnstring="success";
            }
            else{
                returnstring="nomainrecord";
            }

            return Json(new { rtnmsg = returnstring });

        }

         [HttpPost]
        public ActionResult AddWPRECCoverageMultiSelect(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            string returnstring="";
            WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            if(wp_mainrec_check!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    //WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                    //delete all related records
                    var records =  _wpRegionScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpRegionScopeRepository.Delete(record.Transaction_Id);
                    }

                    //Now add new selection
                    foreach (string recid in selectedkeys)
                    {
                        WP_RegionScope rec_to_add = new WP_RegionScope
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=wp_mainrec_check.Transaction_Id,
                            Project_Id=Int32.Parse(projid),
                            FiscalYear_Id=Int32.Parse(fyear),
                            Period_Id=Int32.Parse(fperiod),
                            Region_Id=Int32.Parse(recid),
                            Employee_Id=Int32.Parse(empid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpRegionScopeRepository.Add(rec_to_add);
                
                    }

                    
                }
                else
                {
                        //delete all related records
                        var records =  _wpRegionScopeRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                        foreach (var record in records)
                        {
                            _wpRegionScopeRepository.Delete(record.Transaction_Id);
                        }


                }
                returnstring="success";
            }
            else{
                returnstring="nomainrecord";
            }

            return Json(new { rtnmsg = returnstring });

        }

        [HttpPost]
        public ActionResult AddContinentalCoverage(string projid, string fyear, string fperiod, string empid, string contstatus)
        {

                string returnstring="";


                WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                if(wp_mainrec_check!=null)
                {

                    if(contstatus=="True")
                    {
                        wp_mainrec_check.ContinentalCoverage=true;
                    }
                    else
                    {
                        wp_mainrec_check.ContinentalCoverage=false;
                    }
                    wp_mainrec_check.Employee_Id=Int32.Parse(empid);
                    wp_mainrec_check.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    _wpMainRecordRepository.Update(wp_mainrec_check);
                    
                    returnstring="success";
   

                }
                else
                {
                    returnstring="nomainrecord";
                }


                
    

            return Json(new { rtnmsg = returnstring });

        }


        [HttpPost]
        public ActionResult AddWPAUDAPriorities(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            if(selectkeys!=null)
            {
                string[] selectedkeys = selectkeys.Split(',');


                WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                if(wp_mainrec_check==null)
                {
                    WP_MainRecord mainrec_to_add = new WP_MainRecord
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        Directorate_Id=Int32.Parse(dirid),
                        Division_Id=Int32.Parse(divid),
                        Programme_Id=Int32.Parse(progid),
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        WP_Status="Drafting Mode",
                        WP_ApprovalStatus="Drafting Mode: Within Division",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));

                    if(wpcycle.LinkToSAPExecution==true)
                        mainrec_to_add.LinkToSAPExecution=true;
                    else
                        mainrec_to_add.LinkToSAPExecution=false;

                    _wpMainRecordRepository.Add(mainrec_to_add);

                    WP_MainRecord wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    //Save the Status
                    WP_ApprovalStatus wpstatus_to_add = new WP_ApprovalStatus
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=wp_mainrec_fetch1.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        WPStatusStatement="Drafting Mode: Within Division",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpApprovalStatusRepository.Add(wpstatus_to_add);

                     //Log the transaction for auditiong

                    System_Audit sysaudit_to_add = new System_Audit
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        AuditStatement="Drafting of Project: '" +_lkupProjectRepository.GetRecord(Int32.Parse(projid)).Record_Name + "' for " + _lkupFiscalYearRepository.GetRecord(Int32.Parse(fyear)).Record_Name+ ", " + 
                                        _lkupPeriodRepository.GetRecord(Int32.Parse(fperiod)).Record_Name+ " has been initiated.",
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _sysSystemAuditRepository.Add(sysaudit_to_add);

                }

                WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                //delete all related records
                var records =  _wpAUDAPriorityRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                foreach (var record in records)
                {
                    _wpAUDAPriorityRepository.Delete(record.Transaction_Id);
                }

                //Now add new selection
                foreach (string priorityid in selectedkeys)
                {
                    WP_AUDAPriority rec_to_add = new WP_AUDAPriority
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id=wp_mainrec_fetch.Transaction_Id,
                        Project_Id=Int32.Parse(projid),
                        FiscalYear_Id=Int32.Parse(fyear),
                        Period_Id=Int32.Parse(fperiod),
                        Priority_Id=Int32.Parse(priorityid),
                        MTP_Id=999,
                        Employee_Id=Int32.Parse(empid),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    _wpAUDAPriorityRepository.Add(rec_to_add);
            
                }

                
            }
            else
            {
                    //delete all related records
                    var records =  _wpAUDAPriorityRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    foreach (var record in records)
                    {
                        _wpAUDAPriorityRepository.Delete(record.Transaction_Id);
                    }


            }

            return Json(new { rtnmsg = "success" });

        }

        

        [HttpPost]
        public ActionResult CheckMainWPRecordStatus(string projid, string fyear, string fperiod, string empid, string dirid, string divid,  string progid)
        {

            WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            string rtnmsg="";

            if(wp_mainrec_check==null)
            {
                rtnmsg="norecord";
            }
            else
            {
                rtnmsg="recordfound";
            }
                
            return Json(new { rtnmsg = rtnmsg });

        }
    

        [HttpPost]
        public async Task<ActionResult> AddDirectorateDirectorMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            IdentityResult _result;

            Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);


            if(primarydir !=null)
            {
                try
                {
                    Struc_Director rec_to_add = new Struc_Director
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        EmployeePK= model.Employee_Id,
                        Staff_Number=emp.Staff_Number,
                        Directorate_Id= model.Directorate_Id,
                        Status=true,
                        StartDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };


                    _strucDirectorRepository.Add(rec_to_add);

                    Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var isInRole = await userManager.IsInRoleAsync(_user, "Director");

                    if (!isInRole)
                    {
                        _result = await userManager.AddToRoleAsync(_user, "Director");
                    }
                            

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "otherprimaryalreadyexist" });

            }




        }


        [HttpPost]
        public async Task<ActionResult> AddDivisionHeadMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
           // Struc_DirStaffMapping rec=_strucDirStaffMappingRepository.GetRecordByEmployeeAndDirectorate(model.Employee_Id, model.Directorate_Id);
            Struc_DivStaffMapping rec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndDivision(model.Employee_Id, model.Division_Id);
            IdentityResult _result;

           // Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            Struc_DivStaffMapping primaryrec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndPrimaryDivision(model.Employee_Id);




            if(primaryrec !=null)
            {
                try
                {
                    Struc_DivHead rec_to_add = new Struc_DivHead
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        EmployeePK= model.Employee_Id,
                        Staff_Number=emp.Staff_Number,
                        Directorate_Id= model.Directorate_Id,
                        Division_Id=model.Division_Id,
                        Status=true,
                        StartDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day),
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _strucDivHeadRepository.Add(rec_to_add);

                    Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                    var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                    var isInRole = await userManager.IsInRoleAsync(_user, "Division Head");

                    if (!isInRole)
                    {
                        _result = await userManager.AddToRoleAsync(_user, "Division Head");
                    }
                            

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
            }
            else
            {
                return Json(new { rtnmsg = "otherprimaryalreadyexist" });

            }




        }

        [HttpPost]
        public async Task<ActionResult> AddStaffDivisionMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            Struc_DivStaffMapping rec=_strucDivStaffMappingRepository.GetRecordByEmployeeAndDivision(model.Employee_Id, model.Division_Id);
            IdentityResult _result;

            //Struc_DirStaffMapping primarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id);

            Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(model.Employee_Id, model.Directorate_Id);

            if (rec == null)
            {
                if(model.PrimaryMain==false || (model.PrimaryMain==true && thisprimarydir !=null))
                {
                    try
                    {

                        Struc_DivStaffMapping rec_to_add = new Struc_DivStaffMapping
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            EmployeePK= model.Employee_Id,
                            Staff_Number=emp.Staff_Number,
                            IdentityUserId=emp.IdentityUserId,
                            Directorate_Id= model.Directorate_Id,
                            Division_Id=model.Division_Id,
                            Mapping_Status=true,
                            PrimaryDivision=model.PrimaryMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        _strucDivStaffMappingRepository.Add(rec_to_add);


                        //Check if lowest role exist and add
                        Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);
                        var _user = await userManager.FindByIdAsync(_emp.IdentityUserId);
                        var isInRole = await userManager.IsInRoleAsync(_user, "Nepad Staff");


                        if (!isInRole)
                        {
                            _result = await userManager.AddToRoleAsync(_user, "Nepad Staff");
                        }

                        return Json(new { rtnmsg = "success" });
                    }
                    catch (Exception)
                    {
                        return Json(new { rtnmsg = "error" });
                    }
                }
                else
                {
                    return Json(new { rtnmsg = "notprimarydirectorate" });

                }
            }
            else
            {
                return Json(new { rtnmsg = "alreadyexist" });
            }



        }

        //**************DROP DOWN READS******************///

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransDirectorate()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }


            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransDivisionsByDirectorate(int directorate)
        {
            var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Division_Id,
                            DropDown_Name = _strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransProgrammesByDivision(int division)
        {
           // var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();
            var recs=_transProgrammeRepository.GetAllRecordsByDivisionID(division);
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.MainProgramme_Id,
                            DropDown_Name = _lkupProgrammeRepository.GetRecord(rec.MainProgramme_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransOutputIndicatorsByPriority(int priority)
        {
           // var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();
            var recs=_strategyOutputIndicatorsPriorityMappingRepository.GetAllRecordsByPriority(priority);
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.OutputIndicator_Id,
                            DropDown_Name = _strategyOutputIndicatorsRepository.GetRecord(rec.OutputIndicator_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransStrategicPriorities(int mtp_ident)
        {
           // var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();
            var recs=_transStrategyPriorityRepository.GetAllRecords().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _strategyPriorityRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransProjectsByProgramme(int programme)
        {
           // var recs =  _transStrucDivisionRepository.GetAllRecordsByDirectorate(_transStrucDirectorateRepository.GetRecordByMasterStrucDirectorateId(directorate).Transaction_Id).ToList();
            var recs=_transProjectRepository.GetAllRecordsByProgrammeID(programme);
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.MainProject_Id,
                            DropDown_Name = _lkupProjectRepository.GetRecord(rec.MainProject_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransFiscalYears(int fyears)
        {
          
            var recs=_transFiscalYearRepository.GetAllRecords().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _lkupFiscalYearRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWPStrategicPriorities(string projid, string fyear, string fperiod)
        {
          
            var recs=_wpAUDAPriorityRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid),Int32.Parse(fyear),Int32.Parse(fperiod)).ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Priority_Id,
                            DropDown_Name = _strategyPriorityRepository.GetRecord(rec.Priority_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWPSAPWBSsByCycleAndDirectorate(string empid, string mainrecordid)
        {
            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(mainrecordid);
            WP_DispatchCycle wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(mainrec.FiscalYear_Id, mainrec.Period_Id);
          
            var recs=_wpSAPLinkRepository.GetAllRecordsByDirectorateAndWPCycle(mainrec.Directorate_Id, wpcycle.Transaction_Id).ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_StringId = rec.Transaction_Id,
                            DropDown_Name = _wpSAPLinkRepository.GetRecord(rec.Transaction_Id).SAP_WBS+"-"+_wpSAPLinkRepository.GetRecord(rec.Transaction_Id).SAP_Description
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWPProjectBasedTypeOfIndicator()
        {
            var recs=_lkupIndicatorTypeRepository.GetAllRecords().ToList();
            int _count = recs.Count();
          

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }
                
       

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCycleActiveYears(int projectid)
        {
          
            var recs=_wpDispatchCycleRepository.GetAllCurrentWPDispatch();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.FiscalYear_Id,
                            DropDown_Name = _lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.GroupBy(x => x.DropDown_IntId).Select(x => x.First()).ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetTransFiscalPeriods(int fperiods)
        {
          
            var recs=_transPeriodRepository.GetAllRecords().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _lkupPeriodRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetCycleActivePeriodsByYear(int fyear)
        {
          
            var recs=_wpDispatchCycleRepository.GetAllCurrentWPDispatchByYear(fyear);
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Period_Id,
                            DropDown_Name = _lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllDirectorates()
        {
          
            var recs=_transStrucDirectorateRepository.GetAllRecords().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _strucDirectorateRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllActivityTypes()
        {
          
            var recs=_transActivityTypeRepository.GetAllTransActivityType().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Activity_Id,
                            DropDown_Name = _lkupActivityTypeRepository.GetActivityType(rec.Activity_Id).Activity_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllImplementationTypes()
        {
          
            var recs=_transImplementationTypeRepository.GetAllRecords().ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _lkupImplementationTypeRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetMappedDivisionsByEmployeeAndDirectorate(int empid)
        {

           // int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(Int32.Parse(empid)).Directorate_Id;

           // var recs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(Int32.Parse(empid),dirid).ToList();

           int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(empid).Directorate_Id;

           var recs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(empid,dirid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Division_Id,
                            DropDown_Name = _strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransMTPPriorities()
        {


           var recs =  _transStrategyMTPRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _strategyMTPRepository.GetRecord(rec.Record_Id).Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransAUCMemberStates()
        {


           var recs =  _transCountryRepository.GetAllTrans_Country().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_Country fetched_rec=_lkupCountryRepository.GetCountry(rec.Country_Id);

                   if(fetched_rec!=null && fetched_rec.AfricanCountry==1)
                   {
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = rec.Country_Id,
                                DropDown_Name = _lkupCountryRepository.GetCountry(rec.Country_Id).Country_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                   }
                }
            }

            return Json(collection_recs.ToList());

        }

         [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransRECs()
        {


           var recs =  _transRegionScopeRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_RegionScope fetched_rec=_lkupRegionScopeRepository.GetRecord(rec.Record_Id);

                   if(fetched_rec!=null)
                   {
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = rec.Record_Id,
                                DropDown_Name = _lkupRegionScopeRepository.GetRecord(rec.Record_Id).Record_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                   }
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDirMappStaff(int recid)
        {
            var recs =  _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = employee.Id,
                            DropDown_Name = employee.First_Name + " " + employee.Last_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDirPrimaryMappStaff(int recid)
        {
            var recs =  _strucDirStaffMappingRepository.GetAllRecordsByDirectorate(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Struc_DirStaffMapping thisprimarydir=_strucDirStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDirectorate(rec.EmployeePK, recid);

                    if(thisprimarydir!=null)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                    
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = employee.Id,
                                DropDown_Name = employee.First_Name + " " + employee.Last_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                    }
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDivPrimaryMappStaff(int recid)
        {
           
            var recs =  _strucDivStaffMappingRepository.GetAllRecordsByDivision(recid).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    Struc_DivStaffMapping thisprimarydiv=_strucDivStaffMappingRepository.GetRecordByEmployeeAndThisPrimaryDivision(rec.EmployeePK, recid);

                    if(thisprimarydiv!=null)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.EmployeePK);
                    
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_IntId = employee.Id,
                                DropDown_Name = employee.First_Name + " " + employee.Last_Name
                        };
                        // EmployeeDropDownViewModel me = DB_Employees[_count];
                        collection_recs.Add(srec);
                    }
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllEmployee()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _employeeRepository.GetAllEmployee().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Id,
                            DropDown_Name = rec.First_Name+" "+rec.Last_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }


            return Json(collection_recs.ToList());

        }


        public JsonResult GetEvents()
        {
            List<TimelineEventModel> events = new List<TimelineEventModel>();

            events.Add(new TimelineEventModel() {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 25, 2008",
                Description = "Barcelona is an excellent place to discover world-class arts and culture. Bullfighting was officially banned several years ago, but the city remains rich with festivals and events. The sights in Barcelona are second to none. Don’t miss the architectural wonder, Casa Mila—otherwise known as La Pedrera. It’s a modernist apartment building that looks like something out of an expressionist painting. Make your way up to the roof for more architectural surprises. And if you like Casa Mila, you’ll want to see another one of Antoni Gaudi’s architectural masterpieces, Casa Batllo, which is located at the center of Barcelona.\r\nTenerife, one of the nearby Canary Islands, is the perfect escape once you’ve had your fill of the city. In Los Gigantes, life revolves around the marina.",
                EventDate = new System.DateTime(2008, 5, 25)
            });

            events.Add(new TimelineEventModel()
            {
                Title = "United States East Coast Tour 1",
                Subtitle = "Feb 27, 2007",
                Description = "Touring the East Coast of the United States provides a massive range of entertainment and exploration. To take things in a somewhat chronological order, best to begin your trip in the north, checking out Boston’s Freedom Trail, Fenway Park, the Statue of Liberty, and Niagara Falls. Bring your raincoat to Niagara Falls, which straddles the boarder between Canada and the United States—the majestic sight might have you feeling misty in every sense of the word.",
                EventDate = new System.DateTime(2007, 2, 27)
            });

            events.Add(new TimelineEventModel()
            {
                Title = "Malta, a Country of Кnights",
                Subtitle = "Jun 15, 2008",
                Description = "Home of the oldest-known human structures in the world, the Maltese archipelago is best described as an open-air museum. Malta, the biggest of the seven Mediterranean islands, is the cultural center of the three largest—only three islands that are fully inhabited.  If you’re into heavy metal—swords, armor and other medieval weaponry—you’ll love the Grandmaster’s Palace.",
                EventDate = new System.DateTime(2008, 6, 15)
            });

            return Json(events);
        }

    }
}