﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScienceAssignment02_Forecasting.Smoothing
{
    interface ISmoothing
    {
        List<double> Calculate();
    }
}
