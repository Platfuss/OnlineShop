using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ImageService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void Save(List<string> dir, List<IFormFile> images)
        {
            var directory = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "assets");
            dir.ForEach((p) => {
                directory = Path.Combine(directory, p);
            });

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            int index = 1;
            images.ForEach(async file =>
            {
                var format = file.FileName.Split('.')[^1];
                var newFileName = $"{index++:D5}_{Guid.NewGuid()}.{format}";
                var fullFilePath = Path.Combine(directory, newFileName);
                using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            });
        }
    }
}
