using System;
using System.Collections.Generic;
using System.Linq;

namespace AD
{
    public partial class Vertex
    {
        public int Graad()
        {
            return adj.Count;
        }

        public bool IsVerbondenMetAllemaal(HashSet<Vertex> vertices)
        {
            return vertices.All(IsConnected);
        }
        
        private bool IsConnected(Vertex v)
        {
            foreach (var edge in adj)
            {
                if (edge.dest.name.Equals(v.name)) return true;
            }

            return false;
        }

        private bool isVerbonden2(Vertex a, Vertex b)
        {
            foreach (var edge in a.adj)
            {
                if (edge.dest.name.Equals(b.name))
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}
