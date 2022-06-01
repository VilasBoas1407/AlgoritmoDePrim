using System;

namespace AlgoritmoDePrim
{
    /*
        Alunos:
        Fabiana Quelott Lopes Cançado - RA: 119214091
        Leandro César Lopes Cardoso - RA: 119210676
        Lucas Vilas Boas Lage - RA: 119119592
     */
    internal class Program
    {
        static int V = 6;

        static int minKey(int[] key, bool[] mstSet)
        {

            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }

            return min_index;
        }

        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Aresta | Peso");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + " \t " + graph[i, parent[i]]);
        }

        static void primMST(int[,] graph)
        {

            int[] parent = new int[V];

            int[] key = new int[V];

            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {

                int u = minKey(key, mstSet);

                mstSet[u] = true;


                for (int v = 0; v < V; v++)
                {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }

            }

            printMST(parent, graph);
        }

        public static void Main()
        {


            int[,] graph = new int[,] {
                                         { 0, 6, 1, 5, 0, 0},
                                         { 6, 0, 2, 0, 5, 0 },
                                         { 1, 2, 0, 2, 6, 4 },
                                         { 5, 0, 2, 3, 0, 4 },
                                         { 0, 5, 6, 0, 4, 3 },
                                         { 0, 0, 4, 4, 3, 0 },
                                      };


            primMST(graph);
        }
    }
}
