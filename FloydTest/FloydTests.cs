using System;
using Floyd;
using NUnit.Framework;

namespace FloydTest
{
    public class FloydTests
    {
        [Test]
        public void FindShortestPathTest_SimpleMatrix_SuccessfulFounded()
        {
            AdjacencyMatrix matrix = FileHandler.CreateAdjacencyMatrix(@"..\..\..\SimpleMatrix.txt");

            double[,] expected = {{0, 1, 3}, {2, 0, 5}, {4, 5, 0}};

            var actual = AlgorithmFloyd.FindShortestPathMatrix(matrix).Item1;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindShortestPathTest_MatrixNA_MatrixNA()
        {
            AdjacencyMatrix matrix = FileHandler.CreateAdjacencyMatrix(@"..\..\..\MatrixNA.txt");

            double[,] expected = {
                {0, Double.PositiveInfinity, Double.PositiveInfinity}
                , {Double.PositiveInfinity, 0, Double.PositiveInfinity}
                , {Double.PositiveInfinity, Double.PositiveInfinity, 0}
            };

            var actual = AlgorithmFloyd.FindShortestPathMatrix(matrix).Item1;
            
            Assert.AreEqual(expected, actual);
        }
    }
}