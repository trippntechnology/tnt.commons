using System.Diagnostics.CodeAnalysis;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
public class ExtBaseClass2 : BaseClass
{
  public int e2IntProperty { get; set; }

  public string? e2StringProperty { get; set; }
}
