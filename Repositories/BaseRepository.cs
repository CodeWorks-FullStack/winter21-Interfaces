using System.Data;

namespace AllSpice.Repositories
{
  public abstract class BaseRepository
  {
    protected readonly IDbConnection _db;

    protected BaseRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}