using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    internal RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> GetAll()
    {
      return _repo.GetAll();
    }

    internal Recipe GetById(int id)
    {
      Recipe recipe = _repo.GetById(id);
      if (recipe == null)
      {
        throw new Exception("Invalid Id");
      }
      return recipe;
    }

    internal Recipe Create(Recipe newData)
    {
      return _repo.Create(newData);
    }

    internal Recipe Edit(Recipe update)
    {
      Recipe original = GetById(update.Id);
      if (original.CreatorId != update.CreatorId)
      {
        throw new Exception("You can't edit this recipe");
      }
      original.Title = update.Title != "" ? update.Title : original.Title;
      original.Subtitle = update.Subtitle != "" ? update.Subtitle : original.Subtitle;
      original.Category = update.Category != "" ? update.Category : original.Category;
      _repo.Edit(original);
      return original;
    }

    internal void Delete(int id, string userId)
    {
      Recipe original = GetById(id);
      if (original.CreatorId != userId)
      {
        throw new Exception("You can't delete this recipe");
      }
      _repo.Delete(id, userId);
    }
  }
}