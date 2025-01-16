using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
internal class JsonTests
{
  private string EXPECTED_JSON1 = "";
  private string EXPECTED_JSON2 = "";

  [SetUp]
  public void Setup()
  {
    EXPECTED_JSON1 = File.ReadAllText("expected1.json").Replace("\t", "").Replace(" ", "");
    EXPECTED_JSON2 = File.ReadAllText("expected2.json").Replace("\t", "").Replace(" ", "");
  }

  [Test]
  public void Json_serialize_deserialize()
  {
    var sut = new JsonTestClass()
    {
      ListExample = new List<BaseClass> {
        new ExtExtBaseClass1(){ baseIntProperty =3 , baseStringProperty = "three", e1IntProperty = 33, e1StringProperty = "thirty-three", MyLong = 333L, myEnum = MyEnum.ENUM3},
        new ExtBaseClass1() { baseIntProperty=2, baseStringProperty = "Two", e1IntProperty = 22, e1StringProperty = "twenty-two"},
        new BaseClass(){baseIntProperty = 1, baseStringProperty = "one"},
      },
      IntExample = 27,
      StringExample = "twenty-seven",
      BaseClassExample = new ExtBaseClass1() { baseIntProperty = 2, baseStringProperty = "Two", e1IntProperty = 22, e1StringProperty = "twenty-two" }
    };

    var settings = new JsonSerializerSettings()
    {
      Formatting = Formatting.Indented,
      TypeNameHandling = TypeNameHandling.All,
    };

    string json1 = Json.serializeObject(sut, settings).Replace(" ", "");
    Assert.That(json1, Is.EqualTo(EXPECTED_JSON1));
    string json2 = Json.serializeObject(sut, settings).Replace(" ", "");
    Assert.That(json2, Is.EqualTo(EXPECTED_JSON2));
    var deserializedSut = Json.deserializeJson<JsonTestClass>(json2, settings);
    Assert.That(deserializedSut, Is.EqualTo(sut));
    Assert.That(deserializedSut.ListExample, Is.EqualTo(sut.ListExample));
  }
}
