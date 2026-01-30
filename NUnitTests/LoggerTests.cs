using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TNT.Commons;

namespace NUnitTests;

[TestFixture]
[ExcludeFromCodeCoverage]
public class LoggerTests
{
    private StringBuilder _output;
    private TextWriterTraceListener _listener;

    [SetUp]
    public void SetUp()
    {
        _output = new StringBuilder();
        _listener = new TextWriterTraceListener(new StringWriter(_output));
        Trace.Listeners.Add(_listener);
    }

    [TearDown]
    public void TearDown()
    {
        Trace.Listeners.Remove(_listener);
        _listener.Dispose();
    }

    [Test]
    public void Info_LogsExpectedMessage()
    {
        var lineNumber = GetCurrentLineNumber() + 1;
        Logger.Info("Test message");
        Trace.Flush();
        var expected = $"[LoggerTests:{lineNumber}:Info_LogsExpectedMessage] Test message\r\n";
        Assert.That(_output.ToString(), Is.EqualTo(expected));
    }

    [Test]
    public void MeasureTimeMillis_LogsElapsedTime()
    {
        var lineNumber = GetCurrentLineNumber() + 1;
        Logger.MeasureTimeMillis(() => System.Threading.Thread.Sleep(10), "Timing test");
        Trace.Flush();
        var log = _output.ToString();
        var pattern = $@"\[LoggerTests:{lineNumber}:MeasureTimeMillis_LogsElapsedTime\] \[\d{{1,4}} ms\] Timing test";
        Assert.That(System.Text.RegularExpressions.Regex.IsMatch(log, pattern), $"Log output did not match. Output: {log}");
    }

    private int GetCurrentLineNumber([System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0) => lineNumber;

}
