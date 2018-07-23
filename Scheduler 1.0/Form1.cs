using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_1
{
    public partial class Form1 : Form
    {
        private Scheduler scheduler;

        public Form1()
        {
            InitializeComponent();
            scheduler = new Scheduler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scheduler.AddAppointment(new ControlAppointment(DateTime.Now.AddSeconds(10), DateTime.Now.AddSeconds(30), 1));
        }
    }
}
