using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Cooredraw
{
    class Receive_message
    {
        SerialPort _reveicePort;
        char _beginMessageMarker = '#';
        char _endMessageaMarker = '%';
        bool _beginMessageMarkterDetected = false;

        Queue<string> _messageQueue;
        
        public Receive_message(SerialPort port)
        {
            _reveicePort = port;
            _messageQueue = new Queue<string>();
        }

        public void readMessage()
        {
            string serialMessage = null;
            string message = null;

            if (_reveicePort.IsOpen && _reveicePort.BytesToRead > 0)
            {
                //serialMessage = _reveicePort.ReadExisting();
                serialMessage = _reveicePort.ReadLine();
            }

            if (serialMessage != null)
            {
                foreach (char c in serialMessage)
                {
                    if (c == _beginMessageMarker) // Is # detected?
                    {
                        _beginMessageMarkterDetected = true; // start reading incoming message
                    }
                    else if (c == _endMessageaMarker && _beginMessageMarkterDetected) // Is % detected after # is detected?
                    {
                        _beginMessageMarkterDetected = false; // Stop reading incoming message
                        if (message != null)
                        {
                            if (message.IndexOf('#') == 0)
                            {
                                message = message.Remove(0, 1);
                                _messageQueue.Enqueue(message); // Add incoming message to the queue.
                                message = "";
                            }
                        }
                    }

                    if (_beginMessageMarkterDetected)
                    {
                        message += c; // Build the message.              
                    }
                }
            }
        }

        public string returnMessage()
        {
            if(_messageQueue.Count > 0)
            {
                return _messageQueue.Dequeue();
            }

            return null;
        }
    }
}
