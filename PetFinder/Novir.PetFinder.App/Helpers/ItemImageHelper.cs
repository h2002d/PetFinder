using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Novir.PetFinder.Core.Dto.Items;
using Novir.PetFinder.Core.Services.Items;
using Novir.PetFinder.Data;
using Novir.PetFinder.Data.Entities;
using Novir.PetFinder.Data.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App.Helpers
{
    public class ItemImageHelper
    {
        protected IItemImageService _itemImageService;

        private IHostingEnvironment _hostingEnvironment;
        public ItemImageHelper(IItemImageService itemImageService, IHostingEnvironment hostingEnvironment)
        {
            _itemImageService = itemImageService;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task SaveProductImage(List<IFormFile> formFiles, int productId)
        {
            List<ItemImageDto> productImages = new List<ItemImageDto>();
            string shortLocation = $"\\images\\items\\{productId}\\";
            string uploads = Path.Combine(_hostingEnvironment.WebRootPath + shortLocation);
            if (!Directory.Exists(uploads))
            {
                DirectoryInfo di = Directory.CreateDirectory(uploads);
            }
            foreach (var file in formFiles)
            {
                ////string fileName = file.FileName;
                //using (var memoryStream = new MemoryStream())
                //{
                //    await file.CopyToAsync(memoryStream);
                //    using (var img = new Bitmap(memoryStream))
                //    {
                //        var bitmapa= MakeSquarePhoto(img, 800);
                //        bitmapa.Save(memoryStream,);
                //    }
                //}
                if (file.Length > 0)
                {
                    //item.CopyTo(fileStream);

                    var timeSpan = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    var extension = System.IO.Path.GetExtension(file.FileName);
                    string newName = $"item_{timeSpan}.{extension}";
                    var filePath = Path.Combine(uploads, newName);
                    //var image = FixedSize((Image)file, 620, 440, true);

                    if (file == null || file.Length == 0)
                    {
                        return;
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        using (var img = Image.FromStream(memoryStream))
                        {
                            var resizedImage=FixedSize(img, 620, 440, false);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                resizedImage.Save(fileStream, ImageFormat.Jpeg);


                            }
                        }
                    }
                    ItemImageDto product = new ItemImageDto();
                    product.Source = $"/images/items/{productId}/{newName}";
                    product.ItemId = productId;
                    var newProduct = await _itemImageService.Add(product);
                }
            }
        }
        public static System.Drawing.Image FixedSize(Image image, int Width, int Height, bool needToFill)
        {
            #region calculations
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)Width / (double)sourceWidth);
            nScaleH = ((double)Height / (double)sourceHeight);
            if (!needToFill)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (Height - sourceHeight * nScale) / 2;
                destX = (Width - sourceWidth * nScale) / 2;
            }

            //if (nScale > 1)
            //    nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);
            #endregion

            System.Drawing.Bitmap bmPhoto = null;
            try
            {
                bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
            }
            catch (Exception ex)
            {
                throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                    destWidth, destX, destHeight, destY, Width, Height), ex);
            }
            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                //Console.WriteLine("From: " + from.ToString());
                //Console.WriteLine("To: " + to.ToString());
                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }



        //const int size = 150;
        //const int quality = 75;
        //void Resize(IFormFile file,string outputDirectory)
        //{
        //    using (var image = new Bitmap(file.OpenReadStream()))
        //    {
        //        int width, height;
        //        if (image.Width > image.Height)
        //        {
        //            width = 620;
        //            height = Convert.ToInt32(image.Height * size / (double)image.Width);
        //        }
        //        else
        //        {
        //            width = Convert.ToInt32(image.Width * size / (double)image.Height);
        //            height = size;
        //        }
        //        var resized = new Bitmap(width, height);
        //        using (var graphics = Graphics.FromImage(resized))
        //        {
        //            graphics.CompositingQuality = CompositingQuality.HighSpeed;
        //            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        //            graphics.CompositingMode = CompositingMode.SourceCopy;
        //            graphics.DrawImage(image, 0, 0, width, height);
        //            using (var output = File.Open(
        //               outputDirectory, FileMode.Create))
        //            {
        //                var qualityParamId = Encoder.Quality;
        //               //var encoderParameters = new EncoderParameters(1);
        //               // encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);
        //                var codec = ImageCodecInfo.GetImageDecoders()
        //                    .FirstOrDefault(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
        //                resized.Save(output,ImageFormat.Jpeg);
        //            }
        //        }
        //    }
        //}
        public Bitmap MakeSquarePhoto(Bitmap bmp, int size)
        {
            try
            {
                Bitmap res = new Bitmap(size, size);
                Graphics g = Graphics.FromImage(res);
                g.FillRectangle(new SolidBrush(System.Drawing.Color.White), 0, 0, size, size);
                int t = 0, l = 0;
                if (bmp.Height > bmp.Width)
                    t = (bmp.Height - bmp.Width) / 2;
                else
                    l = (bmp.Width - bmp.Height) / 2;
                g.DrawImage(bmp, new Rectangle(0, 0, size, size), new Rectangle(l, t, bmp.Width - l * 2, bmp.Height - t * 2), GraphicsUnit.Pixel);
                return res;
            }
            catch { }
            return null;
        }
    }
}
