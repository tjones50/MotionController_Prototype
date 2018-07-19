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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.ToggleTimeIntervalButton = new System.Windows.Forms.Button();
            this.IntervalInput = new System.Windows.Forms.NumericUpDown();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.CelesitialDropDown = new System.Windows.Forms.ComboBox();
            this.TrackInstructionButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).BeginInit();
            this.SuspendLayout();
            // 
            // ELPositionLabel
            // 
            this.ELPositionLabel.AutoSize = true;
            this.ELPositionLabel.Location = new System.Drawing.Point(783, 372);
            this.ELPositionLabel.Name = "ELPositionLabel";
            this.ELPositionLabel.Size = new System.Drawing.Size(158, 17);
            this.ELPositionLabel.TabIndex = 1;
            this.ELPositionLabel.Text = "Elevation Position (deg)";
            // 
            // AZPositionLabel
            // 
            this.AZPositionLabel.AutoSize = true;
            this.AZPositionLabel.Location = new System.Drawing.Point(783, 451);
            this.AZPositionLabel.Name = "AZPositionLabel";
            this.AZPositionLabel.Size = new System.Drawing.Size(150, 17);
            this.AZPositionLabel.TabIndex = 2;
            this.AZPositionLabel.Text = "Azimuth Position (deg)";
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(1046, 372);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(83, 17);
            this.ArrivalTimeLabel.TabIndex = 3;
            this.ArrivalTimeLabel.Text = "Arrival Time";
            // 
            // ArrivalTimeInput
            // 
            this.ArrivalTimeInput.Checked = false;
            this.ArrivalTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ArrivalTimeInput.Location = new System.Drawing.Point(1049, 392);
            this.ArrivalTimeInput.Name = "ArrivalTimeInput";
            this.ArrivalTimeInput.Size = new System.Drawing.Size(149, 22);
            this.ArrivalTimeInput.TabIndex = 7;
            // 
            // ELPositionInput
            // 
            this.ELPositionInput.Location = new System.Drawing.Point(786, 392);
            this.ELPositionInput.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.ELPositionInput.Name = "ELPositionInput";
            this.ELPositionInput.Size = new System.Drawing.Size(155, 22);
            this.ELPositionInput.TabIndex = 8;
            // 
            // AZPositionInput
            // 
            this.AZPositionInput.Location = new System.Drawing.Point(786, 471);
            this.AZPositionInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AZPositionInput.Name = "AZPositionInput";
            this.AZPositionInput.Size = new System.Drawing.Size(155, 22);
            this.AZPositionInput.TabIndex = 9;
            // 
            // AZChart
            // 
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.Title = "Time (sec)";
            chartArea4.AxisY.Title = "Azimuth Position (deg)";
            chartArea4.Name = "OutputChartArea";
            this.AZChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.AZChart.Legends.Add(legend4);
            this.AZChart.Location = new System.Drawing.Point(22, 356);
            this.AZChart.Name = "AZChart";
            series4.ChartArea = "OutputChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series4.Name = "OutputData";
            this.AZChart.Series.Add(series4);
            this.AZChart.Size = new System.Drawing.Size(744, 325);
            this.AZChart.TabIndex = 10;
            this.AZChart.Text = "AZChart";
            title4.Name = "Title1";
            title4.Text = "Output Azimuth Path";
            this.AZChart.Titles.Add(title4);
            // 
            // ELChart
            // 
            chartArea5.AxisX.Minimum = 0D;
            chartArea5.AxisX.Title = "Time (sec)";
            chartArea5.AxisY.Minimum = 0D;
            chartArea5.AxisY.Title = "Elevation Position (deg)";
            chartArea5.Name = "OutputChartArea";
            this.ELChart.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.Name = "Legend1";
            this.ELChart.Legends.Add(legend5);
            this.ELChart.Location = new System.Drawing.Point(22, 12);
            this.ELChart.Name = "ELChart";
            series5.ChartArea = "OutputChartArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series5.Name = "InputData";
            this.ELChart.Series.Add(series5);
            this.ELChart.Size = new System.Drawing.Size(744, 325);
            this.ELChart.TabIndex = 11;
            this.ELChart.Text = "ElChart";
            title5.Name = "Title1";
            title5.Text = "Output Elevation Path";
            this.ELChart.Titles.Add(title5);
            // 
            // ELAZChart
            // 
            chartArea6.AxisX.Minimum = 0D;
            chartArea6.AxisX.Title = "Azimuth Position (deg)";
            chartArea6.AxisY.Title = "Elevation Position (deg)";
            chartArea6.Name = "OutputChartArea";
            this.ELAZChart.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.ELAZChart.Legends.Add(legend6);
            this.ELAZChart.Location = new System.Drawing.Point(786, 12);
            this.ELAZChart.Name = "ELAZChart";
            series6.ChartArea = "OutputChartArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series6.Name = "OutputData";
            this.ELAZChart.Series.Add(series6);
            this.ELAZChart.Size = new System.Drawing.Size(744, 325);
            this.ELAZChart.TabIndex = 12;
            this.ELAZChart.Text = "ELAZChart";
            title6.Name = "Title1";
            title6.Text = "Output Elevation vs. Azimuth Path";
            this.ELAZChart.Titles.Add(title6);
            // 
            // SlewButton
            // 
            this.SlewButton.Location = new System.Drawing.Point(786, 610);
            this.SlewButton.Name = "SlewButton";
            this.SlewButton.Size = new System.Drawing.Size(155, 27);
            this.SlewButton.TabIndex = 13;
            this.SlewButton.Text = "Slew Instruction";
            this.SlewButton.UseVisualStyleBackColor = true;
            this.SlewButton.Click += new System.EventHandler(this.SlewButton_Click);
            // 
            // DriftScanButton
            // 
            this.DriftScanButton.Location = new System.Drawing.Point(786, 541);
            this.DriftScanButton.Name = "DriftScanButton";
            this.DriftScanButton.Size = new System.Drawing.Size(155, 27);
            this.DriftScanButton.TabIndex = 14;
            this.DriftScanButton.Text = "Drift Scan Instruction";
            this.DriftScanButton.UseVisualStyleBackColor = true;
            this.DriftScanButton.Click += new System.EventHandler(this.DriftScanButton_Click);
            // 
            // ToggleTimeIntervalButton
            // 
            this.ToggleTimeIntervalButton.Location = new System.Drawing.Point(1049, 541);
            this.ToggleTimeIntervalButton.Name = "ToggleTimeIntervalButton";
            this.ToggleTimeIntervalButton.Size = new System.Drawing.Size(149, 27);
            this.ToggleTimeIntervalButton.TabIndex = 15;
            this.ToggleTimeIntervalButton.Text = "Toggle Time/Interval";
            this.ToggleTimeIntervalButton.UseVisualStyleBackColor = true;
            this.ToggleTimeIntervalButton.Click += new System.EventHandler(this.ToggleTimeIntervalButton_Click);
            // 
            // IntervalInput
            // 
            this.IntervalInput.Enabled = false;
            this.IntervalInput.Location = new System.Drawing.Point(1049, 471);
            this.IntervalInput.Maximum = new decimal(new int[] {
            86400,
            0,
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
            this.IntervalLabel.Location = new System.Drawing.Point(1046, 451);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(90, 17);
            this.IntervalLabel.TabIndex = 16;
            this.IntervalLabel.Text = "Interval (sec)";
            // 
            // CelesitialDropDown
            // 
            this.CelesitialDropDown.FormattingEnabled = true;
            this.CelesitialDropDown.Items.AddRange(new object[] {
            "Sun",
            "Moon"});
            this.CelesitialDropDown.Location = new System.Drawing.Point(1301, 392);
            this.CelesitialDropDown.Name = "CelesitialDropDown";
            this.CelesitialDropDown.Size = new System.Drawing.Size(155, 24);
            this.CelesitialDropDown.TabIndex = 18;
            this.CelesitialDropDown.SelectedIndexChanged += new System.EventHandler(this.CelesitialDropDown_SelectedIndexChanged);
            // 
            // TrackInstructionButton
            // 
            this.TrackInstructionButton.Enabled = false;
            this.TrackInstructionButton.Location = new System.Drawing.Point(1301, 468);
            this.TrackInstructionButton.Name = "TrackInstructionButton";
            this.TrackInstructionButton.Size = new System.Drawing.Size(155, 27);
            this.TrackInstructionButton.TabIndex = 19;
            this.TrackInstructionButton.Text = "Track Instruction";
            this.TrackInstructionButton.UseVisualStyleBackColor = true;
            this.TrackInstructionButton.Click += new System.EventHandler(this.TrackInstructionButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1309, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Elevation Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1309, 620);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Azimuth Position:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 689);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackInstructionButton);
            this.Controls.Add(this.CelesitialDropDown);
            this.Controls.Add(this.IntervalInput);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.ToggleTimeIntervalButton);
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
            this.Name = "Form1";
            this.Text = "User Input";
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELAZChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button ToggleTimeIntervalButton;
        private System.Windows.Forms.NumericUpDown IntervalInput;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.ComboBox CelesitialDropDown;
        private System.Windows.Forms.Button TrackInstructionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

