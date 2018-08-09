using System;
using System.Collections.Generic;
using System.Threading;

namespace ControlRoomSoftware1
{
    // This enum describes the two modes that the SpectraCyber can be in at all times
    public enum SpectraCyberModeType
    {
        Unspecified,
        Continuum,
        Spectral
    }

    // This class and its members encapsulates all interaction with the SpectraCyber
    public class SpectraCyber : Receiver
    {
        //
        // Class members
        //

        // Serial communication handler
        private SpectraCyberCommunication comms;

        // Current mode
        private SpectraCyberModeType currentMode;

        //
        // Class methods
        //

        // Constructor
        public SpectraCyber(string commPort)
        {
            // Initialize serial port communication
            comms = new SpectraCyberCommunication(commPort);

            // Default currentMode to Continuum
            currentMode = SpectraCyberModeType.Continuum;

            // Init communication, as well as any other necessary bringup procedure
            BringUnitOnline();

            //
            // Everything below here is for testing
            //

            // Test scanning once
            RecieverResponse response = ScanOnce();
            Console.WriteLine("Testing ScanOnce... Response: [" + response.RequestSuccessful + "] [" + response.Valid + "] [" + response.HexData + "] [" + response.DecimalData + "]");

            // Test scanning repeatedly over a period of 1.5 seconds
            StartScan();
            Thread.Sleep(1500);
            List<RecieverResponse> responses = StopScan();
            Console.WriteLine("Testing StartScan and StopScan... Captured " + responses.Count + " responses.");
            foreach (SpectraCyberResponse r in responses)
                Console.WriteLine("\t[" + r.RequestSuccessful + "] [" + r.Valid + "] [" + r.HexData + "] [" + r.DecimalData + "]");
        }

        // Configuration
        public override void BringUnitOnline()
        {
            // Attempt to open serial communication and start the processing thread
            if (comms.BringUp())
            {
                Console.WriteLine("Connected to unit like a boss!");
            }
            else
            {
                Console.WriteLine("ERROR connecting to unit.");
            }
        }

        public override void BringUnitOffline()
        {
            // Simply disconnect serial communication and kill the processing thread
            comms.BringDown();
        }

        public SpectraCyberResponse SendSpectraCyberRequest(SpectraCyberRequest request)
        {
            // Simply send the command and return that response
            return comms.SendCommand(request);
        }

        // Scan once, based on current mode
        public override RecieverResponse ScanOnce()
        {
            return SendSpectraCyberRequest(CurrentRequest(true, 4));
        }

        // Start scan (Arg: start, stop)
        // TODO: implement a start and stop time procedure
        public override void StartScan()
        {
            comms.SetProcessingRequest(CurrentRequest(true, 4));
            comms.ClearResponseList();
            comms.SetProcessingThreadActivity(true);
        }

        // Stop scan (return scan info)
        public override List<RecieverResponse> StopScan()
        {
            comms.SetProcessingThreadActivity(false);
            return comms.GetResponseList();
        }

        // Generate a SpectraCyberRequest based on currentMode
        public SpectraCyberRequest CurrentRequest(bool waitForReply, int numChars)
        {
            // Based on the current mode, create the proper command string
            string commandString;

            if (currentMode == SpectraCyberModeType.Continuum)
            {
                commandString = "!D000";
            }
            else if (currentMode == SpectraCyberModeType.Spectral)
            {
                commandString = "!D001";
            }
            else
            {
                // Unkown case, default to Continuum
                commandString = "!D000";
            }

            return new SpectraCyberRequest(
                SpectraCyberCommandType.DataRequest,
                commandString,
                waitForReply,
                numChars
            );
        }
    }
}
