using Microsoft.AspNetCore.Http;

namespace DataAccess.Services.Interfaces
{
    public interface IFileService
    {
        Task<List<byte[]>> Read(List<string> dirParts, bool onlyFirst = true);
        void Save(List<string> dirParts, List<IFormFile> images);
    }
}