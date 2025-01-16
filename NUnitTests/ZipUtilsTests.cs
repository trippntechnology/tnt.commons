using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests;

[ExcludeFromCodeCoverage]
public class ZipUtilsTests
{
  [Test]
  public void Test_ArchiveString()
  {
    string stringToArchive = "This is the string to compress in the archive.";
    ZipUtils.ArchiveString(stringToArchive, "string.txt", "test.zip");

    string? entry = ZipUtils.ExtractString("invalidEntry", "test.zip");
    Assert.That(entry, Is.Null);

    entry = ZipUtils.ExtractString("string.txt", "test.zip");
    Assert.That(entry, Is.EqualTo(stringToArchive));
  }
}
