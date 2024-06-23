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

    string json1 = Json.serializeObject(sut, settings);
    Assert.That(json1, Is.EqualTo(EXPECTED_JSON1));
    string json2 = Json.serializeObject(sut);
    Assert.That(json2, Is.EqualTo(EXPECTED_JSON2));
    var deserializedSut = Json.deserializeJson<JsonTestClass>(json2, settings);
    Assert.That(deserializedSut, Is.EqualTo(sut));
    Assert.That(deserializedSut.ListExample, Is.EqualTo(sut.ListExample));
  }

  private const string EXPECTED_JSON1 = @"{
  ""$type"": ""NUnitTests.JsonTests.JsonTestClass, NUnitTests"",
  ""ListExample"": {
    ""$type"": ""System.Collections.Generic.List`1[[NUnitTests.JsonTests.BaseClass, NUnitTests]], System.Private.CoreLib"",
    ""$values"": [
      {
        ""$type"": ""NUnitTests.JsonTests.ExtExtBaseClass1, NUnitTests"",
        ""MyLong"": 333,
        ""myEnum"": 2,
        ""e1IntProperty"": 33,
        ""e1StringProperty"": ""thirty-three"",
        ""baseIntProperty"": 3,
        ""baseStringProperty"": ""three""
      },
      {
        ""$type"": ""NUnitTests.JsonTests.ExtBaseClass1, NUnitTests"",
        ""e1IntProperty"": 22,
        ""e1StringProperty"": ""twenty-two"",
        ""baseIntProperty"": 2,
        ""baseStringProperty"": ""Two""
      },
      {
        ""$type"": ""NUnitTests.JsonTests.BaseClass, NUnitTests"",
        ""baseIntProperty"": 1,
        ""baseStringProperty"": ""one""
      }
    ]
  },
  ""IntExample"": 27,
  ""StringExample"": ""twenty-seven"",
  ""myEnum"": 0,
  ""BaseClassExample"": {
    ""$type"": ""NUnitTests.JsonTests.ExtBaseClass1, NUnitTests"",
    ""e1IntProperty"": 22,
    ""e1StringProperty"": ""twenty-two"",
    ""baseIntProperty"": 2,
    ""baseStringProperty"": ""Two""
  }
}";

  private const string EXPECTED_JSON2 = @"{""$type"":""NUnitTests.JsonTests.JsonTestClass, NUnitTests"",""ListExample"":{""$type"":""System.Collections.Generic.List`1[[NUnitTests.JsonTests.BaseClass, NUnitTests]], System.Private.CoreLib"",""$values"":[{""$type"":""NUnitTests.JsonTests.ExtExtBaseClass1, NUnitTests"",""MyLong"":333,""myEnum"":2,""e1IntProperty"":33,""e1StringProperty"":""thirty-three"",""baseIntProperty"":3,""baseStringProperty"":""three""},{""$type"":""NUnitTests.JsonTests.ExtBaseClass1, NUnitTests"",""e1IntProperty"":22,""e1StringProperty"":""twenty-two"",""baseIntProperty"":2,""baseStringProperty"":""Two""},{""$type"":""NUnitTests.JsonTests.BaseClass, NUnitTests"",""baseIntProperty"":1,""baseStringProperty"":""one""}]},""IntExample"":27,""StringExample"":""twenty-seven"",""myEnum"":0,""BaseClassExample"":{""$type"":""NUnitTests.JsonTests.ExtBaseClass1, NUnitTests"",""e1IntProperty"":22,""e1StringProperty"":""twenty-two"",""baseIntProperty"":2,""baseStringProperty"":""Two""}}";
}
