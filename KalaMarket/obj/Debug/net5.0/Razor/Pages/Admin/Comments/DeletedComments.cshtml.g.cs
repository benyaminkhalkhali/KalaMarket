#pragma checksum "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2063f3529da8fa307087a1a043e18382ff9309c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Admin_Comments_DeletedComments), @"mvc.1.0.razor-page", @"/Pages/Admin/Comments/DeletedComments.cshtml")]
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
#line 8 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
using KalaMarket.Core.ExtensionMethod;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2063f3529da8fa307087a1a043e18382ff9309c2", @"/Pages/Admin/Comments/DeletedComments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Comments_DeletedComments : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
  
    ViewData["Title"] = "لیست نقش ها";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"col-md-12 col-sm-12 col-xs-12\">\r\n    <div class=\"x_panel\">\r\n        <div class=\"x_title\">\r\n            <h2>\r\n\r\n                نظرات\r\n");
#nullable restore
#line 16 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                 if (Model.Checked == null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"/Admin/Comments/DeletedComments\" class=\"btn btn-danger\">همه</a>\r\n");
#nullable restore
#line 19 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"

                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a href=\"/Admin/Comments/DeletedComments\" class=\"btn btn-default\">همه</a>\r\n");
#nullable restore
#line 24 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 723, "\"", 775, 2);
            WriteAttributeValue("", 730, "/Admin/Comments/DeletedComments?Checked=", 730, 40, true);
#nullable restore
#line 26 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 770, true, 770, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 776, "\"", 840, 2);
            WriteAttributeValue("", 784, "btn", 784, 3, true);
#nullable restore
#line 26 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue(" ", 787, (Model.Checked==true)?"btn-primary":"btn-default", 788, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">تایید شده</a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 875, "\"", 928, 2);
            WriteAttributeValue("", 882, "/Admin/Comments/DeletedComments?Checked=", 882, 40, true);
#nullable restore
#line 27 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 922, false, 922, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 929, "\"", 994, 2);
            WriteAttributeValue("", 937, "btn", 937, 3, true);
