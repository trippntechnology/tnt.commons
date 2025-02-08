using System.Diagnostics.CodeAnalysis;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
public class Part
{
  public int id { get; set; }
  public string code { get; set; } = string.Empty;
  public string description { get; set; } = string.Empty;
}
