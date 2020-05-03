using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonTagger.BusinessLogic
{
    public static class FileTags
    {
        public static string ConvertToSpaceDelimitedString(IEnumerable<string> tags)
        {
            return
                tags
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .Aggregate("", (x, y) => x == "" ? y : x + ' ' + y);
        }

        public static string ConvertToJson(IEnumerable<string> tags)
        {
            string spaceDelimited = ConvertToSpaceDelimitedString(tags);
            return "{\"tags\":" + JsonConvert.ToString(spaceDelimited) + "}";
        }
    }
}
