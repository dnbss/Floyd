using System;

namespace Floyd
{
    public static class AlgorithmFloyd
    {
        private static double[,] D;

        private static string[,] F;

        private static AdjacencyMatrix _matrix;
        public static (double[,] , string[,]) FindShortestPathMatrix(AdjacencyMatrix matrix)
        {
            _matrix = matrix;
            
            D = _matrix.GetAdjacencyMatrix();

            F = new string[_matrix.Length, _matrix.Length];
            
            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix.Length; j++)
                {
                    F[i, j] = _matrix[j];
                }
            }
            
            for (int k = 0; k < _matrix.Length; ++k)
            {
                for (int i = 0; i < _matrix.Length; ++i)
                {
                    for (int j = 0; j < _matrix.Length; ++j)
                    {
                        if (D[i, k] + D[k, j] < D[i, j])
                        {
                            D[i, j] = D[i, k] + D[k, j];

                            F[i, j] = F[i, k] + "-> " + F[k, j];
                        }
                    }
                }
            }

            return (D, F);
        }

        public static void PrintShortestPathMatrix()
        {
            for (int i = 0; i < _matrix.Length; ++i)
            {
                for (int j = 0; j < _matrix.Length; ++j)
                {
                    if (i != j)
                    {
                        Console.Write($"[{_matrix[i]}-> {F[i,j]} : {D[i,j]}]  ");
                    }
                    else
                    {
                        Console.Write($"[{F[i,j]} : {D[i,j]}]  ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}