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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        ControlRoom controlRoom;
        RadioTelescopeEnum currentRadioTelescopeType;

        public Home()
        {
            try
            {
                InitializeComponent();
                
                // Create control room
                controlRoom = new ControlRoom();

                // Set the radioTelescopeType to default, will be updated in WindowUpdateTimerHandler
                currentRadioTelescopeType = RadioTelescopeEnum.Unspecified;

                // Create/select correct radio telescope
                CheckRadioTelescopeType();

                // Show appointments on calender
                UpdateCalender();

                // Show list of appointments from default selected day
                showAppointmentsForDate(DateTime.Now);

                // Start window update timer
                StartTimer();

            }
            catch (Exception error)
            {
                ErrorLabel.Text = error.Message;
            }
        }

        // Timer goes off every 0.1 second all calls graphTimerHandler
        private void StartTimer()
        {
            Timer windowUpdateTimer = new Timer();
            windowUpdateTimer.Interval = 100;
            windowUpdateTimer.Tick += (sender, e) => WindowUpdateTimerHandler(sender, e);
            windowUpdateTimer.Start();
        }

        // Updates the graph when the timer goes off every 0.1 second
        private void WindowUpdateTimerHandler(object sender, EventArgs e)
        {
            // Update Graph
            TelescopePositionGraph.Series[0].Points[0].XValue = controlRoom.GetPosition(RadioTelescopeEnum.Simulator).azimuth;
            TelescopePositionGraph.Series[0].Points[0].YValues[0] = controlRoom.GetPosition(RadioTelescopeEnum.Simulator).elevation;
        }

        private void CheckRadioTelescopeType()
        {
            // Set the current radio telescope type based on the radio buttons
            if(SimulatorRadioTelescopeButton.Checked)
            {
                currentRadioTelescopeType = RadioTelescopeEnum.Simulator;
                if (!controlRoom.DoesRadioTelescopeExist(currentRadioTelescopeType))
                {
                    controlRoom.AddRadioTelescope(new SimulatorRadioTelescope());
                }
            }
            else if (PrototypeRadioTelescopeButton.Checked)
            {
                currentRadioTelescopeType = RadioTelescopeEnum.Prototype;
                if (!controlRoom.DoesRadioTelescopeExist(currentRadioTelescopeType))
                {
                    controlRoom.AddRadioTelescope(new PrototypeRadioTelescope());
                }
            }
        }

        private void UpdateCalender()
        {
            // Iterate through each appointment and add it to the month calander 
            foreach (var appointment in controlRoom.GetAppointmentQueue(currentRadioTelescopeType))
            {
                monthCalendar1.AddBoldedDate(appointment.StartTime);
            }
            monthCalendar1.UpdateBoldedDates();
        }

        private void showAppointmentsForDate(DateTime day)
        {
            // Show a list of all appointments on a given day
            ApplicationList.Clear();
            List<Appointment> appointmentsToday = controlRoom.GetAppointmentsFromDay(currentRadioTelescopeType, day);
            foreach (var appointment in appointmentsToday)
            {
                ApplicationList.Items.Add(appointment.StartTime.ToShortTimeString() + "-" + appointment.EndTime.ToShortTimeString() + " (" + appointment.user.UserName + ")");
            }
            //ApplicationList.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void SlewButton_Click(object sender, EventArgs e)
        {
            double endEL = (double) ELPositionInput.Value;
            double endAZ = (double) AZPositionInput.Value;
            DateTime arrivalTime = getTimeInput();

            // Make sure the arrival time is in the future
            if (DateTime.Now.Subtract(arrivalTime).TotalSeconds < 0)
            {
                try
                {
                    // Submit a slew instruction
                    SlewInstruction inputInstruction = new SlewInstruction(endAZ, endEL, arrivalTime);
                    controlRoom.SubmitInstruction(RadioTelescopeEnum.Simulator, inputInstruction);
                    //organizer.SubmitInstruction(RadioTelescopeEnum.Prototype, inputInstruction); // Can't use unless COM3 is set up
                }
                catch (Exception error)
                {

                    ErrorLabel.Text = error.Message;
                }
            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            double endEL = (double)ELPositionInput.Value;
            double endAZ = (double)AZPositionInput.Value;
            DateTime arrivalTime = getTimeInput();

            // Make sure the arrival time is in the future
            if (DateTime.Now.Subtract(arrivalTime).TotalSeconds < 0)
            {
                try
                {
                    // Submit a scan instruction
                    SectionalScanInstruction inputInstruction = new SectionalScanInstruction(endAZ, endEL, arrivalTime);
                    controlRoom.SubmitInstruction(RadioTelescopeEnum.Simulator, inputInstruction);
                }
                catch (Exception error)
                {

                    ErrorLabel.Text = error.Message;
                }
                
            }
        }

        private void TrackInstructionButton_Click(object sender, EventArgs e)
        {
            DateTime arrivalTime = getTimeInput();
            // Make sure the arrival time is in the future
            if (DateTime.Now.Subtract(arrivalTime).TotalSeconds < 0)
            {
                try
                {
                    // Submit a TrackingInstruction
                    CelestialObject celestialObject = getCelestialObjectInput();
                    TrackInstruction inputInstruction = new TrackInstruction(celestialObject, arrivalTime);
                    controlRoom.SubmitInstruction(RadioTelescopeEnum.Simulator, inputInstruction);
                }
                catch (Exception error)
                {
                    ErrorLabel.Text = error.Message;
                }
                
            }
        }


        private void ToggleTimeIntervalButton_Click(object sender, EventArgs e)
        {
            // Toggle the time interval based on what is currently enabled, only enabling one at a time
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
            // Enable the track instruction botton once a celesial body is selected for the first time
            TrackInstructionButton.Enabled = true;
        }

        private DateTime getTimeInput()
        {
            // Get the corrent time input depending on which input is enabled by the toggle button
            DateTime setArrivalTime;
            if (ArrivalTimeInput.Enabled) { setArrivalTime = ArrivalTimeInput.Value; }
            else { setArrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }
            return setArrivalTime;
        }

        private CelestialObject getCelestialObjectInput()
        {
            // Convert dropdown selection into selected celestial object
            CelestialObject setCelestialObject;
            if (CelesitialDropDown.SelectedItem.Equals("Sun"))
            {
                setCelestialObject = new Sun();
            }
            else if (CelesitialDropDown.SelectedItem.Equals("Moon"))
            {
                setCelestialObject = new Moon();
            }
            else
            {
                log.Error("Invalid CelesialDropDown Input");
                throw new Exception("Invalid Input");
            }
            return setCelestialObject;
        }

        private void SimulatorRadioTelescopeButton_CheckedChanged(object sender, EventArgs e)
        {
            // Create/select correct radio telescope
            CheckRadioTelescopeType();
        }

        private void PrototypeRadioTelescopeButton_CheckedChanged(object sender, EventArgs e)
        {
            // Create/select correct radio telescope
            CheckRadioTelescopeType();
        }

        private void monthCalendar1_CursorChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Show list of appointments from selected day
            showAppointmentsForDate(monthCalendar1.SelectionStart);
        }
    }
}
