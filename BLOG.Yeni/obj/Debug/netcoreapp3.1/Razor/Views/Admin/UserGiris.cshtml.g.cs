#pragma checksum "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de4c0cb3433d5b5902ee3610511418258aca9134"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserGiris), @"mvc.1.0.view", @"/Views/Admin/UserGiris.cshtml")]
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
#line 1 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\_ViewImports.cshtml"
using BLOG.Yeni;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\_ViewImports.cshtml"
using BLOG.Yeni.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de4c0cb3433d5b5902ee3610511418258aca9134", @"/Views/Admin/UserGiris.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0432d9a464dbe8a16b1dfc45bc386c01693cf184", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserGiris : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BLOG.Yeni.Models.kullaniciislem>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml"
  
    ViewData["Title"] = "UserGiris";
    Layout = "~/Views/Shared/_LayoutUserGiris.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-login100\" style=\"margin-top:-23px;\">\r\n    <div class=\"wrap-login100 p-t-30 p-b-30\">\r\n     \r\n            \r\n");
#nullable restore
#line 12 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml"
             using (Html.BeginForm("Girisyap", "Admin"))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <span class=\"login100-form-title p-b-40\">\r\n                    Giriş Yap\r\n                </span>\r\n");
            WriteLiteral("                <div class=\"wrap-input100 validate-input m-b-16\" data-validate=\"Please enter email: ex@abc.xyz\">\r\n\r\n                    ");
#nullable restore
#line 20 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml"
               Write(Html.TextBoxFor(x => x.kullanici, new { @placeholder = "Email veya Kullanıcı Adı", @class = "input100", @type = "email", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <span class=\"focus-input100\"></span>\r\n                </div>\r\n");
            WriteLiteral(@"                <div class=""wrap-input100 validate-input m-b-20"" data-validate=""Please enter password"">
                    <span class=""btn-show-pass"">
                        <i class=""fa fa fa-eye""></i>
                    </span>

                    ");
#nullable restore
#line 29 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml"
               Write(Html.PasswordFor(x => x.password, new { @placeholder = "Password", @class = "input100", @type = "password", @required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <span class=\"focus-input100\"></span>\r\n                </div>\r\n");
            WriteLiteral("                <div class=\"container-login100-form-btn\">\r\n                    <button class=\"login100-form-btn\">\r\n                        Giriş Yap\r\n                    </button>\r\n                </div>\r\n");
#nullable restore
#line 38 "C:\Users\sumey\source\repos\BLOG\BLOG.Yeni\Views\Admin\UserGiris.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       \r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BLOG.Yeni.Models.kullaniciislem> Html { get; private set; }
    }
}
#pragma warning restore 1591
