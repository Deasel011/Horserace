using System;
using System.Diagnostics;
using HorseRace14.Shit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HorseRace14Tests
{
    [TestClass]
    public class RageServiceTests
    {
        [TestMethod]
        public void TestCallRandomMethod()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RageService.CallRandomMethod();
            stopWatch.Stop();
            Console.Write(stopWatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestCallLeGrosRPG()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RageService.CallLeGrosRPG();
            stopWatch.Stop();
            Console.Write(stopWatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestCallFiveLastClaims()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RageService.CallFiveLastClaims();
            stopWatch.Stop();
            Console.Write(stopWatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestCallProviderSearch()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RageService.CallProviderSearch();
            stopWatch.Stop();
            Console.Write(stopWatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void TestCallBenefitSummary()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            RageService.CallBenefitSummary();
            stopWatch.Stop();
            Console.Write(stopWatch.ElapsedMilliseconds);
        }
    }
}
