#pragma checksum "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/Shared/EditorTemplates/DatePickerTemplate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6272106f967e6d7c1b8517747609d63cf6fd118c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_DatePickerTemplate), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/DatePickerTemplate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6272106f967e6d7c1b8517747609d63cf6fd118c", @"/Views/Shared/EditorTemplates/DatePickerTemplate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37d35ea56c2d14dc1962e146e0310b25b93790e3", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_DatePickerTemplate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DateTime?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "/Users/gideonnimako/Library/Mobile Documents/com~apple~CloudDocs/DDrive/Projects/AUDANEPAD_Integrated/Views/Shared/EditorTemplates/DatePickerTemplate.cshtml"
Write(Html.Kendo().DatePickerFor(m => m)
    .Name("WPActualDateVM")
  .Format("0:MM/dd/yyyy")
);

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DateTime?> Html { get; private set; }
    }
}
#pragma warning restore 1591
