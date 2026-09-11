using DictionaryGraph.Parser;
using DictionaryGraph.WordLearner;

var dictionaryGraph = DictionaryParser.ParseDictionary("dictionary.json");

Console.WriteLine($"{dictionaryGraph.NodeConnections.Count} word definitions parsed");

using var writer = new StreamWriter("output.txt");
var wordLearner = new WordLearner(dictionaryGraph, writer);

var word = "world";
wordLearner.LearnWord(word);
Console.WriteLine($"Number of words required to learn word {word}: {wordLearner.LearntWordCount}");

//var max = 0;
//var min = int.MaxValue;

//Parallel.ForEach(dictionaryGraph.NodeConnections.Keys, (string word) =>
//{
//    var wordLearner = new WordLearner(dictionaryGraph);
//    wordLearner.LearnWord(word);

//    if (wordLearner.LearntWordCount > max)
//    {
//        max = wordLearner.LearntWordCount;
//        Console.WriteLine($"Max required words found: {word} {max}");
//    }
//    else if (wordLearner.LearntWordCount < min && wordLearner.LearntWordCount > 100)
//    {
//        min = wordLearner.LearntWordCount;
//        Console.WriteLine($"Min required words found: {word} {min}");
//    }
//});

//foreach (var word in dictionaryGraph.NodeConnections.Keys)
//{
//    var wordLearner = new WordLearner(dictionaryGraph);
//    wordLearner.LearnWord(word);
//    Console.WriteLine($"Number of words required to learn word {word}: {wordLearner.LearntWordCount}");
//}

//foreach (var word2 in dictionaryGraph.NodeConnections.Keys)
//{
//    var wordLearner2 = new WordLearner(dictionaryGraph);
//    wordLearner2.LearnWord(word2);

//    var learntWordDifference = wordLearner.LearntWords.Except(wordLearner2.LearntWords).Union(wordLearner2.LearntWords.Except(wordLearner.LearntWords));
//    Console.WriteLine($"difference between {word} and {word2}: {string.Join(", ", learntWordDifference)}");
//}

//var wordsAlwaysRequired = dictionaryGraph.NodeConnections.Keys.ToHashSet();
//var wordsNeverRequired = dictionaryGraph.NodeConnections.Keys.ToHashSet();
//foreach (var word2 in dictionaryGraph.NodeConnections.Keys)
//{
//    var wordLearner2 = new WordLearner(dictionaryGraph);
//    wordLearner2.LearnWord(word2);

//    if (wordLearner2.LearntWordCount > 100)
//    {
//        foreach (var requiredWord in wordsAlwaysRequired)
//        {
//            if (!wordLearner2.LearntWords.Contains(requiredWord))
//            {
//                wordsAlwaysRequired.Remove(requiredWord);
//            }
//        }
//    }

//    foreach (var learntWord in wordLearner2.LearntWords)
//    {
//        wordsNeverRequired.Remove(learntWord);
//    }

//    Console.WriteLine($"Words always required: {wordsAlwaysRequired.Count}, Words never required: {wordsNeverRequired.Count}");
//}