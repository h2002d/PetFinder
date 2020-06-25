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
                    string newName = file.FileName.Split('.')[0] + timeSpan + "." + file.FileName.Split('.')[1];
                    var filePath = Path.Combine(uploads, newName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ItemImageDto product = new ItemImageDto();
                    product.Source = $"/images/items/{productId}/{newName}";
                    product.ItemId = productId;
                    var newProduct = await _itemImageService.Add(product);
                }
            }
        }

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
