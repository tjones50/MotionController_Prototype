using System;
using System.Threading;
using System.IO.Ports;
using System.Collections.Generic;

namespace ControlRoomSoftware1
{
    public class SpectraCyberCommunication
    {
        // COM port identifier
        private string commPort;

        // Communication serial port
        private SerialPort serialPort;

        // Parallel processing thread members
        private bool processingThreadActive;
        private Thread processingThread;
        private SpectraCyberRequest processingRequest;
        private List<SpectraCyberResponse> responseList;
        private bool killProcessingThread;

        public SpectraCyberCommunication(string cp)
        {
            // Set communication protocol characteristics
            commPort = cp;

            // Initialize necessary processing thread members
            processingThreadActive = false;
            processingRequest = SpectraCyberRequest.GetNewEmpty();
            responseList = new List<SpectraCyberResponse>();
            killProcessingThread = false;
        }

        // Default constructor that guesses communication will be on COM1 (not recommended)
        public SpectraCyberCommunication() : this("COM1") { }

        // Open the serial connection
        public bool OpenSerialCommunication()
        {
            try
            {
                // Set all the communication protocol requirements, all of these MUST be
                // these values, with the exception of the commPort obviously
                serialPort = new SerialPort(
                    commPort,
                    SpectraCyberReferences.BAUD_RATE,
                    SpectraCyberReferences.PARITY_BITS,
                    SpectraCyberReferences.DATA_BITS,
                    SpectraCyberReferences.STOP_BITS
                )
                {
                    // Set safe timeout values
                    ReadTimeout = SpectraCyberReferences.TIMEOUT_MS,
                    WriteTimeout = SpectraCyberReferences.TIMEOUT_MS
                };

                // Attempt to open the port
                serialPort.Open();
            }
            catch (Exception e)
            {
                if (e is System.IO.IOException
                    || e is InvalidOperationException
                    || e is ArgumentOutOfRangeException
                    || e is ArgumentException
                    || e is UnauthorizedAccessException)
                {
                    return false;
                }
                else
                {
                    // Unknown and unexpected exception type
                    throw;
                }
            }

            return true;
        }

        // Close the serial connection
        public bool CloseSerialCommunication()
        {
            try
            {
                if (serialPort != null)
                {
                    serialPort.Close();
                }
            }
            catch (Exception e)
            {
                if (e is System.IO.IOException)
                {
                    return false;
                }
                else
                {
                    // Unknown and unexpected exception type
                    throw;
                }
            }

            return true;
        }

        // Attempt to start serial communication and start the processing thread
        public bool BringUp()
        {
            bool success = OpenSerialCommunication();

            if (success)
            {
                try
                {
                    // Init thread and start it
                    processingThread = new Thread(new ThreadStart(ProcessingThread));
                    processingThread.Start();
                }
                catch (Exception)
                {
                    success = false;
                }
            }

            return success;
        }

        // Attempt to safely kill the serial communication and the processing thread
        public bool BringDown()
        {
            // Track the state of closing serial communication
            bool success = CloseSerialCommunication();
            
            // Stop the processing thread
            killProcessing();

            // Return success in closing serial communication
            return success;
        }

        // Submit a command and return a response
        public SpectraCyberResponse SendCommand(SpectraCyberRequest request)
        {
            SpectraCyberResponse response = new SpectraCyberResponse();

            // If the request is empty, don't process
            if (request.IsEmpty())
            {
                return response;
            }

            try
            {
                // Attempt to write the command to the serial port
                serialPort.Write(request.CommandString);
            }
            catch (Exception)
            {
                // Something went wrong, return the response
                return response;
            }

            // Command was successfully sent through serial communication
            response.RequestSuccessful = true;
                
            // Give the SpectraCyber some time to process the command
            Thread.Sleep(SpectraCyberReferences.PROCESSING_WAIT_TIME_MS);

            // Check for any significant cases
            switch (request.CommandType)
            {
                // Termination, safely end communication
                case SpectraCyberCommandType.Terminate:
                    CloseSerialCommunication();
                    break;
                    
                // TODO: implement this case further probably
                case SpectraCyberCommandType.ScanStop:
                    break;

                // Purge the serial buffer
                case SpectraCyberCommandType.DataDiscard:
                    serialPort.DiscardInBuffer();
                    break;
                    
                //
                // Do nothing by default
                //
            }

            // The request expects a reply back, capture the data and attach it to the response
            if (request.WaitForReply)
            {
                // Reponse's data is valid (assuming no exceptions are thrown)
                response.Valid = true;

                try
                {
                    // Create a character array in which to store the buffered characters
                    string hexString;

                    // Read a number of characters in the buffer
                    char[] charInBuffer = new char[SpectraCyberReferences.BUFFER_SIZE];
                    int length = serialPort.Read(charInBuffer, 0, request.CharsToRead);

                    // Clip the string to the exact number of bytes read
                    if (SpectraCyberReferences.CLIP_BUFFER_RESPONSE && (length != SpectraCyberReferences.BUFFER_SIZE))
                    {
                        char[] actual = new char[length];

                        for (int i = 0; i < length; i++)
                            actual[i] = charInBuffer[i];

                        hexString = new string(actual);
                    }

                    // Leave the string how it is, with the possibility of chars being 0
                    else
                    {
                        hexString = new string(charInBuffer);
                    }

                    // The replyString's first character is not what was expected
                    if (hexString[0] != request.ResponseIdentifier)
                    {
                        throw new Exception();
                    }

                    // Set the hex string
                    response.HexData = hexString;

                    // Convert the hex string into an int
                    response.DecimalData = SpectraCyberReferences.HexStringToInt(hexString.Substring(1));
                }
                catch (Exception e)
                {
                    // Something went wrong, the response isn't valid
                    Console.WriteLine("ERROR: " + e.ToString());
                    response.Valid = false;
                }
            }

            // Clear the input buffer
            serialPort.DiscardInBuffer();

            // Return the response, no matter what happened
            return response;
        }

        // Thread callback
        public void ProcessingThread()
        {
            // Loop until the thread is attempting to be shutdown
            while (!killProcessingThread)
            {
                // Process is the thread is set to be active, otherwise don't send commands
                if (processingThreadActive)
                {
                    responseList.Add(SendCommand(processingRequest));
                }
            }
        }

        // Set the request that should be continuously processed in the processing thread
        public void SetProcessingRequest(SpectraCyberRequest r)
        {
            processingRequest = r;
        }

        // Set the processing thread to be (in)active
        public void SetProcessingThreadActivity(bool active)
        {
            processingThreadActive = active;
        }

        // Get the list of responses captured in the processing thread
        public List<SpectraCyberResponse> GetResponseList()
        {
            return responseList;
        }

        // Clear the response list
        // Intended to be called either directly before setting the thread active or directly
        // after getting the response list contents and setting the thread inactive
        public void ClearResponseList()
        {
            responseList.Clear();
        }

        // Implicitly kills the processing thread and waits for it to join before returning
        public void killProcessing()
        {
            killProcessingThread = true;
            processingThread.Join();
        }
    }
}