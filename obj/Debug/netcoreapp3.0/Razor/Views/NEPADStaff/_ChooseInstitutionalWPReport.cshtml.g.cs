#pragma checksum "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/_ChooseInstitutionalWPReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa34bb290bef40090cdd000b7f44753005ddf798"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NEPADStaff__ChooseInstitutionalWPReport), @"mvc.1.0.view", @"/Views/NEPADStaff/_ChooseInstitutionalWPReport.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using AUDANEPAD_Integrated;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using AUDANEPAD_Integrated.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using AUDANEPAD_Integrated.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa34bb290bef40090cdd000b7f44753005ddf798", @"/Views/NEPADStaff/_ChooseInstitutionalWPReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d35ea56c2d14dc1962e146e0310b25b93790e3", @"/Views/_ViewImports.cshtml")]
    public class Views_NEPADStaff__ChooseInstitutionalWPReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WP_CycleVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("k-textbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("avatar-lg mb-3 mb-sm-0 rounded mr-sm-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/summary.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/full.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/mobility.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/procurement.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/communication.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/nepadstaff2/images/risk.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addform"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n\n\n");
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa34bb290bef40090cdd000b7f44753005ddf7988896", async() => {
                WriteLiteral("\n\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aa34bb290bef40090cdd000b7f44753005ddf7989156", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 9 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/_ChooseInstitutionalWPReport.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.WPCycle_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 9 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/_ChooseInstitutionalWPReport.cshtml"
                                                                       WriteLiteral(Model.WPCycle_Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n\n <div class=\"card mb-4\">\n                            <div class=\"card-body\">\n                             \n                                <div class=\"d-flex flex-column flex-sm-row align-items-sm-center mb-3\">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79812194", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateSummaryReport()"">Summary Report for Workplan</a></h5>
                                        <p class=""m-0 text-small text-muted"">The target users of this report is senior management.</p>
                                      
                                    </div>
                                    <div>
                                        <a href=""javascript:void(0)"" onclick=""GenerateSummaryReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>

                                <div class=""d-flex flex-column flex-sm-row align-items-sm-center mb-3"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79814421", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateFullReport()"">Full Institutional Workplan</a></h5>
                                        <p class=""m-0 text-small text-muted"">This is a detailed institutional workplan</p>
                                      
                                    </div>
                                    <div>
                                

                                        <a href=""javascript:void(0)"" onclick=""GenerateFullReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>

                                <div class=""d-flex flex-column flex-sm-row align-items-sm-center mb-3"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79816664", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateMobilityReport()"">Institutional Mobility Plan</a></h5>
                                        <p class=""m-0 text-small text-muted"">This is an institutional mobility plan</p>
                                      
                                    </div>
                                    <div>
                                       <a href=""javascript:void(0)"" onclick=""GenerateMobilityReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>

                                <div class=""d-flex flex-column flex-sm-row align-items-sm-center mb-3"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79818877", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateProcurementReport()"">Institutional Procurement Plan</a></h5>
                                        <p class=""m-0 text-small text-muted"">This is an institutional procurement plan</p>
                                      
                                    </div>
                                    <div>
                                       <a href=""javascript:void(0)"" onclick=""GenerateProcurementReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>

                                <div class=""d-flex flex-column flex-sm-row align-items-sm-center mb-3"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79821102", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateCommunicationReport()"">Institutional Communication Plan</a></h5>
                                        <p class=""m-0 text-small text-muted"">This is an institutional communication plan</p>
                                      
                                    </div>
                                    <div>
                                       <a href=""javascript:void(0)"" onclick=""GenerateCommunicationReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>

                                 <div class=""d-flex flex-column flex-sm-row align-items-sm-center mb-3"">");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aa34bb290bef40090cdd000b7f44753005ddf79823336", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    <div class=""flex-grow-1"">
                                        <h5><a href=""javascript:void(0)"" onclick=""GenerateRiskReport()"">Institutional Risk Profile</a></h5>
                                        <p class=""m-0 text-small text-muted"">This is an risk profile for the period</p>
                                      
                                    </div>
                                    <div>
                                       <a href=""javascript:void(0)"" onclick=""GenerateRiskReport()"" class=""btn btn-outline-primary mt-3 mb-3 m-sm-0 btn-rounded btn-sm"">
                                            View
                                            Report
                                        </a>
                                    </div>
                                </div>
                            
                            </div>
                        </div>



");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"








<script>

function GenerateFullReport() {
    var transid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraft?transid="" + transid;

    redirect_blank(url);
   


 
}

function GenerateSummaryReport() {
    var transid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraftSummary?transid="" + transid;

    redirect_blank(url);
   


 
}





function GenerateRiskReport() {
    var cycleid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraftRiskPDF?cycleid="" + cycleid;

    redirect_blank(url);
   


 
}

function GenerateMobilityReport() {
    var cycleid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraftMobilityPDF?cycleid="" + cycleid;

    redirect_blank(url);
   


 
}

function GenerateProcurementReport() {
    var cycleid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraftProcurementPDF?cycleid="" + cycleid;

    redirect_blank(url);
   


 
}

function Gene");
            WriteLiteral(@"rateCommunicationReport() {
    var cycleid = $(""#WPCycle_Id"").val();  

    var url=""/NEPADStaff/InstitutionalWorkplanDraftCommunicationPDF?cycleid="" + cycleid;

    redirect_blank(url);
   


 
}

function redirect_blank(url) {
  var a = document.createElement('a');
  a.target=""_blank"";
  a.href=url;
  a.click();
}

    
$(""#btnCloseStaffa"").click(function () {
    $("".k-window-content"").each(function () {
                $(this).data(""kendoWindow"").close();
            });
});



$(""#btnSubmita"").click(function () {
    var divid = $(""#Division_Id"").val();  
    var indicator_txt = $(""#Record_Name"").val();  
    var indicator_type = $(""#Indicator_Type_Ident"").val();  
    var recid = $(""#Employee_Id"").val();  

    if(divid === """" && typeof divid === ""string"")
    {
        $('#targetDivStaffa').empty();
        $('<span class=""alert alert-warning"" style=""display: block;font-size: 100%"">No Selection : Please select division. </span>').appendTo('.rssedStaffa');

    }
    else if (indicator_txt === """" && ty");
            WriteLiteral(@"peof indicator_txt === ""string"")
    {
        $('#targetDivStaffa').empty();
        $('<span class=""alert alert-warning"" style=""display: block;font-size: 100%"">Please provide the text for the indicator. </span>').appendTo('.rssedStaffa');
    }
    else if (indicator_type === """" && typeof indicator_type === ""string"")
    {
        $('#targetDivStaffa').empty();
        $('<span class=""alert alert-warning"" style=""display: block;font-size: 100%"">Selection : Please select the type of indicator.  </span>').appendTo('.rssedStaffa');
    }
    else{
        $.ajax({
            type: ""POST"",
            url: '/Admin/AddDivisionKPI',     //your action
            data: $('#addform').serialize(),   //your form name.it takes all the values of model
            dataType: 'json',
            success: function (result) {
                var response = result.rtnmsg;

                if (response == ""success"") {
                            $('#targetDivStaffa').empty();
                            $('<span class=""alert ");
            WriteLiteral(@"alert-success"" style=""display: block;font-size: 100%"">Success : Indicator Saved Successfully. </span>').appendTo('.rssedStaffa');

                             
                            var grid = $(""#gridkpis"").data(""kendoGrid""); 

                            grid.dataSource.transport.options.read.url = ""/Admin/DivisionTransKPIs_Read/?recid="" + recid;
                            grid.dataSource.read();
                            grid.refresh();

                }
                else if (response == ""pkerror"") {
                        $('#targetDivStaffa').empty();
                        $('<span class=""alert alert-danger"" style=""display: block;font-size: 100%"">Error: Unable to Save. Indicator Already Exist.  Please use different options </span>').appendTo('.rssedStaffa');
                        //$('#targetDivStaffa').empty();
                }
                else if (response == ""createerror"") {
                        $('#targetDivStaffa').empty();
                        $('<span class=""alert ale");
            WriteLiteral(@"rt-danger"" style=""display: block;font-size: 100%"">Error: Unable to save indicator</span>').appendTo('.rssedStaffa');
                        //$('#targetDivStaffa').empty();
                }
                else if (response == ""doesnotexist"") {
                        $('#targetDivStaffa').empty();
                        $('<span class=""alert alert-danger"" style=""display: block;font-size: 100%"">No Record: Indicator does not exist</span>').appendTo('.rssedStaffa');
                        //$('#targetDivStaffa').empty();
                }
                else {
                        $('#targetDivStaffa').empty();
                        $('<span class=""alert alert-danger"" style=""display: block;font-size: 100%"">Unknown Error: Please try Again </span>').appendTo('.rssedStaffa');
                        //$('#targetDivStaffa').empty();
                }

            },
            error: function (data) {
                    $('#targetDivStaffa').empty();
                    $('<span class=""alert alert-dange");
            WriteLiteral("r\" style=\"display: block;font-size: 100%\">Error: Error Occurred whiles saving </span>\').appendTo(\'.rssedStaffa\');\n                    //$(\'#targetDivStaffa\').empty();\n            }\n        })\n    }\n    \n        return false;\n    });\n</script>\n\n\n\n\n\n\n\n\n\n\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WP_CycleVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
