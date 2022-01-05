using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.Core.ExtensionMethod
{
    public class ConvertImage
    {
        public void Image_resize(string input_Image_Path, string output_Image_Path, int new_width, int new_height)

        {

            const long quality = 50L;


            Bitmap source_Bitmap = new Bitmap(input_Image_Path);

            

                //< create Empty Drawarea >

                var resized_Bitmap = new Bitmap(new_width, new_height);

                //</ create Empty Drawarea >



                using (var graphics = Graphics.FromImage(resized_Bitmap))

                {

                    //< setup >

                    graphics.CompositingQuality = CompositingQuality.HighSpeed;

                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    graphics.CompositingMode = CompositingMode.SourceCopy;

                    //</ setup >



                    //< draw into placeholder >

                    graphics.DrawImage(source_Bitmap, 0, 0, new_width, new_height);

                    //</ draw into placeholder >



                    //--< Output as .Jpg >--

                    using (var output = File.Open(output_Image_Path, FileMode.Create))

                    {

                        //< setup jpg >

                        var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                        var encoderParameters = new EncoderParameters(1);

                        encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                        //</ setup jpg >



                        //< save Bitmap as Jpg >

                        var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                        resized_Bitmap.Save(output, codec, encoderParameters);

                    //</ save Bitmap as Jpg >
                        output.Close();
                    }

                //--</ Output as .Jpg >--
                    graphics.Dispose();
                }
            source_Bitmap.Dispose();
            }

            //---------------</ Image_resize() >---------------

        }
    }

  
