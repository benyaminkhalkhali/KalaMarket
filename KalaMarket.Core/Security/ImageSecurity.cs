using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.Security
{
    public static class ImageSecurity
    {
        public static string ImageSecurities(this IFormFile file)
        {
            try
            {
                System.Drawing.Image.FromStream(file.OpenReadStream());
                return "true";
            }
            catch (Exception)
            {
                return "false";
            }
        }
    }
}
