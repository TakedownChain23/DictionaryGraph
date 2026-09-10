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

                var meaningsElement = wordData.GetProperty("MEANINGS");

                var definitionWords = new HashSet<string>();

                foreach (var meaningArray in meaningsElement.EnumerateArray())
                {
                    var definition = meaningArray[1].GetString() ?? string.Empty;

                    foreach (Match match in wordRegex.Matches(definition))
                    {
                        definitionWords.Add(match.Value);
                    }
                }

                dictionaryGraph.AddNode(word, definitionWords);
            }

            return dictionaryGraph;
        }
    }
}
