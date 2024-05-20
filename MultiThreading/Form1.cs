using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace MultiThreading
{
    public partial class Form1 : Form
    {
        private Dictionary<long, BigInteger> factorialCache = new Dictionary<long, BigInteger>();
        private Dictionary<(long, int), (BigInteger, double)> computedResults = new Dictionary<(long, int), (BigInteger, double)>();
        private Dictionary<int, List<double>> points = new Dictionary<int, List<double>>();

        public Form1()
        {
            InitializeComponent();
            factorialCache[0] = 1;
            factorialCache[1] = 1;

            // Initialize DataGridView columns
            InitializeDataGridViewColumns();
            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Calculate the maximum width available for the chart
            int maxWidth = this.ClientSize.Width - chart.Left - 20; // Assuming 20px margin on the right side

            // Set the chart's width to the calculated maximum width
            chart.Width = maxWidth;
        }


        private void InitializeDataGridViewColumns()
        {
            DataGridViewTextBoxColumn numberColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Number",
                HeaderText = "Number",
                Name = "Number"
            };
            this.data.Columns.Add(numberColumn);

            DataGridViewTextBoxColumn threadColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Threads",
                HeaderText = "Threads",
                Name = "Threads"
            };
            this.data.Columns.Add(threadColumn);

            DataGridViewTextBoxColumn resultColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Result",
                HeaderText = "Result",
                Name = "Result",
                ReadOnly = true
            };
            this.data.Columns.Add(resultColumn);

            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Time",
                HeaderText = "Time (ms)",
                Name = "Time",
                ReadOnly = true
            };
            this.data.Columns.Add(timeColumn);
        }

        private async void compute_click(object sender, EventArgs e)
        {
            using (var calculatingDialog = new Form())
            {
                calculatingDialog.Text = "Calculating...";
                calculatingDialog.StartPosition = FormStartPosition.CenterScreen;

                var label = new Label
                {
                    Text = "Calculating...",
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                };
                calculatingDialog.Controls.Add(label);
                calculatingDialog.Show();

                List<Task> tasks = new List<Task>();

                foreach (DataGridViewRow row in data.Rows)
                {
                    if (row.Cells["Number"].Value != null && row.Cells["Threads"].Value != null)
                    {
                        long num = long.Parse(row.Cells["Number"].Value.ToString());
                        int threads = int.Parse(row.Cells["Threads"].Value.ToString());

                        tasks.Add(Task.Run(async () =>
                        {
                            var result = await FactorialWithTimingAsync(num, threads);
                            this.Invoke(new Action(() =>
                            {
                                row.Cells["Result"].Value = result.Item1;
                                row.Cells["Time"].Value = result.Item2.TotalMilliseconds;

                                if (!points.ContainsKey(threads))
                                {
                                    points[threads] = new List<double>();
                                }
                                points[threads].Add(result.Item2.TotalMilliseconds);
                            }));
                        }));

                    }
                }

                await Task.WhenAll(tasks);
                calculatingDialog.Close();
                PlotChart();
            }
        }

        private void PlotChart()
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Maximum = 60;

            // Dictionary to hold data organized by number
            Dictionary<long, List<double>> dataByNumber = new Dictionary<long, List<double>>();

            // Iterate over DataGridView rows to organize data by number
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["Number"].Value != null && row.Cells["Threads"].Value != null && row.Cells["Time"].Value != null)
                {
                    long number = long.Parse(row.Cells["Number"].Value.ToString());
                    int threads = int.Parse(row.Cells["Threads"].Value.ToString());
                    double time = double.Parse(row.Cells["Time"].Value.ToString());

                    if (!dataByNumber.ContainsKey(number))
                    {
                        dataByNumber[number] = new List<double>();
                    }

                    // Add time to the list for the corresponding number
                    dataByNumber[number].Add(time);
                }
            }

            // Create series for each number
            foreach (var kvp in dataByNumber)
            {
                System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = $"Number: {kvp.Key}",
                    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
                };

                // Add points for each time value
                for (int i = 0; i < kvp.Value.Count; i++)
                {
                    series.Points.AddXY((i + 1), kvp.Value[i]);
                }

                chart.Series.Add(series);
            }
        }






        public async Task<(BigInteger, TimeSpan)> FactorialWithTimingAsync(long num, int threads)
        {
            BigInteger finalResult = 1;
            TimeSpan executionTime = TimeSpan.Zero;

            if (!factorialCache.ContainsKey(num))
            {
                BigInteger[] results = new BigInteger[threads];
                long chunkSize = num / threads;

                var stopwatch = Stopwatch.StartNew();

                await Task.WhenAll(Enumerable.Range(0, threads).Select(i =>
                {
                    return Task.Run(() =>
                    {
                        long start = i * chunkSize + 1;
                        long end = (i == threads - 1) ? num : (i + 1) * chunkSize;
                        results[i] = CalculateFactorialInRange(start, end);
                    });
                }));

                stopwatch.Stop();

                foreach (BigInteger result in results)
                {
                    finalResult *= result;
                }

                executionTime = stopwatch.Elapsed;

                factorialCache[num] = finalResult;
            }

            return (finalResult, executionTime);
        }

        private BigInteger CalculateFactorialInRange(long start, long end)
        {
            BigInteger result = 1;

            for (long i = start; i <= end; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
