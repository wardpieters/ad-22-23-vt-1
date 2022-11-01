using System.Collections.Generic;
using System.Linq;


namespace AD
{
    class Program
    {
        public static void AddUndirectedEdge(Graph g, string a, string b)
        {
            g.AddEdge(a, b, 1);
            g.AddEdge(b, a, 1);
        }

        public static Graph UnweightedUndirectedKliek()
        {
            Graph graph = new Graph();

            AddUndirectedEdge(graph, "A", "C");
            AddUndirectedEdge(graph, "A", "B");
            AddUndirectedEdge(graph, "B", "C");
            AddUndirectedEdge(graph, "B", "D");
            AddUndirectedEdge(graph, "B", "F");
            AddUndirectedEdge(graph, "C", "D");
            AddUndirectedEdge(graph, "D", "E");
            AddUndirectedEdge(graph, "D", "F");
            AddUndirectedEdge(graph, "D", "G");
            AddUndirectedEdge(graph, "D", "H");
            AddUndirectedEdge(graph, "E", "F");
            AddUndirectedEdge(graph, "F", "G");
            AddUndirectedEdge(graph, "F", "H");
            AddUndirectedEdge(graph, "G", "H");

            return graph;
        }

        static void Main(string[] args)
        {
            Graph kliek = UnweightedUndirectedKliek();

            System.Console.WriteLine("=== Graad() ===");
            foreach (string key in kliek.vertexMap.Keys.OrderBy(x => x))
            {
                Vertex v = kliek.vertexMap[key];
                System.Console.WriteLine(v.GetName() + " : " + v.Graad());
            }

            System.Console.WriteLine();
            System.Console.WriteLine("=== HoogsteGraad() ===");
            System.Console.WriteLine($"De vertex met de hoogste graad is : {kliek.HoogsteGraad().GetName()}");

            System.Console.WriteLine();
            System.Console.WriteLine("=== IsVerbondenMetAllemaal() ===");
            HashSet<Vertex> set = new HashSet<Vertex>();
            set.Add(kliek.GetVertex("B"));
            set.Add(kliek.GetVertex("C"));
            System.Console.WriteLine($"A met B + C : {kliek.GetVertex("A").IsVerbondenMetAllemaal(set)}");
            set.Add(kliek.GetVertex("E"));
            set.Add(kliek.GetVertex("F"));
            set.Add(kliek.GetVertex("G"));
            set.Add(kliek.GetVertex("H"));
            System.Console.WriteLine($"D met B + C + E + F + G + H : {kliek.GetVertex("D").IsVerbondenMetAllemaal(set)}");
            set.Add(kliek.GetVertex("A"));
            System.Console.WriteLine($"D met A + B + C + E + F + G + H : {kliek.GetVertex("D").IsVerbondenMetAllemaal(set)}");

            System.Console.WriteLine();
            System.Console.WriteLine("=== MaximaleKliek() ===");
            System.Console.Write("En maximale kliek is:");
            foreach (Vertex v in kliek.MaximaleKliek().OrderBy(v => v.GetName()))
            {
                System.Console.Write($" {v.GetName()}");
            }
            System.Console.WriteLine();
        }
    }
}
