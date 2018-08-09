using System;
using System.Collections.Generic;
using System.Text;

namespace ControlRoomSoftware1
{
    public enum SpectraCyberCommandType
    {
        // Default value is unknown
        Unknown,

        // Specifies an empty command that should not be processed, null-like behavior
        Empty,

        // Actual commands, in a general order of priority
        // Nothing below here has to be permanent, this is what I just put for the time being
        Terminate,
        Reset,
        ChangeSetting,
        ScanStart,
        ScanStop,
        Rescan,
        DataRequest,
        FrequencySet,
        DataDiscard,
        GeneralCommunication
    }

    public class SpectraCyberRequest
    {
        // Constructor with specified parameters
        public SpectraCyberRequest(SpectraCyberCommandType ct, string cs, bool wr, int cr, char ri)
        {
            CommandType = ct;
            Priority = CalcPriority();
            CommandString = cs;
            WaitForReply = wr;
            CharsToRead = cr <= 0 ? SpectraCyberReferences.BUFFER_SIZE : cr;
            ResponseIdentifier = ri;
        }

        // Constructor with specified parameters, default response identier to the same as the command string
        public SpectraCyberRequest(SpectraCyberCommandType ct, string cs, bool wr, int cr)
            : this(ct, cs, wr, cr, cs[1]) { }

        // Get the command type
        public SpectraCyberCommandType CommandType { get; }

        // Get the command's priority
        public int Priority { get; }

        // Get or Set the command string
        public string CommandString { get; set; }

        // Get the number of characters to read from the serial port
        public int CharsToRead { get; }

        // Get whether or not the command should expect a reply
        public bool WaitForReply { get; }

        // Get the expected character identifier for a response
        public char ResponseIdentifier { get; }

        // Set the priority of this command
        private int CalcPriority()
        {
            switch (CommandType)
            {
                // Cover the unknown case first
                case SpectraCyberCommandType.Unknown:
                    return 6;

                // Then, the empty case
                case SpectraCyberCommandType.Empty:
                    return 5;

                //
                // Finally, the standard cases...
                //

                case SpectraCyberCommandType.DataDiscard:
                case SpectraCyberCommandType.DataRequest:
                case SpectraCyberCommandType.FrequencySet:
                case SpectraCyberCommandType.GeneralCommunication:
                case SpectraCyberCommandType.Rescan:
                    return 4;

                case SpectraCyberCommandType.ScanStart:
                case SpectraCyberCommandType.ScanStop:
                    return 3;

                case SpectraCyberCommandType.ChangeSetting:
                    return 2;

                case SpectraCyberCommandType.Reset:
                    return 1;

                case SpectraCyberCommandType.Terminate:
                    return 0;

                // Could not find the case, return lowest priority
                default:
                    return 6;
            }
        }

        // Check if the request is of type Empty
        public bool IsEmpty()
        {
            return CommandType == SpectraCyberCommandType.Empty;
        }

        // Create a new Empty request
        public static SpectraCyberRequest GetNewEmpty()
        {
            return new SpectraCyberRequest(
                SpectraCyberCommandType.Empty,
                "EMPTY",
                false,
                0
            );
        }
    }

    // This class acts as a wrapper of a response to a command published to the SpectraCyber
    public class SpectraCyberResponse : RecieverResponse
    {
        public SpectraCyberResponse()
        {
            RequestSuccessful = false;
            Valid = false;

            // HexData was added as a debugging tool, it can be removed if desired
            HexData = "";

            DecimalData = 0;
        }

        // Whether or not the command was successfully sent
        public bool RequestSuccessful{ get; set; }

        // Whether or not the response is valid and populated
        public bool Valid { get; set; }

        // The hexadecimal value pertaining to this response
        public string HexData { get; set; }

        // The decimal value pertaining to this response
        public int DecimalData { get; set; }
    }
}