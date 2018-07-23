using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using MovementController_1;

namespace Scheduler_1
{
    class Scheduler
    {
        private List<Appointment> appointmentQueue;
        private InstructionInterpreter instructionInterpreter;
        private CommandProcessor commandProcessor;

        public Scheduler()
        {
            appointmentQueue = new List<Appointment>();
            instructionInterpreter = new InstructionInterpreter();
            commandProcessor = new MotorDriver();
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
                appointmentTimer.Elapsed += (sender, e) => OnAppointment(sender, e, newAppointment);
                appointmentTimer.AutoReset = false;
                appointmentTimer.Enabled = true;
            }
            return success;
        }

        private void OnAppointment(object sender, ElapsedEventArgs e, Appointment appointment)
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

        public bool submitInstruction(Instruction instruction)
        {
            // check if the trajectoy is possible
            bool approved = instructionInterpreter.CreateTrajectory(instruction, commandProcessor.GetPosition());
            if (approved)
            {
                // if the trajectory is possible, then go through each command in the trajectoty and execute it
                foreach (var command in instructionInterpreter.trajectory)
                {
                    commandProcessor.Move(command);
                }
            }

            return approved;
        }
    }
}
