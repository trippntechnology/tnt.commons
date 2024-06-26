﻿using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests;

[ExcludeFromCodeCoverage]
public class ExtensionTests
{
  [Test]
  public void Extensions_Let()
  {
    var result = new FooExtension() { Value = 7 }.let(it =>
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
    var result = fooExt?.let(it => 7) ?? 11;

    Assert.That(result, Is.EqualTo(11));
  }

  [Test]
  public void Extensions_Also()
  {
    var result = new FooExtension() { Value = 7 }.also(it =>
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

    value.whenType<FooExtension, BarExtension>(d =>
    {
      success = true;
    });

    Assert.That(success, Is.True, "whenType failed to cast to type");

    value.whenType<FooExtension, FormatException>(d =>
    {
      success = false;
    });

    Assert.That(success, Is.True);
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
