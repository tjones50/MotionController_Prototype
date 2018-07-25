using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    class Reading
    {
        public List<RFData> data;

        public Reading()
        {
            data = new List<RFData>();
        }

        public void AddRFData(double signalLevel)
        {
            data.Add(new RFData(signalLevel, DateTime.Now));
        }
    }
}
