namespace DataAccess.DatabaseAccess.Interfaces
{
    public interface IDatabase
    {
        Task<IEnumerable<T>> ExecuteProcedure<T, U>(string storedProcedure, U parameters, string connectionID = "Default");
        Task ExecuteProcedure<T>(string storedProcedure, T parameters, string connectionID = "Default");
    }
}