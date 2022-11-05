using DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace DataAccess.Services;

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

        var existingIndexes = Directory.EnumerateFiles(directory).ToList().Select(name =>
        {
            var fileName = Path.GetFileName(name);
            return int.Parse(fileName[..5]);
        });

        int index = existingIndexes.Max() + 1;
        images.ForEach(async file =>
        {
            var format = file.FileName.Split('.')[^1];
            var newFileName = $"{index++:D5}_{Guid.NewGuid()}.{format}";
            var fullFilePath = Path.Combine(directory, newFileName);
            using var fileStream = new FileStream(fullFilePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        });
    }

    public async Task<List<byte[]>> Read(string path, bool onlyFirst)
    {
        var searchingFolder = Path.Combine(_startingDirectory, path);
        if (!Directory.Exists(searchingFolder)
            || !Directory.EnumerateFiles(searchingFolder).Any())
        {
            searchingFolder = _startingDirectory;
            onlyFirst = true;
        }

        var output = new List<byte[]>();
        var onlyImages = new Regex(@".+.(jpg||png||jpeg)", RegexOptions.Compiled);
        var imagesInFolder = Directory.EnumerateFiles(searchingFolder).OrderBy(name => name).Where(name => onlyImages.IsMatch(name)).ToArray();
        foreach (var fileName in imagesInFolder)
        {
            using var fileStream = File.Open(fileName, FileMode.Open);
            byte[] result = new byte[fileStream.Length];
            await fileStream.ReadAsync(result.AsMemory(0, (int)fileStream.Length));
            output.Add(result);

            if (onlyFirst)
                break;
        }
        return output;
    }
}
