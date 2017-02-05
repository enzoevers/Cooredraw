using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace Cooredraw
{
    class Port
    {
        SerialPort _port;
        public SerialPort connectionPort { get { return _port; } }

        public static string[] portNames()
        {
            string[] _portNames;


            _portNames = SerialPort.GetPortNames();

            return _portNames;
        }

        public static List<string> boudrates()
        {
            List<string> boudrateList = new List<string>();

            boudrateList.Add("9600");
            boudrateList.Add("19200");
            boudrateList.Add("38400");
            boudrateList.Add("57600");
            boudrateList.Add("74880");
            boudrateList.Add("115200");
            boudrateList.Add("230400");
            boudrateList.Add("250000");

            return boudrateList;
        }

        public void connect(string Port, int Boudrate)
        {
            _port = new SerialPort(Port, Boudrate);

            try
            {
                if (!_port.IsOpen)
                {
                    _port.Open();
                    if (_port.IsOpen)
                    {
                        _port.DiscardInBuffer();
                        _port.DiscardOutBuffer();
                    }
                }
               
            }
            catch (UnauthorizedAccessException uae)
            {
                _port.Close();
                _port.Dispose();
                Thread.Sleep(1000);
            }
            finally
            {
                if (!_port.IsOpen)
                {
                    _port.Open();
                }
            }

            if (_port.IsOpen)
            {
                //MessageBox.Show("Connected");
            }
        }

        public bool disconnect()
        {
            try
            {
                if (_port.IsOpen)
                {
                    _port.Close();
                    _port.Dispose();
                    Thread.Sleep(1000);                   
                }
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
