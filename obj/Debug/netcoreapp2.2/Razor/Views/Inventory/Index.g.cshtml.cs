#pragma checksum "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "211508e96b9d47e65d595604b7a3e3a293c1430d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inventory_Index), @"mvc.1.0.view", @"/Views/Inventory/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Inventory/Index.cshtml", typeof(AspNetCore.Views_Inventory_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "c:\Users\MiiNRea\Desktop\sproject\Views\_ViewImports.cshtml"
using sproject;

#line default
#line hidden
#line 2 "c:\Users\MiiNRea\Desktop\sproject\Views\_ViewImports.cshtml"
using sproject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"211508e96b9d47e65d595604b7a3e3a293c1430d", @"/Views/Inventory/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb6db91a464338634b626bcf055f7479d45db7f3", @"/Views/_ViewImports.cshtml")]
    public class Views_Inventory_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<sproject.Models.Inventory>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(47, 289, true);
            WriteLiteral(@"
<p>
   <h4>Inventory Balance</h4>
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                Product name
            </th>
            <th>
                Quantity
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 19 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(368, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(417, 47, false);
#line 22 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.product_name));

#line default
#line hidden
            EndContext();
            BeginContext(464, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(520, 46, false);
#line 25 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.invento_qty));

#line default
#line hidden
            EndContext();
            BeginContext(566, 95, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <!-- <a asp-action=\"Edit\" asp-route-id=\"");
            EndContext();
            BeginContext(662, 17, false);
#line 28 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
                                                   Write(item.inventory_id);

#line default
#line hidden
            EndContext();
            BeginContext(679, 68, true);
            WriteLiteral("\">Edit</a> |\r\n                <a asp-action=\"Details\" asp-route-id=\"");
            EndContext();
            BeginContext(748, 17, false);
#line 29 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
                                                 Write(item.inventory_id);

#line default
#line hidden
            EndContext();
            BeginContext(765, 70, true);
            WriteLiteral("\">Details</a> |\r\n                <a asp-action=\"Delete\" asp-route-id=\"");
            EndContext();
            BeginContext(836, 17, false);
#line 30 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
                                                Write(item.inventory_id);

#line default
#line hidden
            EndContext();
            BeginContext(853, 52, true);
            WriteLiteral("\">Delete</a> -->\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 33 "c:\Users\MiiNRea\Desktop\sproject\Views\Inventory\Index.cshtml"
}

#line default
#line hidden
            BeginContext(908, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<sproject.Models.Inventory>> Html { get; private set; }
    }
}
#pragma warning restore 1591
