using DictionaryGraph.Graph;

namespace DictionaryGraph.WordLearner
{
    internal class WordLearner(DirectedGraph dictionaryGraph, StreamWriter? writer = null)
    {
        public readonly OrderedSet<string> LearntWords = [];

        public int LearntWordCount => LearntWords.Count;

        public void SeeWord(string word)
        {
            if (!LearntWords.Contains(word))
            {
                writer?.WriteLine(word);
            }
        }

        public void LearnWord(string startWord)
        {
            var stack = new Stack<string>();
            stack.Push(startWord);
            SeeWord(startWord);

            while (stack.Count > 0)
            {
                var word = stack.Pop();

                if (LearntWords.Contains(word)) continue;
                LearntWords.Add(word);

                writer?.WriteLine();
                writer?.WriteLine($"{word}:");

                var definitionWords = dictionaryGraph.NodeConnections.GetValueOrDefault(word) ?? [];
                foreach (var definitionWord in definitionWords)
                {
                    SeeWord(definitionWord);
                }

                foreach (var definitionWord in definitionWords.Reverse())
                {
                    stack.Push(definitionWord);
                }
            }
        }
    }
}
