using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningProject.Chapter_8
{
    // 8.6
    class Puzzle
    {
        Piece[] pieces; // Remaining pieces
        Piece[][] solution;

        Edge[] inners, outers, flats;
        Piece[] corners;

        public Puzzle()
        { }

        void Sort()
        {
            foreach (Piece p in pieces)
            {
            }
        }

        void Solve()
        {

        }

        public static void RunPuzzle()
        {

        }
    }

    class Piece
    {
        Edge[] edges;
        public bool IsCorner()
        {
            int counter = 0;
            foreach (Edge e in edges)
            {
                if (e.GetEdgeType() == Edge.Type.flat)
                    counter++;
            }
            if (counter >= 2)
                return true;
            else
                return false;
        }
    }

    class Edge
    {
        public enum Type { inner, outer, flat };
        Piece parent;
        Type type;
        int index;
        Edge attached_to;

        bool FitsWith(Edge edge)
        {
            return true;
        }

        public Type GetEdgeType()
        {
            return type;
        }
    }
}
