#pragma checksum "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0fd313a3484ebe046e3d3a8d0e6ea09be7a1a69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Product_ShowAllGalleries), @"mvc.1.0.view", @"/Areas/Admin/Views/Product/ShowAllGalleries.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0fd313a3484ebe046e3d3a8d0e6ea09be7a1a69", @"/Areas/Admin/Views/Product/ShowAllGalleries.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Product_ShowAllGalleries : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KalaMarket.DataLayer.Entities.ProductEntities.ProductGallery>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("140"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("130"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CssSite/Js/sweetAlert.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
  
    ViewData["Title"] = "ShowAllGalleries";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""col-sm-12"">
    <div class=""panel"">
        <div class=""panel-body"" style=""margin-top:5%;"">


            <div class=""editable-responsive"">
                <div id=""datatable-editable_wrapper"" class=""dataTables_wrapper form-inline dt-bootstrap no-footer"">

                    <div class=""row"">
                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <div class=""m-b-30"">
                                    <a");
            BeginWriteAttribute("href", " href=\"", 703, "\"", 749, 2);
            WriteAttributeValue("", 710, "/admin/product/AddGalleries/", 710, 28, true);
#nullable restore
#line 19 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
WriteAttributeValue("", 738, ViewBag.id, 738, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""addToTable"" class=""btn btn-primary waves-effect waves-light"">افزودن <i class=""fa fa-plus""></i></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-sm-12"">

");
#nullable restore
#line 25 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                             if (TempData["Result"] != null)
                            {
                                if (TempData["Result"].ToString() == "true")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-success alert-dismissable"">
                                        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">×</button>
                                        ثبت گالری با موفقیت انجام شد .
                                    </div>
");
#nullable restore
#line 33 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-danger alert-dismissable"">
                                        <button type=""button"" class=""close"" data-dismiss=""alert"" aria-hidden=""true"">×</button>
                                        خطادر انجام عملیات .
                                    </div>
");
#nullable restore
#line 40 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                }
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 43 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                             if (TempData["NotFoundSlider"] != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <script>

                                    setTimeout(function () {
                                        Swal.fire({
                                            position: 'top-end',
                                            icon: 'error',
                                            title: 'گالری با این مشخصات یافت نشد .',
                                            showConfirmButton: false,
                                            timer: 3000
                                        })
                                    }, 50)

                                </script>
");
#nullable restore
#line 58 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <table class=""table table-striped dataTable no-footer"" id=""datatable-editable"" role=""grid"" aria-describedby=""datatable-editable_info"">
                                <thead>
                                    <tr role=""row"">
                                        <th class=""sorting_asc"" tabindex=""0"" aria-controls=""datatable-editable"" rowspan=""1"" colspan=""1"" style=""width: 234px;"" aria-sort=""ascending"" aria-label=""موتور جستجو: activate to sort column descending"">#</th>
                                        <th class=""sorting_asc"" tabindex=""0"" aria-controls=""datatable-editable"" rowspan=""1"" colspan=""1"" style=""width: 234px;"" aria-sort=""ascending"" aria-label=""موتور جستجو: activate to sort column descending"">تصویر گالری محصول</th>
                                        <th class=""sorting_asc"" tabindex=""0"" aria-controls=""datatable-editable"" rowspan=""1"" colspan=""1"" style=""width: 234px;"" aria-sort=""ascending"" aria-label=""موتور جستجو: activate to sort column descending"">عنوان گالری");
            WriteLiteral(@" محصول</th>

                                        <th class=""sorting_disabled"" rowspan=""1"" colspan=""1"" style=""width: 138px;"" aria-label=""فعالیت"">فعالیت</th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 70 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                     if (Model.Count() > 0)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr class=\"gradeX odd\" role=\"row\">\r\n                                        <td class=\"sorting_1\">");
#nullable restore
#line 75 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                                         Write(item.GalleryId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td class=\"sorting_1\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d0fd313a3484ebe046e3d3a8d0e6ea09be7a1a6911200", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4616, "~/CssSite/ImageSite/", 4616, 20, true);
#nullable restore
#line 76 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
AddHtmlAttributeValue("", 4636, item.GalleryImage, 4636, 18, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                        <td class=\"sorting_1\">");
#nullable restore
#line 77 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                                         Write(item.GalleryTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        <td class=\"actions\">\r\n                                            <a class=\"on-default remove-row btnDelete\"");
            BeginWriteAttribute("ThisId", " ThisId=\"", 4902, "\"", 4926, 1);
#nullable restore
#line 80 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
WriteAttributeValue("", 4911, item.GalleryId, 4911, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("ThisName", " ThisName=\"", 4927, "\"", 4956, 1);
#nullable restore
#line 80 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
WriteAttributeValue("", 4938, item.GalleryTitle, 4938, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash-o\"></i></a>\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 83 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"

                                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                         
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr class=\"gradeX odd\" role=\"row\">\r\n                                            <td colspan=\"5\" class=\"sorting_1\">گالری  موجود نمی باشد .</td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 92 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-sm-6"">

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <!-- end: panel body -->

    </div> <!-- end panel -->
</div> <!-- end col-->
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d0fd313a3484ebe046e3d3a8d0e6ea09be7a1a6915950", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        $('.btnDelete').click(function () {

            var ThisName = $(this).attr(""ThisName"");
            var ThisId = $(this).attr(""ThisId"");

            var GetResult = confirm(""آیا گالری "" + ThisName +  "" را حذف می‌کنید؟ "");

            var action = { url: '");
#nullable restore
#line 122 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Areas/Admin/Views/Product/ShowAllGalleries.cshtml"
                            Write(Url.Action("DeleteGallery","Delete",new { Area=""}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' };

            var model = { 'GalleryId': ThisId };

            if (GetResult == true) {
                $.ajax({
                    type: ""POST"",
                    url: action.url,
                    contentType: ""application/json;charset=utf-8"",
                    data: JSON.stringify(model),
                }).done(function (result) {
                    if (result != ""OK"") {
                        console.log(result);
                        alert(""عملیات انجام نشد لطفا مجدد تلاش کنید"");
                    }
                    else {
                        alert(""گالری "" + ThisName +  "" با موفقیت حذف شد!"");
                        location.reload();
                    }
                })
            }

        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KalaMarket.DataLayer.Entities.ProductEntities.ProductGallery>> Html { get; private set; }
    }
}
#pragma warning restore 1591
