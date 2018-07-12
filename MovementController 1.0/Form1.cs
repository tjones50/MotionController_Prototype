using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            DateTime arrivalTime = ArrivalTimeInput.Value;

            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            MoveToAZELInstruction inputInstruction = new MoveToAZELInstruction(endEL, endAZ, arrivalTime);
            instructionInterpreter.ProcessInstructionInput(inputInstruction);

            // Graph Elevation vs. Time 
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.elevation);
            }

            // Graph Azimuth vs. Time 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.azimuth);
            }

            // Graph Elevation vs. Azimuth
            this.ELAZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELAZChart.Series[0].Points.AddXY(cmd.coordinates.azimuth, cmd.coordinates.elevation);
            }
        }

        private void TrackButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime = ArrivalTimeInput.Value;

            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            TrackInstruction inputInstruction = new TrackInstruction(endEL, endAZ, arrivalTime);
            instructionInterpreter.ProcessInstructionInput(inputInstruction);

            // Graph Elevation vs. Time  
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.elevation);
            }

            // Graph Azimuth vs. Time 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.azimuth);
            }

            // Graph Elevation vs. Azimuth
            this.ELAZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELAZChart.Series[0].Points.AddXY(cmd.coordinates.azimuth, cmd.coordinates.elevation);
            }
        }

        private void DriftScanButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime = ArrivalTimeInput.Value;

            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            DriftScanInstruction inputInstruction = new DriftScanInstruction(endEL, endAZ, arrivalTime);
            instructionInterpreter.ProcessInstructionInput(inputInstruction);

            // Graph Elevation vs. Time 
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.elevation);
            }

            // Graph Azimuth vs. Time 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.azimuth);
            }

            // Graph Elevation vs. Azimuth
            this.ELAZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELAZChart.Series[0].Points.AddXY(cmd.coordinates.azimuth, cmd.coordinates.elevation);
            }
        }

        
    }
}
