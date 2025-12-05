using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace TNT.Commons;

/// <summary>
/// Provides simple logging utilities for debugging and performance measurement.
/// </summary>
public static class Logger
{
    /// <summary>
    /// Logs an informational message to the trace output, including the calling method and file name.
    /// </summary>
    /// <param name="msg">The message to log. If omitted, only the context is logged.</param>
    /// <param name="callingMethod">The name of the calling method. Automatically supplied by the compiler; do not set manually.</param>
    /// <param name="filePath">The file path of the calling code. Automatically supplied by the compiler; do not set manually.</param>
    /// <remarks>
    /// Output format: [FileName:MethodName] message
    /// Example: [MyClass:MyMethod] Hello world
    /// </remarks>
    public static void Info(string msg = "", [CallerMemberName] string callingMethod = "", [CallerFilePath] string filePath = "")
    {
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        Trace.WriteLine($"[{fileName}:{callingMethod}] {msg}");
    }

    /// <summary>
    /// Measures the execution time of an action in milliseconds and logs the result to the trace output, including the calling method and file name.
    /// </summary>
    /// <param name="action">The action to measure. The code block to execute and time.</param>
    /// <param name="msg">An optional message to include in the log output after the elapsed time.</param>
    /// <param name="callingMethod">The name of the calling method. Automatically supplied by the compiler; do not set manually.</param>
    /// <param name="filePath">The file path of the calling code. Automatically supplied by the compiler; do not set manually.</param>
    /// <remarks>
    /// Output format: [FileName:MethodName] [N ms] message
    /// Example: [MyClass:MyMethod] [15 ms] Finished processing
    /// </remarks>
    public static void MeasureTimeMillis(Action action, string msg = "", [CallerMemberName] string callingMethod = "", [CallerFilePath] string filePath = "")
    {
        var fileName = Path.GetFileNameWithoutExtension(filePath);
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();

        var sb = new StringBuilder($"[{sw.ElapsedMilliseconds} ms]");
        if (!String.IsNullOrWhiteSpace(msg)) sb.Append($" {msg}");

        Trace.WriteLine($"[{fileName}:{callingMethod}] {sb}");
    }
}
