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
                MdAnalyserMain obj = MoodAnalyserFactory.GetMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserMain");
                MdAnalyserMain m = new MdAnalyserMain();
                Assert.IsTrue(obj.ToString().Equals(m.ToString()));
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
                MdAnalyserMain obj = MoodAnalyserFactory.GetMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyserMainabc");
                MdAnalyserMain m = new MdAnalyserMain();

            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual(MoodAnalyserException.ExceptionType.INVALID_INPUT, e.type);

            }
        }
    }
}