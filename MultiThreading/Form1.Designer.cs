namespace MultiThreading
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chart = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.computationBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.computationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compute = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.computationBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // computationBindingSource1
            // 
            this.computationBindingSource1.DataSource = typeof(MultiThreading.Computation);
            // 
            // computationBindingSource
            // 
            this.computationBindingSource.DataSource = typeof(MultiThreading.Computation);

            // 
            // compute
            // 
            this.compute.Location = new System.Drawing.Point(822, 411);
            this.compute.Name = "compute";
            this.compute.Size = new System.Drawing.Size(137, 80);
            this.compute.TabIndex = 2;
            this.compute.Text = "COMPUTE";
            this.compute.UseVisualStyleBackColor = true;
            this.compute.Click += compute_click;
            // 
            // data
            // 
            this.data.AutoGenerateColumns = false;
            this.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data.DataSource = this.computationBindingSource;
            this.data.Location = new System.Drawing.Point(12, 348);
            this.data.Name = "data";
            this.data.RowHeadersWidth = 51;
            this.data.RowTemplate.Height = 24;
            this.data.Size = new System.Drawing.Size(717, 255);
            this.data.TabIndex = 1;
            // 
            // chart
            // 
            chart.Name = "chart";
            this.chart.ChartAreas.Add(chart);
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(28, 12);
            this.chart.Name = "chart";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(931, 300);
            this.chart.TabIndex = 3;
            this.chart.Text = "chart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 615);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.compute);
            this.Controls.Add(this.data);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factorial Computation With Multithreading";
            ((System.ComponentModel.ISupportInitialize)(this.computationBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        private void Load_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Compute_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.BindingSource computationBindingSource1;
        private System.Windows.Forms.BindingSource computationBindingSource;
        private System.Windows.Forms.Button compute;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}

