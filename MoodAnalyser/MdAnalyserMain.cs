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

            public string analyseMood () 
            {
            try
            {
                if (message.Length == 0)
                    throw new MoodAnalyserException("Exception");

                if (message.Contains("sad"))
                    return "sad";
                else 
                        return "happy";
                }
                 catch (MoodAnalyserException e)
               {
                throw new MoodAnalyserException("Exception");
                }
           }
    }
}
