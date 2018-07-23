using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlRoomSoftware1
{
    public partial class Home : Form
    {
        Scheduler scheduler;

        public Home()
        {
            InitializeComponent();
            // Generate 10 dummy appointments for testing
            scheduler = new Scheduler();
            for (int i = 0; i < 10; i++)
            {
                scheduler.AddAppointment(
                    new ActionAppointment(
                        DateTime.Now.AddDays(i),
                        DateTime.Now.AddDays(i).AddHours(2),
                        new User(),
                        new List<Instruction>()
                        )
                    );
            }
            SetupCalender();
        }

        private void SetupCalender()
        {
            // Iterate through each appointment and add it to the month calander 
            foreach (var appointment in scheduler.appointmentQueue)
            {
                monthCalendar1.AddBoldedDate(appointment.StartTime);

            }
        }

        private void monthCalendar1_CursorChanged(object sender, EventArgs e)
        {
            foreach (var appointment in scheduler.appointmentQueue)
            {
                // show the daily schedule for that day when the date is selected
            }
        }
    }
}
