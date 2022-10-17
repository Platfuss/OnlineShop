using DataAccess.Models;

namespace DataAccess.Services.Interfaces
{
    public interface IClientService
    {
        Task DeleteClient(int id);
        Task<ClientModel> GetClient(int id);
        Task<IEnumerable<ClientModel>> GetClientsAll();
        Task InsertClient(ClientModel model);
        Task UpdateClient(ClientModel model);
    }
}