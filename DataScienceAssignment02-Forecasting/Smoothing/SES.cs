using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_Forecasting.Smoothing
{
    class SES: ISmoothing
    {
        private List<double> dataset;
        private int forecastAmount;

        public SES(List<double> dataSet, int ForecastAmount)
        {
            dataset = dataSet;
            forecastAmount = ForecastAmount;
        }

        public List<double> Calculate()
        {
            return new List<double>();
        }

        // Get the best value for alpha and SSE
        public Tuple<double, double> BestValues()
        {
            return new Tuple<double, double>(0.0, 0.0);
        }
    }
}
