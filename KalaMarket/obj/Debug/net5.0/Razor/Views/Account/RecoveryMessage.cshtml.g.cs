#pragma checksum "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Account/RecoveryMessage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba882ea9a23839e69993fa7601f15a4547917f1f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_RecoveryMessage), @"mvc.1.0.view", @"/Views/Account/RecoveryMessage.cshtml")]
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
#line 4 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/_ViewImports.cshtml"
using KalaMarket.DataLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/_ViewImports.cshtml"
using KalaMarket.Core.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/_ViewImports.cshtml"
using KalaMarket.DataLayer.Entities.ProductEntities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/_ViewImports.cshtml"
using KalaMarket.TagHelper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba882ea9a23839e69993fa7601f15a4547917f1f", @"/Views/Account/RecoveryMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6729dc1c0c12b5b1d63c59e8ca690affbda5bcf5", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_RecoveryMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-account text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Account/RecoveryMessage.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"fa\" dir=\"rtl\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba882ea9a23839e69993fa7601f15a4547917f1f4817", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>?????????????? ???????? ????????</title>
    <!-- font---------------------------------------->
    <link rel=""stylesheet"" href=""/CssSite/Css/vendor/font-awesome.min.css"">
    <link rel=""stylesheet"" href=""/CssSite/Css/vendor/materialdesignicons.css"">
    <!-- plugin-------------------------------------->
    <link rel=""stylesheet"" href=""/CssSite/Css/vendor/bootstrap.css"">
    <link rel=""stylesheet"" href=""/CssSite/Css/vendor/owl.carousel.min.css"">
    <link rel=""stylesheet"" href=""/CssSite/Css/vendor/noUISlider.min.css"">
    <!-- main-style---------------------------------->
    <link rel=""stylesheet"" href=""/CssSite/Css/main.css"">
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba882ea9a23839e69993fa7601f15a4547917f1f6545", async() => {
                WriteLiteral(@"

    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg"">
                <section class=""page-account-box"">
                    <div class=""col-lg-6 col-md-6 col-xs-12 mx-auto"">
                        <div class=""ds-userlogin"">
                            <a href=""#"" class=""account-box-logo"">digismart</a>
                            <div class=""account-box"">
                                <div class=""Login-to-account mt-4"">
                                    <div class=""account-box-content"">
                                        <h4 class=""mb-2"">?????????????? ?????????? ???????? ????????</h4>
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba882ea9a23839e69993fa7601f15a4547917f1f7493", async() => {
                    WriteLiteral(@"
                                            <div class=""user-account-welcome"">
                                                <img src=""/CssSite/ImageSite/man.png"">
                                            </div>
                                            <div class=""made-account"">
                                                <h2>?????? ???????? ???????? ????????</h2>
                                                <p>
                                                    ???? ?????????? ???????? ?????? ???????? ???????? ???????? ???? ?????????? ");
#nullable restore
#line 41 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Account/RecoveryMessage.cshtml"
                                                                                         Write(Model);

#line default
#line hidden
#nullable disable
                    WriteLiteral(@" ?????????? ?????????? .
                                                </p>
                                            </div>
                                            <div class=""form-row-account"">
                                                <a href=""/"" class=""btn btn-primary btn-login"">?????????? ???? ????????</a>
                                            </div>
                                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </div>
    </div>
    <!-- login----------------------------------->
    <!-- scroll_Progress------------------------->
    <div class=""progress-wrap"">
        <svg class=""progress-circle svg-content"" width=""100%"" height=""100%"" viewBox=""-1 -1 102 102"">
            <path d=""M50,1 a49,49 0 0,1 0,98 a49,49 0 0,1 0,-98"" />
        </svg>
    </div>
    <!-- scroll_Progress------------------------->
    <script src=""/CssSite/JS/vendor/jquery-3.2.1.min.js""></script>
    <script src=""/CssSite/JS/vendor/bootstrap.js""></script>
    <!-- plugin----------------------------------------------------->
    <script src=""/CssSite/JS/vendor/owl.carousel.min.js""></script>
    <script src=""/CssSite/JS/vendor/jquery.countdown.js""></script>
    <script src=""/CssSite/JS/vendor/Resize");
                WriteLiteral(@"Sensor.min.js""></script>
    <script src=""/CssSite/JS/vendor/theia-sticky-sidebar.min.js""></script>
    <script src=""/CssSite/JS/vendor/wNumb.js""></script>
    <script src=""/CssSite/JS/vendor/nouislider.min.js""></script>
    <!-- main js---------------------------------------------------->
    <script src=""/CssSite/JS/main.js""></script>
");
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
            WriteLiteral("\r\n<!-- file js---------------------------------------------------->\r\n\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
