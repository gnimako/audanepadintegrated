#pragma checksum "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31f9c2590f4c562d09e83ec07f68d7d9c44ab61e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NEPADStaff_MtpPriortyMapping), @"mvc.1.0.view", @"/Views/NEPADStaff/MtpPriortyMapping.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31f9c2590f4c562d09e83ec07f68d7d9c44ab61e", @"/Views/NEPADStaff/MtpPriortyMapping.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d35ea56c2d14dc1962e146e0310b25b93790e3", @"/Views/_ViewImports.cshtml")]
    public class Views_NEPADStaff_MtpPriortyMapping : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("k-textbox"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("addformmain"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
  
    ViewBag.Title = "AUDA-NEPAD Integrated Planning System";
    Layout = "_NEPADStaffLayout2";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<h1 style=""font-family: Faktslab;"">AUC MTP Mappings</h1>
<div class=""separator-breadcrumb border-top""></div>


<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card mb-5"">
            <div class=""card-body"">
                <div class=""card-title mb-3"">MTP Mappings</div>

                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31f9c2590f4c562d09e83ec07f68d7d9c44ab61e6363", async() => {
                WriteLiteral("\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "31f9c2590f4c562d09e83ec07f68d7d9c44ab61e6633", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 21 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdentityUserId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 21 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
                                                                                       WriteLiteral(Model.IdentityUserId);

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
                WriteLiteral("\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "31f9c2590f4c562d09e83ec07f68d7d9c44ab61e9472", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 22 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Employee_Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
                                                                                        WriteLiteral(Model.Id);

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
                WriteLiteral("\n\n                    <div class=\"form-group row\" style=\"padding-right: 1.25rem; padding-left: 1.25rem; padding-top: 1.25rem; padding-bottom: 0.25rem;\">\n                    ");
#nullable restore
#line 25 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
                Write(Html.Kendo().DropDownList()
                                    .Name("MTP_Id")
                                    .HtmlAttributes(new { style = "width:60%" })
                                    .OptionLabel("Select MTP Priority...")
                                    .DataTextField("DropDown_Name")
                                    .DataValueField("DropDown_IntId")
                                    .Events(e =>
                                    {
                                        e.Close("onDropDownChange");
                                    })
                                    .DataSource(source =>
                                    {
                                        source.Read(read =>
                                        {
                                            read.Action("GetAllTransMTPPriorities", "Admin");
                                        });
                                    })
                                    // .SelectedIndex(Model.Directorate_Id)
                    );

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                  \n                    </div>\n                    <div class=\"form-group row\" style=\"padding-right: 1.25rem; padding-left: 1.25rem; padding-bottom: 0.25rem;\">\n                        ");
#nullable restore
#line 47 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
                    Write(Html.Kendo().DropDownListFor(model => model.Priority_Id)
                                            // .Name("Department_Id")
                                            .HtmlAttributes(new { style = "width:60%", id = "Priority_Id" })
                                            .OptionLabel("Select AUDA-NEPAD Priority...")
                                            .DataTextField("DropDown_Name")
                                            .DataValueField("DropDown_IntId")
                                            .DataSource(source =>
                                            {
                                                source.Read(read =>
                                                {
                                                        read.Action("GetTransStrategicPriorities", "Admin")
                                                        .Data("filterProducts");
                                                })
                                                .ServerFiltering(true);
                                            })
                                            .Enable(false)
                                            .AutoBind(false)
                                            .CascadeFrom("MTP_Id")
                                            //.SelectedIndex(Model.Department_Id)
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                        <script>function filterProducts() {
                                return {
                                    mtp_ident: $(""#MTP_Id"").val()
                                };
                            }</script>

                        &nbsp; &nbsp;

                        <a class=""k-button "" id=""btnAdd"" style=""color: #003f59;"">
                                        <span class=""k-icon k-i-plus-outline""></span> Map AUDA-NEPAD Priority
                        </a>

                    </div>
                    <div class=""form-group row"" style=""padding-right: 1.25rem; padding-left: 1.25rem; padding-bottom: 1.25rem;"">
                          
                        ");
#nullable restore
#line 82 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/MtpPriortyMapping.cshtml"
                    Write(Html.Kendo().Grid<StrategyPriorityViewModel>()
                                        .Name("grid")
                                        .Columns(columns =>
                                        {

                                            columns.Bound(c => c.Priority_Id).Hidden();
                                            columns.Bound(c => c.MTPPriority_Id).Hidden();
                                            columns.Bound(c => c.Transaction_Id).Hidden();
                                            columns.Bound(c => c.Priority_Name).Title("AUDA-NEPAD Strategic Priority");
                                            columns.Bound(c => c.TransactionDate).Title("Transaction Date").Format("{0: dd-MM-yyyy}");
                                            columns.Command(command => { command.Destroy().Text(" Delete").IconClass("k-icon k-i-delete"); });
                                        })
                                        .HtmlAttributes(new { style = "height: 400px;" })
                                        .Scrollable()
                                        .Groupable()
                                        .Sortable()
                                        .Navigatable()
                                        .Filterable()
                                        .Pageable(pageable => pageable
                                            .Refresh(true)
                                            .PageSizes(true)
                                            .ButtonCount(5))
                                        .DataSource(dataSource => dataSource
                                            .Ajax()
                                            .Sort(sort => sort.Add("Priority_Name").Ascending())
                                            .Read(read => read
                                                            .Action("MTPPriorityMapping_Read", "Admin"))
                                            .Model(model => model.Id(p => p.Transaction_Id))
                                            .Destroy(destroy => destroy.Action("Strategy_MTPStrategyMapping_Delete", "Admin"))
                                            .PageSize(20)
                                            .Events(events => events.Error("error_handler")
                                                                .RequestEnd("onRequestEnd"))
                                        )
                                    );

#line default
#line hidden
#nullable disable
                WriteLiteral("\n                    </div>\n\n        \n                    \n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>




<br \>
<br \>
<br \>


<div id=""getstaffwindow"">
</div>
<div id=""windowstaff""></div>
<div id=""staffposwindow"">
</div>
<div id=""windowstaffpos"">
</div>

<div id=""example"">
    <div id=""dialog"">
    </div>
    <div id=""undo"">
    </div>
</div>









<script type=""text/javascript""> 
    function error_handler(e) {    
        if (e.errors) {
            var message = ""Errors:\n"";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function() {
                        message += this + ""\n"";
                    });
                }
            });        
            alert(message);
        }
    }

    function onRequestEnd(e){
            var recid = $(""#MTP_Id"").val();  
            if (e.type === ""update"" || e.type === ""create"" || e.type === ""destroy"" ) {
               
                var grid = $(""#grid"").data(""kendoGrid""); 

                grid.dataSource.transpo");
            WriteLiteral(@"rt.options.read.url = ""/Admin/MTPPriorityMapping_Read/?recid="" + recid;
                grid.dataSource.read();
            }
    }
    
    function onDropDownChange()  
    {  
        var recid = $(""#MTP_Id"").val();  
        var grid = $(""#grid"").data(""kendoGrid""); 

        grid.dataSource.transport.options.read.url = ""/Admin/MTPPriorityMapping_Read/?recid="" + recid;
        grid.dataSource.read();

    }




   $(""#btnAdd"").click(function () {

 // e.preventDefault();
        var mtpid = $(""#MTP_Id"").val();  
        var priorityid = $(""#Priority_Id"").val(); 


        var dialog = $('#dialog');
        var undo = $(""#undo"");

        function onClose() {
            undo.fadeIn();
        }

        if(mtpid === """" && typeof mtpid === ""string"")
        {
              dialog.kendoDialog({
                  width: ""300px"",
                  title: ""No Selection"",
                  closable: false,
                  modal: true,
                  content: ""<p>Please select <strong>MTP Priority</strong><p");
            WriteLiteral(@">"",
                  actions: [
                      { text: 'Cancel' }
                  ],
                  close: onClose
              });

              dialog.data(""kendoDialog"").open();
              undo.fadeOut();
        }
        else if (priorityid === """" && typeof priorityid === ""string"")
        {
              dialog.kendoDialog({
                  width: ""300px"",
                  title: ""No Selection"",
                  closable: false,
                  modal: true,
                  content: ""<p>Please select <strong>AUDA-NEPAD Priority</strong><p>"",
                  actions: [
                      { text: 'Cancel' }
                  ],
                  close: onClose
              });

              dialog.data(""kendoDialog"").open();
              undo.fadeOut();
        }
        else{
            $.ajax({
                type: ""POST"",
                url: '/Admin/MappMTPAUDAPriority',     //your action
                data: $('#addformmain').serialize(),   //your form name.it take");
            WriteLiteral(@"s all the values of model
               // data: { ""dirid"": dirid, ""empid"": empid, ""primaryid"": primaryid},   //your form name.it takes all the values of model
                dataType: 'json',
                success: function (result) {
                    var response = result.rtnmsg;

                    if (response == ""success"") {

                                var grid = $(""#grid"").data(""kendoGrid""); 

                                grid.dataSource.transport.options.read.url = ""/Admin/MTPPriorityMapping_Read/?recid="" + mtpid;
                                grid.dataSource.read();
                                grid.refresh();

                    }
                    else if (response == ""alreadyexist"") {
                                dialog.kendoDialog({
                                    width: ""300px"",
                                    title: ""Already Exist"",
                                    closable: false,
                                    modal: true,
                            ");
            WriteLiteral(@"        content: ""<p>Mapping Aready Exist.<p>"",
                                    actions: [
                                        { text: 'Cancel' }
                                    ],
                                    close: onClose
                                });

                                dialog.data(""kendoDialog"").open();
                                undo.fadeOut();
                    }
                    else {

                                dialog.kendoDialog({
                                    width: ""300px"",
                                    title: ""Error"",
                                    closable: false,
                                    modal: true,
                                    content: ""<p>Error: Please try Again<p>"",
                                    actions: [
                                        { text: 'Cancel' }
                                    ],
                                    close: onClose
                                });

        ");
            WriteLiteral(@"                        dialog.data(""kendoDialog"").open();
                                undo.fadeOut();
                    }

                },
                error: function (data) {
                                dialog.kendoDialog({
                                    width: ""300px"",
                                    title: ""Error"",
                                    closable: false,
                                    modal: true,
                                    content: ""<p>Error Occurred whiles saving<p>"",
                                    actions: [
                                        { text: 'Cancel' }
                                    ],
                                    close: onClose
                                });

                                dialog.data(""kendoDialog"").open();
                                undo.fadeOut();
                }
            })
        }
        return false;

   });
</script>


<style>
    /* Page Template for the exported PDF */
    .p");
            WriteLiteral(@"age-template {
        font-family: ""DejaVu Sans"", ""Arial"", sans-serif;
        position: absolute;
        width: 100%;
        height: 100%;
        top: 0;
        left: 0;
    }

        .page-template .header {
            position: absolute;
            top: 30px;
            left: 30px;
            right: 30px;
            border-bottom: 1px solid #888;
            color: #888;
        }

        .page-template .footer {
            position: absolute;
            bottom: 30px;
            left: 30px;
            right: 30px;
            border-top: 1px solid #888;
            text-align: center;
            color: #888;
        }

        .page-template .watermark {
            font-weight: bold;
            font-size: 400%;
            text-align: center;
            margin-top: 30%;
            color: #aaaaaa;
            opacity: 0.1;
            transform: rotate(-35deg) scale(1.7, 1.5);
        }

    /* Content styling */
    .customer-photo {
        display: inline-block;
        width: 32px;
");
            WriteLiteral(@"        height: 32px;
        border-radius: 50%;
        background-size: 32px 35px;
        background-position: center center;
        vertical-align: middle;
        line-height: 32px;
        box-shadow: inset 0 0 1px #999, inset 0 0 10px rgba(0,0,0,.2);
        margin-left: 5px;
    }

    .customer-name {
        display: inline-block;
        vertical-align: middle;
        line-height: 32px;
        padding-left: 3px;
    }
</style>

<style>

/*SWITCH ON*/

    .k-switch-on .k-switch-container {
        border-color: #13ad28;
        color: #c5fcd4;
        background-color: #c5fcd4;
    }

    .k-switch-on .k-switch-handle {
        border-color: #13ad28;
        color: #fff;
        background-color: #13ad28
    }

    .k-switch-on:hover .k-switch-container {
        border-color: #13ad28;
        color: #c5fcd4;
        background-color: #c5fcd4;
    }

    .k-switch-on:hover .k-switch-handle {
        border-color: #13ad28;
        color: #fff;
        background-color: #13ad28;
    }


    .k-sw");
            WriteLiteral(@"itch-on:active .k-switch-container {
        border-color: #13ad28;
        color: #c5fcd4;
        background-color: #c5fcd4
    }

    .k-switch-on:active .k-switch-handle {
        border-color: #13ad28;
        color: #fff;
        background-color: #13ad28
    }



    .k-switch-on:visited .k-switch-container {
        border-color: #13ad28;
        color: #c5fcd4;
        background-color: #c5fcd4;
    }

    .k-switch-on:visited .k-switch-handle{
        border-color: #13ad28;
        color: #fff;
        background-color: #13ad28;
    }


    .k-switch-on:focus .k-switch-container {
        border-color: #13ad28;
        color: #c5fcd4;
        background-color: #c5fcd4;
    }

    .k-switch-on:focus .k-switch-handle {
        border-color: #13ad28;
        color: #fff;
        background-color: #13ad28;
    }




    /*SWITCH OFF*/

    .k-switch-off .k-switch-container {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #fff;
    }

    .k-switch-off .k-switch-handle {
  ");
            WriteLiteral(@"      border-color: #c5c7c9;
        color: #fff;
        background-color: #c5c7c9;
    }



    .k-switch-off:hover .k-switch-container {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #fff;
    }

    .k-switch-off:hover .k-switch-handle {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #c5c7c9;
    }


    .k-switch-off:active .k-switch-container {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #fff;
    }

    .k-switch-off:active .k-switch-handle {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #c5c7c9;
    }


    .k-switch-off:visited .k-switch-container {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #fff;
    }

    .k-switch-off:visited .k-switch-handle {
        border-color: #c5c7c9;
        color: #fff;
        background-color: #c5c7c9;
    }

    .k-switch-off:focus .k-switch-container {
        border-color: #c5c7c9;
        color: #fff;
  ");
            WriteLiteral("      background-color: #fff;\n    }\n\n    .k-switch-off:focus .k-switch-handle {\n        border-color: #c5c7c9;\n        color: #fff;\n        background-color: #c5c7c9;\n    }\n\n\n\n</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
