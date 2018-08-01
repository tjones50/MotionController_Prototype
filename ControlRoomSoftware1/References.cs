using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace ControlRoomSoftware1
{
    class TrajectoryReferences
    {
        public static readonly double MAX_VEL_AZ  = 15.0 / 180 * Math.PI; // rad/s
        public static readonly double MAX_VEL_EL  = 3.0 / 180 * Math.PI;  // rad/s
        public static readonly double MAX_ACC_AZ  = 1.0;                  // rad/s^2
        public static readonly double MAX_ACC_EL  = 1.0;                  // rad/s^2
        public static readonly double SYSTEM_JERK = 4.0;                  // rad/s^3

        public static readonly double STEP_TRAJECTORY_MINIMAL_VELOCITY_THRESHOLD = 0.02; // rad/s
        public static readonly double STEP_TRAJECTORY_VELOCITY_CHANGE_THRESHOLD  = 0.1;  // rad/s
    }

    class SpectraCyberReferences
    {
        public static readonly int BAUD_RATE      = 2400;
        public static readonly int DATA_BITS      = 8;
        public static readonly Parity PARITY_BITS = Parity.None;
        public static readonly StopBits STOP_BITS = StopBits.One;
        public static readonly int BUFFER_SIZE    = 8; // Max necessary value should only be 4
        public static readonly int TIMEOUT_MS     = 1000;

        public static readonly int PROCESSING_WAIT_TIME_MS = 70; // TODO: confirm that this is suitable
        public static readonly bool CLIP_BUFFER_RESPONSE   = true;

        public static int HexStringToInt(string hex, int length)
        {
            if (length == 0)
            {
                return 0;
            }

            if (length == 1)
            {
                return HexCharToInt(hex[0]);
            }

            return (int)(HexCharToInt(hex[0]) * Math.Pow(16, length-1)) + HexStringToInt(hex.Substring(1), length - 1);
        }
        public static int HexStringToInt(string hex)
        {
            return HexStringToInt(hex, hex.Length);
        }
        private static int HexCharToInt(char ch)
        {
            int baseVal = Convert.ToByte(ch);

            // Between [0-9]
            if (baseVal >= 48 && baseVal <= 57)
            {
                return baseVal - 48;
            }

            // Between [A-F]
            if (baseVal >= 65 && baseVal <= 70)
            {
                return baseVal - 55;
            }

            // Between [a-f]
            if (baseVal >= 97 && baseVal <= 102)
            {
                return baseVal - 87;
            }

            // Unknown
            return 0;
        }

        public static string IntToHexString(int value)
        {
            string strHex = "0123456789ABCDEF";
            string strTemp = "";

            // First, encode the integer into hex (but backward)
            while (value > 0)
            {
                strTemp = strHex[value % 16] + strTemp;
                value /= 16;
            }

            // Now, pad the string with zeros to make it the correct length
            for (int i = strTemp.Length; i < 4; i++)
            {
                strTemp = "0" + strTemp;
            }

            // Finally, reverse the direction of the string
            string strOutput = "";
            foreach (char ch in strTemp.ToCharArray())
                strOutput = ch + strOutput;

            // Return it
            return strOutput;
        }
    }
}