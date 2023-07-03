using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//Create a new static class called DebugLogger.
//In the DebugLogger class, define a static method called LogMessage(). This method should accept a string parameter called message.
//In the LogMessage() method, utilize the
//#if DEBUG preprocessor directive to control when logging is active. When in DEBUG mode, the method should print the message to the console.
//When not in DEBUG mode, the method should do nothing.
//In your Main() method or another method in your program, test the LogMessage() method by logging a simple message.

namespace Task
{
    public static class DebugLogger
    {

        public static void LogMessage(string message)
        {
#if DEBUG
            Console.WriteLine(message);
#endif

        }

    }
}
