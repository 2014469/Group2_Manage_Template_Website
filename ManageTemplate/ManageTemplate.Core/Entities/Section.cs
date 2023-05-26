using ManageTemplate.Core.Contracts;

namespace ManageTemplate.Core.Entities
{
  public class Section : IEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Hbs { get; set; }
    public string UrlSlug { get; set; }
    public string PreviewImageUrl { get; set; }
    public bool Enable { get; set; } = true;

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }
    public IList<SampledData> ExampledDatas { get; set; }
  }
}
