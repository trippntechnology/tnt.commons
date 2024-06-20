using System.Diagnostics.CodeAnalysis;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
internal class JsonTestClass
{
  public List<BaseClass> ListExample { get; set; } = new List<BaseClass>();
  public int IntExample { get; set; } = 0;
  public string StringExample { get; set; } = "";

  public MyEnum myEnum { get; set; }

  public BaseClass? BaseClassExample { get; set; } = null;

  public override bool Equals(object? obj)
  {
    var testObj = obj as JsonTestClass;
    if (testObj == null) return false;
    return IntExample == testObj.IntExample && StringExample == testObj.StringExample && testObj.myEnum == myEnum;
  }
}
