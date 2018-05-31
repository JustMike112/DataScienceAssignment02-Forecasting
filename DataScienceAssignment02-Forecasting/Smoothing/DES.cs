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
            var alphaBetaError = GetBestValues();
            var alpha = 0.65;
            var beta = 0.006;

            var s = new List<double> { dataset[0], dataset[1] };
            var b = new List<double> { 0, dataset[1] - dataset[0] };
            var smoothedPoints = new List<double> { dataset[0] };

            for (var i = 2; i < dataset.Count + forecastAmount + 1; i++)
            {
                var smoothedPoint = 0.0;
                var trend = 0.0;
                var forecast = 0.0;

                if (i >= dataset.Count)
                {
                    smoothedPoint = s[dataset.Count - 1] + ((i - dataset.Count) * b[dataset.Count - 1]);
                    smoothedPoints.Add(smoothedPoint);
                }
                else
                {
                    // pSmooth = a * p + (1-a)*(pSmooth[previous] + bSmooth[previous])
                    // bSmooth = b * (pSmooth - pSmooth[previous]) + (1-b) * bSmooth[previous]
                    smoothedPoint = (alpha * dataset[i]) + (1 - alpha) * (s[i - 1] + b[i - 1]);
                    s.Add(smoothedPoint);

                    trend = beta * (dataset[i] - dataset[i - 1]) + (1 - beta) * b[i - 1];
                    b.Add(trend);

                    forecast = s[i - 1] + b[i - 1];
                    smoothedPoints.Add(forecast);
                }
                
            }

            return smoothedPoints;
        }

        // Get the best value for alpha, beta and SSE
        public Tuple<double, double, double> GetBestValues()
        {
            return new Tuple<double, double, double>(0.0, 0.0, 0.0);
        }
    }
}
