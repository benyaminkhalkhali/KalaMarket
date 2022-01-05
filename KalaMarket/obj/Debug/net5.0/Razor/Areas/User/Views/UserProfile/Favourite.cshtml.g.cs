#pragma checksum "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3ca075c28cc4cf67a68dcca25c6a21e11d7b4400"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_UserProfile_Favourite), @"mvc.1.0.view", @"/Areas/User/Views/UserProfile/Favourite.cshtml")]
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
#line 3 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/_ViewImports.cshtml"
using KalaMarket.DataLayer.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/_ViewImports.cshtml"
using KalaMarket.Core.ViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/_ViewImports.cshtml"
using KalaMarket.DataLayer.Entities.ProductEntities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3ca075c28cc4cf67a68dcca25c6a21e11d7b4400", @"/Areas/User/Views/UserProfile/Favourite.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b8e4fe441b3b9a0bba979eece7d0f373bcbc3f1", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_UserProfile_Favourite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShowFavouriteVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_SidebarUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    var information = ViewBag.information as InformationAccountVM;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- profile------------------------------->
<div class=""container-main"">
    <div class=""d-block"">
        <section class=""profile-home"">
            <div class=""col-lg"">
                <div class=""post-item-profile order-1 d-block"">
                    <div class=""col-lg-3 col-md-3 col-xs-12 pr"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3ca075c28cc4cf67a68dcca25c6a21e11d7b44004321", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 14 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = information;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <div class=""col-lg-9 col-md-9 col-xs-12 pl"">
                        <div class=""profile-content"">
                            <div class=""profile-stats"">
                                <div class=""table-favorites"">
                                    <table class=""table ns-table table-profile-favorites"">
                                        <thead>
                                            <tr>
                                                <th scope=""col"" width=""50""> </th>
                                                <th scope=""col"">نام محصول</th>
                                                <th scope=""col"">قیمت</th>
                                                <th class=""actions-th""></th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 30 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                             foreach (var item in Model)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                <tr>
                                                    <th scope=""row"">
                                                        <div class=""favorites-product-img"">
                                                            <img");
            BeginWriteAttribute("src", " src=\"", 1875, "\"", 1918, 2);
            WriteAttributeValue("", 1881, "/CssSite/ImageSite/", 1881, 19, true);
#nullable restore
#line 35 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
WriteAttributeValue("", 1900, item.ProductImage, 1900, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                            <div class=\"product-rate\">\r\n");
#nullable restore
#line 37 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                                                 for (int i = 1; i <= item.ProductStar; i++)
                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                    <i class=\"fa fa-star active\"></i>\r\n");
#nullable restore
#line 40 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            </div>
                                                        </div>
                                                    </th>
                                                    <td>
                                                        <a");
            BeginWriteAttribute("href", " href=\"", 2664, "\"", 2740, 4);
            WriteAttributeValue("", 2671, "/product/detail/", 2671, 16, true);
#nullable restore
#line 45 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
WriteAttributeValue("", 2687, item.ProductId, 2687, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2702, "/", 2702, 1, true);
#nullable restore
#line 45 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
WriteAttributeValue("", 2703, item.ProductFaTitle.Replace(" ","-"), 2703, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 45 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                                                                                                                   Write(item.ProductFaTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                    </td>
                                                    <td>
                                                        <span class=""amount"">
                                                            ");
#nullable restore
#line 49 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                                        Write(item.ProductPrice.ToString()=="0"?"ناموجود":
                                                            item.ProductPrice +" تومان ");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </span>
                                                    </td>
                                                    <td class=""text-left actions"">
                                                        <a href=""#"" class=""remove-product""><i class=""mdi mdi-close""></i></a>
                                                    </td>
                                                </tr>
                                                <tr class=""spacer""></tr>
");
#nullable restore
#line 58 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/User/Views/UserProfile/Favourite.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</div>
<!-- profile------------------------------->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShowFavouriteVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
