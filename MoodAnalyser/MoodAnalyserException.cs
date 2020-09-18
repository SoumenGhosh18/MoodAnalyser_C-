using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyserException : Exception
    {
        string message;
        public MoodAnalyserException(string message)
        {
            this.message = message;

        }
    }
}
