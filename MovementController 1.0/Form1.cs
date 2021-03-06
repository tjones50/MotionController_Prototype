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
		EncoderSimulator encoder = new EncoderSimulator();
		UnityController unity = new UnityController();

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

        private void ScanButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            ScanInstruction inputInstruction = new ScanInstruction(endAZ, endEL, arrivalTime);
            Graph(inputInstruction);
        }

        private void TrackInstructionButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            CelestialLocation.CelestialObjectEnum celestialObject;

            if (CelesitialDropDown.SelectedItem.Equals("Sun"))
            {
                celestialObject = CelestialLocation.CelestialObjectEnum.Sun;
            }
            else if (CelesitialDropDown.SelectedItem.Equals("Moon"))
            {
                celestialObject = CelestialLocation.CelestialObjectEnum.Moon;
            }
            else
            {
                throw new Exception("Invalid Input");
            }

            TrackCelestialObjectInstruction inputInstruction = new TrackCelestialObjectInstruction(celestialObject, arrivalTime);
            Graph(inputInstruction);
        }

        private void Graph(Instruction instruction)
        {
            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();

			decimal currentAz = encoder.getCurrentAz();
			decimal currentEl = encoder.getCurrentEl();

			instructionInterpreter.ProcessInstructionInput(instruction, new AZELCoordinate(currentAz, currentEl));

            // Graph Elevation vs. Time 
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.elevation);
				encoder.moveEl(cmd.coordinates.elevation);
				unity.sendData(cmd.diffSecs);
				unity.sendData(cmd.coordinates.elevation);
            }

            // Graph Azimuth vs. Time 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.diffSecs, cmd.coordinates.azimuth);
				encoder.moveAz(cmd.coordinates.azimuth);
			}

            // Graph Elevation vs. Azimuth
            this.ELAZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELAZChart.Series[0].Points.AddXY(cmd.coordinates.azimuth, cmd.coordinates.elevation);
            }

			this.label1.Text = "Elevation Position =" + Math.Round(encoder.getCurrentEl()).ToString();
			this.label2.Text = "Azimuth Position =" + Math.Round(encoder.getCurrentAz()).ToString();

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

        private void CelesitialDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrackInstructionButton.Enabled = true;
        }
    }
}
