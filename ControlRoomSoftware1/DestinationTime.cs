using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public class DestinationTime
    {
        private int type = -1;

        public double dt;
        public DateTime endTime;

        public DestinationTime(double t)
        {
            type = 0;
            dt = t;
        }

        public DestinationTime(DateTime et)
        {
            type = 1;
            endTime = et;
        }

        public double UntilEndTimeInSeconds(DateTime startTime)
        {
            if (type == 0)
            {
                return dt;
            }
            else
            {
                return endTime.Subtract(startTime).TotalSeconds;
            }
        }

        public double EndTimeAsSeconds(double startSeconds)
        {
            if (type == 0)
            {
                return startSeconds + dt;
            }
            else
            {
                return endTime.Ticks / 10000000.0;
            }
        }
    }
}