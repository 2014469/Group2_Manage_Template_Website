using ManageTemplate.Core.Contracts;

namespace ManageTemplate.Core.Entities
{
  public class ExampledData : IEntity
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Data { get; set; }
    public string Title { get; set; }
    public bool Enable { get; set; } = true;

    public Guid SectionId { get; set; }

    public Section Section { get; set; }
  }
}
