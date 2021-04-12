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
            AdjacencyList list = FileHandler.CreateAdjacencyList(@"..\..\..\SimpleMatrix.txt");

            double[,] expected = {{0, 1, 3}, {2, 0, 5}, {4, 5, 0}};

            var actual = AlgorithmFloyd.FindShortestPathMatrix(list).Item1;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindShortestPathTest_MatrixNA_MatrixNA()
        {
            AdjacencyList list = FileHandler.CreateAdjacencyList(@"..\..\..\MatrixNA.txt");

            double[,] expected = {
                {0, Double.PositiveInfinity, Double.PositiveInfinity}
                , {Double.PositiveInfinity, 0, Double.PositiveInfinity}
                , {Double.PositiveInfinity, Double.PositiveInfinity, 0}
            };

            var actual = AlgorithmFloyd.FindShortestPathMatrix(list).Item1;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindShortestPathTest_IsolatedVertex_IsolatedVertexInMatrix()
        {
            AdjacencyList list = FileHandler.CreateAdjacencyList(@"..\..\..\IsolatedVertex.txt");

            double[,] expected =
            {
                {0,1,Double.PositiveInfinity}
                , {2,0,Double.PositiveInfinity}
                , {Double.PositiveInfinity, Double.PositiveInfinity, 0}
            };

            var actual = AlgorithmFloyd.FindShortestPathMatrix(list).Item1;
            
            Assert.AreEqual(expected, actual);
        }
    }
}