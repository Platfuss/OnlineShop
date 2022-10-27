using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class ImageService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _startingDirectory;

        public ImageService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _startingDirectory = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "assets");
        }

        public void Save(string path, List<IFormFile> images)
        {
            var directory = Path.Combine(_startingDirectory, path);

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

        public List<byte[]> Read(List<string> paths, bool onlyFirst)
        {
            if (paths is null) return null; 

            var output = new List<byte[]>();
            paths.ForEach(async p => {
                var filePath = Path.Combine(_startingDirectory, p);

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"File {filePath} does not exist.");
                }

                using var fileStream = File.Open(filePath, FileMode.Open);
                byte[] result = new byte[fileStream.Length];
                await fileStream.ReadAsync(result.AsMemory(0, (int)fileStream.Length));
                output.Add(result);
            });
            return output;
        }
    }
}
