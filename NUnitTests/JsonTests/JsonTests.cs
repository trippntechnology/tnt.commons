using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using TNT.Commons;

namespace NUnitTests.JsonTests;

[ExcludeFromCodeCoverage]
internal class JsonTests
{
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

    string json = Json.serializeObject(sut, settings);
    var deserializedSut = Json.deserializeJson<JsonTestClass>(json);
    Assert.That(deserializedSut, Is.EqualTo(sut));
    Assert.That(deserializedSut.ListExample, Is.EqualTo(sut.ListExample));
  }
}
