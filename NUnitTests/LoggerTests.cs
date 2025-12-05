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
        Logger.Info("Test message");
        Trace.Flush();
        Assert.That(_output.ToString(), Is.EqualTo("[LoggerTests:Info_LogsExpectedMessage] Test message\r\n"));
    }

    [Test]
    public void MeasureTimeMillis_LogsElapsedTime()
    {
        Logger.MeasureTimeMillis(() => System.Threading.Thread.Sleep(10), "Timing test");
        Trace.Flush();
        var log = _output.ToString();
        var pattern = @"\[LoggerTests:MeasureTimeMillis_LogsElapsedTime\] \[\d{2} ms\] Timing test";
        Assert.That(System.Text.RegularExpressions.Regex.IsMatch(log, pattern));
    }
}
