#pragma checksum "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fff02a63e91dc805cd68a531391f281e48ba169"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ChoreView), @"mvc.1.0.view", @"/Views/Home/ChoreView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fff02a63e91dc805cd68a531391f281e48ba169", @"/Views/Home/ChoreView.cshtml")]
    public class Views_Home_ChoreView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<client_web.Models.ChoreModel>
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
#line 2 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fff02a63e91dc805cd68a531391f281e48ba1692914", async() => {
                WriteLiteral(@"
    <title>Chat</title>
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">

    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css"">
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js""></script>
    <script src=""https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js""></script>
    <style>
        .navbar {
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

        .btnpls {
            font-size: 16px;
            border: none;
            outline: none;
            c");
                WriteLiteral(@"olor: white;
            padding: 14px 16px;
            background-color: inherit;
            font-family: inherit;
            margin: 0;
        }

            .btnpls:hover {
                background-color: red;
                color: white;
            }

        .dropdown {
            float: left;
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
  ");
                WriteLiteral(@"      }

            .dropdown-content a {
                float: none;
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
                text-align: left;
            }

                .dropdown-content a:hover {
                    background-color: #ddd;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }
    </style>
");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fff02a63e91dc805cd68a531391f281e48ba1696494", async() => {
                WriteLiteral("\r\n    <header>\r\n        <div class=\"navbar\">\r\n            <a href=\"/home\">Home</a>\r\n            <button class=\"btnpls\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2760, "\"", 2900, 2);
#nullable restore
#line 99 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
WriteAttributeValue("", 2770, "window.location.href='" + @Url.Action("CreateChore", "Home", new client_web.Models.HouseModel { Id = ViewBag.houseid }) + "'", 2770, 129, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2899, ";", 2899, 1, true);
                EndWriteAttribute();
                WriteLiteral(@">Create</button>
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
#line 113 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
     foreach (client_web.Models.ChoreModel item in ViewBag.list)
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"card\">\r\n            <h5 class=\"card-title\">");
#nullable restore
#line 116 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n            <label class=\"card-label\">");
#nullable restore
#line 117 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
                                 Write(item.Status);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n            <label class=\"card-label\">");
#nullable restore
#line 118 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
                                 Write(item.EndDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n            <label class=\"card-label\">");
#nullable restore
#line 119 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
                                 Write(item.Person);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n            <br>\r\n            <input type=\"button\" class=\"btn btn-primary\" value=\"Join\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3827, "\"", 3912, 2);
#nullable restore
#line 121 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
WriteAttributeValue("", 3837, "window.location.href='" + @Url.Action("JoinChore", "Home", item) + "'", 3837, 74, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3911, ";", 3911, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n            <input type=\"button\" class=\"btn btn-primary\" value=\"Edit\"");
                BeginWriteAttribute("onclick", " onclick=\"", 3987, "\"", 4072, 2);
#nullable restore
#line 122 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
WriteAttributeValue("", 3997, "window.location.href='" + @Url.Action("EditChore", "Home", item) + "'", 3997, 74, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4071, ";", 4071, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n        </div>\r\n");
#nullable restore
#line 124 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\ChoreView.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<client_web.Models.ChoreModel> Html { get; private set; }
    }
}
#pragma warning restore 1591