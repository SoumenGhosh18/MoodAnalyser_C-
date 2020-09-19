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
        public MdAnalyserMain()
        {

        }

            public string analyseMood () 
            {
            try
            {
                if (message.Length == 0)
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "Please enter valid input");

                if (message.Contains("sad"))
                    return "sad";
                else 
                        return "happy";
                }
                 catch (MoodAnalyserException e)
               {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_NULL,"please entered valid input");
                }
           }
    }
}
