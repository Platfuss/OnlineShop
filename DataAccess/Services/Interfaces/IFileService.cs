using Microsoft.AspNetCore.Http;

namespace DataAccess.Services.Interfaces;

public interface IFileService
{
    Task<List<byte[]>> ReadAsync(string path, bool onlyFirst);
    void Save(string path, List<IFormFile> images);
}