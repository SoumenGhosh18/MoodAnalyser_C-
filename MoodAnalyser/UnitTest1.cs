using NUnit.Framework;
using System;
using System.Reflection;

namespace MoodAnalyser
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void when_Sad_Message_Is_Given_Should_Return_Sad()
        {
            try
            {
                MdAnalyserMain md = new MdAnalyserMain(" This is sad message");
                string result = md.analyseMood();
                Assert.AreEqual("sad", result);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, "Please entered valid input");
            }
        }

        [Test]
        public void when_Happy_Message_Is_Given_Should_Return_Happy()
        {
            MdAnalyserMain md = new MdAnalyserMain("happy message");
            string result = md.analyseMood();
            Assert.AreEqual("happy", result);

        }
        [Test]
        public void when_Any_Message_Is_Given_Should_Return_Happy()
        {
            MdAnalyserMain md = new MdAnalyserMain("any message");
            string result = md.analyseMood();
            Assert.AreEqual("happy", result);
        }
        [Test]

        public void when_Null_Message_Is_Given_Should_Return_Happy()
        {
            MdAnalyserMain md = new MdAnalyserMain("null");
            string result = md.analyseMood();
            Assert.AreEqual("happy", result);
        }
        [Test]
        public void when_Empty_Message_Is_Given_Should_Return_MoodAnalyserException()
        {
            try
            {
                MdAnalyserMain md = new MdAnalyserMain(" ");
                string result = md.analyseMood();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, e.type);
            }
        }
        [Test]

        public void when_Null_Message_Is_Given_Should_Return_MoodAnalyserException()
        {
            try
            {
                MdAnalyserMain md = new MdAnalyserMain("If Enter null");
                string result = md.analyseMood();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.ENTERED_NULL, e.type);
            }
        }
        [Test]
        public void WhenGivenMoodAnalyserNameShouldReturnMoodAnalyserObject()
        {
            try
            {
                //modnalysermain m = new mdanalyser();
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain", constructorInfo);
              //  MdAnalyserMain m = new MdAnalyserMain();
                 Assert.IsInstanceOf(typeof(MdAnalyserMain), obj);
               // Assert.AreEqual(obj, m);
                Console.WriteLine("try");
            }
            catch (MoodAnalyserException e)
            {

                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "wrong file");
            }
        }
        [Test]
        public void WhenGivenMoodAnalyserWithWrongNameShouldThrowMoodAnalyserException()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                object obj = MoodAnalyserFactory.InstanceCreator("MdAnalyserMain12bhvyu", constructorInfo);
               // MdAnalyserMain m = new MdAnalyserMain();
                Console.WriteLine("try");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.type);
                Console.WriteLine("catch");

            }
        }
        [Test]
        public void WhenGivenMoodAnalyserWithWrongConstructorShouldThrowMoodAnalyserException()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator("hjvffj");
                object obj = MoodAnalyserFactory.InstanceCreator("MdAnalyserMain", constructorInfo);
                MdAnalyserMain m = new MdAnalyserMain();
                Console.WriteLine("try");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.type);
                Console.WriteLine("catch");

            }
        }
        [Test]
        public void WhenGivenMoodAnalyser_WithParameterConstructor_ProperNameShouldReturnMoodAnalyserObject()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(1);
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain", constructorInfo, "he is is happy mood");
                Assert.IsInstanceOf(typeof(MdAnalyserMain), obj);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "please enter valid input");
            }
        }
        [Test]
        public void WhenGivenMoodAnalyser_WithParameterConstructor_WrongClass_NameShouldThrowMoodAnalyserException()
        {
            try
            {
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain1as]3", constructorInfo, "he is in happy mood");

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.type);
            }
        }
        [Test]
        public void WhenGivenMoodAnalyser_WithParameterConstructor_WhenWrongConstructor_NameShouldThrowMoodAnalyserException()
        {
            try
            {
              
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(22554);
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain", constructorInfo, "i am in happy mood");

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.type);
            }
        }
      
        [Test]
        public void WhenGivenHappyMessageUsingReflection_WhenImproperMethod_ShouldReturnHappy()
        {
            try
            {
                string message = MoodAnalyserFactory.getMethod("MoodAnalyser.MdAnalyserMain", "WrongMethodName", "happy");
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.Not_A_Valid_Input, e.type);
            }
        }
        public static dynamic ChangeTheMood(string className, string mood)
        {
            try
            {
                Type type = Type.GetType(className);
                dynamic change_mood = Activator.CreateInstance(type, mood);
                MethodInfo method = type.GetMethod("getMood");
                dynamic value = method.Invoke(change_mood, new object[] { mood });
                return value;
            }
            catch (Exception e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_NULL, e.Message);
            }
        }
    }
 }
