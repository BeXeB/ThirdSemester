#pragma checksum "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5ff52c236c3c3fd1e5dc6ae2ae783251b9bc1aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_HomeView), @"mvc.1.0.view", @"/Views/Home/HomeView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5ff52c236c3c3fd1e5dc6ae2ae783251b9bc1aa", @"/Views/Home/HomeView.cshtml")]
    public class Views_Home_HomeView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<client_web.Models.HouseModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5ff52c236c3c3fd1e5dc6ae2ae783251b9bc1aa2912", async() => {
                WriteLiteral(@"
        <title>Home</title>
        <meta charset=""utf-8"">
        <meta name=""viewport"" content=""width=device-width, initial-scale=1"">

        <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"">
        <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"">
        <script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js""></script>
        <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
        <style>
            .navbar {
                background-color: #333;
                background-color: #333;
                font-family: Arial;
            }

            .navbar a {
                float: left;
                font-size: 16px;
                color: white;
                text-align: center;
                padding: 14px 16px;
                text-decoration: none;
            }

            .dropdown {
   ");
                WriteLiteral(@"             float: left;
            }

            .dropdown .dropbtn {
                font-size: 16px;
                border: none;
                outline: none;
                color: white;
                padding: 14px 16px;
                background-color: inherit;
                font-family: inherit;
                margin: 0;
            }

            .navbar a:hover, .dropdown:hover .dropbtn {
                background-color: red;
            }

            .dropdown-content {
                display: none;
                position: absolute;
                background-color: #f9f9f9;
                min-width: 160px;
                box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
                z-index: 1;
            }

            .dropdown-content a {
                float: none;
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
                text-align: left;
        ");
                WriteLiteral("    }\r\n\r\n            .dropdown-content a:hover {\r\n                background-color: #ddd;\r\n            }\r\n\r\n            .dropdown:hover .dropdown-content {\r\n                display: block;\r\n            }\r\n        </style>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5ff52c236c3c3fd1e5dc6ae2ae783251b9bc1aa6263", async() => {
                WriteLiteral(@"
        <header>
            <div class=""navbar"">
                <a href=""/home"">Home</a>
                <div class=""dropdown"">
                    <button class=""dropbtn"">Dropdown</button>
                    <div class=""dropdown-content"">
                        <a href=""/account"">Account</a>
                        <a href=""/createhouse"">Create House</a>
                        <a href=""/joinhouse"">Join House</a>
                        <a href=""/list"">Lists</a>
                        <a href=""/logout"">Logout</a>
                    </div>
                </div>
            </div>
        </header>


");
#nullable restore
#line 98 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
         foreach (client_web.Models.HouseModel item in ViewBag.list)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"card\">\r\n                <h5 class=\"card-title\">");
#nullable restore
#line 101 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                  Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                <label class=\"card-label\">");
#nullable restore
#line 102 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.InviteCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 103 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.ZipCode);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 104 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.City);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 105 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.Street);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 106 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.HouseNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 107 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.Floor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <label class=\"card-label\">");
#nullable restore
#line 108 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
                                     Write(item.DoorNo);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                <br>\r\n                <input type=\"button\" class=\"btn btn-primary\" value=\"Leave\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3747, "\"", 3833, 2);
#nullable restore
#line 110 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
WriteAttributeValue("", 3757, "window.location.href='" + @Url.Action("LeaveHouse", "Home", item) + "'", 3757, 75, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3832, ";", 3832, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"button\" class=\"btn btn-primary\" value=\"Chat\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3912, "\"", 3992, 2);
#nullable restore
#line 111 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
WriteAttributeValue("", 3922, "window.location.href='" + @Url.Action("Chat", "Home", item) + "'", 3922, 69, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3991, ";", 3991, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                <input type=\"button\" class=\"btn btn-primary\" value=\"Chore\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4072, "\"", 4153, 2);
#nullable restore
#line 112 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
WriteAttributeValue("", 4082, "window.location.href='" + @Url.Action("Chore", "Home", item) + "'", 4082, 70, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4152, ";", 4152, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            </div>\r\n");
#nullable restore
#line 114 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\HomeView.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<client_web.Models.HouseModel> Html { get; private set; }
    }
}
#pragma warning restore 1591