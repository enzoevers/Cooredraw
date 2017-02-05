using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Cooredraw
{
    class Send_message
    {
        SerialPort _reveicerPort;
        char _beginMarker = '#';
        char _endMarker = '%';

        public Send_message(SerialPort Port)
        {
            _reveicerPort = Port;
        }

        /// <summary>
        /// Send the given parameter in the format #paramter% to the arduino.
        /// </summary>
        /// <param name="Messages"></param>
        public void sendMessage(string Messages)
        {
            if (_reveicerPort.IsOpen)
            {
                string _messageToSend = string.Format(_beginMarker + Messages + _endMarker);
                _reveicerPort.WriteLine(_messageToSend);
            }
        }
    }
}
