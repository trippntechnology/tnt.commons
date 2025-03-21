using System.Diagnostics.CodeAnalysis;

namespace TNT.Commons;

/// <summary>
/// Extension methods
/// </summary>
public static class Extensions
{
  /// <summary>
  /// Calls <paramref name="func"/> with <paramref name="it"/> as the parameter and returns the value returned
  /// by <paramref name="func"/>
  /// </summary>
  /// <typeparam name="T">Type of <paramref name="it"/></typeparam>
  /// <typeparam name="R">Type of return value</typeparam>
  /// <param name="it">Object calling extension method</param>
  /// <param name="func"><see cref="Func{T, TResult}"/> that takes <paramref name="it"/> as the parameter
  /// and return value of type <typeparamref name="R"/></param>
  /// <returns>The value returned by <paramref name="func"/></returns>
  public static R Let<T, R>(this T it, Func<T, R> func) => func(it);

  /// <summary>
  /// Calls <paramref name="func"/> with <paramref name="it"/> as the parameter and returns the value returned
  /// by <paramref name="func"/>
  /// </summary>
  /// <typeparam name="T">Type of <paramref name="it"/></typeparam>
  /// <typeparam name="R">Type of return value</typeparam>
  /// <param name="it">Object calling extension method</param>
  /// <param name="func"><see cref="Func{T, TResult}"/> that takes <paramref name="it"/> as the parameter
  /// and return value of type <typeparamref name="R"/></param>
  /// <returns>The value returned by <paramref name="func"/></returns>
  [Obsolete("Use Let instead")]
  [ExcludeFromCodeCoverage]
  public static R let<T, R>(this T it, Func<T, R> func) => func(it);

  /// <summary>
  /// Calls <paramref name="action"/> with <paramref name="it"/> as the parameter and return <paramref name="it"/>
  /// </summary>
  /// <typeparam name="T">Type of <paramref name="it"/></typeparam>
  /// <param name="it">Object calling extension method</param>
  /// <param name="action"><see cref="Action{T}"/> that takes <paramref name="it"/> as the parameter</param>
  /// <returns><paramref name="it"/></returns>
  public static T Also<T>(this T it, Action<T> action)
  {
    action(it);
    return it;
  }

  /// <summary>
  /// Calls <paramref name="action"/> with <paramref name="it"/> as the parameter and return <paramref name="it"/>
  /// </summary>
  /// <typeparam name="T">Type of <paramref name="it"/></typeparam>
  /// <param name="it">Object calling extension method</param>
  /// <param name="action"><see cref="Action{T}"/> that takes <paramref name="it"/> as the parameter</param>
  /// <returns><paramref name="it"/></returns>
  [Obsolete("Use Also instead")]
  [ExcludeFromCodeCoverage]
  public static T also<T>(this T it, Action<T> action)
  {
    action(it);
    return it;
  }

  /// <summary>
  /// Calls <paramref name="action"/> when <typeparamref name="T1"/> can be cast to <typeparamref name="T2"/> and 
  /// passes<typeparamref name="T2"/> to <paramref name="action"/>
  /// </summary>
  /// <typeparam name="T1">Base type</typeparam>
  /// <typeparam name="T2">Super type</typeparam>
  /// <param name="obj">Object that needs to be cast</param>
  /// <param name="action">Action to take </param>
  public static void WhenType<T1, T2>(this T1 obj, Action<T2> action)
  {
    if (obj is T2 value) action(value);
  }

  /// <summary>
  /// Calls <paramref name="action"/> when <typeparamref name="T1"/> can be cast to <typeparamref name="T2"/> and 
  /// passes<typeparamref name="T2"/> to <paramref name="action"/>
  /// </summary>
  /// <typeparam name="T1">Base type</typeparam>
  /// <typeparam name="T2">Super type</typeparam>
  /// <param name="obj">Object that needs to be cast</param>
  /// <param name="action">Action to take </param>
  [Obsolete("Use WhenType instead")]
  [ExcludeFromCodeCoverage]
  public static void whenType<T1, T2>(this T1 obj, Action<T2> action)
  {
    if (obj is T2 value) action(value);
  }

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