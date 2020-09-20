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
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator();
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain", constructorInfo);
                Assert.IsInstanceOf(typeof(MdAnalyserMain), obj);
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
                ConstructorInfo constructorInfo = MoodAnalyserFactory.ConstructorCreator(3);
                MdAnalyserMain obj = (MdAnalyserMain)MoodAnalyserFactory.InstanceCreator
                ("MoodAnalyser.MdAnalyserMain", constructorInfo, "he is is happy mood");
                Assert.IsInstanceOf(typeof(MdAnalyserMain), obj);
            }
            catch (MoodAnalyserException e)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.ENTERED_EMPTY, "please enter valid input");
            }
        }
    }
}