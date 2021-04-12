using System;

namespace Floyd
{
    public static class AlgorithmFloyd
    {
        private static double[,] D;

        private static string[,] F;

        private static AdjacencyList _list;
        public static (double[,] , string[,]) FindShortestPathMatrix(AdjacencyList list)
        {
            _list = list;
            
            D = _list.GetAdjacencyMatrix();

            F = new string[_list.Length, _list.Length];
            
            for (int i = 0; i < _list.Length; i++)
            {
                for (int j = 0; j < _list.Length; j++)
                {
                    F[i, j] = _list[j];
                }
            }
            
            for (int k = 0; k < _list.Length; ++k)
            {
                for (int i = 0; i < _list.Length; ++i)
                {
                    for (int j = 0; j < _list.Length; ++j)
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
            for (int i = 0; i < _list.Length; ++i)
            {
                for (int j = 0; j < _list.Length; ++j)
                {
                    if (i != j)
                    {
                        Console.Write($"[{_list[i]}-> {F[i,j]} : {D[i,j]}]  ");
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