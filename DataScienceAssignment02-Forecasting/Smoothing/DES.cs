using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_Forecasting.Smoothing
{
    class DES: ISmoothing
    {
        private List<double> dataset;
        private int forecastAmount;

        public DES(List<double> dataSet, int ForecastAmount)
        {
            dataset = dataSet;
            forecastAmount = ForecastAmount;
        }

        public List<double> Calculate()
        {
            return new List<double>();
        }

        // Get the best value for alpha, beta and SSE
        public Tuple<double, double, double> BestValues()
        {
            return new Tuple<double, double, double>(0.0, 0.0, 0.0);
        }
    }
}
