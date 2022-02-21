using System.Collections.Generic;

namespace AllSpice
{
  /// <summary>
  /// The Basic Repository Pattern 
  /// <param name="Tid"> "Tid" Specifies type of collection id </param>
  /// </summary>
  public interface IRepository<T, Tid>
  {

    // GetAll
    List<T> GetAll();

    // GetById
    T GetById(Tid id);

    // Create 
    T Create(T newData);

    // Edit
    void Edit(T update);


    // Delete
    void Delete(Tid objectId, string userId);
  }
}