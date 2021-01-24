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
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web;
using System.Threading;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using SkiaSharp;
//using STATCONNECTORCLNTLib;
using RDotNet;







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
        private readonly ILkUp_MobilityLimitsRepository _lkupMobilityLimitsRepository ;
        private readonly IStrategy_PriorityRepository _strategyPriorityRepository ;
        private readonly IStrategy_MTPRepository _strategyMTPRepository;
        private readonly IStrategy_MTPPriorityMappingRepository _strategyMTPPriorityMappingRepository ;
        private readonly IStrategy_KeyPerformanceAreaRepository _strategyKeyPerformanceAreaRepository;
        private readonly IStrategy_OutputIndicatorsRepository _strategyOutputIndicatorsRepository ;
        private readonly IStrategy_OutputIndicatorsPriorityMappingRepository _strategyOutputIndicatorsPriorityMappingRepository;
        private readonly IStruc_DirectorateRepository _strucDirectorateRepository ;
        private readonly IStruc_DivisionRepository _strucDivisionRepository;
        private readonly IStruc_DirDivIndicatorsRepository _strucDirDivIndicatorsRepository;
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
        private readonly ITrans_MobilityLimitsRepository _transMobilityLimitsRepository ;
        private readonly ITrans_StrategyPriorityRepository _transStrategyPriorityRepository ;
        private readonly ITrans_StrategyMTPRepository _transStrategyMTPRepository ;
        private readonly ITrans_StrategyKeyPerformanceAreaRepository _transStrategyKeyPerformanceAreaRepository  ;
        private readonly ITrans_StrategyOutputIndicators _transStrategyOutputIndicators  ;
        private readonly ITrans_StrucDirectorateRepository _transStrucDirectorateRepository  ;
        private readonly ITrans_StrucDivisionRepository _transStrucDivisionRepository  ;
        private readonly ITrans_StrucDirDivIndicatorsRepository _transStrucDirDivIndicatorsRepository  ;
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
        private readonly IWP_OutcomeIndicatorsRepository _wpOutcomeIndicatorsRepository ;
        private readonly IWP_OutputIndicatorsRepository _wpOutputIndicatorsRepository ;
        private readonly IWP_OutputActivitiesRepository _wpOutputActivitiesRepository ;
        private readonly IWP_SAPLinkRepository _wpSAPLinkRepository  ;
        private readonly IWP_OutputBudgetRepository _wpOutputBudgetRepository ;
        private readonly IWP_OutputActivityCountriesRepository _wpOutputActivityCountriesRepository;
        private readonly IWP_MobilityRepository _wpMobilityRepository;
        private readonly IWP_MobilityInternalTeamRepository _wpMobilityInternalTeamRepository;
        private readonly IWP_MobilityExternalTeamRepository _wpMobilityExternalTeamRepository;
        private readonly IWP_MobilityLimitRepository _wpMobilityLimitRepository;
        private readonly IWP_BarCodeIdentsRepository _wpBarCodeIdentsRepository;
        private readonly IWP_CommunicationRepository _wpCommunicationRepository;
        private readonly IWP_PRCBudgetLimitsRepository _wpPRCBudgetLimitsRepository;
        private readonly IWP_ProcurementRepository _wpProcurementRepository;
        private readonly IWP_RiskProfileRepository _wpRiskProfileRepository;
        private readonly IWP_RiskProfileCountriesRepository _wpRiskProfileCountriesRepository;



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
                                ILkUp_MobilityLimitsRepository lkupMobilityLimitsRepository ,
                                IStrategy_PriorityRepository strategyPriorityRepository,
                                IStrategy_MTPRepository strategyMTPRepository,
                                IStrategy_MTPPriorityMappingRepository strategyMTPPriorityMappingRepository,
                                IStrategy_KeyPerformanceAreaRepository strategyKeyPerformanceAreaRepository,
                                IStrategy_OutputIndicatorsRepository strategyOutputIndicatorsRepository,
                                IStrategy_OutputIndicatorsPriorityMappingRepository strategyOutputIndicatorsPriorityMappingRepository,
                                IStruc_DirectorateRepository strucDirectorateRepository,
                                IStruc_DivisionRepository strucDivisionRepository,
                                IStruc_DirDivIndicatorsRepository strucDirDivIndicatorsRepository,
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
                                ITrans_MobilityLimitsRepository transMobilityLimitsRepository,
                                ITrans_StrategyPriorityRepository transStrategyPriorityRepository,
                                ITrans_StrategyMTPRepository transStrategyMTPRepository,
                                ITrans_StrategyKeyPerformanceAreaRepository transStrategyKeyPerformanceAreaRepository,
                                ITrans_StrategyOutputIndicators transStrategyOutputIndicators,
                                ITrans_StrucDirectorateRepository transStrucDirectorateRepository,
                                ITrans_StrucDivisionRepository transStrucDivisionRepository,   
                                ITrans_StrucDirDivIndicatorsRepository transStrucDirDivIndicatorsRepository ,
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
                                IWP_OutcomeIndicatorsRepository wpOutcomeIndicatorsRepository,
                                IWP_OutputIndicatorsRepository wpOutputIndicatorsRepository,
                                IWP_OutputActivitiesRepository wpOutputActivitiesRepository,
                                IWP_SAPLinkRepository wpSAPLinkRepository,
                                IWP_OutputBudgetRepository wpOutputBudgetRepository,
                                IWP_OutputActivityCountriesRepository wpOutputActivityCountriesRepository,
                                IWP_MobilityRepository wpMobilityRepository,
                                IWP_MobilityInternalTeamRepository wpMobilityInternalTeamRepository,
                                IWP_MobilityExternalTeamRepository wpMobilityExternalTeamRepository,
                                IWP_MobilityLimitRepository wpMobilityLimitRepository,
                                IWP_BarCodeIdentsRepository wpBarCodeIdentsRepository,
                                IWP_CommunicationRepository wpCommunicationRepository,
                                IWP_PRCBudgetLimitsRepository wpPRCBudgetLimitsRepository,
                                IWP_ProcurementRepository wpProcurementRepository,
                                IWP_RiskProfileRepository wpRiskProfileRepository,
                                IWP_RiskProfileCountriesRepository wpRiskProfileCountriesRepository)
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
            _lkupMobilityLimitsRepository=lkupMobilityLimitsRepository;
            _strategyPriorityRepository=strategyPriorityRepository;
            _strategyMTPRepository=strategyMTPRepository;
            _strategyMTPPriorityMappingRepository=strategyMTPPriorityMappingRepository;
            _strategyKeyPerformanceAreaRepository=strategyKeyPerformanceAreaRepository;
            _strategyOutputIndicatorsRepository=strategyOutputIndicatorsRepository;
            _strategyOutputIndicatorsPriorityMappingRepository=strategyOutputIndicatorsPriorityMappingRepository;
            _strucDirectorateRepository=strucDirectorateRepository;
            _strucDivisionRepository=strucDivisionRepository;
            _strucDirDivIndicatorsRepository=strucDirDivIndicatorsRepository;


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
            _transMobilityLimitsRepository= transMobilityLimitsRepository;
            _transStrategyPriorityRepository=transStrategyPriorityRepository;
            _transStrategyMTPRepository=transStrategyMTPRepository;
            _transStrategyKeyPerformanceAreaRepository=transStrategyKeyPerformanceAreaRepository;
            _transStrategyOutputIndicators=transStrategyOutputIndicators;
            _transStrucDirectorateRepository=transStrucDirectorateRepository;
            _transStrucDivisionRepository=transStrucDivisionRepository;
            _transStrucDirDivIndicatorsRepository=transStrucDirDivIndicatorsRepository;
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
            _wpOutcomeIndicatorsRepository=wpOutcomeIndicatorsRepository;
            _wpOutputIndicatorsRepository=wpOutputIndicatorsRepository;
            _wpOutputActivitiesRepository=wpOutputActivitiesRepository;
            _wpSAPLinkRepository=wpSAPLinkRepository;
            _wpOutputBudgetRepository=wpOutputBudgetRepository;
            _wpOutputActivityCountriesRepository=wpOutputActivityCountriesRepository;
            _wpMobilityRepository=wpMobilityRepository;
            _wpMobilityInternalTeamRepository=wpMobilityInternalTeamRepository;
            _wpMobilityExternalTeamRepository=wpMobilityExternalTeamRepository;
            _wpMobilityLimitRepository=wpMobilityLimitRepository;
            _wpBarCodeIdentsRepository=wpBarCodeIdentsRepository;
            _wpCommunicationRepository=wpCommunicationRepository;
            _wpPRCBudgetLimitsRepository=wpPRCBudgetLimitsRepository;
            _wpProcurementRepository=wpProcurementRepository;
            _wpRiskProfileRepository=wpRiskProfileRepository;
            _wpRiskProfileCountriesRepository=wpRiskProfileCountriesRepository;
        



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



        public async Task<ActionResult> LookUpProcurementType()
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

        public async Task<ActionResult> ManageLkUpProjects()
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

        public async Task<ActionResult> ManageLkUpProgrammes()
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


        public async Task<ActionResult> StaffRolesMapping()
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

        public async Task<ActionResult> ProjProgMapping()
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
            Chilkat.Csv csv_mobilitylimit =new Chilkat.Csv();



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
            string mobilitylimit_path = Path.Combine(hostingEnvironment.WebRootPath, "appdirectory/lookupcsvs/MobilityLimits.csv");
            


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
                bool success_mobilitylimit= csv_mobilitylimit.LoadFile(mobilitylimit_path);


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

                if (success_mobilitylimit == true)
                {
                    int _count= _lkupMobilityLimitsRepository.GetAllRecords().Count();
                    if (_count <= 0)
                    {
                        int row;
                        int n = csv_mobilitylimit.NumRows;


                        for (row = 0; row <= n - 1; row++)
                        {

                            LkUp_MobilityLimits rec = new LkUp_MobilityLimits
                            {

                                Record_Id = Int32.Parse(csv_mobilitylimit.GetCell(row, 0)),
                                MonthlyLimit=Int32.Parse(csv_mobilitylimit.GetCell(row, 1)),
                                Record_Status = true,
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _lkupMobilityLimitsRepository.Add(rec);

                            Trans_MobilityLimits rec_trans = new Trans_MobilityLimits
                            {
                                Transaction_Id = Guid.NewGuid().ToString(),
                                Record_Id = Int32.Parse(csv_mobilitylimit.GetCell(row, 0)),
                                TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                            };

                            _transMobilityLimitsRepository.Add(rec_trans);

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
        public async Task<ActionResult> InitializeForFirstUse()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);

            try
            {

                //Delete All WP_DispatchCycle
                var DB_Recs_WP_DispatchCycle =  _wpDispatchCycleRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_DispatchCycle)
                {
                    _wpDispatchCycleRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_MainRecord
                var DB_Recs_WP_MainRecord =  _wpMainRecordRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_MainRecord)
                {
                    _wpMainRecordRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_Outcomes
                var DB_Recs_WP_Outcomes =  _wpOutcomesRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_Outcomes)
                {
                    _wpOutcomesRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_MTP
                var DB_Recs_WP_MTP =  _wpMTPRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_MTP)
                {
                    _wpMTPRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_AUDAPriority
                var DB_Recs_WP_AUDAPriority =  _wpAUDAPriorityRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_AUDAPriority)
                {
                    _wpAUDAPriorityRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_ApprovalStatus
                var DB_Recs_WP_ApprovalStatus =  _wpApprovalStatusRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_ApprovalStatus)
                {
                    _wpApprovalStatusRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_RegionScope
                var DB_Recs_WP_RegionScope =  _wpRegionScopeRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_RegionScope)
                {
                    _wpRegionScopeRepository.Delete(recordset.Transaction_Id);
                }


                //Delete All WP_CountryScope
                var DB_Recs_WP_CountryScope =  _wpCountryScopeRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_CountryScope)
                {
                    _wpCountryScopeRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_Outputs
                var DB_Recs_WP_Outputs =  _wpOutputsRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_Outputs)
                {
                    _wpOutputsRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_OutputIndicators
                var DB_Recs_WP_OutputIndicators =  _wpOutputIndicatorsRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_OutputIndicators)
                {
                    _wpOutputIndicatorsRepository.Delete(recordset.Transaction_Id);
                }


                //Delete All WP_OutputActivities
                var DB_Recs_WP_OutputActivities =  _wpOutputActivitiesRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_OutputActivities)
                {
                    _wpOutputActivitiesRepository.Delete(recordset.Transaction_Id);
                }



                //Delete All WP_SAPLink
                var DB_Recs_WP_SAPLink =  _wpSAPLinkRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_SAPLink)
                {
                    _wpSAPLinkRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_OutputBudget
                var DB_Recs_WP_OutputBudget =  _wpOutputBudgetRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_OutputBudget)
                {
                    _wpOutputBudgetRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_OutputActivityCountries
                var DB_Recs_WP_OutputActivityCountries =  _wpOutputActivityCountriesRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_OutputActivityCountries)
                {
                    _wpOutputActivityCountriesRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_Mobility
                var DB_Recs_WP_Mobility =  _wpMobilityRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_Mobility)
                {
                    _wpMobilityRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_MobilityInternalTeam
                var DB_Recs_WP_MobilityInternalTeam =  _wpMobilityInternalTeamRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_MobilityInternalTeam)
                {
                    _wpMobilityInternalTeamRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_MobilityExternalTeam
                var DB_Recs_WP_MobilityExternalTeam =  _wpMobilityExternalTeamRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_MobilityExternalTeam)
                {
                    _wpMobilityExternalTeamRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_MobilityLimit
                var DB_Recs_WP_MobilityLimit =  _wpMobilityLimitRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_MobilityLimit)
                {
                    _wpMobilityLimitRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All WP_OutputIndicators
                var DB_Recs_WP_OutcomeIndicators =  _wpOutcomeIndicatorsRepository.GetAllRecords().ToList();
                foreach (var recordset in DB_Recs_WP_OutcomeIndicators)
                {
                    _wpOutcomeIndicatorsRepository.Delete(recordset.Transaction_Id);
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
		public ActionResult LkUp_ProcurementType_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ProcurementType rec = _lkupProcurementTypeRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _lkupProcurementTypeRepository.GetAllRecords();
                        int _count = DB_Recs.Count();

                        LkUp_ProcurementType rec_to_add = new LkUp_ProcurementType
                        {
                            Record_Id=_count+1,
                            Record_Name=record.LookUp_Name,
                            Record_Status=true,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _lkupProcurementTypeRepository.Add(rec_to_add);


                        Trans_ProcurementType rec_trans = new Trans_ProcurementType
                        {
                            Transaction_Id = Guid.NewGuid().ToString(),
                            Record_Id = _count+1,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _transProcurementTypeRepository.Add(rec_trans);


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
		public async Task<ActionResult>  Ident_Role_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                bool roleexist=await roleManager.RoleExistsAsync(record.LookUp_Name);
                if(!roleexist)
                {
                    var role = new IdentityRole();
                    role.Name = record.LookUp_Name;
                    await roleManager.CreateAsync(role);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }



         [AcceptVerbs("Post")]
		public ActionResult Trans_Project_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_Project rec = _lkupProjectRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _lkupProjectRepository.GetAllRecords();
                        int _count = DB_Recs.Count()+1;

                        LkUp_Project rec_to_add = new LkUp_Project
                        {
                            Record_Id=_count,
                            Record_Name=record.LookUp_Name,
                            Record_Status=false,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _lkupProjectRepository.Add(rec_to_add);

                        
                        Trans_Project trans_rec_to_add = new Trans_Project
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            MainProject_Id=_count,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                         _transProjectRepository.Add(trans_rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_Programme_Create([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_Programme rec = _lkupProgrammeRepository.GetRecordByName(record.LookUp_Name);

                if (rec == null && record.LookUp_Name !=null)
                {

                        var DB_Recs = _lkupProgrammeRepository.GetAllRecords();
                        int _count = DB_Recs.Count()+1;

                        LkUp_Programme rec_to_add = new LkUp_Programme
                        {
                            Record_Id=_count,
                            Record_Name=record.LookUp_Name,
                            Record_Status=false,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _lkupProgrammeRepository.Add(rec_to_add);

                        
                        Trans_Programme trans_rec_to_add = new Trans_Programme
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            MainProgramme_Id=_count,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                         _transProgrammeRepository.Add(trans_rec_to_add);
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityLimit_Create([DataSourceRequest] DataSourceRequest request, WP_MobilityLimitViewModel record, string wpcycleid)
        {
            if (record != null && ModelState.IsValid)
            { 
                 if(wpcycleid!=null)
                 {

                     WP_MobilityLimit rec=_wpMobilityLimitRepository.GetRecordByEmployeeAndCycle(record.Category.CategoryID, wpcycleid);

                     if(rec==null)
                     {
                         WP_MobilityLimit rec_to_add = new WP_MobilityLimit
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            WPCycle_id=wpcycleid,
                            FiscalYear_Id=_wpDispatchCycleRepository.GetRecord(wpcycleid).FiscalYear_Id,
                            Period_Id=_wpDispatchCycleRepository.GetRecord(wpcycleid).Period_Id,
                            Employee_Id=record.Category.CategoryID,
                            MonthlyLimit=record.MonthlyLimitVM,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        if(_wpDispatchCycleRepository.GetRecord(wpcycleid).Period_Id==8)
                        {
                            rec_to_add.PeriodStartDate=_wpDispatchCycleRepository.GetRecord(wpcycleid).PeriodStartDate;
                            rec_to_add.PeriodEndDate=_wpDispatchCycleRepository.GetRecord(wpcycleid).PeriodEndDate;
                        }

                        _wpMobilityLimitRepository.Add(rec_to_add);
                     }
                 }
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        
        [AcceptVerbs("Post")]
		public ActionResult WP_PRCLimit_Create([DataSourceRequest] DataSourceRequest request, WP_PRCLimitViewModel record, string wpcycleid)
        {
            if (record != null && ModelState.IsValid)
            { 
                 if(wpcycleid!=null)
                 {

                     WP_PRCBudgetLimits rec=_wpPRCBudgetLimitsRepository.GetRecordByDirectorateAndCycle(record.Category.CategoryID, wpcycleid);

                     if(rec==null)
                     {
                         WP_PRCBudgetLimits rec_to_add = new WP_PRCBudgetLimits
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            WPCycle_id=wpcycleid,
                            FiscalYear_Id=_wpDispatchCycleRepository.GetRecord(wpcycleid).FiscalYear_Id,
                            Period_Id=_wpDispatchCycleRepository.GetRecord(wpcycleid).Period_Id,
                            Directorate_Id=record.Category.CategoryID,
                            MS_Limit=record.MSLimitVM,
                            DP_Limit=record.DPLimitVM,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };


                        if(_wpDispatchCycleRepository.GetRecord(wpcycleid).Period_Id==8)
                        {
                            rec_to_add.PeriodStartDate=_wpDispatchCycleRepository.GetRecord(wpcycleid).PeriodStartDate;
                            rec_to_add.PeriodEndDate=_wpDispatchCycleRepository.GetRecord(wpcycleid).PeriodEndDate;
                        }

                        _wpPRCBudgetLimitsRepository.Add(rec_to_add);
                     }
                 }
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityExternalParticipants_Create([DataSourceRequest] DataSourceRequest request, WP_OutputMobilityExternalPartVM record, string wpmobilityid)
        {
            if (record != null && ModelState.IsValid)
            { 
                 if(wpmobilityid!=null)
                 {

                    WP_MobilityExternalTeam rec=_wpMobilityExternalTeamRepository.GetRecordByMobilityIdExtPartIdAndDesc(wpmobilityid, record.ExternalType.CategoryID, record.ExternalParticipant_DescriptionExtPartVM);

                    WP_Mobility mobrec=_wpMobilityRepository.GetRecord(wpmobilityid);

                    WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(mobrec.WPMainRecord_id);
                     if(rec==null)
                     {
                         WP_MobilityExternalTeam rec_to_add = new WP_MobilityExternalTeam
                        {
                            Transaction_Id=Guid.NewGuid().ToString(),
                            WPMainRecord_id=record.WPMainRecord_idExtPartVM,
                            Project_Id=mainrec.Project_Id,
                            FiscalYear_Id=mainrec.FiscalYear_Id,
                            Period_Id=mainrec.Period_Id,
                            WPOutput_Id=record.WPOutput_IdExtPartVM,
                            WPMobility_id=wpmobilityid,
                            ExternalParticipant_Id=record.ExternalType.CategoryID,
                            ExternalParticipant_Description=record.ExternalParticipant_DescriptionExtPartVM,
                            ExternalParticipant_Number=record.ExternalParticipant_NumberExtPartVM,
                            PeriodStartDate=mainrec.PeriodStartDate,
                            PeriodEndDate=mainrec.PeriodStartDate,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };



                        _wpMobilityExternalTeamRepository.Add(rec_to_add);
                     }
                 }
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_Outcomes_Create([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string progid, string projid, string fyear, string fperiod, string empid, string dirid, string divid, string periodtxt)
        {
            if (record != null && ModelState.IsValid)
            {  
                WP_Outcomes rec = _wpOutcomesRepository.GetRecordByOutcomeStatement(record.Outcome);

                if (rec == null && record.Outcome !=null)
                {
                        WP_MainRecord wp_mainrec_check=null;

                        if(Int32.Parse(fperiod)==8)
                        {
                            var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                            int _countrecs =  DB_Records8.Count();
                            if(_countrecs>0)
                            {
                                foreach (var rec_set in DB_Records8)
                                {
                                    DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                    DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                    string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                    if(periodinmain==periodtxt)
                                        wp_mainrec_check=rec_set;
                                }
                            }

                        }
                        else
                        {
                            wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                        }

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

                            WP_DispatchCycle wpcycle=null;

                            if(Int32.Parse(fperiod)==8)
                            {
                                var DB_Records8 =_wpDispatchCycleRepository.GetRecordsByYearAndPeriodRecs(Int32.Parse(fyear), Int32.Parse(fperiod));

                                int _countrecs =  DB_Records8.Count();
                                if(_countrecs>0)
                                {
                                    foreach (var rec_set in DB_Records8)
                                    {
                                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                        if(periodinmain==periodtxt)
                                        wpcycle=rec_set;
                                    }

                                    if(wpcycle!=null)
                                    {
                                        mainrec_to_add.PeriodStartDate=wpcycle.PeriodStartDate;
                                        mainrec_to_add.PeriodEndDate=wpcycle.PeriodEndDate;
                                    }
                                }
                            }
                            else
                            {
                                wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));
                            }

                            if(wpcycle.LinkToSAPExecution==true)
                                mainrec_to_add.LinkToSAPExecution=true;
                            else
                                mainrec_to_add.LinkToSAPExecution=false;

                            _wpMainRecordRepository.Add(mainrec_to_add);



	                        //WP_MainRecord wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                            //Modified for Period type 8
                            WP_MainRecord wp_mainrec_fetch1=null;

                            if(Int32.Parse(fperiod)==8)
                            {
                                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                                int _countrecs =  DB_Records8.Count();
                                if(_countrecs>0)
                                {
                                    foreach (var rec_set in DB_Records8)
                                    {
                                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                        if(periodinmain==periodtxt)
                                        wp_mainrec_fetch1=rec_set;
                                    }
                                }

                            }
                            else
                            {
                                wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                            }


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

                       // WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                        //Modified for Period type 8
                        WP_MainRecord wp_mainrec_fetch=null;

                        if(Int32.Parse(fperiod)==8)
                        {
                            var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                            int _countrecs =  DB_Records8.Count();
                            if(_countrecs>0)
                            {
                                foreach (var rec_set in DB_Records8)
                                {
                                    DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                    DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                    string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                    if(periodinmain==periodtxt)
                                    wp_mainrec_fetch=rec_set;
                                }
                            }

                        }
                        else
                        {
                            wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                        }

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
		public ActionResult WP_Outputs_Create([DataSourceRequest] DataSourceRequest request, WorkplansViewModel record, string progid, string projid, string fyear, string fperiod, string empid, string dirid, string divid, string periodtxt)
        {
            if (record != null && ModelState.IsValid)
            {  
                //WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                WP_MainRecord wp_mainrec_check=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                                wp_mainrec_check=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }

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


         [AcceptVerbs("Post")]
		public ActionResult Struc_DivisionKPI_Create([DataSourceRequest] DataSourceRequest request, DivisionKPIsViewModel record, string dirid, string divid)
        {
            if (record != null && ModelState.IsValid)
            {  
                     
                           
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
		public ActionResult LkUp_ProcurementType_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ProcurementType rec = _lkupProcurementTypeRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        LkUp_ProcurementType rec_already_exist = _lkupProcurementTypeRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _lkupProcurementTypeRepository.Update(rec);
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
		public ActionResult Trans_Project_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_Project rec = _lkupProjectRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        LkUp_Project rec_already_exist = _lkupProjectRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _lkupProjectRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_Programme_Update([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_Programme rec = _lkupProgrammeRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {

                        LkUp_Programme rec_already_exist = _lkupProgrammeRepository.GetRecordByName(record.LookUp_Name);

                        if(rec_already_exist==null)
                        {
                            rec.Record_Name=record.LookUp_Name;
                            rec.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


                            _lkupProgrammeRepository.Update(rec);
                        }
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityLimit_Update([DataSourceRequest] DataSourceRequest request, WP_MobilityLimitViewModel record, string wpcycleid)
        {
            if (record != null && ModelState.IsValid)
            {  
                
                WP_MobilityLimit wp_rec_fetch=_wpMobilityLimitRepository.GetRecord(record.Transaction_IdVM);
                if (wp_rec_fetch != null)
                {

                    wp_rec_fetch.MonthlyLimit =record.MonthlyLimitVM;
                    wp_rec_fetch.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    _wpMobilityLimitRepository.Update(wp_rec_fetch);
                    
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_PRCLimit_Update([DataSourceRequest] DataSourceRequest request, WP_PRCLimitViewModel record, string wpcycleid)
        {
            if (record != null && ModelState.IsValid)
            {  
                
                WP_PRCBudgetLimits wp_rec_fetch=_wpPRCBudgetLimitsRepository.GetRecord(record.Transaction_IdVM);
                if (wp_rec_fetch != null)
                {

                    wp_rec_fetch.MS_Limit =record.MSLimitVM;
                    wp_rec_fetch.DP_Limit =record.DPLimitVM;
                    wp_rec_fetch.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    _wpPRCBudgetLimitsRepository.Update(wp_rec_fetch);
                    
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityExternalParticipant_Update([DataSourceRequest] DataSourceRequest request, WP_OutputMobilityExternalPartVM record, string wpmobilityid)
        {
            if (record != null && ModelState.IsValid)
            {  
                
                
                WP_MobilityExternalTeam wp_rec_fetch=_wpMobilityExternalTeamRepository.GetRecord(record.Transaction_IdExtPartVM);
                WP_Mobility mobrec=_wpMobilityRepository.GetRecord(wpmobilityid);

                if (wp_rec_fetch != null)
                {
                    wp_rec_fetch.ExternalParticipant_Id=record.ExternalType.CategoryID;
                    wp_rec_fetch.ExternalParticipant_Description =record.ExternalParticipant_DescriptionExtPartVM;
                    wp_rec_fetch.ExternalParticipant_Number=record.ExternalParticipant_NumberExtPartVM;
                    wp_rec_fetch.TransactionDate=new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    _wpMobilityExternalTeamRepository.Update(wp_rec_fetch);
                    
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
		public ActionResult LkUp_ProcurementType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                LkUp_ProcurementType rec = _lkupProcurementTypeRepository.GetRecord(record.LookUp_Id);
                
                if (rec != null)
                {
                    rec.Record_Status=false;
                    _lkupProcurementTypeRepository.Update(rec);   
                } 

                Trans_ProcurementType transrec=_transProcurementTypeRepository.GetRecordByMainRecord_Id(record.LookUp_Id); 

                if (transrec != null)
                {
                    _transProcurementTypeRepository.Delete(transrec.Transaction_Id);   
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
		public ActionResult Trans_Project_Delete ([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_Project rec = _transProjectRepository.GetRecord(record.TransLookUp_Id);
                
                if (rec != null)
                {
                    _transProjectRepository.Delete(rec.Transaction_Id);
                        
                }  

                
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs("Post")]
		public ActionResult Trans_Programme_Delete ([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_Programme rec = _transProgrammeRepository.GetRecord(record.TransLookUp_Id);
                
                if (rec != null)
                {
                    _transProgrammeRepository.Delete(rec.Transaction_Id);
                        
                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityLimit_Delete([DataSourceRequest] DataSourceRequest request, WP_MobilityLimitViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_MobilityLimit rec=_wpMobilityLimitRepository.GetRecord(record.Transaction_IdVM);
                
                if (rec != null)
                {
                    _wpMobilityLimitRepository.Delete(rec.Transaction_Id);

                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_PRCLimit_Delete([DataSourceRequest] DataSourceRequest request, WP_PRCLimitViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_PRCBudgetLimits rec=_wpPRCBudgetLimitsRepository.GetRecord(record.Transaction_IdVM);
                
                if (rec != null)
                {
                    _wpPRCBudgetLimitsRepository.Delete(rec.Transaction_Id);

                }      
                           
            }
            
            return Json(new [] { record }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
		public ActionResult WP_MobilityExternalParticipant_Delete([DataSourceRequest] DataSourceRequest request, WP_OutputMobilityExternalPartVM record)
        {
            if (record != null && ModelState.IsValid)
            {  

                WP_MobilityExternalTeam rec=_wpMobilityExternalTeamRepository.GetRecord(record.Transaction_IdExtPartVM);
                
                if (rec != null)
                {
                    _wpMobilityExternalTeamRepository.Delete(rec.Transaction_Id);

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
                


                //Delete all related indicators
                var DB_Recs_indicators =  _wpOutputIndicatorsRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_indicators)
                {
                    _wpOutputIndicatorsRepository.Delete(recordset.Transaction_Id);
                }

                //Delete all related activities
                var DB_Recs_activities=  _wpOutputActivitiesRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_activities)
                {
                    _wpOutputActivitiesRepository.Delete(recordset.Transaction_Id);
                }

                //Delete all related budget linees
                var DB_Recs_budgetlines=  _wpOutputBudgetRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_budgetlines)
                {
                    _wpOutputBudgetRepository.Delete(recordset.Transaction_Id);
                }


                //Delete All Mobility Related Records

                var DB_Recs_Mobilities=  _wpMobilityRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_Mobilities)
                {
                    //Delete Internal Participants
                    var DB_Recs_MobilitiesInt=_wpMobilityInternalTeamRepository.GetRecordsByMobilityId(recordset.Transaction_Id);
                    foreach (var innerrec in DB_Recs_MobilitiesInt)
                    {
                        _wpMobilityInternalTeamRepository.Delete(innerrec.Transaction_Id);

                    }

                    //Delete External Participants
                    var DB_Recs_MobilitiesExt=_wpMobilityExternalTeamRepository.GetRecordsByMobilityId(recordset.Transaction_Id);
                    foreach (var innerrec in DB_Recs_MobilitiesExt)
                    {
                        _wpMobilityExternalTeamRepository.Delete(innerrec.Transaction_Id);

                    }

                    _wpMobilityRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All Procurement Related Records

                var DB_Recs_Procurement=  _wpProcurementRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_Procurement)
                {
                    _wpProcurementRepository.Delete(recordset.Transaction_Id);
                }


                //Delete All Communication Related Records


                var DB_Recs_Communication=  _wpCommunicationRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_Communication)
                {
                    _wpCommunicationRepository.Delete(recordset.Transaction_Id);
                }

                //Delete All Risk Related Records

                var DB_Recs_RiskProfile=  _wpRiskProfileRepository.GetRecordsByMainRecordOutputId(rec.WPMainRecord_id, rec.Transaction_Id);
                foreach (var recordset in DB_Recs_RiskProfile)
                {
                    //Delete Risk Profile Countries
                    var DB_Recs_RiskProfileCountries=_wpRiskProfileCountriesRepository.GetRecordsByRiskId(recordset.Transaction_Id);
                    foreach (var innerrec in DB_Recs_RiskProfileCountries)
                    {
                        _wpRiskProfileCountriesRepository.Delete(innerrec.Transaction_Id);

                    }

                    _wpRiskProfileRepository.Delete(recordset.Transaction_Id);
                }


                //Delete Output Record
                if (rec != null)
                {
                    _wpOutputsRepository.Delete(rec.Transaction_Id);

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
		public ActionResult Trans_ProcurementType_Delete([DataSourceRequest] DataSourceRequest request, LookUpTablesViewModel record)
        {
            if (record != null && ModelState.IsValid)
            {  
                Trans_ProcurementType rec = _transProcurementTypeRepository.GetRecord(record.Trans_LookUp_Id);
                
                if (rec != null)
                {
                    _transProcurementTypeRepository.Delete(rec.Transaction_Id);

                    LkUp_ProcurementType rec_update=_lkupProcurementTypeRepository.GetRecord(rec.Record_Id);
                    rec_update.Record_Status=false;
                    _lkupProcurementTypeRepository.Update(rec_update);
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



        public ActionResult LkUp_ProcurementType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _lkupProcurementTypeRepository.GetAllRecords();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        LookUp_Name =rec.Record_Name,
                        Show_trans_button=rec.Record_Status,
                        LookUp_Status = rec.Record_Status? "Transactional": "Inactive",
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

        public ActionResult Trans_Project_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _transProjectRepository.GetAllRecords().ToList();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        TransLookUp_Id=rec.Transaction_Id,
                        LookUp_Id = rec.MainProject_Id,
                        LookUp_Name =_lkupProjectRepository.GetRecord(rec.MainProject_Id).Record_Name,
                      //  LookUp_Status = _lkupProjectRepository.GetRecord(rec.MainProject_Id).Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive", //implement later
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult Trans_Programme_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();



            var DB_Recs =  _transProgrammeRepository.GetAllRecords().ToList();




            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        TransLookUp_Id=rec.Transaction_Id,
                        LookUp_Id = rec.MainProgramme_Id,
                        LookUp_Name =_lkupProgrammeRepository.GetRecord(rec.MainProgramme_Id).Record_Name,
                      //  LookUp_Status = _lkupProjectRepository.GetRecord(rec.MainProject_Id).Record_Status.HasValue? rec.Record_Status.Value? "Transactional": "Active": "Inactive", //implement later
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_Outcomes_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
           WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                 var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                           wp_mainrec_check=rec;
                    }
                }

            }
            else
            {
               wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }



            var DB_Recs =  _wpOutcomesRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutcomesRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutcomesRepository.GetRecordsByMainRecordId("Null").ToList();



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

        public ActionResult WP_MobilityLimit_Read([DataSourceRequest]DataSourceRequest request, string wpcycleid)
        {


            List<WP_MobilityLimitViewModel> collection_recs = new List<WP_MobilityLimitViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
       
            var DB_Recs =  _wpMobilityLimitRepository.GetRecordsByWPCycle(wpcycleid).ToList();

          //  var emp_recs =  _employeeRepository.GetAllEmployee().ToList();

           



            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var employee=_employeeRepository.GetEmployee(rec.Employee_Id);
   
                    WP_MobilityLimitViewModel srec = new WP_MobilityLimitViewModel
                    {
                        Transaction_IdVM = rec.Transaction_Id,
                        WPCycle_idVM=rec.WPCycle_id,
                        Project_IdVM=rec.Project_Id,
                        FiscalYear_IdVM=rec.FiscalYear_Id,
                        Period_IdVM=rec.Period_Id,
                        MonthlyLimitVM=rec.MonthlyLimit,
                        Employee_IdVM=rec.Employee_Id,
                        Category = new CategoryViewModel()
                        {
                            CategoryID = employee.Id,
                            CategoryName = employee.First_Name+" "+employee.Last_Name
                        },


                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_PRCLimit_Read([DataSourceRequest]DataSourceRequest request, string wpcycleid)
        {


            List<WP_PRCLimitViewModel> collection_recs = new List<WP_PRCLimitViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
       
            var DB_Recs =  _wpPRCBudgetLimitsRepository.GetRecordsByWPCycle(wpcycleid).ToList();

          //  var emp_recs =  _employeeRepository.GetAllEmployee().ToList();

           



            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var directorate =_strucDirectorateRepository.GetRecord(rec.Directorate_Id);
   
                    WP_PRCLimitViewModel srec = new WP_PRCLimitViewModel
                    {
                        Transaction_IdVM = rec.Transaction_Id,
                        WPCycle_idVM=rec.WPCycle_id,
                        FiscalYear_IdVM=rec.FiscalYear_Id,
                        Period_IdVM=rec.Period_Id,
                        Directorate_IdVM=rec.Directorate_Id,
                        MSLimitVM=rec.MS_Limit,
                        DPLimitVM=rec.DP_Limit,
                        Category = new CategoryViewModel()
                        {
                            CategoryID = directorate.Record_Id,
                            CategoryName = directorate.Record_Name
                        },


                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_MobilityExternal_Read([DataSourceRequest]DataSourceRequest request, string wpmobilityid)
        {


            List<WP_OutputMobilityExternalPartVM> collection_recs = new List<WP_OutputMobilityExternalPartVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
       
            var DB_Recs =  _wpMobilityExternalTeamRepository.GetRecordsByMobilityId(wpmobilityid).ToList();

          //  var emp_recs =  _employeeRepository.GetAllEmployee().ToList();

           



            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var exttype=_lkupExtParticipantTypeRepository.GetRecord(rec.ExternalParticipant_Id);
   
                    WP_OutputMobilityExternalPartVM srec = new WP_OutputMobilityExternalPartVM
                    {
                        Transaction_IdExtPartVM = rec.Transaction_Id,
                        WPMainRecord_idExtPartVM=rec.WPMainRecord_id,
                        WPOutput_IdExtPartVM=rec.WPOutput_Id,
                        WPMobility_idExtPartVM=rec.WPMobility_id,
                        ExternalParticipant_IdExtPartVM=rec.ExternalParticipant_Id,
                        ExternalParticipant_DescriptionExtPartVM=rec.ExternalParticipant_Description,
                        ExternalParticipant_NumberExtPartVM=rec.ExternalParticipant_Number,
                        ExternalType = new CategoryViewModel()
                        {
                            CategoryID = exttype.Record_Id,
                            CategoryName = exttype.Record_Name
                        },


                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult WP_Outputs_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

            var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

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
                       // Output_BudgetAmount= _wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(rec.Project_Id, rec.FiscalYear_Id, rec.Period_Id, rec.Transaction_Id).Output_BudgetAmount,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    collection_recs.Add(srec);
                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        


        public ActionResult WP_Gantt_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            List<TaskViewModel> collection_recs2 = new List<TaskViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByMainRecordId(recid).ToList();

            int _count =  DB_Recs.Count();
           int _cnt = 0;


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_RecsActivities=_wpOutputActivitiesRepository.GetRecordsByMainRecordOutputId(recid, rec.Transaction_Id);
                    DateTime? minDate = null, maxDate = null;
                    double percentcomplete=0;
                    int count=0;
                    _cnt=_cnt+1;
                    int _act_id=0;

                    int _activity_count=DB_RecsActivities.Count();

                    if(_activity_count > 0)
                    {
                        foreach (var rec_activity in DB_RecsActivities)
                        {
                            DateTime sDate= new DateTime(rec_activity.ActivityStartDate.Year, rec_activity.ActivityStartDate.Month, rec_activity.ActivityStartDate.Day);
                            DateTime eDate= new DateTime(rec_activity.ActivityEndDate.Year, rec_activity.ActivityEndDate.Month, rec_activity.ActivityEndDate.Day);

                            if ((minDate == null) || (sDate < minDate.Value))
                                minDate = sDate;

                            if ((maxDate == null) || (eDate > maxDate.Value))
                                maxDate = eDate;

                            percentcomplete=percentcomplete+rec_activity.BaselineTechnical;
                            count=count+1;

                            _act_id=(_cnt*1000)+count;

                            TaskViewModel srec_act = new TaskViewModel
                            {
                                Output_Id=rec.Transaction_Id,
                                Activity_Id=rec_activity.Transaction_Id,
                                TaskID=_act_id,
                                OrderId=_act_id,
                                ParentID=_cnt,
                                Start=DateTime.SpecifyKind(new DateTime(rec_activity.ActivityStartDate.Year, rec_activity.ActivityStartDate.Month, rec_activity.ActivityStartDate.Day), DateTimeKind.Utc),
                                End=DateTime.SpecifyKind(new DateTime(rec_activity.ActivityEndDate.Year, rec_activity.ActivityEndDate.Month, rec_activity.ActivityEndDate.Day), DateTimeKind.Utc),
                                Title=rec_activity.ActivityDescription,
                                PercentComplete=(decimal)(rec_activity.BaselineTechnical/100),
                                Summary=false,
                                Expanded=false
                            };
                            collection_recs2.Add(srec_act);
                            
                        }
                        percentcomplete=(percentcomplete/count)/100;

                        

                        TaskViewModel srec_main = new TaskViewModel
                        {
                            Output_Id=rec.Transaction_Id,
                            TaskID=_cnt,
                            OrderId=_cnt,
                            ParentID=null,
                            Start=DateTime.SpecifyKind(minDate.Value, DateTimeKind.Utc),
                            End=DateTime.SpecifyKind(maxDate.Value, DateTimeKind.Utc),
                            Title=rec.Output,
                            PercentComplete=(decimal)percentcomplete,
                            Summary=true,
                            Expanded=true
                        };
                        collection_recs2.Add(srec_main);
                    }
                }
            }




           return Json(collection_recs2.ToDataSourceResult(request));
        }



        


        public ActionResult WP_GanttMobility_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            List<TaskViewModel> collection_recs2 = new List<TaskViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByMainRecordId(recid).ToList();

            int _count =  DB_Recs.Count();
           int _cnt = 0;


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_RecsMobility=_wpMobilityRepository.GetRecordsByMainRecordOutputId(recid, rec.Transaction_Id);
                    DateTime? minDate = null, maxDate = null;
                    double percentcomplete=0;
                    int count=0;
                    _cnt=_cnt+1;
                    int _mob_id=0;

                    int _mobility_count=DB_RecsMobility.Count();

                    if(_mobility_count > 0)
                    {
                        foreach (var rec_set in DB_RecsMobility)
                        {
                            DateTime sDate= new DateTime(rec_set.MobilityStartDate.Year, rec_set.MobilityStartDate.Month, rec_set.MobilityStartDate.Day);
                            DateTime eDate= new DateTime(rec_set.MobilityEndDate.Year, rec_set.MobilityEndDate.Month, rec_set.MobilityEndDate.Day);

                            if ((minDate == null) || (sDate < minDate.Value))
                                minDate = sDate;

                            if ((maxDate == null) || (eDate > maxDate.Value))
                                maxDate = eDate;

                            percentcomplete=0;
                            count=count+1;

                            _mob_id=(_cnt*1000)+count;

                            TaskViewModel srec_ = new TaskViewModel
                            {
                                Output_Id=rec.Transaction_Id,
                                Mobility_Id=rec_set.Transaction_Id,
                                TaskID=_mob_id,
                                OrderId=_mob_id,
                                ParentID=_cnt,
                                Start=DateTime.SpecifyKind(new DateTime(rec_set.MobilityStartDate.Year, rec_set.MobilityStartDate.Month, rec_set.MobilityStartDate.Day), DateTimeKind.Utc),
                                End=DateTime.SpecifyKind(new DateTime(rec_set.MobilityEndDate.Year, rec_set.MobilityEndDate.Month, rec_set.MobilityEndDate.Day), DateTimeKind.Utc),
                                Title=rec_set.WPMobility_Description,
                                PercentComplete=0,
                                Summary=false,
                                Expanded=false
                            };
                            collection_recs2.Add(srec_);
                            
                        }
                        percentcomplete=0;

                        

                        TaskViewModel srec_main = new TaskViewModel
                        {
                            Output_Id=rec.Transaction_Id,
                            TaskID=_cnt,
                            OrderId=_cnt,
                            ParentID=null,
                            Start=DateTime.SpecifyKind(minDate.Value, DateTimeKind.Utc),
                            End=DateTime.SpecifyKind(maxDate.Value, DateTimeKind.Utc),
                            Title=rec.Output,
                            PercentComplete=(decimal)percentcomplete,
                            Summary=true,
                            Expanded=true
                        };
                        collection_recs2.Add(srec_main);
                    }
                }
            }




           return Json(collection_recs2.ToDataSourceResult(request));
        }




        public ActionResult WP_GanttProcurement_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            List<TaskViewModel> collection_recs2 = new List<TaskViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByMainRecordId(recid).ToList();

            int _count =  DB_Recs.Count();
           int _cnt = 0;


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Records=_wpProcurementRepository.GetRecordsByMainRecordOutputId(recid, rec.Transaction_Id);
                    DateTime? minDate = null, maxDate = null;
                    double percentcomplete=0;
                    int count=0;
                    _cnt=_cnt+1;
                    int _mob_id=0;

                    int _recs_count=DB_Records.Count();

                    if(_recs_count > 0)
                    {
                        foreach (var rec_set in DB_Records)
                        {
                            DateTime sDate= new DateTime(rec_set.WPProcurementStartDate.Year, rec_set.WPProcurementStartDate.Month, rec_set.WPProcurementStartDate.Day);
                            DateTime eDate= new DateTime(rec_set.WPProcurementEndDate.Year, rec_set.WPProcurementEndDate.Month, rec_set.WPProcurementEndDate.Day);

                            if ((minDate == null) || (sDate < minDate.Value))
                                minDate = sDate;

                            if ((maxDate == null) || (eDate > maxDate.Value))
                                maxDate = eDate;

                            percentcomplete=0;
                            count=count+1;

                            _mob_id=(_cnt*1000)+count;

                            TaskViewModel srec_ = new TaskViewModel
                            {
                                Output_Id=rec.Transaction_Id,
                                Procurement_Id=rec_set.Transaction_Id,
                                TaskID=_mob_id,
                                OrderId=_mob_id,
                                ParentID=_cnt,
                                Start=DateTime.SpecifyKind(new DateTime(rec_set.WPProcurementStartDate.Year, rec_set.WPProcurementStartDate.Month, rec_set.WPProcurementStartDate.Day), DateTimeKind.Utc),
                                End=DateTime.SpecifyKind(new DateTime(rec_set.WPProcurementEndDate.Year, rec_set.WPProcurementEndDate.Month, rec_set.WPProcurementEndDate.Day), DateTimeKind.Utc),
                                Title=rec_set.WPProcurement_Description,
                                PercentComplete=0,
                                Summary=false,
                                Expanded=false
                            };
                            collection_recs2.Add(srec_);
                            
                        }
                        percentcomplete=0;

                        

                        TaskViewModel srec_main = new TaskViewModel
                        {
                            Output_Id=rec.Transaction_Id,
                            TaskID=_cnt,
                            OrderId=_cnt,
                            ParentID=null,
                            Start=DateTime.SpecifyKind(minDate.Value, DateTimeKind.Utc),
                            End=DateTime.SpecifyKind(maxDate.Value, DateTimeKind.Utc),
                            Title=rec.Output,
                            PercentComplete=(decimal)percentcomplete,
                            Summary=true,
                            Expanded=true
                        };
                        collection_recs2.Add(srec_main);
                    }
                }
            }




           return Json(collection_recs2.ToDataSourceResult(request));
        }



        public ActionResult WP_GanttCommunication_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            List<TaskViewModel> collection_recs2 = new List<TaskViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByMainRecordId(recid).ToList();

            int _count =  DB_Recs.Count();
           int _cnt = 0;


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Records=_wpCommunicationRepository.GetRecordsByMainRecordOutputId(recid, rec.Transaction_Id);
                    DateTime? minDate = null, maxDate = null;
                    double percentcomplete=0;
                    int count=0;
                    _cnt=_cnt+1;
                    int _mob_id=0;

                    int _recs_count=DB_Records.Count();

                    if(_recs_count > 0)
                    {
                        foreach (var rec_set in DB_Records)
                        {
                            DateTime sDate= new DateTime(rec_set.WPCommsStartDate.Year, rec_set.WPCommsStartDate.Month, rec_set.WPCommsStartDate.Day);
                            DateTime eDate= new DateTime(rec_set.WPCommsEndDate.Year, rec_set.WPCommsEndDate.Month, rec_set.WPCommsEndDate.Day);

                            if ((minDate == null) || (sDate < minDate.Value))
                                minDate = sDate;

                            if ((maxDate == null) || (eDate > maxDate.Value))
                                maxDate = eDate;

                            percentcomplete=0;
                            count=count+1;

                            _mob_id=(_cnt*1000)+count;

                            TaskViewModel srec_ = new TaskViewModel
                            {
                                Output_Id=rec.Transaction_Id,
                                Communication_Id=rec_set.Transaction_Id,
                                TaskID=_mob_id,
                                OrderId=_mob_id,
                                ParentID=_cnt,
                                Start=DateTime.SpecifyKind(new DateTime(rec_set.WPCommsStartDate.Year, rec_set.WPCommsStartDate.Month, rec_set.WPCommsStartDate.Day), DateTimeKind.Utc),
                                End=DateTime.SpecifyKind(new DateTime(rec_set.WPCommsEndDate.Year, rec_set.WPCommsEndDate.Month, rec_set.WPCommsEndDate.Day), DateTimeKind.Utc),
                                Title=rec_set.WPComms_Description,
                                PercentComplete=0,
                                Summary=false,
                                Expanded=false
                            };
                            collection_recs2.Add(srec_);
                            
                        }
                        percentcomplete=0;

                        

                        TaskViewModel srec_main = new TaskViewModel
                        {
                            Output_Id=rec.Transaction_Id,
                            TaskID=_cnt,
                            OrderId=_cnt,
                            ParentID=null,
                            Start=DateTime.SpecifyKind(minDate.Value, DateTimeKind.Utc),
                            End=DateTime.SpecifyKind(maxDate.Value, DateTimeKind.Utc),
                            Title=rec.Output,
                            PercentComplete=(decimal)percentcomplete,
                            Summary=true,
                            Expanded=true
                        };
                        collection_recs2.Add(srec_main);
                    }
                }
            }




           return Json(collection_recs2.ToDataSourceResult(request));
        }




        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        public virtual JsonResult WP_Gantt_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                //taskService.Update(task, ModelState);
                if(model.Summary==false)
                {
                    if(model.Activity_Id!=null)
                    {
                        WP_OutputActivities rec=_wpOutputActivitiesRepository.GetRecord(model.Activity_Id);

                        if(rec!=null)
                        {
                            rec.ActivityStartDate=new LocalDate(model.Start.Year, model.Start.Month, model.Start.Day);
                            rec.ActivityEndDate=new LocalDate(model.End.Year, model.End.Month, model.End.Day);
                            rec.BaselineTechnical=(double)(model.PercentComplete*100);

                            _wpOutputActivitiesRepository.Update(rec);
                        }
                    }


                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }




        public virtual JsonResult WP_GanttMobility_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                //taskService.Update(task, ModelState);
                if(model.Summary==false)
                {
                    if(model.Mobility_Id!=null)
                    {
                        WP_Mobility rec=_wpMobilityRepository.GetRecord(model.Mobility_Id);

                        if(rec!=null)
                        {
                            rec.MobilityStartDate=new LocalDate(model.Start.Year, model.Start.Month, model.Start.Day);
                            rec.MobilityEndDate=new LocalDate(model.End.Year, model.End.Month, model.End.Day);
                      
                            _wpMobilityRepository.Update(rec);
                        }
                    }


                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult WP_GanttProcurement_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                //taskService.Update(task, ModelState);
                if(model.Summary==false)
                {
                    if(model.Procurement_Id!=null)
                    {
                        WP_Procurement rec=_wpProcurementRepository.GetRecord(model.Procurement_Id);

                        if(rec!=null)
                        {
                            rec.WPProcurementStartDate=new LocalDate(model.Start.Year, model.Start.Month, model.Start.Day);
                            rec.WPProcurementEndDate=new LocalDate(model.End.Year, model.End.Month, model.End.Day);
                      
                            _wpProcurementRepository.Update(rec);
                        }
                    }


                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        public virtual JsonResult WP_GanttCommunication_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                //taskService.Update(task, ModelState);
                if(model.Summary==false)
                {
                    if(model.Communication_Id!=null)
                    {
                        WP_Communication rec=_wpCommunicationRepository.GetRecord(model.Communication_Id);

                        if(rec!=null)
                        {
                            rec.WPCommsStartDate=new LocalDate(model.Start.Year, model.Start.Month, model.Start.Day);
                            rec.WPCommsEndDate=new LocalDate(model.End.Year, model.End.Month, model.End.Day);
                      
                            _wpCommunicationRepository.Update(rec);
                        }
                    }


                }
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }




        [HttpPost]
        public virtual JsonResult WP_Gantt_Delete([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if(model.Activity_Id!=null)
                {
                    WP_OutputActivities rec=_wpOutputActivitiesRepository.GetRecord(model.Activity_Id);

                    //Now Delete the record
                    if (rec != null)
                    {
                        _wpOutputActivitiesRepository.Delete(rec.Transaction_Id);

                    } 

                }
            }


            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [HttpPost]
        public virtual JsonResult WP_GanttMobility_Delete([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if(model.Mobility_Id!=null)
                {
                    WP_Mobility rec=_wpMobilityRepository.GetRecord(model.Mobility_Id);

                    //Now Delete the record
                    if (rec != null)
                    {
                        _wpMobilityRepository.Delete(rec.Transaction_Id);

                    } 

                }
            }


            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }




        [HttpPost]
        public virtual JsonResult WP_GanttProcurement_Delete([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if(model.Procurement_Id!=null)
                {
                    WP_Procurement rec=_wpProcurementRepository.GetRecord(model.Procurement_Id);

                    //Now Delete the record
                    if (rec != null)
                    {
                        _wpProcurementRepository.Delete(rec.Transaction_Id);

                    } 

                }
            }


            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }


        [HttpPost]
        public virtual JsonResult WP_GanttCommunication_Delete ([DataSourceRequest] DataSourceRequest request, TaskViewModel model)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                if(model.Communication_Id!=null)
                {
                    WP_Communication rec=_wpCommunicationRepository.GetRecord(model.Communication_Id);

                    //Now Delete the record
                    if (rec != null)
                    {
                        _wpCommunicationRepository.Delete(rec.Transaction_Id);

                    } 

                }
            }


            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }



        [HttpPost]
        public ActionResult _GetCompletionLevelOfWPS_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();
            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Compute Level Divisions Submissions***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                    double _totaldivisions =  Convert.ToDouble(DB_RecordsDivs.Count());
                    int _numofdivisions_thathave_submitted=0;
               
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }


                        if(DivMainRecs.Count()>0)
                        {
                            _numofdivisions_thathave_submitted=_numofdivisions_thathave_submitted+1;
                        }
                    }

                    double _numofdivssubmitted=Convert.ToDouble(_numofdivisions_thathave_submitted);

                    double divsubmissionlevel=(_numofdivssubmitted/_totaldivisions)*100;

                    if(Double.IsNaN(divsubmissionlevel))
                        divsubmissionlevel=0;




                    //**********Compute Completeness Level of Submissions***********// 

                   // Compute the Denominator
                    int _totalprojectsubmitted=0;
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }
                        _totalprojectsubmitted=_totalprojectsubmitted+DivMainRecs.Count();
                    }
                    int score_denominator=_totalprojectsubmitted*100;

                    //Compute the Numerator
                       int score_numerator_score=0;
                    foreach (var rec_div in DB_RecordsDivs)
                    {

                        int outcomes=0;
                        int outputs=0;
                        int activities=0;
                        int comms=0;
                        int risk=0;

                        var DB_DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DB_DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DB_DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }
                        foreach (var rec_proj_main in DB_DivMainRecs)
                        {
                            var DB_OutcomeRecs=_wpOutcomesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            if(DB_OutcomeRecs.Count()>0)
                                outcomes=20;

                            var DB_OutputsRecs=_wpOutputsRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            if(DB_OutputsRecs.Count()>0)
                                outputs=30;
                            
                            var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            if(DB_ActivitiesRecs.Count()>0)
                                activities=30;

                            var DB_CommsRecs=_wpCommunicationRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            if(DB_CommsRecs.Count()>0)
                                comms=10;

                            var DB_RiskRecs=_wpRiskProfileRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            if(DB_RiskRecs.Count()>0)
                                risk=10;

                            score_numerator_score=score_numerator_score+(outcomes+outputs+activities+comms+risk);
                        }

                    }

                    double completionlevel=(Convert.ToDouble(score_numerator_score)/Convert.ToDouble(score_denominator))*100;

                    if(Double.IsNaN(completionlevel))
                        completionlevel=0;

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        DivisionSubmissions=divsubmissionlevel,
                        CompletenessOfSubmissions=completionlevel
                    };


                    collection_recs.Add(srec1);



                   



                }
            }




            return Json(collection_recs);
        }

        [HttpPost]
        public ActionResult _GetDirectorateMTPContributions_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();

            //MTP Return Values Variables
            double economic_rtn=0;
            double invest_rtn=0;
            double advancing_rtn=0;
            double service_rtn=0;
            double institutional_rtn=0;

            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Divisions Submissions***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                    
                    double _total_for_mtps =  0;

                    double _economic_cnt=0;
                    double _invest_cnt=0;
                    double _advancing_cnt=0;
                    double _service_cnt=0;
                    double _institutional_cnt=0;
                 
               
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                       // _total_for_mtps=Convert.ToDouble(DivMainRecs.Count());

                        foreach (var projwpmainrec in DivMainRecs)
                        {
                            //GetRecordsByMainRecordId
                            var MappedProjMTPs=_wpMTPRepository.GetRecordsByMainRecordId(projwpmainrec.Transaction_Id);
                            _total_for_mtps=_total_for_mtps + Convert.ToDouble(MappedProjMTPs.Count());

                            foreach (var mtprec in MappedProjMTPs)
                            {
                                if(mtprec.MTP_Id==1)
                                    _economic_cnt=_economic_cnt+1;
                                else if(mtprec.MTP_Id==2)
                                    _invest_cnt=_invest_cnt+1;
                                else if(mtprec.MTP_Id==3)
                                    _advancing_cnt=_advancing_cnt+1;
                                else if(mtprec.MTP_Id==4)
                                    _service_cnt=_service_cnt+1;
                                else if(mtprec.MTP_Id==5)
                                    _institutional_cnt=_institutional_cnt+1;


                            }


                        }
                
                    }
                    //Math.Round((mtp_total/totalcontributions)*100, 1)

                    if(_total_for_mtps>0)
                        economic_rtn=Math.Round((_economic_cnt/_total_for_mtps)*100, 0);
                    else
                        economic_rtn=0;

                    if(_total_for_mtps>0)
                        invest_rtn=Math.Round((_invest_cnt/_total_for_mtps)*100, 0);
                    else
                        invest_rtn=0;

                    if(_total_for_mtps>0)
                        advancing_rtn=Math.Round((_advancing_cnt/_total_for_mtps)*100, 0);
                    else
                        advancing_rtn=0;

                    if(_total_for_mtps>0)
                        service_rtn=Math.Round((_service_cnt/_total_for_mtps)*100, 0);
                    else
                        service_rtn=0;

                    if(_total_for_mtps>0)
                        institutional_rtn=Math.Round((_institutional_cnt/_total_for_mtps)*100, 0);
                    else
                        institutional_rtn=0;






                    

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        Economic=economic_rtn,
                        Invest=invest_rtn,
                        Advancing=advancing_rtn,
                        Service=service_rtn,
                        Institutional=institutional_rtn

                      //  CompletenessOfSubmissions=completionlevel
                    };


                    collection_recs.Add(srec1);



                   



                }
            }




            return Json(collection_recs);
        }


        [HttpPost]
        public ActionResult _GetDirectorateStraContributions_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();

            //Stra Return Values Variables
            double economicint_rtn=0;
            double humancap_rtn=0;
            double foodsys_rtn=0;
            double systener_rtn=0;
            double climateres_rtn=0;
            double sti_rtn=0;
            double instenh_rtn=0;

            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Divisions Submissions***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                    
                    double _total_for_stra =  0;

                    double _economicint_cnt=0;
                    double _humancap_cnt=0;
                    double _foodsys_cnt=0;
                    double _systener_cnt=0;
                    double _climateres_cnt=0;
                    double _sti_cnt=0;
                    double _instenh_cnt=0;
                 
               
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                       // _total_for_mtps=Convert.ToDouble(DivMainRecs.Count());

                        foreach (var projwpmainrec in DivMainRecs)
                        {
                            //GetRecordsByMainRecordId
                            var MappedProjStras=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(projwpmainrec.Transaction_Id);
                            _total_for_stra=_total_for_stra + Convert.ToDouble(MappedProjStras.Count());

                            foreach (var strarec in MappedProjStras)
                            {
                                if(strarec.Priority_Id==1)
                                    _economicint_cnt=_economicint_cnt+1;
                                else if(strarec.Priority_Id==2)
                                    _humancap_cnt=_humancap_cnt+1;
                                else if(strarec.Priority_Id==3)
                                    _foodsys_cnt=_foodsys_cnt+1;
                                else if(strarec.Priority_Id==4)
                                    _systener_cnt=_systener_cnt+1;
                                else if(strarec.Priority_Id==5)
                                    _climateres_cnt=_climateres_cnt+1;
                                else if(strarec.Priority_Id==6)
                                    _sti_cnt=_sti_cnt+1;
                                else if(strarec.Priority_Id==7)
                                    _instenh_cnt=_instenh_cnt+1;


                            }


                        }
                
                    }
                    //Math.Round((mtp_total/totalcontributions)*100, 1)

                    if(_total_for_stra>0)
                        economicint_rtn=Math.Round((_economicint_cnt/_total_for_stra)*100, 0);
                    else
                        economicint_rtn=0;

                    if(_total_for_stra>0)
                        humancap_rtn=Math.Round((_humancap_cnt/_total_for_stra)*100, 0);
                    else
                        humancap_rtn=0;

                    if(_total_for_stra>0)
                        foodsys_rtn=Math.Round((_foodsys_cnt/_total_for_stra)*100, 0);
                    else
                        foodsys_rtn=0;

                    if(_total_for_stra>0)
                        systener_rtn=Math.Round((_systener_cnt/_total_for_stra)*100, 0);
                    else
                        systener_rtn=0;

                    if(_total_for_stra>0)
                        climateres_rtn=Math.Round((_climateres_cnt/_total_for_stra)*100, 0);
                    else
                        climateres_rtn=0;

                    if(_total_for_stra>0)
                        sti_rtn=Math.Round((_sti_cnt/_total_for_stra)*100, 0);
                    else
                        sti_rtn=0;

                    if(_total_for_stra>0)
                        instenh_rtn=Math.Round((_instenh_cnt/_total_for_stra)*100, 0);
                    else
                        instenh_rtn=0;






                    

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        EconomicInt=economicint_rtn,
                        HumanCap=humancap_rtn,
                        FoodSys=foodsys_rtn,
                        SystEnergy=systener_rtn,
                        ClimateRes=climateres_rtn,
                        STI=sti_rtn,
                        StraInstitutional=instenh_rtn

                      //  CompletenessOfSubmissions=completionlevel
                    };


                    collection_recs.Add(srec1);



                   



                }
            }




            return Json(collection_recs);
        }



        [HttpPost]
        public ActionResult _GetDirectorateImplemenationType_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();

            //Stra Return Values Variables
            double subdelegation_rtn=0;
            double direct_rtn=0;
            double joint_rtn=0;


            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Divisions Submissions***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                    
                    double _total_for_imp =  0;

                    double _subdelegation_cnt=0;
                    double _direct_cnt=0;
                    double _joint_cnt=0;

                 
               
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                       // _total_for_mtps=Convert.ToDouble(DivMainRecs.Count());

                        foreach (var projwpmainrec in DivMainRecs)
                        {
                            //GetRecordsByMainRecordId
                            var MappedProjActivities=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(projwpmainrec.Transaction_Id);
                            _total_for_imp=_total_for_imp + Convert.ToDouble(MappedProjActivities.Count());

                            foreach (var actrec in MappedProjActivities)
                            {
                                if(actrec.ImplementationType_Id==1)
                                    _subdelegation_cnt=_subdelegation_cnt+1;
                                else if(actrec.ImplementationType_Id==2)
                                    _direct_cnt=_direct_cnt+1;
                                else if(actrec.ImplementationType_Id==3)
                                    _joint_cnt=_joint_cnt+1;
          


                            }


                        }
                
                    }
                    //Math.Round((mtp_total/totalcontributions)*100, 1)

                    if(_total_for_imp>0)
                        subdelegation_rtn=Math.Round((_subdelegation_cnt/_total_for_imp)*100, 0);
                    else
                        subdelegation_rtn=0;

                    if(_total_for_imp>0)
                        direct_rtn=Math.Round((_direct_cnt/_total_for_imp)*100, 0);
                    else
                        direct_rtn=0;

                    if(_total_for_imp>0)
                        joint_rtn=Math.Round((_joint_cnt/_total_for_imp)*100, 0);
                    else
                        joint_rtn=0;

                    






                    

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        SubDelegation=subdelegation_rtn,
                        DirectExe=direct_rtn,
                        JointExe=joint_rtn

                      //  CompletenessOfSubmissions=completionlevel
                    };


                    collection_recs.Add(srec1);



                   



                }
            }




            return Json(collection_recs);
        }


        [HttpPost]
        public ActionResult _GetDirectorateNewProjects_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();

            //Stra Return Values Variables
            double existingproj_rtn=0;
            double newproj_rtn=0;
        


            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Divisions Submissions***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();
                    
                    double _total_for_newproj =  0;

                    double _existingproj_cnt=0;
                    double _newproj_cnt=0;
 

                 
               
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();

                        //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                       // _total_for_mtps=Convert.ToDouble(DivMainRecs.Count());
                       _total_for_newproj=_total_for_newproj+Convert.ToDouble(DivMainRecs.Count());

                        foreach (var projwpmainrec in DivMainRecs)
                        {
                            LkUp_Project actualproject=_lkupProjectRepository.GetRecord(projwpmainrec.Project_Id);
                            
                            if(actualproject.Record_Status==true)
                                _existingproj_cnt=_existingproj_cnt+1;
                            else 
                                _newproj_cnt=_newproj_cnt+1;
     
                        }
                
                    }
                    //Math.Round((mtp_total/totalcontributions)*100, 1)
                    //Currently not using this...

                    if(_total_for_newproj>0)
                        existingproj_rtn=Math.Round((_existingproj_cnt/_total_for_newproj)*100, 0);
                    else
                        existingproj_rtn=0;

                    if(_total_for_newproj>0)
                        newproj_rtn=Math.Round((_newproj_cnt/_total_for_newproj)*100, 0);
                    else
                        newproj_rtn=0;

                    //Currently using this...

                    existingproj_rtn=_existingproj_cnt;
                    newproj_rtn=_newproj_cnt;

                    






                    

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        ExistingProjs=existingproj_rtn,
                        NewProjs=newproj_rtn

                      //  CompletenessOfSubmissions=completionlevel
                    };
                    collection_recs.Add(srec1);

                }
            }




            return Json(collection_recs);
        }


        [HttpPost]
        public ActionResult _GetInstitutionalMTPContributions_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);


            double totalcontributions=0;

            var DB_RecsTrans =  _transStrategyMTPRepository.GetAllRecords().ToList();

            //Get Total Contributions
            foreach (var rec_set in DB_RecsTrans)
            {
                var DB_WPMTPRecs=_wpMTPRepository.GetAllRecords().ToList();
                               //Fetch the Correct Recs
                if(currentcyclerec.Period_Id==8)
                {
                    DB_WPMTPRecs=_wpMTPRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPMTPRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if((mainrec.PeriodStartDate==currentcyclerec.PeriodStartDate) && (mainrec.PeriodEndDate==currentcyclerec.PeriodEndDate))
                        {
                            totalcontributions=totalcontributions+1;
                        }
                    }
                }
                else
                {
                    DB_WPMTPRecs=_wpMTPRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();

                    totalcontributions=Convert.ToDouble(DB_WPMTPRecs.Count());
                }

            }

            foreach (var rec_set in DB_RecsTrans)
            {
                //WP_MTP
                var DB_WPMTPRecs=_wpMTPRepository.GetAllRecords().ToList();
                double mtp_total=0;
                double mtp_contribution=0;

                //Fetch the Correct Recs
                if(currentcyclerec.Period_Id==8)
                {
                    DB_WPMTPRecs=_wpMTPRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPMTPRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if((wprec_set.MTP_Id==rec_set.Record_Id) && (mainrec.PeriodStartDate==currentcyclerec.PeriodStartDate) && (mainrec.PeriodEndDate==currentcyclerec.PeriodEndDate))
                        {
                            mtp_total=mtp_total+1;
                            
                        }
                    }
                    mtp_contribution=Math.Round((mtp_total/totalcontributions)*100, 1);

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strategyMTPRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DNameOther=_strategyMTPRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DValue=mtp_contribution
                    };


                    collection_recs.Add(srec1);

                }
                else
                {
                    DB_WPMTPRecs=_wpMTPRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPMTPRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if(wprec_set.MTP_Id==rec_set.Record_Id)
                        {
                            mtp_total=mtp_total+1;
                        }
                    }
                    mtp_contribution=Math.Round((mtp_total/totalcontributions)*100, 1);

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strategyMTPRepository.GetRecord(rec_set.Record_Id).ShortName,
                        DNameOther=_strategyMTPRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DValue=mtp_contribution
                    };


                    collection_recs.Add(srec1);




                }


            }
        
            




            return Json(collection_recs);
        }

        [HttpPost]
        public ActionResult _GetInstitutionalStraContributions_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

            WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);


            double totalcontributions=0;

            var DB_RecsTrans =  _transStrategyPriorityRepository.GetAllRecords().ToList();

            //Get Total Contributions
            foreach (var rec_set in DB_RecsTrans)
            {
                var DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetAllRecords().ToList();
                               //Fetch the Correct Recs
                if(currentcyclerec.Period_Id==8)
                {
                    DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPAUDAPriorityRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if((mainrec.PeriodStartDate==currentcyclerec.PeriodStartDate) && (mainrec.PeriodEndDate==currentcyclerec.PeriodEndDate))
                        {
                            totalcontributions=totalcontributions+1;
                        }
                    }
                }
                else
                {
                    DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();

                    totalcontributions=Convert.ToDouble(DB_WPAUDAPriorityRecs.Count());
                }

            }

            foreach (var rec_set in DB_RecsTrans)
            {
                //WP_MTP
                var DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetAllRecords().ToList();
                double stra_total=0;
                double stra_contribution=0;

                //Fetch the Correct Recs
                if(currentcyclerec.Period_Id==8)
                {
                    DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPAUDAPriorityRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if((wprec_set.Priority_Id==rec_set.Record_Id) && (mainrec.PeriodStartDate==currentcyclerec.PeriodStartDate) && (mainrec.PeriodEndDate==currentcyclerec.PeriodEndDate))
                        {
                            stra_total=stra_total+1;
                            
                        }
                    }
                    stra_contribution=Math.Round((stra_total/totalcontributions)*100, 1);

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strategyPriorityRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DNameOther=_strategyPriorityRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DValue=stra_contribution
                    };


                    collection_recs.Add(srec1);

                }
                else
                {
                    DB_WPAUDAPriorityRecs=_wpAUDAPriorityRepository.GetRecordsByYearAndPeriod(currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                    foreach (var wprec_set in DB_WPAUDAPriorityRecs)
                    {
                        WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wprec_set.WPMainRecord_id);
                        if(wprec_set.Priority_Id==rec_set.Record_Id)
                        {
                            stra_total=stra_total+1;
                        }
                    }
                    stra_contribution=Math.Round((stra_total/totalcontributions)*100, 1);

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strategyPriorityRepository.GetRecord(rec_set.Record_Id).ShortName,
                        DNameOther=_strategyPriorityRepository.GetRecord(rec_set.Record_Id).Record_Name,
                        DValue=stra_contribution
                    };


                    collection_recs.Add(srec1);




                }


            }
        
            




            return Json(collection_recs);
        }


        public ActionResult _GetPRCBudgetThresholds_Draft(string cycleid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

             WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();
            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Compute Total MS and DP Budgets of Directorates***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();

                    double directorate_dp_budget=0;
                    double directorate_ms_budget=0;
                    double directorate_total_budget=0;
  
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                                //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                        foreach (var rec_proj_main in DivMainRecs)
                        {
                            var DB_ActivitiesRecs=_wpOutputActivitiesRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();
                            foreach (var rec_proj_act in DB_ActivitiesRecs)
                            {
                                directorate_total_budget=directorate_total_budget+rec_proj_act.ActivityCost;
                               
                                if(rec_proj_act.PartnerFunding==true)
                                {
                                    directorate_dp_budget=directorate_dp_budget+rec_proj_act.ActivityCost;
                                }

                            }
                        }

                    }

                    directorate_ms_budget=directorate_total_budget-directorate_dp_budget;

                    double directorate_dp_budgetV=directorate_dp_budget/1000000;
                    double directorate_ms_budgetV=directorate_ms_budget/1000000;

                    if(Double.IsNaN(directorate_dp_budgetV))
                        directorate_dp_budgetV=0;

                    if(Double.IsNaN(directorate_ms_budgetV))
                        directorate_ms_budgetV=0;




                    //**********Retrieve and Compute PRC Thresholds***********// 

                   // Retrieve PRC Thresholds  
          

                    WP_PRCBudgetLimits prccyclelimit=_wpPRCBudgetLimitsRepository.GetRecordByDirectorateAndCycle(rec_set.Record_Id,currentcyclerec.Transaction_Id);

                   
                    double directorate_dp_prc=0;//change this
                    double directorate_ms_prc=0;//change this

                    if(prccyclelimit!=null)
                    {
                        directorate_dp_prc=prccyclelimit.DP_Limit;
                        directorate_ms_prc=prccyclelimit.MS_Limit;
                    }

                    double directorate_dp_prcV=directorate_dp_prc/1000000;
                    double directorate_ms_prcV=directorate_ms_prc/1000000;

                    if(Double.IsNaN(directorate_dp_prcV))
                        directorate_dp_prcV=0;

                    if(Double.IsNaN(directorate_ms_prcV))
                        directorate_ms_prcV=0;

                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        DirectorateMSBudget=directorate_ms_budgetV,
                        DirectorateDPBudget=directorate_dp_budgetV,
                        PRCMSThreshold=directorate_ms_prcV,
                        PRCDPThreshold=directorate_dp_prcV
                    };


                    collection_recs.Add(srec1);



                   



                }
            }




            return Json(collection_recs);
        }


        public ActionResult _GetPRCBudgetThresholds_DraftPeriodRange(string cycleid, string periodid)
        {
            List<WP_InstitutionalGraphsVM> collection_recs = new List<WP_InstitutionalGraphsVM>();

             WP_DispatchCycle currentcyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();

            int _countrecs =  DB_Records.Count();
            if(_countrecs>0)
            {
                foreach (var rec_set in DB_Records)
                {
                    //**********Compute Total MS and DP Budgets of Directorates***********// 

                    Struc_Directorate dir=_strucDirectorateRepository.GetRecord(rec_set.Record_Id);

                    var DB_RecordsDivs=_transStrucDivisionRepository.GetAllRecordsByDirectorate(rec_set.Transaction_Id).ToList();

                    double directorate_dp_budget=0;
                    double directorate_ms_budget=0;
                   // double directorate_total_budget=0;
  
                    //Check if the division have any submission GetRecordsByDivRecs
                    foreach (var rec_div in DB_RecordsDivs)
                    {
                        var DivMainRecs=_wpMainRecordRepository.GetRecordsByDivRecs(rec_div.Division_Id).ToList();
                                                //Fetch the Division Records that correspond the cycle 
                        if(currentcyclerec.Period_Id==8)
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriodStartEnd(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DivMainRecs=_wpMainRecordRepository.GetRecordsByDivisionYearAndPeriod(rec_div.Division_Id, currentcyclerec.FiscalYear_Id,currentcyclerec.Period_Id).ToList();
                        }

                        foreach (var rec_proj_main in DivMainRecs)
                        {

                            
                            var DB_Outpus_for_Project=_wpOutputsRepository.GetRecordsByMainRecordId(rec_proj_main.Transaction_Id).ToList();

                            foreach (var rec_proj_output in DB_Outpus_for_Project)
                            {
                               // bool dpfunding=false;
                                int ms_count=0;
                                int dp_count=0;
                                double output_total_budget=0;

                                var DB_OutputActivities=_wpOutputActivitiesRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();

                                foreach (var rec_proj_output_act in DB_OutputActivities)
                                {
                                    if(rec_proj_output_act.PartnerFunding==true)
                                    {
                                        dp_count=dp_count+1;
                                    }
                                    else
                                    {
                                        ms_count=ms_count+1;
                                    }
                                    output_total_budget=output_total_budget+rec_proj_output_act.ActivityCost;

                                }

                                //Get All the Mobility Records that Meet the Period Range Boundry
                                var DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Mobilities_Recs_All=_wpMobilityRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Mobilities_Recs=_wpMobilityRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                                }



                                //Get All the Procurement Records that Meet the Period Range Boundry

                                var DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Procurement_Recs_All=_wpProcurementRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Procurement_Recs=_wpProcurementRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                                }

                                //Get All the Communication Records that Meet the Period Range Boundry

                                var DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                var DB_Communication_Recs_All=_wpCommunicationRepository.GetRecordsByOutputId(rec_proj_output.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                               new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(currentcyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    DB_Communication_Recs=_wpCommunicationRepository.GetRecordsByOutputIdStartEndRange(rec_proj_output.Transaction_Id, currentcyclerec.PeriodStartDate, currentcyclerec.PeriodEndDate).ToList();
                                }

                                //inner totals
                                double output_dp_budget=0;
                                double output_ms_budget=0;
                                double output_budget_all=0;
                                




                                //Sum as DP
                                if(dp_count>ms_count)
                                {
                                    foreach (var _innerrec in DB_Mobilities_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs)
                                    {
                                        output_dp_budget=output_dp_budget+_innerrec.WPCommsCost;
                                    }

                                    //Get the Overall Total for Mobility, Procurement and Communication 
                                        
                                    foreach (var _innerrec in DB_Mobilities_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                    }
                                 
                                    double remainingfunds=output_total_budget-output_budget_all;

                                    //Add Adjust Cost to DP
                                    if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/4.0);
                                    }
                                    else if(periodid=="5" || periodid=="6" )
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/2.0);
                                    }
                                    else
                                    {
                                        if(remainingfunds!=0)
                                            output_dp_budget=output_dp_budget+(remainingfunds/1.0);
                                    }
                                        
                                }
                                else //Sum as MS
                                {
                                    foreach (var _innerrec in DB_Mobilities_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs)
                                    {
                                        output_ms_budget=output_ms_budget+_innerrec.WPCommsCost;
                                    }

                                     //Get the Overall Total for Mobility, Procurement and Communication 
                                        
                                    foreach (var _innerrec in DB_Mobilities_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.MobilityCost;
                                    }

                                    foreach (var _innerrec in DB_Procurement_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPProcurementCost;
                                    }

                                    foreach (var _innerrec in DB_Communication_Recs_All)
                                    {
                                        output_budget_all=output_budget_all+_innerrec.WPCommsCost;
                                    }

                                    double remainingfunds=output_total_budget-output_budget_all;

                                    //Add Adjust Cost to DP
                                    if(periodid=="1" || periodid=="2" || periodid=="3" || periodid=="4")
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/4.0);
                                    }
                                    else if(periodid=="5" || periodid=="6" )
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/2.0);
                                    }
                                    else
                                    {
                                        if(remainingfunds!=0)
                                            output_ms_budget=output_ms_budget+(remainingfunds/1.0);
                                    }

                                }
                                directorate_dp_budget=directorate_dp_budget+output_dp_budget;
                                directorate_ms_budget=directorate_ms_budget+output_ms_budget;




                                

                            }


                          
                            
                           
                        }

                    }

                   // directorate_ms_budget=directorate_total_budget-directorate_dp_budget;

                    double directorate_dp_budgetV=directorate_dp_budget/1000000;
                    double directorate_ms_budgetV=directorate_ms_budget/1000000;

                    if(Double.IsNaN(directorate_dp_budgetV))
                        directorate_dp_budgetV=0;

                    if(Double.IsNaN(directorate_ms_budgetV))
                        directorate_ms_budgetV=0;


                    WP_InstitutionalGraphsVM srec1 = new WP_InstitutionalGraphsVM
                    {   
                        DName=_strucDirectorateRepository.GetRecord(rec_set.Record_Id).AcronymName,
                        DirectorateMSBudget=directorate_ms_budgetV,
                        DirectorateDPBudget=directorate_dp_budgetV
                       // PRCMSThreshold=directorate_ms_prcV,
                       // PRCDPThreshold=directorate_dp_prcV
                    };


                    collection_recs.Add(srec1);



                }
            }




            return Json(collection_recs);
        }


        [HttpPost]
        public void Export_PRCBugetSave(string contentType, string base64, string fileName, string cycleid)
        {
            var fileContents = Convert.FromBase64String(base64);

            string Path =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"PRC.png";
           

            System.IO.File.WriteAllBytes(Path, fileContents);
        

           //return File(fileContents, contentType, fileName);
        }

        public static void ExecuteScriptFile(string scriptFilePath)//, string paramForScript1,  string paramForScript2)
        {
            using (var en = REngine.GetInstance())
            {
                //var args_r = new string[2] { paramForScript1, paramForScript2 };
                var execution = "source('" + scriptFilePath + "')";
               // en.SetCommandLineArguments(args_r);
                en.Evaluate(execution);
            }
        }


         [HttpPost]
        public ActionResult ExportSave_InstitutionalCharts(string contentType, string base64_complete, string base64_prc, string base64_mtpcontr, string base64_mtpcontrdir, string base64_stracontr, string base64_stracontrdir,  string base64_impdistr, string base64_newproj, string cycleid)
        {


            try
            {
                var fileContents_complete = Convert.FromBase64String(base64_complete);
                var fileContents_prc = Convert.FromBase64String(base64_prc);

                var fileContents_mtpcontr = Convert.FromBase64String(base64_mtpcontr);
                var fileContents_mtpcontrdir = Convert.FromBase64String(base64_mtpcontrdir);

                var fileContents_stracontr = Convert.FromBase64String(base64_stracontr);
                var fileContents_stracontrdir = Convert.FromBase64String(base64_stracontrdir);

                var fileContents_impdistr = Convert.FromBase64String(base64_impdistr);
                var fileContents_newproj = Convert.FromBase64String(base64_newproj);
                

                string Path_Complete =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"Complete.png";
                string Path_PRC =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"PRC.png";
                string Path_PRC2 =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"PRC2.png";

                string Path_MTPContr =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"MTPContr.png";
                string Path_MTPContrDir =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"MTPContrDir.png";

                string Path_StraContr =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"StraContr.png";
                string Path_StraContrDir =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"StraContrDir.png";

                string Path_ImpDistr =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"ImpDistr.png";
                string Path_NewProj =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"NewProj.png";
           
                // string Path_Complete2 =  @"wwwroot/appdirectory/pdfreports/institutional/"+cycleid+"Complete2.png";
                // System.Drawing.Image image;
                // using (MemoryStream ms = new MemoryStream(fileContents_complete))
                // {
                //     image = System.Drawing.Image.FromStream(ms, true);
                // }
                // Bitmap bitmap = new Bitmap(image, new Size(320, 960));
                // bitmap.SetResolution(200, 400);
                // bitmap.Save(Path_Complete2, System.Drawing.Imaging.ImageFormat.Png);

               // System.Drawing.Image image;
                // using (MemoryStream ms = new MemoryStream(fileContents_prc))
                // {
                //     image = System.Drawing.Image.FromStream(ms);
                // }


                // MemoryStream ms = new MemoryStream(fileContents_prc)  ;  
                // image = System.Drawing.Image.FromStream(ms);

                // Bitmap bitmap = new Bitmap(image, new Size(320, 960));
                // bitmap.SetResolution(200, 400);
                // bitmap.Save(Path_PRC2, System.Drawing.Imaging.ImageFormat.Png);





               











                System.IO.File.WriteAllBytes(Path_Complete, fileContents_complete);
                System.IO.File.WriteAllBytes(Path_PRC, fileContents_prc);

                System.IO.File.WriteAllBytes(Path_MTPContr, fileContents_mtpcontr);
                System.IO.File.WriteAllBytes(Path_MTPContrDir, fileContents_mtpcontrdir);

                System.IO.File.WriteAllBytes(Path_StraContr, fileContents_stracontr);
                System.IO.File.WriteAllBytes(Path_StraContrDir, fileContents_stracontrdir);

                System.IO.File.WriteAllBytes(Path_ImpDistr, fileContents_impdistr);
                System.IO.File.WriteAllBytes(Path_NewProj, fileContents_newproj);






/*
                int size = 1000;
                int quality = 300;


                using (var input = System.IO.File.OpenRead(Path_PRC))
                {
                    using (var inputStream = new SKManagedStream(input))
                    {
                        using (var original = SKBitmap.Decode(inputStream))
                        {
                            int width, height;
                            if (original.Width > original.Height)
                            {
                                width = size;
                                height = original.Height * size / original.Width;
                            }
                            else
                            {
                                width = original.Width * size / original.Height;
                                height = size;
                            }

                            using (var resized = original.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
                            {
                                if (resized == null) return Json(new { rtnmsg = "success" });

                                using (var image = SKImage.FromBitmap(resized))
                                {
                                    using (var output = System.IO.File.OpenWrite(Path_PRC2))
                                    {
                                        image.Encode(SKEncodedImageFormat.Jpeg, quality)
                                            .SaveTo(output);
                                       // SKImageEncodeFormat
                                    }
                                }
                            }
                        }
                    }
                }
                */


                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }

        }

        


         [HttpPost]
        public ActionResult ExportSave_InstitutionalChartsRange(string contentType, string base64_complete, string base64_prc, string base64_mtpcontr, string base64_mtpcontrdir, string base64_stracontr, string base64_stracontrdir,  string base64_impdistr, string base64_newproj, string cycleid)
        {


            try
            {
                var fileContents_complete = Convert.FromBase64String(base64_complete);
                var fileContents_prc = Convert.FromBase64String(base64_prc);

                var fileContents_mtpcontr = Convert.FromBase64String(base64_mtpcontr);
                var fileContents_mtpcontrdir = Convert.FromBase64String(base64_mtpcontrdir);

                var fileContents_stracontr = Convert.FromBase64String(base64_stracontr);
                var fileContents_stracontrdir = Convert.FromBase64String(base64_stracontrdir);

                var fileContents_impdistr = Convert.FromBase64String(base64_impdistr);
                var fileContents_newproj = Convert.FromBase64String(base64_newproj);
                

                string Path_Complete =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"Complete.png";
                string Path_PRC =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"PRC.png";
                string Path_PRC2 =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"PRC2.png";

                string Path_MTPContr =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"MTPContr.png";
                string Path_MTPContrDir =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"MTPContrDir.png";

                string Path_StraContr =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"StraContr.png";
                string Path_StraContrDir =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"StraContrDir.png";

                string Path_ImpDistr =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"ImpDistr.png";
                string Path_NewProj =  @"wwwroot/appdirectory/pdfreports/institutionalrange/"+cycleid+"NewProj.png";
           


                System.IO.File.WriteAllBytes(Path_Complete, fileContents_complete);
                System.IO.File.WriteAllBytes(Path_PRC, fileContents_prc);

                System.IO.File.WriteAllBytes(Path_MTPContr, fileContents_mtpcontr);
                System.IO.File.WriteAllBytes(Path_MTPContrDir, fileContents_mtpcontrdir);

                System.IO.File.WriteAllBytes(Path_StraContr, fileContents_stracontr);
                System.IO.File.WriteAllBytes(Path_StraContrDir, fileContents_stracontrdir);

                System.IO.File.WriteAllBytes(Path_ImpDistr, fileContents_impdistr);
                System.IO.File.WriteAllBytes(Path_NewProj, fileContents_newproj);




                return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }

        }

        

        public ActionResult WP_Outputs_for_Activities_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

           var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();
            //var DB_Recs =  _wpOutputBudgetRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }

                    WorkplansViewModel srec1 = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        Output_BudgetAmount= total_budget,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    collection_recs.Add(srec1);
                    

                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_Outputs_for_Mobilities_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

           var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();
            //var DB_Recs =  _wpOutputBudgetRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }

                    WorkplansViewModel srec1 = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        Output_BudgetAmount= total_budget,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    collection_recs.Add(srec1);
                    

                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        
        

        public ActionResult WP_Outputs_for_Procurement_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

           var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();
            //var DB_Recs =  _wpOutputBudgetRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }

                    WorkplansViewModel srec1 = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        Output_BudgetAmount= total_budget,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    collection_recs.Add(srec1);
                    

                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        



        public ActionResult WP_Outputs_for_Communication_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

           var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();
            //var DB_Recs =  _wpOutputBudgetRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }

                    WorkplansViewModel srec1 = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        Output_BudgetAmount= total_budget,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    collection_recs.Add(srec1);
                    

                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        


        
        public ActionResult WP_Outputs_for_RiskProfile_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

           var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();
            //var DB_Recs =  _wpOutputBudgetRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)).ToList();

            if(wp_mainrec_check!=null)
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId(wp_mainrec_check.Transaction_Id).ToList();
            else
                DB_Recs=_wpOutputsRepository.GetRecordsByMainRecordId("Null").ToList();

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }

                    WorkplansViewModel srec1 = new WorkplansViewModel
                    {
                        Transaction_Id = rec.Transaction_Id,
                        WPMainRecord_Ident=rec.WPMainRecord_id,
                        Output=rec.Output,
                        Output_BudgetAmount= total_budget,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    collection_recs.Add(srec1);
                    

                }
            }



            return Json(collection_recs.ToDataSourceResult(request));
        }
        



        [HttpPost]
        public ActionResult SetExpandedRow(string rowident)
        {
            HttpContext.Session.SetString("ExpandedRowId",rowident);
            ViewData["Nom"] = "bob";
            return new EmptyResult();
        }

        public ActionResult WP_OutputsBudget_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            var DB_OutputRecords=_wpOutputsRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            int _count =  DB_Recs.Count();
            double grandtotal=0;

            if (_count > 0)
            {
                foreach (var rec in DB_OutputRecords)
                {
                   // WP_OutputBudget wpoutputbudget_recfetch=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Transaction_Id);
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(rec.WPSAPLink_Id);
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(rec.Transaction_Id);
                    
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }
                    WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(rec.WPMainRecord_id);
                    if(rec.WPSAPLink_Id!=null)
                    {
                        
                        WorkplansViewModel srec_1 = new WorkplansViewModel
                        {
                            Transaction_Id = rec.Transaction_Id,
                            WPMainRecord_Ident=rec.WPMainRecord_id,
                            Output=rec.Output,
                            WPOutput_Id=rec.Transaction_Id,
                            Output_BudgetAmount=total_budget,
                            WPSAPLink_Id=rec.WPSAPLink_Id,
                            UtilizationPercentage=0,//not implemented
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

                        if(rec.WPSAPLink_Id!=null)
                        {
                            srec_1.LinkToSAPExecutionDisplayVM="Linked to SAP";

                        }
                        else
                        {
                            srec_1.LinkToSAPExecutionDisplayVM="Not Linked to SAP";

                        }

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
                            Output_BudgetAmount=total_budget,
                            WPSAPLink_Id="",
                            UtilizationPercentage=0,//not implemented
                           // LinkToSAPExecutionVM=false,
                           // LinkToSAPExecutionStringVM="false",
                            LinkToSAPExecutionDisplayVM="Not Linked to SAP",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        if(mainrec.LinkToSAPExecution==true)
                        {
                            srec_2.LinkToSAPExecutionVM=true;
                            srec_2.LinkToSAPExecutionStringVM="true";
                            
                        }
                        else
                        {
                            srec_2.LinkToSAPExecutionVM=false;
                            srec_2.LinkToSAPExecutionStringVM="false";
                            
                        }

                        collection_recs.Add(srec_2);
                    }
                    

                }

                var DB_Recs_Activities_for_Main =  _wpOutputActivitiesRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                
        
                foreach (var record in DB_Recs_Activities_for_Main)
                {
                    grandtotal=grandtotal+record.ActivityCost;

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


             WP_Outputs wpoutput_recfetch=_wpOutputsRepository.GetRecord(transid);

            if(wpoutput_recfetch!=null)
            {
                if(wpoutput_recfetch.WPSAPLink_Id!=null)
                {
                   // var DB_BudgetSAPLinks=_wpOutputBudgetRepository.GetRecordsBySAPLinkId(recbudget.WPSAPLink_Id);
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(wpoutput_recfetch.WPSAPLink_Id);

                 
                    double sapbudgetutilization=0;

                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(wpoutput_recfetch.Transaction_Id);
                    double total_budget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_budget=total_budget+record.ActivityCost;

                    }
                    var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(wpoutput_recfetch.WPSAPLink_Id);
                    double total_use=0;
                    foreach (var record in DB_Recs_Activities_Linked_SAP)
                    {
                        total_use=total_use+record.ActivityCost;

                    }

                    sapbudgetutilization=Math.Round((total_use/saplinkrec.SAP_BudgetAmount)*100);

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

                    if(rec.IndicatorCategory=="Institutional-Level")
                    {
                        srec.IndicatorStatementOIVM=_strategyOutputIndicatorsRepository.GetRecord(rec.OutputIndicator_Id).Record_Name;
                    }
                    else if (rec.IndicatorCategory=="Directorate-Level")
                    {
                        srec.IndicatorStatementOIVM=_strucDirDivIndicatorsRepository.GetRecord(rec.OutputIndicator_Id).Record_Name;

                    }
                    else if (rec.IndicatorCategory=="Project-Level")
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


        public ActionResult WP_OutcomesSubIndicators_Read([DataSourceRequest]DataSourceRequest request, string outcome_transid)
        {


            List<WP_OutcomeIndicatorsSubGridVM> collection_recs = new List<WP_OutcomeIndicatorsSubGridVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpOutcomeIndicatorsRepository.GetRecordsByOutcomeId(outcome_transid);

            int _count =  DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
   
                    WP_OutcomeIndicatorsSubGridVM srec = new WP_OutcomeIndicatorsSubGridVM
                    {
                        Transaction_IndicatorId = rec.WPOutcome_Id,
                        Outcome_ChildGridId = rec.WPOutcome_Id,
                        Transaction_IdOCIVM=rec.Transaction_Id,
                        TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };


                    if (rec.IndicatorCategory=="Project-Level")
                    {
                        srec.IndicatorStatementOCIVM=rec.ProjectBasedIndicatorStatement;

                    }


                    if(rec.IndicatorType=="Quantitative")
                    {
                        srec.BaselineOCIVM=rec.BaselineQuantitative.ToString();
                        srec.TargetOCIVM=rec.TargetQuantitative.ToString();
                    }
                    else
                    {
                        srec.BaselineOCIVM=rec.BaselineQuanlitative;
                        srec.TargetOCIVM=rec.TargetQuanlitative;

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
                        Output_ChildGridId=rec.WPOutput_Id,
                        ActivityTypeName_IdOAVM=_lkupActivityTypeRepository.GetActivityType(rec.ActivityType_Id).Activity_Name,
                        ActivityDescriptionOAVM=rec.ActivityDescription,
                        ActivityCostOAVM=rec.ActivityCost,
                        ShowGridButtons="YES",

                        TransactionDateOAVM = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                    totalcost=totalcost+rec.ActivityCost;

                    collection_recs.Add(srec);
                }
                   
                // WP_OutputActivitiesSubGridVM srectotal = new WP_OutputActivitiesSubGridVM
                // {
                //     Transaction_IdOAVM="",
                //     ActivityTypeName_IdOAVM="",
                //     ActivityDescriptionOAVM="TOTAL COST",
                //     ActivityCostOAVM=totalcost,
                //     ShowGridButtons="NO"
                // };
                // collection_recs.Add(srectotal);


            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_OutputsSubMobilities_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputMobilityVM> collection_recs = new List<WP_OutputMobilityVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpMobilityRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();
        


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    DateTime mstart=new DateTime(rec.MobilityStartDate.Year, rec.MobilityStartDate.Month, rec.MobilityStartDate.Day);
                    DateTime mend=new DateTime(rec.MobilityEndDate.Year, rec.MobilityEndDate.Month, rec.MobilityEndDate.Day);
          
   
                    WP_OutputMobilityVM srec = new WP_OutputMobilityVM
                    {
                        Transaction_IdOMVM=rec.Transaction_Id,
                        Output_ChildGridIdOMVM=rec.WPOutput_Id,
                        WPMobility_DescriptionOMVM=rec.WPMobility_Description,
                        Country_NameOMVM=_lkupCountryRepository.GetCountry(rec.Country_Id).Country_Name,
                        WPMobilityPeriodOMVM=mstart.Date.ToString("MMM d, yyyy") + " - "+ mend.Date.ToString("MMM d, yyyy"),
                        No_DaysOMVM = mstart.Date.Subtract(mend.Date).Duration().Days + 1,
                        InternalParticipantsOMVM=WP_MobilityGetInternalParticipants(rec.Transaction_Id),
                        ExternalParticipantsOMVM=WP_MobilityGetExternalParticipants(rec.Transaction_Id),


                        ShowGridButtons="YES",

                        TransactionDateOMVM= new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                 

                    collection_recs.Add(srec);
                }
                   
                // WP_OutputActivitiesSubGridVM srectotal = new WP_OutputActivitiesSubGridVM
                // {
                //     Transaction_IdOAVM="",
                //     ActivityTypeName_IdOAVM="",
                //     ActivityDescriptionOAVM="TOTAL COST",
                //     ActivityCostOAVM=totalcost,
                //     ShowGridButtons="NO"
                // };
                // collection_recs.Add(srectotal);


            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_OutputsSubProcurement_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputProcurmentVM> collection_recs = new List<WP_OutputProcurmentVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpProcurementRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();
        


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    DateTime recstart=new DateTime(rec.WPProcurementStartDate.Year, rec.WPProcurementStartDate.Month, rec.WPProcurementStartDate.Day);
                    DateTime recend=new DateTime(rec.WPProcurementEndDate.Year, rec.WPProcurementEndDate.Month, rec.WPProcurementEndDate.Day);
          
   
                    WP_OutputProcurmentVM srec = new WP_OutputProcurmentVM
                    {
                        Transaction_IdOPVM=rec.Transaction_Id,
                        Output_ChildGridIdOPVM=rec.WPOutput_Id,
                        WPProcurement_DescriptionOPVM=rec.WPProcurement_Description,
                        WPProcurementType_IdOPVM=rec.WPProcurementType_Id,
                        WPProcurementType_NameOPVM=_lkupProcurementTypeRepository.GetRecord(rec.WPProcurementType_Id).Record_Name,
                       // WPProcurementLeadTime_IdOPVM=rec.WPProcurementLeadTime_Id,
                       // WPProcurementLeadTime_NameOPVM=_lkupProcurementLTimeRepository.GetRecord(rec.WPProcurementLeadTime_Id).Record_Name,
                        WPProcurementPeriodOPVM=recstart.Date.ToString("MMM d, yyyy") + " - "+ recend.Date.ToString("MMM d, yyyy"),
                        ProcurementCostOPVM = rec.WPProcurementCost,


                        ShowGridButtons="YES",

                        TransactionDateOPVM= new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                 

                    collection_recs.Add(srec);
                }
                   
                // WP_OutputActivitiesSubGridVM srectotal = new WP_OutputActivitiesSubGridVM
                // {
                //     Transaction_IdOAVM="",
                //     ActivityTypeName_IdOAVM="",
                //     ActivityDescriptionOAVM="TOTAL COST",
                //     ActivityCostOAVM=totalcost,
                //     ShowGridButtons="NO"
                // };
                // collection_recs.Add(srectotal);


            }



            return Json(collection_recs.ToDataSourceResult(request));
        }



        public ActionResult WP_OutputsSubCommunication_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputCommunicationVM> collection_recs = new List<WP_OutputCommunicationVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpCommunicationRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();
        


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {
                    DateTime recstart=new DateTime(rec.WPCommsStartDate.Year, rec.WPCommsStartDate.Month, rec.WPCommsStartDate.Day);
                    DateTime recend=new DateTime(rec.WPCommsEndDate.Year, rec.WPCommsEndDate.Month, rec.WPCommsEndDate.Day);
          
   
                    WP_OutputCommunicationVM srec = new WP_OutputCommunicationVM
                    {
                        Transaction_IdOCVM=rec.Transaction_Id,
                        Output_ChildGridIdOCVM=rec.WPOutput_Id,
                        WPComms_DescriptionOCVM=rec.WPComms_Description,
                        WPCommsChannel_IdOCVM=rec.WPCommsChannel_Id,
                        WPCommunicationChannelOCVM=_lkupCommsChannelRepository.GetCommsChannel(rec.WPCommsChannel_Id).CommsChannel_Name,
                        WPCommunicationPeriodOCVM=recstart.Date.ToString("MMM d, yyyy") + " - "+ recend.Date.ToString("MMM d, yyyy"),
                        WPCommsCostOCVM = rec.WPCommsCost,


                        ShowGridButtons="YES",

                        TransactionDateOCVM= new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                 

                    collection_recs.Add(srec);
                }



            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public ActionResult WP_OutputsSubRiskProfile_Read([DataSourceRequest]DataSourceRequest request, string output_transid)
        {


            List<WP_OutputRiskProfileVM> collection_recs = new List<WP_OutputRiskProfileVM>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_Recs =  _wpRiskProfileRepository.GetRecordsByOutputId(output_transid);

            int _count =  DB_Recs.Count();
        


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

          
   
                    WP_OutputRiskProfileVM srec = new WP_OutputRiskProfileVM
                    {
                        Transaction_IdORVM=rec.Transaction_Id,
                        Output_ChildGridIdORVM=rec.WPOutput_Id,
                        WPRisk_DescriptionORVM=rec.WPRisk_Description,
                        WPCategory_NameORVM=_lkupRiskCategoryRepository.GetRecord(rec.WPCategory_Id).Record_Name,
                        WPRiskImpactLevel_NameORVM=_lkupRiskImpactRepository.GetRecord(rec.WPRiskImpactLevel_Id).Record_Name,
                        WPRiskCostORVM = rec.WPRiskCost,


                        ShowGridButtons="YES",

                        TransactionDateORVM= new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                    };

                 

                    collection_recs.Add(srec);
                }



            }



            return Json(collection_recs.ToDataSourceResult(request));
        }


        public string WP_MobilityGetInternalParticipants(string id)
        {
            string rtnstring = string.Empty;
            var DB_RecsInt =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(id);

            int _countint =  DB_RecsInt.Count();
            int inntercount=0;
        
            if (_countint > 0)
            {
                foreach (var recint in DB_RecsInt)
                {
                    inntercount=inntercount+1;
                    Employee employee=_employeeRepository.GetEmployee(recint.Employee_Id);


                    if(inntercount==_countint)
                    {
                        rtnstring += employee.First_Name.TrimEnd()+ " "+employee.Last_Name.TrimEnd();  
                    }
                    else
                    {
                        rtnstring += employee.First_Name.TrimEnd()+ " "+employee.Last_Name.TrimEnd()+", ";  

                    }
                }

            }
            return rtnstring;

        }

        public string WP_MobilityGetExternalParticipants(string id)
        {
            string rtnstring = string.Empty;
            var DB_RecsExt =  _wpMobilityExternalTeamRepository.GetRecordsByMobilityId(id);

            int _countext =  DB_RecsExt.Count();
            int inntercount=0;
        
            if (_countext > 0)
            {
                foreach (var recext in DB_RecsExt)
                {
                
                    inntercount=inntercount+1;

                    if(inntercount==_countext)
                    {
                        rtnstring += recext.ExternalParticipant_Description.TrimEnd()+" ("+recext.ExternalParticipant_Number.ToString()+")";  
                    }
                    else
                    {
                        rtnstring += recext.ExternalParticipant_Description.TrimEnd()+" ("+recext.ExternalParticipant_Number.ToString()+"), ";  
                    }
                }

            }
            return rtnstring;

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


        public ActionResult WP_MTPsActual_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

          //  var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

            var DB_RecsTrans =  _transStrategyMTPRepository.GetAllRecords().ToList();

            //int _count =  DB_Recs.Count();
            int iter=0;



            foreach (var rec in DB_RecsTrans)
            {
                //Modified for Period type 8
                WP_MainRecord wp_mainrec_fetch=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                            wp_mainrec_fetch=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }
                WP_MTP wpmtp_recfetch=null;
                if(wp_mainrec_fetch!=null)
                    wpmtp_recfetch=_wpMTPRepository.GetRecordsByProjectYearPeriodMTPAndMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id, wp_mainrec_fetch.Transaction_Id);
                
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
        public ActionResult WP_AUDAPrioritiesActual_Read([DataSourceRequest]DataSourceRequest request, string projid, string fyear, string fperiod, string periodtxt)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

           // WP_MainRecord wp_mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(yearid), Int32.Parse(periodid));

            var DB_RecsTrans =  _transStrategyPriorityRepository.GetAllRecords().ToList();


            int iter=0;



            foreach (var rec in DB_RecsTrans)
            {
                 //Modified for Period type 8
                WP_MainRecord wp_mainrec_fetch=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                                wp_mainrec_fetch=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }
                WP_AUDAPriority wpaudapriority_recfetch=null;
                if(wp_mainrec_fetch!=null)
                    wpaudapriority_recfetch=_wpAUDAPriorityRepository.GetRecordsByProjectYearPeriodPriorityMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id, wp_mainrec_fetch.Transaction_Id);
                
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
                            EnableRow=GetEnableStatus(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id, periodtxt),
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
                            EnableRow=GetEnableStatus(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), rec.Record_Id, periodtxt),
                            AUDA_PriorityStatement=_strategyPriorityRepository.GetRecord(rec.Record_Id).Record_Name,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)
                        };
                        collection_recs.Add(srec_2);


                }
            }




            return Json(collection_recs.ToDataSourceResult(request));
        }
        public string GetEnableStatus(int projid, int fyear, int fperiod, int priority, string periodtxt)
        {
                            //Modified for Period type 8
            WP_MainRecord wp_mainrec_fetch=null;

            if(fperiod==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(projid, fyear, fperiod);

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_fetch=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(projid, fyear, fperiod);
            }

            //var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearPeriodMainRecId(projid, fyear, fperiod, wp_mainrec_fetch.Transaction_Id);
            var DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearPeriodMainRecId(projid, fyear, fperiod, "Null");
            if(wp_mainrec_fetch!=null)
                DB_Recs =  _wpMTPRepository.GetRecordsByProjectYearPeriodMainRecId(projid, fyear, fperiod, wp_mainrec_fetch.Transaction_Id);
                
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





        public ActionResult Trans_ProcurementType_Read([DataSourceRequest]DataSourceRequest request, string text)
        {


            List<LookUpTablesViewModel> collection_recs = new List<LookUpTablesViewModel>();

            var DB_Recs =  _transProcurementTypeRepository.GetAllRecords().ToList();

            int _count = DB_Recs.Count();


            if (_count > 0)
            {
                foreach (var rec in DB_Recs)
                {

                    LookUpTablesViewModel srec = new LookUpTablesViewModel
                    {
                        LookUp_Id = rec.Record_Id,
                        Trans_LookUp_Id=rec.Transaction_Id,
                        LookUp_Name =_lkupProcurementTypeRepository.GetRecord(rec.Record_Id).Record_Name,
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

        public ActionResult DraftWorkplans_Read ([DataSourceRequest]DataSourceRequest request, string empid)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();

            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(Int32.Parse(empid)).Directorate_Id;

            var DB_RecsDivs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(Int32.Parse(empid),dirid).ToList();

            int _countDivs = DB_RecsDivs.Count();

            if (empid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                if(_countDivs>0)
                {
                    foreach (var div in DB_RecsDivs)
                    {
                        var DB_Recs = _wpMainRecordRepository.GetDraftRecordsByDivRecs(div.Division_Id).ToList();

                        int _countIndicators = DB_Recs.Count();
                        if (_countIndicators > 0)
                        {
                            foreach (var rec in DB_Recs)
                            {


                                string periodinmain="";
                                string periodinmainhidden="";
                                if(rec.Period_Id==8)
                                {
                                    DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                                    DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                                    periodinmain=pstart.Date.ToString("MMM d, yyyy") + " - "+ pend.Date.ToString("MMM d, yyyy"); 
                                    periodinmainhidden=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy");

                                }
                                else
                                {
                                    periodinmain=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name;
                                    periodinmainhidden=_lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name;

                                }  

                                WorkplansViewModel srec = new WorkplansViewModel
                                {
                                    
                                    WPMainRecord_Ident=rec.Transaction_Id,
                                    Employee_Id = Int32.Parse(empid),
                                    Directorate_Id=rec.Directorate_Id,
                                    Division_Id=rec.Division_Id,
                                    Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                                    Programme_Id=rec.Programme_Id,
                                    ProjectId=rec.Project_Id,
                                    Project_Name=_lkupProjectRepository.GetRecord(rec.Project_Id).Record_Name,
                                    FYearIdent=rec.FiscalYear_Id,
                                    FisYear=_lkupFiscalYearRepository.GetRecord(rec.FiscalYear_Id).Record_Name,
                                    FPeriodIdent=rec.Period_Id,
                                    FisPeriod=periodinmain,
                                    FisPeriodHidden=periodinmainhidden,
                                    TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                                };

                                collection_recs.Add(srec);
                            }
                        }
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }




        public ActionResult AllProcurementPlans_Read ([DataSourceRequest]DataSourceRequest request, string cycleid, string periodid)
        {


            List<WP_ProcurementGridVM> collection_recs = new List<WP_ProcurementGridVM>();

            

            

            if (cycleid != null && periodid!=null)
            {
                WP_DispatchCycle cyclerec= _wpDispatchCycleRepository.GetRecord(cycleid);

                var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();
                int _countrecs =  DB_Records.Count();

                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records)
                    {
                        var DirMainRecs=_wpMainRecordRepository.GetRecordsByDirRecs(rec_set.Record_Id).ToList();
                                

                        //Fetch the Directorate Project Records that correspond the cycle 
                        if(cyclerec.Period_Id==8)
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriodStartEnd(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriod(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                        }

                        if(DirMainRecs.Count()>0)
                        {


                            foreach (var mproject in DirMainRecs)
                            {

                                //Get WP_RiskProfiles

                                var CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordId(mproject.Transaction_Id).ToList();

                                
                                foreach(var record in CategoryRecs)
                                {
                                    WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(record.WPMainRecord_id);

                                    WP_ProcurementGridVM srec = new WP_ProcurementGridVM
                                    {
                                        Transaction_IdGVM = record.Transaction_Id,
                                        WPMainRecord_idGVM = record.WPMainRecord_id,
                                        Project_IdGVM  = record.Project_Id,
                                        FiscalYear_IdGVM  = record.FiscalYear_Id,
                                        Period_IdGVM = record.Period_Id,
                                        WPOutput_IdGVM = record.WPOutput_Id,
                                        WPProcurement_DescriptionGVM = record.WPProcurement_Description,
                                        WPProcurementType_IdGVM = record.WPProcurementType_Id,
                                        WPProcurementType_NameGVM = _lkupProcurementTypeRepository.GetRecord(record.WPProcurementType_Id).Record_Name,
                                        WPProcurementLeadTime_IdGVM = record.WPProcurementLeadTime_Id,
                                        WPProcurementCostGVM = record.WPProcurementCost,
                                        WPProcurement_SourceOfFundsDescrGVM  = record.WPProcurement_SourceOfFundsDescr,
                                        Directorate_IdGVM = mainrec.Directorate_Id,
                                        Directorate_NameGVM = _strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName,
                                        Division_IdGVM =  mainrec.Division_Id,
                                        Division_NameGVM = _strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name,
                                        Cycle_IdGVM = cycleid,
                                        InstitutionalSelectdedPeriodIdentGVM = periodid

                                    };
                                     collection_recs.Add(srec);

                                }

                            }

                        }


                    }

                }

                //Sorting
                collection_recs=collection_recs.OrderBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ToList();
   


                
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult AllOutputsPlans_Read ([DataSourceRequest]DataSourceRequest request, string cycleid, string periodid)
        {


            List<WP_OutputsGridVM> collection_recs = new List<WP_OutputsGridVM>();

            

            

            if (cycleid != null && periodid!=null)
            {
                WP_DispatchCycle cyclerec= _wpDispatchCycleRepository.GetRecord(cycleid);

                var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();
                int _countrecs =  DB_Records.Count();

                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records)
                    {
                        var DirMainRecs=_wpMainRecordRepository.GetRecordsByDirRecs(rec_set.Record_Id).ToList();
                                

                        //Fetch the Directorate Project Records that correspond the cycle 
                        if(cyclerec.Period_Id==8)
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriodStartEnd(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriod(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                        }

                        if(DirMainRecs.Count()>0)
                        {


                            foreach (var mproject in DirMainRecs)
                            {
                                //Get Periorities
                                var DB_MainProjsPriorities=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(mproject.Transaction_Id);
                                string rtnstringPriorities = string.Empty;
                                int prioritycount=0;
                                foreach(var record in DB_MainProjsPriorities)
                                {
                                    prioritycount=prioritycount+1;
                                    Strategy_Priority priority=_strategyPriorityRepository.GetRecord(record.Priority_Id);

                                    if(prioritycount==DB_MainProjsPriorities.Count())
                                    {
                                        rtnstringPriorities += "("+prioritycount.ToString()+") " + priority.Record_Name.TrimEnd();  

                                    }
                                    else
                                    {
                                        rtnstringPriorities += "("+prioritycount.ToString()+") " + priority.Record_Name.TrimEnd()+", ";  
                                    }

                                }


                                

                                //Get WP_RiskProfiles

                                var CategoryRecs=_wpOutputsRepository.GetRecordsByMainRecordId(mproject.Transaction_Id).ToList();

                                
                                foreach(var record in CategoryRecs)
                                {
                                    WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(record.WPMainRecord_id);

                                    //Total Output Budget
                                    var DB_Activities_Recs=_wpOutputActivitiesRepository.GetRecordsByOutputId(record.Transaction_Id).ToList();
                                    double output_total_budget=0;
                                    foreach (var _innerrec in DB_Activities_Recs)
                                    {
                                        output_total_budget=output_total_budget+_innerrec.ActivityCost;
                                    }

                                    WP_OutputsGridVM srec = new WP_OutputsGridVM
                                    {
                                        Transaction_IdGVM = record.Transaction_Id,
                                        WPMainRecord_idGVM = record.WPMainRecord_id,
                                        Project_IdGVM  = record.Project_Id,
                                        Project_NameGVM=_lkupProjectRepository.GetRecord(record.Project_Id).Record_Name,
                                        FiscalYear_IdGVM  = record.FiscalYear_Id,
                                        Period_IdGVM = record.Period_Id,
                                        OutputGVM = record.Output,
                                        WPOutputCostGVM=output_total_budget,
                                        Strategic_PrioritiesGVM=rtnstringPriorities,
                                        Directorate_IdGVM = mainrec.Directorate_Id,
                                        Directorate_NameGVM = _strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName,
                                        Division_IdGVM =  mainrec.Division_Id,
                                        Division_NameGVM = _strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name,
                                        Cycle_IdGVM = cycleid,
                                        InstitutionalSelectdedPeriodIdentGVM = periodid

                                    };
                                     collection_recs.Add(srec);

                                }

                            }

                        }


                    }

                }

                //Sorting
                collection_recs=collection_recs.OrderBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ThenBy(d => d.Project_NameGVM).ToList();
   


                
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }




        public ActionResult RangeProcurementPlans_Read ([DataSourceRequest]DataSourceRequest request, string cycleid, string periodid)
        {


            List<WP_ProcurementGridVM> collection_recs = new List<WP_ProcurementGridVM>();

            

            

            if (cycleid != null && periodid!=null)
            {
                WP_DispatchCycle cyclerec= _wpDispatchCycleRepository.GetRecord(cycleid);

                var DB_Records = _transStrucDirectorateRepository.GetAllRecords().ToList();
                int _countrecs =  DB_Records.Count();

                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records)
                    {
                        var DirMainRecs=_wpMainRecordRepository.GetRecordsByDirRecs(rec_set.Record_Id).ToList();
                                

                        //Fetch the Directorate Project Records that correspond the cycle 
                        if(cyclerec.Period_Id==8)
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriodStartEnd(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                        }
                        else
                        {
                            DirMainRecs=_wpMainRecordRepository.GetRecordsByDirectorateYearAndPeriod(rec_set.Record_Id, cyclerec.FiscalYear_Id,cyclerec.Period_Id).ToList();
                        }

                        if(DirMainRecs.Count()>0)
                        {


                            foreach (var mproject in DirMainRecs)
                            {

                                //Get WP_RiskProfiles

                                var CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordId(mproject.Transaction_Id).ToList();
                                if(periodid=="1")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 3))).ToList();
                                }
                                else if(periodid=="2")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 4, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="3")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 9))).ToList();
                                }
                                else if(periodid=="4")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 10, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="5")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 6))).ToList();
                                }
                                else if(periodid=="6")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 7, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="7")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 1, 1),
                                                                                                                                            new LocalDate(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12, DateTime.DaysInMonth(Int32.Parse(_lkupFiscalYearRepository.GetRecord(cyclerec.FiscalYear_Id).Record_Name), 12))).ToList();
                                }
                                else if(periodid=="8")
                                {
                                    CategoryRecs=_wpProcurementRepository.GetRecordsByMainRecordIdStartEndRange(mproject.Transaction_Id, cyclerec.PeriodStartDate, cyclerec.PeriodEndDate).ToList();
                                }

                                
                                foreach(var record in CategoryRecs)
                                {
                                    WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(record.WPMainRecord_id);

                                    WP_ProcurementGridVM srec = new WP_ProcurementGridVM
                                    {
                                        Transaction_IdGVM = record.Transaction_Id,
                                        WPMainRecord_idGVM = record.WPMainRecord_id,
                                        Project_IdGVM  = record.Project_Id,
                                        FiscalYear_IdGVM  = record.FiscalYear_Id,
                                        Period_IdGVM = record.Period_Id,
                                        WPOutput_IdGVM = record.WPOutput_Id,
                                        WPProcurement_DescriptionGVM = record.WPProcurement_Description,
                                        WPProcurementType_IdGVM = record.WPProcurementType_Id,
                                        WPProcurementType_NameGVM = _lkupProcurementTypeRepository.GetRecord(record.WPProcurementType_Id).Record_Name,
                                        WPProcurementLeadTime_IdGVM = record.WPProcurementLeadTime_Id,
                                        WPProcurementCostGVM = record.WPProcurementCost,
                                        WPProcurement_SourceOfFundsDescrGVM  = record.WPProcurement_SourceOfFundsDescr,
                                        Directorate_IdGVM = mainrec.Directorate_Id,
                                        Directorate_NameGVM = _strucDirectorateRepository.GetRecord(mainrec.Directorate_Id).AcronymName,
                                        Division_IdGVM =  mainrec.Division_Id,
                                        Division_NameGVM = _strucDivisionRepository.GetRecord(mainrec.Division_Id).Record_Name,
                                        Cycle_IdGVM = cycleid,
                                        InstitutionalSelectdedPeriodIdentGVM = periodid

                                    };
                                     collection_recs.Add(srec);

                                }

                            }

                        }


                    }

                }

                //Sorting
                collection_recs=collection_recs.OrderBy(d => d.Directorate_IdGVM).ThenBy(d => d.Division_IdGVM).ToList();
   


                
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }






        public ActionResult DivisionTransKPIs_Read ([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<DivisionKPIsViewModel> collection_recs = new List<DivisionKPIsViewModel>();

            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(Int32.Parse(recid)).Directorate_Id;

            var DB_RecsDivs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(Int32.Parse(recid),dirid).ToList();

            int _countDivs = DB_RecsDivs.Count();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                if(_countDivs>0)
                {
                    foreach (var div in DB_RecsDivs)
                    {
                        var DB_RecsIndicators = _transStrucDirDivIndicatorsRepository.GetAllRecordsByDivision(div.Division_Id).ToList();

                        int _countIndicators = DB_RecsIndicators.Count();
                        if (_countIndicators > 0)
                        {
                            foreach (var rec in DB_RecsIndicators)
                            {
                                DivisionKPIsViewModel srec = new DivisionKPIsViewModel
                                {
                                    
                                    Transaction_Id=rec.Transaction_Id,
                                    Record_Id = rec.Record_Id,
                                    Directorate_Ident=rec.Directorate_Id,
                                    Division_Ident=rec.Division_Id,
                                    Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                                    Record_Name=rec.Record_Name,
                                    Indicator_Type_Ident=rec.Indicator_Type_Id,
                                    Indicator_Type=rec.Indicator_Type,
                                    TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                                };

                                collection_recs.Add(srec);
                            }
                        }
                    }
                }
            }


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public ActionResult DivisionDeactivatedKPIs_Read ([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<DivisionKPIsViewModel> collection_recs = new List<DivisionKPIsViewModel>();

            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(Int32.Parse(recid)).Directorate_Id;

           var DB_RecsDivs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(Int32.Parse(recid),dirid).ToList();

            int _countDivs = DB_RecsDivs.Count();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                if(_countDivs>0)
                {
                    foreach (var div in DB_RecsDivs)
                    {
                        var DB_RecsIndicators = _strucDirDivIndicatorsRepository.GetAllDeactivatedRecordsByDivision(div.Division_Id).ToList();

                        int _countIndicators = DB_RecsIndicators.Count();
                        if (_countIndicators > 0)
                        {
                            foreach (var rec in DB_RecsIndicators)
                            {
                                DivisionKPIsViewModel srec = new DivisionKPIsViewModel
                                {
                                    
                                    Transaction_Id="",
                                    Record_Id = rec.Record_Id,
                                    Directorate_Ident=rec.Directorate_Id,
                                    Division_Ident=rec.Division_Id,
                                    Division_Name=_strucDivisionRepository.GetRecord(rec.Division_Id).Record_Name,
                                    Record_Name=rec.Record_Name,
                                    Indicator_Type_Ident=rec.Indicator_Type_Id,
                                    Indicator_Type=rec.Indicator_Type,
                                    TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                                };

                                collection_recs.Add(srec);
                            }
                        }
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
                            PeriodStart=new DateTime(rec.PeriodStartDate.Year,rec.PeriodStartDate.Month, rec.PeriodStartDate.Day),
                            PeriodEnd=new DateTime(rec.PeriodEndDate.Year,rec.PeriodEndDate.Month, rec.PeriodEndDate.Day),
                            WPStatus_String = rec.Dispatch_Status.HasValue? rec.Dispatch_Status.Value? "Current": "Closed": "Inactive",
                            WPSAPLinkView_String= rec.LinkToSAPExecution.HasValue? rec.LinkToSAPExecution.Value? "Linked": "Not Linked": "Not Linked",
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day)

                        };

                        collection_recs.Add(srec);
                    }
                }
            


            return Json(collection_recs.ToDataSourceResult(request));
        }

        public async Task<ActionResult>  CurrentInstitutionalWorkplan_Read([DataSourceRequest]DataSourceRequest request)
        {


            List<WorkplansViewModel> collection_recs = new List<WorkplansViewModel>();



                var DB_Recs = _wpDispatchCycleRepository.GetAllCurrentAndInactiveWPDispatch();
                var user = await userManager.GetUserAsync(HttpContext.User);
                string approvestring="";

                if (await userManager.IsInRoleAsync(user, "CEO"))
                {
                    approvestring="Approve";

                }
                else
                {
                    approvestring="Cannot Approve";
                }

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
                            PeriodStart=new DateTime(rec.PeriodStartDate.Year,rec.PeriodStartDate.Month, rec.PeriodStartDate.Day),
                            PeriodEnd=new DateTime(rec.PeriodEndDate.Year,rec.PeriodEndDate.Month, rec.PeriodEndDate.Day),
                            WPStatus_String = rec.Dispatch_Status.HasValue? rec.Dispatch_Status.Value? "Current": "Closed": "Inactive",
                            WPSAPLinkView_String= rec.LinkToSAPExecution.HasValue? rec.LinkToSAPExecution.Value? "Linked": "Not Linked": "Not Linked",
                            WPCEOApproveRole_String=approvestring,
                            TransactionDate = new DateTime(rec.TransactionDate.Year, rec.TransactionDate.Month, rec.TransactionDate.Day),
                            PeriodTypeSingle="View Report",
                            PeriodType = new CategoryViewModel()
                            {
                                CategoryID = 7,
                                CategoryName = "Annual"
                            },

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

        public async Task<ActionResult> StaffRoleMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {

                var usersOfRole = await userManager.GetUsersInRoleAsync(recid);

                int _count = usersOfRole.Count();
                if (_count > 0)
                {
                    foreach (var rec in usersOfRole)
                    {
                        Employee employee = _employeeRepository.GetEmployee(rec.Employee_Id);

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
                            EmployeeName = employee.First_Name + " " + employee.Last_Name,
                            Staff_Number = rec.Staff_Number,
                            profilepicpath = profilepicpath,
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


        public ActionResult ProjProgMapping_Read([DataSourceRequest]DataSourceRequest request, string recid)
        {


            List<EmployeeMappingViewModel> collection_recs = new List<EmployeeMappingViewModel>();

            if (recid != null)
            {
              //  AUDAProgramme prog = _programmeRepository.GetAUDAProgramme(Int32.Parse(programmeid));
                var DB_Recs = _transProjectRepository.GetAllRecordsByDivisionID(Int32.Parse(recid));

                int _count = DB_Recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in DB_Recs)
                    {
                        LkUp_Project project = _lkupProjectRepository.GetRecord(rec.MainProject_Id);
                        LkUp_Programme programme=_lkupProgrammeRepository.GetRecord(rec.MainProgramme_Id);

                        EmployeeMappingViewModel srec = new EmployeeMappingViewModel
                        {
                            ProjectTransaction_Id = rec.Transaction_Id,
                            ProgrammeTransaction_Id=rec.TransProgramme_Id,
                            Project_IdGM=rec.MainProject_Id,
                            Programme_IdGM=rec.MainProgramme_Id,
                            Project_Name=project.Record_Name,
                            Programme_Name=programme.Record_Name,
                            Directorate_IdGM=rec.Directorate_Id,
                            Division_IdGM=rec.Division_Id,
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
        public ActionResult MakeProcurementTypeTrans(string recid)
        {
            try
            {
                LkUp_ProcurementType rec = _lkupProcurementTypeRepository.GetRecord(Int32.Parse(recid));
                rec.Record_Status=true;
                _lkupProcurementTypeRepository.Update(rec);

                Trans_ProcurementType rec_trans = new Trans_ProcurementType
                {
                    Transaction_Id = Guid.NewGuid().ToString(),
                    Record_Id = rec.Record_Id,
                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                };
                _transProcurementTypeRepository.Add(rec_trans);

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
        public async Task<ActionResult> DeactivateDivisionKPI(string transid)
        {
             var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                Trans_StrucDirDivIndicators rec = _transStrucDirDivIndicatorsRepository.GetRecord(transid);


                if(rec!=null)
                {
                    Struc_DirDivIndicators mainrec=_strucDirDivIndicatorsRepository.GetRecord(rec.Record_Id);

                    mainrec.Record_Status=false;
                    _strucDirDivIndicatorsRepository.Update(mainrec);

                    _transStrucDirDivIndicatorsRepository.Delete(rec.Transaction_Id);

                }


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> ActivateDivisionKPI(string recordid)
        {
             var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {


                Struc_DirDivIndicators mainrec=_strucDirDivIndicatorsRepository.GetRecord(Int32.Parse(recordid));


                if(mainrec!=null)
                {

                    mainrec.Record_Status=true;
                    _strucDirDivIndicatorsRepository.Update(mainrec);

                    Trans_StrucDirDivIndicators rec_to_add_trans = new Trans_StrucDirDivIndicators
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        Record_Id=mainrec.Record_Id,
                        Directorate_Id= mainrec.Directorate_Id,
                        Division_Id= mainrec.Division_Id,
                        Record_Name=mainrec.Record_Name,
                        Indicator_Type_Id= mainrec.Indicator_Type_Id,
                        Indicator_Type=mainrec.Indicator_Type,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    _transStrucDirDivIndicatorsRepository.Add(rec_to_add_trans);

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
        public ActionResult WP_OutcomesSubIndicators_Delete(string subindicatorid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                WP_OutcomeIndicators rec=_wpOutcomeIndicatorsRepository.GetRecord(subindicatorid);
                
                if (rec != null)
                {
                    _wpOutcomeIndicatorsRepository.Delete(rec.Transaction_Id);

                } 


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult WP_OutputsSubActivity_Delete(string subactivityid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {
                WP_OutputActivities rec=_wpOutputActivitiesRepository.GetRecord(subactivityid);


                //Now Delete the record
                if (rec != null)
                {
                    _wpOutputActivitiesRepository.Delete(rec.Transaction_Id);

                } 

                //Delete Mobility Related Records

                //Delete Procurement Related Records

                //Delete Communication Related Records

                //Delete Risk Related Records


                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }


        [HttpPost]
        public ActionResult WP_OutputsSubMobility_Delete(string submobilityid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {

                //Delete Mobility Internal Staff Records
                var records_mobility_internal =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(submobilityid);
                foreach (var record in records_mobility_internal)
                {
                    _wpMobilityInternalTeamRepository.Delete(record.Transaction_Id);
                }

                //Delete Mobility Internal Staff Records
                var records_mobility_external=  _wpMobilityExternalTeamRepository.GetRecordsByMobilityId(submobilityid);
                foreach (var record in records_mobility_external)
                {
                    _wpMobilityExternalTeamRepository.Delete(record.Transaction_Id);
                }

                //Now Delete Mobility record
                WP_Mobility rec_mobility=_wpMobilityRepository.GetRecord(submobilityid);
                
                if (rec_mobility != null)
                {
                    _wpMobilityRepository.Delete(rec_mobility.Transaction_Id);

                } 



                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }


        [HttpPost]
        public ActionResult WP_OutputsSubRiskProfile_Delete(string subriskprofileid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {

                //Delete Risk Profile Countries
                var _records =  _wpRiskProfileCountriesRepository.GetRecordsByRiskId(subriskprofileid);
                foreach (var record in _records)
                {
                    _wpRiskProfileCountriesRepository.Delete(record.Transaction_Id);
                }

        

                //Now Delete Risk Profile record
                WP_RiskProfile _rec=_wpRiskProfileRepository.GetRecord(subriskprofileid);
                
                if (_rec != null)
                {
                    _wpRiskProfileRepository.Delete(_rec.Transaction_Id);

                } 



                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult WP_OutputsSubProcurement_Delete(string subrecid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {

                //Now Delete Mobility record
                WP_Procurement rec_set=_wpProcurementRepository.GetRecord(subrecid);
                
                if (rec_set != null)
                {
                    _wpProcurementRepository.Delete(rec_set.Transaction_Id);

                } 



                 return Json(new { rtnmsg = "success" });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
            }
        }

        [HttpPost]
        public ActionResult WP_OutputsSubCommunication_Delete(string subrecid)
        {
            // var user = await userManager.GetUserAsync(HttpContext.User);
            try
            {

                //Now Delete Mobility record
                WP_Communication rec_set=_wpCommunicationRepository.GetRecord(subrecid);
                
                if (rec_set != null)
                {
                    _wpCommunicationRepository.Delete(rec_set.Transaction_Id);

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
        public ActionResult AddStrategicIndicator(WP_OutcomeOutputIndicatorsVM model)
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
                            IndicatorCategory="Institutional-Level",
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
        public ActionResult AddDirectorateIndicator(WP_OutcomeOutputIndicatorsVM model)
        {
            
            WP_OutputIndicators rec = _wpOutputIndicatorsRepository.GetRecordByProjectYearAndPeriodOutputIdIndicatorId_Dir(model.Project_IdOIVM, model.FiscalYear_IdOIVM, model.Period_IdOIVM, model.Transaction_IdOIVM, model.IndicatorIDOIVM_Dir);

            
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
                            IndicatorCategory="Directorate-Level",
                            IndicatorType=_strucDirDivIndicatorsRepository.GetRecord(model.IndicatorIDOIVM_Dir).Indicator_Type,
                            OutputIndicator_Id=model.IndicatorIDOIVM_Dir,
                            Priority_Id=model.Priority_IdOIVM,
                            Employee_Id= model.Employee_IdOIVM,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        if(_strucDirDivIndicatorsRepository.GetRecord(model.IndicatorIDOIVM_Dir).Indicator_Type=="Quantitative")
                        {
                            rec_to_add.BaselineQuantitative=model.BaselineQuantitativeOIVM_Dir;
                            rec_to_add.TargetQuantitative=model.TargetQuantitativeOIVM_Dir;
                        } 
                        else
                        {
                            rec_to_add.BaselineQuanlitative=model.BaselineQuanlitativeOIVM_Dir;
                            rec_to_add.TargetQuanlitative=model.TargetQuanlitativeOIVM_Dir;

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
        public ActionResult AddOutputActivityNew(WP_OutputActivitiesVM model)
        {
            
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                //WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.Transaction_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.Transaction_IdOAVMMain);

                if(recoutputrecord.WPSAPLink_Id==null )
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
                        PartnerFunding=model.PartnerFundingOAVMMain,
                        PartnerFundingDescr=model.PartnerFundingDescrOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpOutputActivitiesRepository.Add(rec_to_add_1);

                }
                else 
                {
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(recoutputrecord.WPSAPLink_Id);
                   // var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                    var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(recoutputrecord.WPSAPLink_Id);
                    double total_utilization=0;
                    double totalremainingsapbudget=0;
                    foreach (var record in DB_Recs_Activities_Linked_SAP)
                    {
                        total_utilization=total_utilization+record.ActivityCost;

                    }
                    totalremainingsapbudget=saplinkrec.SAP_BudgetAmount-total_utilization;

                    if(totalremainingsapbudget>=model.ActivityCostOAVMMain)
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
                            WPSAPLink_Id=recoutputrecord.WPSAPLink_Id,
                            PartnerFunding=model.PartnerFundingOAVMMain,
                            PartnerFundingDescr=model.PartnerFundingDescrOAVMMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _wpOutputActivitiesRepository.Add(rec_to_add_2);

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
        public ActionResult AddOutputActivityGanttNew(WP_OutputActivitiesVM model)
        {
            
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
           // WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOAVMMain);

                if(recoutputrecord.WPSAPLink_Id==null )
                {
                    WP_OutputActivities rec_to_add_1 = new WP_OutputActivities
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.WPOutput_IdOAVMMain,
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
                        PartnerFunding=model.PartnerFundingOAVMMain,
                        PartnerFundingDescr=model.PartnerFundingDescrOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpOutputActivitiesRepository.Add(rec_to_add_1);

                }
                else 
                {
                    WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(recoutputrecord.WPSAPLink_Id);
                   // var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                    var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(recoutputrecord.WPSAPLink_Id);
                    double total_utilization=0;
                    double totalremainingsapbudget=0;
                    foreach (var record in DB_Recs_Activities_Linked_SAP)
                    {
                        total_utilization=total_utilization+record.ActivityCost;

                    }
                    totalremainingsapbudget=saplinkrec.SAP_BudgetAmount-total_utilization;

                    if(totalremainingsapbudget>=model.ActivityCostOAVMMain)
                    {
                        WP_OutputActivities rec_to_add_2 = new WP_OutputActivities
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                            WPOutput_Id=model.WPOutput_IdOAVMMain,
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
                            WPSAPLink_Id=recoutputrecord.WPSAPLink_Id,
                            PartnerFunding=model.PartnerFundingOAVMMain,
                            PartnerFundingDescr=model.PartnerFundingDescrOAVMMain,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };

                        _wpOutputActivitiesRepository.Add(rec_to_add_2);

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
        public ActionResult AddOutputMobilityNew(WP_OutputMobilityVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.Transaction_IdOMVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOMVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.Transaction_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.Transaction_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.Transaction_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.Transaction_IdOMVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.MobilityCostOMVMMain)
                {
                    WP_Mobility rec_to_add_2 = new WP_Mobility
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOMVMMain,
                        Project_Id=model.Project_IdOMVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOMVMMain,
                        Period_Id=model.Period_IdOMVMMain,
                        WPOutput_Id=model.Transaction_IdOMVMMain,
                        WPMobility_Description=model.WPMobility_DescriptionOMVMMain,
                        Country_Id=model.Country_IdOMVMMain,
                        WPMobility_City=model.Mobility_CityOMVMMain,
                        MobilityStartDate=new LocalDate(model.MobilityStartDateOMVMMain.Year, model.MobilityStartDateOMVMMain.Month,model.MobilityStartDateOMVMMain.Day),
                        MobilityEndDate=new LocalDate(model.MobilityEndDateOMVMMain.Year, model.MobilityEndDateOMVMMain.Month,model.MobilityEndDateOMVMMain.Day),
                        MobilityCost=model.MobilityCostOMVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpMobilityRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }



        [HttpPost]
        public ActionResult AddOutputProcurementNew(WP_OutputProcurementVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.Transaction_IdOPVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOPVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               //double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.Transaction_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.Transaction_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.Transaction_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.Transaction_IdOPVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.ProcurementCostOPVMMain)
                {
                    WP_Procurement rec_to_add_2 = new WP_Procurement
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOPVMMain,
                        Project_Id=model.Project_IdOPVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOPVMMain,
                        Period_Id=model.Period_IdOPVMMain,
                        WPOutput_Id=model.Transaction_IdOPVMMain,
                        WPProcurement_Description=model.WPProcurement_DescriptionOPVMMain,
                        WPProcurementType_Id=model.WPProcurementType_IdOPVMMain,
                        WPProcurementLeadTime_Id=model.WPProcurementLeadTime_IdOPVMMain,
                        WPProcurement_AdditionalNotes=model.WPProcurement_AdditionalNotesOPVMMain,
                        WPProcurementStartDate=new LocalDate(model.ProcurementStartDateOPVMMain.Year, model.ProcurementStartDateOPVMMain.Month,model.ProcurementStartDateOPVMMain.Day),
                        WPProcurementEndDate=new LocalDate(model.ProcurementEndDateOPVMMain.Year, model.ProcurementEndDateOPVMMain.Month,model.ProcurementEndDateOPVMMain.Day),
                        WPTORSubmissionDate=new LocalDate(model.WPTORSubmissionDateOPVMMain.Year, model.WPTORSubmissionDateOPVMMain.Month,model.WPTORSubmissionDateOPVMMain.Day),
                        WPContractStartDate=new LocalDate(model.WPContractStartDateOPVMMain.Year, model.WPContractStartDateOPVMMain.Month,model.WPContractStartDateOPVMMain.Day),
                        WPProcurementCost=model.ProcurementCostOPVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpProcurementRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }

        [HttpPost]
        public ActionResult AddOutputCommunicationNew(WP_OutputCommunicationVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.Transaction_IdOCVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOCVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.Transaction_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.Transaction_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.Transaction_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.Transaction_IdOCVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.WPCommsCostOCVMMain)
                {
                    WP_Communication rec_to_add_2 = new WP_Communication
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOCVMMain,
                        Project_Id=model.Project_IdOCVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOCVMMain,
                        Period_Id=model.Period_IdOCVMMain,
                        WPOutput_Id=model.Transaction_IdOCVMMain,
                        WPComms_Description=model.WPComms_DescriptionOCVMMain,
                        WPCommsChannel_Id=model.WPCommsChannel_IdOCVMMain,
                        WPComms_AdditionalNotes=model.WPComms_AdditionalNotesOCVMMain,
                        WPCommsStartDate=new LocalDate(model.WPCommsStartDateOCVMMain.Year, model.WPCommsStartDateOCVMMain.Month,model.WPCommsStartDateOCVMMain.Day),
                        WPCommsEndDate=new LocalDate(model.WPCommsEndDateOCVMMain.Year, model.WPCommsEndDateOCVMMain.Month,model.WPCommsEndDateOCVMMain.Day),
                        WPCommsCost=model.WPCommsCostOCVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpCommunicationRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }





        [HttpPost]
        public ActionResult AddOutputRiskProfileNew(WP_OutputRiskProfileVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.Transaction_IdORVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdORVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.Transaction_IdORVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.Transaction_IdORVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.Transaction_IdORVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.Transaction_IdORVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                //if(totalremainingbudget>=model.WPRiskCostORVMMain)
                //{
                    WP_RiskProfile rec_to_add_2 = new WP_RiskProfile
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idORVMMain,
                        Project_Id=model.Project_IdORVMMain,
                        FiscalYear_Id=model.FiscalYear_IdORVMMain,
                        Period_Id=model.Period_IdORVMMain,
                        WPOutput_Id=model.Transaction_IdORVMMain,
                        WPRisk_Description=model.WPRisk_DescriptionORVMMain,
                        WPRiskImpactLevel_Id=model.WPRiskImpactLevel_IdORVMMain,
                        WPRiskProbability_Id=model.WPRiskProbability_IdORVMMain,
                        WPFrequencyOfReporting_Id=model.WPFrequencyOfReporting_IdORVMMain,
                        WPCategory_Id=model.WPCategory_IdORVMMain,
                        WPRiskCost=model.WPRiskCostORVMMain,
                        WPRiskOwner_Id=model.WPRiskOwner_IdORVMMain,
                        WPRiskChampion_Id=model.WPRiskChampion_IdORVMMain,
                        WPRisk_MitigationMeasures=model.WPRisk_MitigationMeasuresORVMMain,
                        WPRisk_AdditionalNotes=model.WPRisk_AdditionalNotesORVMMain,
    
                      
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpRiskProfileRepository.Add(rec_to_add_2);

                // }
                // else
                // {
                //     return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                // }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }





        [HttpPost]
        public ActionResult AddOutputProcurementGanttNew(WP_OutputProcurementVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOPVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.ProcurementCostOPVMMain)
                {
                    WP_Procurement rec_to_add_2 = new WP_Procurement
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOPVMMain,
                        Project_Id=model.Project_IdOPVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOPVMMain,
                        Period_Id=model.Period_IdOPVMMain,
                        WPOutput_Id=model.WPOutput_IdOPVMMain,
                        WPProcurement_Description=model.WPProcurement_DescriptionOPVMMain,
                        WPProcurementType_Id=model.WPProcurementType_IdOPVMMain,
                        WPProcurementLeadTime_Id=model.WPProcurementLeadTime_IdOPVMMain,
                        WPProcurement_AdditionalNotes=model.WPProcurement_AdditionalNotesOPVMMain,
                        WPProcurementStartDate=new LocalDate(model.ProcurementStartDateOPVMMain.Year, model.ProcurementStartDateOPVMMain.Month,model.ProcurementStartDateOPVMMain.Day),
                        WPProcurementEndDate=new LocalDate(model.ProcurementEndDateOPVMMain.Year, model.ProcurementEndDateOPVMMain.Month,model.ProcurementEndDateOPVMMain.Day),
                        WPTORSubmissionDate=new LocalDate(model.WPTORSubmissionDateOPVMMain.Year, model.WPTORSubmissionDateOPVMMain.Month,model.WPTORSubmissionDateOPVMMain.Day),
                        WPContractStartDate=new LocalDate(model.WPContractStartDateOPVMMain.Year, model.WPContractStartDateOPVMMain.Month,model.WPContractStartDateOPVMMain.Day),
                        WPProcurementCost=model.ProcurementCostOPVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpProcurementRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }




        [HttpPost]
        public ActionResult AddOutputCommunicationGanttNew(WP_OutputCommunicationVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOCVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.WPCommsCostOCVMMain)
                {
                    WP_Communication rec_to_add_2 = new WP_Communication
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOCVMMain,
                        Project_Id=model.Project_IdOCVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOCVMMain,
                        Period_Id=model.Period_IdOCVMMain,
                        WPOutput_Id=model.WPOutput_IdOCVMMain,
                        WPComms_Description=model.WPComms_DescriptionOCVMMain,
                        WPCommsChannel_Id=model.WPCommsChannel_IdOCVMMain,
                        WPComms_AdditionalNotes=model.WPComms_AdditionalNotesOCVMMain,
                        WPCommsStartDate=new LocalDate(model.WPCommsStartDateOCVMMain.Year, model.WPCommsStartDateOCVMMain.Month,model.WPCommsStartDateOCVMMain.Day),
                        WPCommsEndDate=new LocalDate(model.WPCommsEndDateOCVMMain.Year, model.WPCommsEndDateOCVMMain.Month,model.WPCommsEndDateOCVMMain.Day),
                        WPCommsCost=model.WPCommsCostOCVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpCommunicationRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }






        [HttpPost]
        public ActionResult AddOutputMobilityGanttNew(WP_OutputMobilityVMWindow model)
        {
            double totalremainingbudget=0;

            try
            {
                                  
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOMVMMain);

                //Get the total budget for the output
                var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain);
                double total_outputbudget=0;
                foreach (var record in DB_Recs_Activities)
                {
                    total_outputbudget=total_outputbudget+record.ActivityCost;
                }

                //Get all mission, procurement, communication and risk costs already captured against this output 
                double total_missionbudget=0;
                double total_procurementbudget=0;
                double total_commsbudget=0;
               // double total_riskbudget=0;
                

                var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Missions)
                {
                    total_missionbudget=total_missionbudget+record.MobilityCost;
                }

                //foreach loop for procurment
                var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Procurement)
                {
                    total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                }
                //foreach loop for comms
                var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                foreach (var record in DB_Recs_Comms)
                {
                    total_commsbudget=total_commsbudget+record.WPCommsCost;
                }

                //foreach loop for risk
                // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                // foreach (var record in DB_Recs_Risk)
                // {
                //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                // }

                totalremainingbudget=total_outputbudget-(total_missionbudget+total_procurementbudget+total_commsbudget);
    

                if(totalremainingbudget>=model.MobilityCostOMVMMain)
                {
                    WP_Mobility rec_to_add_2 = new WP_Mobility
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        WPMainRecord_id=model.WPMainRecord_idOMVMMain,
                        Project_Id=model.Project_IdOMVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOMVMMain,
                        Period_Id=model.Period_IdOMVMMain,
                        WPOutput_Id=model.WPOutput_IdOMVMMain,
                        WPMobility_Description=model.WPMobility_DescriptionOMVMMain,
                        Country_Id=model.Country_IdOMVMMain,
                        WPMobility_City=model.Mobility_CityOMVMMain,
                        MobilityStartDate=new LocalDate(model.MobilityStartDateOMVMMain.Year, model.MobilityStartDateOMVMMain.Month,model.MobilityStartDateOMVMMain.Day),
                        MobilityEndDate=new LocalDate(model.MobilityEndDateOMVMMain.Year, model.MobilityEndDateOMVMMain.Month,model.MobilityEndDateOMVMMain.Day),
                        MobilityCost=model.MobilityCostOMVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };

                    _wpMobilityRepository.Add(rec_to_add_2);

                }
                else
                {
                    return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                }
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }
             




        }




        [HttpPost]
        public ActionResult AddOutputActivityGantt(WP_OutputActivitiesVM model)
        {
            
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);

                if(recbudget==null)
                {
                    WP_OutputActivities rec_to_add_1 = new WP_OutputActivities
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.WPOutput_IdOAVMMain,
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
                        WPOutput_Id=model.WPOutput_IdOAVMMain,
                        Project_Id=model.Project_IdOAVMMain,
                        FiscalYear_Id=model.FiscalYear_IdOAVMMain,
                        Period_Id=model.Period_IdOAVMMain,
                        Output_BudgetAmount=model.ActivityCostOAVMMain,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)

                    };
                    _wpOutputBudgetRepository.Add(recbudget_to_add_1);

                    var DB_Recs_1 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOAVMMain);
                    double totalcost_1=0;
                    foreach (var record in DB_Recs_1)
                    {
                        totalcost_1=totalcost_1+record.ActivityCost;

                    }
                    
                    WP_OutputBudget recbudget_1=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                    
                    recbudget_1.Output_BudgetAmount=totalcost_1;
                    _wpOutputBudgetRepository.Update(recbudget_1);

                }
                else if (recbudget.WPSAPLink_Id==null)
                {
                    WP_OutputActivities rec_to_add_2 = new WP_OutputActivities
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOAVMMain,
                        WPOutput_Id=model.WPOutput_IdOAVMMain,
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


                    var DB_Recs_2 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOAVMMain);
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
                            WPOutput_Id=model.WPOutput_IdOAVMMain,
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

                        var DB_Recs_3 =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOAVMMain);
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
        public ActionResult EditOutputActivity(WP_OutputActivitiesVM model)
        {
            
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_OutputActivities rec_activity=_wpOutputActivitiesRepository.GetRecord(model.Transaction_IdOAVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOAVMMain);

                if(rec_activity!=null)
                {
                    if (recoutputrecord.WPSAPLink_Id==null)
                    {

                            
                        rec_activity.WPMainRecord_id= model.WPMainRecord_idOAVMMain;
                        rec_activity.WPOutput_Id=model.WPOutput_IdOAVMMain;
                        rec_activity.Project_Id=model.Project_IdOAVMMain;
                        rec_activity.FiscalYear_Id=model.FiscalYear_IdOAVMMain;
                        rec_activity.Period_Id=model.Period_IdOAVMMain;
                        rec_activity.ActivityType_Id=model.ActivityType_IdOAVMMain;
                        rec_activity.ActivityDescription=model.ActivityDescriptionOAVMMain;
                        rec_activity.ActivityCost=model.ActivityCostOAVMMain;
                        rec_activity.ActivityStartDate=new LocalDate(model.ActivityStartDateOAVMMain.Year, model.ActivityStartDateOAVMMain.Month, model.ActivityStartDateOAVMMain.Day);
                        rec_activity.ActivityEndDate=new LocalDate(model.ActivityEndDateOAVMMain.Year, model.ActivityEndDateOAVMMain.Month, model.ActivityEndDateOAVMMain.Day);
                        rec_activity.ImplementationType_Id=model.ImplementationType_IdOAVMMain;
                        rec_activity.BaselineTechnical=model.BaselineTechnicalOAVMMain;
                        rec_activity.BaselineFinancial=model.BaselineFinancialOAVMMain;
                        rec_activity.Employee_Id= model.Employee_IdOAVMMain;
                        rec_activity.PartnerFunding=model.PartnerFundingOAVMMain;
                        rec_activity.PartnerFundingDescr=model.PartnerFundingDescrOAVMMain;
                        rec_activity.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                      
                        _wpOutputActivitiesRepository.Update(rec_activity);

                    }
                    else
                    {

                        WP_SAPLink saplinkrec = _wpSAPLinkRepository.GetRecord(recoutputrecord.WPSAPLink_Id);
                        // var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.Transaction_IdOAVMMain);
                        var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(recoutputrecord.WPSAPLink_Id);
                        double total_utilization=0;
                        double totalremainingsapbudget=0;
                        foreach (var record in DB_Recs_Activities_Linked_SAP)
                        {
                            total_utilization=total_utilization+record.ActivityCost;

                        }
                        totalremainingsapbudget=saplinkrec.SAP_BudgetAmount-total_utilization;

                    

                        if(totalremainingsapbudget>=model.ActivityCostOAVMMain)
                        {
                            rec_activity.WPMainRecord_id= model.WPMainRecord_idOAVMMain;
                            rec_activity.WPOutput_Id=model.WPOutput_IdOAVMMain;
                            rec_activity.Project_Id=model.Project_IdOAVMMain;
                            rec_activity.FiscalYear_Id=model.FiscalYear_IdOAVMMain;
                            rec_activity.Period_Id=model.Period_IdOAVMMain;
                            rec_activity.ActivityType_Id=model.ActivityType_IdOAVMMain;
                            rec_activity.ActivityDescription=model.ActivityDescriptionOAVMMain;
                            rec_activity.ActivityCost=model.ActivityCostOAVMMain;
                            rec_activity.ActivityStartDate=new LocalDate(model.ActivityStartDateOAVMMain.Year, model.ActivityStartDateOAVMMain.Month, model.ActivityStartDateOAVMMain.Day);
                            rec_activity.ActivityEndDate=new LocalDate(model.ActivityEndDateOAVMMain.Year, model.ActivityEndDateOAVMMain.Month, model.ActivityEndDateOAVMMain.Day);
                            rec_activity.ImplementationType_Id=model.ImplementationType_IdOAVMMain;
                            rec_activity.BaselineTechnical=model.BaselineTechnicalOAVMMain;
                            rec_activity.BaselineFinancial=model.BaselineFinancialOAVMMain;
                            rec_activity.Employee_Id= model.Employee_IdOAVMMain;
                            rec_activity.PartnerFunding=model.PartnerFundingOAVMMain;
                            rec_activity.PartnerFundingDescr=model.PartnerFundingDescrOAVMMain;
                            rec_activity.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                        
                            _wpOutputActivitiesRepository.Update(rec_activity);

                        }
                        else
                        {
                            return Json(new { rtnmsg = "insufficientsapfunds" });

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
        public ActionResult EditOutputMobility(WP_OutputMobilityVMWindow model)
        {
            double totalremainingbudget=0;
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_Mobility rec_mobility=_wpMobilityRepository.GetRecord(model.Transaction_IdOMVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOMVMMain);

                if(rec_mobility!=null)
                {
 

                    //Get the total budget for the output
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain);
                    double total_outputbudget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_outputbudget=total_outputbudget+record.ActivityCost;
                    }

                    //Get all mission, procurement, communication and risk costs already captured against this output 
                    double total_missionbudget=0;
                    double total_procurementbudget=0;
                    double total_commsbudget=0;
                  //  double total_riskbudget=0;
                    

                    var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain);
                    foreach (var record in DB_Recs_Missions)
                    {
                        total_missionbudget=total_missionbudget+record.MobilityCost;
                    }

                    //foreach loop for procurment
                    var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                    foreach (var record in DB_Recs_Procurement)
                    {
                        total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                    }
                    //foreach loop for comms
                    var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                    foreach (var record in DB_Recs_Comms)
                    {
                        total_commsbudget=total_commsbudget+record.WPCommsCost;
                    }

                    //foreach loop for risk
                    // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOMVMMain).ToList();
                    // foreach (var record in DB_Recs_Risk)
                    // {
                    //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                    // }


                    totalremainingbudget=(total_outputbudget+rec_mobility.MobilityCost)-(total_missionbudget+total_procurementbudget+total_commsbudget);

                

                    if(totalremainingbudget>=model.MobilityCostOMVMMain)
                    {

                        rec_mobility.WPMainRecord_id=model.WPMainRecord_idOMVMMain;
                        rec_mobility.Project_Id=model.Project_IdOMVMMain;
                        rec_mobility.FiscalYear_Id=model.FiscalYear_IdOMVMMain;
                        rec_mobility.Period_Id=model.Period_IdOMVMMain;
                        rec_mobility.WPOutput_Id=model.WPOutput_IdOMVMMain;
                        rec_mobility.WPMobility_Description=model.WPMobility_DescriptionOMVMMain;
                        rec_mobility.Country_Id=model.Country_IdOMVMMain;
                        rec_mobility.WPMobility_City=model.Mobility_CityOMVMMain;
                        rec_mobility.MobilityStartDate=new LocalDate(model.MobilityStartDateOMVMMain.Year, model.MobilityStartDateOMVMMain.Month,model.MobilityStartDateOMVMMain.Day);
                        rec_mobility.MobilityEndDate=new LocalDate(model.MobilityEndDateOMVMMain.Year, model.MobilityEndDateOMVMMain.Month,model.MobilityEndDateOMVMMain.Day);
                        rec_mobility.MobilityCost=model.MobilityCostOMVMMain;
                        rec_mobility.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    
                        _wpMobilityRepository.Update(rec_mobility);

                    }
                    else
                    {
                        return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                    }

                    

                }
              
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }

        }




        [HttpPost]
        public ActionResult EditOutputProcurement(WP_OutputProcurementVMWindow model)
        {
            double totalremainingbudget=0;
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_Procurement rec_set=_wpProcurementRepository.GetRecord(model.Transaction_IdOPVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOPVMMain);

                if(rec_set!=null)
                {
 

                    //Get the total budget for the output
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain);
                    double total_outputbudget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_outputbudget=total_outputbudget+record.ActivityCost;
                    }

                    //Get all mission, procurement, communication and risk costs already captured against this output 
                    double total_missionbudget=0;
                    double total_procurementbudget=0;
                    double total_commsbudget=0;
                    //double total_riskbudget=0;
                    

                    var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain);
                    foreach (var record in DB_Recs_Missions)
                    {
                        total_missionbudget=total_missionbudget+record.MobilityCost;
                    }

                    //foreach loop for procurment
                    var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    foreach (var record in DB_Recs_Procurement)
                    {
                        total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                    }
                    //foreach loop for comms
                    var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    foreach (var record in DB_Recs_Comms)
                    {
                        total_commsbudget=total_commsbudget+record.WPCommsCost;
                    }

                    //foreach loop for risk
                    // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    // foreach (var record in DB_Recs_Risk)
                    // {
                    //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                    // }


                    totalremainingbudget=(total_outputbudget+rec_set.WPProcurementCost)-(total_missionbudget+total_procurementbudget+total_commsbudget);

                

                    if(totalremainingbudget>=model.ProcurementCostOPVMMain)
                    {

                        rec_set.WPMainRecord_id=model.WPMainRecord_idOPVMMain;
                        rec_set.Project_Id=model.Project_IdOPVMMain;
                        rec_set.FiscalYear_Id=model.FiscalYear_IdOPVMMain;
                        rec_set.Period_Id=model.Period_IdOPVMMain;
                        rec_set.WPOutput_Id=model.WPOutput_IdOPVMMain;
                        rec_set.WPProcurement_Description=model.WPProcurement_DescriptionOPVMMain;
                        rec_set.WPProcurementType_Id=model.WPProcurementType_IdOPVMMain;
                        rec_set.WPProcurementLeadTime_Id=model.WPProcurementLeadTime_IdOPVMMain;
                        rec_set.WPProcurement_AdditionalNotes=model.WPProcurement_AdditionalNotesOPVMMain;
                        rec_set.WPProcurementStartDate=new LocalDate(model.ProcurementStartDateOPVMMain.Year, model.ProcurementStartDateOPVMMain.Month,model.ProcurementStartDateOPVMMain.Day);
                        rec_set.WPProcurementEndDate=new LocalDate(model.ProcurementEndDateOPVMMain.Year, model.ProcurementEndDateOPVMMain.Month,model.ProcurementEndDateOPVMMain.Day);
                        rec_set.WPTORSubmissionDate=new LocalDate(model.WPTORSubmissionDateOPVMMain.Year, model.WPTORSubmissionDateOPVMMain.Month,model.WPTORSubmissionDateOPVMMain.Day);
                        rec_set.WPContractStartDate=new LocalDate(model.WPContractStartDateOPVMMain.Year, model.WPContractStartDateOPVMMain.Month,model.WPContractStartDateOPVMMain.Day);
                        rec_set.WPProcurementCost=model.ProcurementCostOPVMMain;
                        rec_set.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    
                        _wpProcurementRepository.Update(rec_set);

                    }
                    else
                    {
                        return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                    }

                    

                }
              
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }

        }

        [HttpPost]
        public ActionResult EditOutputProcurementInst(WP_OutputProcurementVMWindow model)
        {
            double totalremainingbudget=0;
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_Procurement rec_set=_wpProcurementRepository.GetRecord(model.Transaction_IdOPVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOPVMMain);

                if(rec_set!=null)
                {
 

                    //Get the total budget for the output
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain);
                    double total_outputbudget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_outputbudget=total_outputbudget+record.ActivityCost;
                    }

                    //Get all mission, procurement, communication and risk costs already captured against this output 
                    double total_missionbudget=0;
                    double total_procurementbudget=0;
                    double total_commsbudget=0;
                    //double total_riskbudget=0;
                    

                    var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain);
                    foreach (var record in DB_Recs_Missions)
                    {
                        total_missionbudget=total_missionbudget+record.MobilityCost;
                    }

                    //foreach loop for procurment
                    var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    foreach (var record in DB_Recs_Procurement)
                    {
                        total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                    }
                    //foreach loop for comms
                    var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    foreach (var record in DB_Recs_Comms)
                    {
                        total_commsbudget=total_commsbudget+record.WPCommsCost;
                    }

                    //foreach loop for risk
                    // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOPVMMain).ToList();
                    // foreach (var record in DB_Recs_Risk)
                    // {
                    //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                    // }


                    totalremainingbudget=(total_outputbudget+rec_set.WPProcurementCost)-(total_missionbudget+total_procurementbudget+total_commsbudget);

                

                    if(totalremainingbudget>=model.ProcurementCostOPVMMain)
                    {

                        rec_set.WPMainRecord_id=model.WPMainRecord_idOPVMMain;
                        rec_set.Project_Id=model.Project_IdOPVMMain;
                        rec_set.FiscalYear_Id=model.FiscalYear_IdOPVMMain;
                        rec_set.Period_Id=model.Period_IdOPVMMain;
                        rec_set.WPOutput_Id=model.WPOutput_IdOPVMMain;
                        rec_set.WPProcurement_Description=model.WPProcurement_DescriptionOPVMMain;
                        rec_set.WPProcurementType_Id=model.WPProcurementType_IdOPVMMain;
                        rec_set.WPProcurementLeadTime_Id=model.WPProcurementLeadTime_IdOPVMMain;
                        rec_set.WPProcurement_AdditionalNotes=model.WPProcurement_AdditionalNotesOPVMMain;
                        rec_set.WPProcurement_SourceOfFundsDescr=model.WPProcurement_SourceOfFundsDescrOPVMMain;
                        rec_set.WPProcurementStartDate=new LocalDate(model.ProcurementStartDateOPVMMain.Year, model.ProcurementStartDateOPVMMain.Month,model.ProcurementStartDateOPVMMain.Day);
                        rec_set.WPProcurementEndDate=new LocalDate(model.ProcurementEndDateOPVMMain.Year, model.ProcurementEndDateOPVMMain.Month,model.ProcurementEndDateOPVMMain.Day);
                        rec_set.WPTORSubmissionDate=new LocalDate(model.WPTORSubmissionDateOPVMMain.Year, model.WPTORSubmissionDateOPVMMain.Month,model.WPTORSubmissionDateOPVMMain.Day);
                        rec_set.WPContractStartDate=new LocalDate(model.WPContractStartDateOPVMMain.Year, model.WPContractStartDateOPVMMain.Month,model.WPContractStartDateOPVMMain.Day);
                        rec_set.WPProcurementCost=model.ProcurementCostOPVMMain;
                        rec_set.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    
                        _wpProcurementRepository.Update(rec_set);

                    }
                    else
                    {
                        return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                    }

                    

                }
              
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }

        }

        [HttpPost]
        public ActionResult EditOutputCommunication(WP_OutputCommunicationVMWindow model)
        {
            double totalremainingbudget=0;
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_Communication rec_set=_wpCommunicationRepository.GetRecord(model.Transaction_IdOCVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdOCVMMain);

                if(rec_set!=null)
                {
 

                    //Get the total budget for the output
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain);
                    double total_outputbudget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_outputbudget=total_outputbudget+record.ActivityCost;
                    }

                    //Get all mission, procurement, communication and risk costs already captured against this output 
                    double total_missionbudget=0;
                    double total_procurementbudget=0;
                    double total_commsbudget=0;
                   // double total_riskbudget=0;
                    

                    var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain);
                    foreach (var record in DB_Recs_Missions)
                    {
                        total_missionbudget=total_missionbudget+record.MobilityCost;
                    }

                    //foreach loop for procurment
                    var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                    foreach (var record in DB_Recs_Procurement)
                    {
                        total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                    }
                    //foreach loop for comms
                    var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                    foreach (var record in DB_Recs_Comms)
                    {
                        total_commsbudget=total_commsbudget+record.WPCommsCost;
                    }

                    //foreach loop for risk
                    // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdOCVMMain).ToList();
                    // foreach (var record in DB_Recs_Risk)
                    // {
                    //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                    // }


                    totalremainingbudget=(total_outputbudget+rec_set.WPCommsCost)-(total_missionbudget+total_procurementbudget+total_commsbudget);

                

                    if(totalremainingbudget>=model.WPCommsCostOCVMMain)
                    {

                        rec_set.WPMainRecord_id=model.WPMainRecord_idOCVMMain;
                        rec_set.Project_Id=model.Project_IdOCVMMain;
                        rec_set.FiscalYear_Id=model.FiscalYear_IdOCVMMain;
                        rec_set.Period_Id=model.Period_IdOCVMMain;
                        rec_set.WPOutput_Id=model.WPOutput_IdOCVMMain;
                        rec_set.WPComms_Description=model.WPComms_DescriptionOCVMMain;
                        rec_set.WPCommsChannel_Id=model.WPCommsChannel_IdOCVMMain;
                        rec_set.WPComms_AdditionalNotes=model.WPComms_AdditionalNotesOCVMMain;
                        rec_set.WPCommsStartDate=new LocalDate(model.WPCommsStartDateOCVMMain.Year, model.WPCommsStartDateOCVMMain.Month,model.WPCommsStartDateOCVMMain.Day);
                        rec_set.WPCommsEndDate=new LocalDate(model.WPCommsEndDateOCVMMain.Year, model.WPCommsEndDateOCVMMain.Month,model.WPCommsEndDateOCVMMain.Day);
                        rec_set.WPCommsCost=model.WPCommsCostOCVMMain;
                        rec_set.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    
                        _wpCommunicationRepository.Update(rec_set);

                    }
                    else
                    {
                        return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                    }

                    

                }
              
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }

        }


        [HttpPost]
        public ActionResult EditOutputRiskProfile(WP_OutputRiskProfileVMWindow model)
        {
            double totalremainingbudget=0;
            try
            {
                                  

                //Check SAP Link Details and Update Total Budget
                
                WP_RiskProfile rec_set=_wpRiskProfileRepository.GetRecord(model.Transaction_IdORVMMain);
            //    WP_OutputBudget recbudget=_wpOutputBudgetRepository.GetRecordsByProjectYearPeriodAndOutputId(model.Project_IdOAVMMain, model.FiscalYear_IdOAVMMain, model.Period_IdOAVMMain, model.WPOutput_IdOAVMMain);
                WP_Outputs recoutputrecord=_wpOutputsRepository.GetRecord(model.WPOutput_IdORVMMain);

                if(rec_set!=null)
                {
 

                    //Get the total budget for the output
                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(model.WPOutput_IdORVMMain);
                    double total_outputbudget=0;
                    foreach (var record in DB_Recs_Activities)
                    {
                        total_outputbudget=total_outputbudget+record.ActivityCost;
                    }

                    //Get all mission, procurement, communication and risk costs already captured against this output 
                    double total_missionbudget=0;
                    double total_procurementbudget=0;
                    double total_commsbudget=0;
                    //double total_riskbudget=0;
                    

                    var DB_Recs_Missions =  _wpMobilityRepository.GetRecordsByOutputId(model.WPOutput_IdORVMMain);
                    foreach (var record in DB_Recs_Missions)
                    {
                        total_missionbudget=total_missionbudget+record.MobilityCost;
                    }

                    //foreach loop for procurment
                    var DB_Recs_Procurement =  _wpProcurementRepository.GetRecordsByOutputId(model.WPOutput_IdORVMMain).ToList();
                    foreach (var record in DB_Recs_Procurement)
                    {
                        total_procurementbudget=total_procurementbudget+record.WPProcurementCost;
                    }
                    //foreach loop for comms
                    var DB_Recs_Comms =  _wpCommunicationRepository.GetRecordsByOutputId(model.WPOutput_IdORVMMain).ToList();
                    foreach (var record in DB_Recs_Comms)
                    {
                        total_commsbudget=total_commsbudget+record.WPCommsCost;
                    }

                    //foreach loop for risk
                    // var DB_Recs_Risk =  _wpRiskProfileRepository.GetRecordsByOutputId(model.WPOutput_IdORVMMain).ToList();
                    // foreach (var record in DB_Recs_Risk)
                    // {
                    //     total_riskbudget=total_riskbudget+record.WPRiskCost;
                    // }


                    totalremainingbudget=(total_outputbudget+rec_set.WPRiskCost)-(total_missionbudget+total_procurementbudget+total_commsbudget);

                

                    // if(totalremainingbudget>=model.WPRiskCostORVMMain)
                    // {

                        rec_set.WPMainRecord_id=model.WPMainRecord_idORVMMain;
                        rec_set.Project_Id=model.Project_IdORVMMain;
                        rec_set.FiscalYear_Id=model.FiscalYear_IdORVMMain;
                        rec_set.Period_Id=model.Period_IdORVMMain;
                        rec_set.WPOutput_Id=model.WPOutput_IdORVMMain;
                        rec_set.WPRisk_Description=model.WPRisk_DescriptionORVMMain;
                        rec_set.WPRiskImpactLevel_Id=model.WPRiskImpactLevel_IdORVMMain;
                        rec_set.WPRiskProbability_Id=model.WPRiskProbability_IdORVMMain;
                        rec_set.WPFrequencyOfReporting_Id=model.WPFrequencyOfReporting_IdORVMMain;
                        rec_set.WPCategory_Id=model.WPCategory_IdORVMMain;
                        rec_set.WPRiskCost=model.WPRiskCostORVMMain;
                        rec_set.WPRiskOwner_Id=model.WPRiskOwner_IdORVMMain;
                        rec_set.WPRiskChampion_Id=model.WPRiskChampion_IdORVMMain;
                        rec_set.WPRisk_MitigationMeasures=model.WPRisk_MitigationMeasuresORVMMain;
                        rec_set.WPRisk_AdditionalNotes=model.WPRisk_AdditionalNotesORVMMain;
                        rec_set.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                    
                        _wpRiskProfileRepository.Update(rec_set);

                    // }
                    // else
                    // {
                    //     return Json(new { rtnmsg = "insufficientfunds", remainfunds= totalremainingbudget.ToString()});

                    // }

                    

                }
              
                return Json(new { rtnmsg = "success", remainfunds= totalremainingbudget.ToString() });
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error", remainfunds= totalremainingbudget.ToString() });
            }

        }



        [HttpPost]
        public ActionResult AddStrategicIndicator_ProjectBased(WP_OutcomeOutputIndicatorsVM model)
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
                        IndicatorCategory="Project-Level",
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
        public ActionResult AddStrategicOutcomeIndicator_ProjectBased(WP_OutcomeOutputIndicatorsVM model)
        {
            
            try
            {
                    WP_OutcomeIndicators rec_to_add = new WP_OutcomeIndicators
                    {
                        Transaction_Id= Guid.NewGuid().ToString(),
                        WPMainRecord_id= model.WPMainRecord_idOIVM,
                        WPOutcome_Id=model.Transaction_IdOIVM,
                        Project_Id=model.Project_IdOIVM,
                        FiscalYear_Id=model.FiscalYear_IdOIVM,
                        Period_Id=model.Period_IdOIVM,
                        IndicatorCategory="Project-Level",
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

                    _wpOutcomeIndicatorsRepository.Add(rec_to_add);


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

            if(model.FPeriodIdent==8)
            {
                WP_DispatchCycle rec = _wpDispatchCycleRepository.GetRecordByYearPStartPEnd(model.FYearIdent, new LocalDate(model.PeriodStart.Year, model.PeriodStart.Month, model.PeriodStart.Day), new LocalDate(model.PeriodEnd.Year, model.PeriodEnd.Month, model.PeriodEnd.Day));

                if (rec == null)
                {
                    if(model.PeriodStart<=model.PeriodEnd)
                    {
                        try
                        {
                            WP_DispatchCycle rec_to_add = new WP_DispatchCycle
                            {
                                Transaction_Id= Guid.NewGuid().ToString(),
                                FiscalYear_Id= model.FYearIdent,
                                Period_Id=model.FPeriodIdent,
                                Employee_Id= model.Employee_Id,
                                PeriodStartDate=new LocalDate(model.PeriodStart.Year, model.PeriodStart.Month, model.PeriodStart.Day),
                                PeriodEndDate=new LocalDate(model.PeriodEnd.Year, model.PeriodEnd.Month, model.PeriodEnd.Day),
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
                        return Json(new { rtnmsg = "futuredate" });
                    }
                }
                else{
                    return Json(new { rtnmsg = "pkerror" });
                }

            }
            else
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



        }



        [HttpPost]
        public ActionResult AddDivisionKPI(DivisionKPIsViewModel model)
        {
            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id).Directorate_Id;

            Struc_DirDivIndicators rec = _strucDirDivIndicatorsRepository.GetRecordByRecordNameDirectorateDivisionAndIndicatorType(model.Record_Name, dirid, model.Division_Ident, model.Indicator_Type_Ident);

            if (rec == null)
            {
                try
                {
                    //Transaction_Id= Guid.NewGuid().ToString(),
                    int record_id=_strucDirDivIndicatorsRepository.GetAllRecords().Count() + 1;
                    Struc_DirDivIndicators rec_to_add = new Struc_DirDivIndicators
                    {
                        Record_Id=record_id,
                        Directorate_Id= dirid,
                        Division_Id= model.Division_Ident,
                        Record_Name=model.Record_Name,
                        Indicator_Type_Id= model.Indicator_Type_Ident,
                        Indicator_Type=_lkupIndicatorTypeRepository.GetRecord(model.Indicator_Type_Ident).Record_Name,
                        Record_Status=true,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    _strucDirDivIndicatorsRepository.Add(rec_to_add);

                    Trans_StrucDirDivIndicators rec_to_add_trans = new Trans_StrucDirDivIndicators
                    {
                        Transaction_Id=Guid.NewGuid().ToString(),
                        Record_Id=record_id,
                        Directorate_Id= dirid,
                        Division_Id= model.Division_Ident,
                        Record_Name=model.Record_Name,
                        Indicator_Type_Id= model.Indicator_Type_Ident,
                        Indicator_Type=_lkupIndicatorTypeRepository.GetRecord(model.Indicator_Type_Ident).Record_Name,
                        TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                    };
                    _transStrucDirDivIndicatorsRepository.Add(rec_to_add_trans);

                    

                    return Json(new { rtnmsg = "success" });
                }
                catch (Exception)
                {
                    return Json(new { rtnmsg = "error" });
                }
        

            }
            else{
                return Json(new { rtnmsg = "pkerror" });
            }

            
            



        }

        [HttpPost]
        public ActionResult EditDivisionKPI(DivisionKPIsViewModel model)
        {
            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(model.Employee_Id).Directorate_Id;

            
           // string return_message="";

            try
            {
                Struc_DirDivIndicators rec_old = _strucDirDivIndicatorsRepository.GetRecordByRecordNameDirectorateDivisionAndIndicatorType(model.Record_Name_Old, dirid, model.Division_Ident_Old, model.Indicator_Type_Ident_Old);
                Struc_DirDivIndicators rec_new = _strucDirDivIndicatorsRepository.GetRecordByRecordNameDirectorateDivisionAndIndicatorType(model.Record_Name, dirid, model.Division_Ident, model.Indicator_Type_Ident);
                Trans_StrucDirDivIndicators trans_rec_tobe_updated=_transStrucDirDivIndicatorsRepository.GetRecord(model.Transaction_Id);
                
                if(rec_new==null && (rec_old.Record_Id==trans_rec_tobe_updated.Record_Id))
                {
                    trans_rec_tobe_updated.Record_Id=model.Record_Id;
                    trans_rec_tobe_updated.Directorate_Id= model.Directorate_Ident;
                    trans_rec_tobe_updated.Division_Id= model.Division_Ident;
                    trans_rec_tobe_updated.Record_Name=model.Record_Name;
                    trans_rec_tobe_updated.Indicator_Type_Id= model.Indicator_Type_Ident;
                    trans_rec_tobe_updated.Indicator_Type=_lkupIndicatorTypeRepository.GetRecord(model.Indicator_Type_Ident).Record_Name;
                    trans_rec_tobe_updated.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    _transStrucDirDivIndicatorsRepository.Update(trans_rec_tobe_updated);

                    Struc_DirDivIndicators main_rec_tobe_updated=_strucDirDivIndicatorsRepository.GetRecord(model.Record_Id);
                    
                    main_rec_tobe_updated.Directorate_Id= model.Directorate_Ident;
                    main_rec_tobe_updated.Division_Id= model.Division_Ident;
                    main_rec_tobe_updated.Record_Name=model.Record_Name;
                    main_rec_tobe_updated.Indicator_Type_Id= model.Indicator_Type_Ident;
                    main_rec_tobe_updated.Record_Status=true;
                    main_rec_tobe_updated.Indicator_Type=_lkupIndicatorTypeRepository.GetRecord(model.Indicator_Type_Ident).Record_Name;
                    main_rec_tobe_updated.TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                    _strucDirDivIndicatorsRepository.Update(main_rec_tobe_updated);

                    
                    return Json(new { rtnmsg = "success" });
                }
                else if(rec_new!=null)
                {
                    return Json(new { rtnmsg = "pkerror" });
                }
                else
                {
                    return Json(new { rtnmsg = "error" });

                }
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
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
        public ActionResult AddWPMTPPriorities(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid, string periodtxt)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            if(selectkeys!=null)
            {
                string[] selectedkeys = selectkeys.Split(',');


                WP_MainRecord wp_mainrec_check=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                                wp_mainrec_check=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }

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
                    
                    WP_DispatchCycle wpcycle=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =_wpDispatchCycleRepository.GetRecordsByYearAndPeriodRecs(Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wpcycle=rec_set;
                            }

                            if(wpcycle!=null)
                            {
                                mainrec_to_add.PeriodStartDate=wpcycle.PeriodStartDate;
                                mainrec_to_add.PeriodEndDate=wpcycle.PeriodEndDate;
                            }
                        }
                    }
                    else
                    {
                        wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));
                    }

                    if(wpcycle.LinkToSAPExecution==true)
                        mainrec_to_add.LinkToSAPExecution=true;
                    else
                        mainrec_to_add.LinkToSAPExecution=false;

                    _wpMainRecordRepository.Add(mainrec_to_add);

                    //Modified for Period type 8
                    WP_MainRecord wp_mainrec_fetch1=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wp_mainrec_fetch1=rec_set;
                            }
                        }

                    }
                    else
                    {
                        wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    }

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

                //Modified for Period type 8
                WP_MainRecord wp_mainrec_fetch=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                            wp_mainrec_fetch=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }


                //delete all related records
                var records =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                if(wp_mainrec_fetch!=null)
                    records=_wpMTPRepository.GetRecordsByMainRecordId(wp_mainrec_fetch.Transaction_Id);
                else
                    records=_wpMTPRepository.GetRecordsByMainRecordId("Null");

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

                    //Modified for Period type 8
                    WP_MainRecord wp_mainrec_fetch=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wp_mainrec_fetch=rec_set;
                            }
                        }

                    }
                    else
                    {
                        wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    }
                    //delete all related records
                    var records =  _wpMTPRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    if(wp_mainrec_fetch!=null)
                        records=_wpMTPRepository.GetRecordsByMainRecordId(wp_mainrec_fetch.Transaction_Id);
                    else
                        records=_wpMTPRepository.GetRecordsByMainRecordId("Null");

                    
                    foreach (var record in records)
                    {
                        _wpMTPRepository.Delete(record.Transaction_Id);
                    }


            }

            return Json(new { rtnmsg = "success" });

        }


        [HttpPost]
        public ActionResult AddWPMemberStateMultiSelect(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid, string periodtxt)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";


          //  WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }


            if(wp_mainrec_check!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    //delete all related records
                    var records =  _wpCountryScopeRepository.GetRecordsByProjectYearPeriodAndMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), wp_mainrec_check.Transaction_Id);
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
                    var records =  _wpCountryScopeRepository.GetRecordsByProjectYearPeriodAndMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), wp_mainrec_check.Transaction_Id);
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
        public ActionResult AddWPMissionEmployeeMultiSelect_Old(string transid, string wpmainrecid, string wpoutputid, string selectkeys)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)); _wpMobilityRepository.Add


            string returnstring="";
            string returnemployee="";
            WP_Mobility wp_mobility_rec=_wpMobilityRepository.GetRecord(transid);
            WP_MainRecord wpmainrecord=_wpMainRecordRepository.GetRecord(wpmainrecid);





            if(wp_mobility_rec!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    bool allnotexceeded=true;



                    foreach (string recident in selectedkeys)
                    {
                        if(!NotExceededDaysLimit(transid,wpmainrecid,wpoutputid, Int32.Parse(recident)))
                        {
                            allnotexceeded=false;  
                            Employee emp=_employeeRepository.GetEmployee(Int32.Parse(recident));
                            returnemployee=emp.First_Name+" "+emp.Last_Name;
                            returnstring="exceededdays";

                
                        }
                    }

                    //Now add new selection
                    if(allnotexceeded)
                    {

                        //delete all related records GetRecordsByMobilityId
                        var records =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(transid);
                        foreach (var record in records)
                        {
                            _wpMobilityInternalTeamRepository.Delete(record.Transaction_Id);
                        }


                        foreach (string recid in selectedkeys)
                        {
                            //Check if Employee has not exceeded the number of mission days for the period
                           // if(NotExceededDaysLimit(transid,wpmainrecid,wpoutputid, Int32.Parse(recid)))
                           // {
                                WP_MobilityInternalTeam rec_to_add = new WP_MobilityInternalTeam
                                {
                                    Transaction_Id= Guid.NewGuid().ToString(),
                                    WPMainRecord_id=wpmainrecid,
                                    Project_Id=wpmainrecord.Project_Id,
                                    FiscalYear_Id=wpmainrecord.FiscalYear_Id,
                                    Period_Id=wpmainrecord.Period_Id,
                                    WPOutput_Id=wpoutputid,
                                    WPMobility_id=transid,
                                    Employee_Id=Int32.Parse(recid),
                                    PeriodStartDate=wpmainrecord.PeriodStartDate,
                                    PeriodEndDate=wpmainrecord.PeriodEndDate,
                                    TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                                };
                                _wpMobilityInternalTeamRepository.Add(rec_to_add);
                            //}

                    
                        }
                        returnstring="success";

                    } 
                }
                else
                {
                    //delete all related records
                    var records =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(transid);
                    foreach (var record in records)
                    {
                        _wpMobilityInternalTeamRepository.Delete(record.Transaction_Id);
                    }
                }
                
            }


            return Json(new { rtnmsg = returnstring, rtnemp= returnemployee});

        }


        [HttpPost]
        public ActionResult AddWPMissionEmployeeMultiSelect(string transid, string wpmainrecid, string wpoutputid, string selectkeys)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)); _wpMobilityRepository.Add


            string returnstring="";
            string returnemployee="";
            WP_Mobility wp_mobility_rec=_wpMobilityRepository.GetRecord(transid);
            WP_MainRecord wpmainrecord=_wpMainRecordRepository.GetRecord(wpmainrecid);





            if(wp_mobility_rec!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');



                    //delete all related records GetRecordsByMobilityId
                    var records =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(transid);
                    foreach (var record in records)
                    {
                        _wpMobilityInternalTeamRepository.Delete(record.Transaction_Id);
                    }


                    foreach (string recid in selectedkeys)
                    {

                        WP_MobilityInternalTeam rec_to_add = new WP_MobilityInternalTeam
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=wpmainrecid,
                            Project_Id=wpmainrecord.Project_Id,
                            FiscalYear_Id=wpmainrecord.FiscalYear_Id,
                            Period_Id=wpmainrecord.Period_Id,
                            WPOutput_Id=wpoutputid,
                            WPMobility_id=transid,
                            Employee_Id=Int32.Parse(recid),
                            PeriodStartDate=wpmainrecord.PeriodStartDate,
                            PeriodEndDate=wpmainrecord.PeriodEndDate,
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpMobilityInternalTeamRepository.Add(rec_to_add);
                

                
                    }
                    returnstring="success";

                    
                }
                else
                {
                    //delete all related records
                    var records =  _wpMobilityInternalTeamRepository.GetRecordsByMobilityId(transid);
                    foreach (var record in records)
                    {
                        _wpMobilityInternalTeamRepository.Delete(record.Transaction_Id);
                    }

                    returnstring="empty";
                }
                
            }


            return Json(new { rtnmsg = returnstring, rtnemp= returnemployee});

        }


        [HttpPost]
        public ActionResult AddWPRiskCountryMultiSelect(string transid, string wpmainrecid, string wpoutputid, string selectkeys)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod)); _wpMobilityRepository.Add


            string returnstring="";
            string returnemployee="";
            WP_RiskProfile wp_riskprofile_rec=_wpRiskProfileRepository.GetRecord(transid);
            WP_MainRecord wpmainrecord=_wpMainRecordRepository.GetRecord(wpmainrecid);





            if(wp_riskprofile_rec!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');



                    //delete all related records GetRecordsByMobilityId
                    var records =  _wpRiskProfileCountriesRepository.GetRecordsByRiskId(transid);
                    foreach (var record in records)
                    {
                        _wpRiskProfileCountriesRepository.Delete(record.Transaction_Id);
                    }


                    foreach (string recid in selectedkeys)
                    {

                        WP_RiskProfileCountries rec_to_add = new WP_RiskProfileCountries
                        {
                            Transaction_Id= Guid.NewGuid().ToString(),
                            WPMainRecord_id=wpmainrecid,
                            Project_Id=wpmainrecord.Project_Id,
                            FiscalYear_Id=wpmainrecord.FiscalYear_Id,
                            Period_Id=wpmainrecord.Period_Id,
                            WPOutput_Id=wpoutputid,
                            WPRisk_id=transid,
                            Country_Id=Int32.Parse(recid),
                            TransactionDate = new LocalDate(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day)
                        };
                        _wpRiskProfileCountriesRepository.Add(rec_to_add);
                

                
                    }
                    returnstring="success";

                    
                }
                else
                {
                    //delete all related records
                    var records =  _wpRiskProfileCountriesRepository.GetRecordsByRiskId(transid);
                    foreach (var record in records)
                    {
                        _wpRiskProfileCountriesRepository.Delete(record.Transaction_Id);
                    }

                    returnstring="empty";
                }
                
            }


            return Json(new { rtnmsg = returnstring, rtnemp= returnemployee});

        }

        public bool NotExceededDaysLimit(string mobilityid, string wpmainrecid, string wpoutputid, int empid)
        {
            bool rtnval=false;

            int max_month_days=0;
            int num_of_months=0;
            int totalnum_of_days_accumulated=0;
            int totalnum_of_days_allowed=0;
            int totalnum_of_days_buffer=0;

            int num_of_days=0;

            WP_MainRecord mainrec=_wpMainRecordRepository.GetRecord(wpmainrecid);
            WP_Mobility mobilityrecord=_wpMobilityRepository.GetRecord(mobilityid);
            WP_MobilityLimit wpmobilitylimit=null;

            //Get max_month_days
            if(mainrec.Period_Id==8)
            {
                wpmobilitylimit=_wpMobilityLimitRepository.GetRecordByEmployeeYearPeriodStartEnd(empid, mainrec.FiscalYear_Id, mainrec.Period_Id, mainrec.PeriodStartDate, mainrec.PeriodEndDate);

                List<MonthAndYear> nummonthobj=GetMonthsInPeriodRange(new DateTime(mainrec.PeriodStartDate.Year,mainrec.PeriodStartDate.Month,mainrec.PeriodStartDate.Day), new DateTime(mainrec.PeriodEndDate.Year,mainrec.PeriodEndDate.Month,mainrec.PeriodEndDate.Day));
                num_of_months=nummonthobj.Count();


                var DB_Records8 =  _wpMobilityInternalTeamRepository.GetRecordsByEmployeeYearPeriodStartEnd(empid, mainrec.FiscalYear_Id, mainrec.Period_Id, mainrec.PeriodStartDate, mainrec.PeriodEndDate);
                foreach (var recordset in DB_Records8)
                {
                    WP_Mobility mobrec=_wpMobilityRepository.GetRecord(recordset.WPMobility_id);
                    DateTime mstart=new DateTime(mobrec.MobilityStartDate.Year, mobrec.MobilityStartDate.Month, mobrec.MobilityStartDate.Day);
                    DateTime mend=new DateTime(mobrec.MobilityEndDate.Year, mobrec.MobilityEndDate.Month, mobrec.MobilityEndDate.Day);

                    totalnum_of_days_accumulated=totalnum_of_days_accumulated+(mstart.Date.Subtract(mend.Date).Duration().Days + 1);

                }

            }
            else
            {
                wpmobilitylimit=_wpMobilityLimitRepository.GetRecordByEmployeeYearPeriod(empid, mainrec.FiscalYear_Id, mainrec.Period_Id);
                if(mainrec.Period_Id==1 || mainrec.Period_Id==2 || mainrec.Period_Id==3 || mainrec.Period_Id==4)
                    num_of_months=3;
                else if(mainrec.Period_Id==5 || mainrec.Period_Id==6)
                    num_of_months=6;
                else 
                    num_of_months=12;

                var DB_Records =  _wpMobilityInternalTeamRepository.GetRecordsByEmployeeYearPeriod(empid, mainrec.FiscalYear_Id, mainrec.Period_Id);
                foreach (var recordset in DB_Records)
                {
                    WP_Mobility mobrec=_wpMobilityRepository.GetRecord(recordset.WPMobility_id);
                    DateTime mstart=new DateTime(mobrec.MobilityStartDate.Year, mobrec.MobilityStartDate.Month, mobrec.MobilityStartDate.Day);
                    DateTime mend=new DateTime(mobrec.MobilityEndDate.Year, mobrec.MobilityEndDate.Month, mobrec.MobilityEndDate.Day);

                    totalnum_of_days_accumulated=totalnum_of_days_accumulated+(mstart.Date.Subtract(mend.Date).Duration().Days + 1);

                }

            }

            if(wpmobilitylimit!=null)
            {
                max_month_days=wpmobilitylimit.MonthlyLimit;
            }
            else
            {
                Trans_MobilityLimits translkupmoblimit=_transMobilityLimitsRepository.GetFirstOrDefaultRecordSet();
                max_month_days=_lkupMobilityLimitsRepository.GetRecord(translkupmoblimit.Record_Id).MonthlyLimit;
            }


            DateTime mstart_req=new DateTime(mobilityrecord.MobilityStartDate.Year, mobilityrecord.MobilityStartDate.Month, mobilityrecord.MobilityStartDate.Day);
            DateTime mend_req=new DateTime(mobilityrecord.MobilityEndDate.Year, mobilityrecord.MobilityEndDate.Month, mobilityrecord.MobilityEndDate.Day);

            num_of_days=mstart_req.Date.Subtract(mend_req.Date).Duration().Days + 1;

            totalnum_of_days_allowed=max_month_days*num_of_months;
            totalnum_of_days_buffer=totalnum_of_days_allowed-totalnum_of_days_accumulated;

            if(num_of_days<=totalnum_of_days_buffer)
            {
                rtnval=true;
            }

            return rtnval;
        }

        List<MonthAndYear> GetMonthsInPeriodRange(DateTime date1, DateTime date2)
        {
            var monthList = new List<MonthAndYear>();

            while (date1 < date2)
            {
                MonthAndYear rec=new MonthAndYear();
                rec.PMonth=Int32.Parse(date1.ToString("MM"));
                rec.PYear=Int32.Parse(date1.ToString("yyyy"));

                monthList.Add(rec);
                date1 = date1.AddMonths(1);
            }

            return monthList;
        }

        [HttpPost]
        public ActionResult CheckOutputIndicatorType(string indicatorid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";

            if(indicatorid!=null)
            {
                Strategy_OutputIndicators rec=_strategyOutputIndicatorsRepository.GetRecord(Int32.Parse(indicatorid));
                
                if(rec!=null && rec.Indicator_Type=="Qualitative")
                {
                
                    returnstring="quanlitative";
                }
                else
                {
                    returnstring="quantitative";

                }
            }

            return Json(new { rtnmsg = returnstring });

        }
        [HttpPost]
        public ActionResult CheckDirOutputIndicatorType(string indicatorid)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            string returnstring="";

            if(indicatorid!=null)
            {
                Struc_DirDivIndicators rec=_strucDirDivIndicatorsRepository.GetRecord(Int32.Parse(indicatorid));
                
                if(rec!=null && rec.Indicator_Type=="Qualitative")
                {
                
                    returnstring="quanlitative";
                }
                else
                {
                    returnstring="quantitative";

                }
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
            WP_Outputs wpoutput_recfetch=_wpOutputsRepository.GetRecord(transid);

            var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(wpoutput_recfetch.Transaction_Id);
            double total_budget=0;
            foreach (var record in DB_Recs_Activities)
            {
                total_budget=total_budget+record.ActivityCost;

            }

            if(saprec.SAP_BudgetAmount< total_budget )
            {
                returnstring="budgetexceedssapamount";
            }
            else
            {
                var DB_Recs_Activities_Linked_SAP =  _wpOutputActivitiesRepository.GetRecordsByWPSAPLink_Id(sapwbsselect);
                double total_use=0;

                foreach (var record in DB_Recs_Activities_Linked_SAP)
                {
                    total_use=total_use+record.ActivityCost;

                }

                if((saprec.SAP_BudgetAmount-total_use)<total_budget)
                {
                    returnstring="insufficientfunds";
                }
                else
                {
                    //Update Output with SAP Link
                    wpoutput_recfetch.WPSAPLink_Id=sapwbsselect;
                    _wpOutputsRepository.Update(wpoutput_recfetch);

                    //Update Output Activities with SAP Link
                    foreach (var record in DB_Recs_Activities)
                    {
                        record.WPSAPLink_Id=sapwbsselect;
                        _wpOutputActivitiesRepository.Update(record);

                    }
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
                WP_Outputs wpoutput_recfetch=_wpOutputsRepository.GetRecord(transid);

                if (wpoutput_recfetch.WPSAPLink_Id != null)
                {
                    wpoutput_recfetch.WPSAPLink_Id=null;
                    _wpOutputsRepository.Update(wpoutput_recfetch); 


                    var DB_Recs_Activities =  _wpOutputActivitiesRepository.GetRecordsByOutputId(wpoutput_recfetch.Transaction_Id);
                    foreach (var record in DB_Recs_Activities)
                    {
                        record.WPSAPLink_Id=null;
                        _wpOutputActivitiesRepository.Update(record);

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
        public ActionResult DeleteWorkplansDraft(string transid)
        {
            try
            {
                WP_MainRecord main_recfetch=_wpMainRecordRepository.GetRecord(transid);

                if (main_recfetch != null)
                {
                    //Delete All Related WP_ApprovalStatus
                    var DB_Recs1 =  _wpApprovalStatusRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs1)
                    {
                        _wpApprovalStatusRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_AUDAPriority
                    var DB_Recs2 =  _wpAUDAPriorityRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs2)
                    {
                        _wpAUDAPriorityRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_Communication
                    var DB_Recs3 =  _wpCommunicationRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs3)
                    {
                        _wpCommunicationRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_CountryScope
                    var DB_Recs4 =  _wpCountryScopeRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs4)
                    {
                        _wpCountryScopeRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_Mobility
                    var DB_Recs5 =  _wpMobilityRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs5)
                    {

                        
                        //Delete All Related WP_MobilityExternalTeam
                        var DB_RecsSubs=_wpMobilityExternalTeamRepository.GetRecordsByMobilityId(recordset.Transaction_Id).ToList();
                        foreach (var record_set in DB_RecsSubs)
                        {
                            _wpMobilityExternalTeamRepository.Delete(record_set.Transaction_Id);

                        }
                        _wpMobilityRepository.Delete(recordset.Transaction_Id);


                    }

                   //Delete All Related WP_MobilityInternalTeam
                    var DB_Recs6 =  _wpMobilityInternalTeamRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs6)
                    {
                        _wpMobilityInternalTeamRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_MTP
                    var DB_Recs7 =  _wpMTPRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs7)
                    {
                        _wpMTPRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_OutcomeIndicators 
                    var DB_Recs8 =  _wpOutcomeIndicatorsRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs8)
                    {
                        _wpOutcomeIndicatorsRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_Outcomes 
                    var DB_Recs9 =  _wpOutcomesRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs9)
                    {
                        _wpOutcomesRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_OutputActivities 
                    var DB_Recs10 =  _wpOutputActivitiesRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs10)
                    {
                        _wpOutputActivitiesRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_OutputActivityCountries  
                    var DB_Recs11 =  _wpOutputActivityCountriesRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs11)
                    {
                        _wpOutputActivityCountriesRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_OutputBudget  
                    var DB_Recs12 =  _wpOutputBudgetRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs12)
                    {
                        _wpOutputBudgetRepository.Delete(recordset.Transaction_Id);
                    }


                    //Delete All Related WP_OutputIndicators  
                    var DB_Recs13 =  _wpOutputIndicatorsRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs13)
                    {
                        _wpOutputIndicatorsRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_Outputs  
                    var DB_Recs14 =  _wpOutputsRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs14)
                    {
                        _wpOutputsRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_Procurement  
                    var DB_Recs15 =  _wpProcurementRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs15)
                    {
                        _wpProcurementRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_RegionScope  
                    var DB_Recs16 =  _wpRegionScopeRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs16)
                    {
                        _wpRegionScopeRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_RiskProfile   
                    var DB_Recs17 =  _wpRiskProfileRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs17)
                    {
                        _wpRiskProfileRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete All Related WP_RiskProfileCountries   
                    var DB_Recs18 =  _wpRiskProfileCountriesRepository.GetRecordsByMainRecordId(main_recfetch.Transaction_Id).ToList();
                    foreach (var recordset in DB_Recs18)
                    {
                        _wpRiskProfileCountriesRepository.Delete(recordset.Transaction_Id);
                    }

                    //Delete Main Record
                    _wpMainRecordRepository.Delete(main_recfetch.Transaction_Id);







       
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
        public ActionResult AddWPRECCoverageMultiSelect(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid, string periodtxt)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            string returnstring="";
           // WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec_set in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                            wp_mainrec_check=rec_set;
                    }
                }

            }
            else
            {
                wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }


            if(wp_mainrec_check!=null)
            {
                if(selectkeys!=null)
                {
                    string[] selectedkeys = selectkeys.Split(',');

                    //WP_MainRecord wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


                    //delete all related records
                    var records =  _wpRegionScopeRepository.GetRecordsByProjectYearPeriodAndMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), wp_mainrec_check.Transaction_Id);
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
                        var records =  _wpRegionScopeRepository.GetRecordsByProjectYearPeriodAndMainRecId(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod), wp_mainrec_check.Transaction_Id);
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
        public ActionResult AddContinentalCoverage(string projid, string fyear, string fperiod, string empid, string contstatus, string periodtxt)
        {

                string returnstring="";


               // WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                WP_MainRecord wp_mainrec_check=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                                wp_mainrec_check=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }

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
        public ActionResult AddWPAUDAPriorities(string projid, string fyear, string fperiod, string selectkeys, string empid, string dirid, string divid,  string progid, string periodtxt)
        {

           // WP_MainRecord mainrec=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));


            if(selectkeys!=null)
            {
                string[] selectedkeys = selectkeys.Split(',');


                WP_MainRecord wp_mainrec_check=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                                wp_mainrec_check=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }

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

                    WP_DispatchCycle wpcycle=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =_wpDispatchCycleRepository.GetRecordsByYearAndPeriodRecs(Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wpcycle=rec_set;
                            }

                            if(wpcycle!=null)
                            {
                                mainrec_to_add.PeriodStartDate=wpcycle.PeriodStartDate;
                                mainrec_to_add.PeriodEndDate=wpcycle.PeriodEndDate;
                            }
                        }
                    }
                    else
                    {
                        wpcycle=_wpDispatchCycleRepository.GetRecordByYearAndPeriod(Int32.Parse(fyear), Int32.Parse(fperiod));
                    }

                    if(wpcycle.LinkToSAPExecution==true)
                        mainrec_to_add.LinkToSAPExecution=true;
                    else
                        mainrec_to_add.LinkToSAPExecution=false;

                    _wpMainRecordRepository.Add(mainrec_to_add);

                    //Modified for Period type 8
                    WP_MainRecord wp_mainrec_fetch1=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wp_mainrec_fetch1=rec_set;
                            }
                        }

                    }
                    else
                    {
                        wp_mainrec_fetch1=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    }

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

                //Modified for Period type 8
                WP_MainRecord wp_mainrec_fetch=null;

                if(Int32.Parse(fperiod)==8)
                {
                    var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                    int _countrecs =  DB_Records8.Count();
                    if(_countrecs>0)
                    {
                        foreach (var rec_set in DB_Records8)
                        {
                            DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                            DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                            string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                            if(periodinmain==periodtxt)
                            wp_mainrec_fetch=rec_set;
                        }
                    }

                }
                else
                {
                    wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                }
                //delete all related records
                var records =  _wpAUDAPriorityRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                if(wp_mainrec_fetch!=null)
                    records=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(wp_mainrec_fetch.Transaction_Id);
                else
                    records=_wpAUDAPriorityRepository.GetRecordsByMainRecordId("Null");

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
                    //Modified for Period type 8
                    WP_MainRecord wp_mainrec_fetch=null;

                    if(Int32.Parse(fperiod)==8)
                    {
                        var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                        int _countrecs =  DB_Records8.Count();
                        if(_countrecs>0)
                        {
                            foreach (var rec_set in DB_Records8)
                            {
                                DateTime pstart=new DateTime(rec_set.PeriodStartDate.Year, rec_set.PeriodStartDate.Month, rec_set.PeriodStartDate.Day);
                                DateTime pend=new DateTime(rec_set.PeriodEndDate.Year, rec_set.PeriodEndDate.Month, rec_set.PeriodEndDate.Day);
                                string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                                if(periodinmain==periodtxt)
                                wp_mainrec_fetch=rec_set;
                            }
                        }

                    }
                    else
                    {
                        wp_mainrec_fetch=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    }
                    //delete all related records
                    var records =  _wpAUDAPriorityRepository.GetRecordsByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
                    if(wp_mainrec_fetch!=null)
                        records=_wpAUDAPriorityRepository.GetRecordsByMainRecordId(wp_mainrec_fetch.Transaction_Id);
                    else
                        records=_wpAUDAPriorityRepository.GetRecordsByMainRecordId("Null");

                    foreach (var record in records)
                    {
                        _wpAUDAPriorityRepository.Delete(record.Transaction_Id);
                    }


            }

            return Json(new { rtnmsg = "success" });

        }

        

        [HttpPost]
        public ActionResult CheckMainWPRecordStatus(string projid, string fyear, string fperiod, string empid, string dirid, string divid,  string progid, string periodtxt)
        {

            //WP_MainRecord wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            WP_MainRecord wp_mainrec_check=null;

            if(Int32.Parse(fperiod)==8)
            {
                 var DB_Records8 =  _wpMainRecordRepository.GetRecordsByProjectYearAndPeriodRecs(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));

                int _countrecs =  DB_Records8.Count();
                if(_countrecs>0)
                {
                    foreach (var rec in DB_Records8)
                    {
                        DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                        string periodinmain=pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy"); 

                        if(periodinmain==periodtxt)
                           wp_mainrec_check=rec;
                    }
                }

            }
            else
            {
               wp_mainrec_check=_wpMainRecordRepository.GetRecordByProjectYearAndPeriod(Int32.Parse(projid), Int32.Parse(fyear), Int32.Parse(fperiod));
            }

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

                    var _user = await userManager.FindByIdAsync("");
                    Employee _emp = _employeeRepository.GetEmployee(model.Employee_Id);

                    if(_emp.IdentityUserId!="")
                    {
                        _user = await userManager.FindByIdAsync(_emp.IdentityUserId);

                        var isInRole = await userManager.IsInRoleAsync(_user, "Director");

                        if (!isInRole)
                        {
                            _result = await userManager.AddToRoleAsync(_user, "Director");
                        }

                        return Json(new { rtnmsg = "success" });
                    }
                    else
                    {
                        return Json(new { rtnmsg = "nologin" });
                    }
         
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
        public async Task<ActionResult> AddStaffRoleMapping(string roleid, string rolename, string empid)
        {
     
            IdentityResult _result;
    
            try
            {
  
                Employee _emp = _employeeRepository.GetEmployee(Int32.Parse(empid));
                var _user = await userManager.FindByIdAsync("");

                if(_emp.IdentityUserId!="")
                {
                    _user = await userManager.FindByIdAsync(_emp.IdentityUserId);
                    var isInRole = await userManager.IsInRoleAsync(_user, rolename);

                    if (!isInRole)
                    {
                        _result = await userManager.AddToRoleAsync(_user, rolename);
                    }
                     return Json(new { rtnmsg = "success" });
                }
                else
                {
                    return Json(new { rtnmsg = "nologin" });
                }




                        

               
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" });
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


        [HttpPost]
        public async Task<ActionResult> AddProjProgMapping(EmployeeViewModel model)
        {
            Employee emp = _employeeRepository.GetEmployee(model.Employee_Id);
            var user = await userManager.GetUserAsync(HttpContext.User);
            Trans_Project transproject=_transProjectRepository.GetRecordByMainProjectID(model.Project_Id);

        

          

            if (transproject != null)
            {

                try
                {
                    Trans_Programme transprogramme =_transProgrammeRepository.GetRecordByMainProgrammeID(model.Programme_Id);
                    LkUp_Programme lkupprogramme=_lkupProgrammeRepository.GetRecord(model.Programme_Id);
                    LkUp_Project lkupproject=_lkupProjectRepository.GetRecord(model.Project_Id);

                    if(transproject.MainProgramme_Id==0)
                    {
                        transproject.MainProgramme_Id=model.Programme_Id;
                        lkupproject.Programme_Id=model.Programme_Id;
                    }
                    if(transprogramme!=null)
                    {
                        transproject.TransProgramme_Id=transprogramme.Transaction_Id;
                    }

                    //Directorate
                    if(transproject.Directorate_Id==0)
                    {
                        transproject.Directorate_Id=model.Directorate_Id;
                    }
                    if(lkupproject.Directorate_Id==0)
                    {
                        lkupproject.Directorate_Id=model.Directorate_Id;
                    }

                    if(transprogramme!=null)
                    {
                        if(transprogramme.Directorate_Id==0)
                        {
                            transprogramme.Directorate_Id=model.Directorate_Id;
                        }
                    }
                    if(lkupprogramme!=null)
                    {
                        if(lkupprogramme.Directorate_Id==0)
                        {
                            lkupprogramme.Directorate_Id=model.Directorate_Id;
                        }
                    }

                    //Division

                    if(transproject.Division_Id==0)
                    {
                        transproject.Division_Id=model.Division_Id;
                    }
                    if(lkupproject.Division_Id==0)
                    {
                        lkupproject.Division_Id=model.Division_Id;
                    }

                    if(transprogramme!=null)
                    {
                        if(transprogramme.Division_Id==0)
                        {
                            transprogramme.Division_Id=model.Division_Id;
                        }
                    }
                    if(lkupprogramme!=null)
                    {
                        if(lkupprogramme.Division_Id==0)
                        {
                            lkupprogramme.Division_Id=model.Division_Id;
                        }
                    }

                    //Now start Saving

                    _transProjectRepository.Update(transproject);

                    if(transprogramme!=null)
                    {
                        _transProgrammeRepository.Update(transprogramme);
                    }

                    if(lkupprogramme!=null)
                    {
                        _lkupProgrammeRepository.Update(lkupprogramme);
                    }

                    if(lkupproject!=null)
                    {
                        _lkupProjectRepository.Update(lkupproject);
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
                return Json(new { rtnmsg = "error" });
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
        public JsonResult GetAllTransProgramme()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _transProgrammeRepository.GetAllRecords().ToList();

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
        public JsonResult GetAllTransProject()
        {
            // IEnumerable<Employee> DB_Employees = new List<Employee>();
            

            var recs =  _transProjectRepository.GetAllRecords().ToList();

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
        public JsonResult GetWPStrategicPriorities(string projid, string fyear, string fperiod, string mainrecid)
        {
          
            var recs=_wpAUDAPriorityRepository.GetRecordsByProjectYearPeriodAndMainRecId(Int32.Parse(projid),Int32.Parse(fyear),Int32.Parse(fperiod), mainrecid).ToList();
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
        public JsonResult GetDirectorateLevelTransIndicators(string empid)
        {
          
            int dirid=_strucDirStaffMappingRepository.GetRecordByEmployeeAndPrimaryDirectorate(Int32.Parse(empid)).Directorate_Id;

           var DB_RecsDivs =  _strucDivStaffMappingRepository.GetAllRecordsByEmployeeAndDirectorate(Int32.Parse(empid),dirid).ToList();

            int _countDivs = DB_RecsDivs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

            if (empid != null)
            {
                if (_countDivs > 0)
                {
                    foreach (var div in DB_RecsDivs)
                    {
                        var DB_RecsIndicators = _transStrucDirDivIndicatorsRepository.GetAllRecordsByDivision(div.Division_Id).ToList();

                        int _countIndicators = DB_RecsIndicators.Count();
                        if (_countIndicators > 0)
                        {
                            foreach (var rec in DB_RecsIndicators)
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
                    }
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
        public JsonResult GetAllOutputsForMainRecord(string mainrecid)
        {
            var recs=_wpOutputsRepository.GetRecordsByMainRecordId(mainrecid).ToList();
            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();


            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_StringId = rec.Transaction_Id,
                            DropDown_Name = rec.Output
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);
                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllNonStructureRoles()
        {
            var userRoles = roleManager.Roles;

            int _count =  userRoles.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();

            if (_count > 0)
            {
                foreach (var rec in userRoles)
                {
                    if(rec.Name=="Admin"||rec.Name=="CEO"||rec.Name=="PIPD"||rec.Name=="Procurement" ||rec.Name=="Travel" || rec.Name=="Finance")
                    {
                        DropDownListViewModel srec = new DropDownListViewModel
                        {
                                DropDown_StringId = rec.Id,
                                DropDown_Name = rec.Name
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
        public JsonResult GetTransFiscalPeriodsInstiutionalReports(string cycleid)
        {

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();
            WP_DispatchCycle cyclerec=_wpDispatchCycleRepository.GetRecord(cycleid);

            if(cyclerec.Period_Id==7)
            {
                var recs=_transPeriodRepository.GetAllRecords().ToList();
                int _count = recs.Count();
                if (_count > 0)
                {
                    foreach (var rec in recs)
                    {
                        if(rec.Record_Id!=8)
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
                            DropDown_IntId = rec.Period_Id
                    };
                    if(rec.Period_Id==8)
                    {
                        DateTime pstart=new DateTime(rec.PeriodStartDate.Year, rec.PeriodStartDate.Month, rec.PeriodStartDate.Day);
                        DateTime pend=new DateTime(rec.PeriodEndDate.Year, rec.PeriodEndDate.Month, rec.PeriodEndDate.Day);
                        srec.DropDown_Name = pstart.Date.ToString("MMMM dd, yyyy") + " - "+ pend.Date.ToString("MMMM dd, yyyy");      
                    }
                    else
                    {
                        srec.DropDown_Name = _lkupPeriodRepository.GetRecord(rec.Period_Id).Record_Name;  
                    }
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
        public JsonResult GetIndicatorType()
        {


           var recs = _transIndicatorTypeRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                   
                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Record_Id,
                            DropDown_Name = _lkupIndicatorTypeRepository.GetRecord(rec.Record_Id).Record_Name
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
        public JsonResult GetAllTransCountries()
        {


           var recs =  _transCountryRepository.GetAllTrans_Country().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_Country fetched_rec=_lkupCountryRepository.GetCountry(rec.Country_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = rec.Country_Id,
                            DropDown_Name = _lkupCountryRepository.GetCountry(rec.Country_Id).Country_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransProcurementTypes()
        {


           var recs =  _transProcurementTypeRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_ProcurementType fetched_rec=_lkupProcurementTypeRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransCommunicationChannels()
        {


           var recs =  _transCommsChannelRepository.GetAllTrans_CommsChannel().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_CommsChannel fetched_rec=_lkupCommsChannelRepository.GetCommsChannel(rec.CommsChannel_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.CommsChannel_Id,
                            DropDown_Name = fetched_rec.CommsChannel_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }




        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransRiskCategories()
        {


           var recs =  _transRiskCategoryRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_RiskCategory fetched_rec=_lkupRiskCategoryRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransImpactLevels()
        {


           var recs =  _transRiskImpactRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_RiskImpact fetched_rec=_lkupRiskImpactRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransProbabilities()
        {


           var recs =  _transRiskProbabilityRepository.GetAllRecords().OrderByDescending(x => x.Record_Id).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_RiskProbability fetched_rec=_lkupRiskProbabilityRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }



        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransRiskReportingFreq()
        {


           var recs =  _transRiskRTimeframeRepository.GetAllRecords().OrderByDescending(x => x.Record_Id).ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_RiskRTimeframe fetched_rec=_lkupRiskRTimeframeRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

                }
            }

            return Json(collection_recs.ToList());

        }





        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTransProcurementLTimes()
        {


           var recs =  _transProcurementLTimeRepository.GetAllRecords().ToList();

            int _count = recs.Count();

            List<DropDownListViewModel> collection_recs = new List<DropDownListViewModel>();



            if (_count > 0)
            {
                foreach (var rec in recs)
                {
                    LkUp_ProcurementLTime fetched_rec=_lkupProcurementLTimeRepository.GetRecord(rec.Record_Id);


                    DropDownListViewModel srec = new DropDownListViewModel
                    {
                            DropDown_IntId = fetched_rec.Record_Id,
                            DropDown_Name = fetched_rec.Record_Name
                    };
                    // EmployeeDropDownViewModel me = DB_Employees[_count];
                    collection_recs.Add(srec);

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