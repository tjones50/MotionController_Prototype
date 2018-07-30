namespace ControlRoomSoftware1
{
    partial class Home
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 90D);
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.ApplicationList = new System.Windows.Forms.ListView();
            this.TrackInstructionButton = new System.Windows.Forms.Button();
            this.CelesitialDropDown = new System.Windows.Forms.ComboBox();
            this.IntervalInput = new System.Windows.Forms.NumericUpDown();
            this.IntervalLabel = new System.Windows.Forms.Label();
            this.ToggleTimeIntervalButton = new System.Windows.Forms.Button();
            this.ScanButton = new System.Windows.Forms.Button();
            this.SlewButton = new System.Windows.Forms.Button();
            this.AZPositionInput = new System.Windows.Forms.NumericUpDown();
            this.ELPositionInput = new System.Windows.Forms.NumericUpDown();
            this.ArrivalTimeInput = new System.Windows.Forms.DateTimePicker();
            this.ArrivalTimeLabel = new System.Windows.Forms.Label();
            this.AZPositionLabel = new System.Windows.Forms.Label();
            this.ELPositionLabel = new System.Windows.Forms.Label();
            this.TelescopePositionGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.CelestialObjectLabel = new System.Windows.Forms.Label();
            this.RadioTelescopeTypeBox = new System.Windows.Forms.GroupBox();
            this.PrototypeRadioTelescopeButton = new System.Windows.Forms.RadioButton();
            this.SimulatorRadioTelescopeButton = new System.Windows.Forms.RadioButton();
            this.CurrentElLabel = new System.Windows.Forms.Label();
            this.CurrentAzLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelescopePositionGraph)).BeginInit();
            this.RadioTelescopeTypeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(1128, 46);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            this.monthCalendar1.CursorChanged += new System.EventHandler(this.monthCalendar1_CursorChanged);
            // 
            // ApplicationList
            // 
            this.ApplicationList.AutoArrange = false;
            this.ApplicationList.Location = new System.Drawing.Point(840, 46);
            this.ApplicationList.Name = "ApplicationList";
            this.ApplicationList.Size = new System.Drawing.Size(262, 207);
            this.ApplicationList.TabIndex = 1;
            this.ApplicationList.UseCompatibleStateImageBehavior = false;
            this.ApplicationList.View = System.Windows.Forms.View.Tile;
            // 
            // TrackInstructionButton
            // 
            this.TrackInstructionButton.Enabled = false;
            this.TrackInstructionButton.Location = new System.Drawing.Point(644, 117);
            this.TrackInstructionButton.Name = "TrackInstructionButton";
            this.TrackInstructionButton.Size = new System.Drawing.Size(155, 27);
            this.TrackInstructionButton.TabIndex = 34;
            this.TrackInstructionButton.Text = "Track Instruction";
            this.TrackInstructionButton.UseVisualStyleBackColor = true;
            this.TrackInstructionButton.Click += new System.EventHandler(this.TrackInstructionButton_Click);
            // 
            // CelesitialDropDown
            // 
            this.CelesitialDropDown.FormattingEnabled = true;
            this.CelesitialDropDown.Items.AddRange(new object[] {
            "Sun",
            "Moon"});
            this.CelesitialDropDown.Location = new System.Drawing.Point(644, 58);
            this.CelesitialDropDown.Name = "CelesitialDropDown";
            this.CelesitialDropDown.Size = new System.Drawing.Size(155, 24);
            this.CelesitialDropDown.TabIndex = 33;
            this.CelesitialDropDown.SelectedIndexChanged += new System.EventHandler(this.CelesitialDropDown_SelectedIndexChanged);
            // 
            // IntervalInput
            // 
            this.IntervalInput.Enabled = false;
            this.IntervalInput.Location = new System.Drawing.Point(277, 120);
            this.IntervalInput.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.IntervalInput.Name = "IntervalInput";
            this.IntervalInput.Size = new System.Drawing.Size(147, 22);
            this.IntervalInput.TabIndex = 32;
            // 
            // IntervalLabel
            // 
            this.IntervalLabel.AutoSize = true;
            this.IntervalLabel.Enabled = false;
            this.IntervalLabel.Location = new System.Drawing.Point(274, 100);
            this.IntervalLabel.Name = "IntervalLabel";
            this.IntervalLabel.Size = new System.Drawing.Size(90, 17);
            this.IntervalLabel.TabIndex = 31;
            this.IntervalLabel.Text = "Interval (sec)";
            // 
            // ToggleTimeIntervalButton
            // 
            this.ToggleTimeIntervalButton.Location = new System.Drawing.Point(275, 177);
            this.ToggleTimeIntervalButton.Name = "ToggleTimeIntervalButton";
            this.ToggleTimeIntervalButton.Size = new System.Drawing.Size(149, 27);
            this.ToggleTimeIntervalButton.TabIndex = 30;
            this.ToggleTimeIntervalButton.Text = "Toggle Time/Interval";
            this.ToggleTimeIntervalButton.UseVisualStyleBackColor = true;
            this.ToggleTimeIntervalButton.Click += new System.EventHandler(this.ToggleTimeIntervalButton_Click);
            // 
            // ScanButton
            // 
            this.ScanButton.Enabled = false;
            this.ScanButton.Location = new System.Drawing.Point(455, 239);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(155, 27);
            this.ScanButton.TabIndex = 29;
            this.ScanButton.Text = "Scan Instruction";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // SlewButton
            // 
            this.SlewButton.Location = new System.Drawing.Point(455, 177);
            this.SlewButton.Name = "SlewButton";
            this.SlewButton.Size = new System.Drawing.Size(155, 27);
            this.SlewButton.TabIndex = 28;
            this.SlewButton.Text = "Slew Instruction";
            this.SlewButton.UseVisualStyleBackColor = true;
            this.SlewButton.Click += new System.EventHandler(this.SlewButton_Click);
            // 
            // AZPositionInput
            // 
            this.AZPositionInput.Location = new System.Drawing.Point(455, 120);
            this.AZPositionInput.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AZPositionInput.Name = "AZPositionInput";
            this.AZPositionInput.Size = new System.Drawing.Size(155, 22);
            this.AZPositionInput.TabIndex = 27;
            // 
            // ELPositionInput
            // 
            this.ELPositionInput.Location = new System.Drawing.Point(455, 60);
            this.ELPositionInput.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.ELPositionInput.Name = "ELPositionInput";
            this.ELPositionInput.Size = new System.Drawing.Size(155, 22);
            this.ELPositionInput.TabIndex = 26;
            // 
            // ArrivalTimeInput
            // 
            this.ArrivalTimeInput.Checked = false;
            this.ArrivalTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ArrivalTimeInput.Location = new System.Drawing.Point(277, 60);
            this.ArrivalTimeInput.Name = "ArrivalTimeInput";
            this.ArrivalTimeInput.Size = new System.Drawing.Size(149, 22);
            this.ArrivalTimeInput.TabIndex = 25;
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(274, 40);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(83, 17);
            this.ArrivalTimeLabel.TabIndex = 24;
            this.ArrivalTimeLabel.Text = "Arrival Time";
            // 
            // AZPositionLabel
            // 
            this.AZPositionLabel.AutoSize = true;
            this.AZPositionLabel.Location = new System.Drawing.Point(452, 100);
            this.AZPositionLabel.Name = "AZPositionLabel";
            this.AZPositionLabel.Size = new System.Drawing.Size(150, 17);
            this.AZPositionLabel.TabIndex = 23;
            this.AZPositionLabel.Text = "Azimuth Position (deg)";
            // 
            // ELPositionLabel
            // 
            this.ELPositionLabel.AutoSize = true;
            this.ELPositionLabel.Location = new System.Drawing.Point(452, 40);
            this.ELPositionLabel.Name = "ELPositionLabel";
            this.ELPositionLabel.Size = new System.Drawing.Size(158, 17);
            this.ELPositionLabel.TabIndex = 22;
            this.ELPositionLabel.Text = "Elevation Position (deg)";
            // 
            // TelescopePositionGraph
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisX.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.Interval = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisX.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisX.Maximum = 360D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.Title = "Azimuth";
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.MajorGrid.Interval = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffset = 0D;
            chartArea1.AxisY.MajorGrid.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.Interval = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffset = 0D;
            chartArea1.AxisY.MajorTickMark.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Auto;
            chartArea1.AxisY.Maximum = 90D;
            chartArea1.AxisY.Minimum = -90D;
            chartArea1.AxisY.MinorTickMark.Enabled = true;
            chartArea1.AxisY.Title = "Elevation";
            chartArea1.Name = "ChartArea1";
            this.TelescopePositionGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TelescopePositionGraph.Legends.Add(legend1);
            this.TelescopePositionGraph.Location = new System.Drawing.Point(63, 302);
            this.TelescopePositionGraph.Name = "TelescopePositionGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "Telescope Position";
            dataPoint1.AxisLabel = "";
            series1.Points.Add(dataPoint1);
            this.TelescopePositionGraph.Series.Add(series1);
            this.TelescopePositionGraph.Size = new System.Drawing.Size(1325, 387);
            this.TelescopePositionGraph.TabIndex = 37;
            this.TelescopePositionGraph.Text = "chart1";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(63, 718);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(1315, 22);
            this.ErrorLabel.TabIndex = 38;
            // 
            // CelestialObjectLabel
            // 
            this.CelestialObjectLabel.AutoSize = true;
            this.CelestialObjectLabel.Location = new System.Drawing.Point(641, 38);
            this.CelestialObjectLabel.Name = "CelestialObjectLabel";
            this.CelestialObjectLabel.Size = new System.Drawing.Size(162, 17);
            this.CelestialObjectLabel.TabIndex = 41;
            this.CelestialObjectLabel.Text = "Celesital Object to Track";
            // 
            // RadioTelescopeTypeBox
            // 
            this.RadioTelescopeTypeBox.Controls.Add(this.PrototypeRadioTelescopeButton);
            this.RadioTelescopeTypeBox.Controls.Add(this.SimulatorRadioTelescopeButton);
            this.RadioTelescopeTypeBox.Location = new System.Drawing.Point(34, 58);
            this.RadioTelescopeTypeBox.Name = "RadioTelescopeTypeBox";
            this.RadioTelescopeTypeBox.Size = new System.Drawing.Size(200, 100);
            this.RadioTelescopeTypeBox.TabIndex = 42;
            this.RadioTelescopeTypeBox.TabStop = false;
            this.RadioTelescopeTypeBox.Text = "Radio Telescope Type";
            // 
            // PrototypeRadioTelescopeButton
            // 
            this.PrototypeRadioTelescopeButton.AutoSize = true;
            this.PrototypeRadioTelescopeButton.Location = new System.Drawing.Point(7, 62);
            this.PrototypeRadioTelescopeButton.Name = "PrototypeRadioTelescopeButton";
            this.PrototypeRadioTelescopeButton.Size = new System.Drawing.Size(90, 21);
            this.PrototypeRadioTelescopeButton.TabIndex = 1;
            this.PrototypeRadioTelescopeButton.TabStop = true;
            this.PrototypeRadioTelescopeButton.Text = "Prototype";
            this.PrototypeRadioTelescopeButton.UseVisualStyleBackColor = true;
            this.PrototypeRadioTelescopeButton.CheckedChanged += new System.EventHandler(this.PrototypeRadioTelescopeButton_CheckedChanged);
            // 
            // SimulatorRadioTelescopeButton
            // 
            this.SimulatorRadioTelescopeButton.AutoSize = true;
            this.SimulatorRadioTelescopeButton.Checked = true;
            this.SimulatorRadioTelescopeButton.Location = new System.Drawing.Point(7, 35);
            this.SimulatorRadioTelescopeButton.Name = "SimulatorRadioTelescopeButton";
            this.SimulatorRadioTelescopeButton.Size = new System.Drawing.Size(88, 21);
            this.SimulatorRadioTelescopeButton.TabIndex = 0;
            this.SimulatorRadioTelescopeButton.TabStop = true;
            this.SimulatorRadioTelescopeButton.Text = "Simulator";
            this.SimulatorRadioTelescopeButton.UseVisualStyleBackColor = true;
            this.SimulatorRadioTelescopeButton.CheckedChanged += new System.EventHandler(this.SimulatorRadioTelescopeButton_CheckedChanged);
            // 
            // CurrentElLabel
            // 
            this.CurrentElLabel.AutoSize = true;
            this.CurrentElLabel.Location = new System.Drawing.Point(644, 177);
            this.CurrentElLabel.Name = "CurrentElLabel";
            this.CurrentElLabel.Size = new System.Drawing.Size(108, 17);
            this.CurrentElLabel.TabIndex = 43;
            this.CurrentElLabel.Text = "Elevation (deg):";
            // 
            // CurrentAzLabel
            // 
            this.CurrentAzLabel.AutoSize = true;
            this.CurrentAzLabel.Location = new System.Drawing.Point(644, 239);
            this.CurrentAzLabel.Name = "CurrentAzLabel";
            this.CurrentAzLabel.Size = new System.Drawing.Size(100, 17);
            this.CurrentAzLabel.TabIndex = 44;
            this.CurrentAzLabel.Text = "Azimuth (deg):";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 759);
            this.Controls.Add(this.CurrentAzLabel);
            this.Controls.Add(this.CurrentElLabel);
            this.Controls.Add(this.RadioTelescopeTypeBox);
            this.Controls.Add(this.CelestialObjectLabel);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.TelescopePositionGraph);
            this.Controls.Add(this.TrackInstructionButton);
            this.Controls.Add(this.CelesitialDropDown);
            this.Controls.Add(this.IntervalInput);
            this.Controls.Add(this.IntervalLabel);
            this.Controls.Add(this.ToggleTimeIntervalButton);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.SlewButton);
            this.Controls.Add(this.AZPositionInput);
            this.Controls.Add(this.ELPositionInput);
            this.Controls.Add(this.ArrivalTimeInput);
            this.Controls.Add(this.ArrivalTimeLabel);
            this.Controls.Add(this.AZPositionLabel);
            this.Controls.Add(this.ELPositionLabel);
            this.Controls.Add(this.ApplicationList);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.IntervalInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TelescopePositionGraph)).EndInit();
            this.RadioTelescopeTypeBox.ResumeLayout(false);
            this.RadioTelescopeTypeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListView ApplicationList;
        private System.Windows.Forms.Button TrackInstructionButton;
        private System.Windows.Forms.ComboBox CelesitialDropDown;
        private System.Windows.Forms.NumericUpDown IntervalInput;
        private System.Windows.Forms.Label IntervalLabel;
        private System.Windows.Forms.Button ToggleTimeIntervalButton;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Button SlewButton;
        private System.Windows.Forms.NumericUpDown AZPositionInput;
        private System.Windows.Forms.NumericUpDown ELPositionInput;
        private System.Windows.Forms.DateTimePicker ArrivalTimeInput;
        private System.Windows.Forms.Label ArrivalTimeLabel;
        private System.Windows.Forms.Label AZPositionLabel;
        private System.Windows.Forms.Label ELPositionLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart TelescopePositionGraph;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label CelestialObjectLabel;
        private System.Windows.Forms.GroupBox RadioTelescopeTypeBox;
        private System.Windows.Forms.RadioButton PrototypeRadioTelescopeButton;
        private System.Windows.Forms.RadioButton SimulatorRadioTelescopeButton;
        private System.Windows.Forms.Label CurrentElLabel;
        private System.Windows.Forms.Label CurrentAzLabel;
    }
}

