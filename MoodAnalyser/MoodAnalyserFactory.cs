using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyserFactory
    {
        public static MdAnalyserMain GetMoodAnalyserObject(string className)
        {
            try
            {
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                MdAnalyserMain MdAnalyserMainObject = (MdAnalyserMain)Activator.CreateInstance(type);
                return MdAnalyserMainObject;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.INVALID_INPUT, "invalid input");
            }
        }
       

    }


    }

