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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            decimal endEL = ELPositionInput.Value;
            decimal endAZ = AZPositionInput.Value;
            DateTime arrivalTime = ArrivalTimeInput.Value;

            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            PointTimeInstruction inputInstruction = new PointTimeInstruction(endEL, endAZ, arrivalTime);
            instructionInterpreter.InputPointTimeInstruction(inputInstruction);

            // Graph Input 
            this.ELChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.ELChart.Series[0].Points.AddXY(cmd.secOffset, cmd.elevation);
            }

            // Graph Output 
            this.AZChart.Series[0].Points.Clear();
            foreach (var cmd in instructionInterpreter.trajectory)
            {
                this.AZChart.Series[0].Points.AddXY(cmd.secOffset, cmd.azimuth);
            }


        }
    }
}
