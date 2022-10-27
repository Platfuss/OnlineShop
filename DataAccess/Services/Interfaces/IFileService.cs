using Microsoft.AspNetCore.Http;

namespace DataAccess.Services.Interfaces
{
    public interface IFileService
    {
        List<byte[]> Read(List<string> paths, bool onlyFirst);
        void Save(string path, List<IFormFile> images);
    }
}