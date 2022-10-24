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

        public void Save(List<string> dirParts, List<IFormFile> images)
        {
            var directory = _startingDirectory;
            dirParts.ForEach((p) => {
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

        public async Task<List<byte[]>> Read(List<string> dirParts, bool onlyFirst = true)
        {
            var directory = _startingDirectory;
            dirParts.ForEach((p) => {
                directory = Path.Combine(directory, p);
            });

            if (!Directory.Exists(directory))
            {
                throw new FileNotFoundException($"Folder {directory} does not exist.");
            }

            var regex = new Regex(@"^.*(\d{5})_.*\.(?:jpg|png|jpeg)$");
            var imageFiles = Directory.GetFiles(directory).Where(fileName => regex.IsMatch(fileName)).ToList();

            var orderToNames = new Dictionary<int, string>();
            foreach (var imageFile in imageFiles)
            {
                var result = int.Parse(regex.Match(imageFile).Groups[1].ToString());
                orderToNames[result] = imageFile;
            }

            var keysInOrder = orderToNames.Keys.ToList();
            keysInOrder.Sort();

            var output = Enumerable.Repeat(default(byte[]), keysInOrder.Count).ToList();
            for (int i = 0; i < keysInOrder.Count; i++)
            {
                var fileName = orderToNames[keysInOrder[i]];
                using (var fileStream = File.Open(fileName, FileMode.Open))
                {
                    byte[] result = new byte[fileStream.Length];
                    await fileStream.ReadAsync(result, 0, (int)fileStream.Length);
                    output[i] = result;
                }
                if (onlyFirst)
                {
                    break;
                }
            }
            return output;
        }
    }
}
