using JsonTagger.BusinessLogic;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test.DataModel
{
    public class TestFileTags
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConvertTwoTagsToSpaceDelimitedString()
        {
            Assert.AreEqual(
                "test1 test2",
                FileTags.ConvertToSpaceDelimitedString(new List<string> {"test1", "test2"})
            );
        }

        [Test]
        public void ConvertEmptyStringToSpaceDelimitedString()
        {
            Assert.AreEqual(
                "",
                FileTags.ConvertToSpaceDelimitedString(new List<string> {})
            );
        }

        [Test]
        public void ConvertTwoTagsToJson()
        {
            Assert.AreEqual(
                "{\"tags\":\"test1 test2\"}",
                FileTags.ConvertToJson(new List<string> {"test1", "test2"})
            );
        }

        [Test]
        public void ConvertEmptyStringToJson()
        {
            Assert.AreEqual(
                "{\"tags\":\"\"}",
                FileTags.ConvertToJson(new List<string> {})
            );
        }

        [Test]
        public void ConvertSpecialCharactersToJson()
        {
            var outputJson = FileTags.ConvertToJson(new List<string> {"}\":{\\{"});

            Assert.DoesNotThrow(() => JsonConvert.DeserializeObject(outputJson));

            Assert.AreEqual(
                "{\"tags\":\"}\\\":{\\\\{\"}",
                outputJson
            );
        }
    }
}