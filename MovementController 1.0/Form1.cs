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
            InstructionInterpreter instructionInterpreter = new InstructionInterpreter();
            PointTimeInstruction inputInstruction = new PointTimeInstruction(ELPositionInput.Value, AZPositionInput.Value, ArrivalTimeInput.Value);
            instructionInterpreter.InputPointTimeInstruction();
        }
    }
}
