using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NodeState = LearningProject.Chapter_4.DirectedGraphRoute.State;

namespace LearningProject
{
    public class GraphNode<T> : IComparable<GraphNode<T>> where T : IComparable<T>
    {
        private SortedDictionary<GraphNode<T>, int> neighbors;
        public SortedDictionary<GraphNode<T>, int> Neighbors
        {
            get { return neighbors; }
        }
        private T value;
        public T Value
        {
            get { return value; }
        }
        public NodeState State { get; set; }

        public GraphNode()
        {
            neighbors = new SortedDictionary<GraphNode<T>, int>();
        }

        public GraphNode(T v)
        {
            value = v;
            neighbors = new SortedDictionary<GraphNode<T>, int>();
        }

        public GraphNode(T v, SortedDictionary<GraphNode<T>, int> n)
        {
            value = v;
            if (n == null)
                neighbors = new SortedDictionary<GraphNode<T>, int>();
            else
                neighbors = n;
        }

        public int CompareTo(GraphNode<T> other)
        {
            if (other == null)
                return 1;
            return Value.CompareTo(other.Value);
        }
    }

    public class Graph<T> where T : IComparable<T>
    {
        private HashSet<GraphNode<T>> nodeSet;
        public HashSet<GraphNode<T>> Nodes
        {
            get { return nodeSet; }
        }

        public int Count
        {
            get { return nodeSet.Count; }
        }

        public Graph()
        {
            nodeSet = new HashSet<GraphNode<T>>();
        }

        public Graph(HashSet<GraphNode<T>> ns)
        {
            if (ns == null)
                nodeSet = new HashSet<GraphNode<T>>();
            else
                nodeSet = ns;
        }

        public void AddNode(GraphNode<T> node)
        {
            nodeSet.Add(node);
        }

        public void AddNode(T value)
        {
            nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to, cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
        {
            from.Neighbors.Add(to, cost);
            to.Neighbors.Add(from, cost);
        }

        public bool Contains(T value)
        {
            foreach (GraphNode<T> node in nodeSet)
                if (node.Value.Equals(value))
                    return true;
            return false;
        }

        public bool Remove(T value)
        {
            GraphNode<T> nodeToRemove = null;
            foreach (GraphNode<T> node in nodeSet)
                if (node.Value.Equals(value))
                    nodeToRemove = node;
            if (nodeToRemove == null)
                return false;

            nodeSet.Remove(nodeToRemove);

            foreach(GraphNode<T> node in nodeSet)
                node.Neighbors.Remove(nodeToRemove);

            return true;
        }

        public void PrintGraph()
        {
            foreach(GraphNode<T> node in nodeSet)
            {
                Console.WriteLine(node.Value);
            }
        }
    }
}
