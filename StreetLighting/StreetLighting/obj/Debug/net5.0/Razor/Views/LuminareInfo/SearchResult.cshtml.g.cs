#pragma checksum "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "505ea0d99aace0269dc1a9a20f1875b3fc5b50b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LuminareInfo_SearchResult), @"mvc.1.0.view", @"/Views/LuminareInfo/SearchResult.cshtml")]
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
#nullable restore
#line 1 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\_ViewImports.cshtml"
using StreetLighting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\_ViewImports.cshtml"
using StreetLighting.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"505ea0d99aace0269dc1a9a20f1875b3fc5b50b1", @"/Views/LuminareInfo/SearchResult.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0becfbf8923c3a7e1fda70f63f612d5008b8257c", @"/Views/_ViewImports.cshtml")]
    public class Views_LuminareInfo_SearchResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<StreetLighting.Models.ViewModels.LuminareViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
   ViewData["Title"] = "Результат"; 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""table-wrapper"">
        <div class=""table-title"">
            <div>
                <div>
                    <span>Результат поиска</span>
                </div>
            </div>
        </div>
        <table class=""table table-hover"">
            <thead class=""bg-warning text-black"">
                <tr>
                    <th>
                        ");
#nullable restore
#line 18 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                   Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 21 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                   Write(Html.DisplayNameFor(model => model.LampType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 24 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                   Write(Html.DisplayNameFor(model => model.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                </tr>\r\n            </thead>\r\n            <tbody class=\"table-bordered border-dark\">\r\n");
#nullable restore
#line 29 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 33 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                       Write(Html.DisplayFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 36 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                       Write(Html.DisplayFor(model => item.LampType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 39 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                       Write(Html.DisplayFor(model => item.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 42 "C:\Users\coca\Desktop\current\StreetLighting\StreetLighting\Views\LuminareInfo\SearchResult.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<StreetLighting.Models.ViewModels.LuminareViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
