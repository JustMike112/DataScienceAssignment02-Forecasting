using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_Forecasting.Utils
{
    public static class Parser
    {
        public static List<double> Parse(string location, char delimiter)
        {
            var dataSet = File.ReadAllLines(location).Select(
                    line => double.Parse(line.Split(delimiter).ElementAt(1)))
                .ToList();
            return dataSet;
        }

    }
}
