#pragma checksum "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed58dbff3d8d3214a2c17aa4e0961d6dc9bda640"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cuenta_Login), @"mvc.1.0.view", @"/Views/Cuenta/Login.cshtml")]
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
#line 1 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\_ViewImports.cshtml"
using TestCrudAmedia;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\_ViewImports.cshtml"
using TestCrudAmedia.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\_ViewImports.cshtml"
using TestCrudAmedia.Models.DB;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\_ViewImports.cshtml"
using TestCrudAmedia.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed58dbff3d8d3214a2c17aa4e0961d6dc9bda640", @"/Views/Cuenta/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32dda6ea95a3f01157ac29ba971b3d173a8b3629", @"/Views/_ViewImports.cshtml")]
    public class Views_Cuenta_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
  

    using (Html.BeginForm("Login", "Cuenta", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 8 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.LabelFor(m => m.user));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 9 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.TextBoxFor(m => m.user, new { @class = "form-control input-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 10 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.ValidationMessageFor(m => m.user, null, new { @class = "help-block" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 13 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.LabelFor(m => m.pass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 14 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.PasswordFor(m => m.pass, new { @class = "form-control input-lg" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 15 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
       Write(Html.ValidationMessageFor(m => m.pass, null, new { @class = "help-block" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 17 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
   Write(Html.HiddenFor(m => m.returnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input type=\"hidden\" name=\"returnUrl\" id=\"returnUrl\"");
            BeginWriteAttribute("value", " value=\"", 768, "\"", 798, 1);
#nullable restore
#line 19 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
WriteAttributeValue("", 776, ViewData["ReturnUrl"], 776, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
            WriteLiteral("        <button type=\"submit\" id=\"buttonLogin\" class=\"btn btn-primary btn-lg btn-block\">Ingresar</button>\r\n");
#nullable restore
#line 22 "C:\Users\mau_n\source\repos\TestCrudAmedia\TestCrudAmedia\Views\Cuenta\Login.cshtml"
    }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
