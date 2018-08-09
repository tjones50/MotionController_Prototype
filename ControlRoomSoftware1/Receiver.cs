using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlRoomSoftware1
{
    public abstract class Receiver
    {
        public abstract void BringUnitOnline();
        public abstract void BringUnitOffline();
        public abstract void StartScan();
        public abstract RecieverResponse ScanOnce();
        public abstract List<RecieverResponse> StopScan();
    }

    public interface RecieverResponse
    {
        // Whether or not the command was successfully sent
        bool RequestSuccessful { get; set; }

        // Whether or not the response is valid and populated
        bool Valid { get; set; }

        // The hexadecimal value pertaining to this response
        string HexData { get; set; }

        // The decimal value pertaining to this response
        int DecimalData { get; set; }
    }
}
