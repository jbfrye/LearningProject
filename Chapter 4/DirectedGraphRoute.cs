using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_4
{
    // 4.2
    public class DirectedGraphRoute
    {
        public enum State
        {
            Unvisited, Visited, Visiting,
        }

        public DirectedGraphRoute()
        { }

        public static bool IsPath(Graph<int> g, GraphNode<int> start, GraphNode<int> end)
        {
            Queue<GraphNode<int>> queue = new Queue<GraphNode<int>>();

            foreach (GraphNode<int> u in g.Nodes)
                u.State = State.Unvisited;

            start.State = State.Visiting;
            queue.Enqueue(start);
            GraphNode<int> node;
            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                if (node != null)
                {
                    foreach (GraphNode<int> v in node.Neighbors.Keys)
                    {
                        if (v.State == State.Unvisited)
                        {
                            if (v == end)
                                return true;
                            else
                            {
                                v.State = State.Visiting;
                                queue.Enqueue(v);
                            }
                        }
                    }
                    node.State = State.Visited;
                }
            }
            return false;
        }

        public static void RunDirectedGraphRoute()
        {
            Graph<int> graph = new Graph<int>();
            GraphNode<int> one = new GraphNode<int>(1);
            GraphNode<int> two = new GraphNode<int>(2);
            GraphNode<int> three = new GraphNode<int>(3);
            GraphNode<int> four = new GraphNode<int>(4);
            GraphNode<int> five = new GraphNode<int>(5);
            graph.AddNode(one);
            graph.AddNode(two);
            graph.AddNode(three);
            graph.AddNode(four);
            graph.AddNode(five);

            graph.AddDirectedEdge(one, three, 10);
            graph.AddDirectedEdge(one, five, 10);
            graph.AddDirectedEdge(two, four, 10);
            graph.AddDirectedEdge(three, four, 10);
            graph.AddDirectedEdge(five, two, 10);

            graph.PrintGraph();
            Console.WriteLine(IsPath(graph, two, four));
        }
    }
}
