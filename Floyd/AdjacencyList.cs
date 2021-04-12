using System;
using System.Collections.Generic;
using Map;

namespace Floyd
{
    public class AdjacencyList
    {
        private Map<string, Map<string, double>> adjacencyList;

        public AdjacencyList()
        {
            adjacencyList = new Map<string, Map<string, double>>();
        }

        public string this[int index] => adjacencyList.GetKeys()[index];

        public int Length => adjacencyList.GetKeys().Count;
        
        public void Insert(string newNode, string nextNode, double weightToNextNode, double weightToNewNode)
        {
            try
            {
                 adjacencyList.FindNode(newNode).data.Insert(nextNode, weightToNextNode);
            }
            catch (Exception e)
            {
                var t = new Map<string, double>();
                
                t.Insert(nextNode, weightToNextNode);
                adjacencyList.Insert(newNode, t);
            }

            
            try
            {
                adjacencyList.FindNode(nextNode).data.Insert(newNode, weightToNewNode);
            }
            catch (Exception e)
            {
                var t = new Map<string, double>();
                
                t.Insert(newNode, weightToNewNode);
                adjacencyList.Insert(nextNode, t);
            }
        }

        public double[,] GetAdjacencyMatrix()
        {
            var keys = adjacencyList.GetKeys();
            
            int count = keys.Count;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    try
                    {
                        if (i == j)
                        {
                            Insert(keys[i], keys[j], 0, 0);
                        }
                        else
                        {
                            Insert(keys[i], keys[j], Double.PositiveInfinity, Double.PositiveInfinity);
                        }
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }
                }
            }
            
            var values = adjacencyList.GetValues();
            
            double[,] matrix = new Double[count, count];

            for (int i = 0; i < count; i++)
            {
                var v = values.Pop().GetValues();
                
                for (int j = 0; j < count; j++)
                {
                    matrix[i, j] = v.Pop();
                }
            }

            return matrix;
        }
        
    }
}