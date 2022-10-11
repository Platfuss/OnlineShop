using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ITestData
    {
        Task<IEnumerable<TestModel>> GetTests();
        Task InsertTest(TestModel test);
    }
}