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

            double endEL = sunPos.Y;
            double endAZ = sunPos.X;

            ELValue.Value = (decimal)endEL;
            AZValue.Value = (decimal)endAZ;

            SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
            Graph(inputInstruction);
        }

        private void TrackMoonButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            AAS2DCoordinate moonPos = CelestialLocation.CelestialObjectSwitch(CelestialLocation.CelestialObjectEnum.Moon, arrivalTime);

            double endEL = moonPos.Y;
            double endAZ = moonPos.X;

            ELValue.Value = (decimal)endEL;
            AZValue.Value = (decimal)endAZ;

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
