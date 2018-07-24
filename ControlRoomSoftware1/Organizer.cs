using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class Organizer
    {
        public List<Scheduler> schedulers;

        public Organizer(int numOfTelescopes)
        {
            schedulers = new List<Scheduler>();
            for (int i = 0; i < numOfTelescopes; i++)
            {
                schedulers.Add(new Scheduler(i));
            }
        }

        public void SubmitAppointment(int telescopeID, Appointment appointment)
        {
            Scheduler scheduler = schedulers[telescopeID];
            scheduler.AddAppointment(appointment);
        }

        public void RemoveAppointment(int telescopeID, Appointment appointment)
        {
            Scheduler scheduler = schedulers[telescopeID];
            scheduler.RemoveAppointment(appointment);
        }

        public List<Appointment> GetAppointmentQueue(int telescopeID)
        {
            Scheduler scheduler = schedulers[telescopeID];
            return scheduler.appointmentQueue;
        }
    }
}
