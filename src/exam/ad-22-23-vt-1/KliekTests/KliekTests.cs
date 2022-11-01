using NUnit.Framework;
using System.Collections.Generic;

namespace AD
{
    public class Builder
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
        public static Graph Graph1()
        {
            Graph graph = new Graph();

            AddUndirectedEdge(graph, "A", "C");
            AddUndirectedEdge(graph, "A", "I");
            AddUndirectedEdge(graph, "B", "C");
            AddUndirectedEdge(graph, "B", "D");
            AddUndirectedEdge(graph, "B", "F");
            AddUndirectedEdge(graph, "C", "D");
            AddUndirectedEdge(graph, "C", "E");
            AddUndirectedEdge(graph, "C", "F");
            AddUndirectedEdge(graph, "C", "G");
            AddUndirectedEdge(graph, "C", "H");
            AddUndirectedEdge(graph, "C", "I");
            AddUndirectedEdge(graph, "D", "F");
            AddUndirectedEdge(graph, "D", "G");
            AddUndirectedEdge(graph, "D", "H");
            AddUndirectedEdge(graph, "D", "I");
            AddUndirectedEdge(graph, "E", "F");
            AddUndirectedEdge(graph, "F", "G");
            AddUndirectedEdge(graph, "F", "H");
            AddUndirectedEdge(graph, "F", "I");
            AddUndirectedEdge(graph, "H", "I");

            return graph;
        }

        public static Graph Graph2()
        {
            Graph graph = new Graph();

            AddUndirectedEdge(graph, "A", "B");
            AddUndirectedEdge(graph, "A", "C");
            AddUndirectedEdge(graph, "A", "D");
            AddUndirectedEdge(graph, "A", "E");
            AddUndirectedEdge(graph, "A", "F");
            AddUndirectedEdge(graph, "B", "D");
            AddUndirectedEdge(graph, "C", "D");
            AddUndirectedEdge(graph, "C", "F");
            AddUndirectedEdge(graph, "D", "E");
            AddUndirectedEdge(graph, "D", "F");
            AddUndirectedEdge(graph, "D", "G");
            AddUndirectedEdge(graph, "F", "G");

            return graph;
        }

        public static Graph Graph3()
        {
            Graph graph = new Graph();

            AddUndirectedEdge(graph, "A", "B");
            AddUndirectedEdge(graph, "A", "G");
            AddUndirectedEdge(graph, "A", "I");
            AddUndirectedEdge(graph, "B", "C");
            AddUndirectedEdge(graph, "B", "D");
            AddUndirectedEdge(graph, "B", "F");
            AddUndirectedEdge(graph, "B", "G");
            AddUndirectedEdge(graph, "B", "H");
            AddUndirectedEdge(graph, "B", "I");
            AddUndirectedEdge(graph, "C", "D");
            AddUndirectedEdge(graph, "C", "E");
            AddUndirectedEdge(graph, "C", "H");
            AddUndirectedEdge(graph, "D", "E");
            AddUndirectedEdge(graph, "E", "F");
            AddUndirectedEdge(graph, "E", "G");
            AddUndirectedEdge(graph, "E", "H");
            AddUndirectedEdge(graph, "E", "I");
            AddUndirectedEdge(graph, "F", "I");
            AddUndirectedEdge(graph, "G", "I");

            return graph;
        }

        public static Graph Graph4()
        {
            Graph graph = new Graph();

            AddUndirectedEdge(graph, "A", "D");
            AddUndirectedEdge(graph, "A", "G");
            AddUndirectedEdge(graph, "A", "I");
            AddUndirectedEdge(graph, "B", "D");
            AddUndirectedEdge(graph, "B", "F");
            AddUndirectedEdge(graph, "B", "G");
            AddUndirectedEdge(graph, "B", "I");
            AddUndirectedEdge(graph, "C", "D");
            AddUndirectedEdge(graph, "C", "I");
            AddUndirectedEdge(graph, "D", "G");
            AddUndirectedEdge(graph, "D", "I");
            AddUndirectedEdge(graph, "E", "G");
            AddUndirectedEdge(graph, "E", "I");
            AddUndirectedEdge(graph, "F", "G");
            AddUndirectedEdge(graph, "G", "I");
            AddUndirectedEdge(graph, "H", "I");

            return graph;
        }

