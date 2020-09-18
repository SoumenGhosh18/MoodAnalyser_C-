using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    class MdAnalyserMain
    {
        public string message;

        public MdAnalyserMain(string message)
        {
            this.message = message;
        }
       /* public  string analyseMood(string message)
        {
            if (message.Contains("sad"))
                return "sad";
            else
                return "happy";
        }*/
         public String analyseMood()
        {
            if (message.Contains("sad"))
                return "sad";
            else
                return "happy";
        }   
    }
}
