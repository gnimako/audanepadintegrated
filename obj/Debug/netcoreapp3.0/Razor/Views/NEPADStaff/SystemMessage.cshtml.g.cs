#pragma checksum "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/SystemMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6503bd8148d13a2d92e6c34a43940a0a111a45e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_NEPADStaff_SystemMessage), @"mvc.1.0.view", @"/Views/NEPADStaff/SystemMessage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6503bd8148d13a2d92e6c34a43940a0a111a45e5", @"/Views/NEPADStaff/SystemMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d35ea56c2d14dc1962e146e0310b25b93790e3", @"/Views/_ViewImports.cshtml")]
    public class Views_NEPADStaff_SystemMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/SystemMessage.cshtml"
  
    ViewBag.Title = "AUDA-NEPAD Integrated Planning System";
    Layout = "_NEPADStaffLayout2";


#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<h1 style=\"font-family: Faktslab;\">System Message</h1>\n\n<div class=\"separator-breadcrumb border-top\"></div>\n\n\n<div class=\"alert alert-warning\" role=\"alert\">\n    ");
#nullable restore
#line 15 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/NEPADStaff/SystemMessage.cshtml"
Write(Model.SystemMessageContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n</div>\n\n     \n\n\n");
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
