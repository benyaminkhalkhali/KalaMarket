#pragma checksum "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cbe30db05c77e7013a2cc23427a2f71e71cb4d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ShowAllProductForBasket), @"mvc.1.0.view", @"/Views/Product/ShowAllProductForBasket.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cbe30db05c77e7013a2cc23427a2f71e71cb4d0", @"/Views/Product/ShowAllProductForBasket.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6729dc1c0c12b5b1d63c59e8ca690affbda5bcf5", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ShowAllProductForBasket : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShowBasketVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CssSite/Js/vendor/jquery-3.2.1.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""header-cart-basket"">
    <a href=""#"" class=""cart-basket-box"">
        <span class=""icon-cart"">
            <i class=""mdi mdi-cart""></i>
        </span>
        <span class=""title-cart"">?????? ????????</span>
        <span class=""price-cart"">
            ");
#nullable restore
#line 13 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
       Write(Model.First().TotalBasket);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <span>??????????</span>\r\n        </span>\r\n        <span class=\"count-cart\">");
#nullable restore
#line 16 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
                            Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n    </a>\r\n    <div class=\"widget-shopping-cart\">\r\n        <div class=\"widget-shopping-cart-content\">\r\n            <ul class=\"product-list-widget\">\r\n");
#nullable restore
#line 21 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <li class=""mini-cart-item"">
                        <div class=""mini-cart-item-content"">
                            <a href=""#"" class=""mini-cart-item-close"">
                                <i class=""fa fa-trash""></i>
                            </a>
                            <a href=""#"" class=""mini-cart-item-image d-block"">
                                <img");
            BeginWriteAttribute("src", " src=\"", 1067, "\"", 1110, 2);
            WriteAttributeValue("", 1073, "/CssSite/ImageSite/", 1073, 19, true);
#nullable restore
#line 29 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
WriteAttributeValue("", 1092, item.ProductImage, 1092, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </a>\r\n                            <span class=\"product-name-card\">");
#nullable restore
#line 31 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
                                                       Write(item.ProductFaTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            <div class=""variation"">
                            </div>
                            <div class=""quantity mt-3"">
                                <span class=""quantity-Price-amount"">
                                    ");
#nullable restore
#line 36 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
                               Write(item.MainPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <span>??????????</span>\r\n                                </span>\r\n                            </div>\r\n                        </div>\r\n                    </li>\r\n");
#nullable restore
#line 42 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </ul>\r\n            <div class=\"mini-card-total\">\r\n                <strong>???????? ???? : </strong>\r\n                <span class=\"price-total\">\r\n                    ");
#nullable restore
#line 49 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Views/Product/ShowAllProductForBasket.cshtml"
               Write(Model.First().TotalBasket);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <span>??????????</span>\r\n                </span>\r\n            </div>\r\n            <div class=\"mini-card-button\">\r\n                <a href=\"/basket\" class=\"view-card\">???????????? ?????? ????????</a>\r\n");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0cbe30db05c77e7013a2cc23427a2f71e71cb4d08344", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShowBasketVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
