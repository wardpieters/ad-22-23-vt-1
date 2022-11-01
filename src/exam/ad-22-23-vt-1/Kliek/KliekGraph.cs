using System.Collections.Generic;

namespace AD
{
    public partial class Graph
    {
        public Vertex HoogsteGraad()
        {
            Vertex max = null;

            foreach (var (_, vertex) in vertexMap)
            {
                if (max == null || vertex.adj.Count > max.adj.Count)
                {
                    max = vertex;
                }
            }

            return max;
        }

        public HashSet<Vertex> MaximaleKliek()
        {
            var kliek = new HashSet<Vertex> { HoogsteGraad() };

            bool vertexAvailable = true;

            while (vertexAvailable)
            {
                // ... idk
                break;
            }

            return kliek;
        }
    }
}
