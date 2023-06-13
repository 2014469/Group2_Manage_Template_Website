using ManageTemplate.Core.Contracts;

namespace ManageTemplate.WebApi.Models
{
  public class PagingModel : IPagingParams
  {
    public int? PageSize { get; set; } = 10;
    public int? PageNumber { get; set; } = 1;
    public string SortColumn { get; set; } = "NAME";
    public string SortOrder { get; set; } = "DESC";
  }
}
