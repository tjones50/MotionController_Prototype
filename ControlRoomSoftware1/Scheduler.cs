using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ControlRoomSoftware1
{
    class Scheduler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RadioTelescope radioTelescope;
        public List<Appointment> appointmentQueue;
        private InstructionHandler instructionHandler;

        public Scheduler(RadioTelescope setRadioTelescope)
        {
            radioTelescope = setRadioTelescope;
            appointmentQueue = new List<Appointment>();
            instructionHandler = new InstructionHandler(radioTelescope);
        }

        public bool AddAppointment(Appointment newAppointment)
        {
            bool success = true;
            // iterate through appointments and make sure the timeslot is open
            foreach (var appointment in appointmentQueue)
            {
                if (appointment.StartTime.CompareTo(newAppointment.StartTime) > 0 
                    && appointment.EndTime.CompareTo(newAppointment.EndTime) < 0)
                {
                    success = false;
                    break;
                }
            }
            if (success)
            {
                // add the appointment
                appointmentQueue.Add(newAppointment);
                // add a timer that will go off when the appointment timeslot arrives
                Timer appointmentTimer = new Timer(newAppointment.StartTime.Subtract(DateTime.Now).TotalMilliseconds);
                appointmentTimer.Elapsed += (sender, e) => AppointmentTimerHandler(sender, e, newAppointment);
                appointmentTimer.AutoReset = false;
                appointmentTimer.Start();
            }
            return success;
        }

        public void RemoveAppointment(Appointment appointment)
        {
            // TODO
        }

        private void AppointmentTimerHandler(object sender, ElapsedEventArgs e, Appointment appointment)
        {
            ProcessAppointment(appointment);
        }

        private void ProcessAppointment(Appointment appointment)
        {
            // start a timer for the end of the appointment. When that timer goes off, the user is kicked off and the instructions are cut off
            // if appointment is a controlAppointment connect the user to the instruction interpreter/command processor
            // if appointment is an actionAppointment, connect to the instruction interpreter/command processor to complete that action
            int test = 1; // for a breakpoint
        }

        public void ServiceInstruction(Instruction instruction)
        {
            instructionHandler.ProcessInstruction(instruction);
        }
    }
}
