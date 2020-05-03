using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace JsonTagger.DataModel
{
    public class IndexedFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FilePath { get; set; } = null!;

        public string Source { get; set; } = null!;

        public string AltSource { get; set; } = null!;

        public string UserJson { get; set; } = null!;

        public string OriginalFilePath { get; set; } = null!;

        public string GuidFilePath { get; set; } = null!;

        public int? CachedWidth { get; set; }

        public int? CachedHeight { get; set; }

        public string CachedShortImageStr { get; set; } = null!;

        public ICollection<IndexedFileTagPair> FileTagPairs { get; set; } = null!;

        public string Tags()
        {
            List<string> tags = FileTagPairs
                .Select(x => x.Tag)
                .Where(x => !String.IsNullOrWhiteSpace(x))
                .ToList();

            // Might not be required; test with unit test
            if (tags.Count == 0)
                return "";

            return tags.Aggregate((x, y) => x + ' ' + y);
        }

        public string Json()
        {
            return "{tags:\"" + Tags() + "\"}";
        }
    }
}
