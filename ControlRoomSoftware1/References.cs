using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class References
    {
        public static readonly double MAX_VEL_AZ  = 15.0 / 180 * Math.PI; // rad/s
        public static readonly double MAX_VEL_EL  = 3.0 / 180 * Math.PI;  // rad/s
        public static readonly double MAX_ACC_AZ  = 1.0; // rad/s^2
        public static readonly double MAX_ACC_EL  = 1.0; // rad/s^2
        public static readonly double SYSTEM_JERK = 4.0; // rad/s^3

        public static readonly double STEP_TRAJECTORY_MINIMAL_VELOCITY_THRESHOLD = 0.02; // rad/s
        public static readonly double STEP_TRAJECTORY_VELOCITY_CHANGE_THRESHOLD  = 0.1;  // rad/s
    }
}