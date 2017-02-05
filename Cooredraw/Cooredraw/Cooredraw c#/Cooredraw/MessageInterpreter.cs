using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooredraw
{
    class MessageInterpreter
    {
        public static int interpretXCoordinate(string Message)
        {
            return messageInterpreter(Message, "X_COORDINATE");
        }

        public static int interpretYCoordinate(string Message)
        {
            return messageInterpreter(Message, "Y_COORDINATE");
        }

        public static int inerpretProgramState(string Message)
        {
            return messageInterpreter(Message, "STATE");
        }

        public static int interpretRedValue(string Message)
        {
            return messageInterpreter(Message, "RED_VALUE");
        }

        public static int interpretGreenValue(string Message)
        {
            return messageInterpreter(Message, "GREEN_VALUE");
        }

        public static int interpretBlueValue(string Message)
        {
            return messageInterpreter(Message, "BLUE_VALUE");
        }

        static int messageInterpreter(string Message, string stringToLookFor)
        {
            try
            {
                int colonIndex = Message.IndexOf(":");

                if (Message.Substring(0, colonIndex) == stringToLookFor)
                {
                    return Convert.ToInt32(Message.Substring(colonIndex + 1));
                }
            }
            catch (FormatException)
            {
                return Convert.ToInt32(null);
            }
            catch (NullReferenceException)
            {
                return Convert.ToInt32(null);
            }

            return Convert.ToInt32(null);
        }
    }
}
