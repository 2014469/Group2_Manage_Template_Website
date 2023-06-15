using ManageTemplate.WebApi.Model;

namespace ManageTemplate.WebApi.Models.Section
{
  public class SectionDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Hbs { get; set; }

    public IList<SampledDataDto> ExampledDatas { get; set; }
  }
}
