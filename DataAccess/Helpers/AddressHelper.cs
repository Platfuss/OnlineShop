using DataAccess.DatabaseAccess;

namespace DataAccess.Helpers;
internal class AddressHelper
{
    private readonly DataContext _db;

    public AddressHelper(DataContext db)
    {
        _db = db;
    }
}
