using System;
using System.IO;

namespace Floyd
{
    public static class FileHandler
    {
        public static AdjacencyList CreateAdjacencyList(string path)
        {
            string[] allStrings = File.ReadAllLines(path);

            AdjacencyList adjacencyList = new AdjacencyList();

            for (int i = 0; i < allStrings.Length; i++)
            {
                string fromCity = allStrings[i].Substring(0, allStrings[i].IndexOf(';'));

                allStrings[i] = allStrings[i].Substring(allStrings[i].IndexOf(';') + 1);
                
                string toCity = allStrings[i].Substring(0, allStrings[i].IndexOf(';'));
                
                allStrings[i] = allStrings[i].Substring(allStrings[i].IndexOf(';') + 1);

                double weightFromCity;
                
                try
                {
                    weightFromCity = double.Parse(allStrings[i].Substring(0, allStrings[i].IndexOf(';')));
                }
                catch (Exception e)
                {
                    weightFromCity = Double.PositiveInfinity;
                }
                
                allStrings[i] = allStrings[i].Substring(allStrings[i].IndexOf(';') + 1);

                double weightToCity;

                try
                {
                    weightToCity = double.Parse(allStrings[i]);
                }
                catch (Exception e)
                {
                    weightToCity = Double.PositiveInfinity;
                }
                
                adjacencyList.Insert(fromCity, toCity, weightFromCity, weightToCity);
            }

            return adjacencyList;
        }
    }
}