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
    public partial class CelestialLocationGraph : Form
    {
        public CelestialLocationGraph()
        {
            InitializeComponent();
        }

        private void TrackSunButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            AAS2DCoordinate sunPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Sun, arrivalTime);

            decimal endEL = (decimal) sunPos.Y;
            decimal endAZ = (decimal) sunPos.X;

            ELValue.Value = endEL;
            AZValue.Value = endAZ;

            SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
            Graph(inputInstruction);
        }

        private void TrackMoonButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            AAS2DCoordinate moonPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Moon, arrivalTime);

            decimal endEL = (decimal) moonPos.Y;
            decimal endAZ = (decimal) moonPos.X;

            ELValue.Value = endEL;
            AZValue.Value = endAZ;

            SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
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
