using DataAccess.DatabaseAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Interfaces
{
    public class ClientData : IClientData
    {
        private readonly IDatabase _db;

        public ClientData(IDatabase db)
        {
            _db = db;
        }

        public async Task<ClientModel> GetClient(int id)
        {
            var results = await _db.LoadData<ClientModel, dynamic>("dbo.sp_Clients_GetOne", new { Id = id });
            return results.FirstOrDefault();
        }
        public Task<IEnumerable<ClientModel>> GetClientsAll() =>
            _db.LoadData<ClientModel, dynamic>("dbo.sp_Clients_GetAll", new { });

        public Task InsertClient(ClientModel model) =>
            _db.SaveData("dbo.sp_Clients_Insert", model);

        public Task UpdateClient(ClientModel model) =>
            _db.SaveData("dbo.sp_Clients_Update", model);

        public Task DeleteClient(int id) =>
            _db.SaveData("dbo.sp_Clients_Delete", new { Id = id });
    }
}
