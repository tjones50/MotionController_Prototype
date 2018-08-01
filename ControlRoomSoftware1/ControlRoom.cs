using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class ControlRoom
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<Scheduler> schedulers;
        public SpectraCyber spectraCyber;

        public ControlRoom()
        {
            // Create SpecraCyber and set it up
            spectraCyber = new SpectraCyber("COM1");

            // Initialize a list of schedulers
            schedulers = new List<Scheduler>();
        }

        public void AddRadioTelescope(RadioTelescope radioTelescopeToAdd)
        {
            schedulers.Add(new Scheduler(radioTelescopeToAdd));

            // Generate 10 dummy appointments for testing
            for (int i = 1; i < 15; i++)
            {
                for (int j = 1; j < 15; j++)
                {
                    SubmitAppointment(radioTelescopeToAdd.radioTelescopeType,
                    new ActionAppointment(
                        DateTime.Now.AddDays(i).AddHours(j),
                        DateTime.Now.AddDays(i).AddHours(j+1),
                        new User(0, "Kerry", UserLevelEnum.Admin),
                        new List<Instruction>()
                        )
                    );
                }
            }
        }

        public bool DoesRadioTelescopeExist(RadioTelescopeEnum radioTelescopeType)
        {
            bool radioTelescopeExists = false;
            foreach (var scheduler in schedulers)
            {
                if (scheduler.radioTelescope.radioTelescopeType.Equals(radioTelescopeType))
                {
                    radioTelescopeExists = true;
                    break;
                }
            }
            return radioTelescopeExists;
        }

        public void SubmitAppointment(RadioTelescopeEnum targetTelescopeType, Appointment appointment)
        {
            try
            {
                if (DoesRadioTelescopeExist(targetTelescopeType))
                {
                    Scheduler scheduler = schedulers.Find(x => x.radioTelescope.radioTelescopeType.Equals(targetTelescopeType));
                    scheduler.AddAppointment(appointment);
                }
            }
            catch(Exception e)
            {
                log.Error(e.Message);
                throw e; 
            }
        }

        public void RemoveAppointment(RadioTelescopeEnum targetTelescopeType, Appointment appointment)
        {
            try
            {
                if (DoesRadioTelescopeExist(targetTelescopeType))
                {
                    Scheduler scheduler = schedulers.Find(x => x.radioTelescope.radioTelescopeType.Equals(targetTelescopeType));
                    scheduler.RemoveAppointment(appointment);
                }
            }
            catch(Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        public void SubmitInstruction(RadioTelescopeEnum targetTelescopeType, Instruction instruction)
        {
            try
            {
                if (DoesRadioTelescopeExist(targetTelescopeType))
                {
                    Scheduler scheduler = schedulers.Find(x => x.radioTelescope.radioTelescopeType.Equals(targetTelescopeType));
                    scheduler.ServiceInstruction(instruction);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            }
        }

        public List<Appointment> GetAppointmentQueue(RadioTelescopeEnum targetTelescopeType)
        {
            try
            {
                List<Appointment> apppointmentQueue = new List<Appointment>();
                if(DoesRadioTelescopeExist(targetTelescopeType))
                {
                    Scheduler scheduler = schedulers.Find(x => x.radioTelescope.radioTelescopeType.Equals(targetTelescopeType));
                    apppointmentQueue =  scheduler.appointmentQueue;
                }
                return apppointmentQueue;
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                throw e;
            } 
        }

        internal List<Appointment> GetAppointmentsFromDay(RadioTelescopeEnum targetTelescopeType, DateTime day)
        {
            List<Appointment> appointmentsFromDay = new List<Appointment>();
            foreach (var appointment in GetAppointmentQueue(targetTelescopeType))
            {
                if (appointment.StartTime.Date.Equals(day.Date))
                {
                    appointmentsFromDay.Add(appointment);
                }
            }
            return appointmentsFromDay;
        }

        public Coordinate GetPosition(RadioTelescopeEnum targetTelescopeType)
        {
            try
            {
                Coordinate position = new Coordinate(0, 0);
                if (DoesRadioTelescopeExist(targetTelescopeType))
                {
                    Scheduler scheduler = schedulers.Find(x => x.radioTelescope.radioTelescopeType.Equals(targetTelescopeType));
                    position = scheduler.radioTelescope.GetPosition();
                }
                return position;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
