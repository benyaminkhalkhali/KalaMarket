using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KalaMarket.TagHelper
{
    public class GoogleRecaptcha : Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        private readonly IConfiguration _configuration;
        public GoogleRecaptcha(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var siteKey = _configuration.GetSection("GoogleRecaptcha")["SiteKey"];
            output.TagName = "div";
            output.AddClass("g-recaptcha", HtmlEncoder.Default);
            output.Attributes.Add("data-sitekey", siteKey);
            base.Process(context, output);
        }
    }
}
