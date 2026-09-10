using DictionaryGraph.Parser;

var dictionaryGraph = DictionaryParser.ParseDictionary("dictionary.json");

Console.WriteLine(string.Join(", ", dictionaryGraph.NodeConnections["bat"]));