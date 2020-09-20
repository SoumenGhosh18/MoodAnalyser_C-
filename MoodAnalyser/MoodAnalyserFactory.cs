using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MoodAnalyser
{
    class MoodAnalyserFactory
    {
        public static ConstructorInfo ConstructorCreator()
        {
            try
            {
                Type type = typeof(MdAnalyserMain);
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[0];
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.Message);
            }
        }
        public static ConstructorInfo ConstructorCreator(String message)
        {
            try
            {
                Type type = typeof(MdAnalyserMain);
                ConstructorInfo[] constructor = type.GetConstructors();
                return constructor[3];
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.Message);
            }
        }
        public static ConstructorInfo ConstructorCreator(int noOfParameters)
        {
            try
            {
                Type type = typeof(MdAnalyserMain);
                ConstructorInfo[] constructor = type.GetConstructors();
                foreach (ConstructorInfo index in constructor)
                {
                    int numberOfParam = index.GetParameters().Length;
                    if (numberOfParam == noOfParameters)
                    {
                        return index;
                    }
                }
                return constructor[1];
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.Message);
            }
        }
       
        public static object InstanceCreator(string className, ConstructorInfo constructor)
        {
            try
            {
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                Type type = excutingAssambly.GetType(className);
                //TYpe cast
                MdAnalyserMain reflectionGenratedObject = (MdAnalyserMain)Activator.CreateInstance(type);
                return reflectionGenratedObject;
            }
            catch (Exception e)
            {
                return new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, "invalid input");
            }

        }
        public static object InstanceCreator(string className, ConstructorInfo constructor, string message)
        {
            try
            {
                //Load class
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                //define the type
                Type type = excutingAssambly.GetType(className);
               //obj create
                object reflectionGenratedObject = Activator.CreateInstance(type, message);
                return reflectionGenratedObject;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.Message);
            }
        }
        public static string gettingMethodInfo(string className, string methodName, string message)
        {
            try
            {
                Assembly excutingAssambly = Assembly.GetExecutingAssembly();
                ConstructorInfo constructor = ConstructorCreator(1);
                object obj = InstanceCreator(className, constructor, message);
                
                Type type = excutingAssambly.GetType(className);
                MethodInfo getMoodMethod = type.GetMethod(methodName);
                string[] parameters = new string[1];//bcz one method is there 
                parameters[0] = message;
                return (string)getMoodMethod.Invoke(obj, parameters);
                
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, "invalid input");
            }

        }
        // int []a= {1};
        public static dynamic ChangeTheMood(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                //calling method at run time
                MethodInfo method = type.GetMethod("analyseMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.Message);
            }
        }
    }
}

