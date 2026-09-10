using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGraph.Graph
{
    internal class DirectedGraph
    {
        public Dictionary<string, HashSet<string>> NodeConnections = [];

        HashSet<string> GetOrInitialiseConnections(string value)
        {
            if (NodeConnections.TryGetValue(value, out var connections)) return connections;

            connections = [];
            NodeConnections[value] = connections;
            return connections;
        }

        public void AddNode(string value, HashSet<string> neighborValues)
        {
            var connections = GetOrInitialiseConnections(value);
            connections.AddRange(neighborValues);
        }
    }   
}
