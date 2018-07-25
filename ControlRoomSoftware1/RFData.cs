using System;

namespace ControlRoomSoftware1
{
    public class RFData
    {
        public double signalLevel;
        public DateTime timeStamp;

        public RFData(double setSignalLevel, DateTime setDateTime)
        {
            signalLevel = setSignalLevel;
            timeStamp = setDateTime;
        }
    }
}