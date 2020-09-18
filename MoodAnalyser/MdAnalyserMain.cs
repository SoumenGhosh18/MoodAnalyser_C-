using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    class MdAnalyserMain
    {
        public  string analyseMood(string message)
        {
            if (message.Contains("sad"))
                return "sad";
            else
                return "happy";
        }
    }
}
