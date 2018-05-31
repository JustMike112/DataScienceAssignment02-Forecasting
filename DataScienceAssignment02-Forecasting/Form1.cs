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
            Console.WriteLine("cool");

            for (var i = 0; i < data.Count; i++)
            {
                Smoothing.Series["Data"].Points.AddXY(i + 1, data[i]);
            }
        }
    }
}
