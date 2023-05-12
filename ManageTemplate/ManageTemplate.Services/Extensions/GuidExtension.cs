
namespace ManageTemplate.Services.Extensions
{
  public static class GuidExtension
  {
    public static bool IsNullOrEmpty(
      this Guid source)

    {
      return  source == Guid.Empty;
    }
  }
}
