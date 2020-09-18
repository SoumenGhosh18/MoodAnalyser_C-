using NUnit.Framework;
using System;

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
            MdAnalyserMain md = new MdAnalyserMain(" This is sad message");
            string result = md.analyseMood();
            Assert.AreEqual("sad", result);
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
            MdAnalyserMain md = new MdAnalyserMain(" ");
            string result = md.analyseMood();
            Assert.AreEqual("happy", result);
        }
    }
}