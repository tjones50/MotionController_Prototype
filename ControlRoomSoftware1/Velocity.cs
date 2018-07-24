using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class Velocity
    {
        public double AZSpeed { get; set; } // deg/sec
        public double ELSpeed { get; set; } // deg/sec

        public Velocity(double setAZSpeed, double setELSpeed)
        {
            AZSpeed = setAZSpeed;
            ELSpeed = setELSpeed;
        }

        public Velocity Add(Velocity velocityToAdd)
        {
            return new Velocity(AZSpeed + velocityToAdd.AZSpeed, ELSpeed + velocityToAdd.ELSpeed);
        }
    }
}
