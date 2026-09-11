namespace DictionaryGraph.Graph
{
    internal class DirectedGraph
    {
        public Dictionary<string, OrderedSet<string>> NodeConnections = [];

        OrderedSet<string> GetOrInitialiseConnections(string value)
        {
            if (NodeConnections.TryGetValue(value, out var connections)) return connections;

            connections = [];
            NodeConnections[value] = connections;
            return connections;
        }

        public void AddNode(string value, OrderedSet<string> neighborValues)
        {
            var connections = GetOrInitialiseConnections(value);
            connections.AddRange(neighborValues);
        }
    }   
}
