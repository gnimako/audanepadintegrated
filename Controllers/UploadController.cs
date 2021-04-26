using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net.Http.Headers;
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
using Microsoft.Net.Http.Headers;
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
    public class UploadController: Controller
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

        //Procurement Automation
        private readonly ILkUp_ProcurementApprovalAuthorityRepository _lkupProcurementApprovalAuthorityRepository ;
        private readonly ILkUp_ProcurementSelectionMethodRepository _lkupProcurementSelectionMethodRepository ;
        private readonly ILkUp_ProcurementPaymentTypeRepository _lkupProcurementPaymentTypeRepository ;
        private readonly ITrans_ProcurementApprovalAuthorityRepository _transProcurementApprovalAuthorityRepository;
        private readonly ITrans_ProcurementSelectionMethodRepository _transProcurementSelectionMethodRepository;
        private readonly ITrans_ProcurementPaymentTypeRepository _transProcurementPaymentTypeRepository;
        private readonly IWP_ProcurementWorkLoadAssignmentRepository _wpProcurementWorkLoadAssignmentRepository;
        private readonly IWP_ProcurementProcessRepository _wpProcurementProcessRepository;
        private readonly IWP_TasksRepository _wpTasksRepository;
        private readonly ILkUp_ProcurementProcessStepsRepository _lkupProcurementProcessStepsRepository;
        private readonly ITrans_ProcurementProcessStepsRepository _transProcurementProcessStepsReposity;
        private readonly IWP_ProcurementProcessStepsRepository _wpProcurementProcessStepsRepository;
        private readonly IWP_ProcurementTORDocsRepository _wpProcurementTORDocsRepository;

      




        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment hostingEnvironment;

        public UploadController(IEmployeeRepository employeeRepository,
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
                                IWP_RiskProfileCountriesRepository wpRiskProfileCountriesRepository,
                                
                                //Procurement Automation
                                ILkUp_ProcurementApprovalAuthorityRepository lkupProcurementApprovalAuthorityRepository,
                                ILkUp_ProcurementSelectionMethodRepository lkupProcurementSelectionMethodRepository,
                                ILkUp_ProcurementPaymentTypeRepository lkupProcurementPaymentTypeRepository,
                                ITrans_ProcurementApprovalAuthorityRepository transProcurementApprovalAuthorityRepository,
                                ITrans_ProcurementSelectionMethodRepository transProcurementSelectionMethodRepository,
                                ITrans_ProcurementPaymentTypeRepository transProcurementPaymentTypeRepository,
                                IWP_ProcurementWorkLoadAssignmentRepository wpProcurementWorkLoadAssignmentRepository,
                                IWP_ProcurementProcessRepository wpProcurementProcessRepository,
                                IWP_TasksRepository wpTasksRepository,
                                ILkUp_ProcurementProcessStepsRepository lkupProcurementProcessStepsRepository,
                                ITrans_ProcurementProcessStepsRepository transProcurementProcessStepsReposity,
                                IWP_ProcurementProcessStepsRepository wpProcurementProcessStepsRepository,
                                IWP_ProcurementTORDocsRepository wpProcurementTORDocsRepository)
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

            //Procurement Automation
            _lkupProcurementApprovalAuthorityRepository =lkupProcurementApprovalAuthorityRepository;
            _lkupProcurementSelectionMethodRepository =lkupProcurementSelectionMethodRepository;
            _lkupProcurementPaymentTypeRepository =lkupProcurementPaymentTypeRepository;
            _transProcurementApprovalAuthorityRepository=transProcurementApprovalAuthorityRepository;
            _transProcurementSelectionMethodRepository=transProcurementSelectionMethodRepository;
            _transProcurementPaymentTypeRepository=transProcurementPaymentTypeRepository;
            _wpProcurementWorkLoadAssignmentRepository=wpProcurementWorkLoadAssignmentRepository;
            _wpProcurementProcessRepository=wpProcurementProcessRepository;
            _wpTasksRepository=wpTasksRepository;
            _lkupProcurementProcessStepsRepository=lkupProcurementProcessStepsRepository;
            _transProcurementProcessStepsReposity=transProcurementProcessStepsReposity;
            _wpProcurementProcessStepsRepository=wpProcurementProcessStepsRepository;
            _wpProcurementTORDocsRepository=wpProcurementTORDocsRepository;
 
        



            _context = context;
            
        }

        public async Task<ActionResult> SaveProcurementTORDocsFiles(IEnumerable<IFormFile> files, string procid)
        {
            //Create folder for each student
       
            var user = await userManager.GetUserAsync(HttpContext.User);
            WP_Procurement procurementrec=_wpProcurementRepository.GetRecord(procid);

            string procurementpath = @"wwwroot/appdirectory/procurements/submissionofproctordocs/" + procurementrec.Transaction_Id;


            var directory = new DirectoryInfo(procurementpath);

            if (directory.Exists == false)
            {
                directory.Create();
            }

            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                    var physicalPath = Path.Combine(procurementpath, fileName);

                    // The files are not actually saved in this demo
                    using (var fileStream = new FileStream(physicalPath, FileMode.Create))
                    {
                       await file.CopyToAsync(fileStream);
                    }
                }
            }



         

            // Return an empty string to signify success
     
            return Content("");
        }
        
    }
}