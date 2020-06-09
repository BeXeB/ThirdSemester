#pragma checksum "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0017a870ea3eac262a1e72914209338e49326c30"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AccountView), @"mvc.1.0.view", @"/Views/Home/AccountView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0017a870ea3eac262a1e72914209338e49326c30", @"/Views/Home/AccountView.cshtml")]
    public class Views_Home_AccountView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<client_web.Models.AccountModel>
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
#line 2 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0017a870ea3eac262a1e72914209338e49326c302932", async() => {
                WriteLiteral(@"
        <title>Account</title>
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
                WriteLiteral(@"                float: left;
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
                WriteLiteral("       }\r\n\r\n            .dropdown-content a:hover {\r\n                background-color: #ddd;\r\n            }\r\n\r\n            .dropdown:hover .dropdown-content {\r\n                display: block;\r\n            }\r\n        </style>\r\n    ");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0017a870ea3eac262a1e72914209338e49326c306286", async() => {
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
#line 97 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
         using (Html.BeginForm(FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"bs-example\" style=\"border:2px solid gray;\">\r\n                <div class=\"form-group centerlook\">\r\n                    <label>User Name: </label>\r\n                    ");
#nullable restore
#line 102 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.EditorFor(model => model.UserName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 103 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.ValidationMessageFor(model => model.UserName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>First Name: </label>\r\n                    ");
#nullable restore
#line 107 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.LabelFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Last Name: </label>\r\n                    ");
#nullable restore
#line 111 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.LabelFor(model => model.LastName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Phone: </label>\r\n                    ");
#nullable restore
#line 115 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.EditorFor(model => model.Phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 116 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.ValidationMessageFor(model => model.Phone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Email: </label>\r\n                    ");
#nullable restore
#line 120 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.EditorFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 121 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.ValidationMessageFor(model => model.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Old Password:</label>\r\n                    ");
#nullable restore
#line 125 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.EditorFor(model => model.OldPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 126 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.ValidationMessageFor(model => model.OldPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>New Password:</label>\r\n                    ");
#nullable restore
#line 130 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.EditorFor(model => model.NewPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 131 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
               Write(Html.ValidationMessageFor(model => model.NewPassword));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"loginbtn\">\r\n                    <input type=\"submit\" value=\"Change\" class=\"btn btn-primary\" />\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 137 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\AccountView.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<client_web.Models.AccountModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
