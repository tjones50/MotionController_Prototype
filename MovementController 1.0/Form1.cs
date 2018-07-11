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
            // Graphing Test
            int test = 0;
            foreach( var series in this.OuputChart.Series)
            {
                series.Points.Clear();
                series.Points.AddXY(0, 0);
                series.Points.AddXY(ELPositionInput.Value, AZPositionInput.Value + test);
                test++;
            }
            
            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            PointTimeInstruction inputInstruction = new PointTimeInstruction(ELPositionInput.Value, AZPositionInput.Value, ArrivalTimeInput.Value);
            instructionInterpreter.InputPointTimeInstruction(inputInstruction);
        }
    }
}
