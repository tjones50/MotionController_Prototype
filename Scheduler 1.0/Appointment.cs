using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementController_1;

namespace Scheduler_1
{
    public abstract class Appointment
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public User user;

        public Appointment(DateTime setStartTime, DateTime setEndTime, User setUser)
        {
            StartTime = setStartTime;
            EndTime = setEndTime;
            user = setUser;
        }
    }

    public class ControlAppointment : Appointment
    {
        public ControlAppointment(DateTime setStartTime, DateTime setEndTime, User setUser) 
            : base(setStartTime, setEndTime, setUser) {}
    }

    public class ActionAppointment : Appointment
    {
        public List<Instruction> actions;

        public ActionAppointment(DateTime setStartTime, DateTime setEndTime, User setUser, List<Instruction> setActions) 
            : base(setStartTime, setEndTime, setUser)
        {
            actions = setActions;
        }
    }

}
