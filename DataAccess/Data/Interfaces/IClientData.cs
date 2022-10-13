using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IClientData
    {
        Task DeleteClient(int id);
        Task<ClientModel> GetClient(int id);
        Task<IEnumerable<ClientModel>> GetClientsAll();
        Task InsertClient(ClientModel model);
        Task UpdateClient(ClientModel model);
    }
}