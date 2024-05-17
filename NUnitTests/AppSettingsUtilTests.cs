using NUnitTests.JsonTests;
using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests;

[ExcludeFromCodeCoverage]
internal class AppSettingsUtilTests
{
  [Test]
  public void Test1()
  {
    var fileNotFound = AppSettingsUtils.DeserializeSection<BaseClass>("invalidfile", "BaseClass");
    Assert.That(fileNotFound, Is.Null);

    // Invalid JSON
    var invalidJson = AppSettingsUtils.DeserializeSection<BaseClass>("TNT.Commons.xml", "BaseClass");
    Assert.That(invalidJson, Is.Null);

    // Invalid section
    var invalidSection = AppSettingsUtils.DeserializeSection<BaseClass>("appsettings.json", "InvalidSectionName");
    Assert.That(invalidSection, Is.Null);

    var result = AppSettingsUtils.DeserializeSection<BaseClass>("appsettings.json", "BaseClass");
    Assert.That(result, Is.Not.Null);
  }
}
