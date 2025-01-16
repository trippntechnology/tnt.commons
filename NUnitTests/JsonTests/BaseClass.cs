using System.Diagnostics.CodeAnalysis;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
public class BaseClass
{
  public int baseIntProperty { get; set; } = 0;

  public string? baseStringProperty { get; set; } = null;

  public List<Part> parts { get; set; } = new List<Part>();

  public override bool Equals(object? obj)
  {
    var other = obj as BaseClass;
    if (other == null) return false;
    return other.baseIntProperty == baseIntProperty && other.baseStringProperty == baseStringProperty;
  }
}
