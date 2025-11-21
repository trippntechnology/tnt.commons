namespace TNT.Commons;

/// <summary>
/// Utility methods for handling null values
/// </summary>
public static class NullUtility
{
  /// <summary>
  /// Runs <paramref name="callback"/> when <paramref name="v1"/> and <paramref name="v2"/> are not
  /// null
  /// </summary>
  public static void RunNotNull<T1, T2>(T1? v1, T2? v2, Action<T1, T2> callback)
  {
    if (v1 != null && v2 != null) callback(v1, v2);
  }

  /// <summary>
  /// Runs <paramref name="callback"/> when <paramref name="v1"/>, <paramref name="v2"/> and <paramref name="v3"/>
  /// are not null
  /// </summary>
  public static void RunNotNull<T1, T2, T3>(T1? v1, T2? v2, T3? v3, Action<T1, T2, T3> callback)
  {
    if (v1 != null && v2 != null && v3 != null) callback(v1, v2, v3);
  }
}
