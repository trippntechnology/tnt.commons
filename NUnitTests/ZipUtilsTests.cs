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

  [Test]
  public void Test_ArchiveFiles()
  {
    var fileName = Path.GetRandomFileName();
    var filesToArchive = new string[] {
      "NUnitTests.dll",
      "NUnitTests.pdb"
    };

    ZipUtils.ArchiveFiles(filesToArchive, fileName);

    Assert.That(File.Exists(fileName), Is.True);
    File.Delete(fileName);

    filesToArchive = new string[] {
      "NUnitTests.dll",
      "NUnitTests.pdb",
      "InvalidFileName.foo"
    };

    Assert.Throws<FileNotFoundException>(() => ZipUtils.ArchiveFiles(filesToArchive, fileName));
  }
}
