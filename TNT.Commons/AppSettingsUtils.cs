using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TNT.Commons;

/// <summary>
/// Utility class to assist with appsettings access
/// </summary>
public static class AppSettingsUtils
{
  /// <summary>
  /// Deserializes the section given by <paramref name="sectionName"/> in an appsettings file  located at <paramref name="appSettingsPath"/>
  /// </summary>
  /// <typeparam name="T">Type represented by section</typeparam>
  /// <returns>Deserialized section</returns>
  public static T? DeserializeSection<T>(string appSettingsPath, string sectionName)
  {
    try
    {
      string json = File.ReadAllText(appSettingsPath);
      JToken? appSettingsToken = JsonConvert.DeserializeObject<JToken>(json);
      if (appSettingsToken == null) return default(T);

      string? sectionJson = appSettingsToken[sectionName]?.ToString();
      if (sectionJson == null) return default(T);

      return Json.deserializeJson<T>(sectionJson);
    }
    catch (Exception)
    {
      return default(T);
    }
  }
}
