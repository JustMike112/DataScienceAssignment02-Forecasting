using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_Forecasting.Smoothing
{
    /* pSmooth = a * p + (1 - a) * pSmooth[previous] */

    class SES : ISmoothing
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
            var alphaError = GetBestValues();
            var alpha = alphaError.Item1;

            var smoothedPoints = new List<double> { dataset[0] };

            for (var i = 1; i < dataset.Count + forecastAmount; i++)
            {
                var smoothedPoint = 0.0;
                //
                if (i >= dataset.Count)
                    smoothedPoint = smoothedPoints[dataset.Count - 1];
                else
                    smoothedPoint = (alpha * dataset[i]) + (1 - alpha) * (smoothedPoints[i - 1]);

                smoothedPoints.Add(smoothedPoint);
            }

            return smoothedPoints;
        }

        // Get the best value for alpha and SSE
        public Tuple<double, double> GetBestValues()
        {
            // Create a list containing the alphas and errors
            var alphaError = new List<Tuple<double, double>>();

            for (var a = 0.0; a < 1.0; a += 0.1)
            {
                var alpha = a;
                var SSE = 0.0;
                var smoothedPoints = new List<double> { dataset[0] };

                for (var i = 1; i < dataset.Count; i++)
                {
                    // pSmooth = a * p + (1 - a) * pSmooth[previous] 
                    var smoothedPoint = (alpha * dataset[i - 1]) + (1 - alpha) * (smoothedPoints[i - 1]);
                    smoothedPoints.Add(smoothedPoint);
                    SSE += Math.Pow((smoothedPoint - dataset[i]), 2);
                }

                SSE = Math.Sqrt(SSE / (dataset.Count - 1));
                alphaError.Add(new Tuple<double, double>(a, SSE));
            }

            // Get the alpha where the error is lowest
            var optimalAlphaError = alphaError.Aggregate((l, r) => (l.Item2 < r.Item2) ? l : r);

            return optimalAlphaError;
        }
    }
}
