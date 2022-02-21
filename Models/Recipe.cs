using System;
using AllSpice.Interfaces;

namespace AllSpice.Models
{
  public class Recipe : IRepoItem<int>, ICreated
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string CreatorId { get; set; }
    public string Category { get; set; }
    public Profile Creator { get; set; }
  }
}