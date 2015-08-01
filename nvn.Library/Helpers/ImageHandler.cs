using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace nvn.Library.Helpers
{
    /// <summary>
    /// Class contaning method to resize an image and save in JPEG format
    /// </summary>
    public class ImageHandler
    {
        /// <summary>
        /// Add by tsandtm 
        /// Xu ly van ban lay 1 link image dau tien, luu thanh cac dinh dang mong muon.
        /// URL image dua ra ten hoac link hinh anh
        /// </summary>
        /// <param name="HTMLCode"></param>
        /// <param name="W"></param>
        /// <param name="H"></param>
        /// <param name="quality"></param>
        /// <param name="pathImage"></param>
        /// 
        // SaveImagefromContent(Item.Content, W, H, Q, E, HttpContext.Current.Server.MapPath("~/UserFiles/Files/"));
        public string SaveImagefromContent(string HTMLCode, int[] W, int[] H, int[] quality, string[] pathImage, string pathServer)
        {
            string URLImage = "";
            URLImage = FindURLImage(HTMLCode);
            //ImageHandler i = new ImageHandler();
            //System.Drawing.Bitmap ima = new System.Drawing.Bitmap(Server.MapPath("~/image/1.jpg"));

            //kiem tra duong dan online hay local
            if (URLImage == string.Empty || URLImage.Contains("http://"))
                return "";
            if (URLImage.Length <= 0)
                return "";
            string nameshow = URLImage.Substring(URLImage.LastIndexOf("/UserFiles/files/") + 17);
            string NameImg = URLImage.Substring(URLImage.LastIndexOf("/") + 1);
            ImageHandler imageHandler = new ImageHandler();
            int i = -1;
            try
            {
                foreach (string item in pathImage)
                {
                    i++;
                    System.Drawing.Bitmap image = new System.Drawing.Bitmap(pathServer + NameImg);
                    Save(image, H[i], W[i], quality[i], pathImage[i] + NameImg);
                }
            }
            catch (Exception e) { return e.ToString(); }
            return nameshow;
        }
        public string SaveImage(string HTMLCode, int[] W, int[] H, int[] quality, string[] pathImage, string pathServer, out string URLImage)
        {
            URLImage = FindURLImage(HTMLCode);
            //ImageHandler i = new ImageHandler();
            //System.Drawing.Bitmap ima = new System.Drawing.Bitmap(Server.MapPath("~/image/1.jpg"));

            //kiem tra duong dan online hay local
            if (URLImage == string.Empty || URLImage.Contains("http://"))
                return "";

            string NameImg = URLImage.Substring(URLImage.LastIndexOf("/") + 1);
            URLImage = URLImage.Substring(1);
            ImageHandler imageHandler = new ImageHandler();
            int i = -1;
            try
            {
                foreach (string item in pathImage)
                {
                    i++;
                    System.Drawing.Bitmap image = new System.Drawing.Bitmap(pathServer + URLImage);
                    Save(image, H[i], W[i], quality[i], pathServer + "UserFiles\\" + pathImage[i] + NameImg);
                }

                URLImage = NameImg;
            }
            catch (Exception e) { return pathServer + "UserFiles\\" + pathImage[i] + NameImg + "\n" + e.ToString(); }
            return "";
        }

        public string SaveImage(int[] W, int[] H, int[] quality, string pathImage, string pathServer, string ImageName, byte[] byteArray)
        {


            //string NameImg = URLImage.Substring(ImageName.LastIndexOf("/") + 1);
            //URLImage = URLImage.Substring(1);
            ImageHandler imageHandler = new ImageHandler();
            int i = -1;
            try
            {
                ImageConverter ic = new ImageConverter();
                Image img = (Image)ic.ConvertFrom(byteArray);



                foreach (int item in W)
                {
                    i++;
                    Bitmap image = new Bitmap(img);
                   
                    if (!System.IO.Directory.Exists(HttpContext.Current.Server.MapPath("~/"+pathImage + "/" + W[i] + "-" + H[i] + "/")))
                        System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/" + pathImage + "/" + W[i] + "-" + H[i] + "/"));


                    //System.Drawing.Bitmap image = new System.Drawing.Bitmap(pathServer + ImageName);
                    Save(image, H[i], W[i], quality[i], HttpContext.Current.Server.MapPath(
                        "~/"+pathImage + "/" + W[i] + "-" + H[i] + "/"
                        + ImageName));
                }
            }
            catch (Exception e) { return e.ToString(); }
            return "";

        }
        /// <summary>
        /// return link or string.Empty
        /// </summary>
        /// <param name="HTMLCode"></param>
        /// <returns></returns>
        private string FindURLImage(string HTMLCode)
        {
            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
            MatchCollection matchesImgSrc = Regex.Matches(HTMLCode, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;
                return href;
                //links.Add(new Uri(href));
            }
            return string.Empty;
        }

        /// <summary>
        /// Method to resize, convert and save the image.
        /// </summary>
        /// <param name="image">Bitmap image.</param>
        /// <param name="maxWidth">resize width.</param>
        /// <param name="maxHeight">resize height.</param>
        /// <param name="quality">quality setting value.</param>
        /// <param name="filePath">file path.</param>      
        public void Save(Bitmap image, int maxHeight, int maxWidth, int quality, string filePath)
        {
            //chi ap dung cho cac hinh lon hon ti le hien co
            // Get the image's original width and height
            int newHeight = image.Height;  //chieu cao moi
            int newWidth = image.Width;   //chieu rong moi
            double HW_ratio = (double)((double)image.Height / (double)maxHeight);   //ti le chieu cao hinh va chieu cao max
            double WW_ratio = (double)((double)image.Width / (double)maxWidth); //ti le chieu rong hinh va chieu rong max

            if (!(HW_ratio <= 1 && WW_ratio <= 1))
            {
                //newWidth = (int)((double)image.Width / HW_ratio);
                //newHeight = (int)((double)image.Height / WW_ratio);

                if (HW_ratio < WW_ratio)    //neu ti le cao > rong
                {
                    newHeight = maxHeight;  //cao = cao max
                    //newWidth = (int)((double)image.Width / (HW_ratio / WW_ratio));
                    newWidth = (int)((double)image.Width / HW_ratio);
                }
                else
                {
                    newWidth = maxWidth;
                    //newHeight = (int)((double)image.Height / (WW_ratio / HW_ratio));
                    newHeight = (int)((double)image.Height / WW_ratio);
                }
            }


            // Convert other formats (including CMYK) to RGB.
            Bitmap newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format64bppArgb);

            // Draws the image in the specified size with quality mode set to HighQuality
            using (Graphics graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Get an ImageCodecInfo object that represents the JPEG codec.
            ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

            // Create an Encoder object for the Quality parameter.
            Encoder encoder = Encoder.Quality;

            // Create an EncoderParameters object. 
            EncoderParameters encoderParameters = new EncoderParameters(1);

            // Save the image as a JPEG file with quality level.
            EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
            encoderParameters.Param[0] = encoderParameter;
            newImage.Save(filePath, imageCodecInfo, encoderParameters);
            //newImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        /// <summary>
        /// Method to get encoder infor for given image format.
        /// </summary>
        /// <param name="format">Image format</param>
        /// <returns>image codec info.</returns>
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }
    }
}