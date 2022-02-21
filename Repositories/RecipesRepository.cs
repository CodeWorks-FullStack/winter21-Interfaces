using System.Collections.Generic;
using System.Data;
using System.Linq;
using AllSpice.Models;
using Dapper;

namespace AllSpice.Repositories
{
  public class RecipesRepository : BaseRepository, IRepository<Recipe, int>
  {
    public RecipesRepository(IDbConnection db) : base(db)
    {
    }

    public List<Recipe> GetAll()
    {
      string sql = @"
        SELECT
          r.*,
          a.*
        FROM recipes r
        JOIN accounts a ON r.creatorId = a.id";

      // NOTE first object, second object, return type
      return _db.Query<Recipe, Profile, Recipe>(sql, (r, p) =>
      {
        r.Creator = p;
        return r;
      }).ToList();
    }

    public Recipe GetById(int id)
    {
      string sql = @"
        SELECT
          r.*,
          a.*
        FROM recipes r
        JOIN accounts a ON r.creatorId = a.id
        WHERE r.id = @id";
      return _db.Query<Recipe, Profile, Recipe>(sql, (r, p) =>
      {
        r.Creator = p;
        return r;
      }, new { id }).FirstOrDefault();
    }
    public Recipe Create(Recipe newData)
    {
      string sql = @"
        INSERT INTO recipes
        (title, subtitle, category, creatorId)
        VALUES
        (@Title, @Subtitle, @Category, @CreatorId)
      ";
      return _db.ExecuteScalar<Recipe>(sql, newData);
    }

    public void Edit(Recipe update)
    {
      string sql = @"
        UPDATE recipes
        SET
          title = @Title,
          subtitle = @Subtitle,
          category = @Category
        WHERE id = @Id";
      _db.Execute(sql, update);
    }
    public void Delete(int objectId, string userId)
    {
      string sql = @"
        DELETE FROM recipes
        WHERE id = @id
        AND creatorId = @userId";
      _db.Execute(sql, new { id = objectId, userId });
    }


  }
}