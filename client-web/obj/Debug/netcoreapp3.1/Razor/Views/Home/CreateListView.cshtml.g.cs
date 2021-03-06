#pragma checksum "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40a8d83c9530760fa9d4a7890530b254d13d4b8d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreateListView), @"mvc.1.0.view", @"/Views/Home/CreateListView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40a8d83c9530760fa9d4a7890530b254d13d4b8d", @"/Views/Home/CreateListView.cshtml")]
    public class Views_Home_CreateListView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<client_web.Models.ListModel>
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
#line 2 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a8d83c9530760fa9d4a7890530b254d13d4b8d2943", async() => {
                WriteLiteral(@"
    <title>Create List</title>
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
            float: left;
        }

        .dropdown .dropbtn {
            fon");
                WriteLiteral(@"t-size: 16px;
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40a8d83c9530760fa9d4a7890530b254d13d4b8d5998", async() => {
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
#line 96 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
         using (Html.BeginForm(FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div class=\"bs-example\" style=\"border:2px solid gray;\">\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Title: </label>\r\n                    ");
#nullable restore
#line 101 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
               Write(Html.EditorFor(model => model.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 102 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
               Write(Html.ValidationMessageFor(model => model.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group centerlook\">\r\n                    <label>Description: </label>\r\n                    ");
#nullable restore
#line 106 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
               Write(Html.EditorFor(model => model.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
#nullable restore
#line 107 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
               Write(Html.ValidationMessageFor(model => model.Description));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
                <div class=""loginbtn"">
                    <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
                </div>
                <div class=""loginbtn"">
                    <input type=""button"" class=""btn btn-primary"" value=""Cancel""");
                BeginWriteAttribute("onclick", " onclick=\"", 3636, "\"", 3710, 2);
#nullable restore
#line 113 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
WriteAttributeValue("", 3646, "window.location.href='" + @Url.Action("List", "Home") + "'", 3646, 63, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 3709, ";", 3709, 1, true);
                EndWriteAttribute();
                WriteLiteral(" />\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 116 "D:\Sem. 3\Projv2\HouseManager\client-web\Views\Home\CreateListView.cshtml"
        }

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<client_web.Models.ListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
