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

                // Set the radioTelescopeType to default, will be updated in windowUpdateTimerHandler
                currentRadioTelescopeType = RadioTelescopeEnum.Unspecified;

                // Start window update timer
                StartTimer();

                // Set up timer
                SetupCalender();
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
            CheckRadioTelescopeType();
            TelescopePositionGraph.Series[0].Points[0].XValue = controlRoom.GetPosition(RadioTelescopeEnum.Simulator).azimuth;
            TelescopePositionGraph.Series[0].Points[0].YValues[0] = controlRoom.GetPosition(RadioTelescopeEnum.Simulator).elevation;
        }

        private void CheckRadioTelescopeType()
        {
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

        private void SetupCalender()
        {
            // Iterate through each appointment and add it to the month calander 
            foreach (var appointment in controlRoom.GetAppointmentQueue(currentRadioTelescopeType))
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
            DateTime arrivalTime = getTimeInput();

            // Make sure the arrival time is in the future
            if (DateTime.Now.Subtract(arrivalTime).TotalSeconds < 0)
            {
                try
                {
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

        private DateTime getTimeInput()
        {
            DateTime setArrivalTime;
            if (ArrivalTimeInput.Enabled) { setArrivalTime = ArrivalTimeInput.Value; }
            else { setArrivalTime = DateTime.Now.AddSeconds((double)IntervalInput.Value); }
            return setArrivalTime;
        }

        private CelestialObject getCelestialObjectInput()
        {
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
    }
}
