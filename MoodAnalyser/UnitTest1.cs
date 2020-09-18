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
        public void whenSad_Message_Is_Given_Should_Return_Sad()
        {
            MdAnalyserMain md = new MdAnalyserMain();
            string result = md.analyseMood("sad message");
            Assert.AreEqual("sad", result);
        }
    }
}