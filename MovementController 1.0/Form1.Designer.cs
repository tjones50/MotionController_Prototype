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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ELPositionLabel = new System.Windows.Forms.Label();
            this.AZPositionLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeLabel = new System.Windows.Forms.Label();
            this.ArrivalTimeInput = new System.Windows.Forms.DateTimePicker();
            this.ELPositionInput = new System.Windows.Forms.NumericUpDown();
            this.AZPositionInput = new System.Windows.Forms.NumericUpDown();
            this.OuputChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OuputChart)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(618, 391);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(149, 23);
            this.SubmitButton.TabIndex = 0;
            this.SubmitButton.Text = "Submit Instruction";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ELPositionLabel
            // 
            this.ELPositionLabel.AutoSize = true;
            this.ELPositionLabel.Location = new System.Drawing.Point(45, 364);
            this.ELPositionLabel.Name = "ELPositionLabel";
            this.ELPositionLabel.Size = new System.Drawing.Size(158, 17);
            this.ELPositionLabel.TabIndex = 1;
            this.ELPositionLabel.Text = "Elevation Position (deg)";
            // 
            // AZPositionLabel
            // 
            this.AZPositionLabel.AutoSize = true;
            this.AZPositionLabel.Location = new System.Drawing.Point(223, 364);
            this.AZPositionLabel.Name = "AZPositionLabel";
            this.AZPositionLabel.Size = new System.Drawing.Size(150, 17);
            this.AZPositionLabel.TabIndex = 2;
            this.AZPositionLabel.Text = "Azimuth Position (deg)";
            // 
            // ArrivalTimeLabel
            // 
            this.ArrivalTimeLabel.AutoSize = true;
            this.ArrivalTimeLabel.Location = new System.Drawing.Point(401, 364);
            this.ArrivalTimeLabel.Name = "ArrivalTimeLabel";
            this.ArrivalTimeLabel.Size = new System.Drawing.Size(185, 17);
            this.ArrivalTimeLabel.TabIndex = 3;
            this.ArrivalTimeLabel.Text = "Arrival Time (sec) - Optional";
            // 
            // ArrivalTimeInput
            // 
            this.ArrivalTimeInput.Checked = false;
            this.ArrivalTimeInput.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ArrivalTimeInput.Location = new System.Drawing.Point(404, 392);
            this.ArrivalTimeInput.Name = "ArrivalTimeInput";
            this.ArrivalTimeInput.Size = new System.Drawing.Size(182, 22);
            this.ArrivalTimeInput.TabIndex = 7;
            // 
            // ELPositionInput
            // 
            this.ELPositionInput.Location = new System.Drawing.Point(48, 392);
            this.ELPositionInput.Name = "ELPositionInput";
            this.ELPositionInput.Size = new System.Drawing.Size(155, 22);
            this.ELPositionInput.TabIndex = 8;
            // 
            // AZPositionInput
            // 
            this.AZPositionInput.Location = new System.Drawing.Point(226, 392);
            this.AZPositionInput.Name = "AZPositionInput";
            this.AZPositionInput.Size = new System.Drawing.Size(147, 22);
            this.AZPositionInput.TabIndex = 9;
            // 
            // OuputChart
            // 
            chartArea1.AxisX.Title = "Azimuth Position (deg)";
            chartArea1.AxisY.Title = "Elevation Position (deg)";
            chartArea1.Name = "OutputChartArea";
            this.OuputChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.OuputChart.Legends.Add(legend1);
            this.OuputChart.Location = new System.Drawing.Point(23, 21);
            this.OuputChart.Name = "OuputChart";
            series1.ChartArea = "OutputChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "InputData";
            series2.ChartArea = "OutputChartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "OutputData";
            this.OuputChart.Series.Add(series1);
            this.OuputChart.Series.Add(series2);
            this.OuputChart.Size = new System.Drawing.Size(744, 325);
            this.OuputChart.TabIndex = 10;
            this.OuputChart.Text = "OuputChart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.OuputChart);
            this.Controls.Add(this.AZPositionInput);
            this.Controls.Add(this.ELPositionInput);
            this.Controls.Add(this.ArrivalTimeInput);
            this.Controls.Add(this.ArrivalTimeLabel);
            this.Controls.Add(this.AZPositionLabel);
            this.Controls.Add(this.ELPositionLabel);
            this.Controls.Add(this.SubmitButton);
            this.Name = "Form1";
            this.Text = "User Input";
            ((System.ComponentModel.ISupportInitialize)(this.ELPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AZPositionInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OuputChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label ELPositionLabel;
        private System.Windows.Forms.Label AZPositionLabel;
        private System.Windows.Forms.Label ArrivalTimeLabel;
        private System.Windows.Forms.DateTimePicker ArrivalTimeInput;
        private System.Windows.Forms.NumericUpDown ELPositionInput;
        private System.Windows.Forms.NumericUpDown AZPositionInput;
        private System.Windows.Forms.DataVisualization.Charting.Chart OuputChart;
    }
}

