using NUnit.Framework;
using System;
using System.Diagnostics;
using TroopyMonitor.Business;

namespace TroopyMonitor.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void dd()
        {
            Trace.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        [Test]
        public void Get_Age()
        {
            // return "You are " + result + " days old.";
            Trace.WriteLine(">>>> " + Calculator.CalculateAge(DateTime.Parse("1960-5-5")));
        }
    }
}