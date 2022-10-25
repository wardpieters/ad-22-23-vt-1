using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace AD
{
    public partial class Graph : IGraph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        public Dictionary<string, Vertex> vertexMap;


        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Graph()
        {
            vertexMap = new Dictionary<string, Vertex>();
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Adds a vertex to the graph. If a vertex with the given name
        ///    already exists, no action is performed.
        /// </summary>
        /// <param name="name">The name of the new vertex</param>
        public void AddVertex(string name)
        {
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.Add(name, new Vertex(name));
            }
        }


        /// <summary>
        ///    Gets a vertex from the graph by name. If no such vertex exists,
        ///    a new vertex will be created and returned.
        /// </summary>
        /// <param name="name">The name of the vertex</param>
        /// <returns>The vertex withe the given name</returns>
        public Vertex GetVertex(string name)
        {
            // Add new vertex if it does not exists.
            if (!vertexMap.ContainsKey(name))
            {
                vertexMap.Add(name, new Vertex(name));
            }

            return vertexMap[name];
        }


        /// <summary>
        ///    Creates an edge between two vertices. Vertices that are non existing
        ///    will be created before adding the edge.
        ///    There is no check on multiple edges!
        /// </summary>
        /// <param name="source">The name of the source vertex</param>
        /// <param name="dest">The name of the destination vertex</param>
        /// <param name="cost">cost of the edge</param>
        public void AddEdge(string source, string dest, double cost = 1)
        {
            Vertex v = GetVertex(source);
            Vertex w = GetVertex(dest);
            v.adj.AddFirst(new Edge(w, cost));
        }


        /// <summary>
        ///    Clears all info within the vertices. This method will not remove any
        ///    vertices or edges.
        /// </summary>
        public void ClearAll()
        {
            foreach (var (_, vertex) in vertexMap) {
                vertex.Reset();
            }
        }

        /// <summary>
        ///    Performs the Breatch-First algorithm for unweighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Unweighted(string name)
        {
            // Breatch algorithm for unweighted graphs in c#
            // http://www.csharpstar.com/csharp-breatch-algorithm-for-unweighted-graphs/

            Queue<Vertex> q = new Queue<Vertex>();
            Vertex start = GetVertex(name);

            start.distance = 0;
            start.prev = null;
            q.Enqueue(start);

            while (q.Count > 0)
            {
                Vertex v = q.Dequeue();

                foreach (Edge e in v.adj)
                {
                    Vertex w = e.dest;
                    if (w.distance.Equals(INFINITY))
                    {
                        w.distance = v.distance + 1;
                        w.prev = v;
                        q.Enqueue(w);
                    }
                }
            }
        }

        /// <summary>
        ///    Performs the Dijkstra algorithm for weighted graphs.
        /// </summary>
        /// <param name="name">The name of the starting vertex</param>
        public void Dijkstra(string name)
        {
            // Dijkstra algorithm using priority queue in c#
            
            // Create a new priority queue
            PriorityQueue<Vertex> priorityQueue = new PriorityQueue<Vertex>();
            // Reset all the vertexes
            ClearAll();
            // Start vertex
            Vertex start = GetVertex(name);
            // Set the distance of the start vertex to 0
            start.distance = 0;
            // Add the starting vertex to the queue
            priorityQueue.Add(start);
            // The amount of nodes discovered
            int nodesSeen = 0;
            while (!priorityQueue.Size().Equals(0) && nodesSeen < vertexMap.Count) {
                // Grab the next vertex
                Vertex vertex = priorityQueue.Remove();
                // If the vertex is already known skip it
                if(vertex.known) continue;
                // Change the current vertex to known
                vertex.known = true;
                // Increase the nodes seen
                nodesSeen++;
                // Go over all the edges connected to the vertex
                foreach (Edge edge in vertex.GetAdjacents()) {
                    // Grab the neighbor vertex
                    Vertex neighbor = edge.dest;
                    double cost = edge.cost;
                    // Don't allow negative edges
                    if (cost < 0) throw new Exception("Graph has negative edges");
                    // If the current edge results in a cheaper path update the vertex
                    if (neighbor.distance > vertex.distance + cost) {
                        neighbor.distance = vertex.distance + cost;
                        neighbor.prev = vertex;
                        // Add the neighbor to the priority queue to calculate the rest of the possible paths
                        priorityQueue.Add(neighbor);
                    }
                }
            }
        }

        //----------------------------------------------------------------------
        // ToString that has to be implemented for exam
        //----------------------------------------------------------------------

        /// <summary>
        ///    Converts this instance of Graph to its string representation.
        ///    It will call the ToString method of each Vertex. The output is
        ///    ascending on vertex name.
        /// </summary>
        /// <returns>The string representation of this Graph instance</returns>
        public override string ToString()
        {
            string output = "";
            
            foreach (var vertex in vertexMap.OrderBy(v => v.Key))
            {
                output += $"{vertex.Value}\n";
            }

            return output;
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public bool IsConnected()
        {
            throw new System.NotImplementedException();
        }
    }
}