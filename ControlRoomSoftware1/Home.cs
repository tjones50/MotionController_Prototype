using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            StartTimer();
            SetupCalender();
        }

        private void StartTimer()
        {
            Timer graphTimer = new Timer();
            graphTimer.Interval = 3000;
            graphTimer.Tick += (sender, e) => GraphTimerHandler(sender, e);
            graphTimer.Start();
        }

        private void GraphTimerHandler(object sender, EventArgs e)
        {
            TelescopePositionGraph.Series[0].Points[0].XValue = organizer.GetPosition(0).azimuth;
            TelescopePositionGraph.Series[0].Points[0].YValues[0] = organizer.GetPosition(0).elevation;
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

        private void SlewButton_Click(object sender, EventArgs e)
        {
            double endEL = (double) ELPositionInput.Value;
            double endAZ = (double) AZPositionInput.Value;
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
            organizer.SubmitInstruction(0, inputInstruction);
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            double endEL = (double)ELPositionInput.Value;
            double endAZ = (double)AZPositionInput.Value;
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            ScanInstruction inputInstruction = new ScanInstruction(endAZ, endEL, arrivalTime);
            organizer.SubmitInstruction(0, inputInstruction);
        }

        private void TrackInstructionButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime;
            if (ArrivalTimeInput.Enabled) { arrivalTime = ArrivalTimeInput.Value; }
            else { arrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }

            CelestialObject celestialObject;

            if (CelesitialDropDown.SelectedItem.Equals("Sun"))
            {
                celestialObject = new Sun();
            }
            else if (CelesitialDropDown.SelectedItem.Equals("Moon"))
            {
                celestialObject = new Moon();
            }
            else
            {
                throw new Exception("Invalid Input");
            }

            TrackCelestialObjectInstruction inputInstruction = new TrackCelestialObjectInstruction(celestialObject, arrivalTime);
            organizer.SubmitInstruction(0, inputInstruction);
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
