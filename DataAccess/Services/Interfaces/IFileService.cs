using Microsoft.AspNetCore.Http;

namespace DataAccess.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<byte[]>> Read(string path, bool onlyFirst);
        void Save(string path, List<IFormFile> images);
    }
}