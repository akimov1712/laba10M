using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10._3
{

    class Program
    {
        static void Main(string[] args)
        {
            int numVertices = 8;
            Graph graph = new Graph(numVertices);

            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(3, 8);
            graph.AddEdge(2, 7);
            graph.AddEdge(7, 8);

            int start = 1;
            int end = 8;

            graph.DFS(start, end);
            graph.BFS(start, end);
        }
    }


    class Graph
    {
        private int V;
        private List<int>[] adjacencyList;

        public Graph(int v)
        {
            V = v;
            adjacencyList = new List<int>[V + 1];

            for (int i = 1; i <= V; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int u, int v)
        {
            adjacencyList[u].Add(v);
            adjacencyList[v].Add(u);
        }

        public void DFS(int start, int end)
        {
            bool[] visited = new bool[V + 1];
            List<int> path = new List<int>();

            DFSUtil(start, end, visited, path);

            Console.WriteLine("DFS:");
            PrintPath(path);
        }

        private bool DFSUtil(int current, int end, bool[] visited, List<int> path)
        {
            visited[current] = true;
            path.Add(current);

            if (current == end)
            {
                return true;
            }

            foreach (int neighbor in adjacencyList[current])
            {
                if (!visited[neighbor])
                {
                    if (DFSUtil(neighbor, end, visited, path))
                    {
                        return true;
                    }
                }
            }

            path.RemoveAt(path.Count - 1);
            return false;
        }

        public void BFS(int start, int end)
        {
            bool[] visited = new bool[V + 1];
            List<List<int>> paths = new List<List<int>>();
            Queue<List<int>> queue = new Queue<List<int>>();

            List<int> initialPath = new List<int>();
            initialPath.Add(start);
            queue.Enqueue(initialPath);

            while (queue.Count > 0)
            {
                List<int> currentPath = queue.Dequeue();
                int currentVertex = currentPath[currentPath.Count - 1];

                visited[currentVertex] = true;

                if (currentVertex == end)
                {
                    paths.Add(currentPath);
                }

                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visited[neighbor])
                    {
                        List<int> newPath = new List<int>(currentPath);
                        newPath.Add(neighbor);
                        queue.Enqueue(newPath);
                    }
                }
            }

            Console.WriteLine("BFS:");
            foreach (List<int> path in paths)
            {
                PrintPath(path);
            }
        }

        private void PrintPath(List<int> path)
        {
            foreach (int vertex in path)
            {
                Console.Write(vertex + " -> ");
            }

            Console.WriteLine();
        }
    }
}