        public static Graph Build(int graph_nr)
        {
            if (graph_nr == 0)
                return UnweightedUndirectedKliek();
            else if (graph_nr == 1)
                return Graph1();
            else if (graph_nr == 2)
                return Graph2();
            else if (graph_nr == 3)
                return Graph3();
            else if (graph_nr == 4)
                return Graph4();
            else
                return null;
        }
    }

    public class KliekTests
    {
        [Test]
        [TestCase(0, new int[] { 2, 4, 3, 6, 2, 5, 3, 3 })]
        [TestCase(1, new int[] { 2, 3, 8, 6, 2, 7, 3, 4, 5 })]
        [TestCase(2, new int[] { 5, 2, 3, 6, 2, 4, 2 })]
        [TestCase(3, new int[] { 3, 7, 4, 3, 6, 3, 4, 3, 5 })]
        [TestCase(4, new int[] { 3, 4, 2, 5, 2, 2, 6, 1, 7 })]
        public void Kliek_1_Graad(
            int graph_nr,
            int[] expected)
        {
            Graph g = Builder.Build(graph_nr);

            char vertex_char = 'A';
            for (int i = 0; i < expected.Length; i++)
            {
                string vertex_name = new string(vertex_char, 1);
                int actual = g.GetVertex(vertex_name).Graad();
                Assert.AreEqual(expected[i], actual, $"vertex={vertex_name}");
                vertex_char++;
            }
        }

        [Test]
        [TestCase(0, "D")]
        [TestCase(1, "C")]
        [TestCase(2, "D")]
        [TestCase(3, "B")]
        [TestCase(4, "I")]
        public void Kliek_2_HoogsteGraad(
            int graph_nr,
            string expected)
        {
            Graph g = Builder.Build(graph_nr);
            string actual = g.HoogsteGraad().GetName();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, "A", new string[] { "B", "C" }, true)]
        [TestCase(0, "D", new string[] { "B", "C", "E", "F", "G", "H" }, true)]
        [TestCase(0, "D", new string[] { "A", "B", "C", "E", "F", "G", "H" }, false)]
        [TestCase(1, "A", new string[] { "C", "I" }, true)]
        [TestCase(1, "A", new string[] { "C", "D", "I" }, false)]
        [TestCase(1, "C", new string[] { "A", "B", "D", "E", "F", "G", "H" }, true)]
        [TestCase(1, "C", new string[] { "A", "B", "D", "E", "F", "G", "H", "I" }, true)]
        [TestCase(2, "C", new string[] { "A", "D", "F" }, true)]
        [TestCase(2, "C", new string[] { "A", "B", "D", "F" }, false)]
        [TestCase(3, "C", new string[] { "B", "D", "E", "H" }, true)]
        [TestCase(3, "C", new string[] { "B", "D", "E", "H", "I" }, false)]
        [TestCase(4, "G", new string[] { "A", "B", "D", "E", "F", "I" }, true)]
        [TestCase(4, "G", new string[] { "A", "B", "C", "D", "E", "F", "I" }, false)]
        [TestCase(4, "G", new string[] { "A", "B", "D", "E", "F", "H", "I" }, false)]
        public void Kliek_3_IsVerbondenMetAllemaal(
            int graph_nr,
            string this_vertex_name,
            string[] other_vertices_names,
            bool expected)
        {
            Graph g = Builder.Build(graph_nr);
            HashSet<Vertex> other_vertices = new HashSet<Vertex>();
            foreach (string other_vertex_name in other_vertices_names)
            {
                other_vertices.Add(g.GetVertex(other_vertex_name));
            }
            bool actual = g.GetVertex(this_vertex_name).IsVerbondenMetAllemaal(other_vertices);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0, new string[] { "B", "D", "F" })]
        [TestCase(1, new string[] { "C", "D", "F", "H", "I" })]
        [TestCase(2, new string[] { "A", "C", "D", "F" })]
        [TestCase(3, new string[] { "A", "B", "G", "I" })]
        [TestCase(4, new string[] { "B", "D", "G", "I" })]
        public void Kliek_4_MaximaleKliek(
            int graph_nr,
            string[] expected_names)
        {
            Graph g = Builder.Build(graph_nr);
            HashSet<Vertex> expected_vertices = new HashSet<Vertex>();
            foreach (string expected_name in expected_names)
            {
                expected_vertices.Add(g.GetVertex(expected_name));
            }
            HashSet<Vertex> actual = g.MaximaleKliek(); //g.GetVertex(this_vertex_name).IsVerbondenMetAllemaal(other_vertices);
            Assert.IsTrue(expected_vertices.SetEquals(actual));
        }
    }
}