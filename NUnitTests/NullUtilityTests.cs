using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests;

[ExcludeFromCodeCoverage]
public class NullUtilityTests
{
  [Test]
  public void NullUtility_RunNotNull_BothNotNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
      Assert.That(param1, Is.EqualTo(v1));
      Assert.That(param2, Is.EqualTo(v2));
    });

    Assert.That(callbackInvoked, Is.True);
  }

  [Test]
  public void NullUtility_RunNotNull_FirstNull()
  {
    string? v1 = null;
    string? v2 = "Test2";
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_SecondNull()
  {
    string? v1 = "Test1";
    string? v2 = null;
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_BothNull()
  {
    string? v1 = null;
    string? v2 = null;
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, (param1, param2) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_ThreeParams_AllNotNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    string? v3 = "Test3";
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
      Assert.That(param1, Is.EqualTo(v1));
      Assert.That(param2, Is.EqualTo(v2));
      Assert.That(param3, Is.EqualTo(v3));
    });

    Assert.That(callbackInvoked, Is.True);
  }

  [Test]
  public void NullUtility_RunNotNull_ThreeParams_FirstNull()
  {
    string? v1 = null;
    string? v2 = "Test2";
    string? v3 = "Test3";
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_ThreeParams_SecondNull()
  {
    string? v1 = "Test1";
    string? v2 = null;
    string? v3 = "Test3";
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_ThreeParams_ThirdNull()
  {
    string? v1 = "Test1";
    string? v2 = "Test2";
    string? v3 = null;
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }

  [Test]
  public void NullUtility_RunNotNull_ThreeParams_AllNull()
  {
    string? v1 = null;
    string? v2 = null;
    string? v3 = null;
    var callbackInvoked = false;

    NullUtility.RunNotNull(v1, v2, v3, (param1, param2, param3) =>
    {
      callbackInvoked = true;
    });

    Assert.That(callbackInvoked, Is.False);
  }
}
