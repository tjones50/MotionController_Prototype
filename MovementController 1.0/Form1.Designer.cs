namespace MovementController_1._0
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.TrackButton = new System.Windows.Forms.Button();
            this.ELPositionLabel = new System.Windows.Forms.Label();
            this.AZPositionLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeInput = new System.Windows.Forms.DateTimePicker();
            this.ELPositionInput = new System.Windows.Forms.NumericUpDown();
            this.AZPositionInput = new System.Windows.Forms.NumericUpDown();
            this.AZChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ELChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ELAZChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SlewButton = new System.Windows.Forms.Button();
            this.DriftScanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackButton
            // 
            this.TrackButton.Location = new System.Drawing.Point(974, 502);
            this.TrackButton.Name = "TrackButton";
            this.TrackButton.Size = new System.Drawing.Size(149, 23);
            this.TrackButton.TabIndex = 0;
            this.TrackButton.Text = "Track Instruction";
            this.TrackButton.UseVisualStyleBackColor = true;
            this.TrackButton.Click += new System.EventHandler(this.TrackButton_Click);
            // 
            // ELPositionLabel
            // 
            this.ELPositionLabel.AutoSize = true;
            this.ELPositionLabel.Location = new System.Drawing.Point(793, 384);
            this.ELPositionLabel.Name = "ELPositionLabel";
            this.ELPositionLabel.Size = new System.Drawing.Size(158, 17);
            this.ELPositionLabel.TabIndex = 1;
            this.ELPositionLabel.Text = "Elevation Position (deg)";
            // 
            // AZPositionLabel
            // 
            this.AZPositionLabel.AutoSize = true;
            this.AZPositionLabel.Location = new System.Drawing.Point(971, 384);
            this.AZPositionLabel.Name = "AZPositionLabel";
            this.AZPositionLabel.Size = new System.Drawing.Size(150, 17);
            this.AZPositionLabel.TabIndex = 2;
            this.AZPositionLabel.Text = "Azimuth Position (deg)";
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(1149, 384);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(119, 17);
            this.ArrivalTimeLabel.TabIndex = 3;
            this.ArrivalTimeLabel.Text = "Arrival Time (sec)";
            // 
            // ArrivalTimeInput
            // 
            this.ArrivalTimeInput.Checked = false;
            this.ArrivalTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ArrivalTimeInput.Location = new System.Drawing.Point(1152, 412);
            this.ArrivalTimeInput.Name = "ArrivalTimeInput";
            this.ArrivalTimeInput.Size = new System.Drawing.Size(182, 22);
            this.ArrivalTimeInput.TabIndex = 7;
            // 
            // ELPositionInput
            // 
            this.ELPositionInput.Location = new System.Drawing.Point(796, 412);
            this.ELPositionInput.Name = "ELPositionInput";
            this.ELPositionInput.Size = new System.Drawing.Size(155, 22);
            this.ELPositionInput.TabIndex = 8;
            // 
            // AZPositionInput
            // 
            this.AZPositionInput.Location = new System.Drawing.Point(974, 412);
            this.AZPositionInput.Name = "AZPositionInput";
            this.AZPositionInput.Size = new System.Drawing.Size(147, 22);
            this.AZPositionInput.TabIndex = 9;
            // 
            // AZChart
            // 
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.Title = "Time (sec)";
            chartArea1.AxisY.Title = "Azimuth Position (deg)";
            chartArea1.Name = "OutputChartArea";
            this.AZChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.AZChart.Legends.Add(legend1);
            this.AZChart.Location = new System.Drawing.Point(22, 356);
            this.AZChart.Name = "AZChart";
            series1.ChartArea = "OutputChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "OutputData";
            this.AZChart.Series.Add(series1);
            this.AZChart.Size = new System.Drawing.Size(744, 325);
            this.AZChart.TabIndex = 10;
            this.AZChart.Text = "AZChart";
            title1.Name = "Title1";
            title1.Text = "Output Azimuth Path";
            this.AZChart.Titles.Add(title1);
            // 
            // ELChart
            // 
            chartArea2.AxisX.Minimum = 0D;
            chartArea2.AxisX.Title = "Time (sec)";
            chartArea2.AxisY.Minimum = 0D;
            chartArea2.AxisY.Title = "Elevation Position (deg)";
            chartArea2.Name = "OutputChartArea";
            this.ELChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.ELChart.Legends.Add(legend2);
            this.ELChart.Location = new System.Drawing.Point(22, 12);
            this.ELChart.Name = "ELChart";
            series2.ChartArea = "OutputChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "InputData";
            this.ELChart.Series.Add(series2);
            this.ELChart.Size = new System.Drawing.Size(744, 325);
            this.ELChart.TabIndex = 11;
            this.ELChart.Text = "ElChart";
            title2.Name = "Title1";
            title2.Text = "Output Elevation Path";
            this.ELChart.Titles.Add(title2);
            // 
            // ELAZChart
            // 
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "Azimuth Position (deg)";
            chartArea3.AxisY.Title = "Elevation Position (deg)";
            chartArea3.Name = "OutputChartArea";
            this.ELAZChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.ELAZChart.Legends.Add(legend3);
            this.ELAZChart.Location = new System.Drawing.Point(786, 12);
            this.ELAZChart.Name = "ELAZChart";
            series3.ChartArea = "OutputChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series3.Name = "OutputData";
            this.ELAZChart.Series.Add(series3);
            this.ELAZChart.Size = new System.Drawing.Size(744, 325);
            this.ELAZChart.TabIndex = 12;
            this.ELAZChart.Text = "ELAZChart";
            title3.Name = "Title1";
            title3.Text = "Output Elevation vs. Azimuth Path";
            this.ELAZChart.Titles.Add(title3);
            // 
            // SlewButton
            // 
            this.SlewButton.Location = new System.Drawing.Point(802, 502);
            this.SlewButton.Name = "SlewButton";
            this.SlewButton.Size = new System.Drawing.Size(149, 23);
            this.SlewButton.TabIndex = 13;
            this.SlewButton.Text = "Slew Instruction";
            this.SlewButton.UseVisualStyleBackColor = true;
            this.SlewButton.Click += new System.EventHandler(this.SlewButton_Click);
            // 
            // DriftScanButton
            // 
            this.DriftScanButton.Location = new System.Drawing.Point(1152, 502);
            this.DriftScanButton.Name = "DriftScanButton";
            this.DriftScanButton.Size = new System.Drawing.Size(149, 23);
            this.DriftScanButton.TabIndex = 14;
            this.DriftScanButton.Text = "Drift Scan Instruction";
            this.DriftScanButton.UseVisualStyleBackColor = true;
            this.DriftScanButton.Click += new System.EventHandler(this.DriftScanButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 689);
            this.Controls.Add(this.DriftScanButton);
            this.Controls.Add(this.SlewButton);
            this.Controls.Add(this.ELAZChart);
            this.Controls.Add(this.ELChart);
            this.Controls.Add(this.AZChart);
            this.Controls.Add(this.AZPositionInput);
            this.Controls.Add(this.ELPositionInput);
            this.Controls.Add(this.ArrivalTimeInput);
            this.Controls.Add(this.ArrivalTimeLabel);
            this.Controls.Add(this.AZPositionLabel);
            this.Controls.Add(this.ELPositionLabel);
            this.Controls.Add(this.TrackButton);
            this.Name = "Form1";
            this.Text = "User Input";
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TrackButton;
        private System.Windows.Forms.Label ELPositionLabel;
        private System.Windows.Forms.Label AZPositionLabel;
        private System.Windows.Forms.Label ArrivalTimeLabel;
        private System.Windows.Forms.DateTimePicker ArrivalTimeInput;
        private System.Windows.Forms.NumericUpDown ELPositionInput;
        private System.Windows.Forms.NumericUpDown AZPositionInput;
        private System.Windows.Forms.DataVisualization.Charting.Chart AZChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ELChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ELAZChart;
        private System.Windows.Forms.Button SlewButton;
        private System.Windows.Forms.Button DriftScanButton;
    }
}

