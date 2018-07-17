namespace MovementController_1._0
{
    partial class CelestialLocationGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title10 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ArrivalTimeLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeInput = new System.Windows.Forms.DateTimePicker();
            this.AZChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ELChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ELAZChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ToggleTimeIntervalButton = new System.Windows.Forms.Button();
            this.IntervalInput = new System.Windows.Forms.NumericUpDown();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.TrackSunButton = new System.Windows.Forms.Button();
            this.TrackMoonButton = new System.Windows.Forms.Button();
            this.AZValue = new System.Windows.Forms.NumericUpDown();
            this.AZLabel = new System.Windows.Forms.Label();
            this.ELValue = new System.Windows.Forms.NumericUpDown();
            this.ELLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELValue)).BeginInit();
            this.SuspendLayout();
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(793, 468);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(83, 17);
            this.ArrivalTimeLabel.TabIndex = 3;
            this.ArrivalTimeLabel.Text = "Arrival Time";
            // 
            // ArrivalTimeInput
            // 
            this.ArrivalTimeInput.Checked = false;
            this.ArrivalTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ArrivalTimeInput.Location = new System.Drawing.Point(796, 488);
            this.ArrivalTimeInput.Name = "ArrivalTimeInput";
            this.ArrivalTimeInput.Size = new System.Drawing.Size(149, 22);
            this.ArrivalTimeInput.TabIndex = 7;
            // 
            // AZChart
            // 
            chartArea10.AxisX.Minimum = 0D;
            chartArea10.AxisX.Title = "Time (sec)";
            chartArea10.AxisY.Title = "Azimuth Position (deg)";
            chartArea10.Name = "OutputChartArea";
            this.AZChart.ChartAreas.Add(chartArea10);
            legend10.Enabled = false;
            legend10.Name = "Legend1";
            this.AZChart.Legends.Add(legend10);
            this.AZChart.Location = new System.Drawing.Point(22, 356);
            this.AZChart.Name = "AZChart";
            series10.ChartArea = "OutputChartArea";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series10.Legend = "Legend1";
            series10.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series10.Name = "OutputData";
            this.AZChart.Series.Add(series10);
            this.AZChart.Size = new System.Drawing.Size(744, 325);
            this.AZChart.TabIndex = 10;
            this.AZChart.Text = "AZChart";
            title10.Name = "Title1";
            title10.Text = "Output Azimuth Path";
            this.AZChart.Titles.Add(title10);
            // 
            // ELChart
            // 
            chartArea11.AxisX.Minimum = 0D;
            chartArea11.AxisX.Title = "Time (sec)";
            chartArea11.AxisY.Minimum = 0D;
            chartArea11.AxisY.Title = "Elevation Position (deg)";
            chartArea11.Name = "OutputChartArea";
            this.ELChart.ChartAreas.Add(chartArea11);
            legend11.Enabled = false;
            legend11.Name = "Legend1";
            this.ELChart.Legends.Add(legend11);
            this.ELChart.Location = new System.Drawing.Point(22, 12);
            this.ELChart.Name = "ELChart";
            series11.ChartArea = "OutputChartArea";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series11.Name = "InputData";
            this.ELChart.Series.Add(series11);
            this.ELChart.Size = new System.Drawing.Size(744, 325);
            this.ELChart.TabIndex = 11;
            this.ELChart.Text = "ElChart";
            title11.Name = "Title1";
            title11.Text = "Output Elevation Path";
            this.ELChart.Titles.Add(title11);
            // 
            // ELAZChart
            // 
            chartArea12.AxisX.Minimum = 0D;
            chartArea12.AxisX.Title = "Azimuth Position (deg)";
            chartArea12.AxisY.Title = "Elevation Position (deg)";
            chartArea12.Name = "OutputChartArea";
            this.ELAZChart.ChartAreas.Add(chartArea12);
            legend12.Enabled = false;
            legend12.Name = "Legend1";
            this.ELAZChart.Legends.Add(legend12);
            this.ELAZChart.Location = new System.Drawing.Point(786, 12);
            this.ELAZChart.Name = "ELAZChart";
            series12.ChartArea = "OutputChartArea";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series12.Legend = "Legend1";
            series12.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series12.Name = "OutputData";
            this.ELAZChart.Series.Add(series12);
            this.ELAZChart.Size = new System.Drawing.Size(744, 325);
            this.ELAZChart.TabIndex = 12;
            this.ELAZChart.Text = "ELAZChart";
            title12.Name = "Title1";
            title12.Text = "Output Elevation vs. Azimuth Path";
            this.ELAZChart.Titles.Add(title12);
            // 
            // ToggleTimeIntervalButton
            // 
            this.ToggleTimeIntervalButton.Location = new System.Drawing.Point(1152, 485);
            this.ToggleTimeIntervalButton.Name = "ToggleTimeIntervalButton";
            this.ToggleTimeIntervalButton.Size = new System.Drawing.Size(155, 27);
            this.ToggleTimeIntervalButton.TabIndex = 15;
            this.ToggleTimeIntervalButton.Text = "Toggle Time/Interval";
            this.ToggleTimeIntervalButton.UseVisualStyleBackColor = true;
            this.ToggleTimeIntervalButton.Click += new System.EventHandler(this.ToggleTimeIntervalButton_Click);
            // 
            // IntervalInput
            // 
            this.IntervalInput.Enabled = false;
            this.IntervalInput.Location = new System.Drawing.Point(974, 488);
            this.IntervalInput.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.IntervalInput.Name = "IntervalInput";
            this.IntervalInput.Size = new System.Drawing.Size(147, 22);
            this.IntervalInput.TabIndex = 17;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Enabled = false;
            this.IntervalLabel.Location = new System.Drawing.Point(971, 468);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(90, 17);
            this.IntervalLabel.TabIndex = 16;
            this.IntervalLabel.Text = "Interval (sec)";
            // 
            // TrackSunButton
            // 
            this.TrackSunButton.Location = new System.Drawing.Point(1152, 435);
            this.TrackSunButton.Name = "TrackSunButton";
            this.TrackSunButton.Size = new System.Drawing.Size(155, 23);
            this.TrackSunButton.TabIndex = 18;
            this.TrackSunButton.Text = "Track Sun";
            this.TrackSunButton.UseVisualStyleBackColor = true;
            this.TrackSunButton.Click += new System.EventHandler(this.TrackSunButton_Click);
            // 
            // TrackMoonButton
            // 
            this.TrackMoonButton.Location = new System.Drawing.Point(1152, 382);
            this.TrackMoonButton.Name = "TrackMoonButton";
            this.TrackMoonButton.Size = new System.Drawing.Size(155, 23);
            this.TrackMoonButton.TabIndex = 19;
            this.TrackMoonButton.Text = "Track Moon";
            this.TrackMoonButton.UseVisualStyleBackColor = true;
            this.TrackMoonButton.Click += new System.EventHandler(this.TrackMoonButton_Click);
            // 
            // AZValue
            // 
            this.AZValue.Location = new System.Drawing.Point(796, 407);
            this.AZValue.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AZValue.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.AZValue.Name = "AZValue";
            this.AZValue.ReadOnly = true;
            this.AZValue.Size = new System.Drawing.Size(147, 22);
            this.AZValue.TabIndex = 21;
            // 
            // AZLabel
            // 
            this.AZLabel.AutoSize = true;
            this.AZLabel.Enabled = false;
            this.AZLabel.Location = new System.Drawing.Point(793, 387);
            this.AZLabel.Name = "AZLabel";
            this.AZLabel.Size = new System.Drawing.Size(96, 17);
            this.AZLabel.TabIndex = 20;
            this.AZLabel.Text = "Azimuth (deg)";
            // 
            // ELValue
            // 
            this.ELValue.Location = new System.Drawing.Point(974, 407);
            this.ELValue.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.ELValue.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.ELValue.Name = "ELValue";
            this.ELValue.ReadOnly = true;
            this.ELValue.Size = new System.Drawing.Size(147, 22);
            this.ELValue.TabIndex = 23;
            // 
            // ELLabel
            // 
            this.ELLabel.AutoSize = true;
            this.ELLabel.Enabled = false;
            this.ELLabel.Location = new System.Drawing.Point(971, 387);
            this.ELLabel.Name = "ELLabel";
            this.ELLabel.Size = new System.Drawing.Size(104, 17);
            this.ELLabel.TabIndex = 22;
            this.ELLabel.Text = "Elevation (deg)";
            // 
            // CelestialLocationGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 689);
            this.Controls.Add(this.ELValue);
            this.Controls.Add(this.ELLabel);
            this.Controls.Add(this.AZValue);
            this.Controls.Add(this.AZLabel);
            this.Controls.Add(this.TrackMoonButton);
            this.Controls.Add(this.TrackSunButton);
            this.Controls.Add(this.IntervalInput);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.ToggleTimeIntervalButton);
            this.Controls.Add(this.ELAZChart);
            this.Controls.Add(this.ELChart);
            this.Controls.Add(this.AZChart);
            this.Controls.Add(this.ArrivalTimeInput);
            this.Controls.Add(this.ArrivalTimeLabel);
            this.Name = "CelestialLocationGraph";
            this.Text = "User Input";
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ArrivalTimeLabel;
        private System.Windows.Forms.DateTimePicker ArrivalTimeInput;
        private System.Windows.Forms.DataVisualization.Charting.Chart AZChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ELChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ELAZChart;
        private System.Windows.Forms.Button ToggleTimeIntervalButton;
        private System.Windows.Forms.NumericUpDown IntervalInput;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Button TrackSunButton;
        private System.Windows.Forms.Button TrackMoonButton;
        private System.Windows.Forms.NumericUpDown AZValue;
        private System.Windows.Forms.Label AZLabel;
        private System.Windows.Forms.NumericUpDown ELValue;
        private System.Windows.Forms.Label ELLabel;
    }
}

