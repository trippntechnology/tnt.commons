using System.IO.Compression;

namespace TNT.Commons;

/// <summary>
/// Utility class to assist in zipping and unzipping a file
/// </summary>
public static class ZipUtils
{
  /// <summary>
  /// Adds the <paramref name="content"/> to a zip file named <paramref name="archiveFileName"/>
  /// </summary>
  /// <param name="content">Content to archive</param>
  /// <param name="entryName">Entry name used in archive for <paramref name="content"/></param>
  /// <param name="archiveFileName">Name of archive file</param>
  public static void ArchiveString(string content, string entryName, string archiveFileName)
  {
    // Create a MemoryStream to hold the ZIP archive
    using (MemoryStream zipStream = new MemoryStream())
    {
      // Create the ZIP archive in the memory stream
      using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
      {
        // Create a new entry for the string in the ZIP archive
        ZipArchiveEntry entry = archive.CreateEntry(entryName);

        // Write the string to the entry
        using (StreamWriter writer = new StreamWriter(entry.Open()))
        {
          writer.Write(content);
        }
      }

      // At this point, the ZIP archive is fully written in zipStream
      // Example: Save the ZIP archive to a file (optional)
      File.WriteAllBytes(archiveFileName, zipStream.ToArray());
    }
  }

  /// <summary>
  /// Unzips the <paramref name="entryName"/> from <paramref name="archiveFileName"/> and return the contents
  /// </summary>
  /// <param name="entryName">Name of entry to extract</param>
  /// <param name="archiveFileName">Name of archive file</param>
  /// <returns></returns>
  public static string? ExtractString(string entryName, string archiveFileName)
  {
    string? content = null;

    // Open the ZIP archive
    using (ZipArchive zipArchive = ZipFile.OpenRead(archiveFileName))
    {
      // Find the specified entry
      ZipArchiveEntry? entry = zipArchive.GetEntry(entryName);

      if (entry != null)
      {
        // Read the content of the entry
        using (StreamReader reader = new StreamReader(entry.Open()))
        {
          content = reader.ReadToEnd();
        }
      }
    }

    return content;
  }

  /// <summary>
  /// Arcives <paramref name="archiveFileName"/>
  /// </summary>
  /// <exception cref="FileNotFoundException">Thrown if a file included in <paramref name="archiveFileName"/> can not be found</exception>
  public static void ArchiveFiles(string[] filesToArchive, string archiveFileName)
  {
    // 1. Create the zip archive:
    using (FileStream zipFile = File.Create(archiveFileName))
    using (ZipArchive archive = new ZipArchive(zipFile, ZipArchiveMode.Create))
    {
      // 2. Add each file to the archive:
      foreach (string file in filesToArchive)
      {
        if (File.Exists(file)) // Check if file exists
        {
          string entryName = Path.GetFileName(file); // Get the file name for the entry
          archive.CreateEntryFromFile(file, entryName);
        }
        else
        {
          throw new FileNotFoundException($"File not found: {file}");
        }
      }
    }
  }
}
