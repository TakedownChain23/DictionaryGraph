using DictionaryGraph.Graph;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace DictionaryGraph.Parser
{
    internal static class DictionaryParser
    {
        public static DirectedGraph ParseDictionary(string jsonPath)
        {
            using FileStream stream = File.OpenRead(jsonPath);

            var jsonDocument = JsonDocument.Parse(stream);
            var rootElement = jsonDocument.RootElement;

            var dictionaryGraph = new DirectedGraph();

            var wordRegex = new Regex(@"\b\w+\b", RegexOptions.Compiled);

            foreach (var wordProperty in rootElement.EnumerateObject())
            {
                var word = wordProperty.Name.ToLower().Trim();
                var wordData = wordProperty.Value;

                var definitionWords = new OrderedSet<string>();

                var meaningsElementArray = wordData.GetProperty("MEANINGS").EnumerateArray();
                if (meaningsElementArray.Any())
                {
                    foreach (var meaningArray in meaningsElementArray)
                    {
                        var definition = meaningArray[1].GetString()?.ToLower().Trim() ?? string.Empty;
                        foreach (Match match in wordRegex.Matches(definition))
                        {
                            definitionWords.Add(match.Value);
                        }
                    }
                }
                else
                {
                    var synonymnArray = wordData.GetProperty("SYNONYMS").EnumerateArray();
                    foreach (var synonymElement in synonymnArray)
                    {
                        var synonym = synonymElement.GetString()?.ToLower().Trim() ?? string.Empty;
                        foreach (Match match in wordRegex.Matches(synonym))
                        {
                            definitionWords.Add(match.Value);
                        }
                    }
                }

                dictionaryGraph.AddNode(word, definitionWords);
            }

            return dictionaryGraph;
        }
    }
}
