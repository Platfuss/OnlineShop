using DataAccess.DatabaseAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class TestData
    {
        private readonly IDatabase _db;
        public TestData(IDatabase db)
        {
            _db = db;
        }

        public Task<IEnumerable<TestModel>> GetTests() =>
            _db.LoadData<TestModel, dynamic>("spTest_GetAll", new { });

        public Task InsertTest(TestModel test) =>
            _db.SaveData("dbo.spTest_Insert", new { test.TestProperty });
    }
}
