using KalaMarket.Core.Security;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ExtensionMethod
{
    public static class UploadImage
    {
        public static string CreateImage(IFormFile file)
        {
            try
            {
                string imageName = GenerateCode.GuidCode() + Path.GetExtension(file.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CssSite/ImageSite", imageName);
                string imagePathThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/thumb", imageName);
                string imageSecurity = file.ImageSecurities();
                if (imageSecurity == "false")
                    return "false";

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                ConvertImage convert = new ConvertImage();
                convert.Image_resize(imagePath, imagePathThumb, 400, 400);
                return imageName;
            }
            catch (Exception)
            {
                return "false";
            }  
        }

    public static bool DeleteImage(string path, string imagename)
        {
            try
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CssSite/" + path + "/" + imagename);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