#nullable restore
#line 27 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue(" ", 940, (Model.Checked==false)?"btn-warning":"btn-default", 941, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">تایید نشده</a>


                <a href=""/Admin/Comments"" class=""btn btn-success"">منتشر شده</a>
            </h2>
            <ul class=""nav navbar-right panel_toolbox"">
                <li>
                    <a class=""collapse-link""><i class=""fa fa-chevron-up""></i></a>
                </li>


            </ul>
            <div class=""clearfix""></div>
        </div>
        <div class=""x_content"">

            <div class=""col-md-12 col-sm-12 col-xs-12"">


                <div id=""datatable-checkbox_wrapper"" class=""dataTables_wrapper form-inline dt-bootstrap no-footer"">


                    <div class=""row"">
                        <div class=""col-sm-12"">


                            <table id=""datatable-checkbox"" class=""table table-striped table-bordered bulk_action dataTable no-footer"" role=""grid"" aria-describedby=""datatable-checkbox_info"">
                                <thead>
                                    <tr>
                                        <th>
        ");
            WriteLiteral(@"                                    ردیف
                                        </th>
                                        <th>
                                            کاربر
                                        </th>
                                        <th>
                                            محصول
                                        </th>
                                        <th>
                                            تاریخ
                                        </th>
                                        <th>
                                            عنوان
                                        </th>
                                        <th>
                                            چکیده
                                        </th>

                                        <th>
                                            امتیاز
                                        </th>
                                        <th>
                      ");
            WriteLiteral(@"                      وضعیت
                                        </th>

                                        <th>
                                            عملیات
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 88 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                      
                                        int Radif = 1;
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 91 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                     foreach (var item in Model.model.Comments)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <span>");
#nullable restore
#line 95 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                  Write(Radif++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                            </td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 3967, "\"", 4008, 2);
            WriteAttributeValue("", 3974, "/Admin/Users/EditUser/", 3974, 22, true);
#nullable restore
#line 98 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 3996, item.UserId, 3996, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 98 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                                                        Write(item.user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                            </td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 4183, "\"", 4234, 2);
            WriteAttributeValue("", 4190, "/Product/Detail/", 4190, 16, true);
#nullable restore
#line 101 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 4206, item.product.ProductEnTitle, 4206, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 101 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                                                                  Write(item.product.ProductFaTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 104 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                           Write(item.CreateDate.ToShamsi());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 107 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                           Write(item.CommentTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n");
#nullable restore
#line 110 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                 if (item.CommentDescription.Length > 50)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span>");
#nullable restore
#line 112 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                     Write(item.CommentDescription.Substring(0, 50));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ...</span>\r\n");
#nullable restore
#line 113 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                }
                                                else
                                                {
                                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                               Write(item.CommentDescription);

#line default
#line hidden
#nullable disable
#nullable restore
#line 116 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                                            
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 120 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                           Write(item.Score);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n");
#nullable restore
#line 123 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                 if (item.IsActive == true)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text-success\">تایید شده</span>\r\n");
#nullable restore
#line 126 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text-danger\">تایید نشده</span>\r\n");
#nullable restore
#line 130 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 6202, "\"", 6248, 2);
            WriteAttributeValue("", 6209, "/Admin/Comments/Details/", 6209, 24, true);
#nullable restore
#line 134 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 6233, item.CommentId, 6233, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"><i class=\"fa fa-pencil\"></i></a>\r\n                                                <a");
            BeginWriteAttribute("ThisId", " ThisId=\"", 6350, "\"", 6374, 1);
#nullable restore
#line 135 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 6359, item.CommentId, 6359, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("ThisName", " ThisName=\"", 6375, "\"", 6404, 1);
#nullable restore
#line 135 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 6386, item.CommentTitle, 6386, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnDelete\"><i class=\"fa fa-trash\"></i></a>\r\n                                                <a");
            BeginWriteAttribute("ThisId", " ThisId=\"", 6507, "\"", 6531, 1);
#nullable restore
#line 136 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 6516, item.CommentId, 6516, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("ThisName", " ThisName=\"", 6532, "\"", 6561, 1);
#nullable restore
#line 136 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 6543, item.CommentTitle, 6543, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btnRestore\"><i class=\"fa fa-recycle\"></i></a>\r\n\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 140 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>

                            </table>
                        </div>
                    </div>

                    <div class=""row"">

                        <div class=""col-sm-5"">
                            <div class=""dataTables_info"" id=""datatable-checkbox_info"" role=""status"" aria-live=""polite"">
                                تعداد کل رکورد ها : ");
#nullable restore
#line 152 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                               Write(Model.model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <br />\r\n                                تعداد نمایش در هر صفحه : ");
#nullable restore
#line 154 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                                    Write(ViewData["Take"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"col-sm-7\">\r\n\r\n                            <div class=\"btn-group\">\r\n\r\n");
#nullable restore
#line 162 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                 if (Model.model.CurrentPage > 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a href=\"/Admin/Comments/DeletedComments?PageId=1\" class=\"btn btn-default\">\r\n                                        اولین\r\n                                    </a>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 7817, "\"", 7891, 2);
            WriteAttributeValue("", 7824, "/Admin/Comments/DeletedComments?PageId=", 7824, 39, true);
#nullable restore
#line 167 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 7863, Model.model.CurrentPage-1, 7863, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n                                        قبلی\r\n                                    </a>\r\n");
#nullable restore
#line 170 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 173 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                 for (int i = 1; i <= Model.model.PageCount; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 8202, "\"", 8250, 2);
            WriteAttributeValue("", 8209, "/Admin/Comments/DeletedComments?PageId=", 8209, 39, true);
#nullable restore
#line 175 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 8248, i, 8248, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 8251, "\"", 8323, 1);
#nullable restore
#line 175 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 8259, (i==Model.model.CurrentPage)?"btn btn-info":"btn btn-default", 8259, 64, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        ");
#nullable restore
#line 176 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </a>\r\n");
#nullable restore
#line 178 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 180 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                 if (Model.model.CurrentPage < Model.model.PageCount)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <a");
            BeginWriteAttribute("href", " href=\"", 8610, "\"", 8684, 2);
            WriteAttributeValue("", 8617, "/Admin/Comments/DeletedComments?PageId=", 8617, 39, true);
#nullable restore
#line 182 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 8656, Model.model.CurrentPage+1, 8656, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n                                        بعدی\r\n                                    </a>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 8838, "\"", 8906, 2);
            WriteAttributeValue("", 8845, "/Admin/Comments/DeletedComments?PageId=", 8845, 39, true);
#nullable restore
#line 185 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
WriteAttributeValue("", 8884, Model.model.PageCount, 8884, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-default\">\r\n                                        آخرین\r\n                                    </a>\r\n");
#nullable restore
#line 188 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>


        $('.btnRestore').click(function () {

            var ThisName = $(this).attr(""ThisName"");
            var ThisId = $(this).attr(""ThisId"");

            var GetResult = confirm(""آیا نظر "" + ThisName + "" را بازگردانی می‌کنید؟ "");

            var action = { url: '");
#nullable restore
#line 213 "/Users/benyamin/Downloads/KalaMarket/KalaMarket/Pages/Admin/Comments/DeletedComments.cshtml"
                            Write(Url.Action("RestoreComment", "Restore",new { Area=""}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' };

            var model = { 'CommentId': ThisId };

            if (GetResult == true) {
                $.ajax({
                    type: ""POST"",
                    url: action.url,
                    contentType: ""application/json;charset=utf-8"",
                    data: JSON.stringify(model)
                }).done(function (result) {
                    if (result != ""OK"") {
                        console.log(result);
                        alert(""عملیات انجام نشد لطفا مجدد تلاش کنید"");
                    }
                    else {
                        alert(""نظر "" + ThisName + "" با موفقیت بازگردانی شد!"");
                        location.reload();
                    }
                })
            }

            });



    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<KalaMarket.Pages.Admin.Comments.DeletedCommentsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KalaMarket.Pages.Admin.Comments.DeletedCommentsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<KalaMarket.Pages.Admin.Comments.DeletedCommentsModel>)PageContext?.ViewData;
        public KalaMarket.Pages.Admin.Comments.DeletedCommentsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591