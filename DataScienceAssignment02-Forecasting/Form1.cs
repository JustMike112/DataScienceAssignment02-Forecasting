using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataScienceAssignment02_Forecasting.Utils;
using DataScienceAssignment02_Forecasting.Smoothing;

namespace DataScienceAssignment02_Forecasting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Read SwordsDemand.csv containing 36 rows
            var data = Parser.Parse("SwordsDemand.csv", ',');
            var ses = new SES(data, 12);
            var des = new DES(data, 12);

            AddToChart(data, "Data");
        }

        private void AddToChart(List<double> dataset, string serie)
        {
            for (var i = 0; i < dataset.Count; i++)
                Smoothing.Series[serie].Points.AddXY(i + 1, dataset[i]);
        }
    }
}
