using System;

namespace Floyd
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyList list = FileHandler.CreateAdjacencyList(@"..\..\..\Cities.txt");
            
            Console.WriteLine("Матрица смежности:");
            
            for (int i = 0; i < list.GetAdjacencyMatrix().GetLength(0); i++)
            {
                for (int j = 0; j < list.GetAdjacencyMatrix().GetLength(1); j++)
                {
                    Console.Write($"{list.GetAdjacencyMatrix()[i,j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            
            AlgorithmFloyd.FindShortestPathMatrix(list);
            
            Console.WriteLine("Матрица кратчайших путей:");
            AlgorithmFloyd.PrintShortestPathMatrix();
        }
    }
}