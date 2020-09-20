﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            Not_A_Valid_Input,ENTERED_EMPTY,ENTERED_NULL, NO_CLASS_FOUND

        }
        string message;
        public ExceptionType type;
        public MoodAnalyserException(ExceptionType type, String message)
        {
            this.type = type;
            this.message = message;

        }
    }
}
