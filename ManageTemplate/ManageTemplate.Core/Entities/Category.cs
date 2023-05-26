using ManageTemplate.Core.Contracts;

namespace ManageTemplate.Core.Entities
{
  public class Category : IEntity
  {
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string UrlSlug { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool ShowOnMenu { get; set; } = true;
    public bool Enable { get; set; } = true;

    public IList<Section> Sections { get; set; }
  }
}
