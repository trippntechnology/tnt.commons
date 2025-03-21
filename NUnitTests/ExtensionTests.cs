using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests;

[ExcludeFromCodeCoverage]
public class ExtensionTests
{
  [Test]
  public void Extensions_Let()
  {
    var result = new FooExtension() { Value = 7 }.Let(it =>
    {
      it.Value = 10;
      return 20;
    });

    Assert.That(result, Is.EqualTo(20));
  }

  [Test]
  public void Extensions_Null_Let()
  {
    FooExtension? fooExt = null;
    var result = fooExt?.Let(it => 7) ?? 11;

    Assert.That(result, Is.EqualTo(11));
  }

  [Test]
  public void Extensions_Also()
  {
    var result = new FooExtension() { Value = 7 }.Also(it =>
   {
     it.Value = 10;
   });

    Assert.That(result?.Value, Is.EqualTo(10));
  }

  [Test]
  public void Extension_whenType()
  {
    FooExtension value = new BarExtension();
    var success = false;

    value.WhenType<FooExtension, BarExtension>(d =>
    {
      success = true;
    });

    Assert.That(success, Is.True, "whenType failed to cast to type");

    value.WhenType<FooExtension, FormatException>(d =>
    {
      success = false;
    });

    Assert.That(success, Is.True);
  }

  [Test]
  public void Extensions_RunNotNull_BothNotNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
      Assert.That(param1, Is.EqualTo(v1));
      Assert.That(param2, Is.EqualTo(v2));
    });

    Assert.That(callbackInvoked, Is.True);
  }

  [Test]
  public void Extensions_RunNotNull_FirstNull()
  {
    string? v1 = null;
    string? v2 = "Test2";
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_SecondNull()
  {
    string? v1 = "Test1";
    string? v2 = null;
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_BothNull()
  {
    string? v1 = null;
    string? v2 = null;
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_ThreeParams_AllNotNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    string? v3 = "Test3";
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
      Assert.That(param1, Is.EqualTo(v1));
      Assert.That(param2, Is.EqualTo(v2));
      Assert.That(param3, Is.EqualTo(v3));
    });

    Assert.That(callbackInvoked, Is.True);
  }

  [Test]
  public void Extensions_RunNotNull_ThreeParams_FirstNull()
  {
    string? v1 = null;
    string? v2 = "Test2";
    string? v3 = "Test3";
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_ThreeParams_SecondNull()
  {
    string? v1 = "Test1";
    string? v2 = null;
    string? v3 = "Test3";
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_ThreeParams_ThirdNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    string? v3 = null;
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void Extensions_RunNotNull_ThreeParams_AllNull()
  {
    string? v1 = null;
    string? v2 = null;
    string? v3 = null;
    var callbackInvoked = false;

    Extensions.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }
}

[ExcludeFromCodeCoverage]
class FooExtension
{
  public int Value { get; set; }
}

[ExcludeFromCodeCoverage]
class BarExtension : FooExtension
{
  public BarExtension() : base()
  {
  }
}
