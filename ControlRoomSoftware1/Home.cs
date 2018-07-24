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
        Organizer organizer;

        public Home()
        {
            InitializeComponent();
            // Create organizer for 1 telescope
            organizer = new Organizer(1);

            // Generate 10 dummy appointments for testing
            for (int i = 1; i < 10; i++)
            {
                organizer.SubmitAppointment(0,
                    new ActionAppointment(
                        DateTime.Now.AddDays(i),
                        DateTime.Now.AddDays(i).AddHours(2),
                        new User(0,UserLevelEnum.Admin),
                        new List<Instruction>()
                        )
                    );
            }
            SetupCalender();
        }

        private void SetupCalender()
        {
            // Iterate through each appointment and add it to the month calander 
            foreach (var appointment in organizer.GetAppointmentQueue(0))
            {
                monthCalendar1.AddBoldedDate(appointment.StartTime);
            }
        }

        // FIXME
        private void monthCalendar1_CursorChanged(object sender, EventArgs e)
        {
            foreach (var day in monthCalendar1.BoldedDates)
            {
                //foreach (var appointment in scheduler.appointmentQueue)
                //{
                //    // show the daily schedule for that day when the date is selected

                //}
            }
        }
    }
}
