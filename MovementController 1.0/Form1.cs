using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AASharp;

namespace MovementController_1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SlewButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) {  arrivalTime = ArrivalTimeInput.Value;  }
            else { arrivalTime = DateTime.Now.AddSeconds((double) IntervalInput.Value); }

            SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
            Graph(inputInstruction);
        }

        private void DriftScanButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            SectionalScanInstruction inputInstruction = new SectionalScanInstruction(endAZ, endEL, arrivalTime);
            Graph(inputInstruction);
        }

        private void Graph(Instruction instruction)
        {
            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            instructionInterpreter.ProcessInstructionInput(instruction);

            // Graph Elevation vs. Time 
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.DifferenceInSeconds(), cmd.objective.elevation);
            }

            // Graph Azimuth vs. Time 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.DifferenceInSeconds(), cmd.objective.azimuth);
            }

            // Graph Elevation vs. Azimuth
            this.ELAZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELAZChart.Series[0].Points.AddXY(cmd.objective.azimuth, cmd.objective.elevation);
            }
        }

        private void ToggleTimeIntervalButton_Click(object sender, EventArgs e)
        {
            if (ArrivalTimeInput.Enabled && ArrivalTimeLabel.Enabled)
            {
                ArrivalTimeInput.Enabled = false;
                ArrivalTimeLabel.Enabled = false;
                IntervalInput.Enabled = true;
                IntervalLabel.Enabled = true;
            }
            else if (IntervalInput.Enabled && IntervalLabel.Enabled)
            {
                ArrivalTimeInput.Enabled = true;
                ArrivalTimeLabel.Enabled = true;
                IntervalInput.Enabled = false;
                IntervalLabel.Enabled = false;
            }
            else
            {
                ArrivalTimeInput.Enabled = true;
                ArrivalTimeLabel.Enabled = true;
                IntervalInput.Enabled = false;
                IntervalLabel.Enabled = false;
            }
        }
    }
}
