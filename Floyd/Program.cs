using System;

namespace Floyd
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyMatrix matrix = FileHandler.CreateAdjacencyMatrix(@"..\..\..\Cities.txt");
            
            Console.WriteLine("Матрица смежности:");
            
            for (int i = 0; i < matrix.GetAdjacencyMatrix().GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetAdjacencyMatrix().GetLength(1); j++)
                {
                    Console.Write($"{matrix.GetAdjacencyMatrix()[i,j]} ");
                }
                Console.WriteLine();
            }
            
            AlgorithmFloyd.FindShortestPathMatrix(matrix);
            
            AlgorithmFloyd.PrintShortestPathMatrix();
        }
    }
}