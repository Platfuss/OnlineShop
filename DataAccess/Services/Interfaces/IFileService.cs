using Microsoft.AspNetCore.Http;

namespace DataAccess.Services.Interfaces
{
    public interface IFileService
    {
        void Save(List<string> dir, List<IFormFile> images);
    }
}